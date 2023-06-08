using ns284;
using ns305;

namespace ns287;

internal class Class7007 : Class6983
{
	public Class7009 Form => method_49<Class7009>();

	protected internal Class7007(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_65(this);
		method_48(visitor);
		visitor.imethod_66(this);
	}
}
