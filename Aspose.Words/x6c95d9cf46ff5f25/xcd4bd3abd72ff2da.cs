using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using x13f1efc79617a47b;

namespace x6c95d9cf46ff5f25;

[DebuggerStepThrough]
internal class xcd4bd3abd72ff2da
{
	public static readonly byte[] x2b0797e1bb4e840a = new byte[0];

	private xcd4bd3abd72ff2da()
	{
	}

	public static bool xf920f15ca6067ada(char[] xc017801291d6b7c8, char[] xf01158a578cec3a8)
	{
		if (xc017801291d6b7c8.Length != xf01158a578cec3a8.Length)
		{
			return false;
		}
		for (int i = 0; i < xc017801291d6b7c8.Length; i++)
		{
			if (xc017801291d6b7c8[i] != xf01158a578cec3a8[i])
			{
				return false;
			}
		}
		return true;
	}

	public static bool xf920f15ca6067ada(byte[] xc017801291d6b7c8, byte[] xf01158a578cec3a8)
	{
		if (xc017801291d6b7c8.Length != xf01158a578cec3a8.Length)
		{
			return false;
		}
		for (int i = 0; i < xc017801291d6b7c8.Length; i++)
		{
			if (xc017801291d6b7c8[i] != xf01158a578cec3a8[i])
			{
				return false;
			}
		}
		return true;
	}

	public static bool xf920f15ca6067ada(int[] xc017801291d6b7c8, int[] xf01158a578cec3a8)
	{
		if (xc017801291d6b7c8 == xf01158a578cec3a8)
		{
			return true;
		}
		if (xc017801291d6b7c8 == null || xf01158a578cec3a8 == null)
		{
			return false;
		}
		if (xc017801291d6b7c8.Length != xf01158a578cec3a8.Length)
		{
			return false;
		}
		for (int i = 0; i < xc017801291d6b7c8.Length; i++)
		{
			if (xc017801291d6b7c8[i] != xf01158a578cec3a8[i])
			{
				return false;
			}
		}
		return true;
	}

	public static bool xf920f15ca6067ada(float[] xc017801291d6b7c8, float[] xf01158a578cec3a8)
	{
		if (xc017801291d6b7c8.Length != xf01158a578cec3a8.Length)
		{
			return false;
		}
		for (int i = 0; i < xc017801291d6b7c8.Length; i++)
		{
			if (xc017801291d6b7c8[i] != xf01158a578cec3a8[i])
			{
				return false;
			}
		}
		return true;
	}

	public static string xd20e56ce95eb96ff(byte[] x4a3f0a05c02f235f)
	{
		if (x4a3f0a05c02f235f != null)
		{
			return xd20e56ce95eb96ff(x4a3f0a05c02f235f, 0, x4a3f0a05c02f235f.Length);
		}
		return "Null";
	}

	public static string xd20e56ce95eb96ff(byte[] x4a3f0a05c02f235f, int x10aaa7cdfa38f254, int x10f4d88af727adbc)
	{
		if (x4a3f0a05c02f235f == null)
		{
			return "Null";
		}
		StringBuilder stringBuilder = new StringBuilder();
		while (x10f4d88af727adbc > 0)
		{
			stringBuilder.AppendFormat("{0:X2} ", x4a3f0a05c02f235f[x10aaa7cdfa38f254]);
			x10aaa7cdfa38f254++;
			x10f4d88af727adbc--;
		}
		return stringBuilder.ToString();
	}

	public static string xd20e56ce95eb96ff(float[] x4a3f0a05c02f235f)
	{
		StringBuilder stringBuilder = new StringBuilder(x4a3f0a05c02f235f.Length * 10);
		stringBuilder.Append("[");
		bool flag = true;
		foreach (float value in x4a3f0a05c02f235f)
		{
			if (!flag)
			{
				stringBuilder.Append(", ");
			}
			else
			{
				flag = false;
			}
			stringBuilder.Append(value);
		}
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}

	public static int x792b6f092cbf4bb1(int[] x9d5750eb2d6373bc, int xc0c4c459c6ccbd00, int x961016a387451f05, int xbcea506a33cf9111)
	{
		int num = xc0c4c459c6ccbd00;
		int num2 = xc0c4c459c6ccbd00 + x961016a387451f05 - 1;
		while (num <= num2)
		{
			int num3 = num + num2 >> 1;
			int num4 = x9d5750eb2d6373bc[num3];
			if (num4 == xbcea506a33cf9111)
			{
				return num3;
			}
			if (num4 < xbcea506a33cf9111)
			{
				num = num3 + 1;
			}
			else
			{
				num2 = num3 - 1;
			}
		}
		return ~num;
	}

	public static int x792b6f092cbf4bb1(byte[] x9d5750eb2d6373bc, int xc0c4c459c6ccbd00, int x961016a387451f05, byte xbcea506a33cf9111)
	{
		int num = xc0c4c459c6ccbd00;
		int num2 = xc0c4c459c6ccbd00 + x961016a387451f05 - 1;
		while (num <= num2)
		{
			int num3 = num + num2 >> 1;
			byte b = x9d5750eb2d6373bc[num3];
			if (b == xbcea506a33cf9111)
			{
				return num3;
			}
			if (b < xbcea506a33cf9111)
			{
				num = num3 + 1;
			}
			else
			{
				num2 = num3 - 1;
			}
		}
		return ~num;
	}

