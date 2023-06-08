using System;
using System.Collections;
using ns171;
using ns176;
using ns186;

namespace ns187;

internal class Class5052
{
	internal int int_0;

	private bool bool_0 = true;

	private Hashtable hashtable_0;

	private Hashtable hashtable_1;

	protected string string_0;

	protected bool bool_1;

	internal bool bool_2;

	private int int_1 = -1;

	private Class5052[] class5052_0;

	private Interface179 interface179_0;

	protected Class5024 class5024_0;

	protected Class5723 class5723_0;

	public int method_0()
	{
		return int_0;
	}

	public Class5052(int propId)
	{
		int_0 = propId;
	}

	public virtual void vmethod_0(Class5052 generic)
	{
		bool_1 = generic.bool_1;
		bool_0 = generic.bool_0;
		string_0 = generic.string_0;
		int_1 = generic.int_1;
		if (generic.class5052_0 != null)
		{
			class5052_0 = new Class5052[generic.class5052_0.Length];
			Array.Copy(generic.class5052_0, 0, class5052_0, 0, class5052_0.Length);
		}
		if (generic.hashtable_0 != null)
		{
			hashtable_0 = new Hashtable(generic.hashtable_0);
		}
		if (generic.hashtable_1 != null)
		{
			hashtable_1 = new Hashtable(generic.hashtable_1);
		}
	}

	public void method_1(bool inheriteD)
	{
		bool_0 = inheriteD;
	}

	public void method_2(string keyword, string value)
	{
		if (hashtable_1 == null)
		{
			hashtable_1 = new Hashtable();
		}
		hashtable_1[keyword] = value;
	}

	public void method_3(string constant, Class5024 value)
	{
		if (hashtable_0 == null)
		{
			hashtable_0 = new Hashtable();
		}
		hashtable_0[constant] = value;
	}

	public virtual void vmethod_1(Class5052 subproperty)
	{
		throw new Exception("Unable to add subproperties " + GetType().Name);
	}

	public virtual Class5052 vmethod_2(int subpropertyId)
	{
		throw new Exception("Unable to add subproperties");
	}

