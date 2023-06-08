using System.Collections.Generic;
using ns305;
using ns73;

namespace ns76;

internal class Class3724 : Interface66, Interface67
{
	private class Class3725
	{
		private string string_0;

		private int int_0;

		private Class3725 class3725_0;

		private int int_1;

		private int int_2;

		public string Identifier => string_0;

		public int Value
		{
			get
			{
				if (class3725_0 != null)
				{
					return class3725_0.Value;
				}
				return int_0;
			}
		}

		public int BeforeValue => int_1;

		public int AfterValue => int_2;

		public Class3725(string identifier, int value)
		{
			string_0 = identifier;
			int_0 = (int_1 = (int_2 = value));
		}

		public void method_0(int value, string pseudoElement)
		{
			if (class3725_0 != null)
			{
				class3725_0.int_0 += value;
			}
			int_0 += value;
			if (pseudoElement != null && !(pseudoElement == Class3724.string_0))
			{
				if (pseudoElement == string_1)
				{
					int_2 += value;
				}
			}
			else
			{
				int_1 += value;
				int_2 += value;
			}
		}

		public void Reset(int value, string pseudoElement)
		{
			class3725_0 = null;
			if (pseudoElement != null && !(pseudoElement == Class3724.string_0))
			{
				if (pseudoElement == string_1)
				{
					int_2 = value;
				}
			}
			else
			{
				int_0 = value;
				int_1 = value;
				int_2 = value;
			}
		}

		public Class3725 method_1()
		{
			Class3725 @class = new Class3725(string_0, int_0);
			@class.class3725_0 = this;
			return @class;
		}
	}

	private Dictionary<string, Class3725> dictionary_0;

	private Class6981 class6981_0;

	private Class3724 class3724_0;

	public static readonly string string_0 = "before";

	public static readonly string string_1 = "after";

	public Class3724(Class6981 owner)
	{
		class6981_0 = owner;
		class3724_0 = smethod_0(owner);
		method_0();
	}

	private static Class3724 smethod_0(Class6981 element)
	{
		Class6976 @class = element.PreviousElementSibling;
		Interface91 @interface;
		while (true)
		{
			if (@class != null)
			{
				@interface = @class as Interface91;
				if (@interface != null)
				{
					break;
				}
				@class = @class.PreviousSibling;
				continue;
			}
			if (element.ParentNode != null && element.ParentNode.NodeType == Enum969.const_0)
			{
				element = element.ParentNode as Class6981;
				if (element is Interface91 interface2)
				{
					return (Class3724)interface2.Counters;
				}
				return smethod_0(element);
			}
			return null;
		}
		return (Class3724)@interface.Counters;
	}

	private void method_0()
	{
		dictionary_0 = new Dictionary<string, Class3725>();
		if (class3724_0 == null)
		{
			return;
		}
		foreach (Class3725 value in class3724_0.dictionary_0.Values)
		{
			dictionary_0.Add(value.Identifier, value.method_1());
		}
	}

	public int imethod_0(string counter, string pseudoElement)
	{
		counter = counter.ToLowerInvariant();
		if (string_0 == pseudoElement)
		{
			if (dictionary_0.ContainsKey(counter))
			{
				return dictionary_0[counter].BeforeValue;
			}
		}
		else if (string_1 == pseudoElement && dictionary_0.ContainsKey(counter))
		{
			return dictionary_0[counter].AfterValue;
		}
		return 0;
	}

	public void imethod_1(string counter)
	{
		imethod_4(counter, 1, null);
	}

	public void imethod_2(string counter, string pseudoElement)
	{
		imethod_4(counter, 1, pseudoElement);
	}

	public void imethod_3(string counter, int value)
	{
		imethod_4(counter, value, null);
	}

	public void imethod_4(string counter, int value, string pseudoElement)
	{
		counter = counter.ToLowerInvariant();
		if (dictionary_0.ContainsKey(counter))
		{
			dictionary_0[counter].method_0(value, pseudoElement);
		}
		else
		{
			dictionary_0.Add(counter, new Class3725(counter, value));
		}
	}

	public void Reset(string counter)
	{
		Reset(counter, 0, null);
	}

	public void Reset(string counter, string pseudoElement)
	{
		Reset(counter, 0, pseudoElement);
	}

	public void Reset(string counter, int value)
	{
		Reset(counter, value, null);
	}

	public void Reset(string counter, int value, string pseudoElement)
	{
		counter = counter.ToLowerInvariant();
		if (dictionary_0.ContainsKey(counter))
		{
			dictionary_0[counter].Reset(value, pseudoElement);
		}
		else
		{
			dictionary_0.Add(counter, new Class3725(counter, value));
		}
	}
}
