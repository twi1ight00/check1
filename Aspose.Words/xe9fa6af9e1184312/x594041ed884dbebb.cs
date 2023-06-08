using System.Collections;
using x5794c252ba25e723;
using x7c4557e104065fc9;
using xf9a9481c3f63a419;

namespace xe9fa6af9e1184312;

internal class x594041ed884dbebb
{
	private readonly Hashtable x3755f17ef3f8758a = new Hashtable();

	private readonly x1fdc4491fb4c3ee8 x8cedcaa9a62c6e39;

	private static readonly Hashtable x6f9bbccfb67dfb8c;

	private static readonly ArrayList xede297d0cfee3b6a;

	internal x594041ed884dbebb(x1fdc4491fb4c3ee8 context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal string xe6904a2e41fd856a(x9189d7a3c7720a79 xad5ee812e0b28f28)
	{
		object obj = ((x3755f17ef3f8758a[xad5ee812e0b28f28] != null) ? x3755f17ef3f8758a[xad5ee812e0b28f28] : x6f9bbccfb67dfb8c[xad5ee812e0b28f28]);
		return (string)obj;
	}

	internal float xd2739c1eef410400(x9189d7a3c7720a79 xad5ee812e0b28f28)
	{
		string xe4115acdf4fbfccc = xe6904a2e41fd856a(xad5ee812e0b28f28);
		return (float)xca004f56614e2431.xf5ece46c5d72e3b9(xe4115acdf4fbfccc);
	}

	internal float x5e2b7763db325a7c(x9189d7a3c7720a79 xad5ee812e0b28f28)
	{
		string x41a4ba6d899b7c = xe6904a2e41fd856a(xad5ee812e0b28f28);
		return xf7e2753b1f50fb2b.xfd3c39adee96110c(x41a4ba6d899b7c, x8cedcaa9a62c6e39);
	}

	internal x26d9ecb4bdf0456d x9198d50dad3a0bf1(x9189d7a3c7720a79 xad5ee812e0b28f28)
	{
		string xbcea506a33cf = xe6904a2e41fd856a(xad5ee812e0b28f28);
		return x495fdb45f3d92b70.x722b70a5a6410b8c(xbcea506a33cf);
	}

	internal x594041ed884dbebb x8b61531c8ea35b85()
	{
		x594041ed884dbebb x594041ed884dbebb2 = new x594041ed884dbebb(x8cedcaa9a62c6e39);
		foreach (x9189d7a3c7720a79 item in xede297d0cfee3b6a)
		{
			object obj = x3755f17ef3f8758a[item];
			if (obj != null)
			{
				x594041ed884dbebb2.x3755f17ef3f8758a[item] = obj;
			}
		}
		return x594041ed884dbebb2;
	}

	internal void x1a417412416bdd23(string xc15bd84e01929885, string xbcea506a33cf9111)
	{
		x9189d7a3c7720a79 x9189d7a3c7720a80 = xf7e2753b1f50fb2b.x1308f09f2a749a06(xc15bd84e01929885);
		if (x9189d7a3c7720a80 != 0)
		{
			x3755f17ef3f8758a[x9189d7a3c7720a80] = xbcea506a33cf9111;
		}
	}

	internal void x11320bfcc1c4003d(string x44ecfea61c937b8e)
	{
		string[] array = x44ecfea61c937b8e.Split(';');
		string[] array2 = array;
		foreach (string text in array2)
		{
			string[] array3 = text.Split(':');
			if (array3.Length >= 2)
			{
				x9189d7a3c7720a79 x9189d7a3c7720a80 = xf7e2753b1f50fb2b.x1308f09f2a749a06(array3[0].Trim());
				if (x9189d7a3c7720a80 != 0 && !x3755f17ef3f8758a.Contains(x9189d7a3c7720a80))
				{
					x3755f17ef3f8758a[x9189d7a3c7720a80] = array3[1].Trim();
				}
			}
		}
	}

	static x594041ed884dbebb()
	{
		x6f9bbccfb67dfb8c = new Hashtable();
		xede297d0cfee3b6a = new ArrayList();
		x6f9bbccfb67dfb8c[x9189d7a3c7720a79.x097db4a59326bcb1] = "Times New Roman";
		x6f9bbccfb67dfb8c[x9189d7a3c7720a79.x70c328f6f2e77d76] = "12";
		x6f9bbccfb67dfb8c[x9189d7a3c7720a79.xfa47517dba72fd20] = "normal";
		x6f9bbccfb67dfb8c[x9189d7a3c7720a79.xc94c0a5afee41a0c] = "normal";
		x6f9bbccfb67dfb8c[x9189d7a3c7720a79.x6a81a30bcaf20a97] = "#000000";
		x6f9bbccfb67dfb8c[x9189d7a3c7720a79.xc9c2f7ed072cf9bf] = "start";
		x6f9bbccfb67dfb8c[x9189d7a3c7720a79.x27a8d08d15edb975] = "visible";
		x6f9bbccfb67dfb8c[x9189d7a3c7720a79.xaeddb2c9d22e1e9b] = "1";
		x6f9bbccfb67dfb8c[x9189d7a3c7720a79.x398d39e7bcc2ca22] = "1";
		xede297d0cfee3b6a.Add(x9189d7a3c7720a79.xc2d4efc42998d87b);
		xede297d0cfee3b6a.Add(x9189d7a3c7720a79.x097db4a59326bcb1);
		xede297d0cfee3b6a.Add(x9189d7a3c7720a79.x70c328f6f2e77d76);
		xede297d0cfee3b6a.Add(x9189d7a3c7720a79.x879fc64107ef377f);
		xede297d0cfee3b6a.Add(x9189d7a3c7720a79.x4085f5c80256c978);
		xede297d0cfee3b6a.Add(x9189d7a3c7720a79.xfa47517dba72fd20);
		xede297d0cfee3b6a.Add(x9189d7a3c7720a79.x75fcbe9ccf3f3f7b);
		xede297d0cfee3b6a.Add(x9189d7a3c7720a79.xc94c0a5afee41a0c);
		xede297d0cfee3b6a.Add(x9189d7a3c7720a79.xc9c2f7ed072cf9bf);
		xede297d0cfee3b6a.Add(x9189d7a3c7720a79.x27a8d08d15edb975);
		xede297d0cfee3b6a.Add(x9189d7a3c7720a79.x6a81a30bcaf20a97);
	}
}
