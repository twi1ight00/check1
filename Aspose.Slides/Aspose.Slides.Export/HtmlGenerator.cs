using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using ns33;

namespace Aspose.Slides.Export;

[ClassInterface(ClassInterfaceType.None)]
[Guid("8C2F4514-7092-45DE-8213-A9429E9A5723")]
[ComVisible(true)]
public sealed class HtmlGenerator : IHtmlGenerator
{
	private const int int_0 = 512;

	private char[] char_0 = new char[1024];

	private int int_1;

	private readonly TextWriter textWriter_0;

	private readonly SizeF sizeF_0;

	private readonly SvgCoordinateUnit svgCoordinateUnit_0;

	private int int_2 = -1;

	private int int_3 = -1;

	private int int_4 = -1;

	private static readonly Class1151 class1151_0 = new Class1151("in", "cm", "mm", "pt", "pc", "em", "ex", "px", "%");

	internal bool ContainsHtml => int_1 > 0;

	internal TextWriter TextWriter => textWriter_0;

	public SizeF SlideImageSize => sizeF_0;

	public SvgCoordinateUnit SlideImageSizeUnit => svgCoordinateUnit_0;

	public string SlideImageSizeUnitCode => class1151_0[(int)svgCoordinateUnit_0];

	public int PreviousSlideIndex => int_2;

	public int SlideIndex => int_3;

	public int NextSlideIndex => int_4;

	internal HtmlGenerator(TextWriter tw, SizeF slideSize, SvgCoordinateUnit sizeUnit)
	{
		textWriter_0 = tw;
		sizeF_0 = slideSize;
		svgCoordinateUnit_0 = sizeUnit;
	}

	private HtmlGenerator()
	{
	}

	public void AddHtml(string html)
	{
		method_1(html, 0, html.Length);
	}

	public void AddHtml(char[] html)
	{
		method_2(html, 0, html.Length);
	}

	public void AddHtml(char[] html, int startIndex, int length)
	{
		method_2(html, startIndex, length);
	}

	public void AddText(string text)
	{
		int length = text.Length;
		int num = 0;
		int num2 = 0;
		while (num < length)
		{
			char c = text[num];
			if ('&' == c)
			{
				if (num2 < num)
				{
					method_1(text, num2, num - num2);
				}
				method_0("&amp;");
				num2 = ++num;
			}
			else if ('<' == c)
			{
				if (num2 < num)
				{
					method_1(text, num2, num - num2);
				}
				method_0("&lt;");
				num2 = ++num;
			}
			else if ('>' == c)
			{
				if (num2 < num)
				{
					method_1(text, num2, num - num2);
				}
				method_0("&gt;");
				num2 = ++num;
			}
			else if ('\u00a0' < c && 'Ā' >= c)
			{
				if (num2 < num)
				{
					method_1(text, num2, num - num2);
				}
				method_0("&");
				int num3 = c;
				method_0(num3.ToString(NumberFormatInfo.InvariantInfo));
				method_0(";");
				num2 = ++num;
			}
			else
			{
				num++;
			}
		}
	}

	public void AddText(char[] text)
	{
		AddText(text, 0, text.Length);
	}

	public void AddText(char[] text, int startIndex, int length)
	{
		int num = startIndex;
		int num2 = startIndex;
		while (num < length)
		{
			char c = text[num];
			if ('&' == c)
			{
				if (num2 < num)
				{
					method_2(text, num2, num - num2);
				}
				method_0("&amp;");
				num2 = ++num;
			}
			else if ('<' == c)
			{
				if (num2 < num)
				{
					method_2(text, num2, num - num2);
				}
				method_0("&lt;");
				num2 = ++num;
			}
			else if ('>' == c)
			{
				if (num2 < num)
				{
					method_2(text, num2, num - num2);
				}
				method_0("&gt;");
				num2 = ++num;
			}
			else if ('\u00a0' < c && 'Ā' >= c)
			{
				if (num2 < num)
				{
					method_2(text, num2, num - num2);
				}
				method_0("&");
				int num3 = c;
				method_0(num3.ToString(NumberFormatInfo.InvariantInfo));
				method_0(";");
				num2 = ++num;
			}
			else
			{
				num++;
			}
		}
	}

