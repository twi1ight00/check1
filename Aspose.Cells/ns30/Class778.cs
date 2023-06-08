using System.Text;
using Aspose.Cells.Properties;
using ns57;
using ns59;

namespace ns30;

internal class Class778
{
	internal static void smethod_0(Class1317 class1317_0, BuiltInDocumentPropertyCollection builtInDocumentPropertyCollection_0, CustomDocumentPropertyCollection customDocumentPropertyCollection_0)
	{
		if (class1317_0 == null)
		{
			return;
		}
		Class1726 @class = new Class1726();
		@class.Read(class1317_0.method_9(), builtInDocumentPropertyCollection_0, customDocumentPropertyCollection_0);
		class1317_0.method_9().Remove("\u0005SummaryInformation");
		class1317_0.method_9().Remove("\u0005DocumentSummaryInformation");
		if (customDocumentPropertyCollection_0.Contains("_PID_LINKBASE"))
		{
			DocumentProperty documentProperty = customDocumentPropertyCollection_0["_PID_LINKBASE"];
			if (documentProperty.Value is byte[])
			{
				byte[] array = (byte[])documentProperty.Value;
				builtInDocumentPropertyCollection_0.HyperlinkBase = Encoding.Unicode.GetString(array, 0, array.Length - 2);
			}
			else
			{
				builtInDocumentPropertyCollection_0.HyperlinkBase = documentProperty.ToString();
			}
			customDocumentPropertyCollection_0.Remove("_PID_LINKBASE");
		}
	}
}
