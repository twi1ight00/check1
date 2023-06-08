using System;

namespace webapp.Handlers.Mobile;

[Serializable]
public class UserBody<T>
{
	public Error error { get; set; }

	public RFQueryResult<T> information { get; set; }
}
