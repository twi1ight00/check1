using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using ns22;

namespace ns18;

internal class Class469 : Class468
{
	private long long_0;

	private Class771 class771_0;

	private XmlTextWriter xmlTextWriter_0;

	private bool bool_1 = true;

	private Hashtable hashtable_0 = new Hashtable();

	public void method_2(Class452 class452_0, Stream stream_0, string string_0)
	{
		method_3(class452_0, stream_0, string_0);
	}

	private void method_3(Class452 class452_0, Stream stream_0, string string_0)
	{
		class771_0 = new Class771(string_0);
		xmlTextWriter_0 = new XmlTextWriter(stream_0, Encoding.UTF8);
		class452_0.vmethod_0(this);
		xmlTextWriter_0.Flush();
	}

	public override void vmethod_1(Class457 class457_0)
	{
		xmlTextWriter_0.Formatting = Formatting.Indented;
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("svg");
		xmlTextWriter_0.WriteAttributeString("xmlns", "http://www.w3.org/2000/svg");
		xmlTextWriter_0.WriteAttributeString("xmlns:xlink", "http://www.w3.org/1999/xlink");
		xmlTextWriter_0.WriteAttributeString("width", "" + class457_0.Width + "pt");
		xmlTextWriter_0.WriteAttributeString("height", "" + class457_0.Height + "pt");
		xmlTextWriter_0.WriteStartElement("g");
		xmlTextWriter_0.WriteAttributeString("id", "SFixTitle");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("g");
		xmlTextWriter_0.WriteAttributeString("id", "SContent");
		xmlTextWriter_0.WriteStartElement("g");
		xmlTextWriter_0.WriteAttributeString("transform", "scale(1.33333)");
	}

	public override void vmethod_2(Class457 class457_0)
	{
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		method_4();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
	}

