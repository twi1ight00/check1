using System.Collections.Generic;
using ns284;
using ns305;
using ns306;

namespace ns287;

internal class Class7035 : Class6983
{
	private int int_0 = -1;

	public string Type
	{
		get
		{
			if (!Multiple)
			{
				return "select-one";
			}
			return "select-multiple";
		}
	}

	public int SelectedIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 0 || value > Length - 1)
			{
				int_0 = -1;
			}
			int_0 = value;
		}
	}

	public string Value
	{
		get
		{
			if (int_0 == -1)
			{
				return string.Empty;
			}
			return Options[int_0].TextContent;
		}
		set
		{
			IEnumerator<Class6976> enumerator = Options.GetEnumerator();
			int num = 0;
			int num2 = -1;
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.TextContent.Equals(value))
				{
					num2 = num;
					break;
				}
			}
			int_0 = num2;
		}
	}

	public int Length
	{
		get
		{
			return Options.Length;
		}
		set
		{
			if (value == Options.Length)
			{
				return;
			}
			if (value < 0)
			{
				value = 0;
			}
			if (value < Options.Length)
			{
				IEnumerator<Class6976> enumerator = Options.GetEnumerator();
				List<Class6976> list = new List<Class6976>();
				while (enumerator.MoveNext())
				{
					if (value == 0)
					{
						list.Add(enumerator.Current);
					}
					else
					{
						value--;
					}
				}
				{
					foreach (Class6976 item in list)
					{
						method_2(item);
					}
					return;
				}
			}
			for (int num = value - Options.Length; num != 0; num--)
			{
				vmethod_1(base.OwnerDocument.CreateElement("OPTION"));
			}
		}
	}

	public Class7009 Form => method_49<Class7009>();

	public Class7076 Options => new Class7077(method_47("OPTION"));

	public bool Disabled
	{
		get
		{
			return method_34("disabled");
		}
		set
		{
			method_52("disabled", value);
		}
	}

	public bool Multiple
	{
		get
		{
			return method_34("multiple");
		}
		set
		{
			method_52("multiple", value);
		}
	}

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

	public int Size
	{
		get
		{
			return method_39("size", 1);
		}
		set
		{
			method_42("size", value);
		}
	}

	public int TabIndex
	{
		get
		{
			return method_39("tabindex", 0);
		}
		set
		{
			method_42("tabindex", value);
		}
	}

	protected internal Class7035(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public void Add(Class6982 element, Class6982 before)
	{
	}

	public void Remove(int index)
	{
	}

	public void method_53()
	{
	}

	public void method_54()
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		Interface325 @interface = visitor.imethod_63(this);
		if (@interface != null)
		{
			method_48(@interface);
			visitor.imethod_64(this, @interface);
		}
	}
}
