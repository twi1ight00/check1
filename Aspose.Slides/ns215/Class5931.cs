using System;
using System.Xml;
using ns217;

namespace ns215;

internal class Class5931 : ICloneable
{
	private string[] string_0;

	private Class5782 class5782_0;

	private Class5782 class5782_1;

	public Class5782 Parent
	{
		get
		{
			return class5782_1;
		}
		set
		{
			class5782_1 = value;
		}
	}

	internal Class5782 Value
	{
		get
		{
			return class5782_0;
		}
		set
		{
			class5782_0 = value;
		}
	}

	internal Class5931(string[] elementsTags, Class5782 parent)
	{
		string_0 = elementsTags;
		class5782_1 = parent;
	}

	internal void method_0(Class5932 reader, XmlNode xmlNode, Class5781 parentNode)
	{
		string[] array = string_0;
		foreach (string text in array)
		{
			XmlNodeList xmlNodeList = reader.method_0(text, xmlNode);
			if (xmlNodeList != null && xmlNodeList.Count != 0)
			{
				class5782_0 = Class5929.Instance.CreateElement(text);
				Value.Parent = class5782_1;
				Value.vmethod_5(reader, xmlNodeList[0]);
				break;
			}
		}
		if (Value != null)
		{
			parentNode.Nodes.method_0(Value);
		}
	}

	public object Clone()
	{
		Class5931 @class = (Class5931)MemberwiseClone();
		if (@class.Value != null)
		{
			@class.Value = (Class5782)class5782_0.Clone();
		}
		return @class;
	}
}
