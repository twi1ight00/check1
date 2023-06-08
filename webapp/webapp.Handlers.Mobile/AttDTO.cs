using System;

namespace webapp.Handlers.Mobile;

[Serializable]
public class AttDTO
{
	public string AttachID { get; set; }

	public string AttachTitle { get; set; }

	public string AttachSize { get; set; }

	public string AttachType { get; set; }
}
