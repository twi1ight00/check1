using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal static class Comparer<T>
{
	private static readonly Type naturalComparerO = typeof(NaturalComparerO<>);

	private static readonly Type naturalComparer = typeof(NaturalComparer<>);

	private static IComparer<T> cachedComparer = null;

	[Tested]
	[ComVisible(true)]
	public static IComparer<T> Default
	{
		[ComVisible(true)]
		get
		{
			if (cachedComparer != null)
			{
				return cachedComparer;
			}
			Type typeFromHandle = typeof(T);
			if (typeFromHandle.IsValueType)
			{
				if (typeFromHandle.Equals(typeof(char)))
				{
					return cachedComparer = (IComparer<T>)new CharComparer();
				}
				if (typeFromHandle.Equals(typeof(sbyte)))
				{
					return cachedComparer = (IComparer<T>)new SByteComparer();
				}
				if (typeFromHandle.Equals(typeof(byte)))
				{
					return cachedComparer = (IComparer<T>)new ByteComparer();
				}
				if (typeFromHandle.Equals(typeof(short)))
				{
					return cachedComparer = (IComparer<T>)new ShortComparer();
				}
				if (typeFromHandle.Equals(typeof(ushort)))
				{
					return cachedComparer = (IComparer<T>)new UShortComparer();
				}
				if (typeFromHandle.Equals(typeof(int)))
				{
					return cachedComparer = (IComparer<T>)new IntComparer();
				}
				if (typeFromHandle.Equals(typeof(uint)))
				{
					return cachedComparer = (IComparer<T>)new UIntComparer();
				}
				if (typeFromHandle.Equals(typeof(long)))
				{
					return cachedComparer = (IComparer<T>)new LongComparer();
				}
				if (typeFromHandle.Equals(typeof(ulong)))
				{
					return cachedComparer = (IComparer<T>)new ULongComparer();
				}
				if (typeFromHandle.Equals(typeof(float)))
				{
					return cachedComparer = (IComparer<T>)new FloatComparer();
				}
				if (typeFromHandle.Equals(typeof(double)))
				{
					return cachedComparer = (IComparer<T>)new DoubleComparer();
				}
				if (typeFromHandle.Equals(typeof(decimal)))
				{
					return cachedComparer = (IComparer<T>)new DecimalComparer();
				}
			}
			if (typeof(IComparable<T>).IsAssignableFrom(typeFromHandle))
			{
				Type type = naturalComparer.MakeGenericType(typeFromHandle);
				return cachedComparer = (IComparer<T>)type.GetConstructor(Type.EmptyTypes).Invoke(null);
			}
			if ((object)typeFromHandle.GetInterface("System.IComparable") != null)
			{
				Type type2 = naturalComparerO.MakeGenericType(typeFromHandle);
				return cachedComparer = (IComparer<T>)type2.GetConstructor(Type.EmptyTypes).Invoke(null);
			}
			throw new NotComparableException($"Cannot make comparer for type {typeFromHandle}");
		}
	}
}
