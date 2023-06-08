using System;
using System.IO;
using System.Net;

namespace HttpWebAdapters.Adapters;

public class HttpWebResponseAdapter : IHttpWebResponse, IDisposable
{
	private WebResponse response;

	public CookieCollection Cookies
	{
		get
		{
			try
			{
				return ((HttpWebResponse)response).Cookies;
			}
			catch (InvalidCastException)
			{
				return ((WebResponseStub)response).Cookies;
			}
		}
		set
		{
			try
			{
				((HttpWebResponse)response).Cookies = value;
			}
			catch (InvalidCastException)
			{
				((WebResponseStub)response).Cookies = value;
			}
		}
	}

	public string ContentEncoding
	{
		get
		{
			try
			{
				return ((HttpWebResponse)response).ContentEncoding;
			}
			catch (InvalidCastException)
			{
				return ((WebResponseStub)response).ContentEncoding;
			}
		}
	}

	public string CharacterSet
	{
		get
		{
			try
			{
				return ((HttpWebResponse)response).CharacterSet;
			}
			catch (InvalidCastException)
			{
				return ((WebResponseStub)response).CharacterSet;
			}
		}
	}

	public string Server
	{
		get
		{
			try
			{
				return ((HttpWebResponse)response).Server;
			}
			catch (InvalidCastException)
			{
				return ((WebResponseStub)response).Server;
			}
		}
	}

	public DateTime LastModified
	{
		get
		{
			try
			{
				return ((HttpWebResponse)response).LastModified;
			}
			catch (InvalidCastException)
			{
				return ((WebResponseStub)response).LastModified;
			}
		}
	}

	public HttpStatusCode StatusCode
	{
		get
		{
			try
			{
				return ((HttpWebResponse)response).StatusCode;
			}
			catch (InvalidCastException)
			{
				return ((WebResponseStub)response).StatusCode;
			}
		}
	}

	public string StatusDescription
	{
		get
		{
			try
			{
				return ((HttpWebResponse)response).StatusDescription;
			}
			catch (InvalidCastException)
			{
				return ((WebResponseStub)response).StatusDescription;
			}
		}
	}

	public Version ProtocolVersion
	{
		get
		{
			try
			{
				return ((HttpWebResponse)response).ProtocolVersion;
			}
			catch (InvalidCastException)
			{
				return ((WebResponseStub)response).ProtocolVersion;
			}
		}
	}

	public string Method
	{
		get
		{
			try
			{
				return ((HttpWebResponse)response).Method;
			}
			catch (InvalidCastException)
			{
				return ((WebResponseStub)response).Method;
			}
		}
	}

	public bool IsFromCache => response.IsFromCache;

	public bool IsMutuallyAuthenticated => response.IsMutuallyAuthenticated;

	public long ContentLength
	{
		get
		{
			return response.ContentLength;
		}
		set
		{
			response.ContentLength = value;
		}
	}

	public string ContentType
	{
		get
		{
			return response.ContentType;
		}
		set
		{
			response.ContentType = value;
		}
	}

	public Uri ResponseUri => response.ResponseUri;

	public WebHeaderCollection Headers => response.Headers;

	public HttpWebResponseAdapter(WebResponse response)
	{
		this.response = response;
	}

	public string GetResponseHeader(string headerName)
	{
		try
		{
			return ((HttpWebResponse)response).GetResponseHeader(headerName);
		}
		catch (InvalidCastException)
		{
			return ((WebResponseStub)response).GetResponseHeader(headerName);
		}
	}

	public void Close()
	{
		response.Close();
	}

	public Stream GetResponseStream()
	{
		return response.GetResponseStream();
	}

	public void Dispose()
	{
		response.Close();
	}
}
