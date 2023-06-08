using System;
using System.Xml;
using ns216;
using ns217;

namespace ns215;

internal class Class5897 : Class5896
{
	private string string_4;

	public string Value
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public Class5897(string name)
		: base(name)
	{
		base.ClassName = "dataValue";
	}

	public override Class5781 vmethod_3()
	{
		return new Class5897("tempValueName");
	}

	public override void vmethod_4(XmlNode node)
	{
		string_4 = node.InnerXml;
	}

	public override Class5908 vmethod_5(Class5784 xfa)
	{
		Class5908 @class = base.vmethod_5(xfa);
		if (string.IsNullOrEmpty(string_4))
		{
			return @class;
		}
		try
		{
			for (int i = 0; i < @class.Length; i++)
			{
				Class5781 class2 = @class.List[i];
				if (class2 is Class5789.Class5894)
				{
					Class5789 class3 = Class5789.smethod_2(class2);
					if (class3 != null)
					{
						class2 = class3.Parent;
					}
				}
				if (class2 is Class5817 class4)
				{
					class4.Value = string_4;
				}
				else
				{
					if (!(class2 is Class5814))
					{
						continue;
					}
					Class5908 class5 = class2.method_3(string.Format("{0}[*]", "field"));
					foreach (Class5817 item in class5.List)
					{
						item.Value = string_4;
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return @class;
	}
}
