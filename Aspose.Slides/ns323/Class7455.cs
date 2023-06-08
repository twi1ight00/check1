using System;
using ns322;

namespace ns323;

internal class Class7455 : Class7448
{
	private object object_0;

	private string string_0;

	private string string_1;

	public override string Name => string_0;

	public Class7455(string variableName)
	{
		string_0 = variableName;
	}

	public Class7455(string variableName, string definitionScript)
		: this(variableName)
	{
		string_1 = definitionScript;
	}

	public Class7455(string variableName, object value)
		: this(variableName)
	{
		object_0 = value;
	}

	public Class7455(string variableName, object value, string definitionScript)
		: this(variableName, value)
	{
		string_1 = definitionScript;
	}

	protected void method_10(Class7397 instance)
	{
		base.Global[Name] = instance;
	}

	public override void Initialize()
	{
		Class7397 class2;
		if (object_0 != null)
		{
			Class7456 @class = base.Global.imethod_5(object_0.GetType());
			class2 = @class.method_13(object_0);
		}
		else
		{
			class2 = base.Global.ObjectClass.method_6();
		}
		method_10(class2);
		if (!string.IsNullOrEmpty(string_1))
		{
			try
			{
				Class7685.smethod_0(string_1)?.vmethod_0(new Class7446((Class7399)class2, base.Global));
			}
			catch (Exception)
			{
			}
		}
	}
}
