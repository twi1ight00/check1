using System;
using System.Collections;
using System.Text;
using ns196;
using ns205;

namespace ns173;

internal class Class4942 : Class4941
{
	public static int int_0 = 0;

	public static int int_1 = 1;

	public static int int_2 = 2;

	public static int int_3 = 3;

	public static int int_4 = 0;

	public static int int_5 = 1;

	public static int int_6 = 2;

	public static int int_7 = 3;

	public static int int_8 = 4;

	public static int int_9 = 5;

	public static int int_10 = int_9 + 1;

	private int int_11 = int_4;

	protected int int_12;

	protected int int_13;

	protected int int_14 = -1;

	protected Hashtable hashtable_1;

	private Class4942 class4942_0;

	private Class5282 class5282_0;

	public Class5282 FloatBodyManager
	{
		get
		{
			return class5282_0;
		}
		set
		{
			class5282_0 = value;
		}
	}

	public int method_9()
	{
		return int_11;
	}

	public override object vmethod_0(Class4941 ato)
	{
		Class4942 @class = (Class4942)base.vmethod_0(ato);
		if (hashtable_1 != null)
		{
			@class.hashtable_1 = (Hashtable)hashtable_1.Clone();
		}
		return @class;
	}

	public void method_10(int areaClasS)
	{
		int_11 = areaClasS;
	}

	public void method_11(int ipD)
	{
		int_12 = ipD;
	}

	public int method_12()
	{
		return int_12;
	}

	public void method_13(int bpd)
	{
		int_13 = bpd;
	}

	public virtual int vmethod_1()
	{
		return int_13;
	}

	public int method_14()
	{
		return method_21() + method_12() + method_22();
	}

	public int method_15()
	{
		return method_23() + method_19() + vmethod_1() + method_20() + method_24();
	}

	public void method_16(int bidiLevel)
	{
		int_14 = bidiLevel;
	}

	public void method_17()
	{
		method_16(-1);
	}

	public int method_18()
	{
		return int_14;
	}

	public int method_19()
	{
		int num = 0;
		Class5705 @class = (Class5705)method_33(Class5757.int_12);
		if (@class != null)
		{
			num = @class.int_4;
		}
		object obj = method_33(Class5757.int_16);
		if (obj != null)
		{
			num += (int)obj;
		}
		return num;
	}

	public int method_20()
	{
		int num = 0;
		Class5705 @class = (Class5705)method_33(Class5757.int_13);
		if (@class != null)
		{
			num = @class.int_4;
		}
		object obj = method_33(Class5757.int_17);
		if (obj != null)
		{
			num += (int)obj;
		}
		return num;
	}

	public int method_21()
	{
		int num = 0;
		Class5705 @class = (Class5705)method_33(Class5757.int_10);
		if (@class != null)
		{
			num = @class.int_4;
		}
		object obj = method_33(Class5757.int_14);
		if (obj != null)
		{
			num += (int)obj;
		}
		return num;
	}

	public int method_22()
	{
		int num = 0;
		Class5705 @class = (Class5705)method_33(Class5757.int_11);
		if (@class != null)
		{
			num = @class.int_4;
		}
		object obj = method_33(Class5757.int_15);
		if (obj != null)
		{
			num += (int)obj;
		}
		return num;
	}

	public int method_23()
	{
		int result = 0;
		object obj = method_33(Class5757.int_22);
		if (obj != null)
		{
			result = (int)obj;
		}
		return result;
	}

	public int method_24()
	{
		int result = 0;
		object obj = method_33(Class5757.int_23);
		if (obj != null)
		{
			result = (int)obj;
		}
		return result;
	}

	public int method_25()
	{
		int result = 0;
		object obj = method_33(Class5757.int_18);
		if (obj != null)
		{
			result = (int)obj;
		}
		return result;
	}

	public int method_26()
	{
		int result = 0;
		object obj = method_33(Class5757.int_19);
		if (obj != null)
		{
			result = (int)obj;
		}
		return result;
	}

	public int method_27()
	{
		int result = 0;
		if (method_33(Class5757.int_38) is Class5442 @class)
		{
			result = @class.method_1();
		}
		return result;
	}

	public virtual void vmethod_2(Class4942 child)
	{
	}

	public virtual void vmethod_3(Class4942 parentArea)
	{
		class4942_0 = parentArea;
	}

	public Class4942 method_28()
	{
		return class4942_0;
	}

	public void method_29(int traitCode, object prop)
	{
		if (hashtable_1 == null)
		{
			hashtable_1 = new Hashtable();
		}
		hashtable_1[traitCode] = prop;
	}

	public void method_30(Hashtable traits)
	{
		if (traits != null)
		{
			hashtable_1 = new Hashtable(traits);
		}
		else
		{
			hashtable_1 = null;
		}
	}

	public Hashtable method_31()
	{
		return hashtable_1;
	}

	public bool method_32()
	{
		return hashtable_1 != null;
	}

	public object method_33(int traitCode)
	{
		if (hashtable_1 == null)
		{
			return null;
		}
		return hashtable_1[traitCode];
	}

	public bool method_34(int traitCode)
	{
		return method_33(traitCode) != null;
	}

	public bool method_35(int traitCode)
	{
		object obj = method_33(traitCode);
		if (obj is bool && (bool)obj)
		{
			return true;
		}
		return false;
	}

	public int method_36(int traitCode)
	{
		object obj = method_33(traitCode);
		if (obj == null)
		{
			return 0;
		}
		if (!(obj is int))
		{
			throw new ArgumentException("Trait " + traitCode.GetType().Name + " could not be converted to an int");
		}
		return (int)obj;
	}

	public virtual void vmethod_4(Interface231 wmtg)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(base.ToString());
		stringBuilder.Append(" {ipd=").Append(method_12());
		stringBuilder.Append(", bpd=").Append(vmethod_1());
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}
}
