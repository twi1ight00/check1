using System;

namespace ns83;

internal class Exception74 : Exception
{
	public string string_0;

	public override string Message
	{
		get
		{
			if (string_0 != null)
			{
				return string_0;
			}
			return null;
		}
	}

	public Exception74(string elementDescription)
	{
		string_0 = elementDescription;
	}
}
