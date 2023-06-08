using System;

namespace ns73;

internal class EventArgs1 : EventArgs
{
	private string string_0;

	public string Uri => string_0;

	public EventArgs1(string uri)
	{
		string_0 = uri;
	}
}
