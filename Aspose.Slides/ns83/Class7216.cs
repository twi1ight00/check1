using System;
using System.Collections;
using ns82;

namespace ns83;

internal abstract class Class7216 : Interface387
{
	protected IDictionary idictionary_0;

	protected int int_0 = 1;

	public virtual object imethod_3()
	{
		return imethod_0(null);
	}

	public virtual object imethod_4(Interface393 input, Interface392 start, Interface392 stop, Exception77 e)
	{
		return new Class7212(input, start, stop, e);
	}

	public virtual bool imethod_5(object tree)
	{
		return ((Interface386)tree).IsNil;
	}

	public virtual object imethod_2(object tree)
	{
		return vmethod_0(tree, null);
	}

	public virtual object vmethod_0(object t, object parent)
	{
		if (t == null)
		{
			return null;
		}
		object obj = imethod_1(t);
		imethod_29(obj, imethod_28(t));
		imethod_27(obj, parent);
		int num = imethod_25(t);
		for (int i = 0; i < num; i++)
		{
			object t2 = imethod_22(t, i);
			object child = vmethod_0(t2, t);
			imethod_6(obj, child);
		}
		return obj;
	}

	public virtual void imethod_6(object t, object child)
	{
		if (t != null && child != null)
		{
			((Interface386)t).imethod_2((Interface386)child);
		}
	}

	public virtual object imethod_7(object newRoot, object oldRoot)
	{
		Interface386 @interface = (Interface386)newRoot;
		Interface386 t = (Interface386)oldRoot;
		if (oldRoot == null)
		{
			return newRoot;
		}
		if (@interface.IsNil)
		{
			int childCount = @interface.ChildCount;
			if (childCount == 1)
			{
				@interface = @interface.imethod_1(0);
			}
			else if (childCount > 1)
			{
				throw new SystemException("more than one node as root (TODO: make exception hierarchy)");
			}
		}
		@interface.imethod_2(t);
		return @interface;
	}

	public virtual object imethod_8(object root)
	{
		Interface386 @interface = (Interface386)root;
		if (@interface != null && @interface.IsNil)
		{
			if (@interface.ChildCount == 0)
			{
				@interface = null;
			}
			else if (@interface.ChildCount == 1)
			{
				@interface = @interface.imethod_1(0);
				@interface.Parent = null;
				@interface.ChildIndex = -1;
			}
		}
		return @interface;
	}

	public virtual object imethod_10(Interface392 newRoot, object oldRoot)
	{
		return imethod_7(imethod_0(newRoot), oldRoot);
	}

	public virtual object imethod_11(int tokenType, Interface392 fromToken)
	{
		fromToken = vmethod_2(fromToken);
		fromToken.Type = tokenType;
		return (Interface386)imethod_0(fromToken);
	}

	public virtual object imethod_12(int tokenType, Interface392 fromToken, string text)
	{
		fromToken = vmethod_2(fromToken);
		fromToken.Type = tokenType;
		fromToken.Text = text;
		return (Interface386)imethod_0(fromToken);
	}

	public virtual object imethod_13(int tokenType, string text)
	{
		Interface392 param = vmethod_1(tokenType, text);
		return (Interface386)imethod_0(param);
	}

	public virtual int imethod_14(object t)
	{
		return 0;
	}

	public virtual void imethod_15(object t, int type)
	{
		throw new NotImplementedException("don't know enough about Tree node");
	}

	public virtual string imethod_16(object t)
	{
		return ((Interface386)t).Text;
	}

	public virtual void imethod_17(object t, string text)
	{
		throw new NotImplementedException("don't know enough about Tree node");
	}

	public virtual object imethod_22(object t, int i)
	{
		return ((Interface386)t).imethod_1(i);
	}

	public virtual void imethod_23(object t, int i, object child)
	{
		((Interface386)t).imethod_3(i, (Interface386)child);
	}

	public virtual object imethod_24(object t, int i)
	{
		return ((Interface386)t).imethod_4(i);
	}

	public virtual int imethod_25(object t)
	{
		return ((Interface386)t).ChildCount;
	}

	public abstract object imethod_1(object param1);

	public abstract object imethod_0(Interface392 param1);

	public abstract void imethod_19(object param1, Interface392 param2, Interface392 param3);

	public abstract int imethod_20(object t);

	public abstract int imethod_21(object t);

	public abstract Interface392 imethod_18(object treeNode);

	public int imethod_9(object node)
	{
		if (idictionary_0 == null)
		{
			idictionary_0 = new Hashtable();
		}
		object obj = idictionary_0[node];
		if (obj != null)
		{
			return (int)obj;
		}
		int num = int_0;
		idictionary_0[node] = num;
		int_0++;
		return num;
	}

	public abstract Interface392 vmethod_1(int tokenType, string text);

	public abstract Interface392 vmethod_2(Interface392 fromToken);

	public abstract object imethod_26(object t);

	public abstract void imethod_27(object t, object parent);

	public abstract int imethod_28(object t);

	public abstract void imethod_29(object t, int index);

	public abstract void imethod_30(object parent, int startChildIndex, int stopChildIndex, object t);
}
