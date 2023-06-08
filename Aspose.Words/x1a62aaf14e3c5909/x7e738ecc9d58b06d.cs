using System;
using System.Collections;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x13f1efc79617a47b;

namespace x1a62aaf14e3c5909;

internal class x7e738ecc9d58b06d
{
	private const int x474e01096e02375d = 1024;

	private readonly Document xd1424e1a0bb4a72b;

	private x57b6730bb29ba4a9 xbf725a5b760291de;

	private x622ccf73c1aa9e89 x100216b58f17909c;

	private readonly Hashtable xe46361d711a62e97 = new Hashtable();

	private readonly Hashtable x8cde65cae117f25f = new Hashtable();

	private Shape xc688b5328f84d0a0;

	private readonly Hashtable xde9eea5d03fd64fe = new Hashtable();

	private readonly IWarningCallback xa056586c1f99e199;

	internal static bool x492f529cee830a40;

	internal Shape x5ab5a058833da74f
	{
		get
		{
			return xc688b5328f84d0a0;
		}
		set
		{
			xc688b5328f84d0a0 = value;
		}
	}

	internal Document x2c8c6741422a1298 => xd1424e1a0bb4a72b;

	internal x57b6730bb29ba4a9 x57b6730bb29ba4a9 => xbf725a5b760291de;

	private bool x4897d33a2b47fb6f
	{
		get
		{
			if (xc688b5328f84d0a0 != null)
			{
				return true;
			}
			if (xe46361d711a62e97.Count <= 0)
			{
				return x8cde65cae117f25f.Count > 0;
			}
			return true;
		}
	}

	internal x7e738ecc9d58b06d(Document document, IWarningCallback warningCallback)
	{
		xd1424e1a0bb4a72b = document;
		xa056586c1f99e199 = warningCallback;
	}

	internal ShapeBase xb613f9c3a594bed5(int x1f6ee650d037e627, xc40bef0fb61c8a3e x4d49889b5a27d1df)
	{
		Hashtable hashtable = xe3bbb6428e17450e(x4d49889b5a27d1df);
		return (ShapeBase)hashtable[x1f6ee650d037e627];
	}

	internal void x83a87b4a5ef1284e(int x1f6ee650d037e627, xc40bef0fb61c8a3e x4d49889b5a27d1df)
	{
		Hashtable hashtable = xe3bbb6428e17450e(x4d49889b5a27d1df);
		hashtable.Remove(x1f6ee650d037e627);
	}

	internal void xa8a795be8f94b493(ShapeBase x5770cdefd8931aa9, xc40bef0fb61c8a3e x4d49889b5a27d1df)
	{
		Hashtable hashtable = xe3bbb6428e17450e(x4d49889b5a27d1df);
		hashtable.Add(x5770cdefd8931aa9.xea1e81378298fa81, x5770cdefd8931aa9);
	}

	internal void x06b0e25aa6ad68a9(BinaryReader x8ac9765f43e4b683, int x19a21d604769e75b, int x9e4be1b404ab074b, BinaryReader x44008b73fc5f9672)
	{
		_ = x492f529cee830a40;
		if (x9e4be1b404ab074b == 0)
		{
			return;
		}
		x8ac9765f43e4b683.BaseStream.Position = x19a21d604769e75b;
		int num = x19a21d604769e75b + x9e4be1b404ab074b;
		xbf725a5b760291de = (x57b6730bb29ba4a9)xeb990b4cb5dd2e44.x2785b0923dba0723(x8ac9765f43e4b683, xa056586c1f99e199);
		xbf725a5b760291de.x92293779605aaa59(x44008b73fc5f9672);
		if (xbf725a5b760291de.xd781d5c3b7b0f235 != null)
		{
			foreach (xfbb3f4be330f4086 item in xbf725a5b760291de.xd781d5c3b7b0f235.xf2453c298c5de6f5)
			{
				if (item.x90c6e45466e5b849 != null)
				{
					xc3eb1b4e429c8893(item);
				}
			}
		}
		_ = x492f529cee830a40;
		x100216b58f17909c = new x622ccf73c1aa9e89();
		while (x8ac9765f43e4b683.BaseStream.Position < num)
		{
			xc40bef0fb61c8a3e x8d179ee9582d1d8e = (xc40bef0fb61c8a3e)x8ac9765f43e4b683.ReadByte();
			x5f3a67c2a92bcd0b x5f3a67c2a92bcd0b2 = (x5f3a67c2a92bcd0b)xeb990b4cb5dd2e44.x2785b0923dba0723(x8ac9765f43e4b683, xa056586c1f99e199);
			x5f3a67c2a92bcd0b2.x8d179ee9582d1d8e = x8d179ee9582d1d8e;
			x100216b58f17909c.Add(x5f3a67c2a92bcd0b2);
			_ = x492f529cee830a40;
		}
		foreach (x5f3a67c2a92bcd0b item2 in x100216b58f17909c)
		{
			x7899c771eca5746e(item2);
		}
	}

