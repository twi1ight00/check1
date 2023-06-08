using System;
using System.Collections;
using ns171;
using ns173;
using ns190;
using ns198;

namespace ns196;

internal class Class5295 : Class5281
{
	private class Class5273 : Class5268
	{
		private class Class5614 : Class5395.Interface183
		{
			private Class5273 class5273_0;

			internal Class5614(Class5273 owner)
			{
				class5273_0 = owner;
			}

			public void imethod_0(int part, int amount, Class5094 obj)
			{
				if (class5273_0.int_4 == 0)
				{
					class5273_0.int_4 = amount;
				}
			}
		}

		private Class5295 class5295_0;

		private int int_2;

		private int int_3;

		private int int_4;

		public Class5273(Class5295 lm, int ipd, int displayAlign)
		{
			class5295_0 = lm;
			int_3 = ipd;
			int_2 = displayAlign;
		}

		protected override void vmethod_16(ArrayList elementList)
		{
			string text = class5295_0.method_54().method_48();
			string text2 = ((Class5127)class5295_0.imethod_2().imethod_21()).vmethod_31();
			if (text2 != null && text2.Length > 0)
			{
				text = text + "-" + text2;
			}
			Class5651.smethod_2(elementList, "static-content", text);
		}

		protected override bool vmethod_5()
		{
			return false;
		}

		public bool method_7()
		{
			return int_4 != 0;
		}

		public int method_8()
		{
			return int_4;
		}

		protected override Class5395.Interface183 vmethod_8()
		{
			return new Class5614(this);
		}

		protected override Interface173 vmethod_3()
		{
			return class5295_0;
		}

		protected override Class5687 vmethod_14()
		{
			Class5687 @class = base.vmethod_14();
			@class.method_30(int_3);
			return @class;
		}

		protected override ArrayList vmethod_9(Class5687 context, int alignment)
		{
			ArrayList arrayList = new ArrayList();
			Interface173 @interface;
			while ((@interface = class5295_0.method_9()) != null)
			{
				Class5687 @class = new Class5687(0);
				@class.method_28(context.method_29());
				@class.method_30(context.method_31());
				@class.method_52(context.method_51());
				ArrayList arrayList2 = null;
				bool flag = @interface is Class5313;
				if (!@interface.imethod_5())
				{
					arrayList2 = @interface.imethod_14(@class, alignment);
				}
				if (arrayList2 != null && !flag)
				{
					class5295_0.method_50(arrayList2, arrayList);
				}
			}
			Class5644.smethod_6(arrayList);
			class5295_0.imethod_6(fin: true);
			return arrayList;
		}

		protected override int vmethod_0()
		{
			return int_2;
		}

		protected override bool vmethod_1()
		{
			return !class5295_0.imethod_5();
		}

		protected override void vmethod_2(Class5652 posIter, Class5687 context)
		{
			Class5648.smethod_0(class5295_0, posIter, context);
		}

		protected override void vmethod_17(Class5395 alg, int partCount, Class5276 originalList, Class5276 effectiveList)
		{
			if (partCount > 1)
			{
				Class5259 @class = (Class5259)alg.method_23()[0];
				int num = Class5683.smethod_4(effectiveList, effectiveList.int_1, @class.method_6());
				int_4 += alg.int_14 - num;
			}
			alg.method_25();
			method_3(alg, 1, originalList, effectiveList);
		}

		protected override void vmethod_13(Class5395 alg, Class5259 pbp)
		{
		}

		protected override Interface173 vmethod_4()
		{
			return null;
		}
	}

	private Class4964 class4964_0;

	private Class4962 class4962_0;

	private Class5136 class5136_0;

	private int int_10;

	private int int_11 = -1;

	public Class5295(Class5322 pslm, Class5129 node, Class5136 reg)
		: base(node)
	{
		imethod_1(pslm);
		class5136_0 = reg;
		class4964_0 = method_15().method_37(class5136_0.vmethod_24());
	}

	public Class5295(Class5322 pslm, Class5129 node, Class4962 block)
		: base(node)
	{
		imethod_1(pslm);
		class4962_0 = block;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		throw new InvalidOperationException();
	}

	public override void imethod_9(Class5652 parentIter, Class5687 layoutContext)
	{
		Class5648.smethod_0(this, parentIter, layoutContext);
		vmethod_2();
		class4964_0 = null;
	}

	public override void imethod_8(Class4942 childArea)
	{
		if (!method_54().method_48().Equals("xsl-footnote-separator") && !method_54().method_48().Equals("xsl-before-float-separator"))
		{
			class4964_0.method_43((Class4962)childArea);
		}
		else
		{
			class4962_0.vmethod_5((Class4962)childArea);
		}
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		if (!method_54().method_48().Equals("xsl-footnote-separator") && !method_54().method_48().Equals("xsl-before-float-separator"))
		{
			return class4964_0;
		}
		return class4962_0;
	}

	public void method_53()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 9;
		bool flag = false;
		if (!method_54().method_48().Equals("xsl-footnote-separator") && !method_54().method_48().Equals("xsl-before-float-separator"))
		{
			num = class4964_0.method_12();
			num2 = class4964_0.vmethod_1();
			num3 = class5136_0.method_55();
		}
		else
		{
			num = class4962_0.method_12();
			num2 = class4962_0.vmethod_1();
			if (num2 == 0)
			{
				flag = true;
			}
			num3 = 13;
		}
		vmethod_8(num);
		method_55(num2);
		Class5273 @class = new Class5273(this, num, num3);
		@class.method_1(num2, flag);
		if (@class.method_7() && !flag)
		{
			string page = imethod_4().vmethod_0().method_1().method_15();
			Interface206 @interface = Class5701.smethod_0(method_54().method_2().method_48());
			bool canRecover = class5136_0.method_54() != 42;
			bool clip = class5136_0.method_54() == 57 || class5136_0.method_54() == 42;
			@interface.imethod_5(this, class5136_0.method_17(), page, @class.method_8(), clip, canRecover, method_54().method_1());
		}
	}

	internal Class5129 method_54()
	{
		return (Class5129)class5094_0;
	}

	public override int imethod_16()
	{
		return int_10;
	}

	protected override void vmethod_8(int contentAreaIPD)
	{
		int_10 = contentAreaIPD;
	}

	public override int imethod_17()
	{
		return int_11;
	}

	private void method_55(int contentAreaBPD)
	{
		int_11 = contentAreaBPD;
	}

	public override Class5686 imethod_29()
	{
		return Class5686.class5686_0;
	}

	public override Class5686 imethod_33()
	{
		return Class5686.class5686_0;
	}

	public override Class5686 imethod_31()
	{
		return Class5686.class5686_0;
	}
}
