using System;
using System.Collections;
using ns323;

namespace ns322;

internal class Class7431 : Class7399, Interface401
{
	private Interface396 interface396_0;

	private Enum987 enum987_0;

	private Class7417 class7417_0;

	private Class7414 class7414_0;

	private Class7412 class7412_0;

	private Class7408 class7408_0;

	private Class7409 class7409_0;

	private Class7410 class7410_0;

	private Class7411 class7411_0;

	private Class7411 class7411_1;

	private Class7411 class7411_2;

	private Class7411 class7411_3;

	private Class7411 class7411_4;

	private Class7411 class7411_5;

	private Class7411 class7411_6;

	private Class7432 class7432_0;

	private Class7413 class7413_0;

	private Class7415 class7415_0;

	private Class7416 class7416_0;

	private Hashtable hashtable_0 = new Hashtable();

	public Interface396 Visitor
	{
		get
		{
			return interface396_0;
		}
		set
		{
			interface396_0 = value;
		}
	}

	public Enum987 Options
	{
		get
		{
			return enum987_0;
		}
		set
		{
			enum987_0 = value;
		}
	}

	public override string _Class => "Global";

	public Class7414 ObjectClass
	{
		get
		{
			return class7414_0;
		}
		set
		{
			class7414_0 = value;
		}
	}

	public Class7412 FunctionClass
	{
		get
		{
			return class7412_0;
		}
		set
		{
			class7412_0 = value;
		}
	}

	public Class7408 ArrayClass
	{
		get
		{
			return class7408_0;
		}
		set
		{
			class7408_0 = value;
		}
	}

	public Class7409 BooleanClass
	{
		get
		{
			return class7409_0;
		}
		set
		{
			class7409_0 = value;
		}
	}

	public Class7410 DateClass
	{
		get
		{
			return class7410_0;
		}
		set
		{
			class7410_0 = value;
		}
	}

	public Class7411 ErrorClass
	{
		get
		{
			return class7411_0;
		}
		set
		{
			class7411_0 = value;
		}
	}

	public Class7411 EvalErrorClass
	{
		get
		{
			return class7411_1;
		}
		set
		{
			class7411_1 = value;
		}
	}

	public Class7411 RangeErrorClass
	{
		get
		{
			return class7411_2;
		}
		set
		{
			class7411_2 = value;
		}
	}

	public Class7411 ReferenceErrorClass
	{
		get
		{
			return class7411_3;
		}
		set
		{
			class7411_3 = value;
		}
	}

	public Class7411 SyntaxErrorClass
	{
		get
		{
			return class7411_4;
		}
		set
		{
			class7411_4 = value;
		}
	}

	public Class7411 TypeErrorClass
	{
		get
		{
			return class7411_5;
		}
		set
		{
			class7411_5 = value;
		}
	}

	public Class7411 URIErrorClass
	{
		get
		{
			return class7411_6;
		}
		set
		{
			class7411_6 = value;
		}
	}

	public Class7432 MathClass
	{
		get
		{
			return class7432_0;
		}
		set
		{
			class7432_0 = value;
		}
	}

	public Class7413 NumberClass
	{
		get
		{
			return class7413_0;
		}
		set
		{
			class7413_0 = value;
		}
	}

	public Class7415 RegExpClass
	{
		get
		{
			return class7415_0;
		}
		set
		{
			class7415_0 = value;
		}
	}

	public Class7416 StringClass
	{
		get
		{
			return class7416_0;
		}
		set
		{
			class7416_0 = value;
		}
	}

	public Class7397 NaN => this["NaN"];

	public bool imethod_0(Enum987 options)
	{
		return (Options & options) == options;
	}

	public Class7397 imethod_3(Class7397[] arguments)
	{
		return class7417_0.method_5(arguments);
	}

	public Class7397 imethod_2(Class7397[] arguments)
	{
		return class7417_0.method_6(arguments);
	}

	public Class7397 imethod_1(Class7397[] arguments)
	{
		return class7417_0.method_7(arguments);
	}

	public void imethod_4(Class7448 extension)
	{
		if (extension is Class7456 @class)
		{
			hashtable_0.Add(@class.Type, extension);
		}
		extension.Initialize(this);
	}

	public Class7456 imethod_5(Type type)
	{
		if (!hashtable_0.ContainsKey(type))
		{
			throw new ArgumentException($"Extension for type '{type.Name}' is not found.");
		}
		return (Class7456)hashtable_0[type];
	}

	public Class7431(Class7678 visitor, Enum987 options)
		: base(Class7433.class7433_0)
	{
		Options = options;
		Visitor = visitor;
		class7417_0 = new Class7417(this, visitor, null, Class7433.class7433_0);
		this["null"] = Class7433.class7433_0;
		Class7399 @class = new Class7399(Class7433.class7433_0);
		Class7400 prototype = new Class7417(this, null, "prototype", @class);
		this["Function"] = (FunctionClass = new Class7412(this, prototype));
		this["Object"] = (ObjectClass = new Class7414(this, prototype, @class));
		ObjectClass.vmethod_26(this);
		this["Array"] = (ArrayClass = new Class7408(this));
		this["Boolean"] = (BooleanClass = new Class7409(this));
		this["Date"] = (DateClass = new Class7410(this));
		this["Error"] = (ErrorClass = new Class7411(this, "Error"));
		this["EvalError"] = (EvalErrorClass = new Class7411(this, "EvalError"));
		this["RangeError"] = (RangeErrorClass = new Class7411(this, "RangeError"));
		this["ReferenceError"] = (ReferenceErrorClass = new Class7411(this, "ReferenceError"));
		this["SyntaxError"] = (SyntaxErrorClass = new Class7411(this, "SyntaxError"));
		this["TypeError"] = (TypeErrorClass = new Class7411(this, "TypeError"));
		this["URIError"] = (URIErrorClass = new Class7411(this, "URIError"));
		this["Number"] = (NumberClass = new Class7413(this));
		this["RegExp"] = (RegExpClass = new Class7415(this));
		this["String"] = (StringClass = new Class7416(this));
		this["Math"] = (MathClass = new Class7432(this));
		foreach (Class7397 item in vmethod_20())
		{
			if (item is Class7406 class19)
			{
				class19.vmethod_26(this);
			}
		}
		this["NaN"] = NumberClass["NaN"];
		this["Infinity"] = NumberClass["POSITIVE_INFINITY"];
		this["undefined"] = Class7437.class7437_0;
		this[Class7438.string_21] = this;
		this["eval"] = new Class7417(this, visitor, "eval", FunctionClass.PrototypeProperty);
		this["parseInt"] = new Class7417(this, visitor, "parseInt", FunctionClass.PrototypeProperty);
		this["parseFloat"] = new Class7417(this, visitor, "parseFloat", FunctionClass.PrototypeProperty);
		this["isNaN"] = new Class7417(this, visitor, "isNaN", FunctionClass.PrototypeProperty);
		this["isFinite"] = new Class7417(this, visitor, "isFinite", FunctionClass.PrototypeProperty);
		this["decodeURI"] = new Class7417(this, visitor, "decodeURI", FunctionClass.PrototypeProperty);
		this["encodeURI"] = new Class7417(this, visitor, "encodeURI", FunctionClass.PrototypeProperty);
		this["decodeURIComponent"] = new Class7417(this, visitor, "decodeURIComponent", FunctionClass.PrototypeProperty);
		this["encodeURIComponent"] = new Class7417(this, visitor, "encodeURIComponent", FunctionClass.PrototypeProperty);
	}
}
