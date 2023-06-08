using System;
using System.IO;
using System.Net;

namespace HttpWebAdapters;

public interface IHttpWebResponse : IDisposable
{
	CookieCollection Cookies { get; set; }

	string ContentEncoding { get; }

	string CharacterSet { get; }

	string Server { get; }

	DateTime LastModified { get; }

	HttpStatusCode StatusCode { get; }

	string StatusDescription { get; }

	Version ProtocolVersion { get; }

	string Method { get; }

	bool IsFromCache { get; }

	bool IsMutuallyAuthenticated { get; }

	long ContentLength { get; set; }

	string ContentType { get; set; }

	Uri ResponseUri { get; }

	WebHeaderCollection Headers { get; }

	string GetResponseHeader(string headerName);

	void Close();

	Stream GetResponseStream();
}
