using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Localizing.Application.DTO;

[Serializable]
public class SYS_LOCALIZINGDTO : DTOBase
{
	public Guid LOCALIZING_ID { get; set; }

	public decimal LOCALIZING_TYPE { get; set; }

	public string INSTANCE { get; set; }

	public string PAGENAME { get; set; }

	public string STRING_KEY { get; set; }

	public Guid LANGUAGE_ID { get; set; }

	public string STRING_KEY_DESC { get; set; }

	public string STRING_KEY_TIP_DESC { get; set; }

	public string CULTURE { get; set; }

	public decimal? ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public Guid SYS_LANGUAGE_LANGUAGEID { get; set; }
}
