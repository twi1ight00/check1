using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Quartz.Collection;

/// <summary>
/// A wrapper for generic HashSet that brings a common interface.
/// </summary>
/// <typeparam name="T"></typeparam>
[Serializable]
public class HashSet<T> : System.Collections.Generic.HashSet<T>, ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	public HashSet()
	{
	}

	public HashSet(IEnumerable<T> collection)
		: base(collection)
	{
	}

	protected HashSet(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