	public static int x792b6f092cbf4bb1(float[] x9d5750eb2d6373bc, int xc0c4c459c6ccbd00, int x961016a387451f05, float xbcea506a33cf9111)
	{
		int num = xc0c4c459c6ccbd00;
		int num2 = xc0c4c459c6ccbd00 + x961016a387451f05 - 1;
		while (num <= num2)
		{
			int num3 = num + num2 >> 1;
			float num4 = x9d5750eb2d6373bc[num3];
			if (num4 == xbcea506a33cf9111)
			{
				return num3;
			}
			if (num4 < xbcea506a33cf9111)
			{
				num = num3 + 1;
			}
			else
			{
				num2 = num3 - 1;
			}
		}
		return ~num;
	}

	public static void xc17d2322bcb00e74(byte[] x9d5750eb2d6373bc, byte xbcea506a33cf9111, int x374ea4fe62468d0f, int x961016a387451f05)
	{
		for (int i = 0; i < x961016a387451f05; i++)
		{
			x9d5750eb2d6373bc[i + x374ea4fe62468d0f] = xbcea506a33cf9111;
		}
	}

	public static bool x5fa70910f253aafa(byte[] xc017801291d6b7c8, byte[] xf01158a578cec3a8, int x961016a387451f05)
	{
		for (int i = 0; i < x961016a387451f05; i++)
		{
			if (xc017801291d6b7c8[i] != xf01158a578cec3a8[i])
			{
				return false;
			}
		}
		return true;
	}

