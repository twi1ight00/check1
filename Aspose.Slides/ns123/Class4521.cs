using System;
using ns106;
using ns122;

namespace ns123;

internal abstract class Class4521 : Class4520
{
	private Class4700 class4700_0;

	public Class4700 Context => class4700_0;

	protected Class4521(Class4700 context, Class4521 parent)
		: base(parent, context.File)
	{
		class4700_0 = context;
		if (context.File == null)
		{
			throw new Exception48($"The parser {GetType().Name} could not start because parsing content is empty");
		}
	}

	public override void vmethod_0(int startPosition, out int endPosition)
	{
		try
		{
			base.vmethod_0(startPosition, out endPosition);
		}
		catch (Exception innerException)
		{
			throw new Exception48($"Error happened during parsing {GetType().Name + new Class4696().method_1(this)}", innerException);
		}
	}
}
