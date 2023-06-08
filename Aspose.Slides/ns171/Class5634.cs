using ns175;
using ns178;
using ns183;
using ns186;
using ns187;
using ns195;

namespace ns171;

internal abstract class Class5634
{
	private static bool[] bool_0;

	protected Class5634 class5634_0;

	private Class5094 class5094_0;

	public Class5634(Class5094 fObjToAttach, Class5634 parentPropertyList)
	{
		class5094_0 = fObjToAttach;
		class5634_0 = parentPropertyList;
	}

	public Class5094 method_0()
	{
		return class5094_0;
	}

	public Class5094 method_1()
	{
		if (class5634_0 != null)
		{
			return class5634_0.method_0();
		}
		return null;
	}

	public Class5634 method_2()
	{
		return class5634_0;
	}

	public Class5024 method_3(int propId)
	{
		Class5024 @class = vmethod_0(propId);
		if (@class == null)
		{
			@class = method_15(propId);
		}
		return @class;
	}

	public abstract Class5024 vmethod_0(int propId);

	public abstract void vmethod_1(int propId, Class5024 value);

	public Class5024 method_4(int propId)
	{
		if (smethod_2(propId))
		{
			return method_8(propId);
		}
		return method_16(propId);
	}

	public Class5024 method_5(int propId)
	{
		return vmethod_2(propId, bTryInherit: true, bTryDefault: true);
	}

	public Class5024 method_6(Enum679 propId)
	{
		return vmethod_2((int)propId, bTryInherit: true, bTryDefault: true);
	}

	public virtual Class5024 vmethod_2(int propId, bool bTryInherit, bool bTryDefault)
	{
		return smethod_3(propId & 0x1FF)?.vmethod_4(propId & -512, this, bTryInherit, bTryDefault);
	}

	public Class5024 method_7(int propId)
	{
		Class5024 @class = null;
		Class5634 class2 = class5634_0;
		while (true)
		{
			if (class2 != null)
			{
				@class = class2.vmethod_0(propId);
				if (@class != null)
				{
					break;
				}
				class2 = class2.class5634_0;
				continue;
			}
			return method_16(propId);
		}
		return @class;
	}

	public Class5024 method_8(int propId)
	{
		if (class5634_0 != null)
		{
			return class5634_0.method_5(propId);
		}
		return method_16(propId);
	}

	public int method_9(int lrtb, int rltb, int tbrl, int tblr)
	{
		try
		{
			return (Enum679)method_5(267).imethod_0() switch
			{
				Enum679.const_208 => rltb, 
				Enum679.const_80 => lrtb, 
				Enum679.const_292 => tblr, 
				Enum679.const_227 => tbrl, 
				_ => -1, 
			};
		}
		catch (Exception55)
		{
			return -1;
		}
	}

	private string method_10(Interface236 attributes, string attributeName)
	{
		string text = attributes.imethod_5(attributeName);
		if (text != null)
		{
			method_12(attributes, attributeName, text);
		}
		return text;
	}

	public virtual void vmethod_3(Interface236 attributes)
	{
		method_10(attributes, "writing-mode");
		method_10(attributes, "column-number");
		method_10(attributes, "number-columns-spanned");
		string value = method_10(attributes, "font");
		if (string.IsNullOrEmpty(value))
		{
			method_10(attributes, "font-size");
		}
		Class5734 @class = method_0().method_2().method_0();
		for (int i = 0; i < attributes.imethod_0(); i++)
		{
			string text = attributes.imethod_3(i);
			string text2 = attributes.imethod_1(i);
			string text3 = attributes.imethod_4(i);
			if (text != null && text.Length != 0 && !"xml:lang".Equals(text2) && !"xml:base".Equals(text2))
			{
				if (@class.method_46(text))
				{
					continue;
				}
				Class5180 class2 = @class.method_13().method_3(text);
				Class5619 class3 = new Class5619(text, text2);
				if (class2 != null)
				{
					if (class2.vmethod_1(class3) && class2.vmethod_0() != null)
					{
						method_12(attributes, class2.vmethod_0() + ":" + class3.method_2(), text3);
					}
					else
					{
						method_0().method_46(class3, text3);
					}
				}
				else
				{
					method_14(class3);
				}
			}
			else
			{
				method_12(attributes, text2, text3);
			}
		}
	}

