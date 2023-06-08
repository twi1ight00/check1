using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using Aspose.XfaConverter.Elements;
using ns215;
using ns217;
using ns235;

namespace ns216;

internal class Class5799 : Class5783, Interface253
{
	private Class6209 class6209_0;

	internal static string Tag => "choiceList";

	public Class5799()
	{
		Class5906.smethod_6(this, "commitOn", XfaEnums.Enum695.const_0);
		Class5906.smethod_6(this, "open", XfaEnums.Enum696.const_0);
		Class5906.smethod_3(this, "textEntry", @default: false);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_33(this);
		base.vmethod_4(visitor);
		visitor.vmethod_34(this);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5799();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	public void imethod_0(Class6213 canvas, Class6213 textCanvas, Class5912 builder, PointF pos, SizeF size)
	{
		try
		{
			Class5817 @class = Class5804.smethod_2(base.Parent);
			List<string> list = new List<string>();
			int value = -1;
			if (@class == null)
			{
				return;
			}
			Class5908 class2 = @class.method_3("..#items[*]");
			if (class2.Length > 0)
			{
				List<int> list2 = new List<int>();
				List<int> list3 = new List<int>();
				foreach (Class5824 item in class2.List)
				{
					if (item.Attributes["save"].vmethod_1() == "1")
					{
						foreach (Class5782 item2 in item.Nodes.List)
						{
							try
							{
								list2.Add(int.Parse(Class5893.smethod_2(item2)));
							}
							catch (Exception)
							{
							}
						}
					}
					if ((XfaEnums.Enum687)item.Attributes["presence"].Value != 0)
					{
						continue;
					}
					foreach (Class5782 item3 in item.Nodes.List)
					{
						string text = Class5893.smethod_2(item3);
						if (text == null)
						{
							text = string.Empty;
						}
						list.Add(text);
					}
				}
				if (list2.Count > 0)
				{
					list3.AddRange(list2);
					list3.Sort();
					for (int i = 0; i < list3.Count; i++)
					{
						if (list3[i] == list2[0] && i < list.Count)
						{
							value = i + 1;
						}
					}
				}
			}
			class6209_0 = new Class6209(PointF.Empty, string.Empty, list, -1);
			RectangleF rectangleF = Class5804.smethod_4(this, builder, pos, size);
			class6209_0.Value = value;
			class6209_0.DefaultFont = Class5804.smethod_3(this);
			class6209_0.Origin = rectangleF.Location;
			class6209_0.Size = rectangleF.Size;
			class6209_0.CustomDraw = canvas;
			builder.method_2(class6209_0);
			builder.method_5(canvas);
			if (textCanvas != null)
			{
				builder.method_5(textCanvas);
			}
		}
		catch (Exception value4)
		{
			Console.WriteLine(value4);
		}
	}

	internal override string[] vmethod_10()
	{
		return new string[3]
		{
			Class5790.Tag,
			Class5816.Tag,
			Class5829.Tag
		};
	}
}
