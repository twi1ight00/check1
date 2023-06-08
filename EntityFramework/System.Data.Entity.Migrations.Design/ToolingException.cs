using System.Data.Entity.ModelConfiguration.Utilities;
using System.Runtime.Serialization;

namespace System.Data.Entity.Migrations.Design;

/// <summary>
/// Represents an exception that occurred while running an operation in another AppDomain in the <see cref="T:System.Data.Entity.Migrations.Design.ToolingFacade" />.
/// </summary>
[Serializable]
public class ToolingException : Exception
{
	private readonly string _innerType;

	private readonly string _innerStackTrace;

	/// <summary>
	/// Gets the type of the exception that was thrown.
	/// </summary>
	public string InnerType => _innerType;

	/// <summary>
	/// Gets the stack trace of the exception that was thrown.
	/// </summary>
	public string InnerStackTrace => _innerStackTrace;

	/// <summary>
	/// Initializes a new instance of the ToolingException class.
	/// </summary>
	/// <param name="message">Error that explains the reason for the exception.</param>
	/// <param name="innerType">The type of the exception that was thrown.</param>
	/// <param name="innerStackTrace">The stack trace of the exception that was thrown.</param>
	public ToolingException(string message, string innerType, string innerStackTrace)
		: base(message)
	{
		_innerType = innerType;
		_innerStackTrace = innerStackTrace;
	}

	/// <inheritdoc />
	protected ToolingException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_innerType = info.GetString("InnerType");
		_innerStackTrace = info.GetString("InnerStackTrace");
	}

	/// <inheritdoc />
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		RuntimeFailureMethods.Requires(info != null, null, "info != null");
		base.GetObjectData(info, context);
		info.AddValue("InnerType", _innerType);
		info.AddValue("InnerStackTrace", _innerStackTrace);
	}
}
