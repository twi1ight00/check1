using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ns171;
using ns173;
using ns175;
using ns181;
using ns184;
using ns224;
using ns235;

namespace ns201;

internal class Class5363 : Class5362
{
	private const float float_0 = 10f;

	private const float float_1 = 10f;

	private Class6205 class6205_0;

	private Enum679 enum679_0 = Enum679.const_40;

	public Class5363(Class5738 userAgent, ArrayList apsPages, bool splitPages)
		: base(userAgent, apsPages, splitPages)
	{
	}

	public override string imethod_0()
	{
		return "application/X-fop-ex-aps";
	}

	private PointF method_52()
	{
		return new PointF((float)int_0 / 1000f, (float)class5358_0.Value / 1000f);
	}

	private static SizeF smethod_9(Class4944 ip)
	{
		return new SizeF((float)(int)ip.method_33(Class5757.int_41) / 1000f, (float)(int)ip.method_33(Class5757.int_42) / 1000f);
	}

	private Class5999 method_53(Class4944 ip)
	{
		if (ip.method_34(Class5757.int_2))
		{
			Class5732 @class = (Class5732)ip.method_33(Class5757.int_2);
			int fontSize = (int)ip.method_33(Class5757.int_3);
			Class5729 font = class5730_0.method_12(@class, fontSize, @class.method_4());
			return method_47(font);
		}
		return null;
	}

	private void method_54(Enum679 type, PointF location, SizeF size, Class5999 font, string id, float centerY)
	{
		enum679_0 = type;
		location = new PointF(location.X, centerY - size.Height / 2f);
		switch (type)
		{
		case Enum679.const_294:
		{
			Class6210 class5 = new Class6210(location, id, size, isRichText: false);
			class5.DefaultFont = font;
			class6205_0 = class5;
			break;
		}
		case Enum679.const_295:
		{
			Class6207 class4 = new Class6207(location, id, 10f);
			class6205_0 = class4;
			break;
		}
		case Enum679.const_296:
		{
			Class6208 class3 = new Class6208(location, id, 10f);
			class6205_0 = class3;
			break;
		}
		case Enum679.const_297:
		{
			Class6209 class2 = new Class6209(location, id, new List<string>(), 1);
			class2.DefaultFont = font;
			class2.Size = size;
			class6205_0 = class2;
			break;
		}
		case Enum679.const_299:
		{
			Class6206 @class = new Class6206(location, id, size);
			class6205_0 = @class;
			break;
		}
		case Enum679.const_40:
			class6205_0 = null;
			break;
		}
		if (class6205_0 != null)
		{
			base.CurrentCanvas.Add(class6205_0);
		}
	}

	private static string smethod_10(ArrayList inlines)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Class4943 inline in inlines)
		{
			if (inline is Class4948 class2)
			{
				stringBuilder.Append(class2.vmethod_10());
				break;
			}
		}
		return stringBuilder.ToString();
	}

	private static bool smethod_11(Class4944 ip)
	{
		if (ip.method_34(Class5757.int_44))
		{
			return (Enum679)ip.method_33(Class5757.int_44) == Enum679.const_236;
		}
		return false;
	}

	protected override void vmethod_22(Class4944 ip)
	{
		string text = method_33(ip);
		float num = 0f;
		RectangleF rect = new RectangleF((float)int_0 / 1000f, (float)class5358_0.Value / 1000f, (float)ip.method_12() / 1000f, (float)ip.vmethod_1() / 1000f);
		Class6002 @class = new Class6002();
		@class.method_8(0f, (float)ip.method_42() / 1000f);
		rect = @class.method_4(rect);
		num = rect.Top + rect.Height / 2f;
		method_29(text, rect);
		try
		{
			if (ip.method_34(Class5757.int_39))
			{
				Enum679 @enum = (Enum679)(int)ip.method_33(Class5757.int_39);
				switch (@enum)
				{
				case Enum679.const_40:
					class6205_0 = null;
					enum679_0 = @enum;
					break;
				default:
					if (class6205_0 == null || !(class6205_0.Id == text))
					{
						method_54(@enum, method_52(), smethod_9(ip), method_53(ip), method_33(ip), num);
						class6205_0.Id = text;
					}
					break;
				case Enum679.const_301:
					break;
				}
			}
			if (ip.method_34(Class5757.int_43) && (Enum679)ip.method_33(Class5757.int_43) == Enum679.const_236)
			{
				switch (enum679_0)
				{
				case Enum679.const_294:
					if (class6205_0 is Class6210 class5)
					{
						if (string.IsNullOrEmpty(class5.Value))
						{
							class5.Value = smethod_10(ip.arrayList_1);
						}
						else
						{
							class5.Value = class5.Value + '\n' + smethod_10(ip.arrayList_1);
						}
					}
					break;
				case Enum679.const_296:
					if (class6205_0 is Class6208 class3)
					{
						class3.Action = smethod_10(ip.arrayList_1);
					}
					break;
				case Enum679.const_297:
					if (class6205_0 is Class6209 class4)
					{
						if (class4.Items == null)
						{
							class4.Items = new List<string>();
						}
						class4.Items.Add(smethod_10(ip.arrayList_1));
						if (smethod_11(ip))
						{
							class4.Value = class4.Items.Count;
						}
					}
					break;
				case Enum679.const_299:
					if (class6205_0 is Class6206 class2)
					{
						class2.Caption = smethod_10(ip.arrayList_1);
					}
					break;
				}
			}
			if (smethod_11(ip))
			{
				switch (enum679_0)
				{
				case Enum679.const_295:
					if (class6205_0 is Class6207 class7)
					{
						class7.Value = true;
					}
					break;
				case Enum679.const_296:
					if (class6205_0 is Class6208 class6)
					{
						class6.Value = true;
					}
					break;
				}
			}
			if (ip.method_34(Class5757.int_39) && (int)ip.method_33(Class5757.int_39) == 214)
			{
				vmethod_34();
				base.vmethod_22(ip);
				class6205_0.CustomDraw = base.CurrentCanvas;
				vmethod_35();
				base.CurrentCanvas.Remove(class6205_0.CustomDraw);
			}
			else
			{
				base.vmethod_22(ip);
			}
		}
		finally
		{
			method_30();
		}
	}
}