	public static void x7644ed310885068c(char[] xc017801291d6b7c8, char[] xf01158a578cec3a8)
	{
		int num = Math.Min(xc017801291d6b7c8.Length, xf01158a578cec3a8.Length);
		for (int i = 0; i < num; i++)
		{
			if (xc017801291d6b7c8[i] != xf01158a578cec3a8[i])
			{
				throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ojodmmfejmmefldfkmkfogbgbmigjkpgblghhlnhekeipklijfcjhjjjfkakfjhkneokoiflajmlkidmhikmdibnniinnhpndigoginopcepnglpnhcagcjadhabpghbahobdgfclgmcnfddagkdmfbelaieibpenfgfnfnfpaeggblgbdchiajhafaimpginonikpejpdmjpddkcpjkipaldbilkoolcdgmonmmpmdnmnknbccobcjofnpokngpfpnpmmeaebmacmcb", 1523662429)), i, xc017801291d6b7c8[i], xf01158a578cec3a8[i]));
			}
		}
		if (xc017801291d6b7c8.Length != xf01158a578cec3a8.Length)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hgpcfjgdcjndoheedjlehdcfaijfghagmhhgchogmhfhngmhfhdipbkinfbjlgijlfpjdbgkefnkgfelafllnecmjejmdfandehnjeonmefopamocpcpkekpmpaageiagooaecgbocnbbcecknkccdcdfoidocaemnge", 2079403814)), xc017801291d6b7c8.Length, xf01158a578cec3a8.Length));
		}
	}

	public static void x7644ed310885068c(byte[] xc017801291d6b7c8, byte[] xf01158a578cec3a8)
	{
		int num = Math.Min(xc017801291d6b7c8.Length, xf01158a578cec3a8.Length);
		for (int i = 0; i < num; i++)
		{
			if (xc017801291d6b7c8[i] != xf01158a578cec3a8[i])
			{
				throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lnamjaimgapmcpfnhannlkdoopkogobpooipepppbogamonagjebenlbcocccnjckiadlmhdnmodhmfeemmeamdfkmkfklbgamigdmpgmgghkknhkleidglialcjmkjjnkakakhkikokkjflnjmljjdmiekmffbnkjinkjpnmegodfnoogepfelpnicajdjakcabhdhbmhobmhfcpcmcfdddafkdhcbepgielbpemagfjbnfofegoflgcbchhbjhcdaijahibfoippej", 530890906)), i, xc017801291d6b7c8[i], xf01158a578cec3a8[i]));
			}
		}
		if (xc017801291d6b7c8.Length != xf01158a578cec3a8.Length)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hicmfljmclanojhndlonhffoakmogjdpmjkpcjbamjianipafjgbpdnbnheclilclhcdddjdehaeghheahoengffjgmfdhdgdgkgjgbhmgihpcphcbgikgnimbejggljgackeejkoealbehlkpnlcffmfammoednmpjn", 57066054)), xc017801291d6b7c8.Length, xf01158a578cec3a8.Length));
		}
	}

	public static void x7644ed310885068c(short[] xc017801291d6b7c8, short[] xf01158a578cec3a8)
	{
		int num = Math.Min(xc017801291d6b7c8.Length, xf01158a578cec3a8.Length);
		for (int i = 0; i < num; i++)
		{
			if (xc017801291d6b7c8[i] != xf01158a578cec3a8[i])
			{
				throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mcfkkfmkhfdldeklifbmmphmpepmhdgnpdnnfeeocdlondcphoipfcaaddhadcoalnebmbmbobdcibkcfbbdbbidlbpdlagebbneebefnlkflpbglajgelpgbahhnpnhopeibplijpcjlojjooakkohkjjokgkfllomllodmnjkmekbnplingjpnongokinolhepiilpnmcanmjaaiabgihbbkobihfcammcmgddnfkdkgbepkiepkpedggfignfdiegkflgckchafjh", 1990960363)), i, xc017801291d6b7c8[i], xf01158a578cec3a8[i]));
			}
		}
		if (xc017801291d6b7c8.Length != xf01158a578cec3a8.Length)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bmfnpomnmodoinkonobpbjipknppangagnnammebgnlbhmccpmjcjhadhlhdfmodflfengmeokdfalkfkkbghkigdkpgnkghnjnhdkeigklijgcjmejjekakgfhkakokaeflohmliidmlhkmedbnmiinpdpniigogdno", 1681118592)), xc017801291d6b7c8.Length, xf01158a578cec3a8.Length));
		}
	}

	public static void x7644ed310885068c(float[] xc017801291d6b7c8, float[] xf01158a578cec3a8, float xf7845a6fecd5afc3)
	{
		int num = Math.Min(xc017801291d6b7c8.Length, xf01158a578cec3a8.Length);
		for (int i = 0; i < num; i++)
		{
			if (xc017801291d6b7c8[i] - xf01158a578cec3a8[i] > xf7845a6fecd5afc3)
			{
				throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pkoonnfpknmpgmdalnkaphbbcnibklpbcmgcimncfledamldkgceikjeglafgkhfofofpjfgbkmgljdhijkhejbiojiioipiejgjhjnjaeekohlkoiclhdjleiamaihmbiomehfnmhmnogdobhkongbpmbipehppgcgaahnakcebnalbfgccibjcbgadbahdefodoefegamefpcfnekfbabgjeigjoogndghmcnhedeifcliknbjlbjjjbaknbhkccokmaflimllacdmfnjmmbbnkmhn", 2109664878)), i, xc017801291d6b7c8[i], xf01158a578cec3a8[i], xf7845a6fecd5afc3));
			}
		}
		if (xc017801291d6b7c8.Length != xf01158a578cec3a8.Length)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ijlfgmcgdmjgpkahemhhigohblfihkminkdjdkkjnkbkojikgkpkafgloinlmjemmilmeecnfijnhiaobihoohookhfpeimpehdakhkanhbbaeibdcpblhgcncnchhedhbldffcepfjecfaflahfdgofgbfgpfmgnadh", 350378839)), xc017801291d6b7c8.Length, xf01158a578cec3a8.Length));
		}
	}

	public static void x0ae59289b654b6a6(byte[] xc017801291d6b7c8, byte[] xf01158a578cec3a8)
	{
		if (xc017801291d6b7c8.Length != xf01158a578cec3a8.Length)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dcnfbfegoelgkdchpejhdpphmdhicdoiidfjocmjiddkjckkbdbllnhljbplhcgmhbnmpmdnablncbcomajojaapfahppaopppeafamaiadblmjbokacgaiciloccagdckmdaodekokennbfgjifoopfbkggkongijeh", 989748450)), xc017801291d6b7c8.Length, xf01158a578cec3a8.Length));
		}
		for (int i = 0; i < xc017801291d6b7c8.Length; i++)
		{
			_ = xc017801291d6b7c8[i];
			_ = xf01158a578cec3a8[i];
		}
	}

	public static byte[] x85f01d4e0fc99422(byte[] x5c50b8a70ebb7895, int x961016a387451f05)
	{
		byte[] array = new byte[x961016a387451f05];
		if (x961016a387451f05 > x5c50b8a70ebb7895.Length)
		{
			x961016a387451f05 = x5c50b8a70ebb7895.Length;
		}
		Array.Copy(x5c50b8a70ebb7895, array, x961016a387451f05);
		return array;
	}

	public static int[] x25c5f23efe5b47e4(ArrayList x50a18ad2656e7181)
	{
		int[] array = new int[x50a18ad2656e7181.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (int)x50a18ad2656e7181[i];
		}
		return array;
	}

	public static bool x57a8965bf85f0d71(byte[] xa7ea9ccafe3a3efa)
	{
		if (xa7ea9ccafe3a3efa != null)
		{
			return xa7ea9ccafe3a3efa.Length > 0;
		}
		return false;
	}

	public static bool x57a8965bf85f0d71(string[] xfbe56b18f3d6944d)
	{
		if (xfbe56b18f3d6944d != null)
		{
			return xfbe56b18f3d6944d.Length > 0;
		}
		return false;
	}

	public static string xecc24694278df524(string[] xfbe56b18f3d6944d)
	{
		if (!x57a8965bf85f0d71(xfbe56b18f3d6944d))
		{
			return "";
		}
		return string.Join("", xfbe56b18f3d6944d);
	}
}
