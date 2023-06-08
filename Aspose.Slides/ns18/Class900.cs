using Aspose.Slides.Theme;
using ns16;
using ns53;
using ns55;

namespace ns18;

internal class Class900
{
	internal static void smethod_0(IOverrideThemeManager themeOverrideManager, Class1341 deserializationContext)
	{
		themeOverrideManager.OverrideTheme.Clear();
		Class1347[] array = deserializationContext.RelationshipsOfCurrentPartEntry.method_0(Class1236.class1338_0);
		if (array.Length > 0)
		{
			Class1208 @class = new Class1208(array[0].TargetPart, deserializationContext);
			@class.method_5(themeOverrideManager);
		}
	}

	internal static void smethod_1(IOverrideThemeManager themeOverrideManager, Class1348 relationshipsOfPartThatReferencesToThemeOverridePart, Class1346 serializationContext)
	{
		if (themeOverrideManager.IsOverrideThemeEnabled)
		{
			Class1028.smethod_8(themeOverrideManager.OverrideTheme, serializationContext);
			relationshipsOfPartThatReferencesToThemeOverridePart.method_4(serializationContext.ThemeToThemePart[themeOverrideManager.OverrideTheme]);
		}
	}
}
