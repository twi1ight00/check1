using Aspose.Words;
using x13f1efc79617a47b;

namespace xa2462df43988ffad;

internal class xd191b8547552c43b
{
	private readonly x9c77c7e782b62883 x800085dd555f7711;

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	private readonly x560f0e9efcf5b9b1 x6962cbeae4129aa3;

	private readonly x09b79d8a30000f4d x07f7735addeb2f9d;

	private readonly x88c62cf8fe0ab427 x26e8f4c9d5e1872f;

	internal xd191b8547552c43b(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		x800085dd555f7711 = writer.x082c3925d43afdad("/content.xml");
		x6962cbeae4129aa3 = new x560f0e9efcf5b9b1(x9b287b671d592594);
		x07f7735addeb2f9d = new x09b79d8a30000f4d(x9b287b671d592594);
		x26e8f4c9d5e1872f = new x88c62cf8fe0ab427(x9b287b671d592594);
	}

	internal void x6210059f049f0d48()
	{
		x800085dd555f7711.xd752bfc8559f7490();
		if (x9b287b671d592594.xf57de0fd37d5e97d.xbfa4c2c3efbf56fd)
		{
			x9b287b671d592594.xe1410f585439c7d4.x5222f4285e37d66b.WriteComment(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fjdpjlkpenbakniaompaingbemnbeneccmlcolcdhhjdglaekmheogoegmffihmfcmdgcgkg", 1136391029)), "Aspose.Words for .NET 11.9.0.0"));
		}
		x9b287b671d592594.x2c8c6741422a1298.Accept(x9b287b671d592594);
	}

	internal VisitorAction x5d0e2a54495c06dc()
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		x26e8f4c9d5e1872f.x6210059f049f0d48();
		x6962cbeae4129aa3.x6210059f049f0d48();
		x07f7735addeb2f9d.xd29409f2ba9889e2();
		return VisitorAction.Continue;
	}
}
