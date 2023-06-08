using System;
using System.Collections;

namespace ns322;

internal class Class7438 : Class7398
{
	private class Class7686 : IEnumerable
	{
		private class Class7687 : IEnumerator
		{
			private Class7438 class7438_0;

			private IEnumerator ienumerator_0;

			private string string_0;

			private bool bool_0;

			public object Current => string_0;

			public Class7687(Class7438 scope)
			{
				class7438_0 = scope;
				if (scope.class7398_1 != null)
				{
					bool_0 = true;
					ienumerator_0 = scope.class7398_1.vmethod_19().GetEnumerator();
				}
				else
				{
					ienumerator_0 = scope.method_5().GetEnumerator();
				}
			}

			public bool MoveNext()
			{
				string key;
				while (true)
				{
					if (ienumerator_0.MoveNext())
					{
						key = (string)ienumerator_0.Current;
						if (!bool_0)
						{
							break;
						}
						if (class7438_0.method_4(key) == null)
						{
							string_0 = key;
							return true;
						}
						continue;
					}
					if (bool_0)
					{
						bool_0 = false;
						ienumerator_0 = class7438_0.method_5().GetEnumerator();
						return MoveNext();
					}
					return false;
				}
				string_0 = key;
				return true;
			}

			public void Reset()
			{
				if (class7438_0.class7398_1 != null)
				{
					class7438_0.class7398_1.vmethod_19().GetEnumerator().Reset();
				}
				class7438_0.method_5().GetEnumerator().Reset();
				if (class7438_0.class7398_1 != null)
				{
					ienumerator_0 = class7438_0.class7398_1.vmethod_19().GetEnumerator();
				}
				else
				{
					ienumerator_0 = class7438_0.method_5().GetEnumerator();
				}
			}
		}

		private Class7438 class7438_0;

		public IEnumerator GetEnumerator()
		{
			return new Class7687(class7438_0);
		}

		public Class7686(Class7438 scope)
		{
			class7438_0 = scope;
		}
	}

	private class Class7688 : IEnumerable
	{
		private class Class7689 : IEnumerator
		{
			private Class7438 class7438_0;

			private IEnumerator ienumerator_0;

			public object Current => class7438_0[(string)ienumerator_0.Current];

			public Class7689(Class7438 scope)
			{
				class7438_0 = scope;
				ienumerator_0 = scope.vmethod_19().GetEnumerator();
			}

			public bool MoveNext()
			{
				return ienumerator_0.MoveNext();
			}

			public void Reset()
			{
				ienumerator_0.Reset();
			}
		}

		private Class7438 class7438_0;

		public IEnumerator GetEnumerator()
		{
			return new Class7689(class7438_0);
		}

		public Class7688(Class7438 scope)
		{
			class7438_0 = scope;
		}
	}

	private Class7352 class7352_0;

	private Class7352 class7352_1;

	private Class7438 class7438_0;

	private Class7398 class7398_1;

	public static string string_21 = "this";

	public static string string_22 = "arguments";

	public override string _Class => "Scope";

	public override string Type => "object";

	public Class7438 Global
	{
		get
		{
			if (class7438_0 == null)
			{
				return this;
			}
			return class7438_0;
		}
	}

	public override Class7397 this[string index]
	{
		get
		{
			if (index == string_21 && class7352_0 != null)
			{
				return class7352_0.vmethod_1(this);
			}
			if (index == string_22 && class7352_1 != null)
			{
				return class7352_1.vmethod_1(this);
			}
			return base[index];
		}
		set
		{
			if (index == string_21)
			{
				if (class7352_0 != null)
				{
					class7352_0.vmethod_2(this, value);
				}
				else
				{
					vmethod_18(class7352_0 = new Class7359(this, index, value));
				}
				return;
			}
			if (index == string_22)
			{
				if (class7352_1 != null)
				{
					class7352_1.vmethod_2(this, value);
				}
				else
				{
					vmethod_18(class7352_1 = new Class7359(this, index, value));
				}
				return;
			}
			Class7352 @class = vmethod_11(index);
			if (@class != null)
			{
				@class.vmethod_2(this, value);
			}
			else if (class7438_0 != null)
			{
				class7438_0.method_1(index, value);
			}
			else
			{
				method_1(index, value);
			}
		}
	}

	public override object Value
	{
		get
		{
			if (class7398_1 == null)
			{
				return null;
			}
			return class7398_1.Value;
		}
		set
		{
			if (class7398_1 != null)
			{
				class7398_1.Value = value;
			}
		}
	}

	public override Class7352 vmethod_11(string index)
	{
		Class7352 @class;
		if ((@class = base.vmethod_11(index)) != null && @class.Owner == this)
		{
			return @class;
		}
		Class7352 class2;
		if (class7398_1 != null && (class2 = class7398_1.vmethod_11(index)) != null)
		{
			Class7352 class3 = new Class7358(this, class2.Name, class2, class7398_1);
			vmethod_18(class3);
			return class3;
		}
		return @class;
	}

	public override IEnumerable vmethod_19()
	{
		return new Class7686(this);
	}

	private Class7352 method_4(string key)
	{
		return base.vmethod_11(key);
	}

	private IEnumerable method_5()
	{
		return base.vmethod_19();
	}

	public override IEnumerable vmethod_20()
	{
		return new Class7688(this);
	}

	public Class7438(Class7438 outer)
		: base(outer)
	{
		if (outer == null)
		{
			throw new ArgumentNullException("outer");
		}
		class7438_0 = outer.Global;
	}

	public Class7438(Class7438 outer, Class7398 bag)
		: base(outer)
	{
		if (outer == null)
		{
			throw new ArgumentNullException("outer");
		}
		if (bag == null)
		{
			throw new ArgumentNullException("bag");
		}
		class7438_0 = outer.Global;
		class7398_1 = bag;
	}

	public Class7438(Class7398 bag)
		: base(Class7433.class7433_0)
	{
		class7398_1 = bag;
	}
}
