using System.Globalization;
using ns171;
using ns174;
using ns178;
using ns187;
using ns189;
using ns190;
using ns191;
using ns192;

namespace ns172;

internal class Class4868 : Class4866
{
	private Interface204 interface204_0;

	public Class4868(Interface204 structureTreeEventHandler)
	{
		interface204_0 = structureTreeEventHandler;
	}

	public override void vmethod_2()
	{
	}

	public override void vmethod_3()
	{
	}

	public override void vmethod_6(Class5127 pageSeq)
	{
		CultureInfo currentCulture = CultureInfo.CurrentCulture;
		interface204_0.imethod_0(currentCulture);
	}

	public override void vmethod_7(Class5127 pageSeq)
	{
		interface204_0.imethod_5();
	}

	public override void vmethod_8(Class5119 pagenum)
	{
		method_1(pagenum);
	}

	public override void vmethod_9(Class5119 pagenum)
	{
		method_7(pagenum);
	}

	public override void vmethod_10(Class5121 pageCite)
	{
		method_1(pageCite);
	}

	public override void vmethod_11(Class5121 pageCite)
	{
		method_7(pageCite);
	}

	public override void vmethod_12(Class5122 pageLast)
	{
		method_1(pageLast);
	}

	public override void vmethod_13(Class5122 pageLast)
	{
		method_7(pageLast);
	}

	public override void vmethod_14(Class5128 fl)
	{
		method_0(fl);
	}

	public override void vmethod_15(Class5128 fl)
	{
		method_7(fl);
	}

	public override void vmethod_16(Class5106 bl)
	{
		method_0(bl);
	}

	public override void vmethod_17(Class5106 bl)
	{
		method_7(bl);
	}

	public override void vmethod_18(Class5161 blc)
	{
		method_0(blc);
	}

	public override void vmethod_19(Class5161 blc)
	{
		method_7(blc);
	}

	public override void vmethod_20(Class5100 inl)
	{
		method_0(inl);
	}

	public override void vmethod_21(Class5100 inl)
	{
		method_7(inl);
	}

	public override void vmethod_22(Class5156 tbl)
	{
		method_0(tbl);
	}

	public override void vmethod_23(Class5156 tbl)
	{
		method_7(tbl);
	}

	public override void vmethod_26(Class5154 header)
	{
		method_0(header);
	}

	public override void vmethod_27(Class5154 header)
	{
		method_7(header);
	}

	public override void vmethod_28(Class5153 footer)
	{
		method_0(footer);
	}

	public override void vmethod_29(Class5153 footer)
	{
		method_7(footer);
	}

	public override void vmethod_30(Class5152 body)
	{
		method_0(body);
	}

	public override void vmethod_31(Class5152 body)
	{
		method_7(body);
	}

	public override void vmethod_32(Class5155 tr)
	{
		method_0(tr);
	}

	public override void vmethod_33(Class5155 tr)
	{
		method_7(tr);
	}

	public override void vmethod_34(Class5157 tc)
	{
		Class5699 attributes = new Class5699();
		int num = tc.method_53();
		if (num > 1)
		{
			method_4(attributes, "number-columns-spanned", num.ToString());
		}
		method_3(tc, attributes);
	}

	public override void vmethod_35(Class5157 tc)
	{
		method_7(tc);
	}

	public override void vmethod_36(Class5159 lb)
	{
		method_0(lb);
	}

	public override void vmethod_37(Class5159 lb)
	{
		method_7(lb);
	}

	public override void vmethod_38(Class5160 li)
	{
		method_0(li);
	}

	public override void vmethod_39(Class5160 li)
	{
		method_7(li);
	}

	public override void vmethod_40(Class5132 listItemLabel)
	{
		method_0(listItemLabel);
	}

	public override void vmethod_41(Class5132 listItemLabel)
	{
		method_7(listItemLabel);
	}

	public override void vmethod_42(Class5131 listItemBody)
	{
		method_0(listItemBody);
	}

	public override void vmethod_43(Class5131 listItemBody)
	{
		method_7(listItemBody);
	}

	public override void vmethod_44(Class5129 staticContent)
	{
		method_0(staticContent);
	}

	public override void vmethod_45(Class5129 statisContent)
	{
		method_7(statisContent);
	}

	public override void vmethod_48(Class5098 basicLink)
	{
		method_1(basicLink);
	}

	public override void vmethod_49(Class5098 basicLink)
	{
		method_7(basicLink);
	}

	public override void vmethod_50(Class5110 eg)
	{
		method_2(eg);
		method_7(eg);
	}

	public override void vmethod_52(Class5111 ifo)
	{
		method_2(ifo);
	}

	public override void vmethod_53(Class5111 ifo)
	{
		method_7(ifo);
	}

	public override void vmethod_54(Class5124 footnote)
	{
		method_0(footnote);
	}

	public override void vmethod_55(Class5124 footnote)
	{
		method_7(footnote);
	}

	public override void vmethod_56(Class5112 body)
	{
		method_0(body);
	}

	public override void vmethod_57(Class5112 body)
	{
		method_7(body);
	}

	public override void vmethod_60(Class5107 wrapper)
	{
		method_0(wrapper);
	}

	public override void vmethod_61(Class5107 wrapper)
	{
		method_7(wrapper);
	}

	public override void vmethod_62(Class5165 c)
	{
		method_1(c);
		method_7(c);
	}

	public override void vmethod_63(Class5172 foText)
	{
		method_1(foText);
		method_7(foText);
	}

	private void method_0(Class5088 node)
	{
		method_3(node, new Class5699());
	}

	private void method_1(Class5088 node)
	{
		Class5699 attributes = new Class5699();
		string name = node.vmethod_21();
		if (node is Interface222)
		{
			method_6((Interface222)node, attributes);
		}
		node.vmethod_29(interface204_0.imethod_4(name, attributes));
	}

	private void method_2(Class5109 node)
	{
		Class5699 attributes = new Class5699();
		string name = node.vmethod_21();
		method_6(node, attributes);
		method_5(attributes, "http://xmlgraphics.apache.org/fop/extensions", "alt-text", Class5183.string_3, node.method_56());
		node.vmethod_29(interface204_0.imethod_3(name, attributes));
	}

	private Interface244 method_3(Class5088 node, Class5699 attributes)
	{
		string name = node.vmethod_21();
		if (node is Interface222)
		{
			method_6((Interface222)node, attributes);
		}
		return interface204_0.imethod_1(name, attributes);
	}

	private void method_4(Class5699 attributes, string name, string value)
	{
		attributes.method_1(string.Empty, name, name, "CDATA", value);
	}

	private void method_5(Class5699 attributes, string @namespace, string localName, string prefix, string value)
	{
		string qName = prefix + ":" + localName;
		attributes.method_1(@namespace, localName, qName, "CDATA", value);
	}

	private void method_6(Interface222 node, Class5699 attributes)
	{
		string text = node.imethod_0().method_1();
		if (text != null)
		{
			method_4(attributes, "role", text);
		}
	}

	private void method_7(Class5088 node)
	{
		string name = node.vmethod_21();
		interface204_0.imethod_2(name);
	}
}
