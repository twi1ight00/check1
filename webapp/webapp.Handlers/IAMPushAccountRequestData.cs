using System.Collections.Generic;

namespace webapp.Handlers;

public class IAMPushAccountRequestData
{
	public string status { get; set; }

	public string accountName { get; set; }

	public bool enabled { get; set; }

	public IList<string> orgList { get; set; }

	public IList<string> appOrgList { get; set; }

	public Dictionary<string, string> mappingAttr { get; set; }

	public Dictionary<string, string> extAttr { get; set; }

	public string userName { get; set; }

	public string masterId { get; set; }

	public string appCode { get; set; }

	public IList<string> roleCodes { get; set; }
}
