using ns305;
using ns76;

namespace ns73;

internal class Class7098 : Class7097, Interface63
{
	public const string string_1 = "HTML+CSS";

	public Class7098(Class7057 factory)
		: base(factory, "HTML+CSS")
	{
	}

	public Class7098(Class7057 factory, string feature)
		: base(factory, feature)
	{
	}

	public Interface76 imethod_0(string title, string media)
	{
		Class3735 @class = new Class3735();
		@class.Title = title;
		return @class;
	}

	public override bool imethod_1(string feature, string version)
	{
		if (!"HTML+CSS".Equals(feature))
		{
			return base.imethod_1(feature, version);
		}
		return true;
	}
}
