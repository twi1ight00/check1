using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Document.Domain.Models;

public class DOC_CONTENTS : Entity
{
	public Guid CONTENT_ID { get; set; }

	public string CONTENT_NAME { get; set; }

	public Guid? PARENT_CONTENT_ID { get; set; }

	public decimal? STATUS { get; set; }

	public decimal? SORT { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }
}
