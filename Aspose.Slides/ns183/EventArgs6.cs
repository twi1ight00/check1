using System;

namespace ns183;

internal class EventArgs6 : EventArgs
{
	private string string_0;

	public string Uri => string_0;

	public EventArgs6(string uri)
	{
		string_0 = uri;
	}
}
