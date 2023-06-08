using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_BUSINESS : Entity
{
	public Guid BUSINESS_ID { get; set; }

	public Guid? LIBRARY_ID { get; set; }

	public string BUSINESS_CODE { get; set; }

	public string BUSINESS_NAME { get; set; }

	public Guid? PARENT_BUSINESS_ID { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public decimal IS_ADD_ACTION_GROUP { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual ICollection<SYS_ACTION_GROUP> SYS_ACTION_GROUP { get; set; }

	public virtual SYS_LIBRARY SYS_LIBRARY { get; set; }

	public virtual SYS_MENU SYS_MENU { get; set; }

	public virtual ICollection<SYS_PRIVILEGE> SYS_PRIVILEGE { get; set; }

	public virtual ICollection<SYS_USER_BUSINESS> SYS_USER_BUSINESS { get; set; }

	public SYS_BUSINESS()
	{
		SYS_ACTION_GROUP = new HashSet<SYS_ACTION_GROUP>();
		SYS_PRIVILEGE = new HashSet<SYS_PRIVILEGE>();
		SYS_USER_BUSINESS = new HashSet<SYS_USER_BUSINESS>();
	}
}
