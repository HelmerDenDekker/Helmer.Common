using System.ComponentModel.DataAnnotations;

namespace Helmer.Shared.Tools.Validation
{
	public class DefaultValidatorStrategy<T> : IValidatorStrategy<T>
	{
		public bool IsValid(T modelToValidate)
		{
			var validationResults = Validate(modelToValidate);
			
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
