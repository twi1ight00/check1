using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace xfc5388ad7dff404f;

internal abstract class xada461b17cdccac0
{
	private const string x1bae673f4cdbb0f9 = "/";

	private const string xa0f82d6bd4f71f33 = "../";

	private readonly x13a141f958daf286 x7f99709808bf10f5 = new x13a141f958daf286("/");

	private readonly xcb90d3e44daeaa9f x4642a7afcf443698 = new xcb90d3e44daeaa9f();

	public xcb90d3e44daeaa9f xd6abb2ab950b4d22 => x4642a7afcf443698;

	public x13a141f958daf286 xadb7000bed559a9a => x7f99709808bf10f5;

	internal void x24be82222767414d()
	{
		foreach (xa2f1c3dcbd86f20a item in (IEnumerable)x4642a7afcf443698)
		{
			if (item.x189167ca3b0a8e0b == "rels")
			{
				string text = item.x759aa16c2016a289.Replace("/_rels", "").Replace(".rels", "");
				if (text == "/")
				{
					x7ac6ba082de428c1(item, x7f99709808bf10f5);
				}
				else
				{
					x7ac6ba082de428c1(item, xd4e2719ccf56f4d7(text).xadb7000bed559a9a);
				}
			}
		}
	}

	private static void x7ac6ba082de428c1(xa2f1c3dcbd86f20a xd7e5673853e47af4, x13a141f958daf286 x8b7997d01a099e87)
	{
		xc1dcd6189d01216e xc1dcd6189d01216e = new xc1dcd6189d01216e(xd7e5673853e47af4.xb8a774e0111d0fbe);
		while (xc1dcd6189d01216e.x152cbadbfa8061b1("Relationships"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc1dcd6189d01216e.xa66385d80d4d296f) != null && xa66385d80d4d296f == "Relationship")
			{
				string xc06e652f250a = null;
				string x061610664b4c984f = null;
				string x7a6cd6daf4195b8a = null;
				bool x1bc1cc5e4fd586bf = false;
				while (xc1dcd6189d01216e.x1ac1960adc8c4c39())
				{
					switch (xc1dcd6189d01216e.xa66385d80d4d296f)
					{
					case "Id":
						xc06e652f250a = xc1dcd6189d01216e.xd2f68ee6f47e9dfb;
						break;
					case "Type":
						x061610664b4c984f = xc1dcd6189d01216e.xd2f68ee6f47e9dfb;
						break;
					case "Target":
						x7a6cd6daf4195b8a = xc1dcd6189d01216e.xd2f68ee6f47e9dfb;
						break;
					case "TargetMode":
						x1bc1cc5e4fd586bf = xc1dcd6189d01216e.xd2f68ee6f47e9dfb == "External";
						break;
					}
				}
				x8b7997d01a099e87.xd6b6ed77479ef68c(xc06e652f250a, x061610664b4c984f, x7a6cd6daf4195b8a, x1bc1cc5e4fd586bf);
			}
			else
			{
				xc1dcd6189d01216e.IgnoreElement();
			}
		}
	}

	public xa2f1c3dcbd86f20a x7bd3b08f3e0470ca(string xc15bd84e01929885)
	{
		return x4642a7afcf443698.get_xe6d4b1b411ed94b5(xc15bd84e01929885);
	}

	public xa2f1c3dcbd86f20a xd4e2719ccf56f4d7(string xc15bd84e01929885)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a2 = x7bd3b08f3e0470ca(xc15bd84e01929885);
		if (xa2f1c3dcbd86f20a2 == null)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ifjodhapnhhpkhopihfakhmadcdbggkbggbcigiclfpcebgdbgndpeeenflemfcffajfjaagkfhgmaoggffhnplhbadi", 1708452117)), xc15bd84e01929885));
		}
		return xa2f1c3dcbd86f20a2;
	}

	public xa2f1c3dcbd86f20a x4bfdbcbc6a51d705(xa2f1c3dcbd86f20a x660bfbc29977d3c8, string x061610664b4c984f)
	{
		x13a141f958daf286 x13a141f958daf287;
		string x3705fee1ea1193c;
		if (x660bfbc29977d3c8 == null)
		{
			x13a141f958daf287 = x7f99709808bf10f5;
			x3705fee1ea1193c = "/";
		}
		else
		{
			x13a141f958daf287 = x660bfbc29977d3c8.xadb7000bed559a9a;
			x3705fee1ea1193c = x660bfbc29977d3c8.x759aa16c2016a289;
		}
		x5b6f1954712b741f x5b6f1954712b741f2 = x13a141f958daf287.x6bd3b5840d6ee24a(x061610664b4c984f);
		if (x5b6f1954712b741f2 != null)
		{
			return xd4e2719ccf56f4d7(x653bf8787d72d626(x3705fee1ea1193c, x5b6f1954712b741f2.x42f4c234c9358072));
		}
		return null;
	}

	public xa2f1c3dcbd86f20a xe55f59c79966b924(xa2f1c3dcbd86f20a x660bfbc29977d3c8, string x061610664b4c984f)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a2 = x4bfdbcbc6a51d705(x660bfbc29977d3c8, x061610664b4c984f);
		if (xa2f1c3dcbd86f20a2 == null)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("eihepjoejkffgkmfekdggkkgpebhcjihcjphejgihiniaeejbjljlhckjijklhalghhlciollcfmhhmmlgdnccknbhbobgiofgpohfgphgnpjfeamflaifcbkfjbmeackehcoeoclpedppldafdecakemebfdphf", 1239435073)), x061610664b4c984f));
		}
		return xa2f1c3dcbd86f20a2;
	}

	public xa2f1c3dcbd86f20a x42c5f80e2ed823ff(xa2f1c3dcbd86f20a x660bfbc29977d3c8, string x95fb8866691eb6f7, string xe1d3286d17e44a37, string x061610664b4c984f)
	{
		string xc06e652f250a;
		return x42c5f80e2ed823ff(x660bfbc29977d3c8, x95fb8866691eb6f7, xe1d3286d17e44a37, x061610664b4c984f, out xc06e652f250a);
	}

	public xa2f1c3dcbd86f20a x42c5f80e2ed823ff(xa2f1c3dcbd86f20a x660bfbc29977d3c8, string x95fb8866691eb6f7, string xe1d3286d17e44a37, string x061610664b4c984f, out string xc06e652f250a3786)
	{
		if (x660bfbc29977d3c8 != null)
		{
			x95fb8866691eb6f7 = x653bf8787d72d626(x660bfbc29977d3c8.x759aa16c2016a289, x95fb8866691eb6f7);
		}
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a2 = new xa2f1c3dcbd86f20a(x95fb8866691eb6f7, xe1d3286d17e44a37);
		x4642a7afcf443698.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a2);
		x13a141f958daf286 x13a141f958daf287 = ((x660bfbc29977d3c8 != null) ? x660bfbc29977d3c8.xadb7000bed559a9a : x7f99709808bf10f5);
		xc06e652f250a3786 = x13a141f958daf287.xd6b6ed77479ef68c(x061610664b4c984f, xa2f1c3dcbd86f20a2.x759aa16c2016a289, x1bc1cc5e4fd586bf: false);
		return xa2f1c3dcbd86f20a2;
	}

	[JavaThrows(true)]
	public virtual void Save(Stream stream)
	{
	}

	public static string x4063f4f83c7a7157(string x3705fee1ea1193c4, string x52974b18dcc6b762)
	{
		if (!x52974b18dcc6b762.StartsWith("/"))
		{
			return x52974b18dcc6b762;
		}
		int num = 0;
		int num2 = Math.Min(x3705fee1ea1193c4.Length, x52974b18dcc6b762.Length);
		for (int i = 0; i < num2; i++)
		{
			if (x3705fee1ea1193c4[i] == '/')
			{
				num = i;
			}
			if (x3705fee1ea1193c4[i] != x52974b18dcc6b762[i])
			{
				break;
			}
		}
		int num3 = num + 1;
		StringBuilder stringBuilder = new StringBuilder();
		for (int j = num3; j < x3705fee1ea1193c4.Length; j++)
		{
			if (x3705fee1ea1193c4[j] == '/')
			{
				stringBuilder.Append("../");
			}
		}
		stringBuilder.Append(x52974b18dcc6b762, num3, x52974b18dcc6b762.Length - num3);
		return stringBuilder.ToString();
	}

	public static string x653bf8787d72d626(string x3705fee1ea1193c4, string x52974b18dcc6b762)
	{
		if (x52974b18dcc6b762.StartsWith("/"))
		{
			return x52974b18dcc6b762;
		}
		if (x0d299f323d241756.x90637a473b1ceaaa(x52974b18dcc6b762, "NULL"))
		{
			return "";
		}
		string text = x10ac43e129fae41d(x3705fee1ea1193c4);
		int num = 0;
		while (true)
		{
			int num2 = x52974b18dcc6b762.IndexOf("../", num);
			if (num2 < num)
			{
				break;
			}
			if (num2 > num)
			{
				text += x52974b18dcc6b762.Substring(num, num2 - num);
			}
			text = x10ac43e129fae41d(text);
			num = num2 + "../".Length;
		}
		return text + x52974b18dcc6b762.Substring(num, x52974b18dcc6b762.Length - num);
	}

	private static string x10ac43e129fae41d(string xe4115acdf4fbfccc)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xe4115acdf4fbfccc))
		{
			return xe4115acdf4fbfccc;
		}
		if (xe4115acdf4fbfccc == "/")
		{
			return xe4115acdf4fbfccc;
		}
		int num = xe4115acdf4fbfccc.Length - 1;
		for (int num2 = num; num2 >= 0; num2--)
		{
			if (xe4115acdf4fbfccc[num2] == '/' && num2 < num)
			{
				return xe4115acdf4fbfccc.Substring(0, num2 + 1);
			}
		}
		return "";
	}
}