	internal void xc3eb1b4e429c8893(xfbb3f4be330f4086 x9b11f51028d17a8b)
	{
		xde9eea5d03fd64fe[x9b11f51028d17a8b.x90c6e45466e5b849.x0217cda8370c1f17] = x9b11f51028d17a8b;
	}

	internal xfbb3f4be330f4086 x590497a2b838b652(Guid xb51cd75f17ace1ec)
	{
		return (xfbb3f4be330f4086)xde9eea5d03fd64fe[xb51cd75f17ace1ec];
	}

	internal int x6210059f049f0d48(BinaryWriter xf4128eeeb72b0b1c, BinaryWriter xc83188e30d5f47a5, bool x9c3d5a1ae48b1ea8)
	{
		if (!x4897d33a2b47fb6f)
		{
			return 0;
		}
		xbf725a5b760291de = x57b6730bb29ba4a9.xa574237c8982796b();
		x100216b58f17909c = new x622ccf73c1aa9e89();
		x2433176ed02449a8(xc40bef0fb61c8a3e.xc447809891322395);
		if (x9c3d5a1ae48b1ea8)
		{
			x2433176ed02449a8(xc40bef0fb61c8a3e.x1ea60bde2b5d0d28);
		}
		xbf725a5b760291de.x5ed090cee2aa9cab(xc83188e30d5f47a5);
		xbf725a5b760291de.x3469ce933e527557();
		x6671cf4b0be888ea();
		return xf69e3cf19f0625a0(xf4128eeeb72b0b1c);
	}

	private void x2433176ed02449a8(xc40bef0fb61c8a3e x4d49889b5a27d1df)
	{
		x5f3a67c2a92bcd0b x5f3a67c2a92bcd0b2 = x5f3a67c2a92bcd0b.xa574237c8982796b(x4d49889b5a27d1df);
		x9ced206c3c179783 x9ced206c3c179784 = new x9ced206c3c179783();
		x373059570f6cfe23 context = new x373059570f6cfe23(xd1424e1a0bb4a72b, xbf725a5b760291de.xd781d5c3b7b0f235, x9ced206c3c179784, xa056586c1f99e199);
		x821732b125012c9e x821732b125012c9e2 = new x821732b125012c9e(context);
		Hashtable x1d7f342a22ddda = xe3bbb6428e17450e(x4d49889b5a27d1df);
		ShapeBase[] array = x1426e0acf9963b0d(x1d7f342a22ddda);
		x0c6eac1af67f9f81 xaedb5aa958e0ae8f = x5f3a67c2a92bcd0b2.xaedb5aa958e0ae8f;
		for (int i = 0; i < array.Length; i++)
		{
			xaedb5aa958e0ae8f.xf2453c298c5de6f5.Add(x821732b125012c9e2.xcef849e3313d20a1(array[i], x0771ab99a5b01492.xe360b1885d8d4a41));
		}
		if (x4d49889b5a27d1df == xc40bef0fb61c8a3e.xc447809891322395 && xc688b5328f84d0a0 != null)
		{
			xc6764e97e740ec5a value = x821732b125012c9e2.x06f0bb4c55cdf2ba(xc688b5328f84d0a0, x0771ab99a5b01492.x52578e3c8384728f);
			x5f3a67c2a92bcd0b2.xf2453c298c5de6f5.Add(value);
		}
		if (x9ced206c3c179784.xd44988f225497f3a > 0)
		{
			x5f3a67c2a92bcd0b2.xf2453c298c5de6f5.Add(x9ced206c3c179784);
		}
		x100216b58f17909c.Add(x5f3a67c2a92bcd0b2);
	}

	private static ShapeBase[] x1426e0acf9963b0d(Hashtable x1d7f342a22ddda41)
	{
		int num = 0;
		ShapeBase[] array = new ShapeBase[x1d7f342a22ddda41.Count];
		foreach (ShapeBase value in x1d7f342a22ddda41.Values)
		{
			array[num] = value;
			num++;
		}
		Array.Sort(array, new x41d5513fb432c671());
		return array;
	}

	private void x6671cf4b0be888ea()
	{
		xef64b8221aa2a96c x6da9472bbc4fce2c = xbf725a5b760291de.x6da9472bbc4fce2c;
		x6da9472bbc4fce2c.x55cb50b5c23ddd7c.Clear();
		int num = 0;
		foreach (x5f3a67c2a92bcd0b item in x100216b58f17909c)
		{
			item.xaedb5aa958e0ae8f.xa9993ed2e0c64574.xdd2aea3eb7514107 = (x6da9472bbc4fce2c.x55cb50b5c23ddd7c.Count + 1) * 1024;
			item.x6671cf4b0be888ea();
			int num2 = item.x91ac32ef4a85c752.x80a0fbcf860ec6e0 - item.xaedb5aa958e0ae8f.xa9993ed2e0c64574.xdd2aea3eb7514107 + 1;
			while (num2 > 0)
			{
				int num3 = Math.Min(num2, 1024);
				x6da9472bbc4fce2c.x55cb50b5c23ddd7c.Add(new xa1d25b751a6c45ec(item.x91ac32ef4a85c752.x65ea8654a7f70de3, num3));
				num2 -= num3;
			}
			num += item.x91ac32ef4a85c752.x45856a8054f10613;
			x6da9472bbc4fce2c.xf1233101d2dcf572++;
		}
		x6da9472bbc4fce2c.x45856a8054f10613 = num;
		x6da9472bbc4fce2c.xe712fb8c17028f72 = (x6da9472bbc4fce2c.x55cb50b5c23ddd7c.Count + 1) * 1024 + 2;
	}

