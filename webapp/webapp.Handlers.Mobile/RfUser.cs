using System;

namespace webapp.Handlers.Mobile;

[Serializable]
public class RfUser
{
	public string userid { get; set; }

	public string username { get; set; }

	public string email { get; set; }

	public string login_id { get; set; }

	public string office_phone { get; set; }

	public string office_mobile { get; set; }

	public string orgid { get; set; }

	public string orgname { get; set; }

	public string company { get; set; }

	public string top_orgid { get; set; }

	public string top_orgname { get; set; }

	public string juname { get; set; }
}
