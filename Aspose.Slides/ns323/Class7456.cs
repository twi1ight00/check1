using System;
using ns322;

namespace ns323;

internal abstract class Class7456 : Class7448
{
	private Class7407 class7407_0;

	protected internal abstract Type Type { get; }

	protected virtual Type InheritedType => null;

	internal override void vmethod_0()
	{
		class7407_0 = new Class7407(base.Global, Name, vmethod_1);
		class7407_0.vmethod_26(base.Global);
		if (InheritedType != null)
		{
			class7407_0.PrototypeProperty = (Class7399)method_0(InheritedType).method_14();
		}
		Initialize();
	}

	protected void method_10(string name)
	{
		class7407_0.method_4(name);
	}

	protected void method_11(string name, Enum983 propertyAccessor)
	{
		class7407_0.method_5(name, propertyAccessor);
	}

	protected void method_12(Class7397 instance, string fieldName, Class7397 value)
	{
		Class7399 @class = (Class7399)instance;
		Class7359 currentDescriptor = new Class7359(@class, fieldName, value);
		@class.vmethod_18(currentDescriptor);
	}

	protected virtual Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		return base.Undefined;
	}

	public Class7397 method_13(object @object)
	{
		Class7397 @class = class7407_0.method_6(@object);
		vmethod_2(@class);
		return @class;
	}

	public Class7397 method_14()
	{
		Class7397 @class = class7407_0.method_7();
		vmethod_2(@class);
		return @class;
	}

	protected virtual void vmethod_2(Class7397 instance)
	{
	}
}
