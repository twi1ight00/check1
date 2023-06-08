using System;
using System.Collections;
using System.Drawing;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using x13f1efc79617a47b;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class x6a53cec2ada67e5c : xb850ecb8335a2e09
{
	private Point xe79c881f80fec866 = Point.Empty;

	private bool xdbc5a9cb98182383;

	private readonly ArrayList x59f65ec646f8c7eb = new ArrayList(5);

	internal bool xef3bf4897acc8ed3
	{
		get
		{
			xf6937c72cebe4ad1 xf6937c72cebe4ad = (xf6937c72cebe4ad1)x9fb0e9c0b1bdc4b3;
			xdea433bdd3c04e0e x4e0afe70adcb4c = xf6937c72cebe4ad.x4e0afe70adcb4c39;
			int num = xf6937c72cebe4ad.x139412b8dea2f02b + 1;
			int num2 = xf6937c72cebe4ad.xb0f146032f47c24e - num + 1;
			if (num >= x4e0afe70adcb4c.x4e941b39b4de92a5)
			{
				return num2 < x4e0afe70adcb4c.x817fa68c05425b51;
			}
			return true;
		}
	}

	internal override float x72d92bd1aff02e37 => x4574ea26106f0edb.xc96d70553223ee04(x9fb0e9c0b1bdc4b3.x8df91a2f90079e88 - xe79c881f80fec866.X);

	internal override float xe360b1885d8d4a41 => x4574ea26106f0edb.xc96d70553223ee04(x9fb0e9c0b1bdc4b3.xc821290d7ecc08bf - xe79c881f80fec866.Y + ((xf6937c72cebe4ad1)x9fb0e9c0b1bdc4b3).x147605d3f215e4c9.xd72444cc04207b76);

	internal x6a53cec2ada67e5c(x398b3bd0acd94b61 part, Point delta)
		: base(part)
	{
		xe79c881f80fec866 = delta;
	}

	internal override void x7012609bcdb39574(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		x672ff13faf031f3d.xd5d8ece01511f314(this);
		x56410a8dd70087c5[] array = ((xf6937c72cebe4ad1)x9fb0e9c0b1bdc4b3).xfbd846b02c9251a4(null, null, ((xf6937c72cebe4ad1)x9fb0e9c0b1bdc4b3).x03577401bda14611);
		for (int i = 0; i < array.Length; i++)
		{
			x56410a8dd70087c5 x56410a8dd70087c = array[i];
			if (x56410a8dd70087c.x5566e2d2acbd1fbe == 11799 && i >= array.Length - 1)
			{
				x56410a8dd70087c.x887b872a95caaab5 = int.MinValue;
			}
			if (x56410a8dd70087c.xb365cc9dea2618c7)
			{
				x56410a8dd70087c.xb365cc9dea2618c7 = false;
			}
			else
			{
				if (x1d7a3e469e17497c(x672ff13faf031f3d, x56410a8dd70087c) || xc8ed661ab160c19f(x672ff13faf031f3d, x56410a8dd70087c))
				{
					continue;
				}
				switch (x56410a8dd70087c.x5566e2d2acbd1fbe)
				{
				case 9217:
				case 10754:
					if (x56410a8dd70087c.x887b872a95caaab5 != 0 && x56410a8dd70087c.xbcd477821fdbd81b != 0)
					{
						new xcd3694ded987e19d(x56410a8dd70087c).x7012609bcdb39574(x672ff13faf031f3d);
					}
					continue;
				case 12803:
					new xfb07b2a80e43c2cc(x56410a8dd70087c).x7012609bcdb39574(x672ff13faf031f3d);
					continue;
				case 25604:
					if (x56410a8dd70087c.x34251722ab416841.x109e3389933c23a8.xab6edfb47ff0b74c == WrapType.Inline)
					{
						new xa7492065dee59ad0(x56410a8dd70087c).x7012609bcdb39574(x672ff13faf031f3d);
					}
					continue;
				case 0:
					if (x56410a8dd70087c is x91e144d65ff41819)
					{
						new xc7b875b517342f11(x56410a8dd70087c).x7012609bcdb39574(x672ff13faf031f3d);
					}
					continue;
				case 9244:
				case 9245:
					new x740374357407832e(x56410a8dd70087c).x7012609bcdb39574(x672ff13faf031f3d);
					continue;
				}
				if (x56410a8dd70087c is x41ac54db4e627dea)
				{
					new xb43a47dbe11ef8fb(x56410a8dd70087c).x7012609bcdb39574(x672ff13faf031f3d);
				}
				else if (x5566e2d2acbd1fbe.xbeeb36dfc51db07d(x56410a8dd70087c.x5566e2d2acbd1fbe))
				{
					new x96fdc2b3abde93b1(x56410a8dd70087c).x7012609bcdb39574(x672ff13faf031f3d);
				}
			}
		}
		x672ff13faf031f3d.x3d7ea625bef846bf(this);
	}

	private bool x1d7a3e469e17497c(x3adba2572f6b9747 x672ff13faf031f3d, x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (!(x5906905c888d3d98 is xeb20d9a559fa99ca) || !x9fb0e9c0b1bdc4b3.xdeb77ea37ad74c56.x74ae341968ceeebf)
		{
			return false;
		}
		xeb20d9a559fa99ca xeb20d9a559fa99ca = (xeb20d9a559fa99ca)x5906905c888d3d98;
		new x988c1cad471a514c(xeb20d9a559fa99ca).x7012609bcdb39574(x672ff13faf031f3d);
		FieldEnd end = xeb20d9a559fa99ca.xd438a3a8968e57e1.xd1b40af56a8385d4.End;
		xf3f447691ab38eee xb3a79d506b0e2f7f = x5906905c888d3d98.x53111d6596d16a99.xb3a79d506b0e2f7f;
		if (!xb3a79d506b0e2f7f.xd8b11076ff837685(x5906905c888d3d98))
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("phmikjdjekkjbkbkpjikbkpkkeglejnldjemhjlmdicnjejn", 37129276)));
		}
		while (xb3a79d506b0e2f7f.x47f176deff0d42e2())
		{
			x5906905c888d3d98 = (x56410a8dd70087c5)xb3a79d506b0e2f7f.x02ebdc12ebf86805;
			x5906905c888d3d98.xb365cc9dea2618c7 = true;
			if (x5906905c888d3d98 is x5c28fdcd27dee7d9)
			{
				x5c28fdcd27dee7d9 x5c28fdcd27dee7d = (x5c28fdcd27dee7d9)x5906905c888d3d98;
				if (x5c28fdcd27dee7d.x6e414db5d060a816 == x6e414db5d060a816.x9fd888e65466818c && x5c28fdcd27dee7d.xb7c4cf9f30ad5f2a == end)
				{
					break;
				}
			}
		}
		return true;
	}

	private bool xc8ed661ab160c19f(x3adba2572f6b9747 x672ff13faf031f3d, x56410a8dd70087c5 x5906905c888d3d98)
	{
		switch (x5906905c888d3d98.x5566e2d2acbd1fbe)
		{
		case 9217:
		case 10754:
			if (xdbc5a9cb98182383)
			{
				xb5490b57c3ff4ae7(x672ff13faf031f3d);
			}
			return false;
		case 12803:
		case 25604:
			return false;
		case 0:
			if (x5906905c888d3d98 is xeb20d9a559fa99ca)
			{
				xdbc5a9cb98182383 = true;
			}
			else
			{
				if (!xdbc5a9cb98182383 || !(x5906905c888d3d98 is x5c28fdcd27dee7d9) || x6e414db5d060a816.x9fd888e65466818c != x5906905c888d3d98.x6e414db5d060a816)
				{
					return false;
				}
				xb5490b57c3ff4ae7(x672ff13faf031f3d);
			}
			return true;
		default:
			if (xdbc5a9cb98182383 && x5566e2d2acbd1fbe.xbeeb36dfc51db07d(x5906905c888d3d98.x5566e2d2acbd1fbe))
			{
				if (x5906905c888d3d98.xf9ad6fb78355fe13[0] == '\u2002')
				{
					x59f65ec646f8c7eb.Add(x5906905c888d3d98);
				}
				else
				{
					xb5490b57c3ff4ae7(x672ff13faf031f3d);
				}
				return true;
			}
			return false;
		}
	}

	private void xb5490b57c3ff4ae7(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		int count = x59f65ec646f8c7eb.Count;
		if (0 < count)
		{
			if (5 == count)
			{
				for (int i = 0; i < count; i++)
				{
					xcd3694ded987e19d xcd3694ded987e19d2 = new xcd3694ded987e19d((x56410a8dd70087c5)x59f65ec646f8c7eb[i]);
					xcd3694ded987e19d2.xf9ad6fb78355fe13 = " ";
					xcd3694ded987e19d2.x7012609bcdb39574(x672ff13faf031f3d);
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					new x96fdc2b3abde93b1((x56410a8dd70087c5)x59f65ec646f8c7eb[j]).x7012609bcdb39574(x672ff13faf031f3d);
				}
			}
			x59f65ec646f8c7eb.Clear();
		}
		xdbc5a9cb98182383 = false;
	}
}