	private int xf69e3cf19f0625a0(BinaryWriter xf4128eeeb72b0b1c)
	{
		int num = (int)xf4128eeeb72b0b1c.BaseStream.Position;
		xbf725a5b760291de.x6210059f049f0d48(xf4128eeeb72b0b1c);
		foreach (x5f3a67c2a92bcd0b item in x100216b58f17909c)
		{
			xf4128eeeb72b0b1c.Write((byte)item.x8d179ee9582d1d8e);
			item.x6210059f049f0d48(xf4128eeeb72b0b1c);
		}
		return (int)xf4128eeeb72b0b1c.BaseStream.Position - num;
	}

	private void x7899c771eca5746e(x5f3a67c2a92bcd0b x0df504b73b9fe8e0)
	{
		x373059570f6cfe23 context = new x373059570f6cfe23(xd1424e1a0bb4a72b, xbf725a5b760291de.xd781d5c3b7b0f235, x0df504b73b9fe8e0.x66105e422ac8a42a, xa056586c1f99e199);
		x821732b125012c9e x821732b125012c9e2 = new x821732b125012c9e(context);
		Hashtable x1d7f342a22ddda = xe3bbb6428e17450e(x0df504b73b9fe8e0.x8d179ee9582d1d8e);
		for (int i = 0; i < x0df504b73b9fe8e0.xd44988f225497f3a; i++)
		{
			xddf6304144fd3863 xddf6304144fd3864 = ((x21ad3b7fe343bc74)x0df504b73b9fe8e0).get_xe6d4b1b411ed94b5(i);
			switch (xddf6304144fd3864.x1ea60bde2b5d0d28.x3146d638ec378671)
			{
			case x773fe540042dad03.xf556a619f6f995f0:
			{
				x0c6eac1af67f9f81 x0c6eac1af67f9f82 = (x0c6eac1af67f9f81)xddf6304144fd3864;
				if (x0c6eac1af67f9f82.xa9993ed2e0c64574.xab3829a04b8614ba && !x0c6eac1af67f9f82.xa9993ed2e0c64574.x65fd966a6b330c28)
				{
					x8cc3d2ed777fa86c(x0c6eac1af67f9f82, x821732b125012c9e2, x1d7f342a22ddda);
				}
				break;
			}
			case x773fe540042dad03.xf6e35fb163f1c232:
			{
				xc6764e97e740ec5a xc6764e97e740ec5a2 = (xc6764e97e740ec5a)xddf6304144fd3864;
				if (xc6764e97e740ec5a2.xa9993ed2e0c64574.x1a3b93a566584a7d && !xc6764e97e740ec5a2.xa9993ed2e0c64574.x65fd966a6b330c28)
				{
					xc688b5328f84d0a0 = x821732b125012c9e2.xac287a575a05d160(xc6764e97e740ec5a2);
				}
				break;
			}
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jkofplfgjlmgjldhhlkhmlbialiipfpiokgjojnjjjekcklkckclbjjlkeamljhmnjombjfndimnlddobikodibpcdipahppkhgajcnalgebghlbdgccfgjcpfadjghdebodfffeagmemedfpfkfoebgafiggepgkagh", 964451924)));
			case x773fe540042dad03.x66105e422ac8a42a:
			case x773fe540042dad03.x91ac32ef4a85c752:
			case x773fe540042dad03.x5e0bc8119f757f1b:
				break;
			}
		}
	}

	private static void x8cc3d2ed777fa86c(x0c6eac1af67f9f81 xab62f568693e7899, x821732b125012c9e xb524ead8b206f534, Hashtable x1d7f342a22ddda41)
	{
		for (int i = 1; i < xab62f568693e7899.xd44988f225497f3a; i++)
		{
			x21ad3b7fe343bc74 x40bb35f2f56a = (x21ad3b7fe343bc74)((x21ad3b7fe343bc74)xab62f568693e7899).get_xe6d4b1b411ed94b5(i);
			ShapeBase shapeBase = xb524ead8b206f534.x8c713173570e8643(x40bb35f2f56a);
			shapeBase.ZOrder = i - 1;
			x1d7f342a22ddda41[shapeBase.xea1e81378298fa81] = shapeBase;
		}
	}

	private Hashtable xe3bbb6428e17450e(xc40bef0fb61c8a3e x4d49889b5a27d1df)
	{
		return x4d49889b5a27d1df switch
		{
			xc40bef0fb61c8a3e.xc447809891322395 => xe46361d711a62e97, 
			xc40bef0fb61c8a3e.x1ea60bde2b5d0d28 => x8cde65cae117f25f, 
			_ => throw new InvalidOperationException("Unexpected drawing type."), 
		};
	}
}
