namespace Richfit.Garnet.Common.Validator.DataAnnotations;

/// <summary>
/// Data Annotations based entity validator factory
/// </summary>
public class DataAnnotationsValidatorFactory : IValidatorFactory
{
	/// <summary>
	/// Create a entity validator
	/// </summary>
	/// <returns></returns>
	public IValidator Create()
	{
		return new DataAnnotationsValidator();
	}
}
