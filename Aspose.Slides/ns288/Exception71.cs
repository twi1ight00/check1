using System;

namespace ns288;

internal sealed class Exception71 : Exception
{
	public Exception71(string message, string html, Exception innerException)
		: base(message, innerException)
	{
		Data.Add("rawHtml", html);
	}

	public Exception71(string message, string html)
		: this(message, html, null)
	{
	}
}
