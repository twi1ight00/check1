using Aspose.Words;
using Aspose.Words.Math;
using x28925c9b27b37a46;
using x55b2bd426d41d30c;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;
using xe5b37aee2c2a4d4e;

namespace xfce5b6a304778b89;

internal class x2eb18b9edfaafee3
{
	private readonly xf871da68decec406 x7450cc1e48712286;

	private readonly x536e1b48249b1390 x8d9d1dd65146a572;

	private bool x755eb6831e7756ee;

	internal x2eb18b9edfaafee3(xf871da68decec406 reader)
	{
		x7450cc1e48712286 = reader;
		string xc15bd84e = string.Format("/{0}/{1}", xcd9013d8375a4e5b(), "content.xml");
		x0ca5e8b532953a51 x0ca5e8b532953a = reader.x39c7aeeec1af9dd0.x5621ebad67e4df79(xc15bd84e);
		if (x0ca5e8b532953a != null)
		{
			x8d9d1dd65146a572 = new x536e1b48249b1390(x0ca5e8b532953a.xb8a774e0111d0fbe);
		}
	}

	internal void x06b0e25aa6ad68a9(CompositeNode x8b2c3c076d5a7daf)
	{
		if (x8d9d1dd65146a572 != null)
		{
			xb82db57726981c32(x8b2c3c076d5a7daf);
		}
	}

