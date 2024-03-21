using System.Net.Mail;

namespace Helmer.Shared.Common.Extensions;

/// <summary>
///     Extends the <see cref="string" />
/// </summary>
public static class StringExtensions
{
    /// <summary>
    ///     Indicates whether a specified string is null, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="input">this string</param>
    /// <returns>
    ///     true if the value parameter is null or System.String.Empty, or if value consists exclusively of white-space
    ///     characters.
    /// </returns>
    public static bool IsNullOrWhiteSpace(this string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }

    /// <summary>
    ///     Indicates whether the specified string is null or an empty string ("").
    /// </summary>
    /// <param name="input">this string</param>
    /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
    public static bool IsNullOrEmpty(this string input)
    {
        return string.IsNullOrEmpty(input);
    }

    /// <summary>
    ///     Combine two separate urls
    /// </summary>
    /// <param name="firstUrl">The first part of the url to be combined</param>
    /// <param name="secondUrl">The second part of the url to be combined</param>
    /// <returns>Combined url as a string</returns>
    public static string CombineUrls(this string firstUrl, string secondUrl)
    {
        firstUrl = firstUrl.TrimEnd('/');
        secondUrl = secondUrl.TrimStart('/');
        return string.Format("{0}/{1}", firstUrl, secondUrl);
    }

    /// <summary>
    ///     Indicates whether the string is a valid email
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public static bool IsValidEmail(this string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith(".")) return false;
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    ///     Removes all kinds of line endings in a string
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string RemoveLineEndings(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        var lineSeparator = ((char)0x2028).ToString();
        var paragraphSeparator = ((char)0x2029).ToString();

        return input.Replace("\r\n", string.Empty)
            .Replace("\n", string.Empty)
            .Replace("\r", string.Empty)
            .Replace(lineSeparator, string.Empty)
            .Replace(paragraphSeparator, string.Empty);
    }

    /// <summary>
    ///     Changes the first character to uppercase https://code-maze.com/csharp-first-letter-upper-case/
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string FirstToUpper(this string input)
    {
        if (input.IsNullOrWhiteSpace()) return string.Empty;
        Span<char> destination = stackalloc char[1];
        input.AsSpan(0, 1).ToUpperInvariant(destination);
        return $"{destination}{input.AsSpan(1)}";
    }

    /// <summary>
    /// Crops a string to a desired length and appends an ellipsis at the end
    /// </summary>
    /// <param name="input"></param>
    /// <param name="desiredLength"></param>
    /// <returns></returns>
	public static string CropStringWithEllipsis(this string input, int desiredLength)
	{
		if (input.Length <= desiredLength)
			return input;

        var firstCut = input.Substring(0, desiredLength - 3);
        var croppedMessage = firstCut.Substring(0, firstCut.LastIndexOf(' '));
		string messageEnd = "...";

		return $"{croppedMessage}{messageEnd}";
	}

    /// <summary>
     	/// Prepends a string with an ellipsis
     	/// </summary>
     	/// <param name="input"></param>
    	/// <returns></returns>
	public static string PrependWithEllipsis(this string input)
	{
		return $"...{input}";
	}
}