namespace ns276;

internal class EventArgs10 : EventArgs7
{
	private int int_1;

	public int EntriesSaved => int_1;

	internal EventArgs10(string archiveName, bool before, int entriesTotal, int entriesSaved, Class6751 entry)
		: base(archiveName, before ? Enum912.const_9 : Enum912.const_10)
	{
		base.EntriesTotal = entriesTotal;
		base.CurrentEntry = entry;
		int_1 = entriesSaved;
	}

	internal EventArgs10()
	{
	}

	internal EventArgs10(string archiveName, Enum912 flavor)
		: base(archiveName, flavor)
	{
	}

	internal static EventArgs10 smethod_0(string archiveName, Class6751 entry, long bytesXferred, long totalBytes)
	{
		EventArgs10 eventArgs = new EventArgs10(archiveName, Enum912.const_16);
		eventArgs.ArchiveName = archiveName;
		eventArgs.CurrentEntry = entry;
		eventArgs.BytesTransferred = bytesXferred;
		eventArgs.TotalBytesToTransfer = totalBytes;
		return eventArgs;
	}

	internal static EventArgs10 smethod_1(string archiveName)
	{
		return new EventArgs10(archiveName, Enum912.const_8);
	}

	internal static EventArgs10 smethod_2(string archiveName)
	{
		return new EventArgs10(archiveName, Enum912.const_11);
	}
}
