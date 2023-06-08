using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using SolrNet.Exceptions;
using SolrNet.Utils;

namespace SolrNet.Impl;

/// <summary>
/// Manages HTTP connection with Solr, uses POST request instead of GET in order to handle large requests
/// </summary>
public class PostSolrConnection : ISolrConnection
{
	private readonly ISolrConnection conn;

	private readonly string serverUrl;

	public PostSolrConnection(ISolrConnection conn, string serverUrl)
	{
		this.conn = conn;
		this.serverUrl = serverUrl;
	}

	public string Post(string relativeUrl, string s)
	{
		return conn.Post(relativeUrl, s);
	}

	public string Get(string relativeUrl, IEnumerable<KeyValuePair<string, string>> parameters)
	{
		UriBuilder u = new UriBuilder(serverUrl);
		u.Path += relativeUrl;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(u.Uri);
		request.Method = "POST";
		request.ContentType = "application/x-www-form-urlencoded";
		string qs = string.Join("&", parameters.Select((KeyValuePair<string, string> kv) => $"{HttpUtility.UrlEncode(kv.Key)}={HttpUtility.UrlEncode(kv.Value)}").ToArray());
		request.ContentLength = Encoding.UTF8.GetByteCount(qs);
		request.ProtocolVersion = HttpVersion.Version11;
		request.KeepAlive = true;
		try
		{
			using (Stream postParams = request.GetRequestStream())
			{
				using StreamWriter sw = new StreamWriter(postParams);
				sw.Write(qs);
			}
			using WebResponse response = request.GetResponse();
			using Stream responseStream = response.GetResponseStream();
			using StreamReader sr = new StreamReader(responseStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
			return sr.ReadToEnd();
		}
		catch (WebException e)
		{
			throw new SolrConnectionException(e);
		}
	}

	public string PostStream(string relativeUrl, string contentType, Stream content, IEnumerable<KeyValuePair<string, string>> getParameters)
	{
		return conn.PostStream(relativeUrl, contentType, content, getParameters);
	}
}
