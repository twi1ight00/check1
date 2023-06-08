using System.Globalization;

namespace Quartz.Impl.AdoJobStore;

/// <summary> 
/// This class contains utility functions for use in all delegate classes.
/// </summary>
/// <author><a href="mailto:jeff@binaryfeed.org">Jeffrey Wescott</a></author>
/// <author>Marko Lahma (.NET)</author>
public static class AdoJobStoreUtil
{
	/// <summary>
	/// Replace the table prefix in a query by replacing any occurrences of
	/// "{0}" with the table prefix.
	/// </summary>
	/// <param name="query">The unsubstitued query</param>
	/// <param name="tablePrefix">The table prefix</param>
	/// <param name="schedNameLiteral">the scheduler name</param>
	/// <returns>The query, with proper table prefix substituted</returns>
	public static string ReplaceTablePrefix(string query, string tablePrefix, string schedNameLiteral)
	{
		return string.Format(CultureInfo.InvariantCulture, query, new object[2] { tablePrefix, schedNameLiteral });
	}
}
