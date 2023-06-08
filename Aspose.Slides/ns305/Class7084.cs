using System;
using System.Collections.Generic;
using ns307;
using ns308;

namespace ns305;

internal class Class7084 : Class7075, IDisposable
{
	private Class6976 class6976_0;

	private Class7067 class7067_0;

	public override Class6976 this[int index]
	{
		get
		{
			if (index >= 0 && index <= Length)
			{
				using (Interface372 @interface = ((Interface368)class6976_0.OwnerDocument).imethod_1(class6976_0, 1, (Interface370)class7067_0, entityReferenceExpansion: false))
				{
					Class6976 result;
					while (true)
					{
						result = @interface.imethod_6();
						if (index == 0)
						{
							break;
						}
						index--;
					}
					return result;
				}
			}
			return null;
		}
	}

	public override int Length
	{
		get
		{
			int num = 0;
			using Interface372 @interface = ((Interface368)class6976_0.OwnerDocument).imethod_1(class6976_0, 1, (Interface370)class7067_0, entityReferenceExpansion: false);
			while (true)
			{
				Class6976 @class = @interface.imethod_6();
				if (@class != null)
				{
					num++;
					continue;
				}
				break;
			}
			return num;
		}
	}

	public Class7084(Class6976 element)
	{
		class6976_0 = element;
		class7067_0 = null;
	}

	public Class7084(Class6976 element, string name)
	{
		class6976_0 = element;
		class7067_0 = new Class7067(name.ToUpper(), element.OwnerDocument.NameTable.Add("*"));
	}

	public Class7084(Class6976 element, string name, IEnumerable<KeyValuePair<string, string>> attrs, Enum964 options)
	{
		class6976_0 = element;
		class7067_0 = new Class7068(name.ToUpper(), attrs, options, element.OwnerDocument.NameTable.Add("*"));
	}

	public Class7084(Class6976 element, IEnumerable<string> nameCollection)
	{
		class6976_0 = element;
		class7067_0 = new Class7067(nameCollection, element.OwnerDocument.NameTable.Add("*"));
	}

	public Class7084(Class6976 element, IDictionary<string, IEnumerable<KeyValuePair<string, string>>> nameAttrsCollection, Enum964 options)
	{
		class6976_0 = element;
		class7067_0 = new Class7068(nameAttrsCollection, options, element.OwnerDocument.NameTable.Add("*"));
	}

	public Class7084(Class6976 element, string namespaceUri, string localName)
	{
		class6976_0 = element;
		class7067_0 = new Class7067(namespaceUri, localName, element.OwnerDocument.NameTable.Add("*"));
	}

	public Class7084(Class6976 element, string namespaceUri, string localName, IEnumerable<KeyValuePair<string, string>> attrs, Enum964 options)
	{
		class6976_0 = element;
		class7067_0 = new Class7068(namespaceUri, localName, attrs, options, element.OwnerDocument.NameTable.Add("*"));
	}

	public Class7084(Class6976 element, IEnumerable<KeyValuePair<string, string>> nameAndNsCollection)
	{
		class6976_0 = element;
		class7067_0 = new Class7067(nameAndNsCollection, element.OwnerDocument.NameTable.Add("*"));
	}

	public Class7084(Class6976 element, IDictionary<KeyValuePair<string, string>, IEnumerable<KeyValuePair<string, string>>> nameNsAndAttrCollection, Enum964 options)
	{
		class6976_0 = element;
		class7067_0 = new Class7068(nameNsAndAttrCollection, options, element.OwnerDocument.NameTable.Add("*"));
	}

	public override IEnumerator<Class6976> GetEnumerator()
	{
		Interface372 treeWalker = ((Interface368)class6976_0.OwnerDocument).imethod_1(class6976_0, 1, (Interface370)class7067_0, entityReferenceExpansion: false);
		return new Class7074(treeWalker);
	}

	public void Dispose()
	{
		class6976_0 = null;
		class7067_0 = null;
	}
}
