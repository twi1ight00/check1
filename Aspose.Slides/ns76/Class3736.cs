using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ns73;
using ns77;

namespace ns76;

[DebuggerDisplay("{MediaText}")]
internal class Class3736 : IEnumerable, IEnumerable<string>, IEnumerable<Interface80>, Interface79
{
	private List<string> list_0 = new List<string>();

	private List<Interface80> list_1 = new List<Interface80>();

	public string MediaText
	{
		get
		{
			if (Length == 0L)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(list_1[0].Text);
			for (int i = 1; i < Length; i++)
			{
				stringBuilder.Append(", ");
				stringBuilder.Append(list_1[i].Text);
			}
			return stringBuilder.ToString();
		}
	}

	public long Length => list_0.Count;

	string Interface79.this[int index]
	{
		get
		{
			if (index < 0 && index > list_0.Count - 1)
			{
				return null;
			}
			return list_0[index];
		}
	}

	public Interface80 this[int index]
	{
		get
		{
			if (index < 0 && index > list_0.Count - 1)
			{
				return null;
			}
			return list_1[index];
		}
	}

	public void imethod_0(string oldMedium)
	{
		int num = list_0.IndexOf(oldMedium);
		if (num != -1)
		{
			list_0.RemoveAt(num);
			list_1.RemoveAt(num);
		}
	}

	public void imethod_1(string newMedium)
	{
		int num = list_0.IndexOf(newMedium);
		if (num == -1)
		{
			list_0.Add(newMedium);
		}
	}

	public void Add(Interface80 expression)
	{
		list_1.Add(expression);
		list_0.Add(expression.Text);
	}

	public bool method_0(Class3677 device)
	{
		foreach (Interface80 item in list_1)
		{
			if (item.imethod_0(device))
			{
				return true;
			}
		}
		return false;
	}

	public IEnumerator<string> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator<Interface80> IEnumerable<Interface80>.GetEnumerator()
	{
		return list_1.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
