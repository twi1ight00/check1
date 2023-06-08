using System;
using ns171;
using ns176;
using ns178;
using ns187;
using ns197;

namespace ns192;

internal abstract class Class5149 : Class5094
{
	internal class Class5059 : Class5052
	{
		public Class5059(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_7(Class5634 propertyList)
		{
			Class5094 @class = propertyList.method_0();
			return Class5048.smethod_1(((Interface233)@class.method_4()).imethod_3().method_0());
		}

		public override Class5024 vmethod_8(Class5634 propertyList, string value, Class5094 fo)
		{
			Class5024 @class = base.vmethod_8(propertyList, value, fo);
			int num = @class.vmethod_10().imethod_5();
			int num2 = propertyList.method_5(165).vmethod_10().imethod_5();
			int num3 = propertyList.method_0().vmethod_24();
			if (num3 == 76 || num3 == 75)
			{
				Interface233 @interface = (Interface233)propertyList.method_1();
				Class5714 class2 = @interface.imethod_3();
				int num4 = num - 1 + num2;
				for (int i = num; i <= num4; i++)
				{
					if (class2.method_3(i))
					{
						Interface245 interface2 = Class5754.smethod_0(fo.method_2().method_48());
						interface2.imethod_9(this, propertyList.method_0().method_17(), i, propertyList.method_0().method_1());
					}
				}
			}
			return @class;
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
				int num = (int)Math.Round((obj is float) ? ((float)obj) : ((float)(int)obj));
				int num2 = propertyList.method_0().vmethod_24();
				if (num <= 0)
				{
					if (num2 != 75 && num2 != 76)
					{
						num = 1;
					}
					else
					{
						Interface233 @interface = (Interface233)propertyList.method_1();
						Class5714 @class = @interface.imethod_3();
						num = @class.method_0();
					}
					Interface245 interface2 = Class5754.smethod_0(fo.method_2().method_48());
					interface2.imethod_10(this, propertyList.method_0().method_17(), obj, num, propertyList.method_0().method_1());
				}
				return Class5048.smethod_1(num);
			}
			return vmethod_12(p, propertyList, fo);
		}
	}

	private Interface181 interface181_0;

	private Interface181 interface181_1;

	private Interface181 interface181_2;

	private Interface181 interface181_3;

	internal Class5722 class5722_0;

	internal Class5722 class5722_1;

	internal Class5706 class5706_0;

	internal Class5706 class5706_1;

	internal Class5711 class5711_0;

	public Class5149(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		interface181_0 = pList.method_5(20).vmethod_10();
		interface181_1 = pList.method_5(24).vmethod_10();
		interface181_2 = pList.method_5(34).vmethod_10();
		interface181_3 = pList.method_5(48).vmethod_10();
		if (vmethod_24() != 71 && vmethod_24() != 75 && vmethod_33().method_22(Class5621.smethod_0()))
		{
			Interface245 @interface = Class5754.smethod_0(method_2().method_48());
			@interface.imethod_8(this, method_17(), method_1());
		}
	}

	public Interface181 method_48(int side)
	{
		return side switch
		{
			0 => interface181_1, 
			1 => interface181_0, 
			2 => interface181_3, 
			3 => interface181_2, 
			_ => null, 
		};
	}

	public virtual Class5156 vmethod_32()
	{
		return ((Class5149)class5088_0).vmethod_32();
	}

	public abstract Class5703 vmethod_33();

	public override void vmethod_6(string elementName, Interface243 locator, Interface236 attlist, Class5634 pList)
	{
		base.vmethod_6(elementName, locator, attlist, pList);
		Class5156 @class = vmethod_32();
		if (!vmethod_5() && !@class.method_72())
		{
			class5711_0 = Class5711.smethod_0(@class.method_71());
			method_49();
		}
	}

	protected void method_49()
	{
		method_50(2);
		method_50(3);
		method_50(0);
		method_50(1);
	}

	private void method_50(int side)
	{
		Class5706 borderSpecification = new Class5706(vmethod_33().method_2(side), vmethod_24());
		switch (side)
		{
		case 0:
			class5722_0 = new Class5722(borderSpecification, class5711_0);
			break;
		case 1:
			class5722_1 = new Class5722(borderSpecification, class5711_0);
			break;
		case 2:
			class5706_0 = borderSpecification;
			break;
		case 3:
			class5706_1 = borderSpecification;
			break;
		}
	}
}
