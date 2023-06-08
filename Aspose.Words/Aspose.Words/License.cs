using System;
using System.IO;
using System.Reflection;
using x13f1efc79617a47b;
using x28925c9b27b37a46;

namespace Aspose.Words;

[JavaManual("This was manually ported some time ago. Keep as is for now.")]
public class License
{
	public void SetLicense(string licenseName)
	{
		switch (xf077e0ca29a2a5af.xbd4904fd691196f5)
		{
		case xf077e0ca29a2a5af.xbd4904fd691196f5:
		{
			string text = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dklicmcjmljjalakmkhkhlokelflhkmlkkdmgkkmgjbnojin", 1233816403));
			break;
		}
		case xf077e0ca29a2a5af.x4a7d849f65d49ff1:
		{
			string text = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gkjpmmaapmhanloahmfbcmmbbmdcflkcmlbdlkid", 1819867489));
			break;
		}
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fleohnlomncpemjpmmaagmhaoloahhfbjlmbfldchlkcplbdblidelpdalgepfnealefcllfgkcgijjgofah", 1785652332)));
		}
		string text2 = xf077e0ca29a2a5af.xbd4904fd691196f5 switch
		{
			xf077e0ca29a2a5af.xbd4904fd691196f5 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ahnhpieijilinhcjjhjjeiakbihkehokhhfldhmldgdmlgkm", 11959584)), 
			xf077e0ca29a2a5af.x4a7d849f65d49ff1 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dppbjbhcmbockafdebmdpadeoakecabfjaifipof", 478420910)), 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gancicedncldfbcenbjehbafpahfimnfkafggamgiadhabkhcabifaiibapialfjbanjdaekhpkkjoblpkil", 1386228925))), 
		};
		if (licenseName == null)
		{
			throw new ArgumentNullException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mjcmgjjmnianmihncjonejfodimojgdpjhkpcibahhia", 892977712)));
		}
		x220f433da4115056 x220f433da = new x220f433da4115056();
		x220f433da.x7d0214bf69711dd9(licenseName, Assembly.GetCallingAssembly());
	}

	public void SetLicense(Stream stream)
	{
		string text;
		switch (xf077e0ca29a2a5af.xbd4904fd691196f5)
		{
		case xf077e0ca29a2a5af.xbd4904fd691196f5:
			text = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pbahodhhidohmcfiicmidddjadkjdcbkgcikccpkcbglkbnl", 784101327));
			break;
		case xf077e0ca29a2a5af.x4a7d849f65d49ff1:
			text = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dhbbjjibmjpbkigcejncpiedoildcicejijeihaf", 201006));
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("blkmdnbnininampnimgocmnoklepdhlpflcabljadlabllhbnkobalfcmkmclfddmkkdokbeckieejpekfgf", 1166723688)));
		}
		string text2 = xf077e0ca29a2a5af.xbd4904fd691196f5 switch
		{
			xf077e0ca29a2a5af.xbd4904fd691196f5 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mfoblhfcfhmcjgddfgkdahbengieagpedggfpfnfpeeghflg", 186261004)), 
			xf077e0ca29a2a5af.x4a7d849f65d49ff1 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fpjalbbbobibmapbgbgcbbncabedealdlacekpie", 102107568)), 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fcaahehameoaedfbmdmbgddcockchoadjcidfcpdhcgepcnebcefeclfaccgpmigacahcchhgbohiafiomli", 1163329500))), 
		};
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		x220f433da4115056 x220f433da = new x220f433da4115056();
		x220f433da.x7d0214bf69711dd9(stream);
		text = text2;
		text2 = text;
	}
}
