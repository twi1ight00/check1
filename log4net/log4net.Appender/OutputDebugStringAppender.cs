using System.Runtime.InteropServices;
using System.Security;
using log4net.Core;

namespace log4net.Appender;

/// <summary>
/// Appends log events to the OutputDebugString system.
/// </summary>
/// <remarks>
/// <para>
/// OutputDebugStringAppender appends log events to the
/// OutputDebugString system.
/// </para>
/// <para>
/// The string is passed to the native <c>OutputDebugString</c> 
/// function.
/// </para>
/// </remarks>
/// <author>Nicko Cadell</author>
/// <author>Gert Driesen</author>
public class OutputDebugStringAppender : AppenderSkeleton
{
	/// <summary>
	/// This appender requires a <see cref="N:log4net.Layout" /> to be set.
	/// </summary>
	/// <value><c>true</c></value>
	/// <remarks>
	/// <para>
	/// This appender requires a <see cref="N:log4net.Layout" /> to be set.
	/// </para>
	/// </remarks>
	protected override bool RequiresLayout => true;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:log4net.Appender.OutputDebugStringAppender" /> class.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Default constructor.
	/// </para>
	/// </remarks>
	public OutputDebugStringAppender()
	{
	}

	/// <summary>
	/// Write the logging event to the output debug string API
	/// </summary>
	/// <param name="loggingEvent">the event to log</param>
	/// <remarks>
	/// <para>
	/// Write the logging event to the output debug string API
	/// </para>
	/// </remarks>
	[SecuritySafeCritical]
	protected override void Append(LoggingEvent loggingEvent)
	{
		OutputDebugString(RenderLoggingEvent(loggingEvent));
	}

	/// <summary>
	/// Stub for OutputDebugString native method
	/// </summary>
	/// <param name="message">the string to output</param>
	/// <remarks>
	/// <para>
	/// Stub for OutputDebugString native method
	/// </para>
	/// </remarks>
	[DllImport("Kernel32.dll")]
	protected static extern void OutputDebugString(string message);
}
