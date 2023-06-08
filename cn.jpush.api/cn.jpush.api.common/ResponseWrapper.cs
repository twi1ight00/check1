using System;
using System.Net;
using cn.jpush.api.push;
using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.common;

public class ResponseWrapper
{
	private const int RESPONSE_CODE_NONE = -1;

	private string _responseContent;

	public JpushError jpushError;

	public HttpStatusCode responseCode = HttpStatusCode.BadRequest;

	public int rateLimitQuota;

	public int rateLimitRemaining;

	public int rateLimitReset;

	public string exceptionString;

	public string responseContent
	{
		get
		{
			return _responseContent;
		}
		set
		{
			_responseContent = value;
		}
	}

	public void setErrorObject()
	{
		if (!string.IsNullOrEmpty(_responseContent))
		{
			jpushError = JsonConvert.DeserializeObject<JpushError>(_responseContent);
		}
	}

	public bool isServerResponse()
	{
		return responseCode == HttpStatusCode.OK;
	}

	public void setRateLimit(string quota, string remaining, string reset)
	{
		if (quota == null)
		{
			return;
		}
		try
		{
			if (quota != "" && StringUtil.IsInt(quota))
			{
				rateLimitQuota = int.Parse(quota);
			}
			if (remaining != "" && StringUtil.IsInt(remaining))
			{
				rateLimitRemaining = int.Parse(remaining);
			}
			if (reset != "" && StringUtil.IsInt(reset))
			{
				rateLimitReset = int.Parse(reset);
			}
			Console.WriteLine($"JPush API Rate Limiting params - quota:{quota}, remaining:{remaining}, reset:{reset} " + " " + DateTime.Now);
		}
		catch (Exception)
		{
		}
	}
}