	protected bool method_11(string propertyName)
	{
		int num = Class5735.smethod_3(smethod_0(propertyName));
		int num2 = Class5735.smethod_4(smethod_1(propertyName));
		if (num != -1)
		{
			if (num2 == -1)
			{
				return smethod_1(propertyName) == null;
			}
			return true;
		}
		return false;
	}

	private void method_12(Interface236 attributes, string attributeName, string attributeValue)
	{
		if (attributeName.StartsWith("xmlns:") || "xmlns".Equals(attributeName) || attributeValue == null)
		{
			return;
		}
		string text = smethod_0(attributeName);
		string text2 = smethod_1(attributeName);
		int num = Class5735.smethod_3(text);
		int num2 = Class5735.smethod_4(text2);
		if (num == -1 || (num2 == -1 && text2 != null))
		{
			method_14(new Class5619(null, attributeName));
		}
		Class5094 @class = class5094_0.method_27();
		Class5052 class2 = smethod_3(num);
		if (class2 == null)
		{
			return;
		}
		try
		{
			Class5024 class3 = null;
			if (text2 == null)
			{
				if (vmethod_0(num) != null)
				{
					return;
				}
				class3 = class2.vmethod_8(this, attributeValue, @class);
			}
			else
			{
				Class5024 baseProperty = method_13(attributes, @class, num, text, class2);
				class3 = class2.vmethod_9(baseProperty, num2, this, attributeValue, @class);
			}
			if (class3 != null)
			{
				vmethod_1(num, class3);
			}
		}
		catch (Exception55 e)
		{
			class5094_0.method_5().imethod_12(this, class5094_0.method_17(), attributeName, attributeValue, e, class5094_0.interface243_0);
		}
	}

	private Class5024 method_13(Interface236 attributes, Class5094 parentFO, int propId, string basePropertyName, Class5052 propertyMaker)
	{
		Class5024 @class = vmethod_0(propId);
		if (@class != null)
		{
			return @class;
		}
		string text = attributes.imethod_5(basePropertyName);
		if (text != null && propertyMaker != null)
		{
			return propertyMaker.vmethod_8(this, text, parentFO);
		}
		return null;
	}

	protected void method_14(Class5619 attr)
	{
		if (!attr.method_3().StartsWith("xmlns"))
		{
			class5094_0.method_5().imethod_11(this, class5094_0.method_17(), attr, canRecover: true, class5094_0.interface243_0);
		}
	}

	protected static string smethod_0(string attributeName)
	{
		int num = attributeName.IndexOf('.');
		string result = attributeName;
		if (num > -1)
		{
			result = Class5479.smethod_0(attributeName, 0, num);
		}
		return result;
	}

	protected static string smethod_1(string attributeName)
	{
		int num = attributeName.IndexOf('.');
		string result = null;
		if (num > -1)
		{
			result = attributeName.Substring(num + 1);
		}
		return result;
	}

	private Class5024 method_15(int propId)
	{
		return smethod_3(propId)?.method_16(this);
	}

	private Class5024 method_16(int propId)
	{
		return smethod_3(propId)?.vmethod_7(this);
	}

	private static bool smethod_2(int propId)
	{
		if (bool_0 == null)
		{
			bool_0 = new bool[300];
			Class5052 @class = null;
			for (int i = 1; i <= 299; i++)
			{
				@class = smethod_3(i);
				bool_0[i] = @class?.method_12() ?? false;
			}
		}
		return bool_0[propId];
	}

	private static Class5052 smethod_3(int propId)
	{
		if (propId >= 1 && propId <= 299)
		{
			return Class5094.smethod_9(propId);
		}
		return null;
	}

	public Class5703 method_17()
	{
		return Class5703.smethod_1(this);
	}

	public Class5087 method_18()
	{
		return Class5087.smethod_0(this);
	}

	public Class5717 method_19()
	{
		return Class5717.smethod_0(this);
	}

	public Class5718 method_20()
	{
		return new Class5718(this);
	}

	public Class5719 method_21()
	{
		return new Class5719(this);
	}

	public Class5382 method_22()
	{
		return new Class5382(this);
	}

	public Class5679 method_23()
	{
		return new Class5679(this);
	}

	public Class5673 method_24()
	{
		return new Class5673(this);
	}

	public Class5716 method_25()
	{
		return Class5716.smethod_0(this);
	}

	public Class5720 method_26()
	{
		return Class5720.smethod_0(this);
	}

	public Class5025 method_27()
	{
		return Class5025.smethod_0(this);
	}
}
