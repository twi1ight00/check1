namespace ns276;

internal class EventArgs11 : EventArgs7
{
	private int int_1;

	private string string_1;

	public int EntriesExtracted => int_1;

	public string ExtractLocation => string_1;

	internal EventArgs11(string archiveName, bool before, int entriesTotal, int entriesExtracted, Class6751 entry, string extractLocation)
		: base(archiveName, before ? Enum912.const_17 : Enum912.const_18)
	{
		base.EntriesTotal = entriesTotal;
		base.CurrentEntry = entry;
		int_1 = entriesExtracted;
		string_1 = extractLocation;
	}

	internal EventArgs11(string archiveName, Enum912 flavor)
		: base(archiveName, flavor)
	{
	}

	internal EventArgs11()
	{
	}

	internal static EventArgs11 smethod_0(string archiveName, Class6751 entry, string extractLocation)
	{
		EventArgs11 eventArgs = new EventArgs11(archiveName, Enum912.const_17);
		eventArgs.CurrentEntry = entry;
		eventArgs.string_1 = extractLocation;
		return eventArgs;
	}

	internal static EventArgs11 smethod_1(string archiveName, Class6751 entry, string extractLocation)
	{
		EventArgs11 eventArgs = new EventArgs11(archiveName, Enum912.const_19);
		eventArgs.CurrentEntry = entry;
		eventArgs.string_1 = extractLocation;
		return eventArgs;
	}

	internal static EventArgs11 smethod_2(string archiveName, Class6751 entry, string extractLocation)
	{
		EventArgs11 eventArgs = new EventArgs11(archiveName, Enum912.const_18);
		eventArgs.CurrentEntry = entry;
		eventArgs.string_1 = extractLocation;
		return eventArgs;
	}

	internal static EventArgs11 smethod_3(string archiveName, string extractLocation)
	{
		EventArgs11 eventArgs = new EventArgs11(archiveName, Enum912.const_21);
		eventArgs.string_1 = extractLocation;
		return eventArgs;
	}

	internal static EventArgs11 smethod_4(string archiveName, string extractLocation)
	{
		EventArgs11 eventArgs = new EventArgs11(archiveName, Enum912.const_22);
		eventArgs.string_1 = extractLocation;
		return eventArgs;
	}

	internal static EventArgs11 smethod_5(string archiveName, Class6751 entry, long bytesWritten, long totalBytes)
	{
		EventArgs11 eventArgs = new EventArgs11(archiveName, Enum912.const_20);
		eventArgs.ArchiveName = archiveName;
		eventArgs.CurrentEntry = entry;
		eventArgs.BytesTransferred = bytesWritten;
		eventArgs.TotalBytesToTransfer = totalBytes;
		return eventArgs;
	}
}
