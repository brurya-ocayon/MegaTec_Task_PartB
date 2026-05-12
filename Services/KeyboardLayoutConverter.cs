
namespace MegaTec_Task.Services;

public static class KeyboardLayoutConverter
{
    private static readonly Dictionary<char, char> EnglishToHebrew = new()
    {
        ['q'] = '/',
        ['w'] = '\'',
        ['e'] = 'ק',
        ['r'] = 'ר',
        ['t'] = 'א',
        ['y'] = 'ט',
        ['u'] = 'ו',
        ['i'] = 'ן',
        ['o'] = 'ם',
        ['p'] = 'פ',

        ['a'] = 'ש',
        ['s'] = 'ד',
        ['d'] = 'ג',
        ['f'] = 'כ',
        ['g'] = 'ע',
        ['h'] = 'י',
        ['j'] = 'ח',
        ['k'] = 'ל',
        ['l'] = 'ך',

        ['z'] = 'ז',
        ['x'] = 'ס',
        ['c'] = 'ב',
        ['v'] = 'ה',
        ['b'] = 'נ',
        ['n'] = 'מ',
        ['m'] = 'צ'
    };

    private static readonly Dictionary<char, char> HebrewToEnglish = new()
    {
        ['/'] = 'q',
        ['\''] = 'w',
        ['ק'] = 'e',
        ['ר'] = 'r',
        ['א'] = 't',
        ['ט'] = 'y',
        ['ו'] = 'u',
        ['ן'] = 'i',
        ['ם'] = 'o',
        ['פ'] = 'p',

        ['ש'] = 'a',
        ['ד'] = 's',
        ['ג'] = 'd',
        ['כ'] = 'f',
        ['ע'] = 'g',
        ['י'] = 'h',
        ['ח'] = 'j',
        ['ל'] = 'k',
        ['ך'] = 'l',

        ['ז'] = 'z',
        ['ס'] = 'x',
        ['ב'] = 'c',
        ['ה'] = 'v',
        ['נ'] = 'b',
        ['מ'] = 'n',
        ['צ'] = 'm'
    };

    public static string? GetAlternateLayout(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        bool hasEnglish = input.Any(c => EnglishToHebrew.ContainsKey(char.ToLowerInvariant(c)));
        bool hasHebrew = input.Any(c => HebrewToEnglish.ContainsKey(c));

        if (hasEnglish)
            return Convert(input, EnglishToHebrew);

        if (hasHebrew)
            return Convert(input, HebrewToEnglish);

        return null;
    }

    private static string Convert(string input, Dictionary<char, char> map)
    {
        var result = input
            .Select(c =>
            {
                var lower = char.ToLowerInvariant(c);
                return map.TryGetValue(lower, out var mapped)
                    ? mapped
                    : c;
            });

        return new string(result.ToArray());
    }
}