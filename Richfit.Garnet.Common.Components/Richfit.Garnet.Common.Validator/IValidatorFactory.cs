namespace Richfit.Garnet.Common.Validator;

/// <summary>
/// 验证工厂
/// </summary>
public interface IValidatorFactory
{
	/// <summary>
	/// Create a new IValidator
	/// </summary>
	/// <returns>IValidator</returns>
	IValidator Create();
}
