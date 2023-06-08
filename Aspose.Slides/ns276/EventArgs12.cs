using System;

namespace ns276;

internal class EventArgs12 : EventArgs7
{
	private Exception exception_0;

	public Exception Exception => exception_0;

	public string FileName => base.CurrentEntry.LocalFileName;

	private EventArgs12()
	{
	}

	internal static EventArgs12 smethod_0(string archiveName, Class6751 entry, Exception exception)
	{
		EventArgs12 eventArgs = new EventArgs12();
		eventArgs.EventType = Enum912.const_23;
		eventArgs.ArchiveName = archiveName;
		eventArgs.CurrentEntry = entry;
		eventArgs.exception_0 = exception;
		return eventArgs;
	}
}
