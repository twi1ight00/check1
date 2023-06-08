namespace Richfit.Garnet.Common.Logging;

/// <summary>
/// The 7 possible logging levels
/// </summary>
/// <author>Gilles Bayon</author>
public enum LogLevel
{
	/// <summary>
	/// All logging levels
	/// </summary>
	All,
	/// <summary>
	/// A trace logging level
	/// </summary>
	Trace,
	/// <summary>
	/// A debug logging level
	/// </summary>
	Debug,
	/// <summary>
	/// A info logging level
	/// </summary>
	Info,
	/// <summary>
	/// A warn logging level
	/// </summary>
	Warn,
	/// <summary>
	/// An error logging level
	/// </summary>
	Error,
	/// <summary>
	/// A fatal logging level
	/// </summary>
	Fatal,
	/// <summary>
	/// Do not log anything.
	/// </summary>
	Off
}
