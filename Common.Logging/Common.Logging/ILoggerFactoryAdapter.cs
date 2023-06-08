using System;

namespace Common.Logging;

/// <summary>
/// LoggerFactoryAdapter interface is used internally by LogManager
/// Only developers wishing to write new Common.Logging adapters need to
/// worry about this interface.
/// </summary>
/// <author>Gilles Bayon</author>
public interface ILoggerFactoryAdapter
{
	/// <summary>
	/// Get a ILog instance by type.
	/// </summary>
	/// <param name="type">The type to use for the logger</param>
	/// <returns></returns>
	ILog GetLogger(Type type);

	/// <summary>
	/// Get a ILog instance by name.
	/// </summary>
	/// <param name="name">The name of the logger</param>
	/// <returns></returns>
	ILog GetLogger(string name);
}
