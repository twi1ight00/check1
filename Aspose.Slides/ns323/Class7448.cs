using System;
using System.Collections;
using ns322;

namespace ns323;

internal abstract class Class7448
{
	private Class7431 class7431_0;

	internal Class7431 Global => class7431_0;

	public virtual string Name => null;

	protected Class7397 Undefined => Class7437.class7437_0;

	protected Class7397 Null => Class7433.class7433_0;

	internal void Initialize(Class7431 global)
	{
		class7431_0 = global;
		vmethod_0();
	}

	internal virtual void vmethod_0()
	{
		Initialize();
	}

	protected Class7456 method_0(Type type)
	{
		return class7431_0.imethod_5(type);
	}

	protected void method_1(Class7448 extension)
	{
		class7431_0.imethod_4(extension);
	}

	public abstract void Initialize();

	protected Class7397 method_2(object value, Type type)
	{
		return Global.imethod_5(type).method_13(value);
	}

	protected Class7397 method_3(string value)
	{
		return Global.StringClass.method_5(value);
	}

	protected Class7397 method_4(string value)
	{
		if (value == null)
		{
			return Undefined;
		}
		return method_3(value);
	}

	protected Class7397 method_5(double value)
	{
		return Global.NumberClass.method_4(value);
	}

	protected Class7397 method_6(bool value)
	{
		return Global.BooleanClass.method_4(value);
	}

	protected Class7397 method_7(object value)
	{
		return Global.ObjectClass.method_5(value);
	}

	protected Class7397 method_8(Class7397[] value)
	{
		return Global.ArrayClass.method_5(value);
	}

	protected Class7397 method_9(IEnumerable value)
	{
		IEnumerator enumerator = value.GetEnumerator();
		ArrayList arrayList = new ArrayList();
		while (enumerator.MoveNext())
		{
			arrayList.Add(method_2(enumerator.Current, enumerator.Current.GetType()));
		}
		Class7397[] array = new Class7397[arrayList.Count];
		arrayList.CopyTo(array);
		return Global.ArrayClass.method_5(array);
	}
}
