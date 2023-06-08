using System;
using System.IO;
using ns226;

namespace ns229;

internal abstract class Class6025
{
	internal abstract class Class6054
	{
		private Class6017 class6017_0;

		private Class6016 class6016_0;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		protected Class6054(int dataSize)
		{
			class6017_0 = Class6017.smethod_1(dataSize);
		}

		protected Class6054(Class6017 data)
		{
			class6017_0 = data;
		}

		protected Class6054(Class6016 data)
		{
			class6016_0 = data;
		}

		public Class6017 method_0()
		{
			Class6017 @class;
			if (bool_0)
			{
				if (!vmethod_3())
				{
					throw new Exception("Table not ready to build.");
				}
				int length = vmethod_4();
				@class = Class6017.smethod_1(length);
				vmethod_2(@class);
			}
			else
			{
				Class6016 class2 = method_6();
				@class = Class6017.smethod_1(class2?.method_2() ?? 0);
				class2?.CopyTo(@class);
			}
			return @class;
		}

		public void method_1(Class6017 data)
		{
			method_3(data, dataChanged: true);
		}

		public void method_2(Class6016 data)
		{
			method_4(data, dataChanged: true);
		}

		private void method_3(Class6017 data, bool dataChanged)
		{
			class6017_0 = data;
			class6016_0 = null;
			if (dataChanged)
			{
				bool_2 = true;
				vmethod_5();
			}
		}

		private void method_4(Class6016 data, bool dataChanged)
		{
			class6016_0 = data;
			class6017_0 = null;
			if (dataChanged)
			{
				bool_2 = true;
				vmethod_5();
			}
		}

		public virtual Class6025 vmethod_0()
		{
			Class6025 @class = null;
			Class6016 class2 = method_6();
			if (bool_0)
			{
				if (!vmethod_3())
				{
					return null;
				}
				int length = vmethod_4();
				Class6017 class3 = Class6017.smethod_1(length);
				vmethod_2(class3);
				class2 = class3;
			}
			if (class2 != null)
			{
				@class = vmethod_6(class2);
				vmethod_1(@class);
			}
			class6016_0 = null;
			class6017_0 = null;
			return @class;
		}

		public bool method_5()
		{
			return true;
		}

		protected Class6016 method_6()
		{
			if (class6016_0 != null)
			{
				return class6016_0;
			}
			return class6017_0;
		}

		protected Class6017 method_7()
		{
			if (class6017_0 == null)
			{
				Class6017 @class = Class6017.smethod_1((class6016_0 != null) ? class6016_0.method_2() : 0);
				if (class6016_0 != null)
				{
					class6016_0.CopyTo(@class);
				}
				method_3(@class, dataChanged: false);
			}
			return class6017_0;
		}

		public bool method_8()
		{
			if (!method_9())
			{
				return method_10();
			}
			return true;
		}

		protected bool method_9()
		{
			return bool_2;
		}

		protected bool method_10()
		{
			if (!method_11())
			{
				return method_12();
			}
			return true;
		}

		protected bool method_11()
		{
			return bool_0;
		}

		protected bool method_12()
		{
			return bool_1;
		}

		protected bool method_13()
		{
			return method_14(changed: true);
		}

		protected bool method_14(bool changed)
		{
			bool result = bool_0;
			bool_0 = changed;
			return result;
		}

		protected virtual void vmethod_1(Class6025 table)
		{
		}

		internal abstract int vmethod_2(Class6017 newData);

		internal abstract bool vmethod_3();

		internal abstract int vmethod_4();

		protected abstract void vmethod_5();

		protected abstract Class6025 vmethod_6(Class6016 data);
	}

	protected Class6016 class6016_0;

	public Class6025(Class6016 data)
	{
		class6016_0 = data;
	}

	public Class6016 method_0()
	{
		return class6016_0;
	}

	public string method_1()
	{
		return class6016_0.method_7();
	}

	public int method_2()
	{
		return class6016_0.method_2();
	}

	public int method_3(StreamWriter os)
	{
		return class6016_0.CopyTo(os);
	}

	protected int method_4(Class6017 data)
	{
		return class6016_0.CopyTo(data);
	}
}
