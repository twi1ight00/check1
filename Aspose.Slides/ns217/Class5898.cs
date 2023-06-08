using System.Xml;

namespace ns217;

internal abstract class Class5898
{
	private bool bool_0 = true;

	private object object_0;

	public bool Default
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public object Value
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	internal static string smethod_0(XmlNode node, string name)
	{
		XmlNode xmlNode = node.Attributes[name];
		if (xmlNode != null && !string.IsNullOrEmpty(xmlNode.Value))
		{
			return xmlNode.Value;
		}
		return null;
	}

	public void method_0(XmlNode node, string name)
	{
		string value = smethod_0(node, name);
		if (!string.IsNullOrEmpty(value))
		{
			vmethod_0(value);
			Default = false;
		}
	}

	public abstract void vmethod_0(string value);

	public abstract string vmethod_1();

	protected abstract Class5898 vmethod_2();

	public object Clone()
	{
		Class5898 @class = vmethod_2();
		@class.Value = Value;
		return @class;
	}
}
