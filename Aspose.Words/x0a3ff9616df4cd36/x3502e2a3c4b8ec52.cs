using System.Collections;
using x1c8faa688b1f0b0c;
using x8b1f7613579e78d0;
using xf84f8427dc22d095;

namespace x0a3ff9616df4cd36;

internal class x3502e2a3c4b8ec52
{
	internal static void xe42491110461872b(x72c34b8dbaec3734 xe058541ca798c059, ArrayList x45bd840e09b7c920, x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		ICollection collection = x1c74fa15a2f5cd1c.xb1451f746ac6e5cb(x45bd840e09b7c920);
		if (collection.Count == 0)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		foreach (x4e72ffd52a21c3db item in collection)
		{
			x173da201543be1fe value = item.xb5c45a878919d53b(xf1125c563ec28c45.x4b34cc8966adf8f7);
			arrayList.Add(value);
		}
		x2bfc048c6117997a[] array = new x2bfc048c6117997a[arrayList.Count];
		arrayList.CopyTo(array);
		xe058541ca798c059.x819589f292a61f6b = array;
	}
}