	internal void xb82db57726981c32(CompositeNode x8b2c3c076d5a7daf)
	{
		if (x8d9d1dd65146a572 != null)
		{
			OfficeMath officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xb19ef215dab9ccd8());
			x755eb6831e7756ee = false;
			xd4c8039eabfdc68b(officeMath, "math");
			if (x755eb6831e7756ee)
			{
				OfficeMath officeMath2 = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new x25cf79997767c318());
				officeMath2.AppendChild(officeMath);
				x8b2c3c076d5a7daf.AppendChild(officeMath2);
			}
		}
	}

	private void xd4c8039eabfdc68b(OfficeMath x0262d73a7c29c28c, string x9929b6e6e29df711)
	{
		int x950ce1a20fc7ea = 0;
		xf47bac63068c8fd6 xc04bef193f17b6b = xf47bac63068c8fd6.x236cb0a4295bc034;
		while (x8d9d1dd65146a572.x152cbadbfa8061b1(x9929b6e6e29df711))
		{
			if (x9929b6e6e29df711 == "math")
			{
				x755eb6831e7756ee = true;
			}
			string xa66385d80d4d296f = x8d9d1dd65146a572.xa66385d80d4d296f;
			OfficeMath officeMath;
			switch (xa66385d80d4d296f)
			{
			case "semantics":
				xd4c8039eabfdc68b(x0262d73a7c29c28c, x9929b6e6e29df711);
				return;
			case "mfenced":
				officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new x8f75f1da124d37a8());
				x56b41b187d0eb695(officeMath);
				break;
			case "mfrac":
				officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new x77c73b53c376655e());
				xb7d70583be43271a(officeMath);
				break;
			case "msup":
				officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new x0f6a978b568fff5b());
				break;
			case "msub":
				xc04bef193f17b6b = xf47bac63068c8fd6.x44da4836b2a87e96;
				officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xa57d244669b77e3f());
				break;
			case "msubsup":
			case "munderover":
				xc04bef193f17b6b = ((!(xa66385d80d4d296f == "msubsup")) ? xf47bac63068c8fd6.x8e321c5b5aaa4dd5 : xf47bac63068c8fd6.x44da4836b2a87e96);
				officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xfd62ce7f2b6769d5());
				break;
			case "mmultiscripts":
				officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xd909b0707303c682());
				break;
			case "mroot":
				officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new x099cae110a815841());
				break;
			case "msqrt":
				officeMath = x8e5ce3886250a172();
				break;
			case "mtable":
				officeMath = xed7d554f6c638fb0();
				break;
			case "mtr":
				officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xb7914f4847d72942());
				break;
			case "mtd":
				officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xb4dde217cd172a7b(x3e68720d12325f49.x1745ba6c6d5efbc4));
				break;
			case "menclose":
				officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xfef3245bedba6f2c());
				break;
			case "munder":
			case "mover":
				officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, x70e0e93d77d79dba(xa66385d80d4d296f));
				break;
			case "mpadded":
				officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new x2a5175731d41f1b1());
				x173b7f8a01f705c4(officeMath);
				break;
			case "mrow":
				officeMath = xd9c6f1ce6ced5eb4(x0262d73a7c29c28c, x9929b6e6e29df711, x950ce1a20fc7ea++, xc04bef193f17b6b);
				xc04bef193f17b6b = xf47bac63068c8fd6.x236cb0a4295bc034;
				break;
			case "mi":
			case "mo":
			case "mn":
				x950ce1a20fc7ea = x2eb2e67b24bbea58(x0262d73a7c29c28c, x9929b6e6e29df711, x950ce1a20fc7ea);
				continue;
			default:
				x8d9d1dd65146a572.IgnoreElement();
				continue;
			}
			if (officeMath != null)
			{
				xd4c8039eabfdc68b(officeMath, xa66385d80d4d296f);
				x950ce1a20fc7ea = x59698ea0da3dd07b(x0262d73a7c29c28c, x9929b6e6e29df711, officeMath, xa66385d80d4d296f, x950ce1a20fc7ea);
			}
		}
	}

	private int x59698ea0da3dd07b(OfficeMath x0262d73a7c29c28c, string x9929b6e6e29df711, Node xb99e63b0fcf75db4, string x4e73fff1f4555b34, int x950ce1a20fc7ea38)
	{
		OfficeMath x6bcd0c8d7a2666a = x0262d73a7c29c28c.LastChild as OfficeMath;
		if (x4e73fff1f4555b34 != "mrow" && x4e73fff1f4555b34 != "mtr" && x4e73fff1f4555b34 != "mtd" && !(x0262d73a7c29c28c.x52642f91ccdeeb35 is xb4dde217cd172a7b) && (x0262d73a7c29c28c.x52642f91ccdeeb35.xcbe541d3325b8546 || x374f9c999080f125(xb99e63b0fcf75db4, x6bcd0c8d7a2666a)))
		{
			OfficeMath officeMath;
			if (x79fe7bb3f86840bf(x0262d73a7c29c28c.x52642f91ccdeeb35.x3e68720d12325f49, x6bcd0c8d7a2666a) && x950ce1a20fc7ea38 >= xb5f27fcdc8f03a62(x9929b6e6e29df711))
			{
				officeMath = (OfficeMath)x0262d73a7c29c28c.LastChild;
			}
			else
			{
				officeMath = xaa51305c793fea43(x0262d73a7c29c28c, x950ce1a20fc7ea38++);
				x0262d73a7c29c28c.AppendChild(officeMath);
			}
			officeMath.AppendChild(xb99e63b0fcf75db4);
		}
		else
		{
			string text = xb99e63b0fcf75db4.GetText();
			if (x3b59c026b8fcd138(x0262d73a7c29c28c, x9929b6e6e29df711, text))
			{
				x0262d73a7c29c28c.x52642f91ccdeeb35.xae20093bed1e48a8(15280, text[0]);
				return ++x950ce1a20fc7ea38;
			}
			x0262d73a7c29c28c.AppendChild(xb99e63b0fcf75db4);
		}
		return x950ce1a20fc7ea38;
	}

	private static bool x3b59c026b8fcd138(OfficeMath x0262d73a7c29c28c, string x9929b6e6e29df711, string xbcea506a33cf9111)
	{
		if ((x9929b6e6e29df711 == "munder" || x9929b6e6e29df711 == "mover") && x0262d73a7c29c28c.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x2709f18576762ece && xbcea506a33cf9111.Length == 1)
		{
			return x0262d73a7c29c28c.ChildNodes.Count == 1;
		}
		return false;
	}

	private static bool x374f9c999080f125(Node xb99e63b0fcf75db4, OfficeMath x6bcd0c8d7a2666a1)
	{
		OfficeMath officeMath = xb99e63b0fcf75db4 as OfficeMath;
		if (x6bcd0c8d7a2666a1 != null && x6bcd0c8d7a2666a1.ChildNodes.Count == 1 && x6bcd0c8d7a2666a1.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x3e270ab1f00c767a)
		{
			if (!(xb99e63b0fcf75db4 is Run))
			{
				if (officeMath != null)
				{
					return officeMath.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x1745ba6c6d5efbc4;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private static bool x79fe7bb3f86840bf(x3e68720d12325f49 x6d16067117fc8508, OfficeMath x6bcd0c8d7a2666a1)
	{
		if (x6bcd0c8d7a2666a1 != null)
		{
			if (x6d16067117fc8508 != x3e68720d12325f49.x82ca8304b1b498f4 && x6d16067117fc8508 != x3e68720d12325f49.x78451b450fb7d099 && x6d16067117fc8508 != x3e68720d12325f49.x1b1f4712a1a0c38c && x6d16067117fc8508 != x3e68720d12325f49.xe8789867140a072a && x6d16067117fc8508 != x3e68720d12325f49.xf2da195ae719a2a1)
			{
				if (x6d16067117fc8508 == x3e68720d12325f49.xdb2ade053c60340d && x6bcd0c8d7a2666a1.x52642f91ccdeeb35 is xb4dde217cd172a7b)
				{
					return x6bcd0c8d7a2666a1.x52642f91ccdeeb35.x3e68720d12325f49 != x3e68720d12325f49.x2b691ff28e877ea4;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private OfficeMath xed7d554f6c638fb0()
	{
		xa097a2be55e6fe20 xa097a2be55e6fe = new xa097a2be55e6fe20();
		xa097a2be55e6fe.x1cf0124cf79a79b8 = true;
		return new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, xa097a2be55e6fe);
	}

	private OfficeMath x8e5ce3886250a172()
	{
		OfficeMath officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new x099cae110a815841());
		OfficeMath newChild = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xb4dde217cd172a7b(x3e68720d12325f49.x2b691ff28e877ea4));
		officeMath.x52642f91ccdeeb35.xae20093bed1e48a8(15540, true);
		officeMath.AppendChild(newChild);
		return officeMath;
	}

	private static int xb5f27fcdc8f03a62(string x3db7f23de97e3c68)
	{
		switch (x3db7f23de97e3c68)
		{
		case "mfenced":
		case "mfrac":
		case "msup":
		case "msub":
		case "msubsup":
		case "mmultiscripts":
		case "mroot":
			return 2;
		case "mpadded":
		case "msqrt":
			return 1;
		default:
			return 0;
		}
	}

	private int x2eb2e67b24bbea58(OfficeMath x0262d73a7c29c28c, string x9929b6e6e29df711, int x950ce1a20fc7ea38)
	{
		string text = x8d9d1dd65146a572.x2a1ea9d24e62bf84();
		if (text.Length == 1 && (x9929b6e6e29df711 == "mover" || x9929b6e6e29df711 == "munder"))
		{
			if (x0262d73a7c29c28c.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x9b63794dfed849a8)
			{
				x0262d73a7c29c28c.x52642f91ccdeeb35.xae20093bed1e48a8(15040, text[0]);
				return ++x950ce1a20fc7ea38;
			}
			if (x0262d73a7c29c28c.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x2709f18576762ece)
			{
				x0262d73a7c29c28c.x52642f91ccdeeb35.xae20093bed1e48a8(15280, text[0]);
				return ++x950ce1a20fc7ea38;
			}
		}
		x950ce1a20fc7ea38 = x59698ea0da3dd07b(x0262d73a7c29c28c, x9929b6e6e29df711, x39a4da4b276627ce(text), x8d9d1dd65146a572.xa66385d80d4d296f, x950ce1a20fc7ea38);
		return x950ce1a20fc7ea38;
	}

	private Run x39a4da4b276627ce(string xb41faee6912a2313)
	{
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		xeedad81aaed42a.x759aa16c2016a289 = "Cambria Math";
		return new Run(x7450cc1e48712286.x2c8c6741422a1298, xb41faee6912a2313, xeedad81aaed42a);
	}

	private OfficeMath xaa51305c793fea43(OfficeMath x0262d73a7c29c28c, int x950ce1a20fc7ea38)
	{
		x3e68720d12325f49 type = x3e68720d12325f49.x1745ba6c6d5efbc4;
		switch (x0262d73a7c29c28c.x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.x71c5078172d72420:
			type = ((x950ce1a20fc7ea38 == 0) ? x3e68720d12325f49.x5ec114ef0df8072b : x3e68720d12325f49.x194cb0ccf5358fec);
			break;
		case x3e68720d12325f49.x1b1f4712a1a0c38c:
			if (x950ce1a20fc7ea38 == 1)
			{
				type = x3e68720d12325f49.x06b102f48629e32f;
			}
			break;
		case x3e68720d12325f49.xe8789867140a072a:
			if (x950ce1a20fc7ea38 == 1)
			{
				type = x3e68720d12325f49.x16984029356c96b7;
			}
			break;
		case x3e68720d12325f49.x398384f7454300c1:
		case x3e68720d12325f49.xf2da195ae719a2a1:
			if (x950ce1a20fc7ea38 == 1)
			{
				type = x3e68720d12325f49.x06b102f48629e32f;
			}
			if (x950ce1a20fc7ea38 == 2)
			{
				type = x3e68720d12325f49.x16984029356c96b7;
			}
			break;
		case x3e68720d12325f49.xdb2ade053c60340d:
			if (x950ce1a20fc7ea38 == 1)
			{
				type = x3e68720d12325f49.x2b691ff28e877ea4;
			}
			break;
		case x3e68720d12325f49.x9c1074dced8b2f2e:
			if (x950ce1a20fc7ea38 == 1)
			{
				type = x3e68720d12325f49.x25d26846c330b189;
			}
			break;
		case x3e68720d12325f49.x5a25e9abda6210c5:
			if (x950ce1a20fc7ea38 == 1)
			{
				type = x3e68720d12325f49.x25d26846c330b189;
			}
			break;
		case x3e68720d12325f49.x30727a59b1643735:
			return new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xb7914f4847d72942());
		}
		return new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xb4dde217cd172a7b(type));
	}

	private OfficeMath xd9c6f1ce6ced5eb4(OfficeMath x0262d73a7c29c28c, string x9929b6e6e29df711, int x950ce1a20fc7ea38, xf47bac63068c8fd6 xc04bef193f17b6b3)
	{
		x3e68720d12325f49 type = x3e68720d12325f49.x1745ba6c6d5efbc4;
		switch (x0262d73a7c29c28c.x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.x71c5078172d72420:
			type = ((x950ce1a20fc7ea38 == 0) ? x3e68720d12325f49.x5ec114ef0df8072b : x3e68720d12325f49.x194cb0ccf5358fec);
			break;
		case x3e68720d12325f49.x1b1f4712a1a0c38c:
			if (x950ce1a20fc7ea38 == 1)
			{
				type = x3e68720d12325f49.x06b102f48629e32f;
			}
			break;
		case x3e68720d12325f49.xe8789867140a072a:
			if (x950ce1a20fc7ea38 == 1)
			{
				type = x3e68720d12325f49.x16984029356c96b7;
			}
			break;
		case x3e68720d12325f49.x398384f7454300c1:
		case x3e68720d12325f49.xf2da195ae719a2a1:
			if (x950ce1a20fc7ea38 == 1)
			{
				type = x3e68720d12325f49.x06b102f48629e32f;
			}
			if (x950ce1a20fc7ea38 == 2)
			{
				type = x3e68720d12325f49.x16984029356c96b7;
			}
			break;
		case x3e68720d12325f49.xdb2ade053c60340d:
			if (x950ce1a20fc7ea38 == 1)
			{
				type = x3e68720d12325f49.x2b691ff28e877ea4;
			}
			break;
		case x3e68720d12325f49.x3e270ab1f00c767a:
			if (x950ce1a20fc7ea38 == 0)
			{
				type = x3e68720d12325f49.x8c55fc884c93cb9f;
			}
			break;
		case x3e68720d12325f49.x5a25e9abda6210c5:
			if (x950ce1a20fc7ea38 == 1)
			{
				type = x3e68720d12325f49.x25d26846c330b189;
			}
			break;
		case x3e68720d12325f49.x9c1074dced8b2f2e:
			if (x950ce1a20fc7ea38 == 1)
			{
				type = x3e68720d12325f49.x25d26846c330b189;
			}
			break;
		case x3e68720d12325f49.x2709f18576762ece:
			if (x950ce1a20fc7ea38 == 0 && x9929b6e6e29df711 == "munder")
			{
				x0262d73a7c29c28c.x52642f91ccdeeb35.x52b190e626f65140(15290);
				x0262d73a7c29c28c.x52642f91ccdeeb35.x52b190e626f65140(15300);
			}
			if (x950ce1a20fc7ea38 == 1)
			{
				if (x9929b6e6e29df711 == "munder")
				{
					x0262d73a7c29c28c.x52642f91ccdeeb35.x52b190e626f65140(15300);
				}
				if (x9929b6e6e29df711 == "mover")
				{
					x0262d73a7c29c28c.x52642f91ccdeeb35.x52b190e626f65140(15290);
				}
			}
			break;
		default:
			if (xa3d386e260f16e67(x0262d73a7c29c28c, xc04bef193f17b6b3))
			{
				return null;
			}
			xd4c8039eabfdc68b(x0262d73a7c29c28c, "mrow");
			x770edc2a139c2756(x0262d73a7c29c28c);
			return null;
		case x3e68720d12325f49.x0dbbcf3105452f20:
			break;
		}
		return new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xb4dde217cd172a7b(type));
	}

	private void x770edc2a139c2756(OfficeMath x0262d73a7c29c28c)
	{
		int num = x2dc0ac9faab02ce3(x0262d73a7c29c28c);
		if (num >= 0)
		{
			OfficeMath newChild = x0b9a9af616425fee(x0262d73a7c29c28c, num);
			xcd3fb8c526c3341b(x0262d73a7c29c28c, num);
			x0262d73a7c29c28c.AppendChild(newChild);
		}
	}

	private OfficeMath x0b9a9af616425fee(OfficeMath x0262d73a7c29c28c, int xaf3d69935370e37f)
	{
		OfficeMath officeMath = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new x11ccc6fd9c50b5e4());
		OfficeMath officeMath2 = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xb4dde217cd172a7b(x3e68720d12325f49.x8c55fc884c93cb9f));
		OfficeMath officeMath3 = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xb4dde217cd172a7b(x3e68720d12325f49.x1745ba6c6d5efbc4));
		officeMath.AppendChild(officeMath2);
		officeMath.AppendChild(officeMath3);
		bool flag = false;
		for (int i = xaf3d69935370e37f - 1; i < x0262d73a7c29c28c.ChildNodes.Count; i++)
		{
			Node node = x0262d73a7c29c28c.ChildNodes[i];
			string text = node.GetText();
			if (text.Length == 1 && text[0] == '\u2061')
			{
				flag = true;
			}
			else if (!flag)
			{
				officeMath2.AppendChild(node.Clone(isCloneChildren: true));
			}
			else
			{
				officeMath3.AppendChild(node.Clone(isCloneChildren: true));
			}
		}
		return officeMath;
	}

	private static void xcd3fb8c526c3341b(OfficeMath x0262d73a7c29c28c, int xaf3d69935370e37f)
	{
		for (int num = x0262d73a7c29c28c.ChildNodes.Count - 1; num >= xaf3d69935370e37f - 1; num--)
		{
			x0262d73a7c29c28c.ChildNodes.RemoveAt(num);
		}
	}

	private static int x2dc0ac9faab02ce3(OfficeMath x0262d73a7c29c28c)
	{
		for (int i = 0; i < x0262d73a7c29c28c.ChildNodes.Count; i++)
		{
			string text = x0262d73a7c29c28c.ChildNodes[i].GetText();
			if (text.Length == 1 && text[0] == '\u2061')
			{
				return i;
			}
		}
		return -1;
	}

	private bool xa3d386e260f16e67(OfficeMath x0262d73a7c29c28c, xf47bac63068c8fd6 xc04bef193f17b6b3)
	{
		if (x0262d73a7c29c28c.LastChild == null || !(x0262d73a7c29c28c.LastChild is OfficeMath))
		{
			return false;
		}
		OfficeMath officeMath = x0262d73a7c29c28c.LastChild as OfficeMath;
		bool flag = officeMath.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.xf2da195ae719a2a1 && officeMath.ChildNodes.Count == 3;
		bool flag2 = (officeMath.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x9c1074dced8b2f2e || officeMath.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x5a25e9abda6210c5 || officeMath.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x1b1f4712a1a0c38c) && officeMath.ChildNodes.Count == 2;
		if (!flag && !flag2)
		{
			return false;
		}
		OfficeMath officeMath2 = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new x6dd1552d6eb89e4e());
		x0262d73a7c29c28c.AppendChild(officeMath2);
		string text = officeMath.ChildNodes[0].GetText();
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			officeMath2.x52642f91ccdeeb35.xae20093bed1e48a8(15045, text[0]);
		}
		officeMath2.x52642f91ccdeeb35.xae20093bed1e48a8(15510, xc04bef193f17b6b3);
		if (flag)
		{
			officeMath2.AppendChild(officeMath.ChildNodes[1].Clone(isCloneChildren: true));
			officeMath2.AppendChild(officeMath.ChildNodes[2].Clone(isCloneChildren: true));
		}
		else
		{
			officeMath2.x52642f91ccdeeb35.xae20093bed1e48a8(15530, true);
			OfficeMath officeMath3 = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xb4dde217cd172a7b(x3e68720d12325f49.x06b102f48629e32f));
			foreach (Node childNode in ((CompositeNode)officeMath.ChildNodes[1]).ChildNodes)
			{
				officeMath3.AppendChild(childNode.Clone(isCloneChildren: true));
			}
			officeMath2.AppendChild(officeMath3);
		}
		officeMath.Remove();
		OfficeMath officeMath4 = new OfficeMath(x7450cc1e48712286.x2c8c6741422a1298, new xb4dde217cd172a7b(x3e68720d12325f49.x1745ba6c6d5efbc4));
		xd4c8039eabfdc68b(officeMath4, "mrow");
		officeMath2.AppendChild(officeMath4);
		return true;
	}

	private x52642f91ccdeeb35 x70e0e93d77d79dba(string x121383aa64985888)
	{
		while (x8d9d1dd65146a572.x1ac1960adc8c4c39())
		{
			if (x8d9d1dd65146a572.xa66385d80d4d296f == "accentunder" || x8d9d1dd65146a572.xa66385d80d4d296f == "accent")
			{
				if (x8d9d1dd65146a572.xd2f68ee6f47e9dfb == "false")
				{
					x52642f91ccdeeb35 x52642f91ccdeeb = new xe0ab87872ac16292();
					x52642f91ccdeeb.xae20093bed1e48a8(15290, xce8b2ce767b2485c.xe360b1885d8d4a41);
					x52642f91ccdeeb.xae20093bed1e48a8(15300, x63bdb8b878b040d9.x9bcb07e204e30218);
					return x52642f91ccdeeb;
				}
				if (x121383aa64985888 == "mover")
				{
					return new x38058b386e92a0ef();
				}
			}
		}
		if (x121383aa64985888 == "munder")
		{
			return new x359908170766b2c1();
		}
		return new x8ca605f254677e14();
	}

	private void xb7d70583be43271a(OfficeMath x6e17fd1ed1b2b8d8)
	{
		while (x8d9d1dd65146a572.x1ac1960adc8c4c39())
		{
			switch (x8d9d1dd65146a572.xa66385d80d4d296f)
			{
			case "linethickness":
				if (xbb857c9fc36f5054.xc93d98c550d1261e(x8d9d1dd65146a572.xd2f68ee6f47e9dfb) == 0.0)
				{
					x6e17fd1ed1b2b8d8.x52642f91ccdeeb35.xae20093bed1e48a8(15460, x890a027c82a36a95.xa1886b914486c170);
				}
				break;
			case "bevelled":
				if (x8d9d1dd65146a572.xd2f68ee6f47e9dfb == "true")
				{
					x6e17fd1ed1b2b8d8.x52642f91ccdeeb35.xae20093bed1e48a8(15460, x890a027c82a36a95.x7ccdf8314e1f1193);
				}
				break;
			}
		}
	}

	private void x173b7f8a01f705c4(OfficeMath x9c744cfd18267b8f)
	{
		while (x8d9d1dd65146a572.x1ac1960adc8c4c39())
		{
			bool flag = x8d9d1dd65146a572.xd2f68ee6f47e9dfb.Length == 3 && x8d9d1dd65146a572.xd2f68ee6f47e9dfb[0] == '0';
			switch (x8d9d1dd65146a572.xa66385d80d4d296f)
			{
			case "width":
				x9c744cfd18267b8f.x52642f91ccdeeb35.xae20093bed1e48a8(15450, flag);
				break;
			case "height":
				x9c744cfd18267b8f.x52642f91ccdeeb35.xae20093bed1e48a8(15330, flag);
				break;
			case "depth":
				x9c744cfd18267b8f.x52642f91ccdeeb35.xae20093bed1e48a8(15340, flag);
				break;
			}
		}
	}

	private void x56b41b187d0eb695(OfficeMath x4c3e8680a15658ef)
	{
		while (x8d9d1dd65146a572.x1ac1960adc8c4c39())
		{
			switch (x8d9d1dd65146a572.xa66385d80d4d296f)
			{
			case "open":
				x859e843d7c01a905(x4c3e8680a15658ef, 15180);
				break;
			case "close":
				x859e843d7c01a905(x4c3e8680a15658ef, 15190);
				break;
			case "separators":
				x859e843d7c01a905(x4c3e8680a15658ef, 15200);
				break;
			}
		}
	}

	private void x859e843d7c01a905(OfficeMath xa01cdd85e8d9e6dc, int xbc000261ea78016e)
	{
		if (x8d9d1dd65146a572.xd2f68ee6f47e9dfb.Length == 1)
		{
			xa01cdd85e8d9e6dc.x52642f91ccdeeb35.xae20093bed1e48a8(xbc000261ea78016e, x8d9d1dd65146a572.xd2f68ee6f47e9dfb[0]);
		}
		if (x8d9d1dd65146a572.xd2f68ee6f47e9dfb == "")
		{
			xa01cdd85e8d9e6dc.x52642f91ccdeeb35.xae20093bed1e48a8(xbc000261ea78016e, '\0');
		}
	}

	private string xcd9013d8375a4e5b()
	{
		x536e1b48249b1390 xca994afbcb9073a = x7450cc1e48712286.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (xca994afbcb9073a.xa66385d80d4d296f == "href")
			{
				return xca994afbcb9073a.xd2f68ee6f47e9dfb.Replace("ObjectReplacements/", "").Replace("./", "").Trim('/');
			}
		}
		return null;
	}
}
