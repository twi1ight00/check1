using System.Net;
using cn.jpush.api.common;
using cn.jpush.api.schedule;

namespace cn.jpush.api.push;

public class getScheduleResult : BaseResult
{
	public SchedulePayload[] schedules;

	public int total_count { get; set; }

	public int total_pages { get; set; }

	public int page { get; set; }

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
		return $"total_count:{total_count},total_pages:{total_pages},page:{page}";
	}
}
