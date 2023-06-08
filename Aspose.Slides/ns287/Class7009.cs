using System.Collections.Generic;
using System.Collections.ObjectModel;
using ns284;
using ns305;

namespace ns287;

internal class Class7009 : Class6983
{
	private static volatile ReadOnlyCollection<string> readOnlyCollection_0;

	private static readonly object object_2 = new object();

	private static IEnumerable<string> FormElements
	{
		get
		{
			if (readOnlyCollection_0 == null)
			{
				lock (object_2)
				{
					if (readOnlyCollection_0 == null)
					{
						List<string> list = new List<string>(8);
						list.Add("BUTTON");
						list.Add("FIELDSET");
						list.Add("KEYGEN");
						list.Add("OUTPUT");
						list.Add("SELECT");
						list.Add("TEXTAREA");
						list.Add("INPUT");
						list.Add("OBJECT");
						readOnlyCollection_0 = new ReadOnlyCollection<string>(list);
					}
				}
			}
			return readOnlyCollection_0;
		}
	}

	public Class7078 Elements => new Class7081(method_46(FormElements));

	public int Length => method_46(FormElements).Length;

	public string Name
	{
		get
		{
			return method_45("name", string.Empty);
		}
		set
		{
			method_21("name", value);
		}
	}

	public string AcceptCharset
	{
		get
		{
			return method_45("accept-charset", string.Empty);
		}
		set
		{
			method_21("accept-charset", value);
		}
	}

	public string Action
	{
		get
		{
			return method_45("action", string.Empty);
		}
		set
		{
			method_21("action", value);
		}
	}

	public string Enctype
	{
		get
		{
			return method_45("enctype", string.Empty);
		}
		set
		{
			method_21("enctype", value);
		}
	}

	public string Method
	{
		get
		{
			return method_45("method", string.Empty);
		}
		set
		{
			method_21("method", value);
		}
	}

	public string Target
	{
		get
		{
			return method_45("target", string.Empty);
		}
		set
		{
			method_21("target", value);
		}
	}

	protected internal Class7009(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public void method_53()
	{
	}

	public void Reset()
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_11(this);
		method_48(visitor);
		visitor.imethod_12(this);
	}
}
