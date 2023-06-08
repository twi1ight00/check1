using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ns305;

internal class Class7091
{
	private class Class7092
	{
		private string string_0;

		private string string_1;

		public string NamespaceURI => string_0;

		public string Name => string_1;

		public Class7092(string namespaceURI, string name)
		{
			string_1 = name;
			string_0 = namespaceURI;
		}
	}

	[CompilerGenerated]
	private sealed class Class7093
	{
		public string string_0;

		public string string_1;

		public bool method_0(Class7092 entry)
		{
			if (entry.Name == string_1)
			{
				return entry.NamespaceURI == string_0;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class Class7094
	{
		public string string_0;

		public bool method_0(Class7092 entry)
		{
			return entry.Name == string_0;
		}
	}

	private List<Class7092> list_0;

	private List<Class7092> List
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<Class7092>();
			}
			return list_0;
		}
	}

	public int Length => List.Count;

	public void Add(string namespaceURI, string name)
	{
		int num = method_0(namespaceURI, namespaceURI);
		if (num == -1)
		{
			List.Add(new Class7092(namespaceURI, name));
		}
		else
		{
			List[num] = new Class7092(namespaceURI, name);
		}
	}

	private int method_0(string namespaceURI, string name)
	{
		return List.FindIndex((Class7092 entry) => entry.Name == name && entry.NamespaceURI == namespaceURI);
	}

	private int method_1(string name)
	{
		return List.FindIndex((Class7092 entry) => entry.Name == name);
	}

	public string method_2(int index)
	{
		return List[index].Name;
	}

	public string method_3(int index)
	{
		return List[index].NamespaceURI;
	}

	public bool Contains(string str)
	{
		return method_1(str) != -1;
	}

	public bool method_4(string namespaceURI, string name)
	{
		return method_0(namespaceURI, name) != -1;
	}
}
