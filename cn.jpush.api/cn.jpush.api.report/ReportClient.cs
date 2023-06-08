using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using cn.jpush.api.common;
using cn.jpush.api.util;
using Newtonsoft.Json.Linq;

namespace cn.jpush.api.report;

internal class ReportClient : BaseHttpClient
{
	private const string REPORT_HOST_NAME = "https://report.jpush.cn";

	private const string REPORT_RECEIVE_PATH = "/v2/received";

	private const string REPORT_RECEIVE_PATH_V3 = "/v3/received";

	private const string REPORT_MESSAGE_PATH_V3 = "/v3/messages";

	private const string REPORT_USER_PATH = "/v3/users";

	private string appKey;

	private string masterSecret;

	public ReportClient(string appKey, string masterSecret)
	{
		this.appKey = appKey;
		this.masterSecret = masterSecret;
	}

	public ReceivedResult getReceiveds(string msg_ids)
	{
		checkMsgids(msg_ids);
		return getReceiveds_common(msg_ids, "/v2/received");
	}

	public ReceivedResult getReceiveds_v3(string msg_ids)
	{
		checkMsgids(msg_ids);
		return getReceiveds_common(msg_ids, "/v3/received");
	}

	public ResponseWrapper getMessageSendStatus(string msgId, List<string> registrationIdList, string data)
	{
		checkMsgids(msgId);
		string url = "https://report.jpush.cn/v3/status/message";
		JObject jObject = new JObject
		{
			{
				"msg_id",
				long.Parse(msgId)
			},
			{
				"registration_ids",
				JArray.FromObject(registrationIdList)
			}
		};
		if (!string.IsNullOrEmpty(data))
		{
			jObject.Add("data", data);
		}
		string base64Encode = Base64.getBase64Encode(appKey + ":" + masterSecret);
		return sendPost(url, base64Encode, jObject.ToString());
	}

	public UsersResult getUsers(TimeUnit timeUnit, string start, int duration)
	{
		string url = "https://report.jpush.cn/v3/users?time_unit=" + timeUnit.ToString() + "&start=" + start + "&duration=" + duration;
		string base64Encode = Base64.getBase64Encode(appKey + ":" + masterSecret);
		return UsersResult.fromResponse(sendGet(url, base64Encode, null));
	}

	public MessagesResult getReportMessages(params string[] msgIds)
	{
		return getReportMessages(StringUtil.arrayToString(msgIds));
	}

	public string checkMsgids(string msgIds)
	{
		if (string.IsNullOrEmpty(msgIds))
		{
			throw new ArgumentException("msgIds param is required.");
		}
		if (new Regex("[^0-9, ]").IsMatch(msgIds))
		{
			throw new ArgumentException("msgIds param format is incorrect. It should be msg_id (number) which response from JPush Push API. If there are many, use ',' as interval. ");
		}
		msgIds = msgIds.Trim();
		if (msgIds.EndsWith(","))
		{
			msgIds = msgIds.Substring(0, msgIds.Length - 1);
		}
		string[] array = msgIds.Split(',');
		List<string> list = new List<string>();
		try
		{
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i].Trim();
				if (!string.IsNullOrEmpty(text))
				{
					long.Parse(text);
					list.Add(text);
				}
			}
			return StringUtil.arrayToString(list.ToArray());
		}
		catch (Exception)
		{
			throw new Exception("Every msg_id should be valid Integer number which splits by ','");
		}
	}

	private ReceivedResult getReceiveds_common(string msg_ids, string path)
	{
		string url = "https://report.jpush.cn" + path + "?msg_ids=" + msg_ids;
		string base64Encode = Base64.getBase64Encode(appKey + ":" + masterSecret);
		ResponseWrapper responseWrapper = sendGet(url, base64Encode, null);
		ReceivedResult receivedResult = new ReceivedResult();
		List<ReceivedResult.Received> list = new List<ReceivedResult.Received>();
		if (responseWrapper.responseCode == HttpStatusCode.OK)
		{
			list = (List<ReceivedResult.Received>)JsonTool.JsonToObject(responseWrapper.responseContent, list);
			_ = responseWrapper.responseContent;
		}
		receivedResult.ResponseResult = responseWrapper;
		receivedResult.ReceivedList = list;
		return receivedResult;
	}

	private MessagesResult getReportMessages(string msgIds)
	{
		string text = checkMsgids(msgIds);
		string url = "https://report.jpush.cn/v3/messages?msg_ids=" + text;
		string base64Encode = Base64.getBase64Encode(appKey + ":" + masterSecret);
		ResponseWrapper responseWrapper = sendGet(url, base64Encode, null);
		MessagesResult messagesResult = new MessagesResult();
		List<MessagesResult.Message> list = new List<MessagesResult.Message>();
		Console.WriteLine("recieve content==" + responseWrapper.responseContent);
		if (responseWrapper.responseCode == HttpStatusCode.OK)
		{
			list = (List<MessagesResult.Message>)JsonTool.JsonToObject(responseWrapper.responseContent, list);
			_ = responseWrapper.responseContent;
		}
		messagesResult.ResponseResult = responseWrapper;
		messagesResult.messages = list;
		return messagesResult;
	}
}
