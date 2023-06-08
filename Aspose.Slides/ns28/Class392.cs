using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using ns24;
using ns33;

namespace ns28;

internal class Class392 : Class369
{
	private string[] string_0;

	internal static readonly Class467 class467_0 = new Class467("path", "shape");

	internal static readonly Class467 class467_1 = new Class467("normal", "path", "shape");

	internal static readonly Class467 class467_2 = new Class467("none", "segments", "str_rectangle");

	internal static readonly Class467 class467_3 = new Class467("flat", "phong", "gouraud", "draft");

	internal static readonly Class467 class467_4 = new Class467("parallel", "perspective");

	internal static readonly string string_1 = "enhanced-geometry";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:dr3d:1.0";

	internal static readonly string string_3 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";

	private Class488 class488_0;

	private Class488 class488_1;

	private Class488 class488_2;

	private Class468 class468_0;

	private Class484 class484_0;

	private Class489 class489_0;

	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	private Dictionary<string, string> dictionary_1 = new Dictionary<string, string>();

	private Dictionary<string, long> dictionary_2 = new Dictionary<string, long>();

	private Dictionary<string, string> dictionary_3 = new Dictionary<string, string>();

	private Dictionary<string, string> dictionary_4 = new Dictionary<string, string>();

	private List<string> list_0 = new List<string>();

	internal Dictionary<string, int> dictionary_5 = new Dictionary<string, int>();

	internal static readonly string[] string_4 = new string[11]
	{
		"c", "w", "h", "ss", "ls", "hc", "vc", "l", "t", "r",
		"b"
	};

	private static readonly Class1151 class1151_0 = new Class1151("*/", "+-", "+/", "?:", "abs", "at2", "cat2", "cos", "max", "min", "mod", "pin", "sat2", "sin", "sqrt", "tan", "val");

	private static readonly int[] int_0 = new int[17]
	{
		3, 3, 3, 3, 1, 2, 3, 2, 2, 2,
		3, 3, 3, 2, 1, 2, 1
	};

	internal Enum69 Projection
	{
		get
		{
			return (Enum69)method_9(class467_4, "projection", string_2, 0);
		}
		set
		{
			method_10(class467_4, "projection", string_2, (int)value);
		}
	}

	internal Enum77 ShadeMode
	{
		get
		{
			return (Enum77)method_9(class467_3, "shade-mode", string_2, 0);
		}
		set
		{
			method_10(class467_3, "shade-mode", string_2, (int)value);
		}
	}

