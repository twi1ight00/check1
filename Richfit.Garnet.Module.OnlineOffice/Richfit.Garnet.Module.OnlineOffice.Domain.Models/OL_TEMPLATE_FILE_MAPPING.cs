using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.OnlineOffice.Domain.Models;

public class OL_TEMPLATE_FILE_MAPPING : Entity
{
	public Guid ID { get; set; }

	public Guid OBJ_ID { get; set; }

	public Guid TEMPLATE_FILE_ID { get; set; }
}
