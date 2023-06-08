using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns235;
using ns287;
using ns295;
using ns301;
using ns306;

namespace ns294;

internal class Class6800 : Interface328
{
	private class Class6801
	{
		private string string_0;

		private Class6982 class6982_0;

		private List<Class6204> list_0;

		public string Id => string_0;

		public Class6982 Element => class6982_0;

		public List<Class6204> Nodes => list_0;

		public Class6801(string id, Class6982 element)
		{
			string_0 = id;
			class6982_0 = element;
			list_0 = new List<Class6204>();
		}
	}

	private Interface327 interface327_0;

	private Class7047 class7047_0;

	private Class6216[] class6216_0;

	private Hashtable hashtable_0;

	private Hashtable hashtable_1 = new Hashtable();

	private Hashtable hashtable_2 = new Hashtable();

	public Class7047 Document => class7047_0;

	public Class6216[] Pages => class6216_0;

	public Class6800(Class7047 document, Interface327 idGenerator)
	{
		class7047_0 = document;
		interface327_0 = idGenerator;
	}

	public string method_0(Class6982 element)
	{
		if (hashtable_1.ContainsKey(element))
		{
			return method_5(element).Id;
		}
		string text = interface327_0.imethod_0(element);
		if (text != null && text.Length != 0)
		{
			text = text.ToUpper();
			method_3(new Class6801(text, element));
			return text;
		}
		return text;
	}

	public Class6204[] imethod_0(Class6982 element)
	{
		Class6801 @class = method_5(element);
		return @class.Nodes.ToArray();
	}

	public Class6982 imethod_1(Class6204 node)
	{
		if (string.IsNullOrEmpty(node.Id))
		{
			return null;
		}
		return method_4(node.Id.ToUpper())?.Element;
	}

	public Class6797 imethod_2(Class6982 element)
	{
		Class6892.smethod_0(element, "element");
		RectangleF rectangle = RectangleF.Empty;
		method_7(element, ref rectangle);
		return new Class6797(element, rectangle, this);
	}

	public Class6797 imethod_3(Class6204 node)
	{
		Class6892.smethod_0(node, "node");
		Class6982 @class = imethod_1(node);
		if (@class == null)
		{
			return null;
		}
		return imethod_2(@class);
	}

	public void method_1(Class6216[] pages)
	{
		class6216_0 = pages;
		foreach (Class6216 node in pages)
		{
			method_2(node);
		}
	}

	private void method_2(Class6204 node)
	{
		if (!string.IsNullOrEmpty(node.Id))
		{
			method_4(node.Id.ToUpper())?.Nodes.Add(node);
		}
		if (node is Class6212 @class)
		{
			for (int i = 0; i < @class.Count; i++)
			{
				Class6204 node2 = @class[i];
				method_2(node2);
			}
		}
	}

	private void method_3(Class6801 tuple)
	{
		hashtable_1.Add(tuple.Element, tuple);
		hashtable_2.Add(tuple.Id, tuple);
	}

	private Class6801 method_4(string id)
	{
		if (!hashtable_2.ContainsKey(id))
		{
			return null;
		}
		return (Class6801)hashtable_2[id];
	}

	private Class6801 method_5(Class6982 element)
	{
		if (!hashtable_1.ContainsKey(element))
		{
			return null;
		}
		return (Class6801)hashtable_1[element];
	}

	internal void method_6(Hashtable map)
	{
		hashtable_0 = map;
	}

	internal bool method_7(Class6982 element, ref RectangleF rectangle)
	{
		Class6801 @class = method_5(element);
		if (@class == null)
		{
			return false;
		}
		string key = @class.Id.ToLower();
		if (!hashtable_0.ContainsKey(key))
		{
			return false;
		}
		rectangle = (RectangleF)hashtable_0[key];
		return true;
	}
}
