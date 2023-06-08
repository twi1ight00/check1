using System;
using System.Collections;
using System.Text;

namespace ns82;

internal class Class7332 : ICloneable
{
	protected internal const int int_0 = 64;

	protected internal const int int_1 = 6;

	protected internal static readonly int int_2 = 63;

	protected internal ulong[] ulong_0;

	public virtual bool Nil
	{
		get
		{
			int num = ulong_0.Length - 1;
			while (true)
			{
				if (num >= 0)
				{
					if (ulong_0[num] != 0L)
					{
						break;
					}
					num--;
					continue;
				}
				return true;
			}
			return false;
		}
	}

	public Class7332()
		: this(64)
	{
	}

	public Class7332(ulong[] bits_)
	{
		ulong_0 = bits_;
	}

	public Class7332(IList items)
		: this(64)
	{
		for (int i = 0; i < items.Count; i++)
		{
			int el = (int)items[i];
			Add(el);
		}
	}

	public Class7332(int nbits)
	{
		ulong_0 = new ulong[(nbits - 1 >> 6) + 1];
	}

	public static Class7332 smethod_0(int el)
	{
		Class7332 @class = new Class7332(el + 1);
		@class.Add(el);
		return @class;
	}

	public static Class7332 smethod_1(int a, int b)
	{
		Class7332 @class = new Class7332(Math.Max(a, b) + 1);
		@class.Add(a);
		@class.Add(b);
		return @class;
	}

	public static Class7332 smethod_2(int a, int b, int c)
	{
		Class7332 @class = new Class7332();
		@class.Add(a);
		@class.Add(b);
		@class.Add(c);
		return @class;
	}

	public static Class7332 smethod_3(int a, int b, int c, int d)
	{
		Class7332 @class = new Class7332();
		@class.Add(a);
		@class.Add(b);
		@class.Add(c);
		@class.Add(d);
		return @class;
	}

	public virtual Class7332 vmethod_0(Class7332 a)
	{
		if (a == null)
		{
			return this;
		}
		Class7332 @class = (Class7332)Clone();
		@class.vmethod_2(a);
		return @class;
	}

	public virtual void Add(int el)
	{
		int num = smethod_4(el);
		if (num >= ulong_0.Length)
		{
			vmethod_1(el);
		}
		ulong_0[num] |= smethod_5(el);
	}

	public virtual void vmethod_1(int bit)
	{
		int num = Math.Max(ulong_0.Length << 1, smethod_6(bit));
		ulong[] destinationArray = new ulong[num];
		Array.Copy(ulong_0, 0, destinationArray, 0, ulong_0.Length);
		ulong_0 = destinationArray;
	}

	public virtual void vmethod_2(Class7332 a)
	{
		if (a != null)
		{
			if (a.ulong_0.Length > ulong_0.Length)
			{
				method_0(a.ulong_0.Length);
			}
			int num = Math.Min(ulong_0.Length, a.ulong_0.Length);
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				ulong_0[num2] |= a.ulong_0[num2];
			}
		}
	}

	public virtual object Clone()
	{
		try
		{
			Class7332 @class = (Class7332)MemberwiseClone();
			@class.ulong_0 = new ulong[ulong_0.Length];
			Array.Copy(ulong_0, 0, @class.ulong_0, 0, ulong_0.Length);
			return @class;
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException("Unable to clone BitSet", innerException);
		}
	}

	public virtual int vmethod_3()
	{
		int num = 0;
		for (int num2 = ulong_0.Length - 1; num2 >= 0; num2--)
		{
			ulong num3 = ulong_0[num2];
			if (num3 != 0L)
			{
				for (int num4 = 63; num4 >= 0; num4--)
				{
					if ((num3 & (ulong)(1L << num4)) != 0L)
					{
						num++;
					}
				}
			}
		}
		return num;
	}

	public virtual bool vmethod_4(int el)
	{
		if (el < 0)
		{
			return false;
		}
		int num = smethod_4(el);
		if (num >= ulong_0.Length)
		{
			return false;
		}
		return (ulong_0[num] & smethod_5(el)) != 0L;
	}

	public virtual void Remove(int el)
	{
		int num = smethod_4(el);
		if (num < ulong_0.Length)
		{
			ulong_0[num] &= ~smethod_5(el);
		}
	}

	public virtual int vmethod_5()
	{
		return ulong_0.Length << 6;
	}

	public virtual int vmethod_6()
	{
		return ulong_0.Length;
	}

	public virtual int[] ToArray()
	{
		int[] array = new int[vmethod_3()];
		int num = 0;
		for (int i = 0; i < ulong_0.Length << 6; i++)
		{
			if (vmethod_4(i))
			{
				array[num++] = i;
			}
		}
		return array;
	}

	public virtual ulong[] vmethod_7()
	{
		return ulong_0;
	}

	private static int smethod_4(int bit)
	{
		return bit >> 6;
	}

	public override string ToString()
	{
		return ToString(null);
	}

	public virtual string ToString(string[] tokenNames)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string value = ",";
		bool flag = false;
		stringBuilder.Append('{');
		for (int i = 0; i < ulong_0.Length << 6; i++)
		{
			if (vmethod_4(i))
			{
				if (i > 0 && flag)
				{
					stringBuilder.Append(value);
				}
				if (tokenNames != null)
				{
					stringBuilder.Append(tokenNames[i]);
				}
				else
				{
					stringBuilder.Append(i);
				}
				flag = true;
			}
		}
		stringBuilder.Append('}');
		return stringBuilder.ToString();
	}

	public override bool Equals(object other)
	{
		Class7332 @class = other as Class7332;
		if (other != null && @class != null)
		{
			int num = Math.Min(ulong_0.Length, @class.ulong_0.Length);
			int num2 = 0;
			while (true)
			{
				if (num2 < num)
				{
					if (ulong_0[num2] != @class.ulong_0[num2])
					{
						break;
					}
					num2++;
					continue;
				}
				if (ulong_0.Length > num)
				{
					for (int i = num + 1; i < ulong_0.Length; i++)
					{
						if (ulong_0[i] != 0L)
						{
							return false;
						}
					}
				}
				else if (@class.ulong_0.Length > num)
				{
					for (int j = num + 1; j < @class.ulong_0.Length; j++)
					{
						if (@class.ulong_0[j] != 0L)
						{
							return false;
						}
					}
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	private static ulong smethod_5(int bitNumber)
	{
		int num = bitNumber & int_2;
		return (ulong)(1L << num);
	}

	private void method_0(int nwords)
	{
		ulong[] destinationArray = new ulong[nwords];
		int length = Math.Min(nwords, ulong_0.Length);
		Array.Copy(ulong_0, 0, destinationArray, 0, length);
		ulong_0 = destinationArray;
	}

	private static int smethod_6(int el)
	{
		return (el >> 6) + 1;
	}
}
