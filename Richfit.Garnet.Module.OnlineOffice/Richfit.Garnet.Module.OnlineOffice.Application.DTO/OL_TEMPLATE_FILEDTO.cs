using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.OnlineOffice.Application.DTO;

public class OL_TEMPLATE_FILEDTO : DTOBase
{
	public Guid ID { get; set; }

	public string TEMPLATE_FILE_URL { get; set; }

	public string TEMPLATE_FILE_NAME { get; set; }

	public string TEMPLATE_DESCRIBE { get; set; }

	public decimal IS_DEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }
}
