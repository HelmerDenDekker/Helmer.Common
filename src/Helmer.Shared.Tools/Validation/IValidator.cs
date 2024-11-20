namespace Helmer.Shared.Tools.Validation
{
	public interface IValidator<T>
	{
		bool IsValid(T model);
	}
}
