using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SiteMessage.Domain.Models;

public class MSG_MESSAGE_USER : Entity
{
	public Guid ID { get; set; }

	public Guid MESSAGE_ID { get; set; }

	public Guid USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public Guid? ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public decimal STATUS { get; set; }

	public decimal IS_DEL { get; set; }

	public decimal USER_TYPE { get; set; }

	public virtual MSG_MESSAGE MSG_MESSAGE { get; set; }
}
