using System;
using System.Runtime.Serialization;

namespace Common.Logging;

/// <summary>
/// The exception that is thrown when a configuration system error has occurred with Common.Logging
/// </summary>
/// <author>Mark Pollack</author>
[Serializable]
public class ConfigurationException : ApplicationException
{
	/// <summary>Creates a new instance of the ObjectsException class.</summary>
	public ConfigurationException()
	{
	}

	/// <summary>
	/// Creates a new instance of the ConfigurationException class. with the specified message.
	/// </summary>
	/// <param name="message">
	/// A message about the exception.
	/// </param>
	public ConfigurationException(string message)
		: base(message)
	{
	}

	/// <summary>
	/// Creates a new instance of the ConfigurationException class with the specified message
	/// and root cause.
	/// </summary>
	/// <param name="message">
	/// A message about the exception.
	/// </param>
	/// <param name="rootCause">
	/// The root exception that is being wrapped.
	/// </param>
	public ConfigurationException(string message, Exception rootCause)
		: base(message, rootCause)
	{
	}

	/// <summary>
	/// Creates a new instance of the ConfigurationException class.
	/// </summary>
	/// <param name="info">
	/// The <see cref="T:System.Runtime.Serialization.SerializationInfo" />
	/// that holds the serialized object data about the exception being thrown.
	/// </param>
	/// <param name="context">
	/// The <see cref="T:System.Runtime.Serialization.StreamingContext" />
	/// that contains contextual information about the source or destination.
	/// </param>
	protected ConfigurationException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
