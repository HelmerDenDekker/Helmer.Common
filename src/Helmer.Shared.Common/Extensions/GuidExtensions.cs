using System.Buffers.Text;
using System.Runtime.InteropServices;

namespace Helmer.Shared.Common.Extensions;

public static class GuidExtensions
{
	private const byte ForwardSlashByte = (byte)'/';
	private const byte PlusByte = (byte)'+';
	private const char Underscore = '_';
	private const char Dash = '-';

	/// <summary>
	///     Encodes a <see cref="Guid" /> into a url safe string
	/// </summary>
	/// <param name="guid"></param>
	/// <returns></returns>
	public static string EncodeBase64String(this Guid guid)
	{
		Span<byte> guidBytes = stackalloc byte[16];
		Span<byte> encodedBytes = stackalloc byte[24];

		MemoryMarshal.TryWrite(guidBytes, in guid); // write bytes from the Guid
		Base64.EncodeToUtf8(guidBytes, encodedBytes, out _, out _);

		Span<char> chars = stackalloc char[22];

		// replace any characters which are not URL safe
		// skip the final two bytes as these will be '==' padding we don't need
		for (var i = 0; i < 22; i++)
		{
			switch (encodedBytes[i])
			{
				case ForwardSlashByte:
					chars[i] = Dash;
					break;
				case PlusByte:
					chars[i] = Underscore;
					break;
				default:
					chars[i] = (char)encodedBytes[i];
					break;
			}
		}

		return new string(chars);
	}

	/// <summary>
	///     Decodes a base64 encoded <see cref="Guid" /> back to a <see cref="Guid" />
	/// </summary>
	/// <param name="encodedGuid"></param>
	/// <returns></returns>
	public static Guid DecodeBase64String(this string encodedGuid)
	{
		Span<byte> encodedBytes = stackalloc byte[24];

		for (var i = 0; i < 22; i++)
		{
			switch (encodedGuid[i])
			{
				case Dash:
					encodedBytes[i] = ForwardSlashByte;
					break;
				case Underscore:
					encodedBytes[i] = PlusByte;
					break;
				default:
					encodedBytes[i] = (byte)encodedGuid[i];
					break;
			}
		}

		encodedBytes[22] = (byte)'=';
		encodedBytes[23] = (byte)'=';
		Span<byte> decodedBytes = stackalloc byte[16];

		Base64.DecodeFromUtf8(encodedBytes, decodedBytes, out _, out _);

		return new Guid(decodedBytes);
	}
}