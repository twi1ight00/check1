using System;
using System.Collections;
using ns167;

namespace ns169;

internal class Class4813
{
	private class Class4814 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4779 @class = a as Class4779;
			Class4779 class2 = b as Class4779;
			if (@class != null && class2 != null)
			{
				float num = @class.Origin.Y - class2.Origin.Y;
				if (num < 0f)
				{
					return -1;
				}
				if (num > 0f)
				{
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Error in sorting of page text.");
		}
	}

	private class Class4815 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4779 @class = a as Class4779;
			Class4779 class2 = b as Class4779;
			if (@class != null && class2 != null)
			{
				float num = @class.Origin.X - class2.Origin.X;
				if (num < 0f)
				{
					return -1;
				}
				if (num > 0f)
				{
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Error in sorting of page text.");
		}
	}

	internal static void smethod_0(ArrayList severalTextPieces)
	{
		smethod_1(severalTextPieces, 0, severalTextPieces.Count);
	}

	internal static void smethod_1(ArrayList severalTextPieces, int startIndex, int count)
	{
		IComparer comparer = new Class4815();
		severalTextPieces.Sort(startIndex, count, comparer);
	}

	internal static void smethod_2(ArrayList textParts)
	{
		IComparer comparer = new Class4814();
		textParts.Sort(comparer);
	}
}
