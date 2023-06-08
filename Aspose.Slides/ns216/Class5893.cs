using System.Drawing;
using System.Globalization;
using System.Xml;
using ns215;

namespace ns216;

internal class Class5893 : Class5782
{
	internal static string Tag => "value";

	internal Class5893()
	{
		Class5906.smethod_3(this, "override", @default: false);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_177(this);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		Class5931 @class = new Class5931(new string[13]
		{
			Class5785.Tag,
			"boolean",
			"date",
			"dateTime",
			"decimal",
			"exData",
			"float",
			Class5874.Tag,
			"integer",
			Class5826.Tag,
			Class5842.Tag,
			"text",
			"time"
		}, this);
		@class.method_0(reader, node, this);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5893();
	}

	internal static string smethod_2(Class5782 value)
	{
		switch (value.vmethod_8())
		{
		case "text":
			return ((Class5889)value).Value;
		case "boolean":
			if (!((Class5861)value).Value)
			{
				return "0";
			}
			return "1";
		case "date":
			return ((Class5864)value).Value;
		case "dateTime":
			return ((Class5865)value).Value;
		case "time":
			return ((Class5890)value).Value;
		case "exData":
			return ((Class5869)value).Value;
		case "decimal":
			return ((Class5866)value).Value.ToString(CultureInfo.InvariantCulture);
		case "float":
			return ((Class5871)value).Value.ToString(CultureInfo.InvariantCulture);
		case "integer":
			return ((Class5875)value).Value.ToString(CultureInfo.InvariantCulture);
		default:
			return null;
		}
	}

	internal string method_6()
	{
		if (base.Nodes.Length == 0)
		{
			return null;
		}
		return smethod_2((Class5782)base.Nodes.method_1(0));
	}

	internal void method_7()
	{
		Class5889 @class = (Class5889)Class5929.Instance.CreateElement("text");
		@class.Parent = this;
		base.Nodes.method_0(@class);
	}

	internal void method_8(string value)
	{
		if (base.Nodes.Length != 0)
		{
			Class5782 @class = (Class5782)base.Nodes.method_1(0);
			switch (@class.vmethod_8())
			{
			case "text":
				((Class5889)@class).Value = value;
				break;
			case "boolean":
				((Class5861)@class).Value = int.Parse(value) != 0;
				break;
			case "date":
				((Class5864)@class).Value = value;
				break;
			case "dateTime":
				((Class5865)@class).Value = value;
				break;
			case "decimal":
				((Class5866)@class).Value = decimal.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
				break;
			case "exData":
				((Class5869)@class).Value = value;
				break;
			case "float":
				((Class5871)@class).Value = float.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
				break;
			case "integer":
				((Class5875)@class).Value = int.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
				break;
			case "time":
				((Class5890)@class).Value = value;
				break;
			}
		}
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal void method_9(Class5912 builder, PointF pos, SizeF size)
	{
	}

	internal override SizeF vmethod_9(SizeF size)
	{
		return ((Class5782)base.Nodes.method_1(0)).vmethod_9(size);
	}
}
