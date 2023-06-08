using System;

namespace webapp.Handlers.Mobile;

[Serializable]
public class Error
{
	public int errorcode { get; set; }

	public string errormsg { get; set; }
}
