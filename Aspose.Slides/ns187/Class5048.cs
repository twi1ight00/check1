using System;
using System.Drawing;
using ns171;
using ns175;
using ns176;
using ns195;

namespace ns187;

internal class Class5048 : Class5024, Interface181
{
	internal class Class5081 : Class5052
	{
		public Class5081(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			if (p is Class5048)
			{
				return p;
			}
			if (p is Class5042)
			{
				return Class5041.smethod_0(p);
			}
			object obj = p.vmethod_9();
			if (obj != null)
			{
				return smethod_0((double)obj);
			}
			return vmethod_12(p, propertyList, fo);
		}
	}

	internal class Class5084 : Class5052
	{
		public Class5084(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			if (p is Class5042)
			{
				return Class5041.smethod_0(p);
			}
			object obj = p.vmethod_9();
			if (obj != null)
			{
				int num = (int)Math.Round(Convert.ToSingle(obj));
				if (num <= 0)
				{
					num = 1;
				}
				return smethod_1(num);
			}
			return vmethod_12(p, propertyList, fo);
		}
	}

	private static Class5749 class5749_0 = new Class5749();

	private object object_0;

	private Class5048(double num)
	{
		if (num == Math.Floor(num))
		{
			if (num < 2147483647.0)
			{
				object_0 = (int)num;
			}
			else
			{
				object_0 = (long)num;
			}
		}
		else
		{
			object_0 = num;
		}
	}

	private Class5048(int num)
	{
		object_0 = num;
	}

	public static Class5048 smethod_0(double num)
	{
		return (Class5048)class5749_0.method_0(new Class5048(num));
	}

	public static Class5048 smethod_1(int num)
	{
		return (Class5048)class5749_0.method_0(new Class5048(num));
	}

	public int imethod_3()
	{
		return 0;
	}

	public double imethod_1()
	{
		return Convert.ToDouble(object_0);
	}

	public double imethod_2(Interface172 context)
	{
		return imethod_1();
	}

	public int imethod_5()
	{
		return (int)object_0;
	}

	public int imethod_6(Interface172 context)
	{
		return imethod_5();
	}

	public bool imethod_4()
	{
		return true;
	}

	public override object vmethod_9()
	{
		return object_0;
	}

	public override object vmethod_12()
	{
		return object_0;
	}

	public override Interface181 vmethod_10()
	{
		return this;
	}

	public override Interface182 vmethod_0()
	{
		return Class5036.smethod_1(imethod_1(), "px");
	}

	public override Color vmethod_1(Class5738 foUserAgent)
	{
		return Color.Black;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5048 @class))
		{
			return false;
		}
		return Class5721.smethod_0(object_0, @class.object_0);
	}

	public override int GetHashCode()
	{
		return object_0.GetHashCode();
	}
}
