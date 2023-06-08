using System;

namespace webapp.Handlers.Mobile;

[Serializable]
public class ValidateData<T>
{
	public string status { get; set; }

	public UserBody<T> body { get; set; }
}
