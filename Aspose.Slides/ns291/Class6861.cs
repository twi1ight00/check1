using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using ns164;
using ns165;
using ns167;
using ns218;
using ns223;
using ns224;
using ns227;
using ns235;
using ns276;
using ns292;
using ns293;
using ns298;
using ns299;
using ns300;
using ns301;
using ns318;
using ns99;

namespace ns291;

internal abstract class Class6861 : IDisposable, Interface145, Interface333
{
	private class Stream14 : MemoryStream
	{
		public override void Close()
		{
		}

		public void method_0()
		{
			base.Close();
		}
	}

	internal class Class6864 : Interface385
	{
		private Interface326 interface326_0;

		private string string_0;

		private Class6861 class6861_0;

		private readonly bool bool_0;

		public string SvgPath => string_0;

		public Class6864(Interface326 keeperCallback, Class6861 builder, bool compress)
		{
			interface326_0 = keeperCallback;
			class6861_0 = builder;
			bool_0 = compress;
		}

		private static bool smethod_0(byte[] a1, byte[] a2)
		{
			if (a1.Length != a2.Length)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < a1.Length)
				{
					if (a1[num] != a2[num])
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

		public string imethod_0(byte[] imageData, Enum979 imageType, string suggestedFileName)
		{
			string key = smethod_2(new MemoryStream(imageData));
			if (class6861_0.hashtable_0[key] is byte[] a && smethod_0(imageData, a))
			{
				return class6861_0.hashtable_1[key] as string;
			}
			Enum922 imageType2 = Enum922.const_7;
			string text = ".png";
			switch (imageType)
			{
			case Enum979.const_0:
				imageType2 = Enum922.const_0;
				text = ".jpg";
				break;
			case Enum979.const_1:
				imageType2 = Enum922.const_1;
				break;
			case Enum979.const_2:
				imageType2 = Enum922.const_2;
				text = ".bmp";
				break;
			case Enum979.const_3:
				imageType2 = Enum922.const_3;
				text = ".gif";
				break;
			case Enum979.const_4:
				imageType2 = Enum922.const_4;
				text = ".tiff";
				break;
			}
			string text2 = interface326_0.imethod_2(imageData, imageType2, class6861_0.class6873_0.method_0() + text);
			class6861_0.hashtable_0[key] = imageData;
			class6861_0.hashtable_1[key] = text2;
			return text2;
		}

		public string imethod_1(byte[] fontData, string suggestedFileName)
		{
			string arg = $"{smethod_2(new MemoryStream(fontData))}_{fontData.Length}";
			string uri = suggestedFileName;
			if (!interface326_0.imethod_3($"{arg}_{Path.GetExtension(suggestedFileName)}", ref uri))
			{
				uri = interface326_0.imethod_5(new MemoryStream(fontData), suggestedFileName);
				interface326_0.imethod_4($"{arg}_{Path.GetExtension(suggestedFileName)}", uri);
			}
			return uri;
		}

		internal static byte[] smethod_1(byte[] data, Enum922 imageType)
		{
			if (imageType != Enum922.const_6)
			{
				return data;
			}
			return Stream9.smethod_1(data);
		}

		public string imethod_2(byte[] htmlData, string suggestedFileName)
		{
			Enum922 imageType = (bool_0 ? Enum922.const_6 : Enum922.const_5);
			string text = (bool_0 ? ".svgz" : ".svg");
			byte[] data = smethod_1(Class6793.smethod_3(Encoding.UTF8.GetString(htmlData)), imageType);
			string_0 = interface326_0.imethod_1(data, imageType, class6861_0.class6873_0.method_0() + text);
			return string_0;
		}
	}

	internal const float float_0 = 12f;

	private Class6869 class6869_0;

	private readonly Class6873 class6873_0;

	private Class6871 class6871_0;

	private readonly string string_0;

	private Enum928 enum928_0;

	private List<Class6877> list_0;

	private readonly Class6858 class6858_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private int int_0;

	private readonly Interface326 interface326_0;

	private readonly string string_1;

	private Class6868 class6868_0;

	private MemoryStream memoryStream_0;

	private MemoryStream memoryStream_1;

	private readonly Class6794 class6794_0;

	private readonly string string_2;

	private string string_3;

	private int int_1;

	private int int_2;

	private string string_4;

	private string string_5;

	private Interface255 interface255_0;

	private bool bool_0;

	private Hashtable hashtable_0 = new Hashtable();

	private Hashtable hashtable_1 = new Hashtable();

	private Enum928 Mode => enum928_0;

	protected abstract string RootNamespace { get; }

	protected Class6871 WriterHelper => class6871_0;

	private Class6873.Enum932 CurrentSvgFormat
	{
		get
		{
			if (!class6858_0.CompressSvgGraphics)
			{
				return Class6873.Enum932.const_1;
			}
			return Class6873.Enum932.const_2;
		}
	}

	protected Class6861(Class6858 options, string filename, string title)
		: this(options, filename, title, new Class6791(filename), null)
	{
	}

	protected Class6861(Class6858 options, string filename, string title, Interface326 callback, Interface255 progressCallback)
	{
		Class6892.smethod_0(callback, "callback");
		string_1 = Path.GetFileName(filename);
		string_0 = title;
		class6858_0 = options;
		class6873_0 = new Class6873(Class6872.smethod_3(filename));
		int_0 = 0;
		interface326_0 = callback;
		interface255_0 = progressCallback;
		class6794_0 = interface326_0.imethod_0();
		string_2 = interface326_0.imethod_9();
		if (options.StreamingOptions.EnableStyleSheetPerPageGeneration && string_2 == null)
		{
			string_2 = "style{0}.css";
		}
		memoryStream_0 = new MemoryStream();
		class6868_0 = new Class6868(memoryStream_0, options.CSSWriterOptions);
		Class7190.smethod_3();
	}

