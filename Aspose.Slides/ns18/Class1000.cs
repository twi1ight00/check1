using ns16;
using ns4;
using ns56;

namespace ns18;

internal class Class1000
{
	public static void smethod_0(Class146 tableStyles, Class2316 tableStyleListElementData, Class1341 deserializationContext)
	{
		Class1942[] tblStyleList = tableStyleListElementData.TblStyleList;
		foreach (Class1942 @class in tblStyleList)
		{
			Class144 style = tableStyles.method_4(@class.StyleId, @class.StyleName);
			Class1001.smethod_0(style, @class, deserializationContext);
		}
		tableStyles.PPTXUnsupportedProps.DefaultStyleId = tableStyleListElementData.Def;
	}

	public static void smethod_1(Class146 tableStyles, Class2316 tableStyleListElementData, Class1346 serializationContext)
	{
		tableStyleListElementData.Def = tableStyles.PPTXUnsupportedProps.DefaultStyleId;
		foreach (Class144 tableStyle in tableStyles)
		{
			if (serializationContext.UsedTableStyles.ContainsKey(tableStyle.PPTXUnsupportedProps.Id))
			{
				Class1001.smethod_1(tableStyle, tableStyleListElementData.delegate1693_0, serializationContext);
			}
		}
	}
}
