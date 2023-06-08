using System.Data.Entity.ModelConfiguration.Utilities;
using System.Runtime.Serialization;

namespace System.Data.Entity.Migrations.Infrastructure;

/// <summary>
/// Represents an error that occurs when an automatic migration would result in data loss.
/// </summary>
[Serializable]
public sealed class AutomaticDataLossException : MigrationsException
{
	/// <summary>
	/// Initializes a new instance of the AutomaticDataLossException class.
	/// </summary>
	/// <param name="message">The message that describes the error.</param>
	public AutomaticDataLossException(string message)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(message), null, "!string.IsNullOrWhiteSpace(message)");
		base._002Ector(message);
	}

	private AutomaticDataLossException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
