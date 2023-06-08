using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using ns218;
using ns224;
using ns233;
using ns234;
using ns235;
using ns271;
using ns309;
using ns310;
using ns312;
using ns318;
using ns73;
using ns76;
using ns84;

namespace ns91;

internal class Class7192
{
	private class Class7193
	{
		internal string string_0 = string.Empty;

		internal float[] float_0 = new float[0];

		public Class7193(string name, float[] values)
		{
			string_0 = name;
			float_0 = values;
		}
	}

	internal enum Enum977
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10,
		const_11,
		const_12,
		const_13,
		const_14,
		const_15,
		const_16,
		const_17,
		const_18,
		const_19
	}

	internal class Class7194
	{
		internal Enum977 enum977_0 = Enum977.const_19;

		internal Hashtable hashtable_0 = new Hashtable();

		internal Hashtable hashtable_1 = new Hashtable();

		public Class7194(Enum977 commandType, Hashtable points)
		{
			enum977_0 = commandType;
			hashtable_0 = points;
		}

		public Class7194()
		{
		}
	}

	private const string string_0 = "xMaxYMax";

	private const string string_1 = "xMaxYMid";

	private const string string_2 = "xMaxYMin";

	private const string string_3 = "xMidYMax";

	private const string string_4 = "xMidYMid";

	private const string string_5 = "xMidYMin";

	private const string string_6 = "xMinYMax";

	private const string string_7 = "xMinYMid";

	private const string string_8 = "xMinYMin";

	private const string string_9 = "none";

	private const float float_0 = 1.3f;

	private const string string_10 = "Times-Roman";

	private const float float_1 = 0.01f;

	private const float float_2 = 1.55f;

	internal static float float_3 = 10f;

	private static string string_11 = ",x,y,width,height,fill,stroke,stroke-width,font-size,font-family,font-weight,transform,opacity,fill-opacity,stroke-opacity,cap-height,rotate,text-anchor,x,y,glyph-orientation-horizontal,glyph-orientation-vertical,bounding-box-width,bounding-box-height,view-clip-id,clip-path,";

	private Hashtable hashtable_0 = new Hashtable();

	private Hashtable hashtable_1 = new Hashtable();

	private Hashtable hashtable_2 = new Hashtable();

	private Hashtable hashtable_3 = new Hashtable();

	private Hashtable hashtable_4 = new Hashtable();

	private Class7191 class7191_0 = new Class7191();

	private int int_0;

	private float float_4;

	private float float_5;

	private Interface76 interface76_0;

	private Hashtable hashtable_5 = new Hashtable();

	private Dictionary<string, Hashtable> dictionary_0 = new Dictionary<string, Hashtable>();

	private float float_6;

	private float float_7;

	private Interface384 interface384_0 = new Class7202();

	private ArrayList arrayList_0 = new ArrayList(new int[9] { 10, 18, 6, 4, 1, 14, 12, 16, 8 });

	private ArrayList arrayList_1 = new ArrayList(new char[20]
	{
		'M', 'm', 'Z', 'z', 'L', 'l', 'H', 'h', 'V', 'v',
		'C', 'c', 'S', 's', 'Q', 'q', 'T', 't', 'A', 'a'
	});

	private ArrayList arrayList_2 = new ArrayList(new int[8] { 9, 10, 11, 12, 13, 14, 15, 16 });

	private ArrayList arrayList_3 = new ArrayList(new int[2] { 0, 1 });

	private Hashtable hashtable_6 = new Hashtable();

	private Hashtable hashtable_7 = new Hashtable();

	private string[] string_12 = new string[1] { "ArialCustom" };

	private float float_8;

	private static float float_9 = 0.8f;

	private Regex regex_0 = new Regex("\\s*(?<style>normal|italic|oblique)?\\s*(?<variant>normal|small\\-caps)?\\s*(?<weight>normal|bold|100|200|300|400|500|600|700|800|900)?\\s*(?<size>\\d+(px|%|pt|em|mm|in|cm)?)?\\s*(?<height>/+\\d+(px|%|pt|em|mm|in|cm)?)?\\s*(?<family>[^,]*\\s*,*)*;?", RegexOptions.IgnoreCase | RegexOptions.Multiline);

	private float float_10 = 10f;

	private string string_13 = "Arial";

	private ArrayList arrayList_4 = new ArrayList(new string[5] { "path", "circle", "rect", "ellipse", "polygon" });

	private Hashtable hashtable_8 = new Hashtable();

	private ArrayList arrayList_5 = new ArrayList(new string[2] { "x", "width" });

	private ArrayList arrayList_6 = new ArrayList(new string[2] { "y", "height" });

	private ArrayList arrayList_7 = new ArrayList(new string[1] { "xy" });

	private void method_0(Class7132 svgArea, bool isUseProperty)
	{
		if (svgArea.string_0 == "style")
		{
			string text = string.Empty;
			foreach (DictionaryEntry item in svgArea.hashtable_4)
			{
				text += ((Class7132)item.Value).string_1;
			}
			class7191_0.method_0(text);
		}
		foreach (DictionaryEntry item2 in svgArea.hashtable_4)
		{
			method_0((Class7132)item2.Value, isUseProperty);
		}
	}

	private void method_1(Class7132 svgNode)
	{
		if (svgNode.string_0 == "style")
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DictionaryEntry item in svgNode.hashtable_4)
			{
				stringBuilder.Append(((Class7132)item.Value).string_1);
			}
			Class3730 @class = new Class3730();
			Interface69 @interface = @class.method_0(null, new Class3723(interface384_0));
			interface76_0 = @interface.imethod_2(stringBuilder.ToString());
			return;
		}
		if (svgNode.string_0 == "link")
		{
			if (svgNode.hashtable_0.ContainsKey("type") && (string)svgNode.hashtable_0["type"] == "text/css" && svgNode.hashtable_0.ContainsKey("rel") && (string)svgNode.hashtable_0["rel"] == "stylesheet" && svgNode.hashtable_0.ContainsKey("href"))
			{
				Class4258 class2 = interface384_0.imethod_0(this, new EventArgs1((string)svgNode.hashtable_0["href"]));
				string @string = Encoding.ASCII.GetString(class2.Data);
				Class3730 class3 = new Class3730();
				Interface69 interface2 = class3.method_0(null, new Class3723(interface384_0));
				interface76_0 = interface2.imethod_2(@string);
			}
			return;
		}
		foreach (DictionaryEntry item2 in svgNode.hashtable_4)
		{
			if (item2.Value is Class7132 svgNode2)
			{
				method_1(svgNode2);
			}
		}
	}

	private void method_2(Class7132 svgArea, SizeF size, bool isUseProperty)
	{
		if (svgArea.string_0 == "defs")
		{
			return;
		}
		string empty = string.Empty;
		string empty2 = string.Empty;
		ArrayList arrayList = new ArrayList(new string[3] { "svg", "g", "use" });
		if (svgArea.hashtable_0.ContainsKey("xlink:href"))
		{
			string text = svgArea.hashtable_0["xlink:href"].ToString();
			if (arrayList.Contains(svgArea.string_0) && text.StartsWith("#"))
			{
				text = text.Remove(0, 1);
				dictionary_0[text] = svgArea.hashtable_0;
			}
		}
		if (svgArea.hashtable_0.ContainsKey("id"))
		{
			string key = svgArea.hashtable_0["id"].ToString();
			if (dictionary_0.ContainsKey(key))
			{
				Hashtable hashtable = dictionary_0[key];
				foreach (DictionaryEntry item in hashtable)
				{
					if (!svgArea.hashtable_0.ContainsKey(item.Key))
					{
						svgArea.hashtable_0[item.Key] = item.Value;
					}
				}
			}
		}
		if (svgArea.hashtable_0.ContainsKey("width") && arrayList.Contains(svgArea.string_0))
		{
			svgArea.hashtable_0["bounding-box-width"] = svgArea.hashtable_0["width"].ToString();
		}
		if (svgArea.hashtable_0.ContainsKey("height") && arrayList.Contains(svgArea.string_0))
		{
			svgArea.hashtable_0["bounding-box-height"] = svgArea.hashtable_0["height"].ToString();
		}
		if (svgArea.string_0 == "text" && !svgArea.hashtable_0.ContainsKey("id") && !svgArea.hashtable_0.ContainsKey("fill") && !svgArea.hashtable_0.ContainsKey("stroke"))
		{
			svgArea.hashtable_0.Add("fill", "#000000");
		}
		foreach (DictionaryEntry item2 in svgArea.hashtable_0)
		{
			empty = item2.Key.ToString();
			empty2 = item2.Value.ToString();
			if (!(item2.Key.ToString() == "style") && !(item2.Key.ToString() == "class"))
			{
				if (Class5964.Contains(string_11, "," + item2.Key.ToString() + ",", ignoreCase: true))
				{
					smethod_0(svgArea, empty, empty2, size, isUseProperty);
				}
				continue;
			}
			string text2 = string.Empty;
			if (item2.Key.ToString() == "style")
			{
				text2 = item2.Value.ToString();
			}
			else if (item2.Key.ToString() == "class")
			{
				text2 = class7191_0.method_1(item2.Value.ToString());
			}
			string[] array = text2.Split(new string[1] { ";" }, StringSplitOptions.RemoveEmptyEntries);
			string[] array2 = array;
			foreach (string text3 in array2)
			{
				string[] array3 = text3.Split(new string[1] { ":" }, StringSplitOptions.RemoveEmptyEntries);
				if (array3.Length >= 2)
				{
					empty = array3[0].Trim();
					empty2 = array3[1].Trim();
					if (Class5964.Contains(string_11, "," + empty + ",", ignoreCase: true))
					{
						smethod_0(svgArea, empty, empty2, size, isUseProperty);
					}
				}
			}
		}
		foreach (DictionaryEntry item3 in svgArea.hashtable_4)
		{
			method_2((Class7132)item3.Value, size, isUseProperty);
		}
	}

	private static void smethod_0(Class7132 svgArea, string styleKey, string styleValue, SizeF size, bool isUsePropery)
	{
		foreach (DictionaryEntry item in svgArea.hashtable_4)
		{
			Class7132 @class = (Class7132)item.Value;
			switch (styleKey)
			{
			case "transform":
				if (@class.hashtable_0.ContainsKey("transform"))
				{
					string text = @class.hashtable_0["transform"].ToString();
					@class.hashtable_0[styleKey] = styleValue + " " + text;
				}
				else
				{
					@class.hashtable_0[styleKey] = styleValue;
				}
				break;
			default:
				if (!((Class7132)item.Value).hashtable_0.ContainsKey(styleKey) || isUsePropery)
				{
					if (isUsePropery && ((Class7132)item.Value).hashtable_0.ContainsKey(styleKey))
					{
						((Class7132)item.Value).hashtable_0.Remove(styleKey);
					}
					((Class7132)item.Value).hashtable_0.Add(styleKey, styleValue);
				}
				break;
			case "x":
			case "y":
				if ((svgArea.string_0 == "g" || svgArea.string_0 == "svg" || svgArea.string_0 == "symbol" || svgArea.string_0 == "image") && !((Class7132)item.Value).hashtable_0.ContainsKey(styleKey))
				{
					((Class7132)item.Value).hashtable_0.Add(styleKey, styleValue);
				}
				break;
			case "clip-path":
				break;
			}
			if (styleKey == "bounding-box-width")
			{
				((Class7132)item.Value).hashtable_0["bounding-box-width"] = styleValue;
			}
			if (styleKey == "bounding-box-height")
			{
				((Class7132)item.Value).hashtable_0["bounding-box-height"] = styleValue;
			}
		}
	}

	private void method_3(Class7132 svgArea)
	{
		try
		{
			foreach (DictionaryEntry item in svgArea.hashtable_4)
			{
				Class7132 @class = (Class7132)item.Value;
				if (@class.string_0 == "font")
				{
					method_4(@class);
				}
				else if (@class.hashtable_0.ContainsKey("id") && @class.string_0 == "altGlyphDef")
				{
					foreach (DictionaryEntry item2 in @class.hashtable_4)
					{
						Class7132 class2 = (Class7132)item2.Value;
						if (class2.string_0 == "glyphRef")
						{
							string text = class2.hashtable_0["xlink:href"].ToString();
							if (text.StartsWith("#"))
							{
								text = text.Remove(0, 1);
							}
							if (class2.hashtable_0.ContainsKey("xlink:href") && !hashtable_2.ContainsKey(@class.hashtable_0["id"].ToString()))
							{
								hashtable_2.Add(@class.hashtable_0["id"].ToString(), text);
							}
						}
					}
				}
				else if (@class.hashtable_0.ContainsKey("id"))
				{
					if (@class.string_0 == "clipPath")
					{
						hashtable_3.Add(@class.hashtable_0["id"].ToString(), item.Value);
					}
					else
					{
						hashtable_0.Add(@class.hashtable_0["id"].ToString(), item.Value);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void method_4(Class7132 svgNode)
	{
		new Hashtable();
		Class7104 @class = new Class7104();
		foreach (DictionaryEntry item in svgNode.hashtable_4)
		{
			Class7132 class2 = (Class7132)item.Value;
			if (class2.string_0 == "font-face")
			{
				if (class2.hashtable_0.ContainsKey("font-family"))
				{
					@class.string_0 = class2.hashtable_0["font-family"].ToString();
				}
				if (class2.hashtable_0.ContainsKey("units-per-em"))
				{
					@class.string_1 = class2.hashtable_0["units-per-em"].ToString();
				}
			}
			if (class2.string_0 == "glyph" || class2.string_0 == "missing-glyph")
			{
				string text = string.Empty;
				string value = string.Empty;
				if (class2.hashtable_0.ContainsKey("unicode"))
				{
					text = class2.hashtable_0["unicode"].ToString();
				}
				if (class2.hashtable_0.ContainsKey("d"))
				{
					value = class2.hashtable_0["d"].ToString();
				}
				if (class2.hashtable_0.ContainsKey("id"))
				{
					class2.hashtable_0["id"].ToString();
				}
				if (class2.string_0 == "missing-glyph")
				{
					text = "missing-glyph";
				}
				if (!string.IsNullOrEmpty(text) && !@class.hashtable_1.ContainsKey(text))
				{
					@class.hashtable_1.Add(text, value);
				}
			}
		}
		if (!string.IsNullOrEmpty(@class.string_0))
		{
			hashtable_1.Add(@class.string_0, @class);
		}
	}

	public Class7192()
	{
	}

	public Class7192(Interface384 resourceLoadingCallback)
	{
		interface384_0 = resourceLoadingCallback;
	}

	public Class6216 method_5(string svgAreaBody)
	{
		Class7167 @class = Class7188.smethod_1(svgAreaBody);
		method_0(@class.class7132_0, isUseProperty: false);
		Class6213 class2 = new Class6213();
		SizeF size = new SizeF(0f, 0f);
		method_2(@class.class7132_0, size, isUseProperty: false);
		method_1(@class.class7132_0);
		method_6(@class.class7132_0, class2, ref size);
		if (size.Width == 0f || size.Height == 0f)
		{
			Class6185 class3 = new Class6185();
			RectangleF rectangleF = class3.method_2(class2);
			if (size.Width == 0f)
			{
				size.Width = rectangleF.Right;
			}
			if (size.Height == 0f)
			{
				size.Height = rectangleF.Bottom;
			}
		}
		Class6216 class4 = new Class6216(size.Width, size.Height);
		if (class2.RenderTransform == null)
		{
			class2.RenderTransform = new Class6002();
		}
		class2.RenderTransform.method_9(new Class6002(1f, 0f, 0f, -1f, 0f, size.Height), MatrixOrder.Prepend);
		class4.Add(class2);
		return class4;
	}

	private void method_6(Class7132 svgArea, Class6213 canvas, ref SizeF size)
	{
		try
		{
			if (svgArea.string_0 == "svg")
			{
				if (svgArea.hashtable_0.ContainsKey("width") && method_65(svgArea.hashtable_0["width"].ToString(), "width", svgArea) > size.Width)
				{
					size.Width = method_65(svgArea.hashtable_0["width"].ToString(), "width", svgArea);
				}
				else if (size.Width <= 0f)
				{
					size.Width = Class7167.float_1;
				}
				if (svgArea.hashtable_0.ContainsKey("height") && method_65(svgArea.hashtable_0["height"].ToString(), "height", svgArea) > size.Height)
				{
					size.Height = method_65(svgArea.hashtable_0["height"].ToString(), "height", svgArea);
				}
				else if (size.Height <= 0f)
				{
					size.Height = Class7167.float_0;
				}
				if (svgArea.hashtable_0.ContainsKey("viewBox"))
				{
					string preserveRatio = "xMidYMid";
					if (svgArea.hashtable_0.Contains("preserveAspectRatio"))
					{
						preserveRatio = (string)svgArea.hashtable_0["preserveAspectRatio"];
					}
					string[] array = svgArea.hashtable_0["viewBox"].ToString().Split(new string[2] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
					if (array.Length == 4)
					{
						float num = (int)method_65(array[0], string.Empty, svgArea);
						float num2 = (int)method_65(array[1], string.Empty, svgArea);
						float_6 = (float)Convert.ToDecimal(array[2], CultureInfo.InvariantCulture);
						float_7 = (float)Convert.ToDecimal(array[3], CultureInfo.InvariantCulture);
						float[] vb = new float[4] { num, num2, float_6, float_7 };
						Class6002 tx = smethod_3(vb, size.Width, size.Height, preserveRatio);
						if (canvas.RenderTransform == null)
						{
							canvas.RenderTransform = new Class6002();
						}
						canvas.RenderTransform.method_9(tx, MatrixOrder.Append);
					}
				}
				if (svgArea.hashtable_0.ContainsKey("style") && svgArea.hashtable_2.Count == 0)
				{
					string text = method_51(svgArea.hashtable_0["style"].ToString());
					string[] array2 = text.Split(new string[1] { ";" }, StringSplitOptions.RemoveEmptyEntries);
					string[] array3 = array2;
					foreach (string text2 in array3)
					{
						string[] array4 = text2.Split(':');
						if (!svgArea.hashtable_2.ContainsKey(array4[0].Trim()))
						{
							svgArea.hashtable_2.Add(array4[0].Trim(), array4[1].Trim());
						}
					}
					if (svgArea.hashtable_2.ContainsKey("position") && svgArea.hashtable_2["position"].ToString() == "absolute")
					{
						if (svgArea.hashtable_2.ContainsKey("left"))
						{
							method_65(svgArea.hashtable_2["left"].ToString(), "left", svgArea);
						}
						if (svgArea.hashtable_2.ContainsKey("top"))
						{
							method_65(svgArea.hashtable_2["top"].ToString(), "top", svgArea);
						}
					}
				}
			}
			bool flag = false;
			for (int j = 0; j < svgArea.hashtable_4.Count; j++)
			{
				flag = false;
				Class7132 @class = (Class7132)svgArea.hashtable_4[j];
				if (@class.string_0 == "pattern" || (@class.hashtable_0.ContainsKey("visibility") && (Convert.ToString(@class.hashtable_0["visibility"]) == "hidden" || Convert.ToString(@class.hashtable_0["visibility"]) == "collapse")))
				{
					continue;
				}
				if (@class.string_0 == "use" && @class.hashtable_0.ContainsKey("xlink:href") && hashtable_0.ContainsKey(@class.hashtable_0["xlink:href"].ToString().Replace("#", string.Empty)))
				{
					string key = @class.hashtable_0["xlink:href"].ToString().Replace("#", string.Empty);
					Class7132 class2 = (Class7132)hashtable_0[key];
					Class7132 class3 = (Class7132)class2.Clone();
					if (class3.string_0 == "rect" && !class3.hashtable_0.ContainsKey("x"))
					{
						class3.hashtable_0.Add("x", 0);
					}
					if (class3.string_0 == "rect" && !class3.hashtable_0.ContainsKey("y"))
					{
						class3.hashtable_0.Add("y", 0);
					}
					@class.hashtable_4.Add(@class.hashtable_4.Count, class3);
					if (@class.hashtable_0.ContainsKey("width") && !@class.hashtable_0.ContainsKey("bounding-box-width"))
					{
						@class.hashtable_0.Add("bounding-box-width", @class.hashtable_0["width"].ToString());
					}
					if (@class.hashtable_0.ContainsKey("height") && !@class.hashtable_0.ContainsKey("bounding-box-height"))
					{
						@class.hashtable_0.Add("bounding-box-width", @class.hashtable_0["height"].ToString());
					}
					float num3 = 0f;
					float num4 = 0f;
					if (@class.hashtable_0.ContainsKey("x"))
					{
						num3 = method_65(@class.hashtable_0["x"].ToString(), string.Empty, svgArea);
					}
					if (@class.hashtable_0.ContainsKey("y"))
					{
						num4 = method_65(@class.hashtable_0["y"].ToString(), string.Empty, svgArea);
					}
					if (num3 != 0f || num4 != 0f)
					{
						string text3 = " translate(" + num3.ToString(CultureInfo.InvariantCulture) + " " + num4.ToString(CultureInfo.InvariantCulture) + ")";
						if (@class.hashtable_0.ContainsKey("transform"))
						{
							Hashtable hashtable;
							object key2;
							(hashtable = @class.hashtable_0)[key2 = "transform"] = string.Concat(hashtable[key2], text3);
						}
						else
						{
							@class.hashtable_0.Add("transform", text3);
						}
					}
					foreach (DictionaryEntry item in @class.hashtable_0)
					{
						if (!(item.Key.ToString() == "x") && !(item.Key.ToString() == "y"))
						{
							if (item.Key.ToString() == "fill" && class3.hashtable_0.ContainsKey(item.Key.ToString()))
							{
								class3.hashtable_0.Remove(item.Key.ToString());
							}
							if (item.Key.ToString() == "stroke" && class3.hashtable_0.ContainsKey(item.Key.ToString()))
							{
								class3.hashtable_0.Remove(item.Key.ToString());
							}
							if (!class3.hashtable_0.ContainsKey(item.Key.ToString()))
							{
								class3.hashtable_0.Add(item.Key.ToString(), item.Value.ToString());
							}
						}
					}
					@class = class3;
					flag = true;
					method_2(@class, size, isUseProperty: true);
				}
				if (@class.string_0 == "tref" && @class.hashtable_0.ContainsKey("xlink:href") && hashtable_0.ContainsKey(@class.hashtable_0["xlink:href"].ToString().Replace("#", string.Empty)))
				{
					Class7132 class4 = (Class7132)((DictionaryEntry)hashtable_0[@class.hashtable_0["xlink:href"].ToString().Replace("#", string.Empty)]).Value;
					Class7132 class5 = (Class7132)class4.Clone();
					foreach (DictionaryEntry item2 in @class.hashtable_0)
					{
						if (!class5.hashtable_0.ContainsKey(item2.Key) && item2.Key.ToString() != "xlink:href")
						{
							class5.hashtable_0.Add(item2.Key.ToString(), item2.Value.ToString());
						}
					}
					if (@class.class7132_0.string_0 == "text")
					{
						foreach (DictionaryEntry item3 in @class.class7132_0.hashtable_0)
						{
							if (!class5.hashtable_0.ContainsKey(item3.Key) && item3.Key.ToString() != "xlink:href")
							{
								class5.hashtable_0.Add(item3.Key.ToString(), item3.Value.ToString());
							}
						}
					}
					method_2(class5, size, isUseProperty: true);
					@class = class5;
				}
				if (!(@class.string_0 == "clipPath") && !(@class.string_0 == "clipPath".ToLower()))
				{
					if (@class.string_0 == "defs")
					{
						method_3(@class);
					}
					else
					{
						if (@class.string_0 == "style")
						{
							continue;
						}
						Class6213 class6 = canvas;
						if (@class.hashtable_0.ContainsKey("clip-path") && @class.string_0 == "g")
						{
							Class6213 class7 = new Class6213();
							class7.Clip = method_62(size, @class);
							canvas.Add(class7);
							if (class7.Clip != null && @class.hashtable_0.ContainsKey("transform"))
							{
								class7.Clip.RenderTransform = Class6161.smethod_1(method_25(@class.hashtable_0["transform"].ToString(), size));
							}
							canvas = class7;
						}
						AddNode(@class, canvas, size, flag, translateAxis: true);
						method_6(@class, canvas, ref size);
						canvas = class6;
					}
				}
				else
				{
					hashtable_3.Add(@class.hashtable_0["id"], @class);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	internal static PointF[] smethod_1(float[] curve, int ratio)
	{
		PointF[] array = new PointF[ratio];
		for (int i = 0; i < ratio; i++)
		{
			float ratio2 = (float)i / (float)(ratio - 1);
			ref PointF reference = ref array[i];
			reference = Class7120.smethod_6(new PointF(curve[0], curve[1]), new PointF(curve[2], curve[3]), new PointF(curve[4], curve[5]), new PointF(curve[6], curve[7]), ratio2);
		}
		return array;
	}

	private RectangleF method_7(PointF point, RectangleF rectangleBound)
	{
		if (point.X > rectangleBound.X)
		{
			float num = point.X - rectangleBound.X;
			if (num > rectangleBound.Width)
			{
				rectangleBound.Width = num;
			}
		}
		if (point.Y > rectangleBound.Y)
		{
			float num2 = point.Y - rectangleBound.Y;
			if (num2 > rectangleBound.Height)
			{
				rectangleBound.Height = num2;
			}
		}
		if (point.X < rectangleBound.X)
		{
			float num3 = rectangleBound.X - point.X;
			rectangleBound.X -= num3;
			rectangleBound.Width += num3;
		}
		if (point.Y < rectangleBound.Y)
		{
			float num4 = rectangleBound.Y - point.Y;
			rectangleBound.Y -= num4;
			rectangleBound.Height += num4;
		}
		return rectangleBound;
	}

	private static RectangleF smethod_2(Class6204 node)
	{
		Class6185 @class = new Class6185();
		return @class.method_2(node);
	}

	private RectangleF method_8(Class7132 svgNode, SizeF size)
	{
		RectangleF result = default(RectangleF);
		switch (svgNode.string_0)
		{
		case "rect":
		{
			Class6218 node4 = method_15(svgNode, size, translateAxis: true);
			result.Size = smethod_2(node4).Size;
			break;
		}
		case "polyline":
		{
			Class6217 node3 = method_22(svgNode, size, closePath: true);
			result.Size = smethod_2(node3).Size;
			break;
		}
		case "polygon":
		{
			Class6217 node2 = method_22(svgNode, size, closePath: true);
			result.Size = smethod_2(node2).Size;
			break;
		}
		case "path":
		{
			Class6217 node = method_29(svgNode, size, translateAxis: false);
			result.Size = smethod_2(node).Size;
			break;
		}
		case "ellipse":
		{
			Class6217 class2 = new Class6217();
			class2.Add(method_61(svgNode, size));
			result.Size = smethod_2(class2).Size;
			break;
		}
		case "circle":
		{
			Class6217 @class = new Class6217();
			@class.Add(method_60(svgNode, useTagShape: true, size));
			result.Size = smethod_2(@class).Size;
			break;
		}
		}
		return result;
	}

	private bool method_9(Class7132 node)
	{
		if (!node.hashtable_0.ContainsKey("style"))
		{
			return true;
		}
		string text = node.hashtable_0["style"].ToString();
		string[] array = text.Split(new string[1] { ";" }, StringSplitOptions.RemoveEmptyEntries);
		string[] array2 = array;
		int num = 0;
		while (true)
		{
			if (num < array2.Length)
			{
				string text2 = array2[num];
				string[] array3 = text2.Split(new string[1] { ":" }, StringSplitOptions.RemoveEmptyEntries);
				string text3 = array3[0].Trim();
				string text4 = string.Empty;
				if (array3.Length > 1)
				{
					text4 = array3[1].Trim();
				}
				if (text3 == "media" && !text4.Contains("all") && !text4.Contains("print") && !text4.Contains("screen"))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private void AddNode(Class7132 svgNode, Class6213 canvas, SizeF size, bool useTagShape, bool translateAxis)
	{
		try
		{
			if (svgNode.hashtable_0.ContainsKey("id"))
			{
				string key = svgNode.hashtable_0["id"].ToString().Replace("#", string.Empty);
				if (!hashtable_0.ContainsKey(key))
				{
					hashtable_0.Add(key, svgNode);
				}
			}
			if (!method_9(svgNode))
			{
				return;
			}
			switch (svgNode.string_0)
			{
			case "a":
				method_17(svgNode);
				break;
			case "circle":
				method_19(svgNode, canvas, size, useTagShape);
				break;
			case "ellipse":
				method_20(svgNode, canvas, size);
				break;
			case "image":
				AddImage(svgNode, canvas, size);
				break;
			case "line":
				method_37(svgNode, canvas, size);
				break;
			case "foreignObject":
				method_36(svgNode);
				break;
			case "path":
				method_30(svgNode, canvas, size, translateAxis: true);
				break;
			case "polygon":
				method_23(svgNode, canvas, size, closePath: true);
				break;
			case "polyline":
				method_23(svgNode, canvas, size, closePath: false);
				break;
			case "rect":
			{
				Hashtable hashtable = svgNode.hashtable_1;
				if (hashtable.ContainsKey("stroke-width") && hashtable["stroke-width"] == "-1")
				{
					hashtable.Remove("stroke-width");
					hashtable.Add("stroke-width", "1");
				}
				method_16(svgNode, canvas, size, translateAxis);
				break;
			}
			case "rawText":
				if (svgNode.class7132_0.string_0 == "text" || svgNode.class7132_0.string_0 == "altGlyph")
				{
					AddText(svgNode, canvas, size);
				}
				if (svgNode.class7132_0.string_0 == "tspan")
				{
					method_45(svgNode, canvas, size);
				}
				break;
			case "text":
				float_8 = 0f;
				method_43(svgNode, size);
				break;
			case "altGlyph":
				method_41(svgNode, canvas, size);
				break;
			case "use":
				method_13(svgNode, canvas, size, useTagShape: true);
				break;
			case "symbol":
			{
				foreach (DictionaryEntry item in svgNode.hashtable_4)
				{
					AddNode((Class7132)item.Value, canvas, size, useTagShape, translateAxis);
				}
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	private void method_10(Class7132 parentNode, Class7132 childNode, string[] attributes)
	{
		foreach (string key in attributes)
		{
			if (parentNode.hashtable_0.ContainsKey(key) && !childNode.hashtable_0.ContainsKey(key))
			{
				childNode.hashtable_0.Add(key, parentNode.hashtable_0[key]);
			}
		}
	}

	private void method_11(Class7132 element, Class6213 canvas, SizeF size)
	{
		for (int i = 0; i < element.hashtable_4.Count; i++)
		{
			Class7132 @class = (Class7132)element.hashtable_4[i];
			if (@class.hashtable_0.ContainsKey("result"))
			{
				if (@class.string_0 == "feImage")
				{
					method_10(element, @class, new string[4] { "x", "y", "width", "height" });
				}
				hashtable_4.Add(@class.hashtable_0["result"], @class);
			}
		}
		for (int j = 0; j < element.hashtable_4.Count; j++)
		{
			Class7132 class2 = (Class7132)element.hashtable_4[j];
			string text;
			if ((text = class2.string_0) != null && text == "feBlend")
			{
				method_12(class2, canvas, size);
			}
		}
	}

	private void method_12(Class7132 filterItem, Class6213 canvas, SizeF size)
	{
		if (filterItem.hashtable_0.ContainsKey("in") && hashtable_4.ContainsKey(filterItem.hashtable_0["in"]))
		{
			Class7132 @class = (Class7132)hashtable_4[filterItem.hashtable_0["in"].ToString()];
			if (filterItem.hashtable_0.ContainsKey("mode"))
			{
				@class.hashtable_0.Add("mode", filterItem.hashtable_0["mode"].ToString());
			}
			int_0++;
			AddImage(@class, canvas, size);
		}
		if (filterItem.hashtable_0.ContainsKey("in2") && hashtable_4.ContainsKey(filterItem.hashtable_0["in2"]))
		{
			Class7132 class2 = (Class7132)hashtable_4[filterItem.hashtable_0["in2"].ToString()];
			if (filterItem.hashtable_0.ContainsKey("mode"))
			{
				class2.hashtable_0.Add("mode", filterItem.hashtable_0["mode"].ToString());
			}
			class2.int_1 = int_0;
			int_0++;
			AddImage(class2, canvas, size);
		}
	}

	internal void method_13(Class7132 element, Class6213 canvas, SizeF size, bool useTagShape)
	{
		try
		{
			string key = string.Empty;
			if (element.hashtable_0.ContainsKey("xlink:href"))
			{
				key = element.hashtable_0["xlink:href"].ToString().Replace("#", string.Empty);
			}
			if (hashtable_0.ContainsKey(key))
			{
				Class7132 svgNode = (Class7132)hashtable_0[key];
				AddNode(svgNode, canvas, size, useTagShape: false, translateAxis: true);
			}
			if (element.hashtable_0.ContainsKey("filter"))
			{
				string key2 = method_54(element.hashtable_0["filter"].ToString());
				method_11((Class7132)((DictionaryEntry)hashtable_0[key2]).Value, canvas, size);
			}
		}
		catch (Exception)
		{
		}
	}

	private Struct219 method_14(float[] curve)
	{
		Struct219 result = default(Struct219);
		result.StartPoint = new PointF(curve[0], curve[1]);
		result.ControlPoint1 = new PointF(curve[2], curve[3]);
		result.ControlPoint2 = new PointF(curve[4], curve[5]);
		result.EndPoint = new PointF(curve[6], curve[7]);
		return result;
	}

	private Class6218 method_15(Class7132 element, SizeF size, bool translateAxis)
	{
		Class6218 @class = new Class6218();
		element.method_1();
		if (element.hashtable_0.ContainsKey("x") && element.hashtable_0.ContainsKey("y") && element.hashtable_0.ContainsKey("width") && element.hashtable_0.ContainsKey("height"))
		{
			float num = method_65(element.hashtable_0["x"].ToString(), "x", element);
			float num2 = method_65(element.hashtable_0["y"].ToString(), "y", element);
			_ = size.Width;
			_ = size.Height;
			if (element.hashtable_0.ContainsKey("bounding-box-width"))
			{
				method_65(element.hashtable_0["bounding-box-width"].ToString(), string.Empty, element);
			}
			if (element.hashtable_0.ContainsKey("bounding-box-height"))
			{
				method_65(element.hashtable_0["bounding-box-height"].ToString(), string.Empty, element);
			}
			float num3 = method_65(element.hashtable_0["width"].ToString(), "width", element);
			float num4 = method_65(element.hashtable_0["height"].ToString(), "height", element);
			float num5 = method_65(element.hashtable_0["x"].ToString(), "x", element) + num3;
			float num6 = method_65(element.hashtable_0["y"].ToString(), "y", element) + num4;
			if (translateAxis)
			{
				num2 = method_18(num2, size.Height);
				num6 = method_18(num6, size.Height);
			}
			if (!element.hashtable_0.ContainsKey("rx") && !element.hashtable_0.ContainsKey("ry"))
			{
				@class.Add(new Class6223(new float[4] { num, num2, num, num6 }));
				@class.Add(new Class6223(new float[4] { num, num6, num5, num6 }));
				@class.Add(new Class6223(new float[4] { num5, num6, num5, num2 }));
				@class.Add(new Class6223(new float[4] { num5, num2, num, num2 }));
			}
			else
			{
				float num7 = 0f;
				float num8 = 0f;
				if (element.hashtable_0.ContainsKey("rx"))
				{
					num7 = method_65(element.hashtable_0["rx"].ToString(), "rx", element);
				}
				if (element.hashtable_0.ContainsKey("ry"))
				{
					num8 = method_65(element.hashtable_0["ry"].ToString(), "ry", element);
				}
				if (!element.hashtable_0.ContainsKey("rx"))
				{
					num7 = num8;
				}
				if (!element.hashtable_0.ContainsKey("ry"))
				{
					num8 = num7;
				}
				@class.Add(new Class6223(new float[4]
				{
					num,
					num2 - num8,
					num,
					num6 + num8
				}));
				ArrayList arrayList = Class7120.smethod_10(num, num6, num7 * 2f, num8 * 2f);
				@class.Add(new Class6222(method_14((float[])arrayList[0])));
				@class.Add(new Class6223(new float[4]
				{
					num + num7,
					num6,
					num5 - num7,
					num6
				}));
				arrayList = Class7120.smethod_10(num5 - num7 * 2f, num6, num7 * 2f, num8 * 2f);
				@class.Add(new Class6222(method_14((float[])arrayList[1])));
				@class.Add(new Class6223(new float[4]
				{
					num5,
					num6 + num8,
					num5,
					num2 - num8
				}));
				arrayList = Class7120.smethod_10(num5 - num7 * 2f, num2 - num8 * 2f, num7 * 2f, num8 * 2f);
				@class.Add(new Class6222(method_14((float[])arrayList[2])));
				@class.Add(new Class6223(new float[4]
				{
					num5 - num7,
					num2,
					num + num7,
					num2
				}));
				arrayList = Class7120.smethod_10(num, num2 - num8 * 2f, num7 * 2f, num8 * 2f);
				@class.Add(new Class6222(method_14((float[])arrayList[3])));
			}
			@class.IsClosed = true;
			if (element.hashtable_0.ContainsKey("transform"))
			{
				method_31(element, @class, size);
			}
			return @class;
		}
		return @class;
	}

	internal void method_16(Class7132 element, Class6213 canvas, SizeF size, bool translateAxis)
	{
		try
		{
			Class6218 node = method_15(element, size, translateAxis);
			Class6217 @class = new Class6217();
			@class.Add(node);
			method_63(@class, element, size, canvas);
			canvas.Add(@class);
			if (element.hashtable_0.ContainsKey("clip-path") || element.hashtable_0.ContainsKey("view-clip-id"))
			{
				@class.Clip = method_62(size, element);
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_17(Class7132 element)
	{
	}

	internal float method_18(float yPos, float graphHeight)
	{
		return graphHeight - yPos;
	}

	internal void method_19(Class7132 element, Class6213 canvas, SizeF size, bool useTagShape)
	{
		try
		{
			Class6217 @class = new Class6217();
			canvas.Add(@class);
			@class.Add(method_60(element, useTagShape, size));
			if (element.hashtable_0.ContainsKey("clip-path") || element.hashtable_0.ContainsKey("view-clip-id"))
			{
				@class.Clip = method_62(size, element);
			}
			if (element.hashtable_0.ContainsKey("transform"))
			{
				method_31(element, @class, size);
			}
			method_63(@class, element, size, canvas);
		}
		catch (Exception)
		{
		}
	}

	internal static Class6002 smethod_3(float[] vb, float w, float h, string preserveRatio)
	{
		Class6002 @class = new Class6002();
		float num = vb[2] / vb[3];
		float num2 = w / h;
		if (preserveRatio == "none")
		{
			@class.method_6(w / vb[2], h / vb[3]);
			@class.method_8(0f - vb[0], 0f - vb[1]);
		}
		else if (num < num2)
		{
			float num3 = h / vb[3];
			@class.method_6(num3, num3);
			switch (preserveRatio)
			{
			case "xMinYMin":
			case "xMinYMid":
			case "xMinYMax":
				@class.method_8(0f - vb[0], 0f - vb[1]);
				break;
			case "xMidYMin":
			case "xMidYMid":
			case "xMidYMax":
				@class.method_8(0f - vb[0] - (vb[2] - w * vb[3] / h) / 2f, 0f - vb[1]);
				break;
			default:
				@class.method_8(0f - vb[0] - (vb[2] - w * vb[3] / h), 0f - vb[1]);
				break;
			}
		}
		else
		{
			float num4 = w / vb[2];
			@class.method_6(num4, num4);
			switch (preserveRatio)
			{
			case "xMinYMin":
			case "xMidYMin":
			case "xMaxYMin":
				@class.method_8(0f - vb[0], 0f - vb[1]);
				break;
			case "xMinYMid":
			case "xMidYMid":
			case "xMaxYMid":
				@class.method_8(0f - vb[0], 0f - vb[1] - (vb[3] - h * vb[2] / w) / 2f);
				break;
			default:
				@class.method_8(0f - vb[0], 0f - vb[1] - (vb[3] - h * vb[2] / w));
				break;
			}
		}
		return @class;
	}

	internal void AddImage(Class7132 element, Class6213 canvas, SizeF size)
	{
		try
		{
			float num = 0f;
			float num2 = 0f;
			float val = 0f;
			float val2 = 0f;
			byte[] array = new byte[0];
			IDictionaryEnumerator dictionaryEnumerator = element.hashtable_0.GetEnumerator();
			try
			{
				while (dictionaryEnumerator.MoveNext())
				{
					switch (((DictionaryEntry)dictionaryEnumerator.Current).Key.ToString())
					{
					case "xlink:href":
						array = interface384_0.imethod_0(this, new EventArgs2(element.hashtable_0["xlink:href"].ToString())).Data;
						break;
					case "height":
						val2 = method_65(element.hashtable_0["height"].ToString(), "height", element);
						break;
					case "width":
						val = method_65(element.hashtable_0["width"].ToString(), "width", element);
						break;
					case "y":
						num2 = method_65(element.hashtable_0["y"].ToString(), "y", element);
						break;
					case "x":
						num = method_65(element.hashtable_0["x"].ToString(), "x", element);
						break;
					}
				}
			}
			finally
			{
				IDisposable disposable = dictionaryEnumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			if (array.Length > 0)
			{
				Class6213 @class = new Class6213();
				@class.RenderTransform = new Class6002(1f, 0f, 0f, -1f, 0f, size.Height);
				float width = 0f;
				float height = 0f;
				smethod_4(array, ref width, ref height);
				SizeF sizeF = new SizeF(width, height);
				float[] vb = new float[4] { 0f, 0f, width, height };
				width = Math.Min(val, size.Width);
				height = Math.Min(val2, size.Height);
				string preserveRatio = "xMidYMid";
				if (element.hashtable_0.Contains("preserveAspectRatio"))
				{
					preserveRatio = (string)element.hashtable_0["preserveAspectRatio"];
				}
				Class6002 class2 = smethod_3(vb, width, height, preserveRatio);
				RectangleF rect = new RectangleF(0f, 0f, sizeF.Width, sizeF.Height);
				rect = class2.method_4(rect);
				@class.Add(new Class6220(new PointF(num + rect.X, num2 + rect.Y), rect.Size, array));
				canvas.Add(@class);
			}
		}
		catch (Exception)
		{
		}
	}

	private static void smethod_4(byte[] imgData, ref float width, ref float height)
	{
		using Bitmap bitmap = new Bitmap(new MemoryStream(imgData));
		width = bitmap.Width;
		height = bitmap.Height;
	}

	internal void method_20(Class7132 element, Class6213 canvas, SizeF size)
	{
		try
		{
			Class6217 @class = new Class6217();
			@class.Add(method_61(element, size));
			if (element.hashtable_0.ContainsKey("clip-path") || element.hashtable_0.ContainsKey("view-clip-id"))
			{
				@class.Clip = method_62(size, element);
			}
			if (element.hashtable_0.ContainsKey("transform"))
			{
				method_31(element, @class, size);
			}
			method_63(@class, element, size, canvas);
			canvas.Add(@class);
		}
		catch (Exception)
		{
		}
	}

	private float[] method_21(SizeF size, Class7132 element, bool closePath, bool translateAxis)
	{
		float[] array = new float[0];
		string[] array2 = Convert.ToString(element.hashtable_0["points"]).Split(new string[2] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
		array = ((!closePath) ? new float[array2.Length] : new float[array2.Length + 2]);
		int num = 0;
		bool flag = false;
		string[] array3 = array2;
		foreach (string text in array3)
		{
			if (!flag)
			{
				array[num] = method_65(text.Trim(), string.Empty, element);
				flag = true;
			}
			else
			{
				if (translateAxis)
				{
					array[num] = method_18(method_65(text.Trim(), string.Empty, element), size.Height);
				}
				else
				{
					array[num] = method_65(text.Trim(), string.Empty, element);
				}
				flag = false;
			}
			num++;
		}
		if (closePath)
		{
			array[num] = array[0];
			array[num + 1] = array[1];
		}
		return array;
	}

	private Class6217 method_22(Class7132 element, SizeF size, bool closePath)
	{
		float[] coords = method_21(size, element, closePath, translateAxis: true);
		Class6217 @class = new Class6217();
		Class6218 class2 = new Class6218();
		Class6223 node = new Class6223(coords);
		class2.Add(node);
		@class.Add(class2);
		if (element.hashtable_0.ContainsKey("transform"))
		{
			method_31(element, @class, size);
		}
		return @class;
	}

	internal void method_23(Class7132 element, Class6213 canvas, SizeF size, bool closePath)
	{
		try
		{
			Class6217 @class = method_22(element, size, closePath);
			if (element.hashtable_0.ContainsKey("clip-path") || element.hashtable_0.ContainsKey("view-clip-id"))
			{
				@class.Clip = method_62(size, element);
			}
			method_63(@class, element, size, canvas);
			canvas.Add(@class);
		}
		catch (Exception)
		{
		}
	}

	internal Hashtable method_24(string transformRaw, SizeF size)
	{
		Hashtable hashtable = new Hashtable();
		string[] array = transformRaw.Split(new string[6] { "rotate", "translate", "scale", "shear", "skew", "matrix" }, StringSplitOptions.RemoveEmptyEntries);
		int num = 0;
		int num2 = 0;
		foreach (string text in array)
		{
			if (text.Trim().Length == 0)
			{
				continue;
			}
			int num3 = transformRaw.IndexOf(text);
			for (int num4 = num3; num4 >= 0; num4--)
			{
				num2 = num4;
				if (transformRaw[num4] == ' ' || transformRaw[num4] == ',' || transformRaw[num4] == ')')
				{
					break;
				}
			}
			string text2 = transformRaw.Substring(num2, num3 - num2).Trim().Replace("(", string.Empty)
				.Replace(")", string.Empty);
			string text3 = text.Replace("(", string.Empty).Replace(")", string.Empty).Trim();
			bool flag = text2 != "translate" && text2 != "matrix";
			string[] array2 = text3.Split(new string[2] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
			if (array2.Length <= 2)
			{
				float num5 = (flag ? ((float)Convert.ToDecimal(array2[0], CultureInfo.InvariantCulture)) : method_65(array2[0], string.Empty, null));
				float num6 = 0f;
				num6 = ((array2.Length <= 1) ? num5 : (flag ? ((float)Convert.ToDecimal(array2[1], CultureInfo.InvariantCulture)) : method_65(array2[1], string.Empty, null)));
				hashtable.Add(num, new Class7193(text2, new float[2] { num5, num6 }));
			}
			else if (array2.Length == 3 && text2 == "rotate")
			{
				hashtable.Add(num, new Class7193("translate", new float[2]
				{
					method_65(array2[1], string.Empty, null),
					method_65(array2[2], string.Empty, null)
				}));
				hashtable.Add(num + 1, new Class7193("rotate", new float[1] { (float)Convert.ToDecimal(array2[0], CultureInfo.InvariantCulture) }));
				hashtable.Add(num + 2, new Class7193("translate", new float[2]
				{
					method_65(array2[1], string.Empty, null) * -1f,
					method_65(array2[2], string.Empty, null) * -1f
				}));
				num += 2;
			}
			else if (text2 == "matrix")
			{
				hashtable.Add(num, new Class7193("translate", new float[2]
				{
					method_65(array2[4], string.Empty, null),
					method_65(array2[5], string.Empty, null)
				}));
				hashtable.Add(num + 1, new Class7193("scale", new float[2]
				{
					(float)Convert.ToDecimal(array2[0], CultureInfo.InvariantCulture),
					(float)Convert.ToDecimal(array2[3], CultureInfo.InvariantCulture)
				}));
				num++;
			}
			num++;
		}
		return hashtable;
	}

	internal Matrix method_25(string transformSet, SizeF size)
	{
		try
		{
			Matrix matrix = new Matrix();
			Hashtable hashtable = method_24(transformSet, size);
			for (int i = 0; i < hashtable.Count; i++)
			{
				Class7193 @class = (Class7193)hashtable[i];
				string text = @class.string_0;
				float[] array = @class.float_0;
				switch (text)
				{
				case "skew":
					matrix.Shear((float)Math.Tan((double)(array[0] / 180f) * Math.PI), (float)Math.Tan((double)(array[1] / 180f) * Math.PI));
					break;
				case "shear":
					matrix.Shear(array[0], array[1]);
					break;
				case "scale":
					matrix.Translate(0f, size.Height);
					matrix.Scale(array[0], array[1]);
					matrix.Translate(0f, 0f - size.Height);
					break;
				case "translate":
					matrix.Translate(0f, size.Height);
					matrix.Translate(array[0], array[1] * -1f);
					matrix.Translate(0f, 0f - size.Height);
					break;
				case "rotate":
					if (array.Length <= 2)
					{
						matrix.Translate(0f, size.Height);
						matrix.Rotate(array[0] * -1f);
						matrix.Translate(0f, 0f - size.Height);
					}
					break;
				}
			}
			return matrix;
		}
		catch (Exception)
		{
			return new Matrix();
		}
	}

	internal float[] method_26(Matrix pointMatrix, float[] pointArray)
	{
		using GraphicsPath graphicsPath = new GraphicsPath();
		for (int i = 0; i < pointArray.Length - 3; i += 2)
		{
			graphicsPath.AddLine(pointArray[i], pointArray[i + 1], pointArray[i + 2], pointArray[i + 3]);
		}
		graphicsPath.Transform(pointMatrix);
		float[] array = new float[pointArray.Length];
		int num = 0;
		PointF[] pathPoints = graphicsPath.PathPoints;
		for (int j = 0; j < pathPoints.Length; j++)
		{
			PointF pointF = pathPoints[j];
			array[num] = pointF.X;
			array[num + 1] = pointF.Y;
			num += 2;
		}
		return array;
	}

	private Enum977 method_27(string commandString)
	{
		return commandString switch
		{
			"M" => Enum977.const_0, 
			"m" => Enum977.const_1, 
			"Z" => Enum977.const_2, 
			"z" => Enum977.const_2, 
			"L" => Enum977.const_3, 
			"l" => Enum977.const_4, 
			"H" => Enum977.const_5, 
			"h" => Enum977.const_6, 
			"V" => Enum977.const_7, 
			"v" => Enum977.const_8, 
			"C" => Enum977.const_9, 
			"c" => Enum977.const_10, 
			"S" => Enum977.const_11, 
			"s" => Enum977.const_12, 
			"Q" => Enum977.const_13, 
			"q" => Enum977.const_14, 
			"T" => Enum977.const_15, 
			"t" => Enum977.const_16, 
			"A" => Enum977.const_17, 
			"a" => Enum977.const_18, 
			_ => Enum977.const_19, 
		};
	}

	private void method_28(ref Hashtable pathCommands, ref Enum977 pathCommandType)
	{
		try
		{
			Class7194 @class = (Class7194)pathCommands[pathCommands.Count - 1];
			if ((pathCommandType == Enum977.const_1 || pathCommandType == Enum977.const_0) && @class.hashtable_0.Count > 2)
			{
				Class7194 class2 = new Class7194(pathCommandType, new Hashtable());
				if (pathCommandType == Enum977.const_1)
				{
					class2.enum977_0 = Enum977.const_4;
				}
				if (pathCommandType == Enum977.const_0)
				{
					class2.enum977_0 = Enum977.const_3;
				}
				pathCommandType = class2.enum977_0;
				class2.hashtable_0.Add(class2.hashtable_0.Count, @class.hashtable_0[@class.hashtable_0.Count - 1]);
				@class.hashtable_0.Remove(@class.hashtable_0.Count - 1);
				pathCommands.Add(pathCommands.Count, class2);
			}
			if ((pathCommandType == Enum977.const_10 || pathCommandType == Enum977.const_9) && @class.hashtable_0.Count > 6)
			{
				Class7194 class3 = new Class7194(pathCommandType, new Hashtable());
				if (pathCommandType == Enum977.const_10)
				{
					class3.enum977_0 = Enum977.const_10;
				}
				if (pathCommandType == Enum977.const_9)
				{
					class3.enum977_0 = Enum977.const_9;
				}
				pathCommandType = class3.enum977_0;
				class3.hashtable_0.Add(class3.hashtable_0.Count, @class.hashtable_0[@class.hashtable_0.Count - 1]);
				@class.hashtable_0.Remove(@class.hashtable_0.Count - 1);
				pathCommands.Add(pathCommands.Count, class3);
			}
		}
		catch (Exception)
		{
		}
	}

	internal Class6217 method_29(Class7132 element, SizeF size, bool translateAxis)
	{
		Class6217 @class = new Class6217();
		Enum977 pathCommandType = Enum977.const_19;
		bool flag = false;
		string text = element.hashtable_0["d"].ToString();
		string text2 = string.Empty;
		string text3 = text;
		for (int i = 0; i < text3.Length; i++)
		{
			char c = text3[i];
			string text4 = c.ToString();
			if (text4 == "-")
			{
				text4 = " -";
			}
			text2 = ((arrayList_1.IndexOf(c) <= -1) ? (text2 + text4) : (text2 + " " + text4 + " "));
		}
		string[] array = text2.Split(new string[5] { " ", ",", "\r", "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries);
		new Hashtable();
		Hashtable pathCommands = new Hashtable();
		string[] array2 = array;
		foreach (string text5 in array2)
		{
			if (method_27(text5) != Enum977.const_19)
			{
				pathCommands.Add(pathCommands.Count, new Class7194(method_27(text5), new Hashtable()));
				flag = false;
				pathCommandType = method_27(text5);
			}
			else
			{
				int count = ((Class7194)pathCommands[pathCommands.Count - 1]).hashtable_0.Count;
				if (flag)
				{
					if (translateAxis && !arrayList_0.Contains((int)pathCommandType))
					{
						((Class7194)pathCommands[pathCommands.Count - 1]).hashtable_0.Add(count, method_18(method_65(text5, string.Empty, element), size.Height));
					}
					else
					{
						((Class7194)pathCommands[pathCommands.Count - 1]).hashtable_0.Add(count, method_65(text5, string.Empty, element));
					}
					flag = false;
				}
				else
				{
					((Class7194)pathCommands[pathCommands.Count - 1]).hashtable_0.Add(count, method_65(text5, string.Empty, element));
					if (pathCommandType != Enum977.const_17 && pathCommandType != Enum977.const_18)
					{
						flag = true;
					}
				}
			}
			method_28(ref pathCommands, ref pathCommandType);
		}
		hashtable_6.Clear();
		float num = 0f;
		float num2 = 0f;
		int num3 = 0;
		Class6218 class2 = new Class6218();
		@class.Add(class2);
		for (int k = 0; k < pathCommands.Count; k++)
		{
			hashtable_7.Clear();
			Class7194 class3 = null;
			try
			{
				Class7194 pathCommand = (Class7194)pathCommands[k];
				Class7194 class4 = null;
				if (k < pathCommands.Count - 1)
				{
					class4 = (Class7194)pathCommands[k + 1];
				}
				if (k > 0)
				{
					class3 = (Class7194)pathCommands[k - 1];
				}
				if (pathCommand.enum977_0 == Enum977.const_0)
				{
					if (hashtable_6.Count >= 4)
					{
						class2.Add(method_35(element, hashtable_6, lineFilled: false));
						class2.IsClosed = true;
						hashtable_6 = new Hashtable();
						class2 = new Class6218();
						@class.Add(class2);
					}
					for (int l = 0; l < pathCommand.hashtable_0.Count; l++)
					{
						hashtable_6.Add(hashtable_6.Count, pathCommand.hashtable_0[l]);
						pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
					}
					num = (float)hashtable_6[hashtable_6.Count - 2];
					num2 = (float)hashtable_6[hashtable_6.Count - 1];
					continue;
				}
				if (pathCommand.enum977_0 == Enum977.const_1)
				{
					if (hashtable_6.Count >= 4)
					{
						class2.Add(method_35(element, hashtable_6, lineFilled: false));
						class2.IsClosed = true;
						hashtable_6 = new Hashtable();
						class2 = new Class6218();
						@class.Add(class2);
					}
					for (int m = 0; m < pathCommand.hashtable_0.Count; m += 2)
					{
						hashtable_6.Add(hashtable_6.Count, num + (float)pathCommand.hashtable_0[m]);
						pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
						hashtable_6.Add(hashtable_6.Count, num2 - (float)pathCommand.hashtable_0[m + 1]);
						pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
					}
					num = (float)hashtable_6[hashtable_6.Count - 2];
					num2 = (float)hashtable_6[hashtable_6.Count - 1];
					continue;
				}
				if (pathCommand.enum977_0 == Enum977.const_3)
				{
					if (class3 != null)
					{
						hashtable_6.Add(hashtable_6.Count, num);
						hashtable_6.Add(hashtable_6.Count, num2);
					}
					for (int n = 0; n < pathCommand.hashtable_0.Count; n++)
					{
						hashtable_6.Add(hashtable_6.Count, pathCommand.hashtable_0[n]);
						pathCommand.hashtable_1.Add(hashtable_6.Count - 1, hashtable_6[hashtable_6.Count - 1]);
					}
					num = (float)hashtable_6[hashtable_6.Count - 2];
					num2 = (float)hashtable_6[hashtable_6.Count - 1];
					continue;
				}
				if (pathCommand.enum977_0 == Enum977.const_4)
				{
					float num4 = num;
					float num5 = num2;
					if (class3 != null)
					{
						hashtable_6.Add(hashtable_6.Count, num);
						hashtable_6.Add(hashtable_6.Count, num2);
					}
					for (int num6 = 0; num6 < pathCommand.hashtable_0.Count; num6 += 2)
					{
						hashtable_6.Add(hashtable_6.Count, num4 + (float)pathCommand.hashtable_0[num6]);
						pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
						hashtable_6.Add(hashtable_6.Count, num5 - (float)pathCommand.hashtable_0[num6 + 1]);
						pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
						num4 = (float)hashtable_6[hashtable_6.Count - 2];
						num5 = (float)hashtable_6[hashtable_6.Count - 1];
					}
					num = (float)hashtable_6[hashtable_6.Count - 2];
					num2 = (float)hashtable_6[hashtable_6.Count - 1];
					continue;
				}
				if (pathCommand.enum977_0 == Enum977.const_5)
				{
					if (class3 != null)
					{
						hashtable_6.Add(hashtable_6.Count, num);
						hashtable_6.Add(hashtable_6.Count, num2);
					}
					for (int num7 = 0; num7 < pathCommand.hashtable_0.Count; num7++)
					{
						hashtable_6.Add(hashtable_6.Count, pathCommand.hashtable_0[num7]);
						pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
						hashtable_6.Add(hashtable_6.Count, num2);
						pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
					}
					num = (float)hashtable_6[hashtable_6.Count - 2];
					num2 = (float)hashtable_6[hashtable_6.Count - 1];
					continue;
				}
				if (pathCommand.enum977_0 == Enum977.const_6)
				{
					if (class3 != null)
					{
						float num8 = num2;
						float num9 = num;
						hashtable_6.Add(hashtable_6.Count, num9);
						hashtable_6.Add(hashtable_6.Count, num8);
						for (int num10 = 0; num10 < pathCommand.hashtable_0.Count; num10++)
						{
							num9 += (float)pathCommand.hashtable_0[num10];
							hashtable_6.Add(hashtable_6.Count, num9);
							pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
							hashtable_6.Add(hashtable_6.Count, num8);
							pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
							num9 = (float)hashtable_6[hashtable_6.Count - 2];
							num8 = (float)hashtable_6[hashtable_6.Count - 1];
						}
						num = (float)hashtable_6[hashtable_6.Count - 2];
						num2 = (float)hashtable_6[hashtable_6.Count - 1];
					}
					continue;
				}
				if (pathCommand.enum977_0 == Enum977.const_7)
				{
					if (class3 != null)
					{
						hashtable_6.Add(hashtable_6.Count, num);
						hashtable_6.Add(hashtable_6.Count, num2);
						for (int num11 = 0; num11 < pathCommand.hashtable_0.Count; num11++)
						{
							hashtable_6.Add(hashtable_6.Count, num);
							pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
							hashtable_6.Add(hashtable_6.Count, method_18((float)pathCommand.hashtable_0[num11], size.Height));
							pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
						}
						num = (float)hashtable_6[hashtable_6.Count - 2];
						num2 = (float)hashtable_6[hashtable_6.Count - 1];
					}
					continue;
				}
				if (pathCommand.enum977_0 == Enum977.const_8)
				{
					if (class3 != null)
					{
						float num12 = num2;
						float num13 = num;
						hashtable_6.Add(hashtable_6.Count, num13);
						hashtable_6.Add(hashtable_6.Count, num12);
						for (int num14 = 0; num14 < pathCommand.hashtable_0.Count; num14++)
						{
							num12 -= (float)pathCommand.hashtable_0[num14];
							hashtable_6.Add(hashtable_6.Count, num13);
							pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
							hashtable_6.Add(hashtable_6.Count, num12);
							pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
							num13 = (float)hashtable_6[hashtable_6.Count - 2];
							num12 = (float)hashtable_6[hashtable_6.Count - 1];
						}
						num = (float)hashtable_6[hashtable_6.Count - 2];
						num2 = (float)hashtable_6[hashtable_6.Count - 1];
					}
					continue;
				}
				if (pathCommand.enum977_0 != Enum977.const_17 && pathCommand.enum977_0 != Enum977.const_18)
				{
					if (arrayList_2.Contains((int)pathCommand.enum977_0))
					{
						if (hashtable_6.Count >= 4)
						{
							class2.Add(method_35(element, hashtable_6, lineFilled: false));
						}
						Class6222 class5 = method_32(element, ref pathCommand, class3, isSegment: true, num, num2);
						class2.Add(class5);
						if (class4 != null && arrayList_3.Contains((int)class4.enum977_0))
						{
							class2.IsClosed = true;
							class2 = new Class6218();
							@class.Add(class2);
						}
						hashtable_6 = new Hashtable();
						num = class5.Curve.EndPoint.X;
						num2 = class5.Curve.EndPoint.Y;
					}
					else if (pathCommand.enum977_0 == Enum977.const_2)
					{
						hashtable_6.Add(hashtable_6.Count, num);
						hashtable_6.Add(hashtable_6.Count, num2);
						if (num3 > 0)
						{
							hashtable_6.Add(hashtable_6.Count, (float)((Class7194)pathCommands[num3]).hashtable_1[0]);
							pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
							hashtable_6.Add(hashtable_6.Count, (float)((Class7194)pathCommands[num3]).hashtable_1[1]);
							pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
						}
						else
						{
							hashtable_6.Add(hashtable_6.Count, (float)((Class7194)pathCommands[0]).hashtable_1[0]);
							pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
							hashtable_6.Add(hashtable_6.Count, (float)((Class7194)pathCommands[0]).hashtable_1[1]);
							pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, hashtable_6[hashtable_6.Count - 1]);
						}
						if (hashtable_6.Count >= 4)
						{
							class2.Add(method_35(element, hashtable_6, lineFilled: false));
							class2.IsClosed = true;
							class2 = new Class6218();
							@class.Add(class2);
						}
						num = (float)hashtable_6[hashtable_6.Count - 2];
						num2 = (float)hashtable_6[hashtable_6.Count - 1];
						hashtable_6 = new Hashtable();
						if (k < pathCommands.Count - 1)
						{
							num3 = k + 1;
						}
					}
					continue;
				}
				if (hashtable_6.Count >= 4)
				{
					class2.Add(method_35(element, hashtable_6, lineFilled: false));
				}
				ArrayList arrayList = new ArrayList();
				if (pathCommand.hashtable_0[0].ToString() == pathCommand.hashtable_0[1].ToString())
				{
					arrayList = method_33(element, ref pathCommand, class3, size, isSegment: true, num, num2);
				}
				for (int num15 = 0; num15 < arrayList.Count; num15++)
				{
					if (arrayList[num15] != null)
					{
						float[] array3 = (float[])arrayList[num15];
						Struct219 bezier = default(Struct219);
						bezier.StartPoint = new PointF(array3[0], array3[1]);
						bezier.ControlPoint1 = new PointF(array3[2], array3[3]);
						bezier.ControlPoint2 = new PointF(array3[4], array3[5]);
						bezier.EndPoint = new PointF(array3[6], array3[7]);
						Class6222 node = new Class6222(bezier);
						class2.Add(node);
					}
				}
				hashtable_6 = new Hashtable();
				num = (float)pathCommand.hashtable_0[5];
				num2 = method_18((float)pathCommand.hashtable_0[6], size.Height);
			}
			catch (Exception)
			{
			}
		}
		if (hashtable_6.Count >= 4)
		{
			class2.Add(method_35(element, hashtable_6, lineFilled: false));
		}
		if (element.hashtable_0.ContainsKey("transform"))
		{
			method_31(element, @class, size);
		}
		return @class;
	}

	internal void method_30(Class7132 element, Class6213 canvas, SizeF size, bool translateAxis)
	{
		try
		{
			string empty = string.Empty;
			if (element.hashtable_0.ContainsKey("x") || element.hashtable_0.ContainsKey("y"))
			{
				float num = 0f;
				float num2 = 0f;
				if (element.hashtable_0.ContainsKey("x"))
				{
					num = method_65(element.hashtable_0["x"].ToString(), "x", element);
				}
				if (element.hashtable_0.ContainsKey("y"))
				{
					num2 = method_65(element.hashtable_0["y"].ToString(), "y", element);
				}
				empty = " translate(" + num + ", " + num2 + ")";
				if (element.hashtable_0.ContainsKey("transform"))
				{
					Hashtable hashtable;
					object key;
					(hashtable = element.hashtable_0)[key = "transform"] = string.Concat(hashtable[key], empty);
				}
				else
				{
					element.hashtable_0.Add("transform", empty);
				}
			}
			Class6217 @class = method_29(element, size, translateAxis);
			if (element.hashtable_0.ContainsKey("clip-path") || element.hashtable_0.ContainsKey("view-clip-id"))
			{
				@class.Clip = method_62(size, element);
			}
			method_63(@class, element, size, canvas);
			canvas.Add(@class);
		}
		catch (Exception)
		{
		}
	}

	private void method_31(Class7132 element, Class6204 node, SizeF size)
	{
		Class6002 @class = Class6161.smethod_1(method_25(element.hashtable_0["transform"].ToString(), size));
		if (node is Class6217 class2)
		{
			if (class2.RenderTransform != null)
			{
				class2.RenderTransform.method_10(@class);
			}
			else
			{
				class2.RenderTransform = @class;
			}
		}
		else if (node is Class6218 class3)
		{
			class3.method_6(@class);
		}
	}

	private Class6222 method_32(Class7132 element, ref Class7194 pathCommand, Class7194 prevPathCommand, bool isSegment, float prevPathXpos, float prevPathYpos)
	{
		float[] array = new float[8];
		ArrayList arrayList = new ArrayList(new int[4] { 9, 10, 11, 12 });
		ArrayList arrayList2 = new ArrayList(new int[4] { 13, 14, 15, 16 });
		if (pathCommand.enum977_0 != Enum977.const_9 && pathCommand.enum977_0 != Enum977.const_10)
		{
			if (pathCommand.enum977_0 != Enum977.const_11 && pathCommand.enum977_0 != Enum977.const_12)
			{
				if (pathCommand.enum977_0 != Enum977.const_13 && pathCommand.enum977_0 != Enum977.const_14)
				{
					if (pathCommand.enum977_0 == Enum977.const_15 || pathCommand.enum977_0 == Enum977.const_16)
					{
						float[] array2 = new float[6];
						if (arrayList2.Contains((int)prevPathCommand.enum977_0))
						{
							array2[0] = prevPathXpos;
							array2[1] = prevPathYpos;
							PointF pointF = method_34(new PointF((float)prevPathCommand.hashtable_1[prevPathCommand.hashtable_1.Count - 4], (float)prevPathCommand.hashtable_1[prevPathCommand.hashtable_1.Count - 3]), new PointF(prevPathXpos, prevPathYpos));
							array2[2] = pointF.X;
							array2[3] = pointF.Y;
						}
						else
						{
							array2[0] = prevPathXpos;
							array2[1] = prevPathYpos;
							array2[2] = prevPathXpos;
							array2[3] = prevPathYpos;
						}
						if (pathCommand.enum977_0 == Enum977.const_16)
						{
							array2[4] = prevPathXpos + (float)pathCommand.hashtable_0[0];
							array2[5] = prevPathYpos - (float)pathCommand.hashtable_0[1];
						}
						else
						{
							array2[4] = (float)pathCommand.hashtable_0[0];
							array2[5] = (float)pathCommand.hashtable_0[1];
						}
						array = Class7120.smethod_4(array2);
						float[] array3 = array2;
						foreach (float num in array3)
						{
							pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, num);
						}
					}
				}
				else
				{
					float[] array4 = new float[6] { prevPathXpos, prevPathYpos, 0f, 0f, 0f, 0f };
					if (pathCommand.enum977_0 == Enum977.const_14)
					{
						array4[2] = prevPathXpos + (float)pathCommand.hashtable_0[0];
						array4[3] = prevPathYpos - (float)pathCommand.hashtable_0[1];
						array4[4] = prevPathXpos + (float)pathCommand.hashtable_0[2];
						array4[5] = prevPathYpos - (float)pathCommand.hashtable_0[3];
					}
					else
					{
						array4[2] = (float)pathCommand.hashtable_0[0];
						array4[3] = (float)pathCommand.hashtable_0[1];
						array4[4] = (float)pathCommand.hashtable_0[2];
						array4[5] = (float)pathCommand.hashtable_0[3];
					}
					array = Class7120.smethod_4(array4);
					float[] array5 = array4;
					foreach (float num2 in array5)
					{
						pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, num2);
					}
				}
			}
			else
			{
				if (arrayList.Contains((int)prevPathCommand.enum977_0))
				{
					array[0] = prevPathXpos;
					array[1] = prevPathYpos;
					PointF pointF2 = method_34(new PointF((float)prevPathCommand.hashtable_1[prevPathCommand.hashtable_1.Count - 4], (float)prevPathCommand.hashtable_1[prevPathCommand.hashtable_1.Count - 3]), new PointF((float)prevPathCommand.hashtable_1[prevPathCommand.hashtable_1.Count - 2], (float)prevPathCommand.hashtable_1[prevPathCommand.hashtable_1.Count - 1]));
					array[2] = pointF2.X;
					array[3] = pointF2.Y;
				}
				else
				{
					array[0] = prevPathXpos;
					array[1] = prevPathYpos;
					array[2] = prevPathXpos;
					array[3] = prevPathYpos;
				}
				if (pathCommand.enum977_0 == Enum977.const_12)
				{
					array[4] = prevPathXpos + (float)pathCommand.hashtable_0[0];
					array[5] = prevPathYpos - (float)pathCommand.hashtable_0[1];
					array[6] = prevPathXpos + (float)pathCommand.hashtable_0[2];
					array[7] = prevPathYpos - (float)pathCommand.hashtable_0[3];
				}
				else
				{
					array[4] = (float)pathCommand.hashtable_0[0];
					array[5] = (float)pathCommand.hashtable_0[1];
					array[6] = (float)pathCommand.hashtable_0[2];
					array[7] = (float)pathCommand.hashtable_0[3];
				}
				float[] array6 = array;
				foreach (float num3 in array6)
				{
					pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, num3);
				}
			}
		}
		else
		{
			array[0] = prevPathXpos;
			array[1] = prevPathYpos;
			if (pathCommand.enum977_0 == Enum977.const_10)
			{
				array[2] = prevPathXpos + (float)pathCommand.hashtable_0[0];
				array[3] = prevPathYpos - (float)pathCommand.hashtable_0[1];
				array[4] = prevPathXpos + (float)pathCommand.hashtable_0[2];
				array[5] = prevPathYpos - (float)pathCommand.hashtable_0[3];
				array[6] = prevPathXpos + (float)pathCommand.hashtable_0[4];
				array[7] = prevPathYpos - (float)pathCommand.hashtable_0[5];
			}
			else
			{
				array[2] = (float)pathCommand.hashtable_0[0];
				array[3] = (float)pathCommand.hashtable_0[1];
				array[4] = (float)pathCommand.hashtable_0[2];
				array[5] = (float)pathCommand.hashtable_0[3];
				array[6] = (float)pathCommand.hashtable_0[4];
				array[7] = (float)pathCommand.hashtable_0[5];
			}
			float[] array7 = array;
			foreach (float num4 in array7)
			{
				pathCommand.hashtable_1.Add(pathCommand.hashtable_1.Count, num4);
			}
		}
		Struct219 bezier = default(Struct219);
		bezier.StartPoint = new PointF(array[0], array[1]);
		bezier.ControlPoint1 = new PointF(array[2], array[3]);
		bezier.ControlPoint2 = new PointF(array[4], array[5]);
		bezier.EndPoint = new PointF(array[6], array[7]);
		return new Class6222(bezier);
	}

	private static bool smethod_5(float x, float y, Class7198.Class7199 rect)
	{
		bool flag = x >= rect.float_0 && x <= rect.float_0 + rect.float_2;
		bool flag2 = y >= rect.float_1 && y <= rect.float_1 + rect.float_3;
		if (flag && flag2)
		{
			return true;
		}
		return false;
	}

	internal ArrayList method_33(Class7132 element, ref Class7194 pathCommand, Class7194 prevPathCommand, SizeF size, bool isSegment, float prevPathXpos, float prevPathYpos)
	{
		prevPathYpos = method_18(prevPathYpos, size.Height);
		ArrayList arrayList = new ArrayList();
		float num = (float)pathCommand.hashtable_0[4];
		float num2 = (float)pathCommand.hashtable_0[3];
		float num3 = ((float)pathCommand.hashtable_0[5] - prevPathXpos) / 2f;
		float num4 = ((float)pathCommand.hashtable_0[6] - prevPathYpos) / 2f;
		float num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
		float num6 = num5;
		float num7 = prevPathXpos + num3;
		float num8 = prevPathYpos + num4;
		float num9 = num7;
		float num10 = num8;
		float num11 = num7;
		float num12 = num8;
		if (num5 < (float)pathCommand.hashtable_0[0] || num6 < (float)pathCommand.hashtable_0[1])
		{
			float num13 = (float)pathCommand.hashtable_0[0];
			float num14 = (float)pathCommand.hashtable_0[1];
			float num15 = prevPathXpos + ((float)pathCommand.hashtable_0[5] - prevPathXpos) / 2f;
			float num16 = prevPathYpos + ((float)pathCommand.hashtable_0[6] - prevPathYpos) / 2f;
			float num17 = (float)Math.Sqrt(Math.Pow(num15 - (float)pathCommand.hashtable_0[5], 2.0) + Math.Pow(num16 - (float)pathCommand.hashtable_0[6], 2.0));
			float num18 = (float)Math.Sqrt(Math.Pow(num13, 2.0) - Math.Pow(num17, 2.0));
			float num19 = (float)pathCommand.hashtable_0[5];
			float num20 = (float)pathCommand.hashtable_0[6];
			float num21 = num15;
			float num22 = num16;
			float num23 = num18;
			float num24 = (num19 - num21) / (num20 - num22);
			float num25 = num24 * num21 + num22;
			float num26 = num24 * num24 + 1f;
			float num27 = 2f * num22 * num24 - 2f * num21 - 2f * num24 * num25;
			float num28 = num21 * num21 - 2f * num22 * num25 + num22 * num22 + num25 * num25 - num23 * num23;
			float num29 = ((!(num20 >= num22)) ? ((num27 * -1f - (float)Math.Sqrt(num27 * num27 - 4f * num26 * num28)) / (2f * num26)) : ((num27 * -1f + (float)Math.Sqrt(num27 * num27 - 4f * num26 * num28)) / (2f * num26)));
			float num30 = num25 - num24 * num29;
			num7 = num29;
			num8 = num30;
			if (num == 1f)
			{
				num7 += (num11 - num7) * 2f;
				num8 += (num12 - num8) * 2f;
			}
			num5 = num13;
			num6 = num14;
		}
		if (num2 == 1f)
		{
			num7 -= (num7 - num9) * 2f;
			num8 -= (num8 - num10) * 2f;
		}
		int num31 = 10000;
		ArrayList arrayList2 = Class7120.smethod_10(num7 - num5, num8 - num6, num5 * 2f, num6 * 2f);
		Class7198.Class7199[] array = new Class7198.Class7199[4]
		{
			new Class7198.Class7199(num7 - num5, num8 - num6, num5, num6),
			new Class7198.Class7199(num7, num8 - num6, num5, num6),
			new Class7198.Class7199(num7, num8, num5, num6),
			new Class7198.Class7199(num7 - num5, num8, num5, num6)
		};
		for (int i = 0; i < 4; i++)
		{
			float[] array2 = (float[])arrayList2[i];
			array[i].float_4 = array2;
			if (smethod_5(prevPathXpos, prevPathYpos, array[i]) && smethod_5((float)pathCommand.hashtable_0[5], (float)pathCommand.hashtable_0[6], array[i]))
			{
				array[i].bool_2 = true;
				array[i].bool_1 = true;
				array[i].bool_0 = true;
			}
			else if (smethod_5(prevPathXpos, prevPathYpos, array[i]))
			{
				array[i].bool_1 = true;
				array[i].bool_0 = true;
			}
			else if (smethod_5((float)pathCommand.hashtable_0[5], (float)pathCommand.hashtable_0[6], array[i]))
			{
				array[i].bool_2 = true;
				array[i].bool_0 = true;
			}
		}
		for (int j = 0; j < 4; j++)
		{
			int num32 = 3;
			if (j > 0)
			{
				num32 = j - 1;
			}
			int num33 = 0;
			if (j < 3)
			{
				num33 = j + 1;
			}
			if (array[num32].bool_0 && array[num33].bool_0 && !array[num32].bool_2 && !array[num33].bool_1)
			{
				array[j].bool_0 = true;
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (!array[k].bool_0)
			{
				continue;
			}
			PointF[] array3 = smethod_1(array[k].float_4, num31);
			bool firstPart = false;
			if (array[k].bool_1)
			{
				PointF pointF = new PointF(prevPathXpos, prevPathYpos);
				PointF pointF2 = new PointF(array3[0].X, array3[0].Y);
				int num34 = -1;
				for (int l = 1; l < array3.Length; l++)
				{
					if (Math.Abs(pointF2.X - pointF.X) > Math.Abs(array3[l].X - pointF.X) && Math.Abs(pointF2.Y - pointF.Y) > Math.Abs(array3[l].Y - pointF.Y))
					{
						pointF2.X = array3[l].X;
						pointF2.Y = array3[l].Y;
						num34 = l;
					}
				}
				if (num34 == -1)
				{
					continue;
				}
				array[k].float_4 = Class7120.smethod_9(array[k].float_4, (float)num34 / (float)num31, firstPart);
				array3 = smethod_1(array[k].float_4, num31);
			}
			firstPart = true;
			if (array[k].bool_2)
			{
				PointF pointF3 = new PointF((float)pathCommand.hashtable_0[5], (float)pathCommand.hashtable_0[6]);
				PointF pointF4 = new PointF(array3[0].X, array3[0].Y);
				int num35 = -1;
				for (int m = 1; m < array3.Length; m++)
				{
					if (Math.Abs(pointF4.X - pointF3.X) > Math.Abs(array3[m].X - pointF3.X) && Math.Abs(pointF4.Y - pointF3.Y) > Math.Abs(array3[m].Y - pointF3.Y))
					{
						pointF4.X = array3[m].X;
						pointF4.Y = array3[m].Y;
						num35 = m;
					}
				}
				if (num35 == -1)
				{
					continue;
				}
				array[k].float_4 = Class7120.smethod_9(array[k].float_4, (float)num35 / (float)num31, firstPart);
			}
			array[k].float_4[1] = method_18(array[k].float_4[1], size.Height);
			array[k].float_4[3] = method_18(array[k].float_4[3], size.Height);
			array[k].float_4[5] = method_18(array[k].float_4[5], size.Height);
			array[k].float_4[7] = method_18(array[k].float_4[7], size.Height);
			if (array[k].bool_0)
			{
				arrayList.Add(array[k].float_4);
			}
		}
		if (num == 1f && arrayList.Count == 3)
		{
			float[] value = (float[])arrayList[0];
			arrayList[0] = arrayList[1];
			arrayList[1] = arrayList[2];
			arrayList[2] = value;
		}
		return arrayList;
	}

	private PointF method_34(PointF startPoint, PointF reflectionPoint)
	{
		PointF result = default(PointF);
		result.X = reflectionPoint.X + (reflectionPoint.X - startPoint.X);
		result.Y = reflectionPoint.Y + (reflectionPoint.Y - startPoint.Y);
		return result;
	}

	private Class6223 method_35(Class7132 element, Hashtable pathRawPoints, bool lineFilled)
	{
		float[] array = new float[pathRawPoints.Count];
		int num = 0;
		for (num = 0; num < pathRawPoints.Count; num++)
		{
			array[num] = (float)pathRawPoints[num];
		}
		return new Class6223(array);
	}

	internal void method_36(Class7132 element)
	{
		try
		{
			if (element.hashtable_0.ContainsKey("requiredExtensions"))
			{
				element.hashtable_0["requiredExtensions"].ToString();
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_37(Class7132 element, Class6213 canvas, SizeF size)
	{
		try
		{
			Class6217 @class = new Class6217();
			float[] array = new float[4];
			IDictionaryEnumerator dictionaryEnumerator = element.hashtable_0.GetEnumerator();
			try
			{
				while (dictionaryEnumerator.MoveNext())
				{
					switch (((DictionaryEntry)dictionaryEnumerator.Current).Key.ToString())
					{
					case "y2":
						array[3] = method_18(method_65(element.hashtable_0["y2"].ToString(), "y2", element), size.Height);
						break;
					case "x2":
						array[2] = method_65(element.hashtable_0["x2"].ToString(), "x2", element);
						break;
					case "y1":
						array[1] = method_18(method_65(element.hashtable_0["y1"].ToString(), "y1", element), size.Height);
						break;
					case "x1":
						array[0] = method_65(element.hashtable_0["x1"].ToString(), "x1", element);
						break;
					}
				}
			}
			finally
			{
				IDisposable disposable = dictionaryEnumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			Class6223 node = new Class6223(array);
			Class6218 class2 = new Class6218();
			class2.Add(node);
			@class.Add(class2);
			if (element.hashtable_0.ContainsKey("transform"))
			{
				method_31(element, @class, size);
			}
			if (element.hashtable_0.ContainsKey("clip-path") || element.hashtable_0.ContainsKey("view-clip-id"))
			{
				@class.Clip = method_62(size, element);
			}
			method_63(@class, element, size, canvas);
			canvas.Add(@class);
		}
		catch (Exception)
		{
		}
	}

	internal void method_38(Class7132 element, Class6213 canvas, string content, float posX, float posY, Class7195 textInfo, SizeF size)
	{
		Class7107 @class = new Class7109();
		((Class7109)@class).method_0();
		float num = 0f;
		for (int i = 0; i < content.Length; i++)
		{
			char charItem = content[i];
			Class7132 class2 = new Class7132("path", new Hashtable(), element);
			if (@class.hashtable_0.ContainsKey(charItem.ToString()))
			{
				class2.hashtable_0.Add("d", ((Class7106)@class.hashtable_0[charItem.ToString()]).string_2);
			}
			string text = "scale(" + 0.01f + ", -1)";
			text += " rotate(180)";
			string text2 = text;
			text = text2 + " translate(" + (posX + num) + "," + posY + ")";
			class2.hashtable_0.Add("transform", text);
			method_30(class2, canvas, size, translateAxis: false);
			num += smethod_8(charItem, textInfo);
		}
	}

	internal void method_39(Class7132 element, Class6213 canvas, SizeF size, string vectorFontName, Class7195 textInfo, float xPos, float yPos)
	{
		string text = element.string_1.Trim();
		float num = xPos;
		float num2 = num;
		Class7104 @class = (Class7104)hashtable_1[vectorFontName];
		string text2 = text;
		for (int i = 0; i < text2.Length; i++)
		{
			char c = text2[i];
			float num3 = textInfo.float_0;
			num3 = ((c == ' ') ? (textInfo.float_0 / 2f) : smethod_8(c, textInfo));
			float scale = 1f;
			if (!string.IsNullOrEmpty(@class.string_1))
			{
				scale = textInfo.float_0 / (float)Convert.ToDecimal(@class.string_1);
			}
			if (@class.hashtable_1.ContainsKey(c.ToString()))
			{
				method_40(element, @class.hashtable_1[c.ToString()].ToString(), scale, num, yPos, canvas, size, flip: true);
			}
			else
			{
				method_40(element, @class.hashtable_1["missing-glyph"].ToString(), scale, num, yPos, canvas, size, flip: true);
			}
			num += num3;
			float_4 += num3;
		}
		if (textInfo.bool_4 || textInfo.bool_5 || textInfo.bool_6)
		{
			Class7132 class2 = new Class7132("rect", new Hashtable(), null);
			class2.hashtable_0.Add("stroke", "none");
			if (element.hashtable_0.ContainsKey("fill"))
			{
				class2.hashtable_0.Add("fill", element.hashtable_0["fill"].ToString());
			}
			else
			{
				class2.hashtable_0.Add("fill", "none");
			}
			class2.hashtable_0.Add("x", num2.ToString());
			if (textInfo.bool_4)
			{
				class2.hashtable_0.Add("y", (yPos + textInfo.float_0 / 10f).ToString());
			}
			else if (textInfo.bool_5)
			{
				class2.hashtable_0.Add("y", (yPos - textInfo.float_0 * 0.8f).ToString());
			}
			else if (textInfo.bool_6)
			{
				class2.hashtable_0.Add("y", (yPos - textInfo.float_0 / 3f).ToString());
			}
			class2.hashtable_0.Add("width", (float_4 - xPos).ToString());
			class2.hashtable_0.Add("height", (textInfo.float_0 / 14f).ToString());
			if (element.hashtable_0.ContainsKey("transform"))
			{
				class2.hashtable_0.Add("transform", element.hashtable_0["transform"].ToString());
			}
			method_16(class2, canvas, size, translateAxis: true);
		}
	}

	private void method_40(Class7132 element, string symbolDefinition, float scale, float xPos, float yPos, Class6213 canvas, SizeF size, bool flip)
	{
		Hashtable hashtable = new Hashtable();
		hashtable.Add("d", symbolDefinition);
		string text = string.Empty;
		if (element.hashtable_0.ContainsKey("transform"))
		{
			text += element.hashtable_0["transform"];
		}
		string text2 = text;
		text = text2 + " translate(" + Convert.ToString(xPos, CultureInfo.InvariantCulture) + "," + Convert.ToString(yPos, CultureInfo.InvariantCulture) + ")";
		if (element.hashtable_0.ContainsKey("rotate"))
		{
			text = text + " rotate(" + element.hashtable_0["rotate"].ToString() + ")";
		}
		text = text + " scale(" + Convert.ToString(scale, CultureInfo.InvariantCulture) + ",";
		if (flip)
		{
			text += "-";
		}
		text = text + Convert.ToString(scale, CultureInfo.InvariantCulture) + ")";
		if (element.class7132_0.hashtable_0.ContainsKey("glyph-orientation-horizontal"))
		{
			float num = method_65(element.class7132_0.hashtable_0["glyph-orientation-horizontal"].ToString(), string.Empty, element);
			string text3 = " rotate(" + num * -1f + ")";
			text += text3;
		}
		hashtable.Add("transform", text);
		foreach (DictionaryEntry item in element.hashtable_0)
		{
			if (!hashtable.ContainsKey(item.Key.ToString()) && item.Key.ToString() != "rotate")
			{
				hashtable.Add(item.Key.ToString().Trim(), item.Value.ToString().Trim());
			}
		}
		Class7132 element2 = new Class7132("path", hashtable, null);
		method_30(element2, canvas, size, translateAxis: true);
	}

	internal void method_41(Class7132 element, Class6213 canvas, SizeF size)
	{
		try
		{
			string key = string.Empty;
			if (element.hashtable_0.ContainsKey("font-family"))
			{
				key = element.hashtable_0["font-family"].ToString();
			}
			if (!hashtable_1.ContainsKey(key))
			{
				return;
			}
			Class7104 @class = (Class7104)hashtable_1[key];
			string text = element.hashtable_0["xlink:href"].ToString();
			if (text.StartsWith("#"))
			{
				text = text.Remove(0, 1);
			}
			if (hashtable_2.ContainsKey(text))
			{
				float num = float_10;
				float num2 = 0f;
				float yPos = 0f;
				if (element.Parent.hashtable_0.ContainsKey("x"))
				{
					num2 = method_65(element.Parent.hashtable_0["x"].ToString(), "x", element);
				}
				if (element.Parent.hashtable_0.ContainsKey("y"))
				{
					yPos = method_65(element.Parent.hashtable_0["y"].ToString(), "y", element);
				}
				if (element.Parent.hashtable_0.ContainsKey("font-size"))
				{
					num = method_65(element.Parent.hashtable_0["font-size"].ToString(), "font-size", element);
				}
				float scale = num / (float)Convert.ToDecimal(@class.string_1);
				string symbolDefinition = @class.hashtable_0[hashtable_2[text].ToString()].ToString();
				method_40(element, symbolDefinition, scale, num2 + float_8, yPos, canvas, size, flip: true);
				float_8 += num * 0.7f;
			}
		}
		catch (Exception)
		{
		}
	}

	private void method_42(Class7132 element, Class6213 pdfSection, SizeF size, Class7195 textInfo, float xPos, float yPos)
	{
		string text = (textInfo.string_0 = "CustomArial");
		if (!hashtable_1.ContainsKey(text))
		{
			new Hashtable();
			Class7104 @class = new Class7104();
			Class7108 class2 = new Class7108();
			@class.string_0 = text;
			@class.string_1 = class2.float_1.ToString();
			foreach (DictionaryEntry item in class2.hashtable_0)
			{
				if (item.Value != null && item.Value is Class7106)
				{
					Class7106 class3 = (Class7106)item.Value;
					if (!@class.hashtable_1.ContainsKey(class3.string_1))
					{
						@class.hashtable_1.Add(class3.string_1, class3.string_2);
					}
				}
			}
			hashtable_1.Add(@class.string_0, @class);
		}
		method_39(element, pdfSection, size, text, textInfo, xPos, yPos);
	}

	internal void method_43(Class7132 element, SizeF size)
	{
		if (element.hashtable_0.ContainsKey("x"))
		{
			float_4 = method_66(element.hashtable_0["x"].ToString(), "x", element, size);
		}
		else
		{
			float_4 = 0f;
		}
		if (element.hashtable_0.ContainsKey("dx"))
		{
			float_4 += method_66(element.hashtable_0["dx"].ToString(), "dx", element, size);
		}
		if (element.hashtable_0.ContainsKey("y"))
		{
			float_5 = method_66(element.hashtable_0["y"].ToString(), "y", element, size);
		}
		else
		{
			float_5 = 0f;
		}
		if (element.hashtable_0.ContainsKey("dy"))
		{
			float_5 += method_66(element.hashtable_0["dy"].ToString(), "dy", element, size);
		}
	}

	internal void AddText(Class7132 element, Class6213 canvas, SizeF size)
	{
		try
		{
			Class7195 textInfo = method_52(element.class7132_0, null, size);
			textInfo = method_52(element, textInfo, size);
			method_46(element, textInfo);
			if (element.hashtable_0.ContainsKey("rotate") && Class7107.arrayList_0.Contains(textInfo.string_0))
			{
				if (!hashtable_1.ContainsKey(textInfo.string_0))
				{
					Class7104 @class = new Class7104();
					Class7109 class2 = new Class7109();
					Hashtable hashtable = new Hashtable();
					if (textInfo.string_0 == "Arial")
					{
						hashtable = class2.method_0();
					}
					else if (textInfo.string_0 == "Times")
					{
						hashtable = class2.method_1();
					}
					else
					{
						if (!(textInfo.string_0 == "Curier"))
						{
							return;
						}
						hashtable = class2.method_2();
					}
					@class.string_0 = textInfo.string_0;
					@class.string_1 = class2.float_1.ToString();
					foreach (DictionaryEntry item in hashtable)
					{
						if (!@class.hashtable_1.ContainsKey(item.Key.ToString()))
						{
							@class.hashtable_1.Add(item.Key.ToString(), ((Class7106)item.Value).string_2);
						}
					}
					hashtable_1.Add(textInfo.string_0, @class);
				}
				method_39(element, canvas, size, textInfo.string_0, textInfo, float_4, float_5);
				return;
			}
			foreach (DictionaryEntry item2 in hashtable_1)
			{
				string text = item2.Key.ToString();
				if (element.hashtable_0.ContainsKey("font-family"))
				{
					ArrayList arrayList = new ArrayList(element.hashtable_0["font-family"].ToString().Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries));
					if (arrayList.Contains(text))
					{
						method_39(element, canvas, size, text, textInfo, float_4, float_5);
						return;
					}
				}
			}
			string text2 = element.string_1.Trim();
			float posX = float_4;
			float posY = float_5;
			if (element.class7132_0.hashtable_0.ContainsKey("fill"))
			{
				textInfo.color_1 = method_47(element.class7132_0.hashtable_0["fill"].ToString());
			}
			if (element.hashtable_0.ContainsKey("fill"))
			{
				textInfo.color_1 = method_47(element.hashtable_0["fill"].ToString());
			}
			if (element.class7132_0.hashtable_0.ContainsKey("font-variant") && element.class7132_0.hashtable_0["font-variant"].ToString().Equals("small-caps"))
			{
				text2 = text2.ToUpper();
				textInfo.float_0 = Math.Abs(textInfo.float_0 / 1.3f);
			}
			if (element.class7132_0.hashtable_0.ContainsKey("textLength"))
			{
				float num = method_65(element.class7132_0.hashtable_0["textLength"].ToString(), "textLength", element);
				float num2 = smethod_7(text2, textInfo);
				if (num > num2)
				{
					float num3 = num - num2;
					textInfo.float_1 = num3 / (float)(text2.Length - 1);
				}
			}
			string[] array = string_12;
			int num4 = 0;
			while (true)
			{
				if (num4 < array.Length)
				{
					string text3 = array[num4];
					if (textInfo.string_0 == text3)
					{
						break;
					}
					num4++;
					continue;
				}
				Class6219 class3 = method_44(textInfo, text2, posX, posY);
				class3.RenderTransform = new Class6002(1f, 0f, 0f, -1f, 0f, size.Height);
				if (element.hashtable_0.ContainsKey("transform"))
				{
					Class6002 tx = Class6161.smethod_1(method_25(element.hashtable_0["transform"].ToString(), size));
					class3.RenderTransform.method_9(tx, MatrixOrder.Append);
				}
				canvas.Add(class3);
				float_4 += smethod_7(text2, textInfo);
				return;
			}
			method_38(element, canvas, text2, posX, posY, textInfo, size);
		}
		catch (Exception)
		{
		}
	}

	private Class6219 method_44(Class7195 textInfo, string content, float posX, float posY)
	{
		FontStyle fontStyle = FontStyle.Regular;
		if (textInfo.bool_2)
		{
			fontStyle |= FontStyle.Italic;
		}
		if (textInfo.bool_3)
		{
			fontStyle |= FontStyle.Bold;
		}
		Class5999 class2;
		if (hashtable_5.ContainsKey(textInfo.string_0))
		{
			Class6654 fontData = new Class6656((byte[])hashtable_5[textInfo.string_0]);
			Class6732 @class = new Class6732();
			class2 = new Class5999(textInfo.float_0, fontStyle, @class.Read(fontData, textInfo.string_0));
		}
		else
		{
			class2 = smethod_6(textInfo, fontStyle);
		}
		SizeF size = class2.method_4(content);
		Class6219 class3 = new Class6219(class2, Class6153.smethod_1(textInfo.color_1), Class6153.smethod_1(textInfo.color_1), new PointF(posX, posY), content, size, 0f);
		if (!textInfo.float_1.Equals(0f) && content.Length > 1)
		{
			float width = class2.method_4(content).Width;
			if (!textInfo.float_1.Equals(width))
			{
				float num = (width - textInfo.float_1) / (float)(content.Length - 1);
				Class6265.Class6269 class4 = new Class6265.Class6269();
				foreach (char c in content)
				{
					float num2 = class2.TrueTypeFont.method_2(c, class2.SizePoints);
					class4.method_1(null, num2 - num, 0f, 0f);
				}
				class3.Indices = class4.method_2();
			}
		}
		else if (!textInfo.float_2.Equals(0f) && content.Length > 1)
		{
			Class6265.Class6269 class5 = new Class6265.Class6269();
			foreach (char c2 in content)
			{
				float num3 = class2.TrueTypeFont.method_2(c2, class2.SizePoints);
				class5.method_1(null, num3 + textInfo.float_2, 0f, 0f);
			}
			class3.Indices = class5.method_2();
		}
		return class3;
	}

	private static Class5999 smethod_6(Class7195 textInfo, FontStyle fontStyle)
	{
		return Class6652.Instance.method_1(textInfo.string_0, textInfo.float_0, fontStyle);
	}

	internal void method_45(Class7132 element, Class6213 canvas, SizeF size)
	{
		try
		{
			Class7195 textInfo = method_52(element.class7132_0, null, size);
			textInfo = method_52(element, textInfo, size);
			string text = element.string_1.Trim();
			if (element.class7132_0.hashtable_0.ContainsKey("x"))
			{
				float_4 = method_65(element.class7132_0.hashtable_0["x"].ToString(), "x", element);
			}
			if (element.class7132_0.hashtable_0.ContainsKey("dx"))
			{
				float_4 += method_65(element.class7132_0.hashtable_0["dx"].ToString(), "dx", element);
			}
			if (element.class7132_0.hashtable_0.ContainsKey("y"))
			{
				float_5 = method_65(element.class7132_0.hashtable_0["y"].ToString(), "y", element);
			}
			if (element.class7132_0.hashtable_0.ContainsKey("dy"))
			{
				float_5 += method_65(element.class7132_0.hashtable_0["dy"].ToString(), "dy", element);
			}
			method_46(element, textInfo);
			float posX = float_4;
			float posY = float_5;
			foreach (DictionaryEntry item in hashtable_1)
			{
				string text2 = item.Key.ToString();
				if (element.hashtable_0.ContainsKey("font-family"))
				{
					ArrayList arrayList = new ArrayList(element.hashtable_0["font-family"].ToString().Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries));
					if (arrayList.Contains(text2))
					{
						method_39(element, canvas, size, text2, textInfo, float_4, float_5);
						return;
					}
				}
			}
			if (element.class7132_0.hashtable_0.ContainsKey("font-variant") && element.class7132_0.hashtable_0["font-variant"].ToString().Equals("small-caps"))
			{
				text = text.ToUpper();
				textInfo.float_0 = Math.Abs(textInfo.float_0 / 1.3f);
			}
			if (element.class7132_0.hashtable_0.ContainsKey("textLength"))
			{
				textInfo.float_1 = method_65(element.class7132_0.hashtable_0["textLength"].ToString(), "textLength", element);
			}
			Class6219 @class = method_44(textInfo, text, posX, posY);
			@class.RenderTransform = new Class6002(1f, 0f, 0f, -1f, 0f, size.Height);
			if (element.hashtable_0.ContainsKey("transform"))
			{
				Class6002 tx = Class6161.smethod_1(method_25(element.hashtable_0["transform"].ToString(), size));
				@class.RenderTransform.method_9(tx, MatrixOrder.Append);
			}
			canvas.Add(@class);
			float_4 += smethod_7(text, textInfo);
		}
		catch (Exception)
		{
		}
	}

	private void method_46(Class7132 element, Class7195 textInfo)
	{
		if (element.class7132_0.hashtable_0.ContainsKey("text-anchor"))
		{
			if (element.class7132_0.hashtable_0["text-anchor"].ToString() == "middle")
			{
				float num = smethod_7(element.string_1.Trim(), textInfo);
				float_4 -= num / 2f;
			}
			if (element.class7132_0.hashtable_0["text-anchor"].ToString() == "end")
			{
				float num2 = smethod_7(element.string_1.Trim(), textInfo);
				float_4 -= num2;
			}
		}
	}

	private static float smethod_7(string content, Class7195 textInfo)
	{
		try
		{
			Class5999 @class = smethod_6(textInfo, FontStyle.Regular);
			if (@class == null)
			{
				@class = Class6652.Instance.method_1("Arial", textInfo.float_0, FontStyle.Regular);
			}
			return @class.method_4(content).Width;
		}
		catch (Exception)
		{
			return 0f;
		}
	}

	private static float smethod_8(char charItem, Class7195 textInfo)
	{
		try
		{
			if (charItem == ' ')
			{
				return textInfo.float_0;
			}
			float num = textInfo.float_0 * 2f;
			float num2 = num;
			RectangleF rect = new RectangleF(0f, 0f, num, num2);
			Bitmap bitmap = new Bitmap((int)Math.Truncate(num), (int)Math.Truncate(num2), PixelFormat.Format24bppRgb);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.FillRectangle(Brushes.White, rect);
			graphics.DrawString(charItem.ToString(), new Font(textInfo.string_0, textInfo.float_0 * float_9), Brushes.Black, new PointF(0f, 0f));
			graphics.DrawImageUnscaled(bitmap, 0, 0);
			for (int num3 = (int)Math.Truncate(num - 1f); num3 >= 0; num3--)
			{
				int num4 = (int)Math.Truncate(num2 - 1f);
				while (num4 >= 0)
				{
					Color pixel = bitmap.GetPixel(num3, num4);
					if (pixel.R >= byte.MaxValue && pixel.G >= byte.MaxValue && pixel.B >= byte.MaxValue)
					{
						num4--;
						continue;
					}
					return num3;
				}
			}
			return num;
		}
		catch (Exception)
		{
			return 0f;
		}
	}

	internal Color method_47(string cssColor)
	{
		Color color = Color.Transparent;
		if (cssColor.ToLower() == "none")
		{
			return Color.Transparent;
		}
		try
		{
			if (cssColor.ToLower().StartsWith("rgb("))
			{
				cssColor = cssColor.Replace("rgb(", string.Empty);
				if (cssColor.ToLower().EndsWith(")"))
				{
					cssColor = cssColor.Replace(")", string.Empty);
				}
				string[] array = cssColor.Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries);
				color = Color.FromArgb(255, Convert.ToInt32(array[0]), Convert.ToInt32(array[1]), Convert.ToInt32(array[2]));
			}
			else if (cssColor.ToLower().StartsWith("#") && cssColor.Length == 7)
			{
				cssColor = cssColor.Replace("#", string.Empty);
				string[] array2 = new string[3]
				{
					cssColor.Substring(0, 2),
					cssColor.Substring(2, 2),
					cssColor.Substring(4, 2)
				};
				color = Color.FromArgb(255, int.Parse(array2[0], NumberStyles.AllowHexSpecifier), int.Parse(array2[1], NumberStyles.AllowHexSpecifier), int.Parse(array2[2], NumberStyles.AllowHexSpecifier));
			}
			else if (cssColor.ToLower().StartsWith("#") && cssColor.Length == 4)
			{
				cssColor = cssColor.Replace("#", string.Empty);
				string[] array3 = new string[3]
				{
					cssColor.Substring(0, 1),
					cssColor.Substring(1, 1),
					cssColor.Substring(2, 1)
				};
				color = Color.FromArgb(255, 15 * int.Parse(array3[0], NumberStyles.AllowHexSpecifier), 15 * int.Parse(array3[1], NumberStyles.AllowHexSpecifier), 15 * int.Parse(array3[2], NumberStyles.AllowHexSpecifier));
			}
			else
			{
				color = Color.FromName(cssColor);
			}
		}
		catch
		{
		}
		return Color.FromArgb(color.R, color.G, color.B);
	}

	internal int method_48(string styleData)
	{
		return styleData switch
		{
			"square" => 2, 
			"round" => 1, 
			"butt" => 0, 
			_ => 0, 
		};
	}

	internal int method_49(string styleData)
	{
		return styleData switch
		{
			"bevel" => 2, 
			"round" => 1, 
			"miter" => 0, 
			_ => 0, 
		};
	}

	internal string method_50(string editorContent)
	{
		editorContent.Replace("\r\n", Environment.NewLine);
		editorContent.Replace("\r", Environment.NewLine);
		editorContent.Replace("\n", Environment.NewLine);
		editorContent.Replace("\t", Environment.NewLine);
		return editorContent;
	}

	private string method_51(string svgProperty)
	{
		string text = svgProperty;
		text = text.Replace(" ", string.Empty);
		text = text.Replace("\r", string.Empty);
		text = text.Replace("\n", string.Empty);
		return text.Replace("\t", string.Empty);
	}

	internal Class7195 method_52(Class7132 element, Class7195 textInfo, SizeF size)
	{
		try
		{
			if (textInfo == null)
			{
				textInfo = new Class7195();
			}
			bool flag = false;
			if (element.hashtable_0.ContainsKey("style"))
			{
				string text = method_51(element.hashtable_0["style"].ToString());
				text.Split(new string[1] { ";" }, StringSplitOptions.RemoveEmptyEntries);
			}
			if (element.hashtable_0.ContainsKey("baseline-shift"))
			{
				if (element.hashtable_0["baseline-shift"].ToString().Equals("sub"))
				{
					textInfo.bool_0 = true;
				}
				if (element.hashtable_0["baseline-shift"].ToString().Equals("super"))
				{
					textInfo.bool_1 = true;
				}
			}
			if (element.hashtable_0.ContainsKey("font-family") && !flag)
			{
				textInfo.string_0 = method_53(element.hashtable_0["font-family"].ToString());
			}
			else if (!flag)
			{
				textInfo.string_0 = "Times-Roman";
			}
			if (element.hashtable_0.ContainsKey("font-size"))
			{
				textInfo.float_0 = method_65(element.hashtable_0["font-size"].ToString(), string.Empty, element);
			}
			if (element.hashtable_0.ContainsKey("font-style") && element.hashtable_0["font-style"].ToString().Equals("italic"))
			{
				textInfo.bool_2 = true;
			}
			if (element.hashtable_0.ContainsKey("font-weight") && (element.hashtable_0["font-weight"].ToString().Equals("bold") || element.hashtable_0["font-weight"].ToString().Equals("bolder") || element.hashtable_0["font-weight"].ToString().Equals("500") || element.hashtable_0["font-weight"].ToString().Equals("600") || element.hashtable_0["font-weight"].ToString().Equals("700") || element.hashtable_0["font-weight"].ToString().Equals("800") || element.hashtable_0["font-weight"].ToString().Equals("900")))
			{
				textInfo.bool_3 = true;
			}
			if (element.hashtable_0.ContainsKey("letter-spacing"))
			{
				textInfo.float_2 = method_65(element.hashtable_0["letter-spacing"].ToString(), string.Empty, element);
			}
			bool flag2 = false;
			bool flag3 = false;
			if (element.hashtable_0.ContainsKey("stroke") && element.hashtable_0["stroke"].ToString() != "none")
			{
				flag3 = true;
				textInfo.color_0 = method_47(element.hashtable_0["stroke"].ToString());
			}
			if (element.hashtable_0.ContainsKey("fill") && element.hashtable_0["fill"].ToString() != "none")
			{
				flag2 = true;
				textInfo.color_1 = method_47(element.hashtable_0["fill"].ToString());
			}
			if (flag2 && flag3)
			{
				textInfo.enum978_0 = Class7195.Enum978.const_0;
			}
			else if (flag2 && !flag3)
			{
				textInfo.enum978_0 = Class7195.Enum978.const_1;
			}
			else if (!flag2 && flag3)
			{
				textInfo.enum978_0 = Class7195.Enum978.const_2;
			}
			if (element.hashtable_0.ContainsKey("text-decoration"))
			{
				if (element.hashtable_0["text-decoration"].ToString() == "underline")
				{
					textInfo.bool_4 = true;
				}
				if (element.hashtable_0["text-decoration"].ToString() == "overline")
				{
					textInfo.bool_5 = true;
				}
				if (element.hashtable_0["text-decoration"].ToString() == "line-through")
				{
					textInfo.bool_6 = true;
				}
			}
			if (element.hashtable_0.ContainsKey("word-spacing"))
			{
				textInfo.float_3 = method_65(element.hashtable_0["word-spacing"].ToString(), string.Empty, element);
			}
			if (element.hashtable_0.ContainsKey("font"))
			{
				Match match = regex_0.Match((string)element.hashtable_0["font"]);
				if (match.Success)
				{
					CaptureCollection captures = match.Groups["style"].Captures;
					if (captures.Count > 0 && captures[0].Value == "italic")
					{
						textInfo.bool_2 = true;
					}
					_ = match.Groups["variant"].Captures;
					CaptureCollection captures2 = match.Groups["weight"].Captures;
					if (captures2.Count > 0 && (captures2[0].Value.Equals("bold") || captures2[0].Value.Equals("500") || captures2[0].Value.Equals("600") || captures2[0].Value.Equals("700") || captures2[0].Value.Equals("800") || captures2[0].Value.Equals("900")))
					{
						textInfo.bool_3 = true;
					}
					CaptureCollection captures3 = match.Groups["size"].Captures;
					if (captures3.Count > 0)
					{
						textInfo.float_0 = method_65(captures3[0].Value, string.Empty, element);
					}
					_ = match.Groups["height"].Captures;
					CaptureCollection captures4 = match.Groups["family"].Captures;
					if (captures4.Count > 0)
					{
						textInfo.string_0 = captures4[0].Value.TrimEnd(',', ';');
					}
				}
			}
			return textInfo;
		}
		catch (Exception)
		{
			return new Class7195();
		}
	}

	internal string method_53(string rawValue)
	{
		try
		{
			string[] array = rawValue.Split(',');
			string[] array2 = array;
			foreach (string searchStr in array2)
			{
				FontFamily[] families = FontFamily.Families;
				foreach (FontFamily fontFamily in families)
				{
					if (Class5964.Contains(fontFamily.Name, searchStr, ignoreCase: true))
					{
						return fontFamily.Name;
					}
				}
			}
			Font font = new Font(rawValue, float_10);
			if (font.Name.IndexOf(rawValue, StringComparison.CurrentCultureIgnoreCase) > -1)
			{
				return font.Name;
			}
			if (hashtable_5.ContainsKey(rawValue))
			{
				return rawValue;
			}
			foreach (Interface59 cSSRule in interface76_0.CSSRules)
			{
				if (cSSRule.Type != 5)
				{
					continue;
				}
				Interface97 @interface = Class4144.smethod_0(cSSRule as Interface60);
				if (!(@interface.FontFamily == rawValue))
				{
					continue;
				}
				foreach (Class4145 item in @interface.Src)
				{
					try
					{
						if (item.IsLocal)
						{
							Font font2 = new Font(item.URI, float_10);
							if (font2.Name.IndexOf(rawValue, StringComparison.CurrentCultureIgnoreCase) > -1)
							{
								return font2.Name;
							}
							continue;
						}
						Class4258 @class = interface384_0.imethod_0(this, new EventArgs1(item.URI));
						byte[] value;
						if ((!string.IsNullOrEmpty(item.Format) && string.Equals(item.Format, "woff", StringComparison.OrdinalIgnoreCase)) || (!string.IsNullOrEmpty(item.URI) && string.Equals(Path.GetExtension(item.URI), ".woff", StringComparison.OrdinalIgnoreCase)) || (!string.IsNullOrEmpty(item.URI) && item.URI.Contains("x-font-woff")))
						{
							Class6736 class2 = new Class6736();
							MemoryStream memoryStream = new MemoryStream();
							class2.method_0(new MemoryStream(@class.Data), memoryStream);
							value = memoryStream.GetBuffer();
						}
						else
						{
							value = @class.Data;
						}
						hashtable_5.Add(rawValue, value);
						return rawValue;
					}
					catch (Exception)
					{
					}
				}
			}
			return string_13;
		}
		catch (Exception)
		{
			return string_13;
		}
	}

	private string method_54(string urlData)
	{
		string empty = string.Empty;
		empty = urlData.Replace("url(", string.Empty);
		if (empty[0] == '#')
		{
			empty = empty.Remove(0, 1);
		}
		if (empty.EndsWith(")"))
		{
			empty = empty.Substring(0, empty.Length - 1);
		}
		return empty;
	}

	private ColorBlend method_55(float opacity, Class7196[] stops, float[] offsets, float width)
	{
		ColorBlend colorBlend = new ColorBlend();
		int num = stops.Length;
		bool flag = false;
		bool flag2 = false;
		if (offsets[0] > 0f)
		{
			num++;
			flag = true;
		}
		float num2 = offsets[stops.Length - 1];
		if (num2 < 100f || num2 < 1f)
		{
			num++;
			flag2 = true;
		}
		colorBlend.Positions = new float[num];
		colorBlend.Colors = new Color[num];
		int num3 = 0;
		float num4 = 0f;
		float num5 = 0f;
		Color black = Color.Black;
		for (int i = 0; i < num; i++)
		{
			num4 = opacity * stops[num3].float_0;
			num5 = offsets[num3] / width;
			black = Color.FromArgb((int)(num4 * 255f), stops[num3++].color_0);
			if (flag && i == 0)
			{
				colorBlend.Positions[i] = 0f;
				colorBlend.Colors[i++] = black;
			}
			colorBlend.Positions[i] = num5;
			colorBlend.Colors[i] = black;
			if (flag2 && i == num - 2)
			{
				colorBlend.Positions[i + 1] = 1f;
				colorBlend.Colors[++i] = black;
			}
		}
		if (colorBlend.Positions[colorBlend.Positions.Length - 1] != 1f)
		{
			colorBlend.Positions[colorBlend.Positions.Length - 1] = 1f;
		}
		return colorBlend;
	}

	internal PathGradientBrush method_56(float centerX, float centerY, float radius, float focalX, float focalY, float opacity, Class7196[] stops, float[] ofsets, float width)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		if (radius > 0f)
		{
			RectangleF rectangleF = new RectangleF(0f, 0f, radius * 2f, radius * 2f);
			graphicsPath.AddEllipse(rectangleF.X - (rectangleF.Width * 0.5f - centerX), rectangleF.Y - (rectangleF.Height * 0.5f - centerY), rectangleF.Width, rectangleF.Height);
			PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
			pathGradientBrush.CenterPoint = new PointF(focalX, focalY);
			ColorBlend interpolationColors = method_55(opacity, stops, ofsets, width);
			pathGradientBrush.InterpolationColors = interpolationColors;
			return pathGradientBrush;
		}
		return null;
	}

	private static float smethod_9(RectangleF bounds, float value, bool vertical)
	{
		return (vertical ? bounds.Height : bounds.Width) / 100f * value;
	}

	internal static Class5995 smethod_10(PathGradientBrush nativeBrush, RectangleF rect, float opacity)
	{
		using Class6150 @class = new Class6150((int)Math.Ceiling(rect.Width), (int)Math.Ceiling(rect.Height));
		using Class6160 class2 = new Class6160(@class);
		using MemoryStream memoryStream = new MemoryStream();
		Class6161.smethod_1(nativeBrush.Transform);
		nativeBrush.Transform = new Matrix();
		class2.method_6().FillRectangle(new SolidBrush(nativeBrush.InterpolationColors.Colors[0]), 0, 0, @class.Width, @class.Height);
		class2.method_6().FillRectangle(nativeBrush, 0, 0, @class.Width, @class.Height);
		@class.Save(memoryStream, Enum788.const_5);
		byte[] imageBytes = memoryStream.ToArray();
		Class5995 class3 = new Class5995(imageBytes);
		class3.WrapMode = WrapMode.Clamp;
		class3.Opacity = opacity;
		return class3;
	}

	internal void method_57(Class6217 path, Class7132 element, string elementData, SizeF size, Class6213 canvas)
	{
		if (elementData.StartsWith("url(#"))
		{
			string key = method_54(elementData);
			if (!hashtable_0.ContainsKey(key))
			{
				return;
			}
			Class7132 @class = (Class7132)hashtable_0[key];
			if (@class.string_0 == "linearGradient")
			{
				if (@class.hashtable_0.ContainsKey("xlink:href"))
				{
					string key2 = method_54(@class.hashtable_0["xlink:href"].ToString());
					if (hashtable_0.ContainsKey(key2))
					{
						Class7132 class2 = (Class7132)hashtable_0[key2];
						for (int i = 0; i < class2.hashtable_4.Count; i++)
						{
							@class.hashtable_4.Add(i, (Class7132)class2.hashtable_4[i]);
						}
					}
				}
				List<Class6000> list = new List<Class6000>();
				for (int j = 0; j < @class.hashtable_4.Count; j++)
				{
					if (((Class7132)@class.hashtable_4[j]).string_0 == "stop")
					{
						Class7132 class3 = (Class7132)@class.hashtable_4[j];
						Class5998 class4 = Class5998.smethod_0(method_47(class3.hashtable_0["stop-color"].ToString()));
						if (class3.hashtable_0.Contains("stop-opacity"))
						{
							class4 = new Class5998((short)((float)class4.A * (float)Convert.ToDecimal(class3.hashtable_0["stop-opacity"].ToString(), CultureInfo.InvariantCulture)), class4.R, class4.G, class4.B);
						}
						Class6000 item = new Class6000(class4, (float)Convert.ToDecimal(class3.hashtable_0["offset"].ToString(), CultureInfo.InvariantCulture));
						list.Add(item);
					}
				}
				if (list.Count > 0)
				{
					RectangleF rectangleF = smethod_2(path);
					PointF startPoint;
					PointF endPoint;
					if (@class.hashtable_0.Contains("x1") && @class.hashtable_0.Contains("x2") && @class.hashtable_0.Contains("y1") && @class.hashtable_0.Contains("y2"))
					{
						float x = (float)Convert.ToDecimal(@class.hashtable_0["x1"], CultureInfo.InvariantCulture);
						float y = (float)Convert.ToDecimal(@class.hashtable_0["y1"], CultureInfo.InvariantCulture);
						float x2 = (float)Convert.ToDecimal(@class.hashtable_0["x2"], CultureInfo.InvariantCulture);
						float y2 = (float)Convert.ToDecimal(@class.hashtable_0["y2"], CultureInfo.InvariantCulture);
						startPoint = new PointF(x, y);
						endPoint = new PointF(x2, y2);
					}
					else
					{
						startPoint = new PointF(rectangleF.Left, 0f);
						endPoint = new PointF(rectangleF.Right, 0f);
					}
					RectangleF rectangle = rectangleF;
					if (rectangle.Height.Equals(0f))
					{
						rectangle.Height += 0.01f;
					}
					if (rectangle.Width.Equals(0f))
					{
						rectangle.Width += 0.01f;
					}
					Class5993 class5 = new Class5993(startPoint, endPoint, list[0].Color, list[list.Count - 1].Color);
					class5.Rectangle = rectangle;
					class5.InterpolationColors = list.ToArray();
					class5.WrapMode = WrapMode.TileFlipX;
					if (@class.hashtable_0.Contains("gradientTransform"))
					{
						class5.Transform = Class6161.smethod_1(method_25(@class.hashtable_0["gradientTransform"].ToString(), size));
					}
					path.Brush = class5;
				}
			}
			if (@class.string_0 == "radialGradient")
			{
				if (@class.hashtable_0.ContainsKey("xlink:href"))
				{
					string key3 = method_54(@class.hashtable_0["xlink:href"].ToString());
					if (hashtable_0.ContainsKey(key3))
					{
						Class7132 class6 = (Class7132)hashtable_0[key3];
						for (int k = 0; k < class6.hashtable_4.Count; k++)
						{
							@class.hashtable_4.Add(k, (Class7132)class6.hashtable_4[k]);
						}
					}
				}
				RectangleF rectangleF2 = smethod_2(path);
				float centerX = smethod_9(rectangleF2, 50f, vertical: false);
				float centerY = smethod_9(rectangleF2, 50f, vertical: true);
				float radius = smethod_9(rectangleF2, 50f, vertical: false);
				float focalX = 0f;
				float focalY = 0f;
				if (@class.hashtable_0.ContainsKey("cx"))
				{
					centerX = method_66(@class.hashtable_0["cx"].ToString(), "x", element, rectangleF2.Size);
				}
				if (@class.hashtable_0.ContainsKey("cy"))
				{
					centerY = method_66(@class.hashtable_0["cy"].ToString(), "y", element, rectangleF2.Size);
				}
				if (@class.hashtable_0.ContainsKey("fx"))
				{
					focalX = method_66(@class.hashtable_0["fx"].ToString(), "x", element, rectangleF2.Size);
				}
				if (@class.hashtable_0.ContainsKey("fy"))
				{
					focalY = method_66(@class.hashtable_0["fy"].ToString(), "y", element, rectangleF2.Size);
				}
				if (@class.hashtable_0.ContainsKey("r"))
				{
					radius = method_66(@class.hashtable_0["r"].ToString(), "xy", element, rectangleF2.Size);
				}
				ArrayList arrayList = new ArrayList();
				ArrayList arrayList2 = new ArrayList();
				for (int l = 0; l < @class.hashtable_4.Count; l++)
				{
					if (((Class7132)@class.hashtable_4[l]).string_0 == "stop")
					{
						Class7196 class7 = new Class7196();
						Class7132 class8 = (Class7132)@class.hashtable_4[l];
						if (class8.hashtable_0.ContainsKey("offset") && class8.hashtable_0["offset"].ToString().Contains("%"))
						{
							arrayList2.Add(smethod_9(rectangleF2, (float)Convert.ToDecimal(class8.hashtable_0["offset"].ToString().Replace("%", string.Empty)), vertical: false));
						}
						if (class8.hashtable_0.ContainsKey("stop-color"))
						{
							class7.color_0 = method_47(class8.hashtable_0["stop-color"].ToString());
						}
						if (class8.hashtable_0.ContainsKey("stop-opacity"))
						{
							class7.float_0 = (float)Convert.ToDecimal(class8.hashtable_0["stop-opacity"].ToString());
						}
						arrayList.Add(class7);
					}
				}
				arrayList.Reverse();
				path.Brush = smethod_10(method_56(centerX, centerY, radius, focalX, focalY, 1f, (Class7196[])arrayList.ToArray(typeof(Class7196)), (float[])arrayList2.ToArray(typeof(float)), rectangleF2.Width), rectangleF2, 1f);
			}
			else
			{
				if (!(@class.string_0 == "pattern") || !hashtable_0.ContainsKey(key))
				{
					return;
				}
				Class6213 class9 = new Class6213();
				foreach (DictionaryEntry item2 in @class.hashtable_4)
				{
					AddNode((Class7132)item2.Value, class9, size, useTagShape: false, translateAxis: true);
				}
				canvas.Add(class9);
			}
		}
		else
		{
			path.Brush = new Class5997(Class6153.smethod_1(method_47(elementData)));
		}
	}

	private void method_58(string elementName, string elementData, Class6217 path, Class7132 element, SizeF size, Class7197 style, Class6213 canvas)
	{
		try
		{
			path.FillMode = FillMode.Winding;
			switch (elementName)
			{
			case "fill":
				if (elementData != "none")
				{
					method_57(path, element, elementData, size, canvas);
				}
				break;
			case "fill-opacity":
				style.float_4 = (float)Convert.ToDecimal(elementData, CultureInfo.InvariantCulture);
				break;
			case "fill-rule":
				if (elementData == "winding")
				{
					path.FillMode = FillMode.Winding;
				}
				else if (elementData == "evenodd")
				{
					path.FillMode = FillMode.Alternate;
				}
				break;
			case "stroke":
				if (elementData != "none")
				{
					style.bool_0 = true;
					style.class5998_0 = Class6153.smethod_1(method_47(elementData));
				}
				else
				{
					style.bool_0 = false;
				}
				break;
			case "stroke-dasharray":
				style.float_0 = method_64(elementData, path, size);
				break;
			case "stroke-dashoffset":
				style.float_1 = (float)Math.Truncate(method_65(elementData, string.Empty, element));
				break;
			case "stroke-linecap":
				style.int_0 = method_48(elementData);
				break;
			case "stroke-linejoin":
				style.int_1 = method_49(elementData);
				break;
			case "stroke-opacity":
				style.float_3 = method_65(elementData, string.Empty, element);
				break;
			case "stroke-width":
				style.float_2 = method_65(elementData, "xy", element);
				break;
			}
			if (!element.hashtable_0.ContainsKey("transform") || !element.hashtable_0["transform"].ToString().Contains("scale"))
			{
				return;
			}
			Hashtable hashtable = method_24(element.hashtable_0["transform"].ToString(), size);
			float num = 1f;
			for (int num2 = hashtable.Count - 1; num2 >= 0; num2--)
			{
				Class7193 @class = (Class7193)hashtable[num2];
				string text = @class.string_0;
				float[] array = @class.float_0;
				string text2;
				if ((text2 = text) != null && text2 == "scale")
				{
					float num3 = array[0];
					if (array[1] < num3)
					{
						num3 = array[1];
					}
					num = ((num != 1f) ? (num * num3) : num3);
				}
			}
			style.float_5 = num;
		}
		catch (Exception)
		{
		}
	}

	private void method_59(ref Class7132 shape, RectangleF bounds)
	{
		ArrayList arrayList = new ArrayList(new string[4] { "x", "cx", "r", "width" });
		ArrayList arrayList2 = new ArrayList(new string[3] { "y", "cy", "height" });
		Hashtable hashtable = new Hashtable();
		foreach (DictionaryEntry item in shape.hashtable_0)
		{
			if (arrayList.Contains(item.Key.ToString()) || arrayList2.Contains(item.Key.ToString()))
			{
				float num = (float)Convert.ToDecimal(item.Value.ToString(), CultureInfo.InvariantCulture);
				if (arrayList.Contains(item.Key.ToString()))
				{
					num *= bounds.Width;
				}
				if (arrayList2.Contains(item.Key.ToString()))
				{
					num *= bounds.Height;
				}
				hashtable.Add(item.Key.ToString(), num);
			}
		}
		shape.hashtable_0 = hashtable;
	}

	private Class6218 method_60(Class7132 element, bool useTagShape, SizeF size)
	{
		float xPos = 0f;
		float yPos = 0f;
		float radius = 0f;
		IDictionaryEnumerator dictionaryEnumerator = element.hashtable_0.GetEnumerator();
		try
		{
			while (dictionaryEnumerator.MoveNext())
			{
				switch (((DictionaryEntry)dictionaryEnumerator.Current).Key.ToString())
				{
				case "r":
					radius = method_65(element.hashtable_0["r"].ToString(), "r", element);
					break;
				case "cy":
					yPos = method_18(method_65(element.hashtable_0["cy"].ToString(), "cy", element), size.Height);
					break;
				case "cx":
					xPos = method_65(element.hashtable_0["cx"].ToString(), "cx", element);
					break;
				}
			}
		}
		finally
		{
			IDisposable disposable = dictionaryEnumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		ArrayList arrayList = Class7120.smethod_7(radius, xPos, yPos);
		Class6218 @class = new Class6218();
		for (int i = 0; i < arrayList.Count; i++)
		{
			float[] array = (float[])arrayList[i];
			Struct219 bezier = default(Struct219);
			bezier.StartPoint = new PointF(array[0], array[1]);
			bezier.ControlPoint1 = new PointF(array[2], array[3]);
			bezier.ControlPoint2 = new PointF(array[4], array[5]);
			bezier.EndPoint = new PointF(array[6], array[7]);
			Class6222 node = new Class6222(bezier);
			@class.Add(node);
		}
		return @class;
	}

	private Class6218 method_61(Class7132 element, SizeF size)
	{
		element.method_1();
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		IDictionaryEnumerator dictionaryEnumerator = element.hashtable_0.GetEnumerator();
		try
		{
			while (dictionaryEnumerator.MoveNext())
			{
				switch (((DictionaryEntry)dictionaryEnumerator.Current).Key.ToString())
				{
				case "ry":
					num4 = method_65(element.hashtable_0["ry"].ToString(), "ry", element);
					break;
				case "cy":
					num2 = method_18(method_65(element.hashtable_0["cy"].ToString(), "cy", element), size.Height);
					break;
				case "rx":
					num3 = method_65(element.hashtable_0["rx"].ToString(), "rx", element);
					break;
				case "cx":
					num = method_65(element.hashtable_0["cx"].ToString(), "cx", element);
					break;
				}
			}
		}
		finally
		{
			IDisposable disposable = dictionaryEnumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		float left = num - num3;
		float bottom = num2 - num4;
		float width = num3 * 2f;
		float height = num4 * 2f;
		ArrayList arrayList = Class7120.smethod_10(left, bottom, width, height);
		Class6218 @class = new Class6218();
		for (int i = 0; i < arrayList.Count; i++)
		{
			float[] array = (float[])arrayList[i];
			Struct219 bezier = default(Struct219);
			bezier.StartPoint = new PointF(array[0], array[1]);
			bezier.ControlPoint1 = new PointF(array[2], array[3]);
			bezier.ControlPoint2 = new PointF(array[4], array[5]);
			bezier.EndPoint = new PointF(array[6], array[7]);
			@class.Add(new Class6222(bezier));
		}
		return @class;
	}

	internal Class6217 method_62(SizeF size, Class7132 element)
	{
		Class6217 @class = null;
		ArrayList arrayList = new ArrayList(new string[5] { "circle", "ellipse", "path", "polygon", "rect" });
		if (element.hashtable_0.ContainsKey("clip-path"))
		{
			string[] array = element.hashtable_0["clip-path"].ToString().Split(new string[1] { ";" }, StringSplitOptions.RemoveEmptyEntries);
			string[] array2 = array;
			foreach (string urlData in array2)
			{
				string key = method_54(urlData);
				if (!hashtable_3.ContainsKey(key))
				{
					continue;
				}
				Class7132 class2 = (Class7132)hashtable_3[key];
				bool flag = false;
				if (class2.hashtable_0.ContainsKey("clipPathUnits") && class2.hashtable_0["clipPathUnits"].ToString() == "objectBoundingBox")
				{
					flag = true;
				}
				RectangleF bounds = default(RectangleF);
				if (flag)
				{
					bounds = method_8(element, size);
				}
				@class = new Class6217();
				foreach (DictionaryEntry item in class2.hashtable_4)
				{
					Class7132 shape = (Class7132)item.Value;
					if (flag && arrayList.Contains(shape.string_0))
					{
						method_59(ref shape, bounds);
					}
					switch (shape.string_0)
					{
					case "rect":
						@class.Add(method_15(shape, size, translateAxis: true));
						break;
					case "polygon":
						@class = method_22(shape, size, closePath: true);
						break;
					case "path":
						@class = method_29(shape, size, translateAxis: true);
						break;
					case "ellipse":
						@class.Add(method_61(shape, size));
						break;
					case "circle":
						@class.Add(method_60(shape, useTagShape: true, size));
						break;
					}
				}
			}
		}
		element.hashtable_0.ContainsKey("view-clip-id");
		if (@class != null && @class.Count != 0)
		{
			return @class;
		}
		return null;
	}

	internal void method_63(Class6217 path, Class7132 element, SizeF size, Class6213 canvas)
	{
		try
		{
			Class7197 @class = new Class7197();
			if (element.hashtable_0.ContainsKey("style"))
			{
				string text = element.hashtable_0["style"].ToString();
				string[] array = text.Split(new string[4] { ";", "\r", "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries);
				string[] array2 = array;
				foreach (string text2 in array2)
				{
					method_58(text2.Split(':')[0].Trim(), text2.Split(':')[1].Trim(), path, element, size, @class, canvas);
				}
			}
			foreach (DictionaryEntry item in element.hashtable_0)
			{
				method_58(item.Key.ToString().Trim(), item.Value.ToString().Trim(), path, element, size, @class, canvas);
			}
			if (@class.float_4 != 0f)
			{
				if (path.Brush != null && path.Brush is Class5997)
				{
					Class5997 class2 = (Class5997)path.Brush;
					class2.Color = new Class5998((int)((float)class2.Color.A * @class.float_4), class2.Color.R, class2.Color.G, class2.Color.B);
				}
			}
			else
			{
				path.Brush = null;
			}
			if (@class.bool_0)
			{
				Class5998 color = @class.class5998_0;
				if (@class.float_3 != 0f)
				{
					color = new Class5998((int)((float)@class.class5998_0.A * @class.float_3), @class.class5998_0.R, @class.class5998_0.G, @class.class5998_0.B);
				}
				Class6003 class3 = new Class6003(color, @class.float_2 * Math.Abs(@class.float_5));
				if (@class.float_0.Length > 1)
				{
					class3.DashPattern = @class.float_0;
				}
				if (@class.float_1 != -1f)
				{
					class3.DashOffset = @class.float_1;
				}
				if (@class.int_0 != -1)
				{
					switch (@class.int_0)
					{
					default:
						class3.DashCap = DashCap.Flat;
						break;
					case 2:
						class3.DashCap = DashCap.Round;
						break;
					case 3:
						class3.DashCap = DashCap.Triangle;
						break;
					}
					class3.StartCap = (LineCap)@class.int_0;
					class3.EndCap = (LineCap)@class.int_0;
				}
				if (@class.int_1 != -1)
				{
					switch (@class.int_1)
					{
					case 0:
						class3.LineJoin = LineJoin.Miter;
						break;
					case 1:
						class3.LineJoin = LineJoin.Round;
						break;
					case 2:
						class3.LineJoin = LineJoin.Bevel;
						break;
					}
				}
				path.Pen = class3;
			}
			if (!element.hashtable_0.ContainsKey("fill") && arrayList_4.Contains(element.string_0))
			{
			}
		}
		catch (Exception)
		{
		}
	}

	internal float[] method_64(string svgInfo, Class6217 graphElement, SizeF size)
	{
		string[] array = svgInfo.Split(new string[2] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length == 1 && array[0] == "null")
		{
			return new float[0];
		}
		float[] array2 = new float[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = (float)Convert.ToDecimal(method_65(array[i], string.Empty, null));
		}
		return array2;
	}

	internal float method_65(string cssSize, string paramName, Class7132 element)
	{
		return method_66(cssSize, paramName, element, SizeF.Empty);
	}

	internal float method_66(string cssSize, string paramName, Class7132 element, SizeF definedSize)
	{
		CultureInfo provider = new CultureInfo("en-US");
		try
		{
			if (hashtable_8.ContainsKey(cssSize))
			{
				return (float)hashtable_8[cssSize];
			}
			string text = string.Empty;
			string value = cssSize;
			if (cssSize.Length >= 3)
			{
				string text2 = cssSize.Substring(cssSize.Length - 2, 2);
				if (!float.TryParse(text2.Trim('.'), out var _))
				{
					text = cssSize.Substring(cssSize.Length - 2, 2);
					value = cssSize.Substring(0, cssSize.Length - 2);
				}
			}
			if (cssSize.EndsWith("%"))
			{
				text = cssSize.Substring(cssSize.Length - 1, 1);
				value = cssSize.Substring(0, cssSize.Length - 1);
			}
			float num = 0f;
			switch (text)
			{
			case "":
				num = (float)Convert.ToDecimal(value, provider) * 0.75f;
				hashtable_8.Add(cssSize, num);
				break;
			case "pt":
				num = (float)Convert.ToDecimal(value, provider);
				hashtable_8.Add(cssSize, num);
				break;
			case "em":
			{
				float num2 = 1f;
				if (paramName != "font-size" && element != null && element.hashtable_0.Contains("font-size"))
				{
					num2 = method_65(element.hashtable_0["font-size"].ToString(), "font-size", element);
				}
				num = (float)Convert.ToDecimal(value, provider) * num2;
				hashtable_8.Add(cssSize, num);
				break;
			}
			case "ex":
				num = (float)Convert.ToDecimal(value, provider) / 4.30554f;
				hashtable_8.Add(cssSize, num);
				break;
			case "%":
				num = (float)Convert.ToDecimal(value, provider);
				break;
			case "px":
				num = (float)Convert.ToDecimal(value, provider) * 0.75f;
				hashtable_8.Add(cssSize, num);
				break;
			case "in":
				num = (float)Convert.ToDecimal(value, provider) * 72f;
				hashtable_8.Add(cssSize, num);
				break;
			case "cm":
				num = (float)Convert.ToDecimal(value, provider) * 28.346f;
				hashtable_8.Add(cssSize, num);
				break;
			case "mm":
				num = (float)Convert.ToDecimal(value, provider) * 2.8346f;
				hashtable_8.Add(cssSize, num);
				break;
			case "pc":
				num = (float)Convert.ToDecimal(value, provider) * 12f;
				hashtable_8.Add(cssSize, num);
				break;
			default:
				num = (float)Convert.ToDecimal(cssSize, provider);
				hashtable_8.Add(cssSize, num);
				break;
			}
			SizeF sizeF = (definedSize.IsEmpty ? new SizeF(float_6, float_7) : definedSize);
			if (cssSize.EndsWith("%"))
			{
				if (arrayList_5.Contains(paramName))
				{
					num *= sizeF.Width / 100f;
				}
				if (arrayList_6.Contains(paramName))
				{
					num *= sizeF.Height / 100f;
				}
				if (arrayList_7.Contains(paramName))
				{
					num *= (float)(Math.Sqrt(sizeF.Width * sizeF.Width + sizeF.Height * sizeF.Height) / Math.Sqrt(2.0)) / 100f;
				}
			}
			return num;
		}
		catch (Exception)
		{
			return 0f;
		}
	}
}
