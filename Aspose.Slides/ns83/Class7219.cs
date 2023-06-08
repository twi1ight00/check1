using System;
using System.Collections;
using System.Text;
using ns82;
using ns96;

namespace ns83;

internal class Class7219 : IEnumerable, Interface388, Interface389
{
	protected sealed class Class7220 : IEnumerator
	{
		private Class7219 class7219_0;

		private int int_0;

		private object object_0;

		public object Current
		{
			get
			{
				if (object_0 == null)
				{
					throw new InvalidOperationException("Enumeration has either not started or has already finished.");
				}
				return object_0;
			}
		}

		internal Class7220()
		{
		}

		internal Class7220(Class7219 nodeStream)
		{
			class7219_0 = nodeStream;
			Reset();
		}

		public void Reset()
		{
			int_0 = 0;
			object_0 = null;
		}

		public bool MoveNext()
		{
			if (int_0 >= class7219_0.ilist_0.Count)
			{
				int num = int_0;
				int_0++;
				if (num < class7219_0.ilist_0.Count)
				{
					object_0 = class7219_0.ilist_0[num];
				}
				object_0 = class7219_0.object_2;
				return true;
			}
			object_0 = null;
			return false;
		}
	}

	public const int int_0 = 100;

	public const int int_1 = 10;

	protected object object_0;

	protected object object_1;

	protected object object_2;

	protected IList ilist_0;

	protected internal object object_3;

	protected Interface393 interface393_0;

	private Interface387 interface387_0;

	protected bool bool_0;

	protected int int_2 = -1;

	protected int int_3;

	protected Class7209 class7209_0;

	public virtual object CurrentSymbol => imethod_9(1);

	public virtual object TreeSource => object_3;

	public virtual string SourceName => TokenStream.SourceName;

	public virtual Interface393 TokenStream
	{
		get
		{
			return interface393_0;
		}
		set
		{
			interface393_0 = value;
		}
	}

	public Interface387 TreeAdaptor
	{
		get
		{
			return interface387_0;
		}
		set
		{
			interface387_0 = value;
		}
	}

	public bool HasUniqueNavigationNodes
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public IEnumerator GetEnumerator()
	{
		if (int_2 == -1)
		{
			method_0();
		}
		return new Class7220(this);
	}

	public Class7219(object tree)
		: this(new Class7217(), tree)
	{
	}

	public Class7219(Interface387 adaptor, object tree)
		: this(adaptor, tree, 100)
	{
	}

	public Class7219(Interface387 adaptor, object tree, int initialBufferSize)
	{
		object_3 = tree;
		interface387_0 = adaptor;
		ilist_0 = new ArrayList(initialBufferSize);
		object_0 = adaptor.imethod_13(2, "DOWN");
		object_1 = adaptor.imethod_13(3, "UP");
		object_2 = adaptor.imethod_13(Class7346.int_7, "EOF");
	}

	protected void method_0()
	{
		method_1(object_3);
		int_2 = 0;
	}

	public void method_1(object t)
	{
		bool flag;
		if (!(flag = interface387_0.imethod_5(t)))
		{
			ilist_0.Add(t);
		}
		int num = interface387_0.imethod_25(t);
		if (!flag && num > 0)
		{
			method_3(2);
		}
		for (int i = 0; i < num; i++)
		{
			object t2 = interface387_0.imethod_22(t, i);
			method_1(t2);
		}
		if (!flag && num > 0)
		{
			method_3(3);
		}
	}

