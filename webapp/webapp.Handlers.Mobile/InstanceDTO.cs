using System;
using System.Collections.Generic;

namespace webapp.Handlers.Mobile;

[Serializable]
public class InstanceDTO
{
	public string Title { get; set; }

	public string FlowName { get; set; }

	public Guid FlowTypeID { get; set; }

	public string FlowType { get; set; }

	public string FlowTypeName { get; set; }

	public Guid FlowID { get; set; }

	public string CurrentUser { get; set; }

	public string SendTime { get; set; }

	public string ptCode { get; set; }

	public string iconURL { get; set; }

	public string detailPageURL { get; set; }

	public Dictionary<string, string> specialJson { get; set; }
}
