using System;
using System.Collections;
using System.Drawing;
using System.Text;
using ns174;
using ns178;
using ns191;
using ns195;
using ns207;

namespace ns179;

internal class Class4929 : Class4927
{
	private StringBuilder stringBuilder_0 = new StringBuilder();

	private Stack stack_0 = new Stack();

	private Interface198 interface198_0;

	private Interface244 interface244_0;

	private Hashtable hashtable_0;

	public Class4929(Interface198 navHandler, Hashtable structureTreeElements)
	{
		interface198_0 = navHandler;
		hashtable_0 = structureTreeElements;
	}

	public void method_0(string uri, string localName, string qName, Interface236 attributes)
	{
		bool flag = false;
		if ("http://xmlgraphics.apache.org/fop/intermediate/document-navigation".Equals(uri))
		{
			if (Class5355.class5619_0.method_2().Equals(localName))
			{
				if (stack_0.Count > 0)
				{
					throw new Exception51(localName + " must be the root element!");
				}
				Class5354 obj = new Class5354();
				stack_0.Push(obj);
			}
			else if (Class5355.class5619_1.method_2().Equals(localName))
			{
				string title = attributes.imethod_5("title");
				string value = attributes.imethod_5("starting-state");
				bool show = !"hide".Equals(value);
				Class5353 @class = new Class5353(title, show, null);
				object obj2 = stack_0.Peek();
				if (obj2 is Class5349)
				{
					Class5349 action = (Class5349)stack_0.Pop();
					obj2 = stack_0.Peek();
					((Class5353)obj2).method_3(action);
				}
				if (obj2 is Class5354)
				{
					((Class5354)obj2).method_0(@class);
				}
				else
				{
					((Class5353)obj2).method_4(@class);
				}
				stack_0.Push(@class);
			}
			else if (Class5355.class5619_2.method_2().Equals(localName))
			{
				if (stack_0.Count > 0)
				{
					throw new Exception51(localName + " must be the root element!");
				}
				string name = attributes.imethod_5("name");
				Class5357 obj3 = new Class5357(name, null);
				stack_0.Push(obj3);
			}
			else if (Class5355.class5619_3.method_2().Equals(localName))
			{
				if (stack_0.Count > 0)
				{
					throw new Exception51(localName + " must be the root element!");
				}
				RectangleF targetRect = Class5482.smethod_5(attributes, "rect");
				interface244_0 = (Interface244)hashtable_0[attributes.imethod_5(Class5182.string_5)];
				Class5356 obj4 = new Class5356(null, targetRect);
				stack_0.Push(obj4);
			}
			else if (Class5355.class5619_4.method_2().Equals(localName))
			{
				string text = attributes.imethod_5("idref");
				Class5350 class2;
				if (text != null)
				{
					class2 = new Class5350(text);
				}
				else
				{
					string id = attributes.imethod_5("id");
					int num = Class5482.smethod_2(attributes, "page-index");
					PointF targetLocation;
					if (num < 0)
					{
						targetLocation = PointF.Empty;
					}
					else
					{
						int x = Class5482.smethod_2(attributes, "x");
						int y = Class5482.smethod_2(attributes, "y");
						targetLocation = new Point(x, y);
					}
					class2 = new Class5350(id, num, targetLocation);
				}
				if (interface244_0 != null)
				{
					class2.method_2(interface244_0);
				}
				stack_0.Push(class2);
			}
			else
			{
				if (!Class5355.class5619_5.method_2().Equals(localName))
				{
					throw new Exception51("Invalid element '" + localName + "' in namespace: " + uri);
				}
				string text2 = attributes.imethod_5("id");
				string uri2 = attributes.imethod_5("uri");
				string value2 = attributes.imethod_5("show-destination");
				bool newWindow = "new".Equals(value2);
				Class5351 class3 = new Class5351(uri2, newWindow);
				if (text2 != null)
				{
					class3.method_0(text2);
				}
				if (interface244_0 != null)
				{
					class3.method_2(interface244_0);
				}
				stack_0.Push(class3);
			}
			flag = true;
		}
		if (!flag && "http://xmlgraphics.apache.org/fop/intermediate/document-navigation".Equals(uri))
		{
			throw new Exception51("Unhandled element '" + localName + "' in namespace: " + uri);
		}
	}

	public void method_1(string uri, string localName, string qName)
	{
		if ("http://xmlgraphics.apache.org/fop/intermediate/document-navigation".Equals(uri))
		{
			try
			{
				if (Class5355.class5619_0.method_2().Equals(localName))
				{
					Class5354 tree = (Class5354)stack_0.Pop();
					if (method_2())
					{
						interface198_0.imethod_1(tree);
					}
				}
				else if (Class5355.class5619_1.method_2().Equals(localName))
				{
					if (stack_0.Peek() is Class5349)
					{
						Class5349 action = (Class5349)stack_0.Pop();
						Class5353 @class = (Class5353)stack_0.Pop();
						@class.method_3(action);
					}
					else
					{
						stack_0.Pop();
					}
				}
				else if (Class5355.class5619_2.method_2().Equals(localName))
				{
					Class5349 action2 = (Class5349)stack_0.Pop();
					Class5357 class2 = (Class5357)stack_0.Pop();
					class2.method_2(action2);
					if (method_2())
					{
						interface198_0.imethod_0(class2);
					}
				}
				else if (Class5355.class5619_3.method_2().Equals(localName))
				{
					Class5349 action3 = (Class5349)stack_0.Pop();
					Class5356 class3 = (Class5356)stack_0.Pop();
					class3.method_2(action3);
					if (method_2())
					{
						interface198_0.imethod_2(class3);
					}
				}
				else if (localName.StartsWith("goto-") && stack_0.Count == 1)
				{
					Class5349 action4 = (Class5349)stack_0.Pop();
					if (method_2())
					{
						interface198_0.imethod_3(action4);
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception51(ex.Message);
			}
		}
		stringBuilder_0.Length = 0;
		stringBuilder_0.Capacity = 0;
	}

	private bool method_2()
	{
		return interface198_0 != null;
	}

	public void method_3(char[] ch, int start, int length)
	{
		stringBuilder_0.Append(ch, start, length);
	}

	public void method_4()
	{
	}
}
