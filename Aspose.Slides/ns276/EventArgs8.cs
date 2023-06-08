namespace ns276;

internal class EventArgs8 : EventArgs7
{
	internal EventArgs8()
	{
	}

	private EventArgs8(string archiveName, Enum912 flavor)
		: base(archiveName, flavor)
	{
	}

	internal static EventArgs8 smethod_0(string archiveName, int entriesTotal)
	{
		EventArgs8 eventArgs = new EventArgs8(archiveName, Enum912.const_4);
		eventArgs.EntriesTotal = entriesTotal;
		return eventArgs;
	}

	internal static EventArgs8 smethod_1(string archiveName, Class6751 entry, int entriesTotal)
	{
		EventArgs8 eventArgs = new EventArgs8(archiveName, Enum912.const_5);
		eventArgs.EntriesTotal = entriesTotal;
		eventArgs.CurrentEntry = entry;
		return eventArgs;
	}

	internal static EventArgs8 smethod_2(string archiveName)
	{
		return new EventArgs8(archiveName, Enum912.const_3);
	}

	internal static EventArgs8 smethod_3(string archiveName, Class6751 entry, long bytesXferred, long totalBytes)
	{
		EventArgs8 eventArgs = new EventArgs8(archiveName, Enum912.const_7);
		eventArgs.CurrentEntry = entry;
		eventArgs.BytesTransferred = bytesXferred;
		eventArgs.TotalBytesToTransfer = totalBytes;
		return eventArgs;
	}

	internal static EventArgs8 smethod_4(string archiveName)
	{
		return new EventArgs8(archiveName, Enum912.const_6);
	}
}
