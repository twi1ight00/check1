using System;

namespace ns67;

internal abstract class Class3075 : Class3073
{
	private readonly Class3401 class3401_0;

	private readonly Class3406 class3406_0;

	private readonly Class3391 class3391_0;

	private readonly Class3394 class3394_0;

	private readonly Class3398 class3398_0;

	public Class3401 Bullet => class3401_0;

	public Class3391 Color => class3391_0;

	public Class3406 CharacterProperties => class3406_0;

	public Class3394 Size => class3394_0;

	public Class3398 Typeface => class3398_0;

	protected Class3075(Class3401 bullet, Class3391 color, Class3394 size, Class3398 typeface, Class3406 characterProperties)
	{
		class3401_0 = bullet;
		class3391_0 = color;
		class3394_0 = size;
		class3398_0 = typeface;
		class3406_0 = characterProperties;
	}

	protected Class3406 method_3()
	{
		Class3406 @class = class3406_0.method_0();
		@class.FillMode = method_4();
		@class.FontSize = method_5();
		Class3449 symbolFont = (@class.LatinFont = (@class.EastAsianFont = (@class.ComplexScriptFont = method_6())));
		@class.SymbolFont = symbolFont;
		return @class;
	}

	private Class3331 method_4()
	{
		Class3331 @class = null;
		if (class3391_0 is Class3393)
		{
			return class3406_0.FillMode.vmethod_0();
		}
		if (class3391_0 is Class3392 class3)
		{
			return new Class3339(class3.Color);
		}
		throw new NotImplementedException();
	}

	private double method_5()
	{
		if (class3394_0 is Class3395)
		{
			return class3406_0.FontSize;
		}
		if (class3394_0 is Class3396 class2)
		{
			return class3406_0.FontSize * class2.Value / 100000.0;
		}
		if (class3394_0 is Class3397 class3)
		{
			return class3.Value;
		}
		throw new NotImplementedException();
	}

	private Class3449 method_6()
	{
		if (class3398_0 is Class3399)
		{
			return class3406_0.LatinFont;
		}
		if (class3398_0 is Class3400 class2)
		{
			return class2.Value;
		}
		throw new NotImplementedException();
	}
}
