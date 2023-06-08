using System;
using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class405 : Class316
{
	internal Class405()
	{
		int_0 = 479;
	}

	internal void method_6(PageSetup pageSetup_0)
	{
		string text = pageSetup_0.GetFirstPageHeader(0) + pageSetup_0.GetFirstPageHeader(1) + pageSetup_0.GetFirstPageHeader(2);
		string text2 = pageSetup_0.GetFirstPageFooter(0) + pageSetup_0.GetFirstPageFooter(1) + pageSetup_0.GetFirstPageFooter(2);
		string text3 = pageSetup_0.GetEvenHeader(0) + pageSetup_0.GetEvenHeader(1) + pageSetup_0.GetEvenHeader(2);
		string text4 = pageSetup_0.GetEvenFooter(0) + pageSetup_0.GetEvenFooter(1) + pageSetup_0.GetEvenFooter(2);
		string text5 = pageSetup_0.GetHeader(0) + pageSetup_0.GetHeader(1) + pageSetup_0.GetHeader(2);
		string text6 = pageSetup_0.GetFooter(0) + pageSetup_0.GetFooter(1) + pageSetup_0.GetFooter(2);
		int num = 26 + 2 * text.Length + 2 * text2.Length + 2 * text3.Length + 2 * text4.Length + 2 * text5.Length + 2 * text6.Length;
		byte_0 = new byte[num];
		byte b = 0;
		if (text.Length > 0 || text2.Length > 0 || text3.Length > 0 || text4.Length > 0 || text5.Length > 0 || text6.Length > 0)
		{
			if (pageSetup_0.IsHFDiffOddEven)
			{
				b = (byte)(b | 1u);
			}
			if (pageSetup_0.IsHFDiffFirst)
			{
				b = (byte)(b | 2u);
			}
			if (pageSetup_0.IsHFScaleWithDoc)
			{
				b = (byte)(b | 4u);
			}
			if (pageSetup_0.IsHFAlignMargins)
			{
				b = (byte)(b | 8u);
			}
			byte_0[0] = b;
			int num2 = 2;
			byte[] sourceArray = new byte[4] { 255, 255, 255, 255 };
			if (text5.Length > 0)
			{
				Class1217.smethod_7(byte_0, ref num2, text5);
			}
			else
			{
				Array.Copy(sourceArray, 0, byte_0, num2, 4);
				num2 += 4;
			}
			if (text6.Length > 0)
			{
				Class1217.smethod_7(byte_0, ref num2, text6);
			}
			else
			{
				Array.Copy(sourceArray, 0, byte_0, num2, 4);
				num2 += 4;
			}
			if (text3.Length > 0)
			{
				Class1217.smethod_7(byte_0, ref num2, text3);
			}
			else
			{
				Array.Copy(sourceArray, 0, byte_0, num2, 4);
				num2 += 4;
			}
			if (text4.Length > 0)
			{
				Class1217.smethod_7(byte_0, ref num2, text4);
			}
			else
			{
				Array.Copy(sourceArray, 0, byte_0, num2, 4);
				num2 += 4;
			}
			if (text.Length > 0)
			{
				Class1217.smethod_7(byte_0, ref num2, text);
			}
			else
			{
				Array.Copy(sourceArray, 0, byte_0, num2, 4);
				num2 += 4;
			}
			if (text2.Length > 0)
			{
				Class1217.smethod_7(byte_0, ref num2, text2);
				return;
			}
			Array.Copy(sourceArray, 0, byte_0, num2, 4);
			num2 += 4;
		}
	}
}
