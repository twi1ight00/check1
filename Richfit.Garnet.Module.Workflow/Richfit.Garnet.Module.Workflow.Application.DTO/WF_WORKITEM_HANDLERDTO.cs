using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

public class WF_WORKITEM_HANDLERDTO : DTOBase
{
	public Guid WORKITEM_HANDLER_ID { get; set; }

	public Guid WORKITEM_ID { get; set; }

	public Guid USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public Guid? HANDLE_USER_ID { get; set; }

	public string HANDLE_USER_NAME { get; set; }

	public DateTime? HANDLE_TIME { get; set; }

	public decimal? HANDLE_RESULT { get; set; }

	public string HANDLE_SUGGESTION { get; set; }

	public decimal? SIGNATURE_MODE { get; set; }

	public decimal? CLIENT_TYPE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public string StopTime
	{
		get
		{
			TimeSpan ts = ((!HANDLE_TIME.HasValue) ? (DateTime.Now - CREATETIME) : (HANDLE_TIME.Value - CREATETIME));
			string[] ss = $"{ts:G}".Split(':');
			string result = "";
			if (Convert.ToInt32(ss[0]) != 0)
			{
				result = result + ss[0] + "天";
			}
			if (Convert.ToInt32(ss[1]) == 0)
			{
				if (result != "")
				{
					result = result + ss[1] + "小时";
				}
			}
			else
			{
				result = result + ss[1] + "小时";
			}
			return result + ss[2] + "分钟";
		}
	}
}
