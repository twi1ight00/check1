using System;

namespace webapp.Handlers.Mobile;

[Serializable]
public class UserMobile
{
	public Guid TokenGuid { get; set; }

	public Guid USER_ID { get; set; }

	public string UserName { get; set; }

	public Guid OrgId { get; set; }

	public string EXTEND1 { get; set; }

	public bool IsSuperUser { get; set; }
}
