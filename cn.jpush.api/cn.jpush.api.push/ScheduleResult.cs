using System.Net;
using cn.jpush.api.common;

namespace cn.jpush.api.push;

public class ScheduleResult : BaseResult
{
	public string schedule_id { get; set; }

	public string name { get; set; }

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
		return $"sendno:{schedule_id},message_id:{name}";
	}
}
