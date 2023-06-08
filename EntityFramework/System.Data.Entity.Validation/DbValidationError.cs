using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Validation;

/// <summary>
///     Validation error. Can be either entity or property level validation error.
/// </summary>
[Serializable]
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbValidationError
{
	/// <summary>
	///     Name of the invalid property. Can be null (e.g. for entity level validations)
	/// </summary>
	private readonly string _propertyName;

	/// <summary>
	///     Validation error message.
	/// </summary>
	private readonly string _errorMessage;

	/// <summary>
	///     Gets name of the invalid property.
	/// </summary>
	public string PropertyName => _propertyName;

	/// <summary>
	///     Gets validation error message.
	/// </summary>
	public string ErrorMessage => _errorMessage;

	/// <summary>
	///     Creates an instance of <see cref="T:System.Data.Entity.Validation.DbValidationError" />.
	/// </summary>
	/// <param name="propertyName">Name of the invalid property. Can be null.</param>
	/// <param name="errorMessage">Validation error message. Can be null.</param>
	public DbValidationError(string propertyName, string errorMessage)
	{
		_propertyName = propertyName;
		_errorMessage = errorMessage;
	}
}
