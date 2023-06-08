namespace ns322;

internal abstract class Class7352
{
	private string string_0;

	protected bool bool_0;

	protected bool bool_1;

	protected bool bool_2;

	private Class7398 class7398_0;

	private bool bool_3;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public bool Enumerable
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool Configurable
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool Writable
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public Class7398 Owner => class7398_0;

	public virtual bool isDeleted
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public abstract bool isReference { get; }

	internal abstract Enum984 DescriptorType { get; }

	public virtual void vmethod_0()
	{
		isDeleted = true;
	}

	public abstract Class7352 Clone();

	public abstract Class7397 vmethod_1(Class7398 that);

	public abstract void vmethod_2(Class7398 that, Class7397 value);

	internal static Class7352 smethod_0(Interface401 global, Class7398 owner, string name, Class7397 instance)
	{
		if (instance._Class != "Object")
		{
			throw new Exception88(global.TypeErrorClass.method_4("The target object has to be an instance of an object"));
		}
		Class7399 @class = (Class7399)instance;
		if ((!@class.vmethod_7("value") && !@class.vmethod_7("writable")) || (!@class.vmethod_7("set") && !@class.vmethod_7("get")))
		{
			Class7397 result = null;
			Class7352 class2 = ((!@class.vmethod_7("value")) ? ((Class7352)new Class7353(global, owner, name)) : ((Class7352)new Class7359(owner, name, @class["value"])));
			if (@class.vmethod_15("enumerable", out result))
			{
				class2.Enumerable = result.vmethod_2();
			}
			if (@class.vmethod_15("configurable", out result))
			{
				class2.Configurable = result.vmethod_2();
			}
			if (@class.vmethod_15("writable", out result))
			{
				class2.Writable = result.vmethod_2();
			}
			if (@class.vmethod_15("get", out result))
			{
				if (!(result is Class7400 getFunction))
				{
					throw new Exception88(global.TypeErrorClass.method_4("The getter has to be a function"));
				}
				((Class7353)class2).GetFunction = getFunction;
			}
			if (@class.vmethod_15("set", out result))
			{
				if (!(result is Class7400 setFunction))
				{
					throw new Exception88(global.TypeErrorClass.method_4("The setter has to be a function"));
				}
				((Class7353)class2).SetFunction = setFunction;
			}
			return class2;
		}
		throw new Exception88(global.TypeErrorClass.method_4("The property cannot be both writable and have get/set accessors or cannot have both a value and an accessor defined"));
	}

	public Class7352(Class7398 owner, string name)
	{
		class7398_0 = owner;
		string_0 = name;
	}
}
