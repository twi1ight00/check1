using System.Collections;
using System.Runtime.CompilerServices;

namespace ns4;

internal class Class1168 : Hashtable
{
	public Class1168()
	{
	}

	public Class1168(Class1168 otherSet)
		: base(otherSet)
	{
	}

	public Class1168(int capacity)
		: base(capacity)
	{
	}

	public Class1168(Class1168 otherSet, float loadFactor)
		: base(otherSet, loadFactor)
	{
	}

	public Class1168(IHashCodeProvider iHashCodeProvider, IComparer iComparer)
		: base(iHashCodeProvider, iComparer)
	{
	}

	public Class1168(int capacity, float loadFactor)
		: base(capacity, loadFactor)
	{
	}

	public Class1168(Class1168 otherSet, IHashCodeProvider iHashCodeProvider, IComparer iComparer)
		: base(otherSet, iHashCodeProvider, iComparer)
	{
	}

	public Class1168(int capacity, IHashCodeProvider iHashCodeProvider, IComparer iComparer)
		: base(capacity, iHashCodeProvider, iComparer)
	{
	}

	public Class1168(Class1168 otherSet, float loadFactor, IHashCodeProvider iHashCodeProvider, IComparer iComparer)
		: base(otherSet, loadFactor, iHashCodeProvider, iComparer)
	{
	}

	public Class1168(int capacity, float loadFactor, IHashCodeProvider iHashCodeProvider, IComparer iComparer)
		: base(capacity, loadFactor, iHashCodeProvider, iComparer)
	{
	}

	public void Add(object entry)
	{
		base.Add(entry, null);
	}

	private static Class1168 smethod_0(Class1168 iterSet, Class1168 containsSet, Class1168 startingSet, bool containment)
	{
		Class1168 @class = ((startingSet == null) ? new Class1168(iterSet.hcp, iterSet.comparer) : startingSet);
		foreach (object key in iterSet.Keys)
		{
			if (!(containment ^ containsSet.ContainsKey(key)))
			{
				@class.Add(key);
			}
		}
		return @class;
	}

	[SpecialName]
	public static Class1168 smethod_1(Class1168 set1, Class1168 set2)
	{
		Class1168 @class = new Class1168(set1, set1.hcp, set1.comparer);
		return smethod_0(set2, @class, @class, containment: false);
	}

	public Class1168 method_0(Class1168 otherSet)
	{
		return smethod_1(this, otherSet);
	}

	[SpecialName]
	public static Class1168 smethod_2(Class1168 set1, Class1168 set2)
	{
		return smethod_0((set1.Count > set2.Count) ? set2 : set1, (set1.Count > set2.Count) ? set1 : set2, null, containment: true);
	}

	public Class1168 method_1(Class1168 otherSet)
	{
		return smethod_2(this, otherSet);
	}

	[SpecialName]
	public static Class1168 smethod_3(Class1168 set1, Class1168 set2)
	{
		return smethod_0(set2, set1, smethod_0(set1, set2, null, containment: false), containment: false);
	}

	public Class1168 method_2(Class1168 otherSet)
	{
		return smethod_3(this, otherSet);
	}

	[SpecialName]
	public static Class1168 smethod_4(Class1168 set1, Class1168 set2)
	{
		return smethod_0(set1, set2, null, containment: false);
	}

	public Class1168 method_3(Class1168 otherSet)
	{
		return smethod_4(this, otherSet);
	}
}
