using System.Collections.Generic;
using System.Net;
using cn.jpush.api.common;
using Newtonsoft.Json;

namespace cn.jpush.api.report;

public class MessagesResult : BaseResult
{
	public class Message
	{
		public long? msg_id;

		public Android android;

		public Ios ios;

		public Message()
		{
			msg_id = 0L;
			android = null;
			ios = null;
		}
	}

	public class Android
	{
		public int? received;

		public int? target;

		public int? online_push;

		public int? click;

		public Android()
		{
			received = 0;
			target = 0;
			online_push = 0;
			click = 0;
		}
	}

	public class Ios
	{
		public int? apns_sent;

		public int? apns_target;

		public int? click;

		public Ios()
		{
			apns_sent = 0;
			apns_target = 0;
			click = 0;
		}
	}

	public List<Message> messages = new List<Message>();

	public static MessagesResult fromResponse(ResponseWrapper responseWrapper)
	{
		MessagesResult messagesResult = new MessagesResult();
		if (responseWrapper.responseCode == HttpStatusCode.OK)
		{
			messagesResult.messages = JsonConvert.DeserializeObject<List<Message>>(responseWrapper.responseContent);
		}
		messagesResult.ResponseResult = responseWrapper;
		return messagesResult;
	}

	public override bool isResultOK()
	{
		if (object.Equals(base.ResponseResult.responseCode, HttpStatusCode.OK))
		{
			return true;
		}
		return false;
	}
}