	public void AddAttributeValue(string value)
	{
		method_0("\"");
		int length = value.Length;
		int num = 0;
		int num2 = 0;
		while (num < length)
		{
			char c = value[num];
			if ('"' == c)
			{
				if (num2 < num)
				{
					method_1(value, num2, num - num2);
				}
				method_0("&quot;");
				num2 = ++num;
			}
			else if ('&' == c)
			{
				if (num2 < num)
				{
					method_1(value, num2, num - num2);
				}
				method_0("&amp;");
				num2 = ++num;
			}
			else if ('<' == c)
			{
				if (num2 < num)
				{
					method_1(value, num2, num - num2);
				}
				method_0("&lt;");
				num2 = ++num;
			}
			else if ('>' == c)
			{
				if (num2 < num)
				{
					method_1(value, num2, num - num2);
				}
				method_0("&gt;");
				num2 = ++num;
			}
			else if ('\u00a0' < c && 'Ā' >= c)
			{
				if (num2 < num)
				{
					method_1(value, num2, num - num2);
				}
				method_0("&");
				int num3 = c;
				method_0(num3.ToString(NumberFormatInfo.InvariantInfo));
				method_0(";");
				num2 = ++num;
			}
			else
			{
				num++;
			}
		}
		method_0("\"");
	}

	public void AddAttributeValue(char[] value)
	{
		AddAttributeValue(value, 0, value.Length);
	}

	public void AddAttributeValue(char[] value, int startIndex, int length)
	{
		method_0("\"");
		int num = startIndex;
		int num2 = startIndex;
		while (num < length)
		{
			char c = value[num];
			if ('"' == c)
			{
				if (num2 < num)
				{
					method_2(value, num2, num - num2);
				}
				method_0("&quot;");
				num2 = ++num;
			}
			else if ('&' == c)
			{
				if (num2 < num)
				{
					method_2(value, num2, num - num2);
				}
				method_0("&amp;");
				num2 = ++num;
			}
			else if ('<' == c)
			{
				if (num2 < num)
				{
					method_2(value, num2, num - num2);
				}
				method_0("&lt;");
				num2 = ++num;
			}
			else if ('>' == c)
			{
				if (num2 < num)
				{
					method_2(value, num2, num - num2);
				}
				method_0("&gt;");
				num2 = ++num;
			}
			else if ('\u00a0' < c && 'Ā' >= c)
			{
				if (num2 < num)
				{
					method_2(value, num2, num - num2);
				}
				method_0("&");
				int num3 = c;
				method_0(num3.ToString(NumberFormatInfo.InvariantInfo));
				method_0(";");
				num2 = ++num;
			}
			else
			{
				num++;
			}
		}
		method_0("\"");
	}

	private void method_0(string text)
	{
		method_1(text, 0, text.Length);
	}

	private void method_1(string text, int startIndex, int length)
	{
		method_3(int_1 + length);
		text.CopyTo(startIndex, char_0, int_1, length);
		int_1 += text.Length;
	}

	private void method_2(char[] text, int startIndex, int length)
	{
		method_3(int_1 + length);
		Array.Copy(text, startIndex, char_0, int_1, length);
		int_1 += text.Length;
	}

	internal void Flush()
	{
		textWriter_0.Write(char_0, 0, int_1);
		textWriter_0.Flush();
		Clear();
	}

	private void method_3(int capacity)
	{
		if (capacity > char_0.Length)
		{
			int num = capacity % 512;
			if (num > 0)
			{
				capacity += 512 - num;
			}
			char[] destinationArray = new char[capacity];
			Array.Copy(char_0, destinationArray, int_1);
			char_0 = destinationArray;
		}
	}

	private void Clear()
	{
		int_1 = 0;
	}

	internal void method_4(int prevSlideIndex, int currentSlideIndex, int nextSlideIndex)
	{
		int_2 = prevSlideIndex;
		int_3 = currentSlideIndex;
		int_4 = nextSlideIndex;
	}
}