	private void method_4()
	{
		xmlTextWriter_0.WriteStartElement("defs");
		foreach (long key in hashtable_0.Keys)
		{
			object obj = hashtable_0[key];
			if (obj is Class772)
			{
				xmlTextWriter_0.WriteStartElement("pattern");
				method_12("id", "PATTERN" + key);
				method_12("patternUnits", "userSpaceOnUse");
				Class772 @class = (Class772)obj;
				Class465 class465_ = @class.class465_0;
				float num2 = class465_.method_4().Width;
				float num3 = class465_.method_4().Height;
				if (@class.matrix_0 != null)
				{
					num2 *= @class.matrix_0.Elements[0];
					num3 *= @class.matrix_0.Elements[3];
				}
				method_10("width", num2);
				method_10("height", num3);
				class465_.Size = new SizeF(num2, num3);
				method_6(class465_);
				xmlTextWriter_0.WriteEndElement();
			}
			else
			{
				Class1199 class2 = (Class1199)obj;
				xmlTextWriter_0.WriteStartElement("linearGradient");
				method_12("id", "PATTERN" + key);
				method_10("x1", class2.method_3().X);
				method_10("x2", class2.method_2().X);
				method_10("y1", class2.method_3().Y);
				method_10("y2", class2.method_2().Y);
				method_12("gradientUnits", "userSpaceOnUse");
				xmlTextWriter_0.WriteStartElement("stop");
				method_12("offset", "0");
				method_12("style", "stop-color:" + smethod_1(class2.method_1()) + ";");
				xmlTextWriter_0.WriteEndElement();
				xmlTextWriter_0.WriteStartElement("stop");
				method_12("offset", "1");
				method_12("style", "stop-color:" + smethod_1(class2.method_0()) + ";");
				xmlTextWriter_0.WriteEndElement();
				xmlTextWriter_0.WriteEndElement();
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_5(Class458 class458_0)
	{
		xmlTextWriter_0.WriteStartElement("defs");
		xmlTextWriter_0.WriteStartElement("clipPath");
		string text = "CLIP" + method_13();
		method_12("id", text);
		xmlTextWriter_0.WriteStartElement("path");
		Class470 @class = new Class470();
		string string_ = @class.method_2(class458_0, bool_3: true);
		method_12("d", string_);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		return text;
	}

	public override void vmethod_3(Class454 class454_0)
	{
		bool flag = Class1405.smethod_3(class454_0);
		string text = "";
		if (flag)
		{
			text = method_5(class454_0.imethod_1());
		}
		xmlTextWriter_0.WriteStartElement("g");
		if (class454_0.imethod_0() != null || flag)
		{
			if (class454_0.imethod_0() != null)
			{
				float[] elements = class454_0.imethod_0().Elements;
				method_12("transform", $"matrix({smethod_0(elements[0])},{smethod_0(elements[1])},{smethod_0(elements[2])},{smethod_0(elements[3])},{smethod_0(elements[4])},{smethod_0(elements[5])})");
			}
			if (flag)
			{
				method_12("clip-path", "url(#" + text + ")");
			}
		}
		if (class454_0 is Class455)
		{
			Class455 @class = (Class455)class454_0;
			method_12("id", "C_" + @class.int_0 + "_" + @class.int_1 + "_" + @class.int_2 + "_" + @class.int_3 + "_" + @class.int_4);
			Class458 class458_ = Class458.smethod_2(@class.rectangleF_0);
			xmlTextWriter_0.WriteStartElement("path");
			Class470 class2 = new Class470();
			string string_ = class2.method_2(class458_, bool_3: true);
			method_12("d", string_);
			method_12("stroke", "none");
			method_12("fill", "white");
			method_12("fill-opacity", "1");
			xmlTextWriter_0.WriteEndElement();
			class458_ = null;
		}
	}

	public override void vmethod_4(Class454 class454_0)
	{
		xmlTextWriter_0.WriteEndElement();
	}

	public override void vmethod_5(Class463 class463_0)
	{
		xmlTextWriter_0.WriteStartElement("text");
		method_10("x", class463_0.method_4().X);
		method_10("y", class463_0.method_4().Y);
		Class1396 @class = class463_0.method_1();
		method_12("font-family", @class.Name);
		method_10("font-size", @class.Size);
		method_11("fill", class463_0.Color);
		if (@class.IsBold)
		{
			method_12("font-weight", "bold");
		}
		if (@class.IsItalic)
		{
			method_12("font-style", "italic");
		}
		if (class463_0.imethod_0() != null)
		{
			float[] elements = class463_0.imethod_0().Elements;
			method_12("transform", $"matrix({smethod_0(elements[0])},{smethod_0(elements[1])},{smethod_0(elements[2])},{smethod_0(elements[3])},{smethod_0(elements[4])},{smethod_0(elements[5])})");
		}
		xmlTextWriter_0.WriteString(class463_0.Text);
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_6(Class465 class465_0)
	{
		string text = "Image" + method_13();
		switch (class465_0.ImageType)
		{
		case Enum200.const_1:
		case Enum200.const_2:
		{
			Class454 @class = Class1422.smethod_0(class465_0);
			@class.method_2(class465_0.Hyperlink);
			@class.vmethod_0(this);
			break;
		}
		case Enum200.const_4:
		case Enum200.const_5:
		case Enum200.const_6:
		case Enum200.const_7:
			xmlTextWriter_0.WriteStartElement("image");
			method_12("Id", text);
			method_10("x", class465_0.method_2().X);
			method_10("y", class465_0.method_2().Y);
			method_10("width", class465_0.Size.Width);
			method_10("height", class465_0.Size.Height);
			if (!bool_1)
			{
				string text2 = class771_0.method_0(class465_0.ImageType);
				using (Stream stream = File.Create(text2))
				{
					stream.Write(class465_0.method_3(), 0, class465_0.method_3().Length);
				}
				method_12("xlink:href", class771_0.method_1(text2));
			}
			else
			{
				string text3 = "";
				switch (class465_0.ImageType)
				{
				case Enum200.const_4:
					text3 = "data:image/jpeg;base64,";
					break;
				case Enum200.const_5:
					text3 = "data:image/png;base64,";
					break;
				case Enum200.const_6:
					text3 = "data:image/bmp;base64,";
					break;
				case Enum200.const_7:
					text3 = "data:image/gif;base64,";
					break;
				}
				method_12("xlink:href", text3 + Convert.ToBase64String(class465_0.method_3()));
			}
			xmlTextWriter_0.WriteEndElement();
			break;
		}
		return text;
	}

	public override void vmethod_13(Class465 class465_0)
	{
		method_6(class465_0);
	}

	public override void vmethod_6(Class458 class458_0)
	{
		xmlTextWriter_0.WriteStartElement("path");
		Class470 @class = new Class470();
		string string_ = @class.method_2(class458_0, bool_3: false);
		method_12("d", string_);
		if (class458_0.class770_0 != null)
		{
			method_11("stroke", class458_0.class770_0.color_0);
			method_10("stroke-width", class458_0.class770_0.float_0);
			if (class458_0.class770_0.dashStyle_0 != 0)
			{
				method_12("stroke-linecap", Class1059.smethod_7(class458_0.class770_0.dashCap_0).ToLower());
				method_12("stroke-dasharray", Class1059.smethod_8(class458_0.class770_0.method_0()));
			}
		}
		else
		{
			method_12("stroke", "none");
			method_10("stroke-width", 0f);
		}
		if (class458_0.method_2() != null)
		{
			if (class458_0.method_2() is SolidBrush)
			{
				SolidBrush solidBrush = (SolidBrush)class458_0.method_2();
				method_11("fill", solidBrush.Color);
			}
			else if (class458_0.method_2() is TextureBrush)
			{
				TextureBrush textureBrush_ = class458_0.method_2() as TextureBrush;
				method_8(textureBrush_);
			}
			else if (class458_0.method_2() is HatchBrush)
			{
				method_7((HatchBrush)class458_0.method_2());
			}
			else if (class458_0.method_2() is Class1199)
			{
				Class1199 value = (Class1199)class458_0.method_2();
				long num = method_13();
				hashtable_0[num] = value;
				method_12("fill", "url(#PATTERN" + num + ")");
			}
		}
		else
		{
			method_12("fill", "none");
		}
		if (class458_0.imethod_0() != null)
		{
			method_12("transform", "matrix(" + Class1059.smethod_3(class458_0.imethod_0()) + ")");
		}
	}

	public override void vmethod_15(Class460 class460_0)
	{
		if (class460_0 != null && class460_0.class770_0 != null)
		{
			xmlTextWriter_0.WriteStartElement("path");
			string string_ = "M " + Class1059.smethod_4(class460_0.pointF_0) + " L " + Class1059.smethod_4(class460_0.pointF_1);
			method_12("d", string_);
			method_11("stroke", class460_0.class770_0.color_0);
			method_10("stroke-width", class460_0.class770_0.float_0);
			if (class460_0.class770_0.dashStyle_0 != 0)
			{
				method_12("stroke-linecap", Class1059.smethod_7(class460_0.class770_0.dashCap_0).ToLower());
				method_12("stroke-dasharray", Class1059.smethod_8(class460_0.class770_0.method_0()));
			}
			method_12("fill", "none");
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_7(Brush brush_0)
	{
		byte[] byte_ = Class1019.smethod_0((HatchBrush)brush_0);
		Class1403 @class = Class1404.smethod_4(byte_);
		RectangleF rectangleF_ = new RectangleF(0f, 0f, @class.Width, @class.Height);
		method_9(byte_, rectangleF_, WrapMode.Tile, null);
	}

	private void method_8(TextureBrush textureBrush_0)
	{
		using Class1021 class1021_ = new Class1021(textureBrush_0);
		byte[] byte_ = Class1064.smethod_1(class1021_);
		try
		{
			Class1403 @class = Class1404.smethod_4(byte_);
			RectangleF rectangleF_ = new RectangleF(0f, 0f, @class.Width, @class.Height);
			method_9(byte_, rectangleF_, textureBrush_0.WrapMode, textureBrush_0.Transform.Clone());
		}
		catch
		{
		}
	}

	internal string method_9(byte[] byte_0, RectangleF rectangleF_0, WrapMode wrapMode_0, Matrix matrix_0)
	{
		Class465 class465_ = new Class465(rectangleF_0.Location, rectangleF_0.Size, byte_0);
		Class772 @class = new Class772();
		@class.class465_0 = class465_;
		@class.matrix_0 = matrix_0;
		long num = method_13();
		hashtable_0[num] = @class;
		method_12("fill", "url(#PATTERN" + num + ")");
		return "";
	}

	public override void vmethod_7(Class458 class458_0)
	{
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_10(string string_0, float float_0)
	{
		xmlTextWriter_0.WriteAttributeString(string_0, smethod_0(float_0));
	}

	private void method_11(string string_0, Color color_0)
	{
		xmlTextWriter_0.WriteAttributeString(string_0, smethod_1(color_0));
	}

	private void method_12(string string_0, string string_1)
	{
		xmlTextWriter_0.WriteAttributeString(string_0, string_1);
	}

	private static string smethod_0(float float_0)
	{
		return Class1025.smethod_10(float_0);
	}

	private static string smethod_1(Color color_0)
	{
		return $"#{Class1025.smethod_5(color_0.R)}{Class1025.smethod_5(color_0.G)}{Class1025.smethod_5(color_0.B)}";
	}

	[SpecialName]
	private long method_13()
	{
		return long_0++;
	}
}
