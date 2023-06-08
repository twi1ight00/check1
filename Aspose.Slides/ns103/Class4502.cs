using System.Text;
using ns119;

namespace ns103;

internal class Class4502
{
	public static string smethod_0(Class4490 fontDefinition)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Font Name: {0}", fontDefinition.FontName);
		stringBuilder.AppendFormat("Font Type: {0}", fontDefinition.FontType);
		if (fontDefinition.FileDefinitions != null && fontDefinition.FileDefinitions.Length > 0)
		{
			stringBuilder.AppendFormat("Font File Definitions:");
			Class4492[] fileDefinitions = fontDefinition.FileDefinitions;
			foreach (Class4492 @class in fileDefinitions)
			{
				stringBuilder.AppendFormat("File Name: {0}", @class.FileName);
				stringBuilder.AppendFormat("File Extension: {0}", @class.FileExtension);
				stringBuilder.AppendFormat("Stream Source Type: {0}", (@class.StreamSource is Class4489) ? "file" : "byte array");
			}
		}
		else
		{
			stringBuilder.AppendFormat("Font File Definitions: not present");
		}
		return stringBuilder.ToString();
	}
}
