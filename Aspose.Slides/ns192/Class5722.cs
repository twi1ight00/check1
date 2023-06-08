using ns197;

namespace ns192;

internal class Class5722
{
	public const int int_0 = 0;

	public const int int_1 = 1;

	public const int int_2 = 2;

	internal Class5706 class5706_0;

	internal Class5706 class5706_1;

	internal Class5706 class5706_2;

	private Class5711 class5711_0;

	private Class5722(Class5706 normal, Class5706 leadingTrailing, Class5706 rest, Class5711 collapsingBorderModel)
	{
		class5706_0 = normal;
		class5706_1 = leadingTrailing;
		class5706_2 = rest;
		class5711_0 = collapsingBorderModel;
	}

	internal Class5722(Class5706 borderSpecification, Class5711 collapsingBorderModel)
	{
		class5706_0 = borderSpecification;
		class5706_1 = class5706_0;
		if (borderSpecification.method_0().method_2().vmethod_16())
		{
			class5706_2 = Class5706.smethod_0();
		}
		else
		{
			class5706_2 = class5706_1;
		}
		class5711_0 = collapsingBorderModel;
	}

	internal void method_0(Class5722 competitor, bool withNormal, bool withLeadingTrailing, bool withRest)
	{
		if (withNormal)
		{
			Class5706 @class = class5711_0.vmethod_1(class5706_0, competitor.class5706_0);
			if (@class != null)
			{
				class5706_0 = @class;
				competitor.class5706_0 = @class;
			}
		}
		if (withLeadingTrailing)
		{
			Class5706 class2 = class5711_0.vmethod_1(class5706_1, competitor.class5706_1);
			if (class2 != null)
			{
				class5706_1 = class2;
				competitor.class5706_1 = class2;
			}
		}
		if (withRest)
		{
			Class5706 class3 = class5711_0.vmethod_1(class5706_2, competitor.class5706_2);
			if (class3 != null)
			{
				class5706_2 = class3;
				competitor.class5706_2 = class3;
			}
		}
	}

	internal void method_1(Class5722 competitor, bool withNormal, bool withLeadingTrailing, bool withRest)
	{
		if (withNormal)
		{
			Class5706 @class = class5711_0.vmethod_1(class5706_0, competitor.class5706_0);
			if (@class != null)
			{
				class5706_0 = @class;
			}
		}
		if (withLeadingTrailing)
		{
			Class5706 class2 = class5711_0.vmethod_1(class5706_1, competitor.class5706_1);
			if (class2 != null)
			{
				class5706_1 = class2;
			}
		}
		if (withRest)
		{
			Class5706 class3 = class5711_0.vmethod_1(class5706_2, competitor.class5706_2);
			if (class3 != null)
			{
				class5706_2 = class3;
			}
		}
	}

	internal void method_2(Class5722 segment, bool withNormal, bool withLeadingTrailing, bool withRest)
	{
		if (withNormal)
		{
			class5706_0 = class5711_0.vmethod_1(class5706_0, segment.class5706_0);
		}
		if (withLeadingTrailing)
		{
			class5706_1 = class5711_0.vmethod_1(class5706_1, segment.class5706_1);
		}
		if (withRest)
		{
			class5706_2 = class5711_0.vmethod_1(class5706_2, segment.class5706_2);
		}
	}

	internal Class5722 method_3()
	{
		return new Class5722(class5706_0, class5706_1, class5706_2, class5711_0);
	}

	public override string ToString()
	{
		return string.Concat("{normal: ", class5706_0, ", leading: ", class5706_1, ", rest: ", class5706_2, "}");
	}

	internal static Class5722 smethod_0(Class5711 collapsingBorderModel)
	{
		Class5706 @class = Class5706.smethod_0();
		return new Class5722(@class, @class, @class, collapsingBorderModel);
	}
}
