using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.AddressBookMangement.Domain.Models;

public class AB_PERSONAL_GROUP : Entity
{
	public Guid GROUP_ID { get; set; }

	public Guid? CATEGORY_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public string GROUP_NAME { get; set; }

	public string CATEGORY_TYPE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal? SORT { get; set; }

	public virtual AB_CATEGORY AB_CATEGORY { get; set; }

	public virtual ICollection<AB_GROUP_CONTACT> AB_GROUP_CONTACT { get; set; }

	public AB_PERSONAL_GROUP()
	{
		AB_GROUP_CONTACT = new HashSet<AB_GROUP_CONTACT>();
	}
}
