using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Xml;
using ns224;
using ns233;
using ns234;
using ns235;
using ns271;

namespace ns267;

internal class Class6622
{
	private class Class6623 : IDisposable
	{
		private static Stack stack_0 = new Stack();

		private XmlElement xmlElement_0;

		public XmlElement Element => xmlElement_0;

		public static Class6623 Current
		{
			get
			{
				if (stack_0.Count != 0)
				{
					return (Class6623)stack_0.Peek();
				}
				return null;
			}
		}

		public Class6623(XmlElement element)
		{
			stack_0.Push(this);
			xmlElement_0 = element;
		}

		public bool method_0()
		{
			XmlNode nextSibling = xmlElement_0;
			do
			{
				if (nextSibling.NextSibling != null)
				{
					nextSibling = nextSibling.NextSibling;
					continue;
				}
				return false;
			}
			while (nextSibling.NodeType != XmlNodeType.Element);
			xmlElement_0 = (XmlElement)nextSibling;
			return true;
		}

		public bool method_1()
		{
			if (!xmlElement_0.HasChildNodes)
			{
				return false;
			}
			XmlNode xmlNode = xmlElement_0.FirstChild;
			while (true)
			{
				if (xmlNode.NodeType != XmlNodeType.Element)
				{
					if (xmlNode.NextSibling == null)
					{
						break;
					}
					xmlNode = xmlNode.NextSibling;
					continue;
				}
				xmlElement_0 = (XmlElement)xmlNode;
				return true;
			}
			return false;
		}

		public void method_2()
		{
			xmlElement_0 = xmlElement_0.ParentNode as XmlElement;
		}

		public void Dispose()
		{
			stack_0.Pop();
		}
	}

	private XmlDocument xmlDocument_0;

	private Class6616 class6616_0;

	public XmlElement CurrentElement => Class6623.Current.Element;

	public XmlNodeList Resources
	{
		get
		{
			string xpath = "//Aps/Resources/Resource";
			return CurrentElement.SelectNodes(xpath);
		}
	}

	public Class6622(Class6616 context, Stream stream)
	{
		xmlDocument_0 = Class6169.smethod_4(stream);
		new Class6623(xmlDocument_0.DocumentElement);
		class6616_0 = context;
	}

	public bool method_0()
	{
		return Class6623.Current.method_0();
	}

	public bool method_1()
	{
		return Class6623.Current.method_1();
	}

	public void method_2()
	{
		Class6623.Current.method_2();
	}

	public bool method_3(string name, out float value)
	{
		if (method_11(name, out var value2))
		{
			value = float.Parse(value2, class6616_0.CurrentCulture);
			return true;
		}
		value = 0f;
		return false;
	}

	public bool method_4(string name, out double value)
	{
		if (method_11(name, out var value2))
		{
			value = double.Parse(value2, class6616_0.CurrentCulture);
			return true;
		}
		value = 0.0;
		return false;
	}

	public bool method_5(string name, out int value)
	{
		if (method_11(name, out var value2))
		{
			value = int.Parse(value2, class6616_0.CurrentCulture);
			return true;
		}
		value = 0;
		return false;
	}

	public bool method_6(string name, out bool value)
	{
		if (method_11(name, out var value2))
		{
			value = bool.Parse(value2);
			return true;
		}
		value = false;
		return false;
	}

	public bool method_7(string name, ref Enum value)
	{
		if (method_11(name, out var value2))
		{
			value = Class6625.smethod_0(value.GetType(), value2);
			return true;
		}
		return false;
	}

	public bool method_8(string name, out float[] value)
	{
		if (method_11(name, out var value2))
		{
			string[] array = value2.Split(' ');
			value = new float[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				value[i] = float.Parse(array[i], class6616_0.CurrentCulture);
			}
			return true;
		}
		value = null;
		return false;
	}