	protected Class6861(Class6858 options, string filename)
		: this(options, filename, string.Empty)
	{
	}

	private void method_0()
	{
		enum928_0 = Enum928.const_2;
	}

	private void method_1()
	{
		enum928_0 = Enum928.const_1;
	}

	protected abstract void vmethod_0();

	protected abstract void vmethod_1();

	private Class6877 method_2(string id)
	{
		foreach (Class6877 item in list_0)
		{
			if (item.Name == id)
			{
				return item;
			}
		}
		throw new ArgumentException(id);
	}

	public void imethod_0()
	{
		if (!class6858_0.DocumentPerPageGeneration)
		{
			method_5();
		}
	}

	private string method_3()
	{
		string extension = Path.GetExtension(string_1);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(string_1);
		string text;
		string path;
		do
		{
			int_0++;
			text = fileNameWithoutExtension + int_0.ToString(CultureInfo.InvariantCulture) + extension;
			path = Path.Combine(class6794_0.BundleRoot, text);
		}
		while (File.Exists(path));
		return text;
	}

	internal void method_4()
	{
		string_4 = (class6858_0.PageStyleOptions.ResolutionDependentFlow ? "inline-block" : "block");
		memoryStream_1 = new MemoryStream();
		if (((!class6858_0.StreamingOptions.EnableSingleStreamConversion && !class6858_0.StreamingOptions.EnableStyleSheetPerPageGeneration) || !class6858_0.DocumentPerPageGeneration) && class6868_0 != null)
		{
			if (int_1 == 0)
			{
				int_1++;
			}
		}
		else
		{
			memoryStream_0 = new MemoryStream();
			class6868_0 = new Class6868(memoryStream_0, class6858_0.CSSWriterOptions);
			int_1++;
		}
		string_3 = ((!class6858_0.StreamingOptions.EnableStyleSheetPerPageGeneration || string_2 == null) ? string_2 : string.Format(string_2, int_1));
		class6869_0 = new Class6870(memoryStream_1, class6868_0, class6794_0, (string_3 != null) ? class6794_0.method_4(string_3) : class6794_0.method_4("style.css"));
		if (class6871_0 == null)
		{
			class6871_0 = new Class6871(class6869_0);
			class6871_0.IsFixedLyaout = class6858_0.FixedLayout;
		}
		else
		{
			class6871_0.method_0(class6869_0);
		}
	}

	private void method_5()
	{
		method_4();
		vmethod_0();
		class6871_0.method_14(RootNamespace, class6858_0.FixedLayout).method_15();
		vmethod_1();
		class6871_0.method_16(string_0).method_3().method_17();
		method_6();
	}

	private void method_6()
	{
		Class6866 @class = new Class6866();
		@class.VerticalAlign = "baseline";
		@class.Position = "relative";
		@class.Top = "-0.4em";
		Class6866 class2 = new Class6866();
		class2.VerticalAlign = "baseline";
		class2.Position = "relative";
		class2.Top = "0.4em";
		class6871_0.method_12("sup", @class).method_12("sub", class2);
		if (class6858_0.FixedLayout)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("a:link {text-decoration:none;}\na:visited {text-decoration:none;}\n");
			stringBuilder.Append("@media screen and (min-device-pixel-ratio:0), (-webkit-min-device-pixel-ratio:0), (min--moz-device-pixel-ratio: 0) { .layer { font-size:10em; transform:scale(0.1); -moz-transform:scale(0.1); -webkit-transform:scale(0.1); -moz-transform-origin:top left; -webkit-transform-origin:top left; } }").Append("\n").Append(".ie { font-size: 1pt; }\n")
				.Append(".ie body { font-size: 12em; }\n");
			class6868_0.method_4(stringBuilder.ToString(), 2);
		}
	}

	private void method_7()
	{
		class6871_0.method_3().method_3();
		method_8();
	}

