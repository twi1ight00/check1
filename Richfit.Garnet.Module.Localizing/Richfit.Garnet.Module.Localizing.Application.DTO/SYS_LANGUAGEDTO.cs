using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Localizing.Application.DTO;

[Serializable]
public class SYS_LANGUAGEDTO : DTOBase
{
	public Guid LANGUAGE_ID { get; set; }

	public string LANGUAGE_NAME { get; set; }

	public string CULTURE { get; set; }

	public decimal IS_USE { get; set; }

	public decimal? SORT { get; set; }

	public List<Guid> SYS_LOCALIZING_LOCALIZINGID { get; set; }
}
