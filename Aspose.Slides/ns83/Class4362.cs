using System;
using System.Collections;
using System.Text;

namespace ns83;

internal abstract class Class4362 : Interface105
{
	protected IList ilist_0;

	public virtual int ChildCount
	{
		get
		{
			if (ilist_0 == null)
			{
				return 0;
			}
			return ilist_0.Count;
		}
	}

	public virtual bool IsNil => false;

	public virtual int Line => 0;

	public virtual int CharPositionInLine => 0;

	public IList Children => ilist_0;

	public virtual int ChildIndex
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public virtual Interface105 Parent
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public abstract int Type { get; }

	public abstract int TokenStartIndex { get; set; }

	public abstract int TokenStopIndex { get; set; }

	public abstract string Text { get; }

	public Class4362()
	{
	}

	public Class4362(Interface105 node)
	{
	}

	public virtual Interface105 imethod_1(int i)
	{
		if (ilist_0 != null && i < ilist_0.Count)
		{
			return (Class4362)ilist_0[i];
		}
		return null;
	}

	public virtual void imethod_2(Interface105 t)
	{
		if (t == null)
		{
			return;
		}
		Class4362 @class = (Class4362)t;
		if (@class.IsNil)
		{
			if (ilist_0 != null && ilist_0 == @class.ilist_0)
			{
				throw new InvalidOperationException("attempt to add child list to itself");
			}
			if (@class.ilist_0 == null)
			{
				return;
			}
			if (ilist_0 != null)
			{
				int count = @class.ilist_0.Count;
				for (int i = 0; i < count; i++)
				{
					Interface105 @interface = (Interface105)@class.Children[i];
					ilist_0.Add(@interface);
					@interface.Parent = this;
					@interface.ChildIndex = ilist_0.Count - 1;
				}
			}
			else
			{
				ilist_0 = @class.ilist_0;
				imethod_0();
			}
		}
		else
		{
			if (ilist_0 == null)
			{
				ilist_0 = vmethod_0();
			}
			ilist_0.Add(t);
			@class.Parent = this;
			@class.ChildIndex = ilist_0.Count - 1;
		}
	}

	public void method_0(IList kids)
	{
		for (int i = 0; i < kids.Count; i++)
		{
			Interface105 t = (Interface105)kids[i];
			imethod_2(t);
		}
	}

	public virtual void imethod_3(int i, Interface105 t)
	{
		if (t != null)
		{
			if (t.IsNil)
			{
				throw new ArgumentException("Can't set single child to a list");
			}
			if (ilist_0 == null)
			{
				ilist_0 = vmethod_0();
			}
			ilist_0[i] = t;
			t.Parent = this;
			t.ChildIndex = i;
		}
	}

	public virtual object imethod_4(int i)
	{
		if (ilist_0 == null)
		{
			return null;
		}
		Class4362 result = (Class4362)ilist_0[i];
		ilist_0.RemoveAt(i);
		vmethod_1(i);
		return result;
	}

	public virtual void imethod_5(int startChildIndex, int stopChildIndex, object t)
	{
		if (ilist_0 == null)
		{
			throw new ArgumentException("indexes invalid; no children in list");
		}
		int num = stopChildIndex - startChildIndex + 1;
		Class4362 @class = (Class4362)t;
		IList list;
		if (@class.IsNil)
		{
			list = @class.Children;
		}
		else
		{
			list = new ArrayList(1);
			list.Add(@class);
		}
		int count = list.Count;
		int count2 = list.Count;
		int num2 = num - count;
		if (num2 == 0)
		{
			int num3 = 0;
			for (int i = startChildIndex; i <= stopChildIndex; i++)
			{
				Class4362 class2 = (Class4362)list[num3];
				ilist_0[i] = class2;
				class2.Parent = this;
				class2.ChildIndex = i;
				num3++;
			}
		}
		else if (num2 > 0)
		{
			for (int j = 0; j < count2; j++)
			{
				ilist_0[startChildIndex + j] = list[j];
			}
			int num4 = startChildIndex + count2;
			for (int k = num4; k <= stopChildIndex; k++)
			{
				ilist_0.RemoveAt(num4);
			}
			vmethod_1(startChildIndex);
		}
		else
		{
			int l;
			for (l = 0; l < num; l++)
			{
				ilist_0[startChildIndex + l] = list[l];
			}
			for (; l < count; l++)
			{
				ilist_0.Insert(startChildIndex + l, list[l]);
			}
			vmethod_1(startChildIndex);
		}
	}

	protected internal virtual IList vmethod_0()
	{
		return new ArrayList();
	}

	public virtual void imethod_0()
	{
		vmethod_1(0);
	}

	public virtual void vmethod_1(int offset)
	{
		int childCount = ChildCount;
		for (int i = offset; i < childCount; i++)
		{
			Interface105 @interface = imethod_1(i);
			@interface.ChildIndex = i;
			@interface.Parent = this;
		}
	}

	public virtual void vmethod_2()
	{
		vmethod_3(null, -1);
	}

	public virtual void vmethod_3(Interface105 parent, int i)
	{
		if (parent != Parent)
		{
			throw new ArgumentException(string.Concat("parents don't match; expected ", parent, " found ", Parent));
		}
		if (i != ChildIndex)
		{
			throw new NotSupportedException("child indexes don't match; expected " + i + " found " + ChildIndex);
		}
		int childCount = ChildCount;
		for (int j = 0; j < childCount; j++)
		{
			Class4363 @class = (Class4363)imethod_1(j);
			@class.vmethod_3(this, j);
		}
	}

	public virtual string imethod_7()
	{
		if (ilist_0 != null && ilist_0.Count != 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (!IsNil)
			{
				stringBuilder.Append("(");
				stringBuilder.Append(ToString());
				stringBuilder.Append(' ');
			}
			int num = 0;
			while (ilist_0 != null && num < ilist_0.Count)
			{
				Class4362 @class = (Class4362)ilist_0[num];
				if (num > 0)
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(@class.imethod_7());
				num++;
			}
			if (!IsNil)
			{
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}
		return ToString();
	}

	public abstract override string ToString();

	public abstract Interface105 imethod_6();
}
