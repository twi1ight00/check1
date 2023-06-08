using ns33;

namespace ns56;

internal class Class2460
{
	private static readonly Class1151 class1151_0 = new Class1151("alignOff", "b", "begMarg", "begPad", "bendDist", "bMarg", "bOff", "connDist", "ctrX", "ctrXOff", "ctrY", "ctrYOff", "diam", "endMarg", "endPad", "h", "hArH", "hOff", "l", "lMarg", "lOff", "none", "primFontSz", "pyraAcctRatio", "r", "rMarg", "rOff", "secFontSz", "secSibSp", "sibSp", "sp", "stemThick", "t", "tMarg", "tOff", "userA", "userB", "userC", "userD", "userE", "userF", "userG", "userH", "userI", "userJ", "userK", "userL", "userM", "userN", "userO", "userP", "userQ", "userR", "userS", "userT", "userU", "userV", "userW", "userX", "userY", "userZ", "w", "wArH", "wOff");

	public static Enum305 smethod_0(string xmlValue)
	{
		return (Enum305)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum305 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
