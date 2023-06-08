using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using xfbd1009a0cbb9842;

namespace x13cd31bb39e0b7ea;

internal class xd8102f3a59d221a1
{
	private readonly IWarningCallback xa056586c1f99e199;

	private readonly Stack x871326a4605c4e8e = new Stack();

	internal xd8102f3a59d221a1(IWarningCallback warningCallback)
	{
		xa056586c1f99e199 = warningCallback;
	}

	internal void x648a8aa88d1bbe19()
	{
		while (x871326a4605c4e8e.Count > 0)
		{
			x928b31adb20d5cc6 x928b31adb20d5cc = x9a4ff7ab1189f15f();
			FieldStart x12cb12b5d2cad53d = x928b31adb20d5cc.x12cb12b5d2cad53d;
			FieldSeparator x43604484a3deae4f = x928b31adb20d5cc.x43604484a3deae4f;
			FieldEnd x9fd888e65466818c = x928b31adb20d5cc.x9fd888e65466818c;
			if (x12cb12b5d2cad53d != null && x9fd888e65466818c == null)
			{
				if (x12cb12b5d2cad53d.FieldType != 0)
				{
					bool flag = x43604484a3deae4f != null;
					CompositeNode compositeNode = (flag ? x43604484a3deae4f.ParentNode : x12cb12b5d2cad53d.xdfa6ecc6f742f086);
					x9fd888e65466818c = new FieldEnd(x12cb12b5d2cad53d.Document, (xeedad81aaed42a76)x12cb12b5d2cad53d.xeedad81aaed42a76.x8b61531c8ea35b85(), x12cb12b5d2cad53d.FieldType, flag);
					compositeNode.AppendChild(x9fd888e65466818c);
				}
				else
				{
					xbbf9a1ead81dd3a1(WarningType.DataLossCategory, WarningSource.Validator, "Fields with FieldType.FieldNone are not supported by Aspose.Words.");
					x928b31adb20d5cc.x45aed43ab4f2045c();
				}
			}
			else if (x12cb12b5d2cad53d == null && x9fd888e65466818c == null)
			{
				xbbf9a1ead81dd3a1(WarningType.DataLossCategory, WarningSource.Validator, "FieldSeparator without corresponding FieldStart and FieldEnd was removed.");
				x928b31adb20d5cc.x45aed43ab4f2045c();
			}
		}
	}

	internal void xd4c0f67c01114dfe(FieldStart xa6315bf377f6364c)
	{
		x871326a4605c4e8e.Push(xa6315bf377f6364c);
	}

	internal void xd646d4760b5a81b9(FieldSeparator xed9a565596a6ae3f)
	{
		x871326a4605c4e8e.Push(xed9a565596a6ae3f);
	}

	internal void x55225d9815813a91(FieldEnd xc87e4e475724f9c3)
	{
		x871326a4605c4e8e.Push(xc87e4e475724f9c3);
		x928b31adb20d5cc6 x928b31adb20d5cc = x9a4ff7ab1189f15f();
		if (x928b31adb20d5cc.x12cb12b5d2cad53d == null)
		{
			xbbf9a1ead81dd3a1(WarningType.DataLossCategory, WarningSource.Validator, "FieldSeparator without corresponding FieldStart was removed.");
			x928b31adb20d5cc.x45aed43ab4f2045c();
		}
	}

	private x928b31adb20d5cc6 x9a4ff7ab1189f15f()
	{
		x928b31adb20d5cc6 result = default(x928b31adb20d5cc6);
		if (x871326a4605c4e8e.Count > 0 && x871326a4605c4e8e.Peek() is FieldEnd)
		{
			result.x9fd888e65466818c = (FieldEnd)x871326a4605c4e8e.Pop();
		}
		if (x871326a4605c4e8e.Count > 0 && x871326a4605c4e8e.Peek() is FieldSeparator)
		{
			result.x43604484a3deae4f = (FieldSeparator)x871326a4605c4e8e.Pop();
		}
		if (x871326a4605c4e8e.Count > 0 && x871326a4605c4e8e.Peek() is FieldStart)
		{
			result.x12cb12b5d2cad53d = (FieldStart)x871326a4605c4e8e.Pop();
		}
		return result;
	}

	private void xbbf9a1ead81dd3a1(WarningType x43163d22e8cd5a71, WarningSource x337e217cb3ba0627, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x43163d22e8cd5a71, x337e217cb3ba0627, xc2358fbac7da3d45));
		}
	}
}
