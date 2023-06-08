using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Supervise.Domain.Models;

public class SUP_FEED_BACK : Entity
{
	public Guid FEED_BACK_ID { get; set; }

	public Guid? ASSIGN_TASK_ID { get; set; }

	public Guid? FEED_BACK_USER { get; set; }

	public string FEED_BACK_NAME { get; set; }

	public string FEED_BACK_CONTENT { get; set; }

	public decimal? FEED_BACK_STATUS { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual SUP_ASSIGN_TASK SUP_ASSIGN_TASK { get; set; }
}
