using x011d489fb9df7027;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x7c7a1dceb600404e;

internal class x2a3247c644c44cfe
{
	private readonly string xc14c8280921f4967;

	private readonly double xe6b508118edbfa28;

	private readonly string xcc7c0dc99fb9213c = "";

	private readonly bool x0dfad4a2ac4c4b47;

	internal bool x82eb6ee0ebeaa44d
	{
		get
		{
			if (x0dfad4a2ac4c4b47)
			{
				return x34307829ceb169a4;
			}
			return false;
		}
	}

	internal bool xd4a7cc164493a506
	{
		get
		{
			if (x0dfad4a2ac4c4b47)
			{
				if (!(xcc7c0dc99fb9213c == "fd"))
				{
					return x34307829ceb169a4;
				}
				return true;
			}
			return false;
		}
	}

	internal bool xbe8d54f88cd64ef4
	{
		get
		{
			if (x0dfad4a2ac4c4b47)
			{
				if (!(xcc7c0dc99fb9213c == "in") && !(xcc7c0dc99fb9213c == "pt") && !(xcc7c0dc99fb9213c == "mm") && !(xcc7c0dc99fb9213c == "cm") && !x34307829ceb169a4)
				{
					return x5ab3b42bd288ad29;
				}
				return true;
			}
			return false;
		}
	}

	internal bool x08428aa3999da322
	{
		get
		{
			if (x0dfad4a2ac4c4b47)
			{
				if (!(xcc7c0dc99fb9213c == "f"))
				{
					return x34307829ceb169a4;
				}
				return true;
			}
			return false;
		}
	}

	internal bool x368bd9f7b8c336b4
	{
		get
		{
			if (x0dfad4a2ac4c4b47)
			{
				if (!(xcc7c0dc99fb9213c == "%"))
				{
					return x5ab3b42bd288ad29;
				}
				return true;
			}
			return false;
		}
	}

	private bool x5ab3b42bd288ad29
	{
		get
		{
			if (xe6b508118edbfa28 == 0.0)
			{
				return x34307829ceb169a4;
			}
			return false;
		}
	}

	private bool x34307829ceb169a4 => xcc7c0dc99fb9213c == string.Empty;

	internal x2a3247c644c44cfe(string value)
	{
		xc14c8280921f4967 = value;
		if (value != string.Empty)
		{
			int num = value.Length - 1;
			while (num >= 0 && (value[num] < '0' || value[num] > '9'))
			{
				num--;
			}
			string xe4115acdf4fbfccc = value.Substring(0, num + 1);
			xe6b508118edbfa28 = xca004f56614e2431.xf5ece46c5d72e3b9(xe4115acdf4fbfccc);
			x0dfad4a2ac4c4b47 = !double.IsNaN(xe6b508118edbfa28);
			xcc7c0dc99fb9213c = value.Substring(num + 1, value.Length - num - 1);
		}
	}

	internal int xb3c6c275892e218c()
	{
		return x15e971129fd80714.x43fcc3f62534530b(x8ff6b239b00e02c3() * 12700.0);
	}

	internal double x8ff6b239b00e02c3()
	{
		return xcc7c0dc99fb9213c switch
		{
			"" => xe6b508118edbfa28, 
			"pt" => xe6b508118edbfa28, 
			"in" => x4574ea26106f0edb.x9adffc4de2e5ac97(xe6b508118edbfa28), 
			"mm" => x4574ea26106f0edb.x5612f4c9f83f95d3(xe6b508118edbfa28), 
			"cm" => x4574ea26106f0edb.x7ee6ab51d3d84831(xe6b508118edbfa28), 
			_ => 0.0, 
		};
	}

	internal x06e4f09a90ca939a xb43972eaeceafe09()
	{
		return new x06e4f09a90ca939a(x4574ea26106f0edb.x88bf16f2386d633e(x8ff6b239b00e02c3()), isFormula: false);
	}

	internal int xb103d12283d985b7()
	{
		return xcc7c0dc99fb9213c switch
		{
			"fd" => x15e971129fd80714.x43fcc3f62534530b(xe6b508118edbfa28), 
			"" => x15e971129fd80714.x43fcc3f62534530b(xe6b508118edbfa28 * 65536.0), 
			_ => 0, 
		};
	}

	internal int x3ec8d5faac556b00()
	{
		if (x368bd9f7b8c336b4)
		{
			return x15e971129fd80714.x43fcc3f62534530b(xe6b508118edbfa28);
		}
		return 0;
	}

	internal int x73932d675f106aa4()
	{
		if (x08428aa3999da322)
		{
			if (x82eb6ee0ebeaa44d)
			{
				return x15e971129fd80714.x43fcc3f62534530b(xe6b508118edbfa28 * 65536.0);
			}
			return x15e971129fd80714.x43fcc3f62534530b(xe6b508118edbfa28);
		}
		return 0;
	}
}
