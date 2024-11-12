namespace Helmer.Shared.Tools.Validation
{
	public interface IValidatorStrategy<T>
	{
		bool IsValid(T objectToValidate);
	}
}
