using System;
using System.Collections.Generic;

namespace webapp.Handlers.Mobile;

[Serializable]
public class RuixinRequestData
{
	public string rx_token { get; set; }

	public string p_code { get; set; }

	public string user_id { get; set; }

	public Dictionary<string, string> data { get; set; }

	public string encrypted { get; set; }
}
