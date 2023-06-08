namespace ns276;

internal class EventArgs9 : EventArgs7
{
	internal EventArgs9()
	{
	}

	private EventArgs9(string archiveName, Enum912 flavor)
		: base(archiveName, flavor)
	{
	}

	internal static EventArgs9 smethod_0(string archiveName, Class6751 entry, int entriesTotal)
	{
		EventArgs9 eventArgs = new EventArgs9(archiveName, Enum912.const_1);
		eventArgs.EntriesTotal = entriesTotal;
		eventArgs.CurrentEntry = entry;
		return eventArgs;
	}

	internal static EventArgs9 smethod_1(string archiveName)
	{
		return new EventArgs9(archiveName, Enum912.const_0);
	}

	internal static EventArgs9 smethod_2(string archiveName)
	{
		return new EventArgs9(archiveName, Enum912.const_2);
	}
}
