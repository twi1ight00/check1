using System;
using System.Collections.Generic;
using System.Diagnostics;
using ns56;

namespace ns8;

internal abstract class Class116
{
	private Class849 class849_0;

	private Class116 class116_0;

	private Class850 class850_0;

	private Class1351 class1351_0;

	public Class116 Parent => class116_0;

	public int Level
	{
		get
		{
			if (class116_0 == null)
			{
				return 0;
			}
			Class116 @class = class116_0;
			int num = 1;
			while (@class.class116_0 != null)
			{
				@class = @class.class116_0;
				num++;
			}
			return num;
		}
	}

	public Class850 Children
	{
		get
		{
			if (class850_0 == null)
			{
				class850_0 = new Class850();
			}
			return class850_0;
		}
	}

	public Class849 Tree => class849_0;

	public virtual string Name => string.Empty;

	protected Class1351 DataNode => class1351_0;

	public static Class116 smethod_0(Class849 tree, Class1351 dataNode, Class116 parent)
	{
		Class116 @class = null;
		if (dataNode is Class2171)
		{
			@class = new Class135(tree, (Class2171)dataNode);
		}
		else if (dataNode is Class2169)
		{
			@class = new Class133(tree, (Class2169)dataNode);
		}
		else if (dataNode is Class2146)
		{
			@class = Class120.smethod_3((Class2146)dataNode);
		}
		else if (dataNode is Class2178)
		{
			@class = new Class134((Class2178)dataNode);
		}
		else if (dataNode is Class2188)
		{
			@class = new Class136((Class2188)dataNode);
		}
		else if (dataNode is Class2157)
		{
			@class = new Class132((Class2157)dataNode);
		}
		else if (dataNode is Class2154)
		{
			@class = new Class131(tree, (Class2154)dataNode);
		}
		else if (dataNode is Class2172)
		{
			@class = new Class137((Class2172)dataNode);
		}
		else if (dataNode is Class2182)
		{
			@class = new Class119((Class2182)dataNode);
		}
		else if (dataNode is Class2174)
		{
			@class = new Class118((Class2174)dataNode);
		}
		else if (dataNode is Class2156)
		{
			@class = new Class117((Class2156)dataNode);
		}
		if (@class != null)
		{
			@class.class849_0 = tree;
			@class.class116_0 = parent;
			@class.class1351_0 = dataNode;
			parent?.Children.Add(@class);
			if (dataNode is Class2171)
			{
				smethod_1(tree, ((Class2171)dataNode).ChildNodeList, @class);
			}
			else if (dataNode is Class2169)
			{
				smethod_1(tree, ((Class2169)dataNode).ChildNodeList, @class);
			}
			else if (dataNode is Class2182)
			{
				smethod_2(tree, ((Class2182)dataNode).RuleList, @class);
			}
			else if (dataNode is Class2157)
			{
				smethod_2(tree, ((Class2157)dataNode).ConstrList, @class);
			}
		}
		return @class;
	}

	private static void smethod_1(Class849 tree, IEnumerable<Class2605> children, Class116 parent)
	{
		foreach (Class2605 child in children)
		{
			smethod_0(tree, (Class1351)child.Object, parent);
		}
	}

	private static void smethod_2(Class849 tree, IEnumerable<Class1351> children, Class116 parent)
	{
		foreach (Class1351 child in children)
		{
			smethod_0(tree, child, parent);
		}
	}

	public Class116 method_0(Class116 newParent)
	{
		Class116 @class = smethod_0(Tree, class1351_0, newParent);
		@class.class116_0 = newParent;
		return @class;
	}

	public virtual void vmethod_0(Class837 parent, Class836 context)
	{
	}

	public void method_1()
	{
		vmethod_1();
		foreach (Class116 child in Children)
		{
			child.method_1();
		}
	}

	public override string ToString()
	{
		return $"{GetType().Name} ({Name})";
	}

	[Conditional("DEBUG")]
	public virtual void Print(string margin)
	{
		Console.WriteLine(margin + ToString());
		if (Children.Count <= 0)
		{
			return;
		}
		margin += "  ";
		foreach (Class116 child in Children)
		{
			_ = child;
		}
	}

	public T method_2<T>(Class836 dataContext, Class837 presentationContext) where T : Class116
	{
		Type typeFromHandle = typeof(T);
		foreach (Class116 child in Children)
		{
			if (typeFromHandle.IsAssignableFrom(child.GetType()))
			{
				return (T)child;
			}
		}
		foreach (Class116 child2 in Children)
		{
			if (child2 is Class131 class3)
			{
				Class116 class4 = class3.method_6(typeFromHandle, dataContext, presentationContext);
				if (class4 != null)
				{
					return (T)class4;
				}
			}
		}
		return null;
	}

	public T method_3<T>() where T : Class116
	{
		Class116 parent = Parent;
		Type typeFromHandle = typeof(T);
		while (parent != null && !typeFromHandle.IsAssignableFrom(parent.GetType()))
		{
			parent = parent.Parent;
		}
		if (parent != null && typeFromHandle.IsAssignableFrom(parent.GetType()))
		{
			return (T)parent;
		}
		return null;
	}

	public Class116 method_4(Class116 root, string name)
	{
		foreach (Class116 child in root.Children)
		{
			if (child.Name == name)
			{
				return child;
			}
		}
		foreach (Class116 child2 in root.Children)
		{
			Class116 class2 = method_4(child2, name);
			if (class2 != null)
			{
				return class2;
			}
		}
		return null;
	}

	protected virtual void vmethod_1()
	{
	}
}
