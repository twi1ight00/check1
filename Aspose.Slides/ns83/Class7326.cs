using System;
using System.Collections;
using System.Text;
using ns82;
using ns96;

namespace ns83;

internal class Class7326 : Interface388, Interface389
{
	protected class Class7327
	{
		protected internal int int_0;

		protected internal int int_1;

		protected internal object object_0;

		protected internal object object_1;

		protected internal int int_2;

		protected internal int int_3;

		protected internal object[] object_2;
	}

	public const int int_0 = 5;

	private Interface386 interface386_0;

	protected bool bool_0;

	protected internal object object_0;

	protected Interface393 interface393_0;

	private Interface387 interface387_0;

	protected internal Class7209 class7209_0 = new Class7209();

	protected internal Class7209 class7209_1 = new Class7209();

	protected internal object object_1;

	protected internal object object_2;

	protected internal int int_1;

	protected int int_2;

	protected internal object[] object_3 = new object[5];

	protected internal int int_3;

	protected internal int int_4;

	protected IList ilist_0;

	protected int int_5;

	protected int int_6;

	protected object object_4;

	protected object object_5;

	protected object object_6;

	public virtual object TreeSource => object_0;

	public virtual object Current => interface386_0;

	public Interface387 TreeAdaptor => interface387_0;

	public string SourceName => TokenStream.SourceName;

	public Interface393 TokenStream
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

	protected int LookaheadSize
	{
		get
		{
			if (int_4 >= int_3)
			{
				return int_4 - int_3;
			}
			return object_3.Length - int_3 + int_4;
		}
	}

	public virtual void Reset()
	{
		object_1 = object_0;
		object_2 = null;
		int_1 = -1;
		int_2 = -1;
		int_4 = 0;
		int_3 = 0;
	}

	public virtual bool MoveNext()
	{
		if (object_1 == null)
		{
			vmethod_1(object_6);
			interface386_0 = null;
			return false;
		}
		if (int_1 == -1)
		{
			interface386_0 = (Interface386)vmethod_2();
			return true;
		}
		if (int_1 < interface387_0.imethod_25(object_1))
		{
			interface386_0 = (Interface386)vmethod_3(int_1);
			return true;
		}
		vmethod_5();
		if (object_1 != null)
		{
			interface386_0 = (Interface386)vmethod_3(int_1);
			return true;
		}
		return false;
	}

	public Class7326(object tree)
		: this(new Class7217(), tree)
	{
	}

	public Class7326(Interface387 adaptor, object tree)
	{
		object_0 = tree;
		interface387_0 = adaptor;
		Reset();
		object_4 = adaptor.imethod_13(2, "DOWN");
		object_5 = adaptor.imethod_13(3, "UP");
		object_6 = adaptor.imethod_13(Class7346.int_7, "EOF");
	}

	public virtual object imethod_8(int i)
	{
		throw new NotSupportedException("stream is unbuffered");
	}

	public virtual object imethod_9(int k)
	{
		if (k == -1)
		{
			return object_2;
		}
		if (k < 0)
		{
			throw new ArgumentNullException("tree node streams cannot look backwards more than 1 node", "k");
		}
		if (k == 0)
		{
			return Class7221.interface386_0;
		}
		vmethod_0(k);
		return object_3[(int_3 + k - 1) % object_3.Length];
	}

	protected internal virtual void vmethod_0(int k)
	{
		int lookaheadSize = LookaheadSize;
		for (int i = 1; i <= k - lookaheadSize; i++)
		{
			MoveNext();
		}
	}

	protected internal virtual void vmethod_1(object node)
	{
		object_3[int_4] = node;
		int_4 = (int_4 + 1) % object_3.Length;
		if (int_4 == int_3)
		{
			object[] destinationArray = new object[2 * object_3.Length];
			int num = object_3.Length - int_3;
			Array.Copy(object_3, int_3, destinationArray, 0, num);
			Array.Copy(object_3, 0, destinationArray, num, int_4);
			object_3 = destinationArray;
			int_3 = 0;
			int_4 += num;
		}
	}

	public virtual void imethod_0()
	{
		vmethod_0(1);
		int_2++;
		object_2 = object_3[int_3];
		int_3 = (int_3 + 1) % object_3.Length;
	}

	public virtual int imethod_1(int i)
	{
		object obj = (Interface386)imethod_9(i);
		if (obj == null)
		{
			return 0;
		}
		return interface387_0.imethod_14(obj);
	}

	public virtual int imethod_2()
	{
		if (ilist_0 == null)
		{
			ilist_0 = new ArrayList();
			ilist_0.Add(null);
		}
		int_5++;
		Class7327 @class = null;
		if (int_5 >= ilist_0.Count)
		{
			@class = new Class7327();
			ilist_0.Add(@class);
		}
		else
		{
			@class = (Class7327)ilist_0[int_5];
		}
		@class.int_1 = int_2;
		@class.int_0 = int_1;
		@class.object_0 = object_1;
		@class.object_1 = object_2;
		@class.int_2 = class7209_0.Count;
		@class.int_3 = class7209_1.Count;
		int lookaheadSize = LookaheadSize;
		int num = 0;
		@class.object_2 = new object[lookaheadSize];
		int num2 = 1;
		while (num2 <= lookaheadSize)
		{
			@class.object_2[num] = imethod_9(num2);
			num2++;
			num++;
		}
		int_6 = int_5;
		return int_5;
	}

