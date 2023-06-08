using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using Aspose.Slides;
using ns33;

namespace ns58;

internal class Class2607 : XmlElement
{
	private static readonly string[] string_0 = new string[9] { "tl", "t", "tr", "l", "ctr", "r", "bl", "b", "br" };

	public new Class2606 OwnerDocument => base.OwnerDocument as Class2606;

	public Class2607(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal virtual void vmethod_0()
	{
	}

	public Class2607 method_0(string localName, string namespaceURI)
	{
		string text = GetPrefixOfNamespace(namespaceURI);
		if (text == null || text == "")
		{
			Class2606.dictionary_0.TryGetValue(namespaceURI, out var value);
			if (value == "")
			{
				text = value;
			}
			else
			{
				if (value == null)
				{
					value = "xns";
				}
				int num = 0;
				do
				{
					int num2 = num;
					string text2 = "";
					while (num2 > 0)
					{
						text2 = num2 % 10 + text2;
						num2 /= 10;
					}
					text = value + text2;
					num++;
				}
				while (GetNamespaceOfPrefix(text) != "");
			}
		}
		Class2607 @class = (Class2607)OwnerDocument.CreateElement(text, localName, namespaceURI);
		AppendChild(@class);
		@class.vmethod_0();
		return @class;
	}

	public Class2607 method_1(string localName, string namespaceURI)
	{
		Class2607 @class = (Class2607)OwnerDocument.CreateElement(GetPrefixOfNamespace(namespaceURI), localName, namespaceURI);
		PrependChild(@class);
		@class.vmethod_0();
		return @class;
	}

	public Class2607 method_2(Class2607 elem, string localName, string namespaceURI)
	{
		Class2607 @class = (Class2607)OwnerDocument.CreateElement(OwnerDocument.DocumentElement.GetPrefixOfNamespace(namespaceURI), localName, namespaceURI);
		if (elem != null)
		{
			ReplaceChild(@class, elem);
		}
		else
		{
			AppendChild(@class);
		}
		@class.vmethod_0();
		return @class;
	}

	public Class2607 method_3(string oldElemName, string localName, string namespaceURI)
	{
		Class2607 elem = method_57(oldElemName, namespaceURI);
		return method_2(elem, localName, namespaceURI);
	}

	public Class2607 method_4(string[] oldElemNames, string localName, string namespaceURI)
	{
		Class2607 elem = method_59(oldElemNames, namespaceURI);
		return method_2(elem, localName, namespaceURI);
	}

	public string method_5(string localName, string namespaceURI, string defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return GetAttribute(localName, namespaceURI);
		}
		return defaultValue;
	}

	public void method_6()
	{
		List<XmlNode> list = new List<XmlNode>();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode is XmlElement)
				{
					list.Add(xmlNode);
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		foreach (XmlElement item in list)
		{
			RemoveChild(item);
		}
	}

	public void method_7(string localName, string namespaceURI, string value)
	{
		if (value != null)
		{
			base.SetAttribute(localName, namespaceURI, value);
		}
		else
		{
			RemoveAttribute(localName, namespaceURI);
		}
	}

	public void method_8(string localName, string namespaceURI, string value, string defaultValue)
	{
		if (!(value == defaultValue) && value != null)
		{
			SetAttribute(localName, namespaceURI, value);
		}
		else
		{
			RemoveAttribute(localName, namespaceURI);
		}
	}

