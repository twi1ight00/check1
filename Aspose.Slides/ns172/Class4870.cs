using System.Collections;
using ns171;
using ns174;
using ns189;
using ns190;
using ns191;
using ns192;

namespace ns172;

internal class Class4870 : Class4869
{
	private class Class4871 : Class4866
	{
		internal Class4871()
		{
		}
	}

	private Class4866 class4866_1;

	private Stack stack_0 = new Stack();

	private Stack stack_1 = new Stack();

	private Class4866 class4866_2;

	private Class4866 class4866_3 = new Class4871();

	public Class4870(Interface204 structureTreeEventHandler, Class4866 @delegate)
		: base(@delegate)
	{
		class4866_2 = new Class4868(structureTreeEventHandler);
		class4866_1 = class4866_2;
	}

	public override void vmethod_2()
	{
		class4866_1.vmethod_2();
		base.vmethod_2();
	}

	public override void vmethod_3()
	{
		class4866_1.vmethod_3();
		base.vmethod_3();
	}

	public override void vmethod_4(Class5170 root)
	{
		class4866_1.vmethod_4(root);
		base.vmethod_4(root);
	}

	public override void vmethod_5(Class5170 root)
	{
		class4866_1.vmethod_5(root);
		base.vmethod_5(root);
	}

	public override void vmethod_6(Class5127 pageSeq)
	{
		class4866_1.vmethod_6(pageSeq);
		base.vmethod_6(pageSeq);
	}

	public override void vmethod_7(Class5127 pageSeq)
	{
		class4866_1.vmethod_7(pageSeq);
		base.vmethod_7(pageSeq);
	}

	public override void vmethod_8(Class5119 pagenum)
	{
		class4866_1.vmethod_8(pagenum);
		base.vmethod_8(pagenum);
	}

	public override void vmethod_9(Class5119 pagenum)
	{
		class4866_1.vmethod_9(pagenum);
		base.vmethod_9(pagenum);
	}

	public override void vmethod_10(Class5121 pageCite)
	{
		class4866_1.vmethod_10(pageCite);
		base.vmethod_10(pageCite);
	}

	public override void vmethod_11(Class5121 pageCite)
	{
		class4866_1.vmethod_11(pageCite);
		base.vmethod_11(pageCite);
	}

	public override void vmethod_12(Class5122 pageLast)
	{
		class4866_1.vmethod_12(pageLast);
		base.vmethod_12(pageLast);
	}

	public override void vmethod_13(Class5122 pageLast)
	{
		class4866_1.vmethod_13(pageLast);
		base.vmethod_13(pageLast);
	}

	public override void vmethod_14(Class5128 fl)
	{
		class4866_1.vmethod_14(fl);
		base.vmethod_14(fl);
	}

	public override void vmethod_15(Class5128 fl)
	{
		class4866_1.vmethod_15(fl);
		base.vmethod_15(fl);
	}

	public override void vmethod_16(Class5106 bl)
	{
		class4866_1.vmethod_16(bl);
		base.vmethod_16(bl);
	}

	public override void vmethod_17(Class5106 bl)
	{
		class4866_1.vmethod_17(bl);
		base.vmethod_17(bl);
	}

	public override void vmethod_18(Class5161 blc)
	{
		class4866_1.vmethod_18(blc);
		base.vmethod_18(blc);
	}

	public override void vmethod_19(Class5161 blc)
	{
		class4866_1.vmethod_19(blc);
		base.vmethod_19(blc);
	}

	public override void vmethod_20(Class5100 inl)
	{
		class4866_1.vmethod_20(inl);
		base.vmethod_20(inl);
	}

	public override void vmethod_21(Class5100 inl)
	{
		class4866_1.vmethod_21(inl);
		base.vmethod_21(inl);
	}

	public override void vmethod_22(Class5156 tbl)
	{
		class4866_1.vmethod_22(tbl);
		stack_1.Push(null);
		base.vmethod_22(tbl);
	}

	public override void vmethod_23(Class5156 tbl)
	{
		((Class4867)stack_1.Pop())?.method_0(class4866_1);
		class4866_1.vmethod_23(tbl);
		base.vmethod_23(tbl);
	}

	public override void vmethod_24(Class5158 tc)
	{
		class4866_1.vmethod_24(tc);
		base.vmethod_24(tc);
	}

	public override void vmethod_25(Class5158 tc)
	{
		class4866_1.vmethod_25(tc);
		base.vmethod_25(tc);
	}

	public override void vmethod_26(Class5154 header)
	{
		class4866_1.vmethod_26(header);
		base.vmethod_26(header);
	}

	public override void vmethod_27(Class5154 header)
	{
		class4866_1.vmethod_27(header);
		base.vmethod_27(header);
	}

	public override void vmethod_28(Class5153 footer)
	{
		stack_0.Push(class4866_1);
		class4866_1 = new Class4867();
		class4866_1.vmethod_28(footer);
		base.vmethod_28(footer);
	}

	public override void vmethod_29(Class5153 footer)
	{
		class4866_1.vmethod_29(footer);
		stack_1.Pop();
		stack_1.Push(class4866_1);
		class4866_1 = (Class4866)stack_0.Pop();
		base.vmethod_29(footer);
	}

	public override void vmethod_30(Class5152 body)
	{
		class4866_1.vmethod_30(body);
		base.vmethod_30(body);
	}

