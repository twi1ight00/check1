using System;
using System.Collections;
using ns16;

namespace ns45;

internal class Class989 : IComparer
{
	private bool bool_0;

	internal Class989(bool bool_1)
	{
		bool_0 = bool_1;
	}

	public int Compare(object x, object y)
	{
		if (x is string)
		{
			if (y is string)
			{
				if (!bool_0)
				{
					return ((string)y).CompareTo((string)x);
				}
				return ((string)x).CompareTo((string)y);
			}
			if (y is double)
			{
				if (!bool_0)
				{
					return -1;
				}
				return 1;
			}
			if (y is int)
			{
				if (!bool_0)
				{
					return -1;
				}
				return 1;
			}
			if (y is DateTime)
			{
				if (!bool_0)
				{
					return 1;
				}
				return -1;
			}
			if (y == null)
			{
				if (!bool_0)
				{
					return 1;
				}
				return -1;
			}
		}
		else if (x is double)
		{
			if (y is string)
			{
				if (!bool_0)
				{
					return 1;
				}
				return -1;
			}
			if (y is double || y is int)
			{
				if (y is double)
				{
					if (!bool_0)
					{
						return ((double)y).CompareTo((double)x);
					}
					return ((double)x).CompareTo((double)y);
				}
				if (!bool_0)
				{
					return Class1618.smethod_85(Class1618.smethod_80((int)y)).CompareTo((double)x);
				}
				return ((double)x).CompareTo(Class1618.smethod_85(Class1618.smethod_80((int)y)));
			}
			if (y is DateTime)
			{
				if (!bool_0)
				{
					return 1;
				}
				return -1;
			}
			if (y == null)
			{
				if (!bool_0)
				{
					return 1;
				}
				return -1;
			}
		}
		else if (x is int)
		{
			if (y is string)
			{
				if (!bool_0)
				{
					return 1;
				}
				return -1;
			}
			if (y is double)
			{
				if (!bool_0)
				{
					return ((double)y).CompareTo(Class1618.smethod_85(Class1618.smethod_80((int)x)));
				}
				return Class1618.smethod_85(Class1618.smethod_80((int)x)).CompareTo((double)y);
			}
			if (y is int)
			{
				if (!bool_0)
				{
					return ((int)y).CompareTo((int)x);
				}
				return ((int)x).CompareTo((int)y);
			}
			if (y is DateTime)
			{
				if (!bool_0)
				{
					return 1;
				}
				return -1;
			}
			if (y == null)
			{
				if (!bool_0)
				{
					return 1;
				}
				return -1;
			}
		}
		else if (x is DateTime)
		{
			if (y is string)
			{
				if (!bool_0)
				{
					return -1;
				}
				return 1;
			}
			if (y is double)
			{
				if (!bool_0)
				{
					return -1;
				}
				return 1;
			}
			if (y is int)
			{
				if (!bool_0)
				{
					return -1;
				}
				return 1;
			}
			if (y is DateTime)
			{
				if (!bool_0)
				{
					return ((DateTime)y).CompareTo((DateTime)x);
				}
				return ((DateTime)x).CompareTo((DateTime)y);
			}
			if (y == null)
			{
				if (!bool_0)
				{
					return 1;
				}
				return -1;
			}
		}
		else if (x == null)
		{
			if (!bool_0)
			{
				return -1;
			}
			return 1;
		}
		if (!bool_0)
		{
			return -1;
		}
		return 1;
	}
}
