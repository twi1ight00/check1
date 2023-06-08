using ns34;
using ns56;

namespace ns20;

internal class Class254
{
	public static void smethod_0(Class805 numFormats, Class1594 numFmtsElementData)
	{
		if (numFmtsElementData != null)
		{
			Class1593[] numFmtList = numFmtsElementData.NumFmtList;
			foreach (Class1593 @class in numFmtList)
			{
				Class804 class2 = new Class804();
				class2.FormatCode = @class.FormatCode;
				class2.NumFormatID = @class.NumFmtId;
				numFormats.Add(class2);
			}
		}
	}

	public static void smethod_1(Class805 numFormats, Class1594 numFmtsElementData)
	{
		if (numFormats == null)
		{
			return;
		}
		numFmtsElementData.Count = (uint)numFormats.Count;
		foreach (Class804 numFormat in numFormats)
		{
			Class1593 class2 = numFmtsElementData.delegate658_0();
			class2.FormatCode = numFormat.FormatCode;
			class2.NumFmtId = numFormat.NumFormatID;
		}
	}
}
