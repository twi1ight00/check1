using ns224;

namespace ns315;

internal class Class7136
{
	private Class7137 class7137_0;

	public Class7136(Class7137 owner)
	{
		class7137_0 = owner;
	}

	public Class7136 Write(string value)
	{
		class7137_0.Write(value);
		return this;
	}

	public Class7136 Write(string format, params object[] args)
	{
		class7137_0.Write(format, args);
		return this;
	}

	public Class7136 method_0()
	{
		class7137_0.method_4(checkPreviousChar: true);
		Write("style=\"");
		return this;
	}

	public Class7137 method_1()
	{
		Write("\"");
		return class7137_0;
	}

	public Class7136 method_2(Class5998 color)
	{
		class7137_0.Write("fill:").Write(color).Write(";");
		return this;
	}

	public Class7136 method_3(Class5998 color)
	{
		class7137_0.Write("stroke:").Write(color).Write(";");
		return this;
	}

	public Class7136 method_4(string stroke)
	{
		class7137_0.Write("stroke:").Write("none").Write(";");
		return this;
	}

	public Class7136 method_5(float size)
	{
		class7137_0.Write("font-size:").Write(size).Write(";");
		return this;
	}

	public Class7136 method_6(string familyName)
	{
		class7137_0.Write("font-family:").Write(familyName).Write(";");
		return this;
	}

	public Class7136 method_7(string style)
	{
		class7137_0.Write("font-style:").Write(style).Write(";");
		return this;
	}

	public Class7136 method_8(string weight)
	{
		class7137_0.Write("font-weight:").Write(weight).Write(";");
		return this;
	}
}