	public void method_4(Class5052 shorthand)
	{
		if (class5052_0 == null)
		{
			class5052_0 = new Class5052[3];
		}
		int num = 0;
		while (true)
		{
			if (num < class5052_0.Length)
			{
				if (class5052_0[num] == null)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		class5052_0[num] = shorthand;
	}

	public void method_5(Interface179 parser)
	{
		interface179_0 = parser;
	}

	public void method_6(string defaultValue)
	{
		string_0 = defaultValue;
	}

	public void method_7(string defaultValue, bool contextDep)
	{
		string_0 = defaultValue;
		bool_1 = contextDep;
	}

	public void method_8(int percentBase)
	{
		int_1 = percentBase;
	}

	public void method_9(bool setByShorthand)
	{
		bool_2 = setByShorthand;
	}

	public void method_10(Class5723 corresponding)
	{
		class5723_0 = corresponding;
	}

	public virtual Class5024 vmethod_3()
	{
		return null;
	}

	public Class5024 method_11(Class5634 propertyList, bool tryInherit)
	{
		Class5024 @class = null;
		if (class5723_0 != null && class5723_0.vmethod_0(propertyList))
		{
			@class = class5723_0.vmethod_1(propertyList);
		}
		else
		{
			@class = propertyList.vmethod_0(int_0);
			if (@class == null)
			{
				@class = method_16(propertyList);
			}
			if (@class == null)
			{
				@class = vmethod_13(propertyList);
			}
		}
		if (@class == null && tryInherit)
		{
			Class5634 class2 = propertyList.method_2();
			if (class2 != null && method_12())
			{
				@class = class2.vmethod_2(int_0, bTryInherit: true, bTryDefault: false);
			}
		}
		return @class;
	}

	public virtual Class5024 vmethod_4(int subpropertyId, Class5634 propertyList, bool tryInherit, bool tryDefault)
	{
		Class5024 @class = method_11(propertyList, tryInherit);
		if (@class == null && tryDefault)
		{
			@class = vmethod_7(propertyList);
		}
		return @class;
	}

	public bool method_12()
	{
		return bool_0;
	}

	public virtual Interface180 vmethod_5(Class5634 pl)
	{
		if (int_1 == -1)
		{
			return null;
		}
		return new Class5743(pl, int_1);
	}

	public Class5024 method_13(Class5024 p, int subpropertyId)
	{
		Interface237 @interface = (Interface237)p.vmethod_12();
		return @interface.imethod_2(subpropertyId);
	}

	internal virtual Class5024 vmethod_6(Class5024 baseProperty, int subpropertyId, Class5024 subproperty)
	{
		Interface237 @interface = (Interface237)baseProperty.vmethod_12();
		@interface.imethod_1(subpropertyId, subproperty, bIsDefault: false);
		return baseProperty;
	}

	public virtual Class5024 vmethod_7(Class5634 propertyList)
	{
		if (class5024_0 != null)
		{
			return class5024_0;
		}
		Class5024 result = vmethod_8(propertyList, string_0, propertyList.method_1());
		if (!bool_1)
		{
			class5024_0 = result;
		}
		return result;
	}

	public virtual Class5024 vmethod_8(Class5634 propertyList, string value, Class5094 fo)
	{
		try
		{
			Class5024 @class = null;
			string text = value;
			if ("inherit".Equals(value))
			{
				@class = propertyList.method_8(int_0 & 0x1FF);
				if (((uint)int_0 & 0xFFFFFE00u) != 0)
				{
					@class = method_13(@class, int_0 & -512);
				}
			}
			else
			{
				text = method_15(text.Trim());
				@class = vmethod_10(text);
			}
			if (@class == null)
			{
				@class = Class5388.smethod_5(text, new Class5750(this, propertyList));
			}
			if (@class != null)
			{
				@class = vmethod_11(@class, propertyList, fo);
			}
			if (@class == null)
			{
				throw new Exception55("No conversion defined " + text);
			}
			return @class;
		}
		catch (Exception55 exception)
		{
			if (fo != null)
			{
				exception.method_0(fo.method_1());
			}
			exception.method_6(method_17());
			throw exception;
		}
	}

	public virtual Class5024 vmethod_9(Class5024 baseProperty, int subpropertyId, Class5634 propertyList, string value, Class5094 fo)
	{
		return baseProperty;
	}

	public Class5024 method_14(Class5634 propertyList, Class5024 prop, Class5094 fo)
	{
		Class5024 @class = vmethod_11(prop, propertyList, fo);
		if (@class == null)
		{
			string text = prop.vmethod_11();
			if (text != null)
			{
				@class = vmethod_10(text);
				if (@class == null)
				{
					string text2 = method_15(text);
					if (!text2.Equals(text))
					{
						Class5024 p = Class5388.smethod_5(text2, new Class5750(this, propertyList));
						@class = vmethod_11(p, propertyList, fo);
					}
				}
			}
		}
		return @class;
	}

	internal virtual Class5024 vmethod_10(string value)
	{
		if (hashtable_0 != null)
		{
			return (Class5024)hashtable_0[value];
		}
		return null;
	}

	internal string method_15(string keyword)
	{
		if (hashtable_1 != null)
		{
			string text = (string)hashtable_1[keyword];
			if (text != null)
			{
				return text;
			}
		}
		return keyword;
	}

	public virtual Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
	{
		return null;
	}

	protected virtual Class5024 vmethod_12(Class5024 p, Class5634 propertyList, Class5094 fo)
	{
		return null;
	}

	protected virtual Class5024 vmethod_13(Class5634 propertyList)
	{
		if (class5723_0 != null)
		{
			return class5723_0.vmethod_1(propertyList);
		}
		return null;
	}

	public Class5024 method_16(Class5634 propertyList)
	{
		if (class5052_0 == null)
		{
			return null;
		}
		int num = class5052_0.Length;
		for (int i = 0; i < num && class5052_0[i] != null; i++)
		{
			Class5052 @class = class5052_0[i];
			Class5024 class2 = propertyList.vmethod_0(@class.int_0);
			if (class2 != null)
			{
				Interface179 @interface = @class.interface179_0;
				Class5024 class3 = @interface.imethod_0(method_0(), class2, this, propertyList);
				if (class3 != null)
				{
					return class3;
				}
			}
		}
		return null;
	}

	public string method_17()
	{
		return Class5735.smethod_5(int_0);
	}

	public object method_18()
	{
		return MemberwiseClone();
	}
}
