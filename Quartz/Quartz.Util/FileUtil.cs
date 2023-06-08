using System;
using System.IO;
using System.Security;
using System.Web;
using Common.Logging;

namespace Quartz.Util;

/// <summary>
/// Utility class for file handling related things.
/// </summary>
/// <author>Marko Lahma</author>
public class FileUtil
{
	private static readonly ILog logger = LogManager.GetLogger<FileUtil>();

	/// <summary>
	/// Resolves file to actual file if for example relative '~' used.
	/// </summary>
	/// <param name="fName">File name to check</param>
	/// <returns>Expanded file name or actual no resolving was done.</returns>
	public static string ResolveFile(string fName)
	{
		if (fName != null && fName.StartsWith("~"))
		{
			if (HttpContext.Current != null)
			{
				return HttpContext.Current.Server.MapPath(fName);
			}
			fName = fName.Substring(1);
			if (fName.StartsWith("/") || fName.StartsWith("\\"))
			{
				fName = fName.Substring(1);
			}
			try
			{
				fName = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, fName);
			}
			catch (SecurityException)
			{
				logger.WarnFormat("Cannot determine path for relative file '{0}' because of security exception");
				throw;
			}
		}
		return fName;
	}
}
