using System;
using System.IO;
using System.Net;
using System.Text;
using cn.jpush.api.common.resp;

namespace cn.jpush.api.common;

public class BaseHttpClient
{
	private const string CHARSET = "UTF-8";

	private const string RATE_LIMIT_QUOTA = "X-Rate-Limit-Limit";

	private const string RATE_LIMIT_Remaining = "X-Rate-Limit-Remaining";

	private const string RATE_LIMIT_Reset = "X-Rate-Limit-Reset";

	protected const int RESPONSE_OK = 200;

	private const int DEFAULT_CONNECTION_TIMEOUT = 100000;

	private const int DEFAULT_SOCKET_TIMEOUT = 100000;

	public ResponseWrapper sendPost(string url, string auth, string reqParams)
	{
		return sendRequest("POST", url, auth, reqParams);
	}

	public ResponseWrapper sendDelete(string url, string auth, string reqParams)
	{
		return sendRequest("DELETE", url, auth, reqParams);
	}

	public ResponseWrapper sendGet(string url, string auth, string reqParams)
	{
		return sendRequest("GET", url, auth, reqParams);
	}

	public ResponseWrapper sendPut(string url, string auth, string reqParams)
	{
		return sendRequest("PUT", url, auth, reqParams);
	}

	public ResponseWrapper sendRequest(string method, string url, string auth, string reqParams)
	{
		Console.WriteLine("Send request - " + method.ToString() + " " + url + " " + DateTime.Now);
		if (reqParams != null)
		{
			Console.WriteLine("Request Content - " + reqParams + " " + DateTime.Now);
		}
		ResponseWrapper responseWrapper = new ResponseWrapper();
		HttpWebRequest httpWebRequest = null;
		HttpWebResponse httpWebResponse = null;
		try
		{
			httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = method;
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.KeepAlive = false;
			if (!string.IsNullOrEmpty(auth))
			{
				httpWebRequest.Headers.Add("Authorization", "Basic " + auth);
			}
			if (method == "POST" || method == "PUT")
			{
				byte[] bytes = Encoding.UTF8.GetBytes(reqParams);
				httpWebRequest.ContentLength = bytes.Length;
				using Stream stream = httpWebRequest.GetRequestStream();
				stream.Write(bytes, 0, bytes.Length);
				stream.Close();
			}
			httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			HttpStatusCode statusCode = httpWebResponse.StatusCode;
			responseWrapper.responseCode = statusCode;
			if (object.Equals(httpWebResponse.StatusCode, HttpStatusCode.OK))
			{
				using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8))
				{
					responseWrapper.responseContent = streamReader.ReadToEnd();
				}
				string responseHeader = httpWebResponse.GetResponseHeader("X-Rate-Limit-Limit");
				string responseHeader2 = httpWebResponse.GetResponseHeader("X-Rate-Limit-Remaining");
				string responseHeader3 = httpWebResponse.GetResponseHeader("X-Rate-Limit-Reset");
				responseWrapper.setRateLimit(responseHeader, responseHeader2, responseHeader3);
				Console.WriteLine("Succeed to get response - 200 OK " + DateTime.Now);
				Console.WriteLine("Response Content - {0}", responseWrapper.responseContent + " " + DateTime.Now);
			}
		}
		catch (WebException ex)
		{
			if (ex.Status == WebExceptionStatus.ProtocolError)
			{
				HttpStatusCode statusCode2 = ((HttpWebResponse)ex.Response).StatusCode;
				_ = ((HttpWebResponse)ex.Response).StatusDescription;
				using (StreamReader streamReader2 = new StreamReader(((HttpWebResponse)ex.Response).GetResponseStream(), Encoding.UTF8))
				{
					responseWrapper.responseContent = streamReader2.ReadToEnd();
				}
				responseWrapper.responseCode = statusCode2;
				responseWrapper.exceptionString = ex.Message;
				string responseHeader4 = ((HttpWebResponse)ex.Response).GetResponseHeader("X-Rate-Limit-Limit");
				string responseHeader5 = ((HttpWebResponse)ex.Response).GetResponseHeader("X-Rate-Limit-Remaining");
				string responseHeader6 = ((HttpWebResponse)ex.Response).GetResponseHeader("X-Rate-Limit-Reset");
				responseWrapper.setRateLimit(responseHeader4, responseHeader5, responseHeader6);
				responseWrapper.setErrorObject();
				Console.WriteLine($"fail  to get response - {statusCode2}" + " " + DateTime.Now);
				Console.WriteLine($"Response Content - {responseWrapper.responseContent}" + " " + DateTime.Now);
				throw new APIRequestException(responseWrapper);
			}
			string text = method + url + auth + reqParams;
			Console.WriteLine(text);
			throw new APIConnectionException(ex.Message, text);
		}
		finally
		{
			httpWebResponse?.Close();
			httpWebRequest?.Abort();
		}
		return responseWrapper;
	}
}
