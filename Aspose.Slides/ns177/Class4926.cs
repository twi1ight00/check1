using System;
using System.Collections;
using System.IO;
using ns178;

namespace ns177;

internal class Class4926
{
	private class Class4928 : Class4927
	{
		private Class4935 class4935_0;

		private Stack stack_0 = new Stack();

		public Class4928(Class4935 model)
		{
			class4935_0 = model;
		}

		public override void imethod_6(string uri, string localName, string qName, Interface236 attributes)
		{
			try
			{
				if ("event-model".Equals(localName))
				{
					if (stack_0.Count > 0)
					{
						throw new Exception51("event-model must be the root element");
					}
					stack_0.Push(class4935_0);
					return;
				}
				if ("producer".Equals(localName))
				{
					Class4984 @class = new Class4984(attributes.imethod_5("name"));
					Class4935 class2 = (Class4935)stack_0.Peek();
					class2.method_0(@class);
					stack_0.Push(@class);
					return;
				}
				if ("method".Equals(localName))
				{
					Class5598 severity = Class5598.smethod_0(attributes.imethod_5("severity"));
					string text = attributes.imethod_5("exception");
					Class4933 class3 = new Class4933(attributes.imethod_5("name"), severity);
					if (text != null && text.Length > 0)
					{
						class3.method_7(text);
					}
					Class4984 class4 = (Class4984)stack_0.Peek();
					class4.method_2(class3);
					stack_0.Push(class3);
					return;
				}
				if ("parameter".Equals(localName))
				{
					string text2 = attributes.imethod_5("type");
					Type type;
					try
					{
						type = Type.GetType(text2);
					}
					catch (TypeLoadException)
					{
						throw new Exception51("Could not find Class for: " + text2);
					}
					string name = attributes.imethod_5("name");
					Class4933 class5 = (Class4933)stack_0.Peek();
					stack_0.Push(class5.method_1(type, name));
					return;
				}
				throw new Exception51("Invalid element: " + qName);
			}
			catch (Exception)
			{
				throw new Exception51("XML format error: " + qName);
			}
		}

		public override void imethod_7(string uri, string localName, string qName)
		{
			stack_0.Pop();
		}
	}

	private Class4926()
	{
	}

	public static Class4935 smethod_0(string src)
	{
		Class4935 @class = new Class4935();
		Class5692 class2 = new Class5692();
		class2.method_1(smethod_1(@class));
		class2.method_2(src, Path.GetDirectoryName(src));
		return @class;
	}

	public static Interface153 smethod_1(Class4935 model)
	{
		return new Class4928(model);
	}
}
