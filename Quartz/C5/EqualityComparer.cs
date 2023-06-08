using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace C5;

internal static class EqualityComparer<T>
{
	private static readonly Type isequenced = typeof(ISequenced<>);

	private static readonly Type icollection = typeof(ICollection<>);

	private static readonly Type orderedcollectionequalityComparer = typeof(SequencedCollectionEqualityComparer<, >);

	private static readonly Type unorderedcollectionequalityComparer = typeof(UnsequencedCollectionEqualityComparer<, >);

	private static readonly Type equalityequalityComparer = typeof(EquatableEqualityComparer<>);

	private static readonly Type iequalitytype = typeof(IEquatable<T>);

	private static IEqualityComparer<T> cachedDefault = null;

	[ComVisible(true)]
	public static IEqualityComparer<T> Default
	{
		[ComVisible(true)]
		get
		{
			if (cachedDefault != null)
			{
				return cachedDefault;
			}
			Type typeFromHandle = typeof(T);
			if (typeFromHandle.IsValueType)
			{
				if (typeFromHandle.Equals(typeof(char)))
				{
					return cachedDefault = (IEqualityComparer<T>)CharEqualityComparer.Default;
				}
				if (typeFromHandle.Equals(typeof(sbyte)))
				{
					return cachedDefault = (IEqualityComparer<T>)SByteEqualityComparer.Default;
				}
				if (typeFromHandle.Equals(typeof(byte)))
				{
					return cachedDefault = (IEqualityComparer<T>)ByteEqualityComparer.Default;
				}
				if (typeFromHandle.Equals(typeof(short)))
				{
					return cachedDefault = (IEqualityComparer<T>)ShortEqualityComparer.Default;
				}
				if (typeFromHandle.Equals(typeof(ushort)))
				{
					return cachedDefault = (IEqualityComparer<T>)UShortEqualityComparer.Default;
				}
				if (typeFromHandle.Equals(typeof(int)))
				{
					return cachedDefault = (IEqualityComparer<T>)IntEqualityComparer.Default;
				}
				if (typeFromHandle.Equals(typeof(uint)))
				{
					return cachedDefault = (IEqualityComparer<T>)UIntEqualityComparer.Default;
				}
				if (typeFromHandle.Equals(typeof(long)))
				{
					return cachedDefault = (IEqualityComparer<T>)LongEqualityComparer.Default;
				}
				if (typeFromHandle.Equals(typeof(ulong)))
				{
					return cachedDefault = (IEqualityComparer<T>)ULongEqualityComparer.Default;
				}
				if (typeFromHandle.Equals(typeof(float)))
				{
					return cachedDefault = (IEqualityComparer<T>)FloatEqualityComparer.Default;
				}
				if (typeFromHandle.Equals(typeof(double)))
				{
					return cachedDefault = (IEqualityComparer<T>)DoubleEqualityComparer.Default;
				}
				if (typeFromHandle.Equals(typeof(decimal)))
				{
					return cachedDefault = (IEqualityComparer<T>)DecimalEqualityComparer.Default;
				}
			}
			Type[] interfaces = typeFromHandle.GetInterfaces();
			if (typeFromHandle.IsGenericType && typeFromHandle.GetGenericTypeDefinition().Equals(isequenced))
			{
				return createAndCache(orderedcollectionequalityComparer.MakeGenericType(typeFromHandle, typeFromHandle.GetGenericArguments()[0]));
			}
			Type[] array = interfaces;
			foreach (Type type in array)
			{
				if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(isequenced))
				{
					return createAndCache(orderedcollectionequalityComparer.MakeGenericType(typeFromHandle, type.GetGenericArguments()[0]));
				}
			}
			if (typeFromHandle.IsGenericType && typeFromHandle.GetGenericTypeDefinition().Equals(icollection))
			{
				return createAndCache(unorderedcollectionequalityComparer.MakeGenericType(typeFromHandle, typeFromHandle.GetGenericArguments()[0]));
			}
			Type[] array2 = interfaces;
			foreach (Type type2 in array2)
			{
				if (type2.IsGenericType && type2.GetGenericTypeDefinition().Equals(icollection))
				{
					return createAndCache(unorderedcollectionequalityComparer.MakeGenericType(typeFromHandle, type2.GetGenericArguments()[0]));
				}
			}
			if (iequalitytype.IsAssignableFrom(typeFromHandle))
			{
				return createAndCache(equalityequalityComparer.MakeGenericType(typeFromHandle));
			}
			return cachedDefault = NaturalEqualityComparer<T>.Default;
		}
	}

	private static IEqualityComparer<T> createAndCache(Type equalityComparertype)
	{
		return cachedDefault = (IEqualityComparer<T>)equalityComparertype.GetProperty("Default", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);
	}
}
