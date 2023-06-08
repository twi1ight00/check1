using System.Drawing;
using System.Xml;
using ns215;

namespace ns216;

internal class Class5855 : Class5783
{
	private readonly string[] string_4 = new string[11]
	{
		Class5788.Tag,
		Class5794.Tag,
		Class5798.Tag,
		Class5799.Tag,
		Class5805.Tag,
		Class5806.Tag,
		Class5822.Tag,
		Class5831.Tag,
		Class5837.Tag,
		Class5843.Tag,
		Class5804.Tag
	};

	internal static string Tag => "ui";

	internal Class5855()
	{
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_173(this);
		base.vmethod_4(visitor);
		visitor.vmethod_174(this);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		Class5931 @class = new Class5931(string_4, this);
		@class.method_0(reader, node, this);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5855();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal void method_8(Class5912 builder, PointF pos, SizeF size)
	{
	}

	internal override string[] vmethod_10()
	{
		return new string[2]
		{
			Class5816.Tag,
			Class5882.Tag
		};
	}
}
