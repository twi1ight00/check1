using System;
using System.Xml;
using Aspose.XfaConverter.Elements;
using ns215;
using ns217;

namespace ns216;

internal class Class5789 : Class5783
{
	internal class Class5894 : Class5781
	{
		public Class5894()
		{
			base.ClassName = "noderef";
		}

		public override Class5781 vmethod_3()
		{
			return new Class5894();
		}
	}

	internal static string Tag => "bind";

	public XfaEnums.Enum685 Match => (XfaEnums.Enum685)method_5("match").Value;

	public string Ref => (string)method_5("ref").Value;

	public Class5789()
	{
		Class5906.smethod_4(this, "ref", string.Empty);
		Class5906.smethod_6(this, "match", XfaEnums.Enum685.const_0);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_9(this);
		base.vmethod_4(visitor);
		visitor.vmethod_10(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5789();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal static Class5789 smethod_2(Class5781 node)
	{
		if (!(node.Parent is Class5789) && node.Parent != null)
		{
			return smethod_2(node.Parent);
		}
		return node.Parent as Class5789;
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		base.vmethod_5(reader, node);
		if (Match == XfaEnums.Enum685.const_1 && !string.IsNullOrEmpty(Ref) && Ref.StartsWith("$"))
		{
			string[] array = Ref.TrimStart('$').Split(new char[1] { '.' }, StringSplitOptions.RemoveEmptyEntries);
			Class5781 @class = this;
			string[] array2 = array;
			foreach (string name in array2)
			{
				Class5894 class2 = new Class5894();
				class2.Name = name;
				class2.Parent = @class;
				@class.Nodes.method_0(class2);
				@class = class2;
			}
		}
	}

	internal override string[] vmethod_10()
	{
		return new string[1] { Class5882.Tag };
	}
}
