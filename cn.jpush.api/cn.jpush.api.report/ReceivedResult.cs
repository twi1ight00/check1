using System.Collections.Generic;
using System.Net;
using cn.jpush.api.common;

namespace cn.jpush.api.report;

public class ReceivedResult : BaseResult
{
	public class Received
	{
		public long msg_id;

		public string android_received;

		public string ios_apns_sent;
	}

	private List<Received> receivedList = new List<Received>();

	public List<Received> ReceivedList
	{
		get
		{
			return receivedList;
		}
		set
		{
			receivedList = value;
		}
	}

	public override bool isResultOK()
	{
		if (object.Equals(base.ResponseResult.responseCode, HttpStatusCode.OK))
		{
			return true;
		}
		return false;
	}

	public HttpStatusCode getErrorCode()
	{
		if (base.ResponseResult != null)
		{
			return base.ResponseResult.responseCode;
		}
		return (HttpStatusCode)0;
	}

	public string getErrorMessage()
	{
		if (base.ResponseResult != null)
		{
			return base.ResponseResult.exceptionString;
		}
		return "";
	}
}
