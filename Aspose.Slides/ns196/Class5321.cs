using System;
using System.Drawing;
using ns173;
using ns176;
using ns181;
using ns183;
using ns191;
using ns198;
using ns205;

namespace ns196;

internal class Class5321 : Class5320
{
	private Class5407 class5407_0;

	public Class5321(Class4872 ath, Class5126 document)
		: base(ath, document)
	{
	}

	protected Class5126 method_34()
	{
		return (Class5126)class5125_0;
	}

	public override Class5322 imethod_4()
	{
		throw new InvalidOperationException("getPSLM() is illegal for " + GetType().FullName);
	}

	public override void imethod_27()
	{
		throw new NotImplementedException();
	}

	private Interface176 method_35()
	{
		return Class5347.smethod_0(method_34().method_2().method_48());
	}

	private void method_36(Class5741 info, Class5407 layout)
	{
		class5407_0 = layout;
		class5690_0 = vmethod_3(isBlank: false);
		method_37(info.method_0());
		vmethod_4();
	}

	private void method_37(string uri)
	{
		Size size = class5407_0.method_7();
		Class4962 @class = new Class4962();
		@class.method_11(size.Width);
		Class4972 class2 = new Class4972();
		Class4968 class3 = new Class4968(uri);
		Class5677.smethod_21(class3, class5094_0.vmethod_31());
		method_18(class3);
		Class4951 class4 = new Class4951(class3, class5094_0.method_41());
		Class5677.smethod_21(class4, class5094_0.vmethod_31());
		class4.method_11(size.Width);
		class4.method_13(size.Height);
		class4.method_52(class5407_0.method_6());
		class4.method_41(0);
		class2.method_37(class4);
		class2.method_42();
		@class.method_43(class2);
		class5690_0.method_1().method_35().vmethod_5(@class);
		class5690_0.method_1().method_34().method_46();
	}

	public override void imethod_29()
	{
		if (class5125_0.method_39())
		{
			class5494_0.method_2(class5125_0.vmethod_31());
		}
		class5125_0.vmethod_20().method_54(int_2, int_2 - int_3 + 1);
		class4872_0.method_8(class5125_0, int_2 - int_3 + 1);
	}

	protected override Class5690 vmethod_2(int pageNumber, bool isBlank)
	{
		string pageNumberStr = class5125_0.method_50(pageNumber);
		Size size = class5407_0.method_7();
		Rectangle rectangle = ((class5125_0.vmethod_32() % 180 != 0) ? new Rectangle(0, 0, size.Height, size.Width) : new Rectangle(0, 0, size.Width, size.Height));
		Class5728 reldims = new Class5728(0, 0);
		Class5492 ctM = Class5492.smethod_1(class5125_0.vmethod_32(), Class5445.class5445_0, rectangle, reldims);
		Class5690 @class = new Class5690(rectangle, pageNumber, pageNumberStr, isBlank);
		Class4974 class2 = @class.method_1();
		Class4973 class3 = new Class4973();
		class2.method_13(class3);
		Class4971 class4 = new Class4971(rectangle);
		class4.method_11(rectangle.Width);
		class4.method_13(rectangle.Height);
		class4.method_39(c: true);
		Class4965 class5 = new Class4965(58, "fop-image-region", class4, 1, 0);
		class5.method_11(size.Width);
		class5.method_13(size.Height);
		class5.method_37(ctM);
		class4.method_37(class5);
		class3.method_10(58, class4);
		class2.method_18(class4872_0.method_10());
		class2.method_33(spanAll: false);
		return @class;
	}
}
