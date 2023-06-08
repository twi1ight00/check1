using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using ns218;
using ns73;

namespace ns91;

internal class Class7202 : Interface104, Interface384
{
	private static byte[] smethod_0(Uri uri)
	{
		if (uri.OriginalString.TrimStart(' ', '\t').StartsWith("data:"))
		{
			Regex regex = new Regex("data:(?<mime>.*);\\s*(?<any>.*);*\\s*base64\\s*,\\s*(?<data>.*)", RegexOptions.IgnoreCase);
			Match match = regex.Match(uri.OriginalString);
			if (match.Success)
			{
				return Convert.FromBase64String(match.Groups["data"].Value);
			}
		}
		if (!uri.IsFile && uri.IsAbsoluteUri)
		{
			return smethod_1(uri).ToArray();
		}
		return Class5964.smethod_13(uri.IsAbsoluteUri ? uri.LocalPath : uri.OriginalString);
	}

	private static MemoryStream smethod_1(Uri uri)
	{
		WebRequest webRequest = WebRequest.Create(uri);
		webRequest.Credentials = CredentialCache.DefaultCredentials;
		using HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
		using (httpWebResponse.GetResponseStream())
		{
			Uri responseUri = httpWebResponse.ResponseUri;
			using WebClient webClient = new WebClient();
			webClient.UseDefaultCredentials = true;
			return new MemoryStream(webClient.DownloadData(responseUri));
		}
	}

	public Class4258 imethod_0(object sender, EventArgs1 e)
	{
		if (e.Uri != null && e.Uri.Length != 0)
		{
			return new Class4258(smethod_0(new Uri(e.Uri)));
		}
		return new Class4258(null);
	}
}
