using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;
using Aspose.Slides;

namespace ns28;

internal class Class369 : XmlElement
{
	public Class369(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal virtual void vmethod_0()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode is Class369 @class)
				{
					@class.vmethod_0();
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
	}

	internal virtual void vmethod_1()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode is Class369 @class)
				{
					@class.vmethod_1();
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
	}

	public string method_0(string localName, string namespaceURI, string defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return GetAttribute(localName, namespaceURI);
		}
		return defaultValue;
	}

	public NullableBool method_1(string localName, string namespaceURI, NullableBool defaultValue)
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
		return defaultValue;
	}

	public void method_2(string localName, string namespaceURI, NullableBool value)
	{
		if (value != NullableBool.NotDefined)
		{
			SetAttribute(localName, namespaceURI, (value == NullableBool.True) ? "true" : "false");
		}
	}

	public bool method_3(string localName, string namespaceURI, bool defaultValue)
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
				return false;
			}
		}
		return defaultValue;
	}

	public void method_4(string localName, string namespaceURI, bool value)
	{
		SetAttribute(localName, namespaceURI, value ? "true" : "false");
	}

	public double method_5(string localName, string namespaceURI, double defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			string attribute = GetAttribute(localName, namespaceURI);
			return double.Parse(attribute, CultureInfo.InvariantCulture);
		}
		return defaultValue;
	}

	public void method_6(string localName, string namespaceURI, double value)
	{
		string value2 = value.ToString(CultureInfo.InvariantCulture);
		SetAttribute(localName, namespaceURI, value2);
	}

	public double method_7(string localName, string namespaceURI, double defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			string text = GetAttribute(localName, namespaceURI);
			bool flag = false;
			if (text.IndexOf("cm") > 0)
			{
				text = text.Replace("cm", "");
			}
			if (text.IndexOf("in") > 0)
			{
				text = text.Replace("in", "");
				flag = true;
			}
			double num = double.Parse(text, CultureInfo.InvariantCulture);
			if (flag)
			{
				return 72.02813067150636 * num;
			}
			return 28.348214285714285 * num;
		}
		return defaultValue;
	}

	public void method_8(string localName, string namespaceURI, double value)
	{
		string text = (0.0352755905511811 * value).ToString(CultureInfo.InvariantCulture);
		SetAttribute(localName, namespaceURI, text + "cm");
	}

	internal int method_9(Class467 edesc, string localName, string namespaceURI, int defaultValue)
	{
		if (!HasAttribute(localName, namespaceURI))
		{
			return defaultValue;
		}
		return edesc[GetAttribute(localName, namespaceURI)];
	}

	internal void method_10(Class467 edesc, string localName, string namespaceURI, int value)
	{
		SetAttribute(localName, namespaceURI, edesc[value]);
	}

	public int method_11(string localName, string namespaceURI, int defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			string attribute = GetAttribute(localName, namespaceURI);
			attribute = attribute.Replace("%", "");
			return Convert.ToInt32(attribute);
		}
		return defaultValue;
	}

	public void method_12(string localName, string namespaceURI, int value)
	{
		SetAttribute(localName, namespaceURI, XmlConvert.ToString(value) + "%");
	}

	public int method_13(string localName, string namespaceURI, int defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return XmlConvert.ToInt32(GetAttribute(localName, namespaceURI));
		}
		return defaultValue;
	}

	public void method_14(string localName, string namespaceURI, int value, int defaultValue)
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

	public void method_15(string localName, string namespaceURI, int value)
	{
		SetAttribute(localName, namespaceURI, XmlConvert.ToString(value));
	}

	public Color method_16(string localName, string namespaceURI, Color defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			string attribute = GetAttribute(localName, namespaceURI);
			return method_18(attribute);
		}
		return defaultValue;
	}

	public void method_17(string localName, string namespaceURI, Color value)
	{
		SetAttribute(localName, namespaceURI, method_19(value));
	}

	public Color method_18(string hexColor)
	{
		if (hexColor.IndexOf('#') != -1)
		{
			hexColor = hexColor.Replace("#", "");
		}
		int red = 0;
		int green = 0;
		int blue = 0;
		if (hexColor.Length == 6)
		{
			red = int.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
			green = int.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
			blue = int.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);
		}
		else if (hexColor.Length == 3)
		{
			red = int.Parse(hexColor[0].ToString() + hexColor[0], NumberStyles.AllowHexSpecifier);
			green = int.Parse(hexColor[1].ToString() + hexColor[1], NumberStyles.AllowHexSpecifier);
			blue = int.Parse(hexColor[2].ToString() + hexColor[2], NumberStyles.AllowHexSpecifier);
		}
		return Color.FromArgb(red, green, blue);
	}

	public string method_19(Color color)
	{
		int r = color.R;
		int g = color.G;
		int b = color.B;
		string text = Convert.ToString(r, 16);
		string text2 = Convert.ToString(g, 16);
		string text3 = Convert.ToString(b, 16);
		if (text.Length == 1)
		{
			text = "0" + text;
		}
		if (text2.Length == 1)
		{
			text2 = "0" + text2;
		}
		if (text3.Length == 1)
		{
			text3 = "0" + text3;
		}
		return "#" + text + text2 + text3;
	}

	public char method_20(string localName, string namespaceURI, char defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			return Convert.ToChar(GetAttribute(localName, namespaceURI));
		}
		return defaultValue;
	}

	public void method_21(string localName, string namespaceURI, char value)
	{
		base.SetAttribute(localName, namespaceURI, Convert.ToString(value));
	}

	public double method_22(string fontSizeStr)
	{
		double num = 1.0;
		if (fontSizeStr.IndexOf("in") > 0)
		{
			num = 72.0;
		}
		string text = fontSizeStr.Replace("pt", "");
		text = text.Replace("in", "");
		text = text.Replace("%", "");
		return double.Parse(text, CultureInfo.InvariantCulture) * num;
	}

	public string method_23(double fontSize)
	{
		string text = fontSize.ToString(CultureInfo.InvariantCulture);
		return text + "pt";
	}

	public string method_24(double fontSize)
	{
		string text = (double.IsNaN(fontSize) ? 100.0 : fontSize).ToString(CultureInfo.InvariantCulture);
		return text + "%";
	}

	public double method_25(string localName, string namespaceURI, double defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			string attribute = GetAttribute(localName, namespaceURI);
			if (attribute.IndexOf("deg") > 0)
			{
				return double.Parse(attribute.Replace("deg", ""), CultureInfo.InvariantCulture);
			}
			if (attribute.IndexOf("grad") > 0)
			{
				return 1.111 * double.Parse(attribute.Replace("grad", ""), CultureInfo.InvariantCulture);
			}
			if (attribute.IndexOf("rad") > 0)
			{
				attribute.Replace("rad", "");
				return 180.0 / Math.PI * double.Parse(attribute.Replace("rad", ""), CultureInfo.InvariantCulture);
			}
			return Convert.ToDouble(Regex.Replace(attribute, "[^0-9.]", ""), CultureInfo.InvariantCulture);
		}
		return defaultValue;
	}

	public void method_26(string localName, string namespaceURI, double value)
	{
		SetAttribute(localName, namespaceURI, value.ToString(CultureInfo.InvariantCulture) + "deg");
	}

	public object[,] method_27(string localName, string namespaceURI, string defaultValue)
	{
		string input = ((!HasAttribute(localName, namespaceURI)) ? defaultValue : GetAttribute(localName, namespaceURI));
		MatchCollection matchCollection = Regex.Matches(input, "[AaBCcFLlMmNQqSsTtUVvWXYZzHh][ 0-9?f-]*");
		string text = "";
		object[,] array = new object[matchCollection.Count, 2];
		for (int i = 0; i < matchCollection.Count; i++)
		{
			string text2 = matchCollection[i].Value.Substring(0, 1);
			text = matchCollection[i].Value.Remove(0, 1).Replace("-", " -").Trim();
			string[] array2 = text.Split(' ');
			array[i, 0] = text2;
			array[i, 1] = array2;
		}
		return array;
	}

	public void method_28(string localName, string namespaceURI, object[,] value)
	{
		string text = "";
		for (int i = 0; i < value.GetLength(0); i++)
		{
			text = text + Convert.ToString(value[i, 0]) + " ";
			string[] array = (string[])value[i, 1];
			for (int j = 0; j < array.Length; j++)
			{
				text = text + Convert.ToString(array[j]) + " ";
			}
		}
		SetAttribute(localName, namespaceURI, text.Trim());
	}

	public Class369[] method_29(string localName, string namespaceURI)
	{
		List<Class369> list = new List<Class369>();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode is Class369 @class && @class.LocalName == localName && @class.NamespaceURI == namespaceURI)
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

	public List<XmlNode> method_30(string localName, string namespaceURI)
	{
		List<XmlNode> list = new List<XmlNode>();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode != null && xmlNode.LocalName == localName && xmlNode.NamespaceURI == namespaceURI)
				{
					list.Add(xmlNode);
				}
			}
			return list;
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	public Class369 method_31(string localName, string namespaceURI)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode is Class369 @class && @class.LocalName == localName && @class.NamespaceURI == namespaceURI)
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

	public Class369[] method_32(string[] localNames, string namespaceURI)
	{
		List<Class369> list = new List<Class369>();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (!(xmlNode is Class369 @class) || !(@class.NamespaceURI == namespaceURI))
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

	public Class369 method_33(string[] localNames, string namespaceURI)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (!(xmlNode is Class369 @class) || !(@class.NamespaceURI == namespaceURI))
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

	internal double method_34(string coordinate)
	{
		double num = 1.0;
		if (coordinate.IndexOf("cm") > 0)
		{
			num = 28.348214285714285;
		}
		if (coordinate.IndexOf("mm") > 0)
		{
			num = 28.348214285714285;
		}
		if (coordinate.IndexOf("in") > 0)
		{
			num = 72.02813067150636;
		}
		if (coordinate.IndexOf("pt") > 0)
		{
			num = 803.3883971827371;
		}
		string s = Regex.Replace(coordinate, "[^0-9.]", "");
		double num2 = double.Parse(s, CultureInfo.InvariantCulture);
		return num * num2;
	}

	public Class369 method_35(string localName, string namespaceURI)
	{
		Class369 @class = (Class369)OwnerDocument.CreateElement(OwnerDocument.DocumentElement.GetPrefixOfNamespace(namespaceURI), localName, namespaceURI);
		AppendChild(@class);
		return @class;
	}
}
