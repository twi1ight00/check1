using System.Collections.Concurrent;
using System.Data.Objects;

namespace System.Data.Entity.Internal;

internal static class ObjectContextTypeCache
{
	private static readonly ConcurrentDictionary<Type, Type> TypeCache = new ConcurrentDictionary<Type, Type>();

	public static Type GetObjectType(Type type)
	{
		return TypeCache.GetOrAdd(type, ObjectContext.GetObjectType);
	}
}
