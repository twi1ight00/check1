using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace HttpWebAdapters.Adapters;

public class HttpWebRequestAdapter : IHttpWebRequest
{
	private HttpWebRequest request;

	public HttpWebRequestMethod Method
	{
		get
		{
			return HttpWebRequestMethod.Parse(request.Method);
		}
		set
		{
			request.Method = value.ToString();
		}
	}

	public bool AllowAutoRedirect
	{
		get
		{
			return request.AllowAutoRedirect;
		}
		set
		{
			request.AllowAutoRedirect = value;
		}
	}

	public bool AllowWriteStreamBuffering
	{
		get
		{
			return request.AllowWriteStreamBuffering;
		}
		set
		{
			request.AllowWriteStreamBuffering = value;
		}
	}

	public bool HaveResponse => request.HaveResponse;

	public bool KeepAlive
	{
		get
		{
			return request.KeepAlive;
		}
		set
		{
			request.KeepAlive = value;
		}
	}

	public bool Pipelined
	{
		get
		{
			return request.Pipelined;
		}
		set
		{
			request.Pipelined = value;
		}
	}

	public bool PreAuthenticate
	{
		get
		{
			return request.PreAuthenticate;
		}
		set
		{
			request.PreAuthenticate = value;
		}
	}

	public bool UnsafeAuthenticatedConnectionSharing
	{
		get
		{
			return request.UnsafeAuthenticatedConnectionSharing;
		}
		set
		{
			request.UnsafeAuthenticatedConnectionSharing = value;
		}
	}

	public bool SendChunked
	{
		get
		{
			return request.SendChunked;
		}
		set
		{
			request.SendChunked = value;
		}
	}

	public DecompressionMethods AutomaticDecompression
	{
		get
		{
			return request.AutomaticDecompression;
		}
		set
		{
			request.AutomaticDecompression = value;
		}
	}

	public int MaximumResponseHeadersLength
	{
		get
		{
			return request.MaximumResponseHeadersLength;
		}
		set
		{
			request.MaximumResponseHeadersLength = value;
		}
	}

	public X509CertificateCollection ClientCertificates
	{
		get
		{
			return request.ClientCertificates;
		}
		set
		{
			request.ClientCertificates = value;
		}
	}

	public CookieContainer CookieContainer
	{
		get
		{
			return request.CookieContainer;
		}
		set
		{
			request.CookieContainer = value;
		}
	}

	public Uri RequestUri => request.RequestUri;

	public long ContentLength
	{
		get
		{
			return request.ContentLength;
		}
		set
		{
			request.ContentLength = value;
		}
	}

	public int Timeout
	{
		get
		{
			return request.Timeout;
		}
		set
		{
			request.Timeout = value;
		}
	}

	public int ReadWriteTimeout
	{
		get
		{
			return request.ReadWriteTimeout;
		}
		set
		{
			request.ReadWriteTimeout = value;
		}
	}

	public Uri Address => request.Address;

	public ServicePoint ServicePoint => request.ServicePoint;

	public int MaximumAutomaticRedirections
	{
		get
		{
			return request.MaximumAutomaticRedirections;
		}
		set
		{
			request.MaximumAutomaticRedirections = value;
		}
	}

	public ICredentials Credentials
	{
		get
		{
			return request.Credentials;
		}
		set
		{
			request.Credentials = value;
		}
	}

	public bool UseDefaultCredentials
	{
		get
		{
			return request.UseDefaultCredentials;
		}
		set
		{
			request.UseDefaultCredentials = value;
		}
	}

	public string ConnectionGroupName
	{
		get
		{
			return request.ConnectionGroupName;
		}
		set
		{
			request.ConnectionGroupName = value;
		}
	}

	public WebHeaderCollection Headers
	{
		get
		{
			return request.Headers;
		}
		set
		{
			request.Headers = value;
		}
	}

	public IWebProxy Proxy
	{
		get
		{
			return request.Proxy;
		}
		set
		{
			request.Proxy = value;
		}
	}

	public Version ProtocolVersion
	{
		get
		{
			return request.ProtocolVersion;
		}
		set
		{
			request.ProtocolVersion = value;
		}
	}

	public string ContentType
	{
		get
		{
			return request.ContentType;
		}
		set
		{
			request.ContentType = value;
		}
	}

	public string MediaType
	{
		get
		{
			return request.MediaType;
		}
		set
		{
			request.MediaType = value;
		}
	}

	public string TransferEncoding
	{
		get
		{
			return request.TransferEncoding;
		}
		set
		{
			request.TransferEncoding = value;
		}
	}

	public string Connection
	{
		get
		{
			return request.Connection;
		}
		set
		{
			request.Connection = value;
		}
	}

	public string Accept
	{
		get
		{
			return request.Accept;
		}
		set
		{
			request.Accept = value;
		}
	}

	public string Referer
	{
		get
		{
			return request.Referer;
		}
		set
		{
			request.Referer = value;
		}
	}

	public string UserAgent
	{
		get
		{
			return request.UserAgent;
		}
		set
		{
			request.UserAgent = value;
		}
	}

	public string Expect
	{
		get
		{
			return request.Expect;
		}
		set
		{
			request.Expect = value;
		}
	}

	public DateTime IfModifiedSince
	{
		get
		{
			return request.IfModifiedSince;
		}
		set
		{
			request.IfModifiedSince = value;
		}
	}

	public HttpWebRequestAdapter(HttpWebRequest request)
	{
		this.request = request;
	}

	public IHttpWebResponse GetResponse()
	{
		return new HttpWebResponseAdapter(request.GetResponse());
	}

	public IAsyncResult BeginGetResponse(AsyncCallback callback, object state)
	{
		return request.BeginGetResponse(callback, state);
	}

	public IHttpWebResponse EndGetResponse(IAsyncResult result)
	{
		return new HttpWebResponseAdapter(request.EndGetResponse(result));
	}

	public IAsyncResult BeginGetRequestStream(AsyncCallback callback, object state)
	{
		return request.BeginGetRequestStream(callback, state);
	}

	public Stream EndGetRequestStream(IAsyncResult result)
	{
		return request.EndGetRequestStream(result);
	}

	public Stream GetRequestStream()
	{
		return request.GetRequestStream();
	}

	public void Abort()
	{
		request.Abort();
	}

	public void AddRange(int from, int to)
	{
		request.AddRange(from, to);
	}

	public void AddRange(int range)
	{
		request.AddRange(range);
	}

	public void AddRange(string rangeSpecifier, int from, int to)
	{
		request.AddRange(rangeSpecifier, from, to);
	}

	public void AddRange(string rangeSpecifier, int range)
	{
		request.AddRange(rangeSpecifier, range);
	}
}
