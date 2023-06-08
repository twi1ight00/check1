using System;
using System.Collections;
using System.Drawing;
using ns171;
using ns176;
using ns187;
using ns190;
using ns196;
using ns205;

namespace ns173;

internal class Class4973 : Class4941
{
	private Class4971 class4971_0;

	private Class4971 class4971_1;

	private Class4971 class4971_2;

	private Class4971 class4971_3;

	private Class4971 class4971_4;

	private Hashtable hashtable_1;

	private bool bool_0;

	public Class4973()
	{
	}

	public Class4973(Class5171 spm)
	{
		Class5728 @class = new Class5728(spm.method_56().imethod_5(), spm.method_57().imethod_5());
		Class5718 class2 = spm.method_54();
		Class5753 context = new Class5753(null, 5, @class.int_0);
		Class5753 context2 = new Class5753(null, 5, @class.int_1);
		RectangleF absVPrect = new RectangleF(class2.interface182_2.imethod_6(context), class2.interface182_0.imethod_6(context2), @class.int_0 - class2.interface182_2.imethod_6(context) - class2.interface182_3.imethod_6(context), @class.int_1 - class2.interface182_0.imethod_6(context2) - class2.interface182_1.imethod_6(context2));
		Class5728 reldims = new Class5728(0, 0);
		Class5492 pageCTM = Class5492.smethod_1(spm.method_58(), spm.method_59(), absVPrect, reldims);
		foreach (Class5135 value in spm.method_52().Values)
		{
			Class4971 class4 = smethod_0(value, reldims, pageCTM);
			Class4964 class5 = ((value.vmethod_24() != 58) ? new Class4964(value, class4) : new Class4965((Class5143)value, class4));
			Class5677.smethod_3(class5, value.method_52(), discardBefore: false, discardAfter: false, discardStart: false, discardEnd: false, null);
			Class5677.smethod_7(class5, value.method_52(), discardBefore: false, discardAfter: false, discardStart: false, discardEnd: false, null);
			smethod_1(class5, value, class4.method_40());
			class4.method_37(class5);
			method_10(value.vmethod_24(), class4);
		}
	}

	public void method_9()
	{
		bool_0 = true;
	}

	private static Class4971 smethod_0(Class5135 r, Class5728 reldims, Class5492 pageCTM)
	{
		RectangleF inRect = r.vmethod_32(reldims);
		RectangleF viewArea = pageCTM.method_4(inRect);
		Class4971 @class;
		try
		{
			@class = new Class4971(viewArea);
		}
		catch (Exception)
		{
			throw;
		}
		@class.method_13((int)inRect.Height);
		@class.method_11((int)inRect.Width);
		Class5677.smethod_11(@class, r.method_52(), null);
		@class.method_39(r.method_54() == 57 || r.method_54() == 42);
		return @class;
	}

	private static void smethod_1(Class4964 rr, Class5135 r, RectangleF absRegVPRect)
	{
		Class5728 @class = new Class5728(0, 0);
		rr.method_37(Class5492.smethod_1(r.method_56(), r.method_57(), absRegVPRect, @class));
		rr.method_11(@class.int_0 - rr.method_21() - rr.method_22());
		rr.method_13(@class.int_1 - rr.method_19() - rr.method_20());
	}

	public void method_10(int areaclass, Class4971 port)
	{
		switch (areaclass)
		{
		case 57:
			class4971_0 = port;
			break;
		case 61:
			class4971_1 = port;
			break;
		case 58:
			class4971_2 = port;
			break;
		case 59:
			class4971_3 = port;
			break;
		case 56:
			class4971_4 = port;
			break;
		}
	}

	public Class4971 method_11(int areaClass)
	{
		return (Enum679)areaClass switch
		{
			Enum679.const_57 => class4971_4, 
			Enum679.const_58 => class4971_0, 
			Enum679.const_59 => class4971_2, 
			Enum679.const_60 => class4971_3, 
			Enum679.const_62 => class4971_1, 
			_ => throw new ArgumentException("No such area class with ID = " + areaClass), 
		};
	}

	public bool method_12()
	{
		if (bool_0)
		{
			return false;
		}
		if (class4971_2 == null)
		{
			return true;
		}
		Class4965 @class = (Class4965)class4971_2.method_38();
		return @class.method_48();
	}

	public object method_13()
	{
		Class4973 @class = (Class4973)base.vmethod_0(new Class4973());
		if (class4971_0 != null)
		{
			@class.class4971_0 = (Class4971)class4971_0.method_42();
		}
		if (class4971_1 != null)
		{
			@class.class4971_1 = (Class4971)class4971_1.method_42();
		}
		if (class4971_2 != null)
		{
			@class.class4971_2 = (Class4971)class4971_2.method_42();
		}
		if (class4971_3 != null)
		{
			@class.class4971_3 = (Class4971)class4971_3.method_42();
		}
		if (class4971_4 != null)
		{
			@class.class4971_4 = (Class4971)class4971_4.method_42();
		}
		return @class;
	}

	public void method_14(Hashtable unres)
	{
		hashtable_1 = unres;
	}

	public Hashtable method_15()
	{
		return hashtable_1;
	}

	public void method_16(Interface231 wmtg)
	{
		if (class4971_0 != null)
		{
			class4971_0.vmethod_4(wmtg);
		}
		if (class4971_1 != null)
		{
			class4971_1.vmethod_4(wmtg);
		}
		if (class4971_2 != null)
		{
			class4971_2.vmethod_4(wmtg);
		}
		if (class4971_3 != null)
		{
			class4971_3.vmethod_4(wmtg);
		}
		if (class4971_4 != null)
		{
			class4971_4.vmethod_4(wmtg);
		}
	}
}
