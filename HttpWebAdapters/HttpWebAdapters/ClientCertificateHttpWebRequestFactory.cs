using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using HttpWebAdapters.Adapters;

namespace HttpWebAdapters;

public class ClientCertificateHttpWebRequestFactory : IHttpWebRequestFactory
{
	private readonly X509Certificate2 certificate;

	public ClientCertificateHttpWebRequestFactory(X509Certificate2 certificate)
	{
		this.certificate = certificate;
	}

	public IHttpWebRequest Create(Uri url)
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
		httpWebRequest.ClientCertificates.Add(certificate);
		return new HttpWebRequestAdapter(httpWebRequest);
	}

	public IHttpWebRequest Create(string url)
	{
		return Create(new Uri(url));
	}
}
