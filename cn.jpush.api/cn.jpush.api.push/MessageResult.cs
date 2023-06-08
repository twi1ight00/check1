using System.Net;
using cn.jpush.api.common;

namespace cn.jpush.api.push;

public class MessageResult : BaseResult
{
	public long msg_id { get; set; }

	public long sendno { get; set; }

	public override bool isResultOK()
	{
		if (!object.Equals(base.ResponseResult.responseCode, HttpStatusCode.OK))
		{
			return false;
		}
		return true;
	}

	public override string ToString()
	{
		return $"sendno:{sendno},message_id:{msg_id}";
	}
}
