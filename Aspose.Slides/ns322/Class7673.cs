using System;
using System.Collections;
using System.Text;

namespace ns322;

internal class Class7673 : ICollection, IEnumerable
{
	private class Class7674 : IEnumerator
	{
		private Class7673 class7673_0;

		private Class7675 class7675_0;

		private bool bool_0;

		public object Current => class7675_0;

		public Class7674(Class7673 list)
		{
			class7673_0 = list;
			bool_0 = true;
		}

		public bool MoveNext()
		{
			if (bool_0)
			{
				class7675_0 = class7673_0.class7675_0;
				bool_0 = false;
				return class7675_0 != null;
			}
			if (class7675_0 != null && class7675_0.Next != null)
			{
				class7675_0 = class7675_0.Next;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			bool_0 = true;
		}
	}

	private Class7675 class7675_0;

	private Class7675 class7675_1;

	private readonly object object_0 = new object();

	public int Count
	{
		get
		{
			int num = 0;
			for (Class7675 next = class7675_0; next != null; next = next.Next)
			{
				num++;
			}
			return num;
		}
	}

	public bool IsSynchronized => false;

	public object SyncRoot => object_0;

	public void method_0(object insertItem)
	{
		if (method_2())
		{
			class7675_0 = (class7675_1 = new Class7675(insertItem));
		}
		else
		{
			class7675_0 = new Class7675(insertItem, class7675_0);
		}
	}

	public void method_1(object insertItem)
	{
		if (method_2())
		{
			class7675_0 = (class7675_1 = new Class7675(insertItem));
			return;
		}
		Class7675 class2 = (class7675_1.Next = new Class7675(insertItem));
		class7675_1 = class2;
	}

	public bool method_2()
	{
		return class7675_0 == null;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder((!method_2()) ? $"[{Count}] = {{\n" : string.Empty);
		for (Class7675 next = class7675_0; next != null; next = next.Next)
		{
			stringBuilder.AppendLine(next.Data.ToString());
		}
		if (!method_2())
		{
			stringBuilder.Append("}");
		}
		return stringBuilder.ToString();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Class7674(this);
	}

	public void CopyTo(Array array, int index)
	{
		foreach (Class7675 item in (IEnumerable)this)
		{
			array.SetValue(item, index++);
		}
	}
}
