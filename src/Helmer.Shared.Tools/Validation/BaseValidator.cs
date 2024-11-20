using System.ComponentModel.DataAnnotations;

namespace Helmer.Shared.Tools.Validation
{
	public class BaseValidator<T> : IValidator<T>
	{
		public bool IsValid(T model)
		{
			var validationResults = Validate(model);
			
			return validationResults.Count == 0;
		}
		
		private IList<ValidationResult> Validate(T modelToValidate)
		{
			var validationResults = new List<ValidationResult>();
			
			var context = new ValidationContext(modelToValidate);
			
			Validator.TryValidateObject(modelToValidate, context, validationResults, true);
			
			return validationResults;
		}
	}
}
