using System;
using System.Net;

namespace HttpWebAdapters;

public class WebResponseStub : WebResponse, IHttpWebResponse, IDisposable
{
	private CookieCollection cookies;

	private string contentEncoding;

	private string characterSet;

	private string server;

	private DateTime lastModified;

	private HttpStatusCode statusCode;

	private string statusDescription;

	private Version protocolVersion;

	private string method;

	public CookieCollection Cookies
	{
		get
		{
			return cookies;
		}
		set
		{
			cookies = value;
		}
	}

	public string ContentEncoding
	{
		get
		{
			return contentEncoding;
		}
		set
		{
			contentEncoding = value;
		}
	}

	public string CharacterSet
	{
		get
		{
			return characterSet;
		}
		set
		{
			characterSet = value;
		}
	}

	public string Server
	{
		get
		{
			return server;
		}
		set
		{
			server = value;
		}
	}

	public DateTime LastModified
	{
		get
		{
			return lastModified;
		}
		set
		{
			lastModified = value;
		}
	}

	public HttpStatusCode StatusCode
	{
		get
		{
			return statusCode;
		}
		set
		{
			statusCode = value;
		}
	}

	public string StatusDescription
	{
		get
		{
			return statusDescription;
		}
		set
		{
			statusDescription = value;
		}
	}

	public Version ProtocolVersion
	{
		get
		{
			return protocolVersion;
		}
		set
		{
			protocolVersion = value;
		}
	}

	public string Method
	{
		get
		{
			return method;
		}
		set
		{
			method = value;
		}
	}

	public string GetResponseHeader(string headerName)
	{
		throw new NotImplementedException();
	}
}
