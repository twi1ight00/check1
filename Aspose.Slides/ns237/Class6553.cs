using System;
using System.Collections;
using ns223;
using ns224;

namespace ns237;

internal class Class6553
{
	private class Class6554
	{
		private Class6555 class6555_0;

		private Class6525 class6525_0;

		public Class6525 Pattern => class6525_0;

		public Class6555 Key => class6555_0;

		public Class6554(Class6555 key, Class6525 pattern)
		{
			class6555_0 = key;
			class6525_0 = pattern;
		}

		public override int GetHashCode()
		{
			return class6555_0.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			Class6555 @class = obj as Class6555;
			if (!object.ReferenceEquals(null, @class))
			{
				return Key.Equals(@class);
			}
			Class6554 class2 = obj as Class6554;
			if (!object.ReferenceEquals(null, class2))
			{
				return Key.Equals(class2.Key);
			}
			return false;
		}
	}

	private abstract class Class6555
	{
		public override bool Equals(object obj)
		{
			return vmethod_0(obj as Class6555);
		}

		protected abstract bool vmethod_0(Class6555 key);
	}

	private class Class6556 : Class6555
	{
		private Class5995 class5995_0;

		private int int_0;

		public Class6556(Class5995 brush)
		{
			class5995_0 = brush;
			int hashCode = brush.ImageArea.GetHashCode();
			int num = 137;
			using (Class5983 @class = new Class5983())
			{
				byte[] array = @class.ComputeHash(brush.ImageBytes);
				foreach (byte b in array)
				{
					num = (13 * num) ^ b.GetHashCode();
				}
			}
			int hashCode2 = brush.Opacity.GetHashCode();
			int hashCode3 = brush.Transform.GetHashCode();
			int hashCode4 = brush.WrapMode.GetHashCode();
			int num2;
			if (brush.ColorMap != null)
			{
				num2 = 137;
				Class5998[] colorMap = brush.ColorMap;
				foreach (Class5998 class2 in colorMap)
				{
					num2 = (13 * num2) ^ class2.GetHashCode();
				}
			}
			else
			{
				num2 = -1;
			}
			int_0 = 137;
			int_0 = (13 * int_0) ^ hashCode;
			int_0 = (13 * int_0) ^ num;
			int_0 = (13 * int_0) ^ hashCode2;
			int_0 = (13 * int_0) ^ hashCode3;
			int_0 = (13 * int_0) ^ hashCode4;
			int_0 = (13 * int_0) ^ num2;
		}

		public override int GetHashCode()
		{
			return int_0;
		}

		protected override bool vmethod_0(Class6555 key)
		{
			Class6556 @class = key as Class6556;
			if (object.ReferenceEquals(null, @class))
			{
				return false;
			}
			return int_0.Equals(@class.int_0);
		}
	}

	private readonly Hashtable hashtable_0 = new Hashtable();

	public static bool smethod_0(Class5990 brush)
	{
		if (Enum746.const_2 == brush.BrushType)
		{
			return true;
		}
		return false;
	}

	public bool Contains(Class5990 brush)
	{
		return hashtable_0.Contains(smethod_1(brush));
	}

	public void Add(Class5990 brush, Class6525 pattern)
	{
		if (Enum746.const_2 != brush.BrushType)
		{
			throw new NotSupportedException($"{brush.BrushType} is not supported for caching.");
		}
		Class6555 key = smethod_1(brush);
		if (hashtable_0.Contains(key))
		{
			throw new ArgumentException("An element with the same key already exists.");
		}
		hashtable_0.Add(key, new Class6554(key, pattern));
	}

	public Class6525 method_0(Class5990 brush)
	{
		Class6555 key = smethod_1(brush);
		if (hashtable_0.Contains(key))
		{
			return ((Class6554)hashtable_0[key]).Pattern;
		}
		return null;
	}

	private static Class6555 smethod_1(Class5990 brush)
	{
		if (Enum746.const_2 != brush.BrushType)
		{
			throw new NotSupportedException($"{brush.BrushType} is not supported for caching.");
		}
		return new Class6556((Class5995)brush);
	}
}