	protected int method_2(object node)
	{
		if (int_2 == -1)
		{
			method_0();
		}
		int num = 0;
		while (true)
		{
			if (num < ilist_0.Count)
			{
				object obj = ilist_0[num];
				if (obj == node)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	protected void method_3(int ttype)
	{
		object obj = null;
		obj = ((ttype == 2) ? ((!HasUniqueNavigationNodes) ? object_0 : interface387_0.imethod_13(2, "DOWN")) : ((!HasUniqueNavigationNodes) ? object_1 : interface387_0.imethod_13(3, "UP")));
		ilist_0.Add(obj);
	}

	public object imethod_8(int i)
	{
		if (int_2 == -1)
		{
			method_0();
		}
		return ilist_0[i];
	}

	public object imethod_9(int k)
	{
		if (int_2 == -1)
		{
			method_0();
		}
		if (k == 0)
		{
			return null;
		}
		if (k < 0)
		{
			return method_4(-k);
		}
		if (int_2 + k - 1 >= ilist_0.Count)
		{
			return object_2;
		}
		return ilist_0[int_2 + k - 1];
	}

	protected object method_4(int k)
	{
		if (k == 0)
		{
			return null;
		}
		if (int_2 - k < 0)
		{
			return null;
		}
		return ilist_0[int_2 - k];
	}

	public void method_7(int index)
	{
		if (class7209_0 == null)
		{
			class7209_0 = new Class7209();
		}
		class7209_0.method_0(int_2);
		Seek(index);
	}

	public int method_8()
	{
		int num = (int)class7209_0.method_1();
		Seek(num);
		return num;
	}

	public void Reset()
	{
		int_2 = -1;
		int_3 = 0;
		if (class7209_0 != null)
		{
			class7209_0.Clear();
		}
	}

	public void imethod_10(object parent, int startChildIndex, int stopChildIndex, object t)
	{
		if (parent != null)
		{
			interface387_0.imethod_30(parent, startChildIndex, stopChildIndex, t);
		}
	}

	public virtual void imethod_0()
	{
		if (int_2 == -1)
		{
			method_0();
		}
		int_2++;
	}

	public virtual int imethod_1(int i)
	{
		return interface387_0.imethod_14(imethod_9(i));
	}

	public virtual int imethod_2()
	{
		if (int_2 == -1)
		{
			method_0();
		}
		int_3 = imethod_3();
		return int_3;
	}

	public virtual void imethod_6(int marker)
	{
	}

	public virtual void imethod_4(int marker)
	{
		Seek(marker);
	}

	public void imethod_5()
	{
		Seek(int_3);
	}

	public virtual void Seek(int index)
	{
		if (int_2 == -1)
		{
			method_0();
		}
		int_2 = index;
	}

	public virtual int imethod_3()
	{
		return int_2;
	}

	public virtual int imethod_7()
	{
		if (int_2 == -1)
		{
			method_0();
		}
		return ilist_0.Count;
	}

	public override string ToString()
	{
		if (int_2 == -1)
		{
			method_0();
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < ilist_0.Count; i++)
		{
			object t = ilist_0[i];
			stringBuilder.Append(" ");
			stringBuilder.Append(interface387_0.imethod_14(t));
		}
		return stringBuilder.ToString();
	}

	public string method_9(int start, int stop)
	{
		if (int_2 == -1)
		{
			method_0();
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = start; i < ilist_0.Count && i <= stop; i++)
		{
			object treeNode = ilist_0[i];
			stringBuilder.Append(" ");
			stringBuilder.Append(interface387_0.imethod_18(treeNode));
		}
		return stringBuilder.ToString();
	}

	public virtual string ToString(object start, object stop)
	{
		if (start != null && stop != null)
		{
			if (int_2 == -1)
			{
				method_0();
			}
			if (interface393_0 != null)
			{
				int num = interface387_0.imethod_20(start);
				int num2 = interface387_0.imethod_21(stop);
				if (interface387_0.imethod_14(stop) == 3)
				{
					num2 = interface387_0.imethod_21(start);
				}
				else if (interface387_0.imethod_14(stop) == Class7346.int_7)
				{
					num2 = imethod_7() - 2;
				}
				return interface393_0.ToString(num, num2);
			}
			object obj = null;
			int i;
			for (i = 0; i < ilist_0.Count; i++)
			{
				obj = ilist_0[i];
				if (obj == start)
				{
					break;
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			string text;
			for (obj = ilist_0[i]; obj != stop; obj = ilist_0[i])
			{
				text = interface387_0.imethod_16(obj);
				if (text == null)
				{
					text = " " + interface387_0.imethod_14(obj);
				}
				stringBuilder.Append(text);
				i++;
			}
			text = interface387_0.imethod_16(stop);
			if (text == null)
			{
				text = " " + interface387_0.imethod_14(stop);
			}
			stringBuilder.Append(text);
			return stringBuilder.ToString();
		}
		return null;
	}
}
