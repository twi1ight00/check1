using System.IO;
using log4net.Core;

namespace log4net.Layout.Pattern;

/// <summary>
/// Write the caller location info to the output
/// </summary>
/// <remarks>
/// <para>
/// Writes the <see cref="P:log4net.Core.LocationInfo.FullInfo" /> to the output writer.
/// </para>
/// </remarks>
/// <author>Nicko Cadell</author>
internal sealed class FullLocationPatternConverter : PatternLayoutConverter
{
	/// <summary>
	/// Write the caller location info to the output
	/// </summary>
	/// <param name="writer"><see cref="T:System.IO.TextWriter" /> that will receive the formatted result.</param>
	/// <param name="loggingEvent">the event being logged</param>
	/// <remarks>
	/// <para>
	/// Writes the <see cref="P:log4net.Core.LocationInfo.FullInfo" /> to the output writer.
	/// </para>
	/// </remarks>
	protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
	{
		writer.Write(loggingEvent.LocationInformation.FullInfo);
	}
}
