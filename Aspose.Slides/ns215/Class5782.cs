using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using ns216;
using ns217;

namespace ns215;

internal abstract class Class5782 : Class5781
{
	protected Class5782()
	{
		base.ClassName = vmethod_8();
	}

	internal abstract void vmethod_4(Class5911 visitor);

	internal virtual void vmethod_5(Class5932 reader, XmlNode node)
	{
		if (!(vmethod_8() != Class5784.Tag) || !(vmethod_8() != Class5852.Tag))
		{
			return;
		}
		foreach (KeyValuePair<string, Class5898> attribute in base.Attributes)
		{
			attribute.Value.method_0(node, attribute.Key);
			if (attribute.Key == "use" && !attribute.Value.Default)
			{
				reader.PrototypedElements.Add(this);
			}
		}
		base.Name = Class5898.smethod_0(node, "name");
		base.Id = Class5898.smethod_0(node, "id");
		if (!string.IsNullOrEmpty(base.Id))
		{
			((Class5784)method_2()).IdElementsDictionary[base.Id] = this;
		}
	}

	internal virtual void vmethod_6(Class5782 prototype)
	{
		foreach (KeyValuePair<string, Class5898> attribute in prototype.Attributes)
		{
			if (!attribute.Value.Default && base.Attributes[attribute.Key].Default)
			{
				base.Attributes[attribute.Key].vmethod_0(attribute.Value.vmethod_1());
			}
		}
	}

	public override Class5781 vmethod_3()
	{
		return vmethod_7();
	}

	internal abstract Class5782 vmethod_7();

	internal abstract string vmethod_8();

	internal virtual SizeF vmethod_9(SizeF size)
	{
		return size;
	}
}
