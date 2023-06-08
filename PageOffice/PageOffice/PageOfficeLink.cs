using System;
using System.Web;

namespace PageOffice;

public sealed class PageOfficeLink
{
	public static string OpenWindow(string URL, string Options)
	{
		HttpRequest request = HttpContext.Current.Request;
		string text = string.Empty;
		for (int i = 0; i < request.Cookies.Count; i++)
		{
			if (request.Cookies[i].Name != _0005_2000._0002(1402781390))
			{
				text = text + request.Cookies[i].Name + _0005_2000._0002(1402769483);
				text = text + request.Cookies[i].Value + _0005_2000._0002(1402772225);
			}
		}
		string text2 = URL;
		if (text2.Length < 1)
		{
			throw new Exception(_0005_2000._0002(1402781246));
		}
		string text3 = URL.ToLower();
		if (text3.StartsWith(_0005_2000._0002(1402771699)) || text3.StartsWith(_0005_2000._0002(1402771681)))
		{
			text2 = URL;
		}
		else
		{
			if (text2[0] == '/')
			{
				string text4 = request.ApplicationPath;
				if (text4[0] == '/')
				{
					text4 = string.Empty;
				}
				text2 = request.Url.AbsoluteUri.Substring(0, request.Url.AbsoluteUri.IndexOf('/', 8)) + text4 + URL;
			}
			else
			{
				string text5 = request.Url.AbsoluteUri;
				int num = text5.LastIndexOf('?');
				if (num > 0)
				{
					text5 = text5.Substring(0, num);
				}
				int num2 = text5.LastIndexOf('/');
				text2 = text5.Substring(0, num2 + 1) + URL;
			}
			if (request.Url.Authority != request.ServerVariables[_0005_2000._0002(1402772358)])
			{
				text2 = URL.Replace(request.Url.Authority, request.ServerVariables[_0005_2000._0002(1402772358)]);
			}
		}
		return _0005_2000._0002(1402781301) + text2 + _0005_2000._0002(1402781288) + Options.ToLower() + _0005_2000._0002(1402781288) + _0003_2000._0002(text) + _0005_2000._0002(1402781288);
	}
}
