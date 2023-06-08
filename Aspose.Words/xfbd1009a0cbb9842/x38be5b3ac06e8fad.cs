using Aspose.Words.Fields;
using x28925c9b27b37a46;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal class x38be5b3ac06e8fad
{
	private x7e263f21a73a027a xed4a7b1500064e12;

	private string xfa6aceda0ccea535;

	private int xaabccab0c06d038b = 1;

	private bool x66fc915984b1a799;

	internal x7e263f21a73a027a xf9ad6fb78355fe13
	{
		get
		{
			return xed4a7b1500064e12;
		}
		set
		{
			xed4a7b1500064e12 = value;
		}
	}

	internal string xe12071fbe3d25fe5
	{
		get
		{
			return xfa6aceda0ccea535;
		}
		set
		{
			xfa6aceda0ccea535 = value;
		}
	}

	internal int x504f3d4040b356d7
	{
		get
		{
			return xaabccab0c06d038b;
		}
		set
		{
			xaabccab0c06d038b = value;
		}
	}

	internal bool x271e0fac991fd9dc
	{
		get
		{
			return x66fc915984b1a799;
		}
		set
		{
			x66fc915984b1a799 = value;
		}
	}

	internal static x38be5b3ac06e8fad x1f490eac106aee12(Field xe01ae93d9fe5a880)
	{
		x38be5b3ac06e8fad x38be5b3ac06e8fad2 = new x38be5b3ac06e8fad();
		x985dd08fd338eeea xb452e2ee706d7a = xe01ae93d9fe5a880.xb452e2ee706d7a67;
		x38be5b3ac06e8fad2.xf9ad6fb78355fe13 = xb452e2ee706d7a.xc1a7df85a9e87250(0);
		xb1190ddd5609cee8(xb452e2ee706d7a, x38be5b3ac06e8fad2);
		return x38be5b3ac06e8fad2;
	}

	internal static void xb1190ddd5609cee8(x985dd08fd338eeea x337e217cb3ba0627, x38be5b3ac06e8fad x7d95d971d8923f4c)
	{
		x7d95d971d8923f4c.xe12071fbe3d25fe5 = x337e217cb3ba0627.x6eba61762c5e83d7("\\f", xbd96676852fc71de: true);
		string xe4115acdf4fbfccc = x337e217cb3ba0627.x6eba61762c5e83d7("\\l", xbd96676852fc71de: true);
		int num = xca004f56614e2431.x912616ee70b2d94d(xe4115acdf4fbfccc);
		if (num >= 1 && num <= 9)
		{
			x7d95d971d8923f4c.x504f3d4040b356d7 = num;
		}
		x7d95d971d8923f4c.x271e0fac991fd9dc = x337e217cb3ba0627.xcc2d426b867d703d("\\n");
	}
}
