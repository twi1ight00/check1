using System;
using Aspose.Slides.Charts;
using ns16;
using ns18;
using ns56;

namespace ns17;

internal class Class925
{
	public static void smethod_0(IOverridableText overridableText, Class2134 tx, Class1946 txPr, Class1341 deserializationContext)
	{
		if (tx == null && txPr == null)
		{
			return;
		}
		if (tx != null)
		{
			switch (tx.Text.Name)
			{
			case "rich":
			{
				Class1946 textBodyElementData = (Class1946)tx.Text.Object;
				if (overridableText.TextFrameForOverriding == null)
				{
					overridableText.AddTextFrameForOverriding("");
					overridableText.TextFrameForOverriding.Paragraphs.Clear();
				}
				Class1002.smethod_0(overridableText.TextFrameForOverriding, textBodyElementData, deserializationContext);
				break;
			}
			case "strRef":
			{
				Class2120 @class = (Class2120)tx.Text.Object;
				if (@class != null && @class.StrCache != null && @class.StrCache.PtList != null && @class.StrCache.PtCount.Val != 0)
				{
					if (overridableText.TextFrameForOverriding != null)
					{
						overridableText.TextFrameForOverriding.Text = @class.StrCache.PtList[0].V;
					}
					else
					{
						overridableText.AddTextFrameForOverriding(@class.StrCache.PtList[0].V);
					}
					break;
				}
				throw new NotImplementedException();
			}
			default:
				throw new Exception("Unknown element \"" + tx.Text.Name + "\"");
			}
		}
		Class916.smethod_0(overridableText.TextFormat, txPr, deserializationContext);
	}

	public static void smethod_1(IOverridableText overridableText, Class2134.Delegate2133 addTx, Class1946.Delegate1705 addTxPr, Class1346 serializationContext)
	{
		if (overridableText.TextFrameForOverriding != null && overridableText.TextFrameForOverriding.Paragraphs.Count != 0)
		{
			Class2134 @class = addTx();
			Class1946 textBodyElementData = (Class1946)@class.delegate2773_0("rich").Object;
			Class1002.smethod_2(overridableText.TextFrameForOverriding, textBodyElementData, serializationContext);
		}
		Class916.smethod_5(overridableText.TextFormat, addTxPr, serializationContext);
	}

	internal static bool smethod_2(IOverridableText overridableText)
	{
		if (overridableText.TextFrameForOverriding != null && overridableText.TextFrameForOverriding.Paragraphs.Count != 0)
		{
			return true;
		}
		return Class916.smethod_10(overridableText.TextFormat);
	}
}
