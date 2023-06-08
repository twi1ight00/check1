using ns33;

namespace ns56;

internal class Class2497
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "sldView", "sldMasterView", "notesView", "handoutView", "notesMasterView", "outlineView", "sldSorterView", "sldThumbnailView");

	public static Enum361 smethod_0(string xmlValue)
	{
		return (Enum361)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum361 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
