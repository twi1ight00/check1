using System;
using System.Drawing;
using System.IO;
using ns161;
using ns218;
using ns224;
using ns235;
using ns271;
using ns292;
using ns298;
using ns299;
using ns301;
using ns99;

namespace ns291;

internal class Class6788 : IDisposable, Interface148
{
	internal const string string_0 = "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd";

	internal const string string_1 = "-//W3C//DTD XHTML 1.0 Transitional//EN";

	internal const string string_2 = "http://www.w3.org/1999/xhtml";

	private int int_0;

	private Class6869 class6869_0;

	private readonly Class6873 class6873_0;

	private readonly Class6871 class6871_0;

	private readonly string string_3;

	private readonly Interface326 interface326_0;

	private readonly string string_4;

	private Class6868 class6868_0;

	private readonly MemoryStream memoryStream_0;

	private readonly MemoryStream memoryStream_1;

	private readonly Class6794 class6794_0;

	private readonly string string_5;

	private Interface255 interface255_0;

	private bool bool_0;

	internal Class6788(string filename, string title)
		: this(filename, title, new Class6791(filename), new Class6859(), null)
	{
	}

	internal Class6788(string filename, string title, Class6858 options)
		: this(filename, title, new Class6791(filename), options, null)
	{
	}

	internal Class6788(string filename, string pageTitle, Interface326 callback, Interface255 progressCallback)
		: this(filename, pageTitle, callback, new Class6859(), progressCallback)
	{
	}

	internal Class6788(string filename, string pageTitle, Interface326 callback, Class6858 options, Interface255 progressCallback)
	{
		Class6892.smethod_0(callback, "callback");
		string_4 = Path.GetFileName(filename);
		string_3 = pageTitle;
		class6873_0 = new Class6873(Class6872.smethod_3(filename));
		interface326_0 = callback;
		interface255_0 = progressCallback;
		class6794_0 = interface326_0.imethod_0();
		string_5 = interface326_0.imethod_9();
		memoryStream_0 = new MemoryStream();
		class6868_0 = new Class6868(memoryStream_0, options.CSSWriterOptions);
		memoryStream_1 = new MemoryStream();
		class6869_0 = new Class6870(memoryStream_1, class6868_0, class6794_0, string_5 ?? class6794_0.method_4("style.css"));
		class6871_0 = new Class6871(class6869_0);
		bool_0 = true;
	}

	internal Class6788(string filename)
		: this(filename, string.Empty)
	{
	}

	public void imethod_0(float width, float height)
	{
		int_0++;
		Notify(int_0, Class5961.Enum741.const_0);
		if (bool_0)
		{
			class6871_0.method_46("html", "-//W3C//DTD XHTML 1.0 Transitional//EN", "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd", null);
			class6871_0.method_14("http://www.w3.org/1999/xhtml", addIeStylesSepartion: false).method_15();
			class6871_0.method_1(Enum931.const_24).method_5(Enum929.const_39, "content-type").method_5(Enum929.const_40, $"text/html;charset={class6871_0.Encoding.WebName}")
				.method_3();
			class6871_0.method_16(string_3).method_3().method_17();
			bool_0 = false;
		}
		class6871_0.method_45().method_6().method_7(Enum930.const_41, "relative")
			.method_7(Enum930.const_32, Class6872.smethod_1(width))
			.method_7(Enum930.const_17, "100%")
			.method_8();
	}

	public void imethod_1()
	{
		class6871_0.method_3();
		Notify(int_0, Class5961.Enum741.const_1);
	}

	public void imethod_2(float marginTop, float maxWidth, float lineHeight)
	{
		class6871_0.method_18().method_6().method_7(Enum930.const_31, Class6872.smethod_1(marginTop))
			.method_7(Enum930.const_28, "0")
			.method_7(Enum930.const_42, "justify")
			.method_7(Enum930.const_32, Class6872.smethod_1(maxWidth));
		if (lineHeight > 0f)
		{
			class6871_0.method_7(Enum930.const_26, Class6872.smethod_1(lineHeight));
		}
		class6871_0.method_8();
	}

