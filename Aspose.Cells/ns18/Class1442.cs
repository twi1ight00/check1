using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells.Rendering;
using ns22;
using ns40;

namespace ns18;

internal class Class1442
{
	private Class1447 class1447_0;

	private bool bool_0;

	private Class958 class958_0;

	private Class951 class951_0;

	private Class960 class960_0;

	private Class1448 class1448_0;

	private Class1440 class1440_0;

	private Class1438 class1438_0;

	private Class949 class949_0;

	private Class946 class946_0;

	private byte[] byte_0;

	private byte[] byte_1;

	private Class945 class945_0;

	internal Class1449 Outline => class951_0.Outline;

	internal Class961 Pages => class951_0.Pages;

	public Class1442(Stream stream_0, Class1448 class1448_1)
	{
		method_4(stream_0, class1448_1, bool_1: false);
	}

	public void method_0()
	{
		class1438_0.method_2(class1447_0);
		class958_0.vmethod_1(class1447_0);
		class951_0.vmethod_1(class1447_0);
		if (method_16() != null)
		{
			method_16().vmethod_1(class1447_0);
		}
		int int_ = class1447_0.method_26();
		method_6(int_);
		class1447_0.Write("%%EOF");
		if (bool_0)
		{
			class1447_0.Close();
		}
	}

	public void method_1(float float_0, float float_1)
	{
		if (class960_0 != null)
		{
			throw new InvalidOperationException("Cannot start a new page while another page is not finished.");
		}
		class960_0 = new Class960(class1440_0, float_0, float_1);
		class951_0.Pages.method_4(class960_0.method_1());
	}

	public void method_2(SizeF sizeF_0)
	{
		method_1(sizeF_0.Width, sizeF_0.Height);
	}

	public void method_3()
	{
		if (class960_0 == null)
		{
			throw new InvalidOperationException("No page to end.");
		}
		class960_0.method_4();
		class960_0.vmethod_1(class1447_0);
		class960_0 = null;
	}

	private void method_4(Stream stream_0, Class1448 class1448_1, bool bool_1)
	{
		bool_0 = bool_1;
		class1448_0 = class1448_1;
		class1440_0 = new Class1440(this);
		class1447_0 = new Class1447(stream_0);
		class1438_0 = new Class1438();
		class958_0 = new Class958(class1440_0);
		class951_0 = new Class951(class1440_0);
		class1447_0.method_6("%PDF-1.4");
		if (class1448_0.Compliance == PdfCompliance.PdfA1b)
		{
			class1447_0.Write("%");
			class1447_0.Write(200);
			class1447_0.Write(201);
			class1447_0.Write(202);
			class1447_0.Write(203);
			class1447_0.Write(13);
			class1447_0.Write(10);
		}
		class958_0.Author = class1448_1.method_12();
		class958_0.Title = class1448_1.method_10();
		class958_0.Subject = class1448_1.method_8();
		class958_0.method_7(Class1184.smethod_1());
		class958_0.method_5(DateTime.UtcNow);
		class958_0.Keywords = class1448_1.method_14();
		if (class1440_0.method_1().Compliance == PdfCompliance.PdfA1b)
		{
			class949_0 = new Class949(class1440_0, class958_0.method_4(), class958_0.method_6(), class958_0.Author);
			class946_0 = new Class946(class1440_0);
		}
		byte_0 = Guid.NewGuid().ToByteArray();
		byte_1 = Guid.NewGuid().ToByteArray();
	}

	private string method_5(byte[] byte_2)
	{
		StringBuilder stringBuilder = new StringBuilder(byte_2.Length);
		foreach (byte b in byte_2)
		{
			stringBuilder.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
		}
		return stringBuilder.ToString().ToUpper();
	}

	private void method_6(int int_0)
	{
		class1447_0.method_6("trailer");
		class1447_0.method_9();
		class1447_0.method_16("/Size", class1447_0.method_23());
		class1447_0.method_11("/Info", class958_0.method_1());
		class1447_0.method_11("/Root", class951_0.method_1());
		string text = method_5(method_14());
		string text2 = method_5(method_15());
		class1447_0.method_6(" /ID [<" + text + "><" + text2 + ">]");
		if (class1440_0.method_1().SecurityOptions != null)
		{
			class1447_0.method_11("/Encrypt", class1440_0.method_7().method_1());
		}
		class1447_0.method_10();
		class1447_0.method_5();
		class1447_0.method_6("startxref");
		class1447_0.method_6(int_0.ToString());
	}

	[SpecialName]
	public Class1448 method_7()
	{
		return class1448_0;
	}

	[SpecialName]
	public Class960 method_8()
	{
		return class960_0;
	}

	[SpecialName]
	internal Class1451 method_9()
	{
		return Pages.method_5();
	}

	[SpecialName]
	internal Class1438 method_10()
	{
		return class1438_0;
	}

	[SpecialName]
	internal Class949 method_11()
	{
		return class949_0;
	}

	[SpecialName]
	internal Class946 method_12()
	{
		return class946_0;
	}

	[SpecialName]
	internal Class1440 method_13()
	{
		return class1440_0;
	}

	[SpecialName]
	internal byte[] method_14()
	{
		return byte_0;
	}

	[SpecialName]
	internal byte[] method_15()
	{
		return byte_1;
	}

	[SpecialName]
	internal Class945 method_16()
	{
		return class945_0;
	}

	[SpecialName]
	internal void method_17(Class945 class945_1)
	{
		class945_0 = class945_1;
	}
}
