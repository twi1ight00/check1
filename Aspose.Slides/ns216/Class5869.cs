using System.Collections;
using System.Drawing;
using System.Xml;
using Aspose.XfaConverter.Elements;
using ns215;
using ns224;
using ns235;

namespace ns216;

internal class Class5869 : Class5782
{
	internal const string string_4 = "exData";

	private Class5937 class5937_0;

	private string string_5;

	public string ContentType => (string)method_5("contentType").Value;

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

	public override object Clone()
	{
		Class5869 @class = (Class5869)base.Clone();
		@class.class5937_0 = new Class5937();
		@class.Value = Value;
		return @class;
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_69(this);
	}

	public Class5869()
	{
		class5937_0 = new Class5937();
		Class5906.smethod_4(this, "contentType", string.Empty);
		Class5906.smethod_2(this, "maxLength", -1);
		Class5906.smethod_6(this, "transferEncoding", XfaEnums.Enum731.const_0);
		Class5906.smethod_4(this, "href", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		string_5 = reader.method_8(node);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5869();
	}

	internal override string vmethod_8()
	{
		return "exData";
	}

	internal SizeF Initialize(Class5913 textAttributes, Class5836 para, Class5829 margin, Interface250 location, Class5998 color, Class5873 hyphenation, Class5783 xfaElement)
	{
		ArrayList arrayList = new ArrayList();
		Class5936.smethod_3(string_5, textAttributes, arrayList);
		return class5937_0.Initialize(arrayList, para, margin, location, color, hyphenation, xfaElement);
	}

	internal void method_6(Class6213 canvas, PointF pos, SizeF size)
	{
		class5937_0.method_0(canvas, pos, size);
	}
}
