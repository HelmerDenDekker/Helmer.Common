namespace Helmer.Shared.Common.Exceptions;

public class EmptyConfigurationException : Exception
{
	/// <summary>
	///     Initializes a new instance of the <see cref="EmptyConfigurationException">EmptyConfigurationException</see>
	/// </summary>
	/// <param name="message"></param>
	public EmptyConfigurationException(string message) : base(message)
	{
	}
}