	public void imethod_3()
	{
		class6871_0.method_3();
	}

	public void imethod_4()
	{
	}

	public void imethod_5(float rightSpace)
	{
	}

	private void method_0(Class6730 font)
	{
		if (Class6010.smethod_0(font.FamilyName))
		{
			return;
		}
		string uri = Path.GetFileName(font.FileName);
		if (!class6868_0.method_0(font.FamilyName, uri))
		{
			Stream stream = font.Data.vmethod_0();
			string arg = $"{Class6861.smethod_2(stream)}_{stream.Length}";
			if (!interface326_0.imethod_3($"{arg}_{Path.GetExtension(uri)}", ref uri))
			{
				uri = interface326_0.imethod_5(font.Data.vmethod_0(), uri);
				interface326_0.imethod_4($"{arg}_{Path.GetExtension(uri)}", uri);
			}
			class6868_0.method_1(font.FamilyName, uri);
		}
	}

	public void imethod_6(Class6730 font, string fontName, float fontSize, FontStyle style, Class5998 color, float leftMargin, string text)
	{
		method_0(font);
		class6871_0.method_25();
		class6871_0.method_6().method_7(Enum930.const_12, Class6872.smethod_1(fontSize)).method_7(Enum930.const_11, "\"" + font.FamilyName + "\"")
			.method_7(Enum930.const_10, Class6872.smethod_0(color.method_0()))
			.method_7(Enum930.const_29, Class6872.smethod_1(leftMargin));
		if ((style & FontStyle.Bold) == FontStyle.Bold)
		{
			class6871_0.method_7(Enum930.const_14, "bold");
		}
		if ((style & FontStyle.Italic) == FontStyle.Italic)
		{
			class6871_0.method_7(Enum930.const_13, "italic");
		}
		class6871_0.method_8().Write(text).method_3();
	}

	public void imethod_7(Class6730 font, string fontName, float fontSize, FontStyle style, Class5998 color, string text, string href)
	{
		class6871_0.method_26(href);
		imethod_6(font, fontName, fontSize, style, color, 0f, text);
		class6871_0.method_3();
	}

	public void imethod_8(float indentLeft, float indentTop, Class6220 image, string name)
	{
		Enum922 imageType;
		string suggestedFileName = class6873_0.method_2(image.ImageBytes, Class6873.Enum932.const_0, out imageType);
		string path = interface326_0.imethod_1(image.ImageBytes, imageType, suggestedFileName);
		class6871_0.method_31(path, image.Size, indentLeft, indentTop).method_3();
	}

	private void method_1()
	{
		if (class6869_0 != null)
		{
			class6871_0.method_3().method_3();
			class6869_0.Flush();
			memoryStream_1.Seek(0L, SeekOrigin.Begin);
			interface326_0.imethod_8(memoryStream_1, string_4);
			class6869_0.Close();
			((IDisposable)class6869_0).Dispose();
			class6869_0 = null;
		}
	}

	private void method_2()
	{
		if (class6868_0 != null)
		{
			class6868_0.Flush();
			memoryStream_0.Seek(0L, SeekOrigin.Begin);
			if (class6868_0.StyleRestrictionPositions.Count <= 1 && (class6868_0.StyleRestrictionPositions.Count != 1 || class6868_0.StyleRestrictionPositions[0] >= memoryStream_0.Length))
			{
				interface326_0.imethod_6(memoryStream_0, string_5 ?? "style.css");
			}
			else
			{
				Class6861.smethod_0(string_5 ?? "style.css", int_0, class6868_0, memoryStream_0, interface326_0);
			}
			class6868_0.Close();
			((IDisposable)class6868_0).Dispose();
			class6868_0 = null;
		}
	}

	public void Close()
	{
		method_1();
		method_2();
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			Close();
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
