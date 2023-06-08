using System;
using System.Collections;
using Aspose.JavaScript;
using ns322;
using ns329;

namespace ns328;

internal abstract class Class7691
{
	private static Hashtable hashtable_0;

	private static object object_0 = new object();

	private static Hashtable Helpers
	{
		get
		{
			if (hashtable_0 == null)
			{
				lock (object_0)
				{
					if (hashtable_0 == null)
					{
						Hashtable hashtable = new Hashtable();
						hashtable.Add(typeof(Enum985), new Class7693());
						hashtable.Add(typeof(BinaryExpressionType), new Class7692());
						hashtable_0 = hashtable;
					}
				}
			}
			return hashtable_0;
		}
	}

	public abstract string vmethod_0(Enum @enum);

	public static Class7691 smethod_0(Type type)
	{
		if (!Helpers.ContainsKey(type))
		{
			throw new InvalidOperationException();
		}
		return (Class7691)Helpers[type];
	}
}
