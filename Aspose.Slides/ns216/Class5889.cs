using System.Collections;
using System.Drawing;
using System.Xml;
using ns215;
using ns224;
using ns235;

namespace ns216;

internal class Class5889 : Class5782
{
	internal const string string_4 = "text";

	private Class5937 class5937_0;

	private string string_5;

	public string Value
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public Class5889()
	{
		class5937_0 = new Class5937();
		Class5906.smethod_2(this, "maxChars", 0);
	}

	public override object Clone()
	{
		Class5889 @class = (Class5889)base.Clone();
		@class.class5937_0 = new Class5937();
		@class.Value = Value;
		return @class;
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_163(this);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		Value = reader.method_7(node);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5889();
	}

	internal SizeF Initialize(Class5913 textAttributes, Class5836 para, Class5829 margin, Interface250 location, Class5998 color, Class5873 hyphenation, Class5783 xfaElement)
	{
		ArrayList arrayList = new ArrayList();
		textAttributes.Add(Enum739.const_16, (Value == null) ? string.Empty : Value.TrimEnd(' '));
		arrayList.Add(textAttributes);
		return class5937_0.Initialize(arrayList, para, margin, location, color, hyphenation, xfaElement);
	}

	internal void method_6(Class6213 canvas, PointF pos, SizeF size)
	{
		if (!(base.Parent is Class5824))
		{
			class5937_0.method_0(canvas, pos, size);
		}
	}

	internal override string vmethod_8()
	{
		return "text";
	}
}
