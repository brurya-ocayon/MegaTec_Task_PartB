using MegaTec_Task.Data;
using MegaTec_Task.DTOs;
using MegaTec_Task.Models;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;

namespace MegaTec_Task.Services;

public sealed class PersonService : IPersonService
{
    private static readonly HashSet<string> AllowedImageExtensions =
        new(StringComparer.OrdinalIgnoreCase) { ".jpg", ".jpeg", ".png" };

    private readonly ApplicationDbContext _dbContext;
    private readonly IWebHostEnvironment _environment;

    public PersonService(ApplicationDbContext dbContext, IWebHostEnvironment environment)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        ArgumentNullException.ThrowIfNull(environment);
        _dbContext = dbContext;
        _environment = environment;
    }

    public async Task<Person> CreatePersonAsync(PersonCreateDto dto, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(dto);

        string? imageRelativePath = null;
        if (dto.ImageFile is { Length: > 0 })
        {
            var extension = Path.GetExtension(dto.ImageFile.FileName);
            if (!AllowedImageExtensions.Contains(extension))
                throw new ArgumentException("Only JPG, JPEG, and PNG images are allowed.", nameof(dto));

            var webRoot = _environment.WebRootPath;
            if (string.IsNullOrWhiteSpace(webRoot))
                webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            var imagesDir = Path.Combine(webRoot, "images");
            Directory.CreateDirectory(imagesDir);

            var fileName = $"{Guid.NewGuid():N}{extension}";
            var physicalPath = Path.Combine(imagesDir, fileName);
            await using (var stream = new FileStream(physicalPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await dto.ImageFile.CopyToAsync(stream, cancellationToken);
            }

            imageRelativePath = Path.Combine("images", fileName).Replace('\\', '/');
        }

        var person = new Person
        {
            Id = Guid.NewGuid(),
            FullName = dto.FullName,
            Phone = dto.Phone,
            Email = dto.Email,
            ImagePath = imageRelativePath
        };

        await _dbContext.Persons.AddAsync(person, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return person;
    }

    public async Task<IReadOnlyList<Person>> GetAllPeopleAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Persons.AsNoTracking().OrderBy(p => p.FullName).ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Person>> SearchByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        name ??= string.Empty;
        return await _dbContext.Persons.AsNoTracking()
            .Where(p => p.FullName.Contains(name))
            .OrderBy(p => p.FullName)
            .ToListAsync(cancellationToken);
    }

    public async Task<byte[]> ExportPeoplePdfAsync(CancellationToken cancellationToken = default)
    {
        var people = await _dbContext.Persons.AsNoTracking().OrderBy(p => p.FullName).ToListAsync(cancellationToken);

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(25);
                page.Content().Column(column =>
                {
                    column.Spacing(8);
                    column.Item().Text("People").SemiBold().FontSize(18);
                    column.Item().Text("Name | Phone | Email").SemiBold();

                    foreach (var person in people)
                    {
                        column.Item().Text($"{person.FullName} | {person.Phone} | {person.Email}");
                    }
                });
            });
        }).GeneratePdf();
    }
}
