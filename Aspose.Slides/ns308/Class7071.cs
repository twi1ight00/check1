using System;
using ns305;
using ns307;

namespace ns308;

internal class Class7071 : IDisposable, Interface372
{
	private Class6976 class6976_0;

	private int int_0;

	private Interface370 interface370_0;

	private bool bool_0;

	private Class6976 class6976_1;

	private bool bool_1;

	public Class6976 Root => class6976_0;

	public int WhatToShow => int_0;

	public Interface370 Filter => interface370_0;

	public bool ExpandEntityReferences => bool_0;

	public Class6976 CurrentNode
	{
		get
		{
			method_1();
			return class6976_1;
		}
		set
		{
			method_1();
			if (value == null || !method_0(value))
			{
				Exception73.smethod_0(Enum968.const_8);
			}
			class6976_1 = value;
		}
	}

	public Class7071(Class6976 root, int whatToShow, Interface370 filter, bool entityReferenceExpansion)
	{
		if (root == null)
		{
			throw new ArgumentNullException("root");
		}
		class6976_0 = root;
		int_0 = whatToShow;
		interface370_0 = filter;
		bool_0 = entityReferenceExpansion;
		class6976_1 = root;
	}

	private bool method_0(Class6976 node)
	{
		if (!Class7066.smethod_0(node, int_0))
		{
			return false;
		}
		if (interface370_0 != null)
		{
			return interface370_0.imethod_0(node) == 1;
		}
		return true;
	}

	public Class6976 imethod_0()
	{
		method_1();
		Class6976 parentNode = class6976_1;
		while (parentNode != class6976_0 && parentNode.ParentNode != null && parentNode.ParentNode != class6976_0)
		{
			parentNode = parentNode.ParentNode;
			if (method_0(parentNode))
			{
				return class6976_1 = parentNode;
			}
		}
		return null;
	}

	public Class6976 imethod_1()
	{
		method_1();
		Class6976 @class = class6976_1.FirstChild;
		while (@class != null && !method_0(@class))
		{
			@class = @class.NextSibling;
		}
		if (@class != null)
		{
			class6976_1 = @class;
		}
		return @class;
	}

	public Class6976 imethod_2()
	{
		method_1();
		Class6976 @class = class6976_1.LastChild;
		while (@class != null && !method_0(@class))
		{
			@class = @class.PreviousSibling;
		}
		if (@class != null)
		{
			class6976_1 = @class;
		}
		return @class;
	}

	public Class6976 imethod_3()
	{
		method_1();
		Class6976 previousSibling = class6976_1;
		while (previousSibling != null && !method_0(previousSibling))
		{
			previousSibling = previousSibling.PreviousSibling;
		}
		if (previousSibling != null)
		{
			class6976_1 = previousSibling;
		}
		return previousSibling;
	}

	public Class6976 imethod_4()
	{
		method_1();
		Class6976 nextSibling = class6976_1;
		while (nextSibling != null && !method_0(nextSibling))
		{
			nextSibling = nextSibling.NextSibling;
		}
		if (nextSibling != null)
		{
			class6976_1 = nextSibling;
		}
		return nextSibling;
	}

	public Class6976 imethod_5()
	{
		method_1();
		Class6976 @class = class6976_1;
		while (@class != null)
		{
			if (@class.PreviousSibling == null)
			{
				@class = ((@class.ParentNode == class6976_0 || @class.ParentNode == null) ? null : @class.ParentNode);
			}
			else
			{
				@class = @class.PreviousSibling;
				while (@class.LastChild != null)
				{
					@class = @class.LastChild;
				}
			}
			if (@class != null && method_0(@class))
			{
				break;
			}
		}
		if (@class != null)
		{
			class6976_1 = @class;
		}
		return @class;
	}

	public Class6976 imethod_6()
	{
		method_1();
		Class6976 @class = class6976_1;
		while (@class != null)
		{
			if (@class.FirstChild != null)
			{
				@class = @class.FirstChild;
			}
			else if (@class.NextSibling != null)
			{
				@class = @class.NextSibling;
			}
			else
			{
				while (@class != null)
				{
					if (@class.ParentNode != class6976_0 && @class.ParentNode != null)
					{
						if (@class.ParentNode.NextSibling == null)
						{
							@class = @class.ParentNode;
							continue;
						}
						@class = @class.ParentNode.NextSibling;
						break;
					}
					return null;
				}
			}
			if (@class != null && method_0(@class))
			{
				break;
			}
		}
		if (@class != null)
		{
			class6976_1 = @class;
		}
		return @class;
	}

	private void method_1()
	{
		if (bool_1)
		{
			Exception73.smethod_0(Enum968.const_10);
		}
	}

	void IDisposable.Dispose()
	{
		bool_1 = true;
		class6976_1 = null;
	}
}
