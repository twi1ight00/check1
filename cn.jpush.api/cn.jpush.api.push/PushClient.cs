using cn.jpush.api.common;
using cn.jpush.api.push.mode;
using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.push;

internal class PushClient : BaseHttpClient
{
	private const string HOST_NAME_SSL = "https://api.jpush.cn";

	private const string PUSH_PATH = "/v3/push";

	private string appKey;

	private string masterSecret;

	public PushClient(string appKey, string masterSecret)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(appKey), "appKey should be set");
		Preconditions.checkArgument(!string.IsNullOrEmpty(masterSecret), "masterSecret should be set");
		this.appKey = appKey;
		this.masterSecret = masterSecret;
	}

	public MessageResult sendPush(PushPayload payload)
	{
		Preconditions.checkArgument(payload != null, "pushPayload should not be empty");
		payload.Check();
		string payloadString = payload.ToJson();
		return sendPush(payloadString);
	}

	public MessageResult sendPush(string payloadString)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(payloadString), "payloadstring should not be empty");
		string text = "https://api.jpush.cn";
		text += "/v3/push";
		ResponseWrapper responseWrapper = sendPost(text, Authorization(), payloadString);
		MessageResult obj = new MessageResult
		{
			ResponseResult = responseWrapper
		};
		JpushSuccess jpushSuccess = JsonConvert.DeserializeObject<JpushSuccess>(responseWrapper.responseContent);
		obj.sendno = long.Parse(jpushSuccess.sendno);
		obj.msg_id = long.Parse(jpushSuccess.msg_id);
		return obj;
	}

	private string Authorization()
	{
		return Base64.getBase64Encode(appKey + ":" + masterSecret);
	}
}
