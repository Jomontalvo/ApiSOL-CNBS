namespace SolCnbs.Api.Helpers;

public static class StringExtensions
{
    public static int GetIntBeforeDash(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return 0;

        var parts = input.Split('-');

        if (parts.Length == 0)
            return 0;

        if (int.TryParse(parts[0].Trim(), out int result))
            return result;

        return 0;
    }
}
