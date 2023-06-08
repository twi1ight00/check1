using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Runtime.Serialization;

namespace System.Data.Entity.ModelConfiguration;

/// <summary>
///     Exception thrown by <see cref="T:System.Data.Entity.DbModelBuilder" /> during model creation when an invalid model is generated.
/// </summary>
[Serializable]
public class ModelValidationException : Exception
{
	/// <summary>
	///     Initializes a new instance of ModelValidationException
	/// </summary>
	public ModelValidationException()
	{
	}

	/// <summary>
	///     Initializes a new instance of ModelValidationException
	/// </summary>
	/// <param name="message">The exception message.</param>
	public ModelValidationException(string message)
		: base(message)
	{
	}

	/// <summary>
	///     Initializes a new instance of ModelValidationException
	/// </summary>
	/// <param name="message">The exception message.</param>
	/// <param name="innerException">The inner exception.</param>
	public ModelValidationException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	internal ModelValidationException(IEnumerable<DataModelErrorEventArgs> validationErrors)
		: base(validationErrors.ToErrorMessage())
	{
	}

	protected ModelValidationException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