	public override void vmethod_31(Class5152 body)
	{
		class4866_1.vmethod_31(body);
		base.vmethod_31(body);
	}

	public override void vmethod_32(Class5155 tr)
	{
		class4866_1.vmethod_32(tr);
		base.vmethod_32(tr);
	}

	public override void vmethod_33(Class5155 tr)
	{
		class4866_1.vmethod_33(tr);
		base.vmethod_33(tr);
	}

	public override void vmethod_34(Class5157 tc)
	{
		class4866_1.vmethod_34(tc);
		base.vmethod_34(tc);
	}

	public override void vmethod_35(Class5157 tc)
	{
		class4866_1.vmethod_35(tc);
		base.vmethod_35(tc);
	}

	public override void vmethod_36(Class5159 lb)
	{
		class4866_1.vmethod_36(lb);
		base.vmethod_36(lb);
	}

	public override void vmethod_37(Class5159 lb)
	{
		class4866_1.vmethod_37(lb);
		base.vmethod_37(lb);
	}

	public override void vmethod_38(Class5160 li)
	{
		class4866_1.vmethod_38(li);
		base.vmethod_38(li);
	}

	public override void vmethod_39(Class5160 li)
	{
		class4866_1.vmethod_39(li);
		base.vmethod_39(li);
	}

	public override void vmethod_40(Class5132 listItemLabel)
	{
		class4866_1.vmethod_40(listItemLabel);
		base.vmethod_40(listItemLabel);
	}

	public override void vmethod_41(Class5132 listItemLabel)
	{
		class4866_1.vmethod_41(listItemLabel);
		base.vmethod_41(listItemLabel);
	}

	public override void vmethod_42(Class5131 listItemBody)
	{
		class4866_1.vmethod_42(listItemBody);
		base.vmethod_42(listItemBody);
	}

	public override void vmethod_43(Class5131 listItemBody)
	{
		class4866_1.vmethod_43(listItemBody);
		base.vmethod_43(listItemBody);
	}

	public override void vmethod_44(Class5129 staticContent)
	{
		class4866_1.vmethod_44(staticContent);
		base.vmethod_44(staticContent);
	}

	public override void vmethod_45(Class5129 statisContent)
	{
		class4866_1.vmethod_45(statisContent);
		base.vmethod_45(statisContent);
	}

	public override void vmethod_46()
	{
		class4866_1.vmethod_46();
		base.vmethod_46();
	}

	public override void vmethod_47()
	{
		class4866_1.vmethod_47();
		base.vmethod_47();
	}

	public override void vmethod_48(Class5098 basicLink)
	{
		class4866_1.vmethod_48(basicLink);
		base.vmethod_48(basicLink);
	}

	public override void vmethod_49(Class5098 basicLink)
	{
		class4866_1.vmethod_49(basicLink);
		base.vmethod_49(basicLink);
	}

	public override void vmethod_50(Class5110 eg)
	{
		class4866_1.vmethod_50(eg);
		base.vmethod_50(eg);
	}

	public override void vmethod_51()
	{
		class4866_1.vmethod_51();
		base.vmethod_51();
	}

	public override void vmethod_52(Class5111 ifo)
	{
		class4866_1.vmethod_52(ifo);
		base.vmethod_52(ifo);
	}

	public override void vmethod_53(Class5111 ifo)
	{
		class4866_1.vmethod_53(ifo);
		base.vmethod_53(ifo);
	}

	public override void vmethod_54(Class5124 footnote)
	{
		class4866_1.vmethod_54(footnote);
		base.vmethod_54(footnote);
	}

	public override void vmethod_55(Class5124 footnote)
	{
		class4866_1.vmethod_55(footnote);
		base.vmethod_55(footnote);
	}

	public override void vmethod_56(Class5112 body)
	{
		class4866_1.vmethod_56(body);
		base.vmethod_56(body);
	}

	public override void vmethod_57(Class5112 body)
	{
		class4866_1.vmethod_57(body);
		base.vmethod_57(body);
	}

	public override void vmethod_58(Class5102 l)
	{
		stack_0.Push(class4866_1);
		class4866_1 = class4866_3;
		class4866_1.vmethod_58(l);
		base.vmethod_58(l);
	}

	public override void vmethod_59(Class5102 l)
	{
		class4866_1.vmethod_59(l);
		class4866_1 = (Class4866)stack_0.Pop();
		base.vmethod_59(l);
	}

	public override void vmethod_60(Class5107 wrapper)
	{
		class4866_1.vmethod_60(wrapper);
		base.vmethod_60(wrapper);
	}

	public override void vmethod_61(Class5107 wrapper)
	{
		class4866_1.vmethod_61(wrapper);
		base.vmethod_61(wrapper);
	}

	public override void vmethod_62(Class5165 c)
	{
		class4866_1.vmethod_62(c);
		base.vmethod_62(c);
	}

	public override void vmethod_63(Class5172 foText)
	{
		class4866_1.vmethod_63(foText);
		base.vmethod_63(foText);
	}

	public override void vmethod_64(Class5126 document)
	{
		class4866_1.vmethod_64(document);
		base.vmethod_64(document);
	}

	public override void vmethod_65(Class5126 document)
	{
		class4866_1.vmethod_65(document);
		base.vmethod_65(document);
	}
}
