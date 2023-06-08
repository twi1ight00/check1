using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using ns183;

namespace ns175;

internal class Class4924 : Interface151
{
	private XmlUrlResolver xmlUrlResolver_0 = new XmlUrlResolver();

	private bool bool_0;

	private Interface171 interface171_0;

	internal Interface171 method_0()
	{
		return interface171_0;
	}

	public string method_1(string @base)
	{
		@base = @base.Replace('\\', '/');
		if (!@base.EndsWith("/"))
		{
			@base += "/";
		}
		if (!File.Exists(@base) && Directory.Exists(@base))
		{
			return new UriBuilder(@base).ToString();
		}
		try
		{
			Uri uri = new Uri(@base);
			string scheme = uri.Scheme;
			bool flag = true;
			if ("file".Equals(scheme))
			{
				string localPath = uri.LocalPath;
				flag = !File.Exists(localPath) && Directory.Exists(localPath);
			}
			if (scheme == null || !flag)
			{
				string message = "base " + @base + " is not a valid directory";
				if (bool_0)
				{
					throw new Exception(message);
				}
			}
			return uri.ToString();
		}
		catch (Exception)
		{
			throw;
		}
	}

	public Class4924()
		: this(throwExceptions: false)
	{
	}

	public Class4924(bool throwExceptions)
	{
		bool_0 = throwExceptions;
	}

	public static Uri smethod_0(string referencePath, string relativePath)
	{
		if (referencePath != null && referencePath.Length > 0)
		{
			return new Uri(Path.Combine(referencePath, relativePath));
		}
		return new Uri(relativePath);
	}

	public Stream imethod_1(string href, string @base, string srcDir)
	{
		string pattern = "data:(?<mime>[\\w/]+);(?<encoding>\\w+),(?<data>.*)";
		Match match = Regex.Match(href, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
		if (match.Success)
		{
			string value = match.Groups["mime"].Value;
			string value2 = match.Groups["encoding"].Value;
			string value3 = match.Groups["data"].Value;
			if (value.IndexOf("image") != -1 && value2 == "base64")
			{
				return new MemoryStream(Convert.FromBase64String(value3));
			}
		}
		if (interface171_0 != null)
		{
			Class5371 @class = interface171_0.imethod_0(this, new EventArgs6(href));
			if (@class.Data == null)
			{
				return null;
			}
			return new MemoryStream(@class.Data);
		}
		Uri absoluteUri = ((@base == null || @base.Length <= 0) ? smethod_0(srcDir, href) : xmlUrlResolver_0.ResolveUri(new Uri(@base), href));
		return (Stream)xmlUrlResolver_0.GetEntity(absoluteUri, null, typeof(Stream));
	}

	public void imethod_0(Interface171 callback)
	{
		interface171_0 = callback;
	}

	public void method_2(bool throwExceptions)
	{
		bool_0 = throwExceptions;
	}
}