	public float method_9(string localName, string namespaceURI, float defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			string attribute = GetAttribute(localName, namespaceURI);
			attribute = attribute.ToLower();
			int num = attribute.IndexOf('f');
			if (num != -1)
			{
				attribute = attribute.Substring(0, num - 1);
				return (float)int.Parse(attribute) / 65536f;
			}
			return (float)XmlConvert.ToDouble(attribute);
		}
		return defaultValue;
	}

	public void method_10(string localName, string namespaceURI, float value, float defaultValue)
	{
		if (value == defaultValue)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, XmlConvert.ToString(value));
		}
	}

	public int method_11(string localName, string namespaceURI, int defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return XmlConvert.ToInt32(GetAttribute(localName, namespaceURI));
		}
		return defaultValue;
	}

	public void method_12(string localName, string namespaceURI, int value, int defaultValue)
	{
		if (value == defaultValue)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, XmlConvert.ToString(value));
		}
	}

	public void method_13(string localName, string namespaceURI, int value)
	{
		SetAttribute(localName, namespaceURI, XmlConvert.ToString(value));
	}

	public long method_14(string localName, string namespaceURI, long defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return XmlConvert.ToInt64(GetAttribute(localName, namespaceURI));
		}
		return defaultValue;
	}

	public void method_15(string localName, string namespaceURI, long value, long defaultValue)
	{
		if (value == defaultValue)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, XmlConvert.ToString(value));
		}
	}

	public void method_16(string localName, string namespaceURI, long value)
	{
		SetAttribute(localName, namespaceURI, XmlConvert.ToString(value));
	}

	public NullableBool method_17(string localName, string namespaceURI)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			switch (GetAttribute(localName, namespaceURI))
			{
			default:
				return NullableBool.True;
			case "false":
			case "0":
			case "f":
				return NullableBool.False;
			}
		}
		return NullableBool.NotDefined;
	}

	public void method_18(string localName, string namespaceURI, NullableBool value)
	{
		if (value == NullableBool.NotDefined)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, (value == NullableBool.True) ? "1" : "0");
		}
	}

	public void method_19(string localName, string namespaceURI, NullableBool value)
	{
		if (value == NullableBool.NotDefined)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, (value == NullableBool.True) ? "true" : "false");
		}
	}

	public bool method_20(string localName, string namespaceURI, bool defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			switch (GetAttribute(localName, namespaceURI))
			{
			default:
				return true;
			case "false":
			case "0":
			case "f":
			case "F":
				return false;
			}
		}
		return defaultValue;
	}

	public void method_21(string localName, string namespaceURI, bool value)
	{
		SetAttribute(localName, namespaceURI, value ? "1" : "0");
	}

	public void method_22(string localName, string namespaceURI, bool value, bool defaultValue)
	{
		if (value == defaultValue)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, value ? "1" : "0");
		}
	}

	public void method_23(string localName, string namespaceURI, bool value, bool defaultValue)
	{
		if (value == defaultValue)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, value ? "true" : "false");
		}
	}

	public void method_24(string localName, string namespaceURI, bool value)
	{
		SetAttribute(localName, namespaceURI, value ? "true" : "false");
	}

	public void method_25(string localName, string namespaceURI, bool value, bool defaultValue)
	{
		if (value == defaultValue)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, value ? "t" : "f");
		}
	}

	public void method_26(string localName, string namespaceURI, bool value)
	{
		SetAttribute(localName, namespaceURI, value ? "t" : "f");
	}

	public float method_27(string localName, string namespaceURI, float defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return (float)XmlConvert.ToInt32(GetAttribute(localName, namespaceURI)) / 60000f;
		}
		return defaultValue;
	}

	public void method_28(string localName, string namespaceURI, float value, float defaultValue)
	{
		int num = (int)Math.Round(value * 60000f);
		int num2 = (int)Math.Round(defaultValue * 60000f);
		if (num == num2)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, XmlConvert.ToString(num));
		}
	}

	public void method_29(string localName, string namespaceURI, float value)
	{
		SetAttribute(localName, namespaceURI, XmlConvert.ToString((int)Math.Round(value * 60000f)));
	}

	public float method_30(string localName, string namespaceURI, float defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return (float)XmlConvert.ToInt32(GetAttribute(localName, namespaceURI)) / 100f;
		}
		return defaultValue;
	}

	public void method_31(string localName, string namespaceURI, float value, float defaultValue)
	{
		int num = (int)Math.Round(value * 100f);
		if (num == (int)Math.Round(defaultValue * 100f))
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, XmlConvert.ToString(num));
		}
	}

	public void method_32(string localName, string namespaceURI, float value)
	{
		SetAttribute(localName, namespaceURI, XmlConvert.ToString((int)Math.Round(value * 100f)));
	}

	public double method_33(string localName, string namespaceURI, double defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return (double)XmlConvert.ToInt64(GetAttribute(localName, namespaceURI)) / 12700.0;
		}
		return defaultValue;
	}

	public void method_34(string localName, string namespaceURI, double value, double defaultValue)
	{
		long num = (long)Math.Round(value * 12700.0);
		if (num == (long)Math.Round(defaultValue * 12700.0))
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, XmlConvert.ToString(num));
		}
	}

	public void method_35(string localName, string namespaceURI, double value)
	{
		SetAttribute(localName, namespaceURI, XmlConvert.ToString((long)Math.Round(value * 12700.0)));
	}

	public float method_36(string localName, string namespaceURI, float defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return (float)XmlConvert.ToInt32(GetAttribute(localName, namespaceURI)) / 1000f;
		}
		return defaultValue;
	}

	public void method_37(string localName, string namespaceURI, float value, float defaultValue)
	{
		int num = (int)Math.Round(value * 1000f);
		int num2 = (int)Math.Round(defaultValue * 1000f);
		if (num == num2)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, XmlConvert.ToString(num));
		}
	}

	public void method_38(string localName, string namespaceURI, float value)
	{
		SetAttribute(localName, namespaceURI, XmlConvert.ToString((int)Math.Round(value * 1000f)));
	}

	public uint method_39(string localName, string namespaceURI, uint defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return uint.Parse(GetAttribute(localName, namespaceURI), NumberStyles.HexNumber);
		}
		return defaultValue;
	}

	public void method_40(string localName, string namespaceURI, uint value, uint defaultValue)
	{
		if (value == defaultValue)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, value.ToString("X8"));
		}
	}

	public void method_41(string localName, string namespaceURI, uint value)
	{
		SetAttribute(localName, namespaceURI, value.ToString("X8"));
	}

	public uint method_42(string localName, string namespaceURI, uint defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return uint.Parse(GetAttribute(localName, namespaceURI), NumberStyles.HexNumber);
		}
		return defaultValue;
	}

	public void method_43(string localName, string namespaceURI, uint value, uint defaultValue)
	{
		if (value == defaultValue)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, (value & 0xFFFFFFu).ToString("X6"));
		}
	}

	public void method_44(string localName, string namespaceURI, uint value)
	{
		SetAttribute(localName, namespaceURI, (value & 0xFFFFFFu).ToString("X6"));
	}

	public ushort method_45(string localName, string namespaceURI, ushort defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return ushort.Parse(GetAttribute(localName, namespaceURI), NumberStyles.HexNumber);
		}
		return defaultValue;
	}

	public void method_46(string localName, string namespaceURI, ushort value, ushort defaultValue)
	{
		if (value == defaultValue)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, value.ToString("X4"));
		}
	}

	public void method_47(string localName, string namespaceURI, ushort value)
	{
		SetAttribute(localName, namespaceURI, value.ToString("X4"));
	}

	public byte method_48(string localName, string namespaceURI, byte defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return byte.Parse(GetAttribute(localName, namespaceURI), NumberStyles.HexNumber);
		}
		return defaultValue;
	}

	public void method_49(string localName, string namespaceURI, byte value, byte defaultValue)
	{
		if (value == defaultValue)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, value.ToString("X2"));
		}
	}

	public void method_50(string localName, string namespaceURI, byte value)
	{
		SetAttribute(localName, namespaceURI, value.ToString("X2"));
	}

	public RectangleAlignment method_51(string localName, string namespaceURI, RectangleAlignment defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return GetAttribute(localName, namespaceURI) switch
			{
				"t" => RectangleAlignment.Top, 
				"tr" => RectangleAlignment.TopRight, 
				"l" => RectangleAlignment.Left, 
				"ctr" => RectangleAlignment.Center, 
				"r" => RectangleAlignment.Right, 
				"bl" => RectangleAlignment.BottomLeft, 
				"b" => RectangleAlignment.Bottom, 
				"br" => RectangleAlignment.BottomRight, 
				_ => RectangleAlignment.TopLeft, 
			};
		}
		return defaultValue;
	}

	public void method_52(string localName, string namespaceURI, RectangleAlignment value, RectangleAlignment defaultValue)
	{
		if (value != defaultValue && value >= RectangleAlignment.TopLeft)
		{
			SetAttribute(localName, namespaceURI, string_0[(int)value]);
		}
		else
		{
			RemoveAttribute(localName, namespaceURI);
		}
	}

	public void method_53(string localName, string namespaceURI, RectangleAlignment value)
	{
		if (value >= RectangleAlignment.TopLeft)
		{
			SetAttribute(localName, namespaceURI, string_0[(int)value]);
		}
		else
		{
			RemoveAttribute(localName, namespaceURI);
		}
	}

	public void method_54(string localName, string namespaceURI)
	{
		Class2607[] array = method_56(localName, namespaceURI);
		Class2607[] array2 = array;
		foreach (XmlElement oldChild in array2)
		{
			RemoveChild(oldChild);
		}
	}

	public void method_55(string[] localNames, string namespaceURI)
	{
		foreach (string localName in localNames)
		{
			method_54(localName, namespaceURI);
		}
	}

	public Class2607[] method_56(string localName, string namespaceURI)
	{
		List<Class2607> list = new List<Class2607>();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode is Class2607 @class && @class.LocalName == localName && @class.NamespaceURI == namespaceURI)
				{
					list.Add(@class);
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return list.ToArray();
	}

	public Class2607 method_57(string localName, string namespaceURI)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode is Class2607 @class && @class.LocalName == localName && @class.NamespaceURI == namespaceURI)
				{
					return @class;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	public Class2607[] method_58(string[] localNames, string namespaceURI)
	{
		List<Class2607> list = new List<Class2607>();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (!(xmlNode is Class2607 @class) || !(@class.NamespaceURI == namespaceURI))
				{
					continue;
				}
				foreach (string text in localNames)
				{
					if (text == @class.LocalName)
					{
						list.Add(@class);
						break;
					}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return list.ToArray();
	}

	public Class2607 method_59(string[] localNames, string namespaceURI)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (!(xmlNode is Class2607 @class) || !(@class.NamespaceURI == namespaceURI))
				{
					continue;
				}
				foreach (string text in localNames)
				{
					if (text == @class.LocalName)
					{
						return @class;
					}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	public Class2607 method_60(string localName, string namespaceURI)
	{
		Class2607 @class = method_57(localName, namespaceURI);
		if (@class == null)
		{
			@class = (Class2607)OwnerDocument.CreateElement(GetPrefixOfNamespace(namespaceURI), localName, namespaceURI);
			AppendChild(@class);
		}
		return @class;
	}

	internal static int smethod_0(int value, int minValue, int maxValue)
	{
		if (value < minValue)
		{
			value = minValue;
		}
		else if (value > maxValue)
		{
			value = maxValue;
		}
		return value;
	}

	internal static float smethod_1(float value, float minValue, float maxValue)
	{
		if (value < minValue)
		{
			value = minValue;
		}
		else if (value > maxValue)
		{
			value = maxValue;
		}
		return value;
	}

	internal static double smethod_2(double value, double minValue, double maxValue)
	{
		if (value < minValue)
		{
			value = minValue;
		}
		else if (value > maxValue)
		{
			value = maxValue;
		}
		return value;
	}

	internal int method_61(Class1151 edesc, string localName, string namespaceURI, string defaultValue)
	{
		string text = defaultValue;
		if (HasAttribute(localName, namespaceURI))
		{
			text = GetAttribute(localName, namespaceURI);
		}
		return edesc[text];
	}

	internal int method_62(Class1151 edesc, string localName, string namespaceURI, int defaultValue)
	{
		if (!HasAttribute(localName, namespaceURI))
		{
			return defaultValue;
		}
		return edesc[GetAttribute(localName, namespaceURI)];
	}

	internal void method_63(Class1151 edesc, string localName, string namespaceURI, int value)
	{
		SetAttribute(localName, namespaceURI, edesc[value]);
	}

	internal void method_64(Class1151 edesc, string localName, string namespaceURI, int value, int defaultValue)
	{
		if (value != defaultValue && value >= edesc.LowerBound && value <= edesc.UpperBound)
		{
			SetAttribute(localName, namespaceURI, edesc[value]);
		}
		else
		{
			RemoveAttribute(localName, namespaceURI);
		}
	}

	internal Guid method_65(string localName, string namespaceURI, Guid defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return XmlConvert.ToGuid(GetAttribute(localName, namespaceURI));
		}
		return defaultValue;
	}

	public void method_66(string localName, string namespaceURI, Guid value, Guid defaultValue)
	{
		if (value == defaultValue)
		{
			RemoveAttribute(localName, namespaceURI);
		}
		else
		{
			SetAttribute(localName, namespaceURI, "{" + XmlConvert.ToString(value).ToUpper() + "}");
		}
	}

	public void method_67(string localName, string namespaceURI, Guid value)
	{
		SetAttribute(localName, namespaceURI, "{" + XmlConvert.ToString(value).ToUpper() + "}");
	}
}