	internal void method_8()
	{
		class6869_0.Flush();
		memoryStream_1.Seek(0L, SeekOrigin.Begin);
		if (class6858_0.StreamingOptions.EnableSingleStreamConversion)
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlTextReader xmlTextReader = new XmlTextReader(memoryStream_1);
			xmlTextReader.ProhibitDtd = false;
			xmlTextReader.XmlResolver = new Class6789();
			xmlDocument.Load(xmlTextReader);
			XmlNode xmlNode;
			XmlElement xmlElement;
			if (string.IsNullOrEmpty(RootNamespace))
			{
				xmlNode = xmlDocument.SelectSingleNode("/html/head");
				xmlElement = xmlDocument.CreateElement("style");
			}
			else
			{
				XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
				xmlNamespaceManager.AddNamespace("htmlns", RootNamespace);
				xmlNode = xmlDocument.SelectSingleNode("/htmlns:html/htmlns:head", xmlNamespaceManager);
				xmlElement = xmlDocument.CreateElement("style", RootNamespace);
			}
			if (xmlNode == null)
			{
				throw new ApplicationException("Head element not resolved.");
			}
			xmlElement.SetAttribute("type", "text/css");
			class6868_0.Flush();
			memoryStream_0.Seek(0L, SeekOrigin.Begin);
			xmlElement.InnerText = Encoding.UTF8.GetString(memoryStream_0.ToArray());
			xmlNode.AppendChild(xmlElement);
			memoryStream_1 = new MemoryStream();
			xmlDocument.Save(memoryStream_1);
			memoryStream_1.Seek(0L, SeekOrigin.Begin);
			method_21();
		}
		else if (class6858_0.StreamingOptions.EnableStyleSheetPerPageGeneration && class6858_0.DocumentPerPageGeneration)
		{
			method_9();
		}
		interface326_0.imethod_8(memoryStream_1, class6858_0.DocumentPerPageGeneration ? method_3() : string_1);
		method_20();
	}

	private void method_9()
	{
		class6868_0.Flush();
		memoryStream_0.Seek(0L, SeekOrigin.Begin);
		if (class6868_0.StyleRestrictionPositions.Count <= 1 && (class6868_0.StyleRestrictionPositions.Count != 1 || class6868_0.StyleRestrictionPositions[0] >= memoryStream_0.Length))
		{
			interface326_0.imethod_6(memoryStream_0, string_3 ?? "style.css");
		}
		else
		{
			smethod_0(string_3 ?? "style.css", int_1, class6868_0, memoryStream_0, interface326_0);
		}
		method_21();
	}

	internal static void smethod_0(string path, int currentPageIndex, Class6868 writer, Stream stream, Interface326 callback)
	{
		int i = 0;
		StringBuilder stringBuilder = new StringBuilder();
		string[] array = new string[writer.StyleRestrictionPositions.Count];
		for (; i < writer.StyleRestrictionPositions.Count; i++)
		{
			if (i > 0)
			{
				smethod_1(i, array, callback, currentPageIndex, stringBuilder);
			}
		}
		if (writer.StyleRestrictionPositions[writer.StyleRestrictionPositions.Count - 1] + 1 < stream.Length)
		{
			smethod_1(i, array, callback, currentPageIndex, stringBuilder);
		}
		byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
		i = 0;
		int num = 0;
		for (; i < writer.StyleRestrictionPositions.Count; i++)
		{
			byte[] array2 = new byte[writer.StyleRestrictionPositions[i] - num];
			stream.Read(array2, 0, array2.Length);
			num = writer.StyleRestrictionPositions[i];
			MemoryStream memoryStream;
			if (i == 0)
			{
				memoryStream = new MemoryStream();
				memoryStream.Write(bytes, 0, bytes.Length);
				memoryStream.Write(array2, 0, array2.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
			}
			else
			{
				memoryStream = new MemoryStream(array2);
			}
			callback.imethod_6(memoryStream, (i == 0) ? path : array[i - 1]);
		}
		if (num + 1 < stream.Length)
		{
			byte[] array3 = new byte[stream.Length - num];
			stream.Read(array3, 0, array3.Length);
			callback.imethod_6(new MemoryStream(array3), array[i - 1]);
		}
	}

	private static void smethod_1(int i, string[] cssNames, Interface326 callback, int currentPageIndex, StringBuilder sb)
	{
		cssNames[i - 1] = callback.imethod_7(currentPageIndex, i);
		if (cssNames[i - 1] == null)
		{
			cssNames[i - 1] = $"style{currentPageIndex}p{i}.css";
		}
		sb.Append("@import ").Append("'").Append(cssNames[i - 1])
			.Append("';\n");
	}

	private void method_10()
	{
		if (class6858_0.PageStyleOptions.ResolutionDependentFlow)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("body > div {");
			stringBuilder.AppendLine("min-width: " + class6871_0.method_47(float_3) + ";");
			stringBuilder.AppendLine("min-height: " + class6871_0.method_47(float_4) + ";");
			stringBuilder.AppendLine("}");
			class6868_0.method_4(stringBuilder.ToString(), 1);
		}
	}

	public void imethod_1()
	{
		if (!class6858_0.DocumentPerPageGeneration)
		{
			method_10();
			method_7();
		}
		if (!class6858_0.StreamingOptions.EnableSingleStreamConversion && !class6858_0.StreamingOptions.EnableStyleSheetPerPageGeneration)
		{
			method_9();
		}
	}

	private void method_11()
	{
		class6871_0.method_45().method_5(Enum929.const_9, "layer");
		class6871_0.method_45().method_6().method_7(Enum930.const_41, "relative")
			.method_7(Enum930.const_17, class6871_0.method_47(float_1));
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(class6871_0.method_9(out var alreadyExist)).Append(' ');
		class6871_0.method_6().method_7(Enum930.const_15, class6871_0.method_47(float_2 / 10f));
		string text = class6871_0.method_9(out alreadyExist);
		stringBuilder.Append(text);
		class6871_0.method_6().method_7(Enum930.const_15, class6871_0.method_47(float_2));
		class6871_0.method_10("ie ." + text, out alreadyExist);
		class6871_0.method_11(stringBuilder.ToString());
	}

	public void imethod_2(float pageWidth, float pageHeight)
	{
		bool_0 = true;
		int_2++;
		Notify(int_2, Class5961.Enum741.const_0);
		if (class6858_0.DocumentPerPageGeneration)
		{
			method_5();
		}
		if (class6858_0.FixedLayout)
		{
			class6871_0.method_45().method_6().method_7(Enum930.const_12, "1em")
				.method_7(Enum930.const_26, "0.0em")
				.method_7(Enum930.const_17, class6871_0.method_47(pageWidth))
				.method_7(Enum930.const_15, class6871_0.method_47(pageHeight));
			Class6796 pageStyleOptions = class6858_0.PageStyleOptions;
			if (class6858_0.DrawPageBorders)
			{
				pageStyleOptions.TopBorderStyle.Length.method_0(12f);
				pageStyleOptions.RightBorderStyle.Length.method_0(12f);
				pageStyleOptions.BottomBorderStyle.Length.method_0(12f);
				pageStyleOptions.LeftBorderStyle.Length.method_0(12f);
				class6871_0.method_7(Enum930.const_6, pageStyleOptions.TopBorderStyle.ToString()).method_7(Enum930.const_7, pageStyleOptions.RightBorderStyle.ToString()).method_7(Enum930.const_8, pageStyleOptions.BottomBorderStyle.ToString())
					.method_7(Enum930.const_9, pageStyleOptions.LeftBorderStyle.ToString());
			}
			else
			{
				class6871_0.method_7(Enum930.const_4, "none");
			}
			pageStyleOptions.PageMargin.method_0(12f);
			class6871_0.method_7(Enum930.const_22, string_4).method_7(Enum930.const_27, pageStyleOptions.PageMargin.ToString()).method_8();
		}
		float_1 = pageWidth;
		float_2 = pageHeight;
		float_3 = Math.Max(float_3, float_1);
		float_4 = Math.Max(float_4, float_2);
	}

	public void imethod_3(float pageWidth, float pageHeight, Class4767 attributes)
	{
		if (attributes != null && attributes.method_0(Enum670.const_5) && class6858_0.RemoveTopBottomMargin)
		{
			pageHeight -= (float)attributes[Enum670.const_5];
			if (attributes.method_0(Enum670.const_4))
			{
				pageHeight += (float)attributes[Enum670.const_4];
			}
		}
		imethod_2(pageWidth, pageHeight);
	}

	public void imethod_4()
	{
		if (class6858_0.FixedLayout)
		{
			class6871_0.method_3();
			if (!bool_0)
			{
				class6871_0.method_3();
				class6871_0.method_3();
			}
		}
		if (class6858_0.DocumentPerPageGeneration)
		{
			method_7();
		}
		Notify(int_2, Class5961.Enum741.const_1);
	}

	public void imethod_5(float leftIndent, float rightIndent, float spaceBefore, float spaceAfter)
	{
		class6871_0.Indent = false;
	}

	public void imethod_6(Class4767 attributes)
	{
		if (attributes.Count == 0)
		{
			method_1();
			class6871_0.method_18();
			return;
		}
		if (class6858_0.FixedLayout)
		{
			if (bool_0)
			{
				method_11();
				bool_0 = false;
			}
			class6871_0.method_45();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("position:absolute; ").AppendFormat("top:{0}em; ", ((float)attributes[Enum670.const_1] / class6871_0.CurrentFontSize).ToString("0.####", Class6872.HtmlCulture)).AppendFormat("left:{0}em;", ((float)attributes[Enum670.const_0] / class6871_0.CurrentFontSize).ToString("0.####", Class6872.HtmlCulture));
			class6871_0.method_5(Enum929.const_30, stringBuilder.ToString());
		}
		else if (attributes.method_0(Enum670.const_19))
		{
			method_12(attributes);
			class6871_0.method_21();
		}
		else
		{
			if (Mode == Enum928.const_2)
			{
				method_13();
			}
			if (Mode != Enum928.const_1)
			{
				method_1();
			}
			class6871_0.method_18();
			if (attributes.method_0(Enum670.const_11))
			{
				Enum671 @enum = (Enum671)attributes[Enum670.const_11];
				if (@enum == Enum671.const_3 && attributes.method_0(Enum670.const_6))
				{
					string value = $"text-align:justify; width:{((float)attributes[Enum670.const_6]).ToString(CultureInfo.InvariantCulture)}pt";
					class6871_0.method_5(Enum929.const_30, value);
					class6871_0.IgnoreWhiteSpace = true;
				}
			}
		}
		class6871_0.Indent = false;
	}

	private void method_12(Class4767 attributes)
	{
		if (Mode != Enum928.const_2)
		{
			method_0();
			string id = (string)attributes[Enum670.const_19];
			Class6877 @class = method_2(id);
			if (@class.Type == Enum669.const_0)
			{
				class6871_0.method_19();
			}
			else
			{
				class6871_0.method_20();
			}
		}
	}

	private void method_13()
	{
		class6871_0.method_3();
	}

	public void imethod_7()
	{
		class6871_0.method_3();
		class6871_0.Indent = true;
		class6871_0.IgnoreWhiteSpace = false;
	}

	public void imethod_8(RectangleF bbox)
	{
	}

	public void imethod_9()
	{
	}

	public void imethod_10(Enum669 type, string listId)
	{
		if (list_0 == null)
		{
			list_0 = new List<Class6877>();
		}
		list_0.Add(new Class6877(type, listId));
	}

	public void imethod_20(int listLevel, Class4767 attributes)
	{
		Class6877 @class = list_0[list_0.Count - 1];
		@class.method_0(new Class6878(listLevel));
	}

	public void imethod_11()
	{
	}

	public void imethod_12(Class4767 attributes)
	{
		class6871_0.method_27();
	}

	public void imethod_13()
	{
		class6871_0.method_3();
	}

	public void imethod_14(float height, Class4767 attributes)
	{
		class6871_0.method_28().method_6().method_7(Enum930.const_15, class6871_0.method_47(height))
			.method_7(Enum930.const_43, "top")
			.method_8();
	}

	public void imethod_15()
	{
		class6871_0.method_4();
	}

	public void imethod_18(float width, Class4767 attributes, bool drawBorders)
	{
		class6871_0.method_29().method_6().method_7(Enum930.const_17, class6871_0.method_47(width))
			.method_8();
	}

	public void imethod_19()
	{
		class6871_0.method_4();
	}

	public void imethod_21(string text, Class4767 attributes)
	{
		Class5999 @class = (Class5999)attributes[Enum670.const_23];
		if (@class == null)
		{
			return;
		}
		method_14(@class);
		Enum674 @enum = Enum674.const_2;
		if (attributes.method_0(Enum670.const_27))
		{
			@enum = Enum674.const_2;
			@enum = Enum674.const_2;
			@enum = (Enum674)attributes[Enum670.const_27];
			switch (@enum)
			{
			case Enum674.const_0:
				class6871_0.method_43();
				break;
			case Enum674.const_1:
				class6871_0.method_44();
				break;
			}
		}
		else
		{
			@enum = Enum674.const_2;
			@enum = Enum674.const_2;
			Enum674 enum2 = Enum674.const_2;
		}
		Color color = Color.Black;
		if (attributes.method_0(Enum670.const_21))
		{
			color = (Color)attributes[Enum670.const_21];
		}
		if (class6858_0.FixedLayout && class6858_0.CompensateRoundingErrors)
		{
			method_16(text, @class, color, attributes);
		}
		else
		{
			method_17(text, @class, color, attributes);
		}
		if (@enum != Enum674.const_2)
		{
			class6871_0.method_3();
		}
	}

	private void method_14(Class5999 font)
	{
		if (Class6010.smethod_0(font.FamilyName))
		{
			return;
		}
		string uri = Path.GetFileName(font.TrueTypeFont.FileName);
		string directoryName = Path.GetDirectoryName(uri);
		Stream stream = font.TrueTypeFont.Data.vmethod_0();
		if (class6858_0.FontFaceTypes != 0)
		{
			method_15(font.FamilyName, uri, stream);
			return;
		}
		if (string.IsNullOrEmpty(directoryName) && class6858_0.UseWoffFonts)
		{
			uri = uri.Replace(".ttf", ".woff");
		}
		if (class6868_0.method_0(font.FamilyName, uri))
		{
			return;
		}
		string arg = $"{smethod_2(stream)}_{stream.Length}";
		if (!interface326_0.imethod_3($"{arg}_{Path.GetExtension(uri)}", ref uri))
		{
			if (string.IsNullOrEmpty(directoryName) && class6858_0.UseWoffFonts)
			{
				stream.Seek(0L, SeekOrigin.Begin);
				MemoryStream memoryStream = new MemoryStream();
				Class6118.smethod_0(stream, memoryStream);
				stream = memoryStream;
				stream.Seek(0L, SeekOrigin.Begin);
			}
			uri = interface326_0.imethod_5(stream, uri);
			interface326_0.imethod_4($"{arg}_{Path.GetExtension(uri)}", uri);
		}
		if (!class6868_0.method_0(font.FamilyName, uri))
		{
			class6868_0.method_1(font.FamilyName, uri);
		}
	}

	internal static string smethod_2(Stream stream)
	{
		stream.Seek(0L, SeekOrigin.Begin);
		Class5983 @class = new Class5983();
		byte[] array = @class.ComputeHash(stream);
		stream.Seek(0L, SeekOrigin.Begin);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	private void method_15(string familyName, string fileName, Stream fontStream)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		if (class6868_0.method_0(familyName, fileName))
		{
			return;
		}
		Stream14 stream = new Stream14();
		try
		{
			Class5964.smethod_9(fontStream, stream);
			string arg = $"{smethod_2(stream)}_{stream.Length}";
			if ((class6858_0.FontFaceTypes & Class6858.Enum927.flag_1) == Class6858.Enum927.flag_1)
			{
				string uri = fileName;
				if (interface326_0.imethod_3(string.Format("{0}_{1}", arg, "ttf"), ref uri))
				{
					text3 = uri;
				}
				else
				{
					stream.Seek(0L, SeekOrigin.Begin);
					text3 = interface326_0.imethod_5(stream, uri);
					interface326_0.imethod_4(string.Format("{0}_{1}", arg, "ttf"), text3);
				}
			}
			if ((class6858_0.FontFaceTypes & Class6858.Enum927.flag_3) == Class6858.Enum927.flag_3)
			{
				string uri2 = fileName.Replace(".ttf", ".woff");
				if (interface326_0.imethod_3(string.Format("{0}_{1}", arg, "woff"), ref uri2))
				{
					text2 = uri2;
				}
				else
				{
					stream.Seek(0L, SeekOrigin.Begin);
					MemoryStream memoryStream = new MemoryStream();
					stream.Seek(0L, SeekOrigin.Begin);
					Class6118.smethod_0(stream, memoryStream);
					memoryStream.Seek(0L, SeekOrigin.Begin);
					text2 = interface326_0.imethod_5(memoryStream, uri2);
					interface326_0.imethod_4(string.Format("{0}_{1}", arg, "woff"), text2);
				}
			}
			if ((class6858_0.FontFaceTypes & Class6858.Enum927.flag_2) == Class6858.Enum927.flag_2)
			{
				string uri3 = fileName.Replace(".ttf", ".eot");
				if (interface326_0.imethod_3(string.Format("{0}_{1}", arg, "eot"), ref uri3))
				{
					text = uri3;
				}
				else
				{
					stream.Seek(0L, SeekOrigin.Begin);
					MemoryStream memoryStream2 = new MemoryStream();
					stream.Seek(0L, SeekOrigin.Begin);
					Class6117.smethod_0(stream, memoryStream2, compress: true, out var _);
					memoryStream2.Seek(0L, SeekOrigin.Begin);
					text = interface326_0.imethod_5(memoryStream2, uri3);
					interface326_0.imethod_4(string.Format("{0}_{1}", arg, "eot"), text);
				}
			}
			class6868_0.method_3(familyName, text, text2, text3);
			class6868_0.method_2(familyName, fileName);
		}
		finally
		{
			stream.method_0();
		}
	}

	private static string[] smethod_3(string text, int lettersIntervalsNumber, float letterSpaceX100, out float[] letterSpaces)
	{
		letterSpaces = new float[2];
		float num = letterSpaceX100 - (float)Math.Floor(letterSpaceX100);
		float num2 = (float)Math.Ceiling(letterSpaceX100) - letterSpaceX100;
		float num3 = (float)Math.Floor(letterSpaceX100) / 100f;
		float num4 = (float)Math.Ceiling(letterSpaceX100) / 100f;
		float num5;
		if (num2 > num)
		{
			num5 = num2;
			letterSpaces[0] = num3;
			letterSpaces[1] = num4;
		}
		else
		{
			num5 = num;
			letterSpaces[0] = num4;
			letterSpaces[1] = num3;
		}
		int num6 = (int)Math.Ceiling((float)lettersIntervalsNumber * num5);
		if (num6 + 1 != text.Length && (num6 + 1 != text.Length - 1 || text[text.Length - 1] != '\r'))
		{
			return new string[2]
			{
				text.Substring(0, num6 + 1),
				text.Substring(num6 + 1)
			};
		}
		return new string[1] { text };
	}

	private static bool smethod_4(string text, float fontSize, Class4767 attributes, out float letterSpace, out int lettersIntervalsNumber, out int wordsIntervalsNumber, out float letterSpaceSumError, out float letterSpaceX100)
	{
		letterSpace = 0f;
		lettersIntervalsNumber = 0;
		wordsIntervalsNumber = 0;
		letterSpaceSumError = 0f;
		letterSpaceX100 = 0f;
		if (attributes.method_0(Enum670.const_29))
		{
			float num = (float)attributes[Enum670.const_29];
			letterSpace = num / fontSize;
			letterSpaceX100 = letterSpace * 100f;
			float num2 = (float)Math.Floor(letterSpaceX100);
			lettersIntervalsNumber = ((text.Length <= 1 || text[text.Length - 1] != '\r') ? (text.Length - 1) : (text.Length - 2));
			letterSpaceSumError = (letterSpaceX100 - num2) * (float)lettersIntervalsNumber / 100f;
			foreach (char c in text)
			{
				if (c == ' ')
				{
					wordsIntervalsNumber++;
				}
			}
			if (wordsIntervalsNumber == 0)
			{
				return false;
			}
			float num3 = 0f;
			if (attributes.method_0(Enum670.const_28))
			{
				float num4 = (float)attributes[Enum670.const_28];
				num3 = num4 / fontSize;
			}
			if (!letterSpaceSumError.Equals(0f))
			{
				float num5 = letterSpaceSumError / (float)wordsIntervalsNumber;
				if (Math.Abs(num5) > 0.1f)
				{
					return false;
				}
				num3 += num5;
				if (Math.Abs(num3) < 0.01f)
				{
					return false;
				}
			}
			letterSpace = num2 / 100f;
		}
		return true;
	}

	private void method_16(string text, Class5999 font, Color color, Class4767 attributes)
	{
		ArrayList arrayList = Class4768.smethod_4(text);
		string value = smethod_5(font);
		foreach (Class4768.Class4769 item in arrayList)
		{
			if (item.Text.Length == 0)
			{
				continue;
			}
			if (item.IsRtl)
			{
				class6871_0.method_45();
				class6871_0.method_5(Enum929.const_42, "ltr");
				class6871_0.method_6().method_7(Enum930.const_22, "inline").method_8();
			}
			string[] array = new string[1] { item.Text };
			float[] letterSpaces;
			if (!smethod_4(item.Text, font.SizePoints, attributes, out var letterSpace, out var lettersIntervalsNumber, out var wordsIntervalsNumber, out var letterSpaceSumError, out var letterSpaceX))
			{
				array = smethod_3(item.Text, lettersIntervalsNumber, letterSpaceX, out letterSpaces);
				letterSpaceSumError = 0f;
			}
			else
			{
				letterSpaces = new float[1] { letterSpace };
			}
			class6871_0.method_25();
			float num = 0f;
			for (int i = 0; i < array.Length; i++)
			{
				string value2 = array[i];
				if (string.IsNullOrEmpty(value2))
				{
					continue;
				}
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringBuilder2 = new StringBuilder();
				bool alreadyExist;
				if (i == 0)
				{
					class6871_0.method_6().method_7(Enum930.const_12, class6871_0.method_47(font.SizePoints)).method_7(Enum930.const_11, value)
						.method_7(Enum930.const_10, Class6872.smethod_0(color));
					class6871_0.CurrentFontSize = font.SizePoints;
					float value3 = font.AscentPoints + font.DescentPoints;
					if (!value3.Equals(0f))
					{
						class6871_0.method_7(Enum930.const_26, class6871_0.method_47(value3));
					}
					stringBuilder.Append(class6871_0.method_9(out alreadyExist)).Append(" ");
					if (font.IsBold)
					{
						stringBuilder2.AppendFormat("font-weight:{0}; ", "bold");
					}
					if (font.IsItalic)
					{
						stringBuilder2.AppendFormat("font-style:{0}; ", "italic");
					}
					if (((uint)font.StyleEx & 4u) != 0)
					{
						stringBuilder2.AppendFormat("text-decoration:{0}; ", "underline");
					}
					if (((uint)font.StyleEx & 8u) != 0)
					{
						stringBuilder2.AppendFormat("text-decoration:{0}; ", "line-through");
					}
					if (attributes.method_0(Enum670.const_31) && (bool)attributes[Enum670.const_31])
					{
						stringBuilder2.Append("visibility:hidden; ");
					}
				}
				else
				{
					class6871_0.method_25();
				}
				if (array.Length > 1 || !letterSpaces[i].Equals(0f))
				{
					class6871_0.method_6().method_7(Enum930.const_50, letterSpaces[i].ToString("0.#########em", Class6872.HtmlCulture));
					stringBuilder.Append(' ');
					string value4 = class6871_0.method_9(out alreadyExist);
					stringBuilder.Append(value4);
				}
				if (stringBuilder.Length > 0)
				{
					class6871_0.method_11(stringBuilder.ToString());
				}
				if (attributes.method_0(Enum670.const_28))
				{
					float num2 = (float)attributes[Enum670.const_28];
					float num3 = num2 / class6871_0.CurrentFontSize;
					if (wordsIntervalsNumber != 0)
					{
						num3 += letterSpaceSumError / (float)wordsIntervalsNumber;
					}
					if (!num.Equals(num3))
					{
						stringBuilder2.AppendFormat("word-spacing:{0}em; ", num3.ToString("0.####", Class6872.HtmlCulture));
					}
					if (i == 0)
					{
						num = num3;
					}
				}
				if (stringBuilder2.Length > 0)
				{
					class6871_0.method_5(Enum929.const_30, stringBuilder2.ToString().TrimEnd());
				}
				if (font.StyleEx != 0 && item.Text == " ")
				{
					class6871_0.method_13();
				}
				else
				{
					class6871_0.Write(value2, replaceReturn: true, !class6858_0.RecognizeUnderlineAndStrikeout || font.StyleEx == 0);
				}
				if (i > 0)
				{
					class6871_0.method_3();
				}
			}
			class6871_0.method_3();
			class6871_0.CurrentFontSize = 12f;
			if (item.IsRtl)
			{
				class6871_0.method_3();
			}
		}
	}

	private void method_17(string text, Class5999 font, Color color, Class4767 attributes)
	{
		IList list = Class4768.smethod_4(text);
		string value = smethod_5(font);
		foreach (Class4768.Class4769 item in list)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			if (item.IsRtl)
			{
				class6871_0.method_45();
				stringBuilder2.Append("display:inline; ");
			}
			else
			{
				class6871_0.method_25();
			}
			class6871_0.method_6().method_7(Enum930.const_12, class6871_0.method_47(font.SizePoints)).method_7(Enum930.const_11, value)
				.method_7(Enum930.const_10, Class6872.smethod_0(color));
			stringBuilder.Append(class6871_0.method_9(out var alreadyExist)).Append(" ");
			try
			{
				class6871_0.CurrentFontSize = font.SizePoints;
				if (font.IsBold)
				{
					stringBuilder2.AppendFormat("font-weight:{0}; ", "bold");
				}
				if (font.IsItalic)
				{
					stringBuilder2.AppendFormat("font-style:{0}; ", "italic");
				}
				if (((uint)font.StyleEx & 4u) != 0)
				{
					stringBuilder2.AppendFormat("text-decoration:{0}; ", "underline");
				}
				if (((uint)font.StyleEx & 8u) != 0)
				{
					stringBuilder2.AppendFormat("text-decoration:{0}; ", "line-through");
				}
				if (attributes.method_0(Enum670.const_31) && (bool)attributes[Enum670.const_31])
				{
					stringBuilder2.Append("visibility:hidden; ");
				}
				if (class6858_0.FixedLayout && attributes.method_0(Enum670.const_28))
				{
					float num = (float)attributes[Enum670.const_28];
					if (num != 0f)
					{
						stringBuilder2.AppendFormat("word-spacing:{0}em; ", (num / class6871_0.CurrentFontSize).ToString("0.####", Class6872.HtmlCulture));
					}
				}
				if (class6858_0.FixedLayout)
				{
					float num2 = font.AscentPoints + font.DescentPoints;
					if (num2 != 0f)
					{
						class6871_0.method_6().method_7(Enum930.const_26, class6871_0.method_47(num2));
						stringBuilder.Append(class6871_0.method_9(out alreadyExist)).Append(" ");
					}
				}
				if (item.IsRtl)
				{
					class6871_0.method_5(Enum929.const_42, "ltr");
				}
				if (class6858_0.FixedLayout && attributes.method_0(Enum670.const_29))
				{
					float num3 = (float)attributes[Enum670.const_29];
					class6871_0.method_6().method_7(Enum930.const_50, (num3 / class6871_0.CurrentFontSize).ToString("0.####em", Class6872.HtmlCulture));
					stringBuilder.Append(' ');
					string text2 = class6871_0.method_9(out alreadyExist);
					stringBuilder.Append(text2);
					if (!alreadyExist)
					{
						StringBuilder stringBuilder3 = new StringBuilder();
						stringBuilder3.AppendFormat("\n.ie .{0} ", text2).Append("{\n").AppendFormat("\tletter-spacing: {0}px;\n", (num3 * 1.3333333f).ToString("0.####", Class6872.HtmlCulture))
							.Append("}\n");
						class6868_0.method_4(stringBuilder3.ToString(), 1);
					}
				}
				class6871_0.method_11(stringBuilder.ToString());
				if (stringBuilder2.Length > 0)
				{
					class6871_0.method_5(Enum929.const_30, stringBuilder2.ToString().TrimEnd());
				}
				if (font.StyleEx != 0 && item.Text == " ")
				{
					class6871_0.method_13().method_3();
				}
				else
				{
					class6871_0.Write(item.Text, replaceReturn: true, !class6858_0.RecognizeUnderlineAndStrikeout || font.StyleEx == 0).method_3();
				}
			}
			finally
			{
				class6871_0.CurrentFontSize = 12f;
			}
		}
	}

	private static string smethod_5(Class5999 font)
	{
		return (font != null && font.TrueTypeFont.Glyphs[' '] == null) ? $"\"{font.FamilyName}\", \"Times New Roman\"" : $"\"{font.FamilyName}\"";
	}

	public void imethod_22(PointF position, SizeF size, byte[] imageData, bool warpTextAround, bool isRelativePosition, bool isBehindText, Class4767 attributes)
	{
		method_18(imageData, position, size, null);
	}

	private void method_18(byte[] imageData, PointF position, SizeF size, int? zIndex)
	{
		if (class6858_0.StreamingOptions.EnableSingleStreamConversion)
		{
			Enum922 type = class6873_0.method_1(imageData, Class6873.Enum932.const_0);
			class6871_0.method_34(imageData, type, size, string.Empty, position, zIndex);
		}
		else
		{
			Enum922 type;
			string suggestedFileName = class6873_0.method_2(imageData, Class6873.Enum932.const_0, out type);
			string path = interface326_0.imethod_1(imageData, type, suggestedFileName);
			class6871_0.method_30(path, size, string.Empty, position, zIndex);
		}
	}

	public void method_19(PointF position, SizeF size, byte[] imageData, int zIndex)
	{
		method_18(imageData, position, size, zIndex);
	}

	public void imethod_23(Class6213 canvas, Hashtable pathToZId)
	{
		if (!class6858_0.FixedLayout || !smethod_6(canvas))
		{
			return;
		}
		class6871_0.method_45().method_6().method_7(Enum930.const_41, "relative")
			.method_8();
		RectangleF rectangleF = new Class6185().method_2(canvas);
		float num = (float)Class5955.smethod_0(rectangleF.Right);
		float num2 = (float)Class5955.smethod_0(rectangleF.Bottom);
		float width = ((num > float_1) ? float_1 : ((num == 0f) ? float_1 : num));
		float height = ((num2 > float_2) ? float_2 : ((num2 == 0f) ? float_2 : num2));
		Class6216 apsPage;
		if (class6858_0.StreamingOptions.SaveNonVectorPartsFromSvgImagesApart)
		{
			apsPage = new Class6216(float_1, float_2);
			class6871_0.CurrentSvgPageSize = new SizeF(float_1, float_2);
		}
		else
		{
			apsPage = new Class6216(width, height);
		}
		if (class6858_0.PageBackgroundImageType == Enum923.const_4)
		{
			Class6002 @class = new Class6002();
			@class.method_6((rectangleF.Right == 0f) ? 1f : (num / rectangleF.Right), (rectangleF.Bottom == 0f) ? 1f : (num2 / rectangleF.Bottom));
			canvas.RenderTransform = @class;
		}
		apsPage.Add(canvas);
		if (class6858_0.PageBackgroundImageType == Enum923.const_4)
		{
			if (class6858_0.StreamingOptions.EnableSingleStreamConversion)
			{
				byte[] data = Class6793.smethod_2(apsPage);
				class6871_0.method_39(data, class6858_0.StreamingOptions.SvgEmbeddingOptions);
			}
			else if (class6858_0.StreamingOptions.SaveNonVectorPartsFromSvgImagesApart)
			{
				Class6864 class2 = new Class6864(interface326_0, this, class6858_0.CompressSvgGraphics);
				Class7189 class3 = new Class7189();
				class3.NormalizeAps = false;
				class3.Callback = class2;
				class3.AddAspectRatio = true;
				Class7190.smethod_2(ref apsPage, class3);
				class6871_0.method_41(class2.SvgPath, class6858_0.StreamingOptions.SvgEmbeddingOptions);
			}
			else
			{
				byte[] array = Class6793.smethod_2(apsPage);
				Enum922 imageType;
				string suggestedFileName = class6873_0.method_2(array, CurrentSvgFormat, out imageType);
				string path = interface326_0.imethod_1(Class6864.smethod_1(array, imageType), imageType, suggestedFileName);
				class6871_0.method_41(path, class6858_0.StreamingOptions.SvgEmbeddingOptions);
			}
		}
		else
		{
			byte[] array2 = Class6793.smethod_0(apsPage, class6858_0.PageBackgroundImageType);
			if (class6858_0.StreamingOptions.EnableSingleStreamConversion)
			{
				Enum922 type = Class6793.smethod_1(class6858_0.PageBackgroundImageType);
				class6871_0.method_32(array2, type, string.Empty, null);
			}
			else
			{
				Enum922 imageType2;
				string suggestedFileName2 = class6873_0.method_2(array2, Class6873.Enum932.const_0, out imageType2);
				string source = interface326_0.imethod_1(array2, imageType2, suggestedFileName2);
				class6871_0.method_33(source, string.Empty, null);
			}
		}
		class6871_0.method_3();
		class6871_0.CurrentSvgPageSize = SizeF.Empty;
	}

	public void imethod_16(Class6270 hyperlink)
	{
		string_5 = null;
		if (hyperlink.HyperlinkType == Enum802.const_0)
		{
			string_5 = hyperlink.Target;
			if (string.IsNullOrEmpty(string_5))
			{
				string_5 = string.Empty;
			}
			else if (string_5.StartsWith("www.", StringComparison.InvariantCultureIgnoreCase))
			{
				string_5 = $"http://{string_5}";
			}
		}
		else if (hyperlink.HyperlinkType == Enum802.const_1 && hyperlink.JumpType == Enum803.const_7)
		{
			string_5 = "#" + hyperlink.Page;
		}
		if (string_5 != null)
		{
			class6871_0.method_26(string_5);
			if (hyperlink.HyperlinkType == Enum802.const_0)
			{
				class6871_0.method_5(Enum929.const_32, "_blank");
			}
		}
	}

	public void imethod_17()
	{
		if (string_5 != null)
		{
			class6871_0.method_3();
			string_5 = null;
		}
	}

	private static bool smethod_6(Class6213 canvas)
	{
		int num = 0;
		while (true)
		{
			if (num < canvas.Count)
			{
				Class6204 @class = canvas[num];
				if (!(@class is Class6213))
				{
					break;
				}
				if (!smethod_6(@class as Class6213))
				{
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	private void method_20()
	{
		if (class6869_0 != null)
		{
			class6869_0.Close();
			((IDisposable)class6869_0).Dispose();
			class6869_0 = null;
		}
	}

	private void method_21()
	{
		if (class6868_0 != null)
		{
			class6868_0.Close();
			((IDisposable)class6868_0).Dispose();
			class6868_0 = null;
		}
	}

	public void Close()
	{
		method_20();
		method_21();
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			Close();
			Class7190.smethod_3();
		}
	}

	void IDisposable.Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void Notify(int pageNumber, Class5961.Enum741 operation)
	{
		if (interface255_0 != null)
		{
			int percent = ((operation == Class5961.Enum741.const_0) ? 50 : 100);
			interface255_0.imethod_0(new Class5961(pageNumber, percent, operation));
		}
	}
}