	public virtual void imethod_6(int marker)
	{
		int_5 = marker;
		int_5--;
	}

	public virtual void imethod_4(int marker)
	{
		if (ilist_0 != null)
		{
			Class7327 @class = (Class7327)ilist_0[marker];
			int_2 = @class.int_1;
			int_1 = @class.int_0;
			object_1 = @class.object_0;
			object_2 = @class.object_1;
			class7209_0.Capacity = @class.int_2;
			class7209_1.Capacity = @class.int_3;
			int_4 = 0;
			for (int_3 = 0; int_4 < @class.object_2.Length; int_4++)
			{
				object_3[int_4] = @class.object_2[int_4];
			}
			imethod_6(marker);
		}
	}

	public void imethod_5()
	{
		imethod_4(int_6);
	}

	public virtual void Seek(int index)
	{
		if (index < imethod_3())
		{
			throw new ArgumentOutOfRangeException("can't seek backwards in node stream", "index");
		}
		while (imethod_3() < index)
		{
			imethod_0();
		}
	}

	public virtual int imethod_3()
	{
		return int_2 + 1;
	}

	public virtual int imethod_7()
	{
		Class7219 @class = new Class7219(object_0);
		return @class.imethod_7();
	}

	protected internal virtual object vmethod_2()
	{
		object obj = object_1;
		int_1 = 0;
		if (interface387_0.imethod_5(obj))
		{
			obj = vmethod_3(int_1);
		}
		else
		{
			vmethod_1(obj);
			if (interface387_0.imethod_25(object_1) == 0)
			{
				object_1 = null;
			}
		}
		return obj;
	}

	protected internal virtual object vmethod_3(int child)
	{
		object obj = null;
		class7209_0.method_0(object_1);
		class7209_1.method_0(child);
		if (child == 0 && !interface387_0.imethod_5(object_1))
		{
			vmethod_4(2);
		}
		object_1 = interface387_0.imethod_22(object_1, child);
		int_1 = 0;
		obj = object_1;
		vmethod_1(obj);
		vmethod_5();
		return obj;
	}

	protected internal virtual void vmethod_4(int ttype)
	{
		object obj = null;
		obj = ((ttype == 2) ? ((!HasUniqueNavigationNodes) ? object_4 : interface387_0.imethod_13(2, "DOWN")) : ((!HasUniqueNavigationNodes) ? object_5 : interface387_0.imethod_13(3, "UP")));
		vmethod_1(obj);
	}

	protected internal virtual void vmethod_5()
	{
		while (object_1 != null && int_1 >= interface387_0.imethod_25(object_1))
		{
			object_1 = class7209_0.method_1();
			if (object_1 == null)
			{
				break;
			}
			int_1 = (int)class7209_1.method_1();
			int_1++;
			if (int_1 >= interface387_0.imethod_25(object_1))
			{
				if (!interface387_0.imethod_5(object_1))
				{
					vmethod_4(3);
				}
				if (object_1 == object_0)
				{
					object_1 = null;
				}
			}
		}
	}

	public void imethod_10(object parent, int startChildIndex, int stopChildIndex, object t)
	{
		throw new NotSupportedException("can't do stream rewrites yet");
	}

	public override string ToString()
	{
		return ToString(object_0, null);
	}

	public virtual string ToString(object start, object stop)
	{
		if (start == null)
		{
			return null;
		}
		if (interface393_0 != null)
		{
			int num = interface387_0.imethod_20(start);
			int num2 = interface387_0.imethod_21(stop);
			num2 = ((stop == null || interface387_0.imethod_14(stop) != 3) ? (imethod_7() - 1) : interface387_0.imethod_21(start));
			return interface393_0.ToString(num, num2);
		}
		StringBuilder stringBuilder = new StringBuilder();
		vmethod_6(start, stop, stringBuilder);
		return stringBuilder.ToString();
	}

	protected internal virtual void vmethod_6(object p, object stop, StringBuilder buf)
	{
		if (!interface387_0.imethod_5(p))
		{
			string text = interface387_0.imethod_16(p);
			if (text == null)
			{
				text = " " + interface387_0.imethod_14(p);
			}
			buf.Append(text);
		}
		if (p != stop)
		{
			int num = interface387_0.imethod_25(p);
			if (num > 0 && !interface387_0.imethod_5(p))
			{
				buf.Append(" ");
				buf.Append(2);
			}
			for (int i = 0; i < num; i++)
			{
				object p2 = interface387_0.imethod_22(p, i);
				vmethod_6(p2, stop, buf);
			}
			if (num > 0 && !interface387_0.imethod_5(p))
			{
				buf.Append(" ");
				buf.Append(3);
			}
		}
	}
}
