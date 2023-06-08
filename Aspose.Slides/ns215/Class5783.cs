using System;
using System.Collections;
using System.Drawing;
using System.Xml;

namespace ns215;

internal abstract class Class5783 : Class5782
{
	private static Hashtable hashtable_0 = new Hashtable();

	internal abstract string[] vmethod_10();

	internal override void vmethod_4(Class5911 visitor)
	{
		foreach (Class5782 item in base.Nodes.List)
		{
			item.vmethod_4(visitor);
		}
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		base.vmethod_5(reader, node);
		string[] array = vmethod_10();
		foreach (XmlNode childNode in node.ChildNodes)
		{
			if (hashtable_0.ContainsKey(childNode))
			{
				continue;
			}
			bool flag = false;
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text == childNode.Name)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				Class5782 @class = Class5929.Instance.CreateElement(childNode.Name);
				@class.Parent = this;
				Class5782 class2 = @class.vmethod_7();
				class2.Parent = this;
				method_7(childNode.Name, class2);
				hashtable_0[childNode] = 0;
				class2.vmethod_5(reader, childNode);
			}
		}
	}

	internal override void vmethod_6(Class5782 prototype)
	{
		base.vmethod_6(prototype);
		foreach (Class5782 item in prototype.Nodes.List)
		{
			if (!(base.Nodes.method_3(item.ClassName) is Class5782 class2))
			{
				base.Nodes.method_0(item);
			}
			else
			{
				class2.vmethod_6(item);
			}
		}
	}

	internal Class5782 method_6(string tag)
	{
		return (Class5782)base.Nodes.method_3(tag);
	}

	public void method_7(string tag, Class5782 element)
	{
		element.Parent = this;
		base.Nodes.method_0(element);
	}

	internal override SizeF vmethod_9(SizeF size)
	{
		SizeF sizeF = size;
		foreach (Class5782 item in base.Nodes.List)
		{
			SizeF sizeF2 = item.vmethod_9(sizeF);
			if (sizeF2.Width > sizeF.Width || sizeF2.Height > sizeF.Height)
			{
				sizeF = new SizeF(Math.Max(sizeF2.Width, sizeF.Width), Math.Max(sizeF2.Height, sizeF.Height));
			}
		}
		return sizeF;
	}
}