	public bool method_9(string name, out Class6002 value)
	{
		if (method_11(name, out var value2))
		{
			string[] array = value2.Split(' ');
			value = new Class6002(float.Parse(array[0], class6616_0.CurrentCulture), float.Parse(array[1], class6616_0.CurrentCulture), float.Parse(array[2], class6616_0.CurrentCulture), float.Parse(array[3], class6616_0.CurrentCulture), float.Parse(array[4], class6616_0.CurrentCulture), float.Parse(array[5], class6616_0.CurrentCulture));
			return true;
		}
		value = null;
		return false;
	}

	public bool method_10(string name, out Class5998 value)
	{
		if (method_11(name, out var value2))
		{
			string val = value2.Substring(1);
			int argb = Class6159.smethod_20(val);
			value = new Class5998(argb);
			return true;
		}
		value = null;
		return false;
	}

	public bool method_11(string name, out string value)
	{
		if (CurrentElement.HasAttribute(name))
		{
			value = CurrentElement.GetAttribute(name);
			return true;
		}
		value = null;
		return false;
	}

	public bool method_12(string name, out string value)
	{
		if (method_30(name, out var node))
		{
			value = node.InnerText;
			return true;
		}
		value = null;
		return false;
	}

	public string method_13()
	{
		return CurrentElement.InnerText;
	}

