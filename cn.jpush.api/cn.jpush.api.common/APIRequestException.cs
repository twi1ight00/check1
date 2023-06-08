using System;
using System.Net;
using cn.jpush.api.push;

namespace cn.jpush.api.common;

public class APIRequestException : Exception
{
	private ResponseWrapper responseRequest;

	public HttpStatusCode Status => responseRequest.responseCode;

	public long MsgId => responseRequest.jpushError.msg_id;

	public int ErrorCode => responseRequest.jpushError.error.code;

	public string ErrorMessage => responseRequest.jpushError.error.message;

	public APIRequestException(ResponseWrapper responseRequest)
		: base(responseRequest.exceptionString)
	{
		this.responseRequest = responseRequest;
	}

	private JpushError ErrorObject()
	{
		return responseRequest.jpushError;
	}

	public int RateLimitQuota()
	{
		return responseRequest.rateLimitQuota;
	}

	public int RateLimitRemaining()
	{
		return responseRequest.rateLimitRemaining;
	}

	public int RateLimitReset()
	{
		return responseRequest.rateLimitReset;
	}
}
