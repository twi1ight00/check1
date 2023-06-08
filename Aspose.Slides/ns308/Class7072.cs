using System;
using ns305;
using ns307;

namespace ns308;

internal class Class7072 : IDisposable, Interface371
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

	public Class7072(Class6976 root, int whatToShow, Interface370 filter, bool entityReferenceExpansion)
	{
		if (root == null)
		{
			throw new ArgumentNullException("root");
		}
		class6976_0 = root;
		int_0 = whatToShow;
		interface370_0 = filter;
		bool_0 = entityReferenceExpansion;
	}

	public Class6976 imethod_0()
	{
		method_0();
		Class6976 @class = ((class6976_1 != null) ? class6976_1.NextSibling : class6976_0);
		while (true)
		{
			if (@class != null)
			{
				if (Class7066.smethod_0(@class, int_0))
				{
					if (interface370_0 == null)
					{
						break;
					}
					short num = interface370_0.imethod_0(@class);
					if (num == 1)
					{
						return class6976_1 = @class;
					}
				}
				@class = @class.NextSibling;
				continue;
			}
			return @class;
		}
		return class6976_1 = @class;
	}

	public Class6976 imethod_1()
	{
		method_0();
		Class6976 @class = ((class6976_1 != null) ? class6976_1.PreviousSibling : class6976_0);
		while (true)
		{
			if (@class != null)
			{
				if (Class7066.smethod_0(@class, int_0))
				{
					if (interface370_0 == null)
					{
						break;
					}
					short num = interface370_0.imethod_0(@class);
					if (num == 1)
					{
						return class6976_1 = @class;
					}
				}
				@class = @class.PreviousSibling;
				continue;
			}
			return @class;
		}
		return class6976_1 = @class;
	}

	public void imethod_2()
	{
		bool_1 = true;
		class6976_1 = null;
	}

	private void method_0()
	{
		if (bool_1)
		{
			Exception73.smethod_0(Enum968.const_10);
		}
	}

	void IDisposable.Dispose()
	{
		imethod_2();
	}
}