	public bool method_14(string name, out PointF value)
	{
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				return method_16(out value);
			}
		}
		value = Point.Empty;
		return false;
	}

	public bool method_15(string name, out SizeF value)
	{
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				return method_17(out value);
			}
		}
		value = SizeF.Empty;
		return false;
	}

	public bool method_16(out PointF value)
	{
		if (method_3("X", out var value2) && method_3("Y", out var value3))
		{
			value = new PointF(value2, value3);
			return true;
		}
		value = PointF.Empty;
		return false;
	}

	public bool method_17(out SizeF value)
	{
		if (method_3("Width", out var value2) && method_3("Height", out var value3))
		{
			value = new SizeF(value2, value3);
			return true;
		}
		value = SizeF.Empty;
		return false;
	}

	public bool method_18(string name, out RectangleF value)
	{
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				if (method_3("X", out var value2) && method_3("Y", out var value3) && method_3("Width", out var value4) && method_3("Height", out var value5))
				{
					value = new RectangleF(value2, value3, value4, value5);
					return true;
				}
			}
		}
		value = RectangleF.Empty;
		return false;
	}

	public bool method_19(string name, out Class6270 value)
	{
		value = null;
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				if (!method_18("ActiveRect", out var value2))
				{
					return false;
				}
				Enum value3 = Enum803.const_0;
				if (method_7("JumpType", ref value3))
				{
					if (method_5("Page", out var value4))
					{
						value = new Class6270(value2, value4);
						return true;
					}
					if (method_11("Target", out var value5))
					{
						value = new Class6270(value2, value5);
						return true;
					}
					value = new Class6270(value2, (Enum803)(object)value3);
					return true;
				}
			}
		}
		return false;
	}

	public bool method_20(string name, out Class6145 value)
	{
		value = null;
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				if (method_4("CropLeft", out var value2) && method_4("CropRight", out var value3) && method_4("CropTop", out var value4) && method_4("CropBottom", out var value5))
				{
					value = new Class6145(value2, value3, value4, value5);
					return true;
				}
			}
		}
		return false;
	}

	public bool method_21(string name, out Class6140 value)
	{
		value = null;
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				if (method_10("HighColor", out var value2) && method_10("LowColor", out var value3))
				{
					value = new Class6140(value3, value2);
					return true;
				}
			}
		}
		return false;
	}

	public bool method_22(string name, out Class6217 value)
	{
		value = null;
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				if (method_1())
				{
					Class6598 @class = class6616_0.method_3(CurrentElement.Name);
					value = @class.method_1() as Class6217;
					return true;
				}
			}
		}
		return false;
	}

	public bool method_23(string name, out Class6003 value)
	{
		value = null;
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				value = new Class6003(Class5998.class5998_141);
				Enum value2 = Enum747.const_3;
				if (method_7("Alignment", ref value2))
				{
					value.Alignment = (Enum747)(object)value2;
				}
				if (method_8("CompoundArray", out var value3))
				{
					value.CompoundArray = value3;
				}
				Enum value4 = DashCap.Flat;
				if (method_7("DashCap", ref value4))
				{
					value.DashCap = (DashCap)(object)value4;
				}
				if (method_3("DashOffset", out var value5))
				{
					value.DashOffset = value5;
				}
				if (method_8("DashPattern", out var value6))
				{
					value.DashPattern = value6;
				}
				Enum value7 = DashStyle.Solid;
				if (method_7("DashStyle", ref value7))
				{
					value.DashStyle = (DashStyle)(object)value7;
				}
				Enum value8 = LineCap.Flat;
				if (method_7("EndCap", ref value8))
				{
					value.EndCap = (LineCap)(object)value8;
				}
				Enum value9 = LineJoin.Bevel;
				if (method_7("LineJoin", ref value9))
				{
					value.LineJoin = (LineJoin)(object)value9;
				}
				if (method_3("MiterLimit", out var value10))
				{
					value.MiterLimit = value10;
				}
				Enum value11 = LineCap.Flat;
				if (method_7("StartCap", ref value11))
				{
					value.StartCap = (LineCap)(object)value11;
				}
				if (method_3("Width", out var value12))
				{
					value.Width = value12;
				}
				if (method_24("Brush", out var value13))
				{
					value.Brush = value13;
				}
				return true;
			}
		}
		return false;
	}

	public bool method_24(string name, out Class5990 value)
	{
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				return new Class6624(class6616_0).method_0(out value);
			}
		}
		value = null;
		return false;
	}

	public bool method_25(string name, out Class5999 value)
	{
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				Enum value2 = FontStyle.Regular;
				if (method_3("SizePoints", out var value3) && method_7("Style", ref value2) && method_11("FamilyName", out var value4))
				{
					if (class6616_0.Reader.method_5("ResourceId", out var value5))
					{
						byte[] data = class6616_0.Resources.Read(value5);
						Class6656 fontData = new Class6656(data);
						Class6732 @class = new Class6732();
						Class6730 trueTypeFont = @class.Read(fontData, string.Empty);
						value = new Class5999(value3, (FontStyle)(object)value2, trueTypeFont);
					}
					else
					{
						value = Class6652.Instance.method_1(value4, value3, (FontStyle)(object)value2);
					}
					return true;
				}
			}
		}
		value = null;
		return false;
	}

	public bool method_26(string name, out byte[] value)
	{
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				if (class6616_0.Reader.method_5("ResourceId", out var value2))
				{
					value = class6616_0.Resources.Read(value2);
					return true;
				}
			}
		}
		value = null;
		return false;
	}

	public bool method_27(string name, out List<string> value)
	{
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				value = new List<string>();
				method_1();
				do
				{
					value.Add(method_13());
				}
				while (method_0());
				method_2();
				return true;
			}
		}
		value = null;
		return false;
	}

	public bool method_28(string name, out Class5998[] value)
	{
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				List<Class5998> list = new List<Class5998>();
				method_1();
				do
				{
					if (method_10("Value", out var value2))
					{
						list.Add(value2);
					}
				}
				while (method_0());
				method_2();
				value = list.ToArray();
				return true;
			}
		}
		value = null;
		return false;
	}

	public bool method_29(string name, out Class6000[] value)
	{
		if (method_30(name, out var node))
		{
			using (new Class6623(node))
			{
				List<Class6000> list = new List<Class6000>();
				method_1();
				do
				{
					if (method_10("Color", out var value2) && method_3("Position", out var value3))
					{
						list.Add(new Class6000(value2, value3));
					}
				}
				while (method_0());
				method_2();
				value = list.ToArray();
				return true;
			}
		}
		value = null;
		return false;
	}

	private bool method_30(string xpath, out XmlElement node)
	{
		node = CurrentElement.SelectSingleNode(xpath) as XmlElement;
		return node != null;
	}
}
