using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HttpWebAdapters;
using HttpWebAdapters.Adapters;
using SolrNet.Exceptions;
using SolrNet.Utils;

namespace SolrNet.Impl;

/// <summary>
/// Manages HTTP connection with Solr
/// </summary>
public class SolrConnection : ISolrConnection
{
	private struct SolrResponse
	{
		public string ETag { get; private set; }

		public string Data { get; private set; }

		public SolrResponse(string eTag, string data)
		{
			this = default(SolrResponse);
			ETag = eTag;
			Data = data;
		}
	}

	private string serverURL;

	private string userName;

	private string password;

	private string version = "2.2";

	/// <summary>
	/// HTTP cache implementation
	/// </summary>
	public ISolrCache Cache { get; set; }

	/// <summary>
	/// HTTP request factory
	/// </summary>
	public IHttpWebRequestFactory HttpWebRequestFactory { get; set; }

	/// <summary>
	/// URL to Solr
	/// </summary>
	public string ServerURL
	{
		get
		{
			return serverURL;
		}
		set
		{
			serverURL = UriValidator.ValidateHTTP(value);
		}
	}

	public string UserName { get; set; }

	public string Password { get; set; }

	/// <summary>
	/// Solr XML response syntax version
	/// </summary>
	public string Version
	{
		get
		{
			return version;
		}
		set
		{
			version = value;
		}
	}

	/// <summary>
	/// HTTP connection timeout
	/// </summary>
	public int Timeout { get; set; }

	/// <summary>
	/// Manages HTTP connection with Solr
	/// </summary>
	/// <param name="serverURL">URL to Solr</param>
	public SolrConnection(string serverURL, string userName, string password)
	{
		ServerURL = serverURL;
		UserName = userName;
		Password = password;
		Timeout = -1;
		Cache = new NullCache();
		HttpWebRequestFactory = new BasicAuthHttpWebRequestFactory(userName, password);
	}

	public string Post(string relativeUrl, string s)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		using MemoryStream content = new MemoryStream(bytes);
		return PostStream(relativeUrl, "text/xml; charset=utf-8", content, null);
	}

	public string PostStream(string relativeUrl, string contentType, Stream content, IEnumerable<KeyValuePair<string, string>> parameters)
	{
		UriBuilder u = new UriBuilder(serverURL);
		u.Path += relativeUrl;
		u.Query = GetQuery(parameters);
		IHttpWebRequest request = HttpWebRequestFactory.Create(u.Uri);
		request.Method = HttpWebRequestMethod.POST;
		request.KeepAlive = true;
		request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
		if (Timeout > 0)
		{
			request.ReadWriteTimeout = Timeout;
			request.Timeout = Timeout;
		}
		if (contentType != null)
		{
			request.ContentType = contentType;
		}
		request.ContentLength = content.Length;
		request.ProtocolVersion = HttpVersion.Version11;
		try
		{
			using (Stream postStream = request.GetRequestStream())
			{
				CopyTo(content, postStream);
			}
			return GetResponse(request).Data;
		}
		catch (WebException e)
		{
			string msg = e.Message;
			if (e.Response != null)
			{
				using Stream s = e.Response.GetResponseStream();
				using StreamReader sr = new StreamReader(s);
				msg = sr.ReadToEnd();
			}
			throw new SolrConnectionException(msg, e, request.RequestUri.ToString());
		}
	}

	private static void CopyTo(Stream input, Stream output)
	{
		byte[] buffer = new byte[4096];
		int read;
		while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
		{
			output.Write(buffer, 0, read);
		}
	}

	public string Get(string relativeUrl, IEnumerable<KeyValuePair<string, string>> parameters)
	{
		UriBuilder u = new UriBuilder(serverURL);
		u.Path += relativeUrl;
		u.Query = GetQuery(parameters);
		IHttpWebRequest request = HttpWebRequestFactory.Create(u.Uri);
		request.Method = HttpWebRequestMethod.GET;
		request.KeepAlive = true;
		request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
		SolrCacheEntity cached = Cache[u.Uri.ToString()];
		if (cached != null)
		{
			request.Headers.Add(HttpRequestHeader.IfNoneMatch, cached.ETag);
		}
		if (Timeout > 0)
		{
			request.ReadWriteTimeout = Timeout;
			request.Timeout = Timeout;
		}
		try
		{
			SolrResponse response = GetResponse(request);
			if (response.ETag != null)
			{
				Cache.Add(new SolrCacheEntity(u.Uri.ToString(), response.ETag, response.Data));
			}
			return response.Data;
		}
		catch (WebException e)
		{
			if (e.Response != null)
			{
				using (e.Response)
				{
					HttpWebResponseAdapter r = new HttpWebResponseAdapter(e.Response);
					if (r.StatusCode != HttpStatusCode.NotModified)
					{
						using Stream s = e.Response.GetResponseStream();
						using StreamReader sr = new StreamReader(s);
						throw new SolrConnectionException(sr.ReadToEnd(), e, u.Uri.ToString());
					}
					return cached.Data;
				}
			}
			throw new SolrConnectionException(e, u.Uri.ToString());
		}
	}

	/// <summary>
	/// Gets the Query 
	/// </summary>
	/// <param name="parameters"></param>
	/// <returns></returns>
	private string GetQuery(IEnumerable<KeyValuePair<string, string>> parameters)
	{
		List<KeyValuePair<string, string>> param = new List<KeyValuePair<string, string>>();
		if (parameters != null)
		{
			param.AddRange(parameters);
		}
		param.Add(KV.Create("version", version));
		return string.Join("&", (from kv in param
			select KV.Create(HttpUtility.UrlEncode(kv.Key), HttpUtility.UrlEncode(kv.Value)) into kv
			select $"{kv.Key}={kv.Value}").ToArray());
	}

	/// <summary>
	/// Gets http response, returns (etag, data)
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	private SolrResponse GetResponse(IHttpWebRequest request)
	{
		using IHttpWebResponse response = request.GetResponse();
		string etag = response.Headers[HttpResponseHeader.ETag];
		string cacheControl = response.Headers[HttpResponseHeader.CacheControl];
		if (cacheControl != null && cacheControl.Contains("no-cache"))
		{
			etag = null;
		}
		return new SolrResponse(etag, ReadResponseToString(response));
	}

	/// <summary>
	/// Reads the full stream from the response and returns the content as stream,
	/// using the correct encoding.
	/// </summary>
	/// <param name="response">Web response from request to Solr</param>
	/// <returns></returns>
	private string ReadResponseToString(IHttpWebResponse response)
	{
		using Stream responseStream = response.GetResponseStream();
		using StreamReader reader = new StreamReader(responseStream, TryGetEncoding(response));
		return reader.ReadToEnd();
	}

	private Encoding TryGetEncoding(IHttpWebResponse response)
	{
		try
		{
			return Encoding.GetEncoding(response.CharacterSet);
		}
		catch
		{
			return Encoding.UTF8;
		}
	}
}
