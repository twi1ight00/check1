using System.Xml;
using ns216;
using ns217;

namespace ns215;

internal class Class5896 : Class5781
{
	private class Class5909 : Interface247
	{
		public bool imethod_0(Class5781 node)
		{
			if (!(node is Class5848) && !(node is Class5814) && !(node is Class5817) && !(node is Class5809) && !(node is Class5786) && !(node is Class5835) && !(node is Class5834) && !(node is Class5784) && !(node is Class5852) && !(node is Class5789))
			{
				return node is Class5789.Class5894;
			}
			return true;
		}
	}

	public Class5896(string name)
	{
		base.Name = name;
		base.ClassName = "dataContainer";
	}

	public override Class5781 vmethod_3()
	{
		return new Class5896("tempName");
	}

	public virtual void vmethod_4(XmlNode node)
	{
		foreach (XmlNode childNode in node.ChildNodes)
		{
			if (childNode.HasChildNodes && (childNode.ChildNodes.Count != 1 || childNode.ChildNodes[0].NodeType != XmlNodeType.Text))
			{
				Class5896 @class = new Class5896(childNode.LocalName);
				base.Nodes.method_0(@class);
				@class.Parent = this;
				@class.vmethod_4(childNode);
			}
			else
			{
				Class5897 class2 = new Class5897(childNode.LocalName);
				base.Nodes.method_0(class2);
				class2.Parent = this;
				class2.vmethod_4(childNode);
			}
		}
		foreach (XmlAttribute attribute in node.Attributes)
		{
			Class5897 class3 = new Class5897(attribute.Name);
			base.Nodes.method_0(class3);
			class3.Parent = this;
			class3.Value = attribute.Value;
		}
	}

	protected static string smethod_2(string som)
	{
		return som.Replace(".", "..").Replace("xfa..template[0]", string.Empty);
	}

	public virtual Class5908 vmethod_5(Class5784 xfa)
	{
		string somExpression = smethod_2(base.SomExpression);
		Class5908 @class = xfa.method_4(somExpression, new Class5909());
		if (@class == null || @class.Length == 0)
		{
			Class5908 class2 = xfa.method_4($"{smethod_2(base.Parent.SomExpression)}..{base.Name}[*]", new Class5909());
			if (class2 == null || class2.Length == 0)
			{
				return null;
			}
			@class = new Class5908();
			foreach (Class5781 item in class2.List)
			{
				if (!item.CreatedFromData)
				{
					Class5781 parent = item.Parent;
					Class5781 class3 = (Class5781)item.Clone();
					class3.Parent = parent;
					@class.method_0(class3);
					class3.CreatedFromData = true;
					parent.Nodes.method_0(class3);
				}
			}
		}
		return @class;
	}
}
