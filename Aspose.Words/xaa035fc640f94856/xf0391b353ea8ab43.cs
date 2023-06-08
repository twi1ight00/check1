using System.IO;
using x13f1efc79617a47b;

namespace xaa035fc640f94856;

internal class xf0391b353ea8ab43
{
	internal int xea1e81378298fa81;

	internal string xb405a444ca77e2d4 = "";

	internal string xd229d86af0f16fb0 = "";

	internal string x88fd06d066fb91d5 = "";

	internal xf0391b353ea8ab43(int id, string uri, string tag)
	{
		xea1e81378298fa81 = id;
		xb405a444ca77e2d4 = uri;
		xd229d86af0f16fb0 = tag;
	}

	internal xf0391b353ea8ab43(BinaryReader reader)
	{
		reader.ReadInt32();
		xea1e81378298fa81 = reader.ReadInt32() & 0xFFFF;
		xb405a444ca77e2d4 = xc20b6ff0d1c320ff.x06b0e25aa6ad68a9(reader);
		xd229d86af0f16fb0 = xc20b6ff0d1c320ff.x06b0e25aa6ad68a9(reader);
		x88fd06d066fb91d5 = xc20b6ff0d1c320ff.x06b0e25aa6ad68a9(reader);
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		int value = 4 + xc20b6ff0d1c320ff.x1deebb03a3d03a50(xb405a444ca77e2d4) + xc20b6ff0d1c320ff.x1deebb03a3d03a50(xd229d86af0f16fb0) + xc20b6ff0d1c320ff.x1deebb03a3d03a50(x88fd06d066fb91d5);
		xbdfb620b7167944b.Write(value);
		xbdfb620b7167944b.Write(xea1e81378298fa81);
		xc20b6ff0d1c320ff.x6210059f049f0d48(xbdfb620b7167944b, xb405a444ca77e2d4);
		xc20b6ff0d1c320ff.x6210059f049f0d48(xbdfb620b7167944b, xd229d86af0f16fb0);
		xc20b6ff0d1c320ff.x6210059f049f0d48(xbdfb620b7167944b, x88fd06d066fb91d5);
	}

	public override string ToString()
	{
		return string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fbcmncjmaaanodhnapnnkdfogolohncpjakpdcbahbiafooadcgbgnmbpbeclmkcmlbdnoidhppdkpgekmneiaffmllfeadgaljgbkahcmhhkoohpofidomiondjonkjnmbknmikllpkfngljmnlhjemfnlmkicnbnjn", 583909836)), xea1e81378298fa81, xb405a444ca77e2d4, xd229d86af0f16fb0, x88fd06d066fb91d5);
	}
}
