using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.OnlineOffice.Application.DTO;

public class OL_TEMPLATE_FILE_MAPPINGDTO : DTOBase
{
	public Guid ID { get; set; }

	public Guid OBJ_ID { get; set; }

	public Guid TEMPLATE_FILE_ID { get; set; }
}
