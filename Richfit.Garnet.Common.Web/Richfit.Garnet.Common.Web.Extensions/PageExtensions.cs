using System;
using System.IO;
using System.Web.UI;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Web.Extensions;

/// <summary>
/// Web页面对象扩展方法类
/// </summary>
public static class PageExtensions
{
	/// <summary>
	/// 向页面的Header区域添加脚本文件
	/// </summary>
	/// <param name="page">页面对象</param>
	/// <param name="file">脚本文件</param>
	public static void AddScriptFile(this Page page, FileInfo file)
	{
		file.GuardNotNull("File");
		if (!file.Exists)
		{
			throw new ArgumentException("File does not exist");
		}
		if (!page.ClientScript.IsClientScriptIncludeRegistered(typeof(Page), file.FullName))
		{
			page.ClientScript.RegisterClientScriptInclude(typeof(Page), file.FullName, file.FullName);
		}
	}
}
