using System.Collections;
using ns101;
using ns119;
using ns147;

namespace ns146;

internal class Class4652 : Class4651
{
	private Class4491 class4491_0;

	private Class4487 class4487_0;

	private Hashtable hashtable_0;

	private Hashtable hashtable_1;

	public Class4652(Class4491 pclFontDefinition, Class4411 font, Class4681 ttfTables)
		: base(null, font, ttfTables)
	{
		class4491_0 = pclFontDefinition;
		class4487_0 = new Class4488(((Class4491.Class4636)pclFontDefinition.GlobalFontDefinition).GlobalData);
		hashtable_0 = new Hashtable(pclFontDefinition.GlyphIdToGlyphData.Count);
		hashtable_1 = pclFontDefinition.GlyphIdToGlyphData;
	}

	public override Class4487 vmethod_0()
	{
		return class4487_0;
	}

	public override Class4487 vmethod_1(int glyphId)
	{
		Class4487 @class = (Class4487)hashtable_0[glyphId];
		if (@class == null)
		{
			if (hashtable_1.ContainsKey(glyphId))
			{
				@class = new Class4488(((Class4491.Class4639)hashtable_1[glyphId]).Data);
				hashtable_0[glyphId] = @class;
			}
			else
			{
				@class = null;
			}
		}
		return @class;
	}
}
