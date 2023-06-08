using System.Collections;
using System.IO;
using System.Text;
using Aspose.Words.Markup;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;
using xf989f31a236ff98c;

namespace xa604c4d210ae0581;

internal class x4fe6ba040498cc67
{
	private x4fe6ba040498cc67()
	{
	}

	internal static void x06b0e25aa6ad68a9(xd8c3135513b9115b x84378c276c4cd7e2, CustomXmlPartCollection x361132de876f4a8c)
	{
		xe7be411416cfcd54 xe7be411416cfcd = x84378c276c4cd7e2.x29e7ace4c90f74cd.x03c5de1b1357f136("MsoDataStore");
		if (xe7be411416cfcd == null)
		{
			return;
		}
		foreach (DictionaryEntry item in xe7be411416cfcd)
		{
			CustomXmlPart customXmlPart = new CustomXmlPart();
			xe7be411416cfcd54 xe7be411416cfcd2 = (xe7be411416cfcd54)item.Value;
			foreach (DictionaryEntry item2 in xe7be411416cfcd2)
			{
				switch ((string)item2.Key)
				{
				case "Item":
					customXmlPart.Data = x0d299f323d241756.xa0aed4cd3b3d5d92((Stream)item2.Value);
					break;
				case "Properties":
					xb2de080ec26d1a63.x06b0e25aa6ad68a9((Stream)item2.Value, customXmlPart);
					break;
				}
			}
			x361132de876f4a8c.Add(customXmlPart);
		}
	}

	internal static xe7be411416cfcd54 x6210059f049f0d48(CustomXmlPartCollection x361132de876f4a8c)
	{
		if (x361132de876f4a8c.Count == 0)
		{
			return null;
		}
		xe7be411416cfcd54 xe7be411416cfcd = new xe7be411416cfcd54();
		for (int i = 0; i < x361132de876f4a8c.Count; i++)
		{
			CustomXmlPart customXmlPart = x361132de876f4a8c[i];
			xe7be411416cfcd54 xe7be411416cfcd2 = new xe7be411416cfcd54();
			xe7be411416cfcd2.xd6b6ed77479ef68c("Item", new MemoryStream(customXmlPart.Data));
			Stream stream = new MemoryStream();
			x3c74b3c4f21844f9 xd07ce4b74c5774a = new x3c74b3c4f21844f9(stream, Encoding.UTF8, isPrettyFormat: false);
			xb2de080ec26d1a63.x6210059f049f0d48(customXmlPart, xd07ce4b74c5774a);
			xe7be411416cfcd2.Add("Properties", stream);
			xe7be411416cfcd.xd6b6ed77479ef68c($"cxds{i}", xe7be411416cfcd2);
		}
		return xe7be411416cfcd;
	}
}
