#define DEBUG
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Text;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 网络辅助类
/// </summary>
public static class NetHelper
{
	/// <summary>
	/// 获取当前URL字符串中的协议前缀字符串
	/// </summary>
	/// <param name="url">当前URL字符串</param>
	/// <returns>当前URL字符串中包含的协议前缀，如果不包含返回空串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前URL字符串为空。</exception>
	public static string GetUrlProtocol(string url)
	{
		Guard.AssertNotNull(url, "url");
		Match i = RegexPatterns.UrlProtocol.Match(url);
		if (!i.Success || i.Index > 0)
		{
			return string.Empty;
		}
		if (i.Groups.Count > 0)
		{
			return i.Groups[1].Value;
		}
		return string.Empty;
	}
}
