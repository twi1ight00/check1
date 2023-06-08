using System;
using System.Collections.Generic;

namespace webapp.Handlers.Mobile;

[Serializable]
public class ArticleDTO
{
	private DateTime _sendtime;

	public string Title { get; set; }

	public string SendTime
	{
		get
		{
			return _sendtime.ToString("yyyy-MM-dd HH:mm:ss");
		}
		set
		{
			_sendtime = Convert.ToDateTime(value);
		}
	}

	public string SendPeo { get; set; }

	public string AuditStatus { get; set; }

	public string DispatchPeo { get; set; }

	public string DispatchDep { get; set; }

	public string IsTop { get; set; }

	public string Url { get; set; }

	public IList<AttDTO> AttachmentList { get; set; }

	public ArticleDTO()
	{
		AttachmentList = new List<AttDTO>();
	}
}
