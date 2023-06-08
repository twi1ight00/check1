using ns101;
using ns119;
using ns147;

namespace ns146;

internal class Class4651
{
	private Class4492 class4492_0;

	private Class4681 class4681_0;

	private Class4651 class4651_0;

	private Class4411 class4411_0;

	public Class4681 TTFTables => class4681_0;

	public Class4411 Font => class4411_0;

	internal Class4651 AdoptedHintingFrom
	{
		get
		{
			return class4651_0;
		}
		set
		{
			class4651_0 = value;
		}
	}

	public Class4651(Class4492 fontFileDefinition, Class4411 font, Class4681 ttfTables)
	{
		class4492_0 = fontFileDefinition;
		class4681_0 = ttfTables;
		class4411_0 = font;
	}

	public virtual Class4487 vmethod_0()
	{
		return class4492_0.StreamSource;
	}

	public virtual Class4487 vmethod_1(int glyphId)
	{
		return class4492_0.StreamSource;
	}
}