	internal bool ConcentricGradientFillAllowed
	{
		get
		{
			return method_3("concentric-gradient-fill-allowed", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("concentric-gradient-fill-allowed", NamespaceURI, value);
		}
	}

	internal string EnhancedPath
	{
		get
		{
			return method_0("enhanced-path", NamespaceURI, "");
		}
		set
		{
			SetAttribute("enhanced-path", NamespaceURI, value);
		}
	}

	internal bool Extrusion
	{
		get
		{
			return method_3("extrusion", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("extrusion", NamespaceURI, value);
		}
	}

	internal bool ExtrusionAllowed
	{
		get
		{
			return method_3("extrusion-allowed", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("extrusion-allowed", NamespaceURI, value);
		}
	}

	internal int ExtrusionBrightness
	{
		get
		{
			return method_11("extrusion-brightness", NamespaceURI, 33);
		}
		set
		{
			method_12("extrusion-brightness", NamespaceURI, value);
		}
	}

	internal bool ExtrusionColor
	{
		get
		{
			return method_3("extrusion-color", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("extrusion-color", NamespaceURI, value);
		}
	}

	internal Class468 ExtrusionDepth
	{
		get
		{
			return class468_0;
		}
		set
		{
			class468_0 = value;
		}
	}

	internal int ExtrusionDiffusion
	{
		get
		{
			return method_11("extrusion-diffusion", NamespaceURI, 0);
		}
		set
		{
			method_12("extrusion-diffusion", NamespaceURI, value);
		}
	}

	internal Class488 ExtrusionFirstLightDirection
	{
		get
		{
			return class488_0;
		}
		set
		{
			class488_0 = value;
		}
	}

	internal bool ExtrusionFirstLightHarsh
	{
		get
		{
			return method_3("extrusion-first-light-harsh", NamespaceURI, defaultValue: true);
		}
		set
		{
			method_4("extrusion-first-light-harsh", NamespaceURI, value);
		}
	}

	internal int ExtrusionFirstLightLevel
	{
		get
		{
			return method_11("extrusion-first-light-level", NamespaceURI, 66);
		}
		set
		{
			method_12("extrusion-first-light-level", NamespaceURI, value);
		}
	}

	internal bool ExtrusionLightFace
	{
		get
		{
			return method_3("extrusion-light-face", NamespaceURI, defaultValue: true);
		}
		set
		{
			method_4("extrusion-light-face", NamespaceURI, value);
		}
	}

	internal bool ExtrusionMetal
	{
		get
		{
			return method_3("extrusion-metal", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("extrusion-metal", NamespaceURI, value);
		}
	}

	internal int ExtrusionNumberOfLineSegments
	{
		get
		{
			return method_13("extrusion-number-of-line-segments", NamespaceURI, 30);
		}
		set
		{
			method_15("extrusion-number-of-line-segments", NamespaceURI, value);
		}
	}

	internal string ExtrusionOrigin
	{
		get
		{
			return GetAttribute("extrusion-origin", NamespaceURI);
		}
		set
		{
			SetAttribute("extrusion-origin", NamespaceURI, value);
		}
	}

	internal string ExtrusionRotationAngle
	{
		get
		{
			return GetAttribute("extrusion-rotation-angle", NamespaceURI);
		}
		set
		{
			SetAttribute("extrusion-rotation-angle", NamespaceURI, value);
		}
	}

	internal Class488 ExtrusionRotationCenter
	{
		get
		{
			return class488_1;
		}
		set
		{
			class488_1 = value;
		}
	}

	internal Class488 ExtrusionSecondLightDirection
	{
		get
		{
			return class488_2;
		}
		set
		{
			class488_2 = value;
		}
	}

	internal bool ExtrusionSecondLightHarsh
	{
		get
		{
			return method_3("extrusion-second-light-harsh", NamespaceURI, defaultValue: true);
		}
		set
		{
			method_4("extrusion-second-light-harsh", NamespaceURI, value);
		}
	}

	internal int ExtrusionSecondLightLevel
	{
		get
		{
			return method_11("extrusion-second-light-level", NamespaceURI, 66);
		}
		set
		{
			method_12("extrusion-second-light-level", NamespaceURI, value);
		}
	}

	internal int ExtrusionShininess
	{
		get
		{
			return method_11("extrusion-shininess", NamespaceURI, 50);
		}
		set
		{
			method_12("extrusion-shininess", NamespaceURI, value);
		}
	}

	internal string ExtrusionSkew
	{
		get
		{
			return GetAttribute("extrusion-skew", NamespaceURI);
		}
		set
		{
			SetAttribute("extrusion-skew", NamespaceURI, value);
		}
	}

	internal int ExtrusionSpecularity
	{
		get
		{
			return method_11("extrusion-specularity", NamespaceURI, 0);
		}
		set
		{
			method_12("extrusion-specularity", NamespaceURI, value);
		}
	}

	internal Class484 ExtrusionViewpoint
	{
		get
		{
			return class484_0;
		}
		set
		{
			class484_0 = value;
		}
	}

	internal string GluePointLeavingDirections
	{
		get
		{
			return GetAttribute("glue-point-leaving-directions", NamespaceURI);
		}
		set
		{
			SetAttribute("glue-point-leaving-directions", NamespaceURI, value);
		}
	}

	internal string GluePoints
	{
		get
		{
			return GetAttribute("glue-points", NamespaceURI);
		}
		set
		{
			SetAttribute("glue-points", NamespaceURI, value);
		}
	}

	internal Enum47 GluePointType
	{
		get
		{
			return (Enum47)method_9(class467_2, "glue-point-type", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_2, "glue-point-type", NamespaceURI, (int)value);
		}
	}

	internal bool MirrorHorizontal
	{
		get
		{
			return method_3("mirror-horizontal", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("mirror-horizontal", NamespaceURI, value);
		}
	}

	internal bool MirrorVertical
	{
		get
		{
			return method_3("mirror-vertical", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("mirror-vertical", NamespaceURI, value);
		}
	}

	private int[] Modifiers
	{
		get
		{
			string namespaceURI = NamespaceURI;
			int[] defaultValue = new int[1];
			return method_36("modifiers", namespaceURI, defaultValue);
		}
		set
		{
			method_37("modifiers", NamespaceURI, value);
		}
	}

	internal double PathStretchpointX
	{
		get
		{
			return method_5("path-stretchpoint-x", NamespaceURI, double.NaN);
		}
		set
		{
			method_6("path-stretchpoint-x", NamespaceURI, value);
		}
	}

	internal double PathStretchpointY
	{
		get
		{
			return method_5("path-stretchpoint-y", NamespaceURI, double.NaN);
		}
		set
		{
			method_6("path-stretchpoint-y", NamespaceURI, value);
		}
	}

	internal string TextAreas
	{
		get
		{
			return GetAttribute("text-areas", NamespaceURI);
		}
		set
		{
			SetAttribute("text-areas", NamespaceURI, value);
		}
	}

	internal bool TextPath
	{
		get
		{
			return method_3("text-path", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("text-path", NamespaceURI, value);
		}
	}

	internal bool TextPathAllowed
	{
		get
		{
			return method_3("text-path-allowed", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("text-path-allowed", NamespaceURI, value);
		}
	}

	internal Enum97 TextPathMode
	{
		get
		{
			return (Enum97)method_9(class467_1, "text-path-mode", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_1, "text-path-mode", NamespaceURI, (int)value);
		}
	}

	internal bool TextPathSameLetterHeights
	{
		get
		{
			return method_3("text-path-same-letter-heights", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("text-path-same-letter-heights", NamespaceURI, value);
		}
	}

	internal Enum98 TextPathScale
	{
		get
		{
			return (Enum98)method_9(class467_0, "text-path-scale", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "text-path-scale", NamespaceURI, (int)value);
		}
	}

	internal double TextRotateAngle
	{
		get
		{
			return method_25("text-rotate-angle", NamespaceURI, 0.0);
		}
		set
		{
			method_26("text-rotate-angle", NamespaceURI, value);
		}
	}

	internal Dictionary<string, string> Equation => dictionary_1;

	internal string Path
	{
		get
		{
			string text = EnhancedPath;
			string text2 = "";
			foreach (KeyValuePair<string, string> item in dictionary_4)
			{
				text2 = Regex.Escape(item.Value.ToString()) + "\\b";
				text = Regex.Replace(text, text2, item.Key);
			}
			return text;
		}
	}

	internal Dictionary<string, long> FunctionSum => dictionary_2;

	internal List<string> FunctionOrder => list_0;

	internal Dictionary<string, string> Modifs => dictionary_3;

	internal string Type
	{
		get
		{
			return GetAttribute("type", NamespaceURI);
		}
		set
		{
			SetAttribute("type", NamespaceURI, value);
		}
	}

	internal Class489 ViewBox
	{
		get
		{
			return class489_0;
		}
		set
		{
			class489_0 = value;
		}
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		class488_0 = new Class488(this, "extrusion-first-light-direction", "-5 0 1");
		class488_1 = new Class488(this, "extrusion-rotation-center", "");
		class488_2 = new Class488(this, "extrusion-second-light-direction", "-5 0 1");
		class468_0 = new Class468(this, "extrusion-depth", "");
		class484_0 = new Class484(this, "extrusion-viewpoint", NamespaceURI, "3.5cm -3.5cm 25cm");
		class489_0 = new Class489(this);
		Class369[] array = method_29("equation", NamespaceURI);
		string_0 = new string[array.Length];
		int num = 0;
		Class369[] array2 = array;
		foreach (Class369 @class in array2)
		{
			Class393 class2 = (Class393)@class;
			dictionary_0.Add(class2.Name, class2.Formula);
			string_0[num++] = class2.Name;
		}
		method_38(this);
	}

	internal override void vmethod_1()
	{
	}

	public Class392(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal int[] method_36(string localName, string namespaceURI, int[] defaultValue)
	{
		if (HasAttribute(localName, namespaceURI))
		{
			string[] array = GetAttribute(localName, namespaceURI).Split();
			int[] array2 = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (int)Math.Round(Convert.ToDouble(array[i], CultureInfo.InvariantCulture));
			}
			return array2;
		}
		return defaultValue;
	}

	internal void method_37(string localName, string namespaceURI, int[] value)
	{
		string text = "";
		for (int i = 0; i < value.Length; i++)
		{
			text = text + value[i] + " ";
		}
		text = text.Substring(0, text.Length - 1);
		SetAttribute(localName, namespaceURI, text);
	}

	internal void method_38(Class392 elem)
	{
		string[] operation = new string[15]
		{
			"(", "sin[", "abs[", "sqrt[", "cos[", "tan[", "atan[", "min[", "max[", "atan2[",
			"if[", "/", "*", "+", "-"
		};
		string[] array = new string[10] { "abs", "sqrt", "sin", "cos", "tan", "atan", "min", "max", "atan2", "if" };
		double[] array2 = new double[4]
		{
			elem.ViewBox.Left,
			elem.ViewBox.Top,
			elem.ViewBox.Right,
			elem.ViewBox.Bottom
		};
		int[] modifiers = elem.Modifiers;
		double pathStretchpointX = elem.PathStretchpointX;
		double pathStretchpointY = elem.PathStretchpointY;
		double num = Math.Abs(array2[2] - array2[0]);
		double value = num / 100.0;
		double num2 = Math.Abs(array2[3] - array2[1]);
		double value2 = num2 / 100.0;
		double value3 = 1.0;
		double value4 = 1.0;
		Dictionary<string, double> dictionary = new Dictionary<string, double>();
		dictionary.Add("left", Math.Round(array2[0], 0));
		dictionary.Add("top", Math.Round(array2[1], 0));
		dictionary.Add("right", Math.Round(array2[2], 0));
		dictionary.Add("bottom", Math.Round(array2[3], 0));
		dictionary.Add("xstretch", Math.Round(pathStretchpointX, 0));
		dictionary.Add("ystretch", Math.Round(pathStretchpointY, 0));
		dictionary.Add("hasstroke", value3);
		dictionary.Add("hasfill", value4);
		dictionary.Add("width", Math.Round(num, 0));
		dictionary.Add("height", Math.Round(num2, 0));
		dictionary.Add("logwidth", Math.Round(value, 0));
		dictionary.Add("logheight", Math.Round(value2, 0));
		dictionary.Add("pi", 3.0);
		Hashtable hashtable = new Hashtable();
		foreach (KeyValuePair<string, string> item in elem.dictionary_0)
		{
			hashtable.Add(item.Key, item.Value);
		}
		int i;
		for (i = 0; i < modifiers.Length; i++)
		{
			string key = "m" + dictionary_3.Count;
			dictionary_3.Add(key, modifiers[i].ToString());
			dictionary_4[key] = '$' + i.ToString();
		}
		for (i = 0; i < string_0.Length; i++)
		{
			string key = "f" + dictionary_1.Count;
			string str = smethod_0((string)hashtable[string_0[i]], array);
			str = smethod_6(str, dictionary);
			dictionary_1.Add(key, str);
			list_0.Add(key);
			method_41(key, out dictionary_1, operation, array);
			dictionary_4[key] = "?" + string_0[i];
		}
		Dictionary<string, string> dictionary2 = new Dictionary<string, string>(dictionary_1);
		string text = "";
		foreach (KeyValuePair<string, string> item2 in dictionary2)
		{
			foreach (KeyValuePair<string, string> item3 in dictionary_4)
			{
				text = Regex.Escape(item3.Value.ToString()) + "\\b";
				dictionary_1[item2.Key] = Regex.Replace(dictionary_1[item2.Key], text, item3.Key);
			}
			dictionary_1[item2.Key] = smethod_7(dictionary_1[item2.Key], operation);
		}
		dictionary2 = new Dictionary<string, string>(dictionary_3);
		foreach (KeyValuePair<string, string> item4 in dictionary2)
		{
			dictionary_3[item4.Key] = smethod_7(dictionary_3[item4.Key], operation);
		}
		List<string> list = new List<string>(list_0);
		for (i = 0; i < list.Count; i++)
		{
			method_42(dictionary_1, list[i]);
		}
		i = 0;
		foreach (KeyValuePair<string, string> item5 in dictionary_3)
		{
			dictionary_5.Add(item5.Key, ++i);
			dictionary_2[item5.Key] = method_39(item5.Value);
		}
		i = 1;
		string[] array3 = string_4;
		foreach (string key2 in array3)
		{
			dictionary_5.Add(key2, -(i++));
		}
		for (i = 0; i < list_0.Count; i++)
		{
			dictionary_5.Add(list_0[i], -(12 + i));
			dictionary_2[list_0[i]] = method_39(dictionary_1[FunctionOrder[i]]);
		}
	}

	internal long method_39(string formula)
	{
		int i = 0;
		for (int length = formula.Length; i < length && formula[i] != ' '; i++)
		{
		}
		int num = class1151_0[formula.Substring(0, i)];
		Enum113 @enum = (Enum113)num;
		int num2 = int_0[num];
		string[] array = formula.Substring(i).Trim().Split(' ');
		long num3 = method_40(array[0]);
		long num4;
		long num5;
		if (num2 > 1)
		{
			num4 = method_40(array[1]);
			num5 = ((num2 <= 2) ? 0L : method_40(array[2]));
		}
		else
		{
			num5 = 0L;
			num4 = 0L;
		}
		double a = 0.0;
		switch (@enum)
		{
		case Enum113.const_0:
			if (num5 == 0L)
			{
				num5 = 1L;
			}
			a = num3 * num4 / num5;
			break;
		case Enum113.const_1:
			a = num3 + num4 - num5;
			break;
		case Enum113.const_3:
			a = ((num3 <= 0L) ? ((double)num5) : ((double)num4));
			break;
		case Enum113.const_4:
			a = Math.Abs(num3);
			break;
		case Enum113.const_5:
			a = Math.Atan(num4 / num3);
			break;
		case Enum113.const_7:
			a = (double)num4 * Math.Cos(num3);
			break;
		case Enum113.const_8:
			a = Math.Max(num3, num4);
			break;
		case Enum113.const_9:
			a = Math.Min(num3, num4);
			break;
		case Enum113.const_13:
			a = (double)num4 * Math.Sin(num3);
			break;
		case Enum113.const_14:
			a = Math.Sqrt(Math.Abs(num3));
			break;
		case Enum113.const_15:
			a = (double)num4 * Math.Tan(num3);
			break;
		case Enum113.const_16:
			a = num3;
			break;
		}
		return (long)Math.Round(a);
	}

	internal long method_40(string value)
	{
		if (value == "")
		{
			return long.MaxValue;
		}
		int i = 0;
		int length;
		for (length = value.Length; i < length && value[i] == ' '; i++)
		{
		}
		int num = 1;
		if (value[i] == '-')
		{
			i++;
			num = -1;
			for (; i < length && value[i] == ' '; i++)
			{
			}
		}
		else if (value[i] == '+')
		{
			for (i++; i < length && value[i] == ' '; i++)
			{
			}
		}
		long num2 = 0L;
		while (true)
		{
			if (i < length)
			{
				char c = value[i];
				if (c < '0' || c > '9')
				{
					break;
				}
				num2 = num2 * 10L + (c - 48);
				i++;
				continue;
			}
			return num * num2;
		}
		return dictionary_2[value];
	}

	internal void method_41(string variableName, out Dictionary<string, string> _functionList, string[] operation, string[] functionArr)
	{
		_functionList = new Dictionary<string, string>(dictionary_1);
		string text = "";
		string text2 = "";
		string text3 = _functionList[variableName];
		if (!smethod_2(_functionList[variableName], operation))
		{
			return;
		}
		int num = smethod_1(text3, operation);
		int num2 = text3.IndexOf(operation[num]);
		if (operation[num] == "(")
		{
			int num3 = smethod_3(text3, num2, '(', ')');
			text = "f" + _functionList.Count;
			text2 = text3.Substring(num2 + 1, num3 - num2 - 1);
			list_0.Add(text);
			_functionList[text] = text2;
			_functionList[variableName] = text3.Remove(num2, num3 - num2 + 1).Insert(num2, text);
			method_41(variableName, out _functionList, operation, functionArr);
			method_41(text, out _functionList, operation, functionArr);
		}
		else if (Array.IndexOf(functionArr, operation[num].Substring(0, operation[num].Length - 1)) > -1)
		{
			int num4 = num2 + operation[num].Length - 1;
			int num5 = smethod_3(text3, num4, '[', ']');
			string text4 = text3.Substring(num4 + 1, num5 - num4 - 1);
			string[] array = text4.Split(',');
			string text5 = "";
			for (int i = 0; i < array.Length; i++)
			{
				text = "f" + _functionList.Count;
				text2 = array[i];
				text5 = text5 + text + ",";
				list_0.Add(text);
				_functionList[text] = text2;
				method_41(text, out _functionList, operation, functionArr);
			}
			text5 = text5.Substring(0, text5.Length - 1);
			text = "f" + _functionList.Count;
			text2 = operation[num] + text5 + "]";
			list_0.Add(text);
			_functionList[text] = text2;
			method_41(text, out _functionList, operation, functionArr);
			_functionList[variableName] = text3.Remove(num2, num5 - num2 + 1).Insert(num2, text);
			method_41(variableName, out _functionList, operation, functionArr);
		}
		else
		{
			int num6 = smethod_4(num2, text3, operation);
			int num7 = smethod_5(num2, text3, operation);
			text = "f" + _functionList.Count;
			text2 = text3.Substring((num6 != -1) ? (num6 + 1) : 0, num7 - num6 - 1);
			list_0.Add(text);
			_functionList[text] = text2;
			_functionList[variableName] = text3.Remove((num6 != -1) ? (num6 + 1) : 0, num7 - num6 - 1).Insert(num6 + 1, text);
			method_41(variableName, out _functionList, operation, functionArr);
			method_41(text, out _functionList, operation, functionArr);
		}
	}

	internal static string smethod_0(string str, string[] funtionArr)
	{
		StringBuilder stringBuilder = new StringBuilder(str);
		for (int i = 0; i < funtionArr.Length; i++)
		{
			int num = str.IndexOf(funtionArr[i] + '(');
			int num2 = num + funtionArr[i].Length;
			if (num > -1)
			{
				int index = smethod_3(str, num2, '(', ')');
				stringBuilder[num2] = '[';
				stringBuilder[index] = ']';
			}
			str = stringBuilder.ToString();
		}
		return str;
	}

	internal static int smethod_1(string str, string[] operation)
	{
		int num = operation.Length + 1;
		int num2 = str.Length;
		for (int i = 0; i < operation.Length; i++)
		{
			int num3 = str.IndexOf(operation[i]);
			if (num3 < num2 && num3 > -1 && i < num)
			{
				num2 = num3;
				num = i;
			}
		}
		return num;
	}

	internal static bool smethod_2(string expression, string[] operation)
	{
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < operation.Length)
			{
				if (expression.IndexOf(operation[num2]) > -1)
				{
					num++;
				}
				if (num > 1)
				{
					break;
				}
				num2++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal static int smethod_3(string str, int openBracketIndex, char openBracket, char closeBracket)
	{
		int num = 0;
		int num2 = openBracketIndex + 1;
		while (true)
		{
			if (num2 < str.Length)
			{
				if (str[num2] == openBracket)
				{
					num++;
				}
				if (str[num2] == closeBracket)
				{
					if (num == 0)
					{
						break;
					}
					num--;
				}
				num2++;
				continue;
			}
			return 0;
		}
		return num2;
	}

	internal static int smethod_4(int currentPosition, string text, string[] operation)
	{
		int num = -1;
		for (int i = 0; i < operation.Length; i++)
		{
			int num2 = text.IndexOf(operation[i]);
			if (num2 > -1 && num2 > num && num2 < currentPosition)
			{
				num = num2;
			}
		}
		return num;
	}

	internal static int smethod_5(int currentPosition, string text, string[] operation)
	{
		int num = text.Length;
		for (int i = 0; i < operation.Length; i++)
		{
			int num2 = text.IndexOf(operation[i]);
			if (num2 > -1 && num2 < num && num2 > currentPosition)
			{
				num = num2;
			}
		}
		return num;
	}

	internal static string smethod_6(string str, Dictionary<string, double> constants)
	{
		foreach (KeyValuePair<string, double> constant in constants)
		{
			str = str.Replace(constant.Key, constant.Value.ToString().Replace(',', '.'));
		}
		return str;
	}

	internal static string smethod_7(string expression, string[] operation)
	{
		expression = expression.Trim();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("*", "*/");
		dictionary.Add("/", "*/");
		dictionary.Add("+", "+-");
		dictionary.Add("-", "+-");
		dictionary.Add("abs[", "abs");
		dictionary.Add("sqrt[", "sqrt");
		dictionary.Add("sin[", "sin");
		dictionary.Add("cos[", "cos");
		dictionary.Add("tan[", "tan");
		dictionary.Add("atan[", "at2");
		dictionary.Add("min[", "min");
		dictionary.Add("max[", "max");
		dictionary.Add("atan2[", "at2");
		dictionary.Add("if[", "?:");
		int num = -1;
		string result = "";
		int num2 = -1;
		for (int i = 1; i < operation.Length; i++)
		{
			num2 = expression.IndexOf(operation[i]);
			if (num2 > -1)
			{
				num = i;
				switch (operation[num])
				{
				case "*":
					result = dictionary[operation[num]] + " " + expression.Substring(0, num2).Trim() + " " + expression.Substring(num2 + 1, expression.Length - num2 - 1).Trim() + " 1";
					break;
				case "/":
					result = dictionary[operation[num]] + " " + expression.Substring(0, num2).Trim() + " 1 " + expression.Substring(num2 + 1, expression.Length - num2 - 1).Trim();
					break;
				case "+":
					result = dictionary[operation[num]] + " " + expression.Substring(0, num2).Trim() + " " + expression.Substring(num2 + 1, expression.Length - num2 - 1).Trim() + " 0";
					break;
				case "-":
					result = ((num2 != 0) ? (dictionary[operation[num]] + " " + expression.Substring(0, num2).Trim() + " 0 " + expression.Substring(num2 + 1, expression.Length - num2 - 1).Trim()) : ((expression.Substring(1, 1) == "f" || expression.Substring(1, 1) == "m") ? (dictionary[operation[num]] + " 0 0 " + expression.Substring(num2 + 1, expression.Length - num2 - 1).Trim()) : ("val " + expression.Trim())));
					break;
				case "abs[":
					result = dictionary[operation[num]] + " " + expression.Substring(4, expression.Length - 5).Trim();
					break;
				case "sqrt[":
					result = dictionary[operation[num]] + " " + expression.Substring(5, expression.Length - 6).Trim();
					break;
				case "sin[":
					result = dictionary[operation[num]] + " " + expression.Substring(4, expression.Length - 5).Trim() + " 1";
					break;
				case "cos[":
					result = dictionary[operation[num]] + " " + expression.Substring(4, expression.Length - 5).Trim() + " 1";
					break;
				case "tan[":
					result = dictionary[operation[num]] + " " + expression.Substring(4, expression.Length - 5).Trim() + " 1";
					break;
				case "atan[":
					result = dictionary[operation[num]] + " " + expression.Substring(4, expression.Length - 6).Trim() + " 1";
					break;
				case "min[":
				{
					string[] array = expression.Remove(0, 4).Remove(expression.Remove(0, 4).Length - 1, 1).Split(',');
					result = dictionary[operation[num]] + " " + array[0].Trim() + " " + array[1].Trim();
					break;
				}
				case "max[":
				{
					string[] array = expression.Remove(0, 4).Remove(expression.Remove(0, 4).Length - 1, 1).Split(',');
					result = dictionary[operation[num]] + " " + array[0].Trim() + " " + array[1].Trim();
					break;
				}
				case "atan2[":
				{
					string[] array = expression.Remove(0, 6).Remove(expression.Remove(0, 6).Length - 1, 1).Split(',');
					result = dictionary[operation[num]] + " " + array[0].Trim() + " " + array[1].Trim();
					break;
				}
				case "if[":
				{
					string[] array = expression.Remove(0, 3).Remove(expression.Remove(0, 3).Length - 1, 1).Split(',');
					result = dictionary[operation[num]] + " " + array[0].Trim() + " " + array[1].Trim() + " " + array[2].Trim();
					break;
				}
				}
			}
		}
		if (num == -1)
		{
			result = "val " + expression.Trim();
		}
		return result;
	}

	internal void method_42(Dictionary<string, string> functions, string elemname)
	{
		int num = -1;
		int num2 = -1;
		string[] array = functions[elemname].Split(' ');
		num = list_0.IndexOf(elemname);
		for (int i = 1; i < array.Length; i++)
		{
			if (list_0.IndexOf(array[i]) > -1)
			{
				num2 = list_0.IndexOf(array[i]);
				if (num2 > num)
				{
					list_0.RemoveAt(num2);
					list_0.Insert(num, array[i]);
					method_42(functions, array[i]);
				}
			}
		}
	}
}
