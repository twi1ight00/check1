using System;
using System.Runtime.Serialization;

namespace Enyim.Caching.Memcached;

/// <summary>
/// The exception that is thrown when a command is not supported by the Memcached server.
/// </summary>
[Serializable]
public class CommandNotSupportedException : MemcachedClientException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="T:CommandNotSupportedException" /> class.
	/// </summary>
	public CommandNotSupportedException()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:CommandNotSupportedException" /> class with a specified error message.
	/// </summary>
	public CommandNotSupportedException(string message)
		: base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:CommandNotSupportedException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
	/// </summary>
	public CommandNotSupportedException(string message, Exception inner)
		: base(message, inner)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:CommandNotSupportedException" /> class with serialized data.
	/// </summary>
	protected CommandNotSupportedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
