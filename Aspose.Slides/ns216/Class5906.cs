using ns217;

namespace ns216;

internal class Class5906
{
	private static void smethod_0(Class5898 attribute, Class5781 parent, string name, object value)
	{
		attribute.Value = value;
		parent.Attributes.Add(name, attribute);
	}

	public static Class5898 smethod_1(Class5781 parent, string name, float @default)
	{
		Class5899 @class = new Class5899();
		smethod_0(@class, parent, name, @default);
		return @class;
	}

	public static Class5898 smethod_2(Class5781 parent, string name, int @default)
	{
		Class5900 @class = new Class5900();
		smethod_0(@class, parent, name, @default);
		return @class;
	}

	public static Class5898 smethod_3(Class5781 parent, string name, bool @default)
	{
		Class5901 @class = new Class5901();
		smethod_0(@class, parent, name, @default);
		return @class;
	}

	public static Class5898 smethod_4(Class5781 parent, string name, string @default)
	{
		Class5902 @class = new Class5902();
		smethod_0(@class, parent, name, @default);
		return @class;
	}

	public static Class5898 smethod_5(Class5781 parent, string name, char @default)
	{
		Class5903 @class = new Class5903();
		smethod_0(@class, parent, name, @default);
		return @class;
	}

	public static Class5898 smethod_6(Class5781 parent, string name, object @default)
	{
		Class5905 @class = new Class5905();
		smethod_0(@class, parent, name, @default);
		return @class;
	}

	public static Class5898 smethod_7(Class5781 parent, string name)
	{
		Class5904 @class = new Class5904();
		smethod_0(@class, parent, name, new float[0]);
		return @class;
	}
}
