using xb1090543d168d647;

namespace x59d6a4fc5007b7a4;

internal class x7e6545cb3fcd6d55 : xc2469d942acfbc3d
{
	internal x7e6545cb3fcd6d55(x91866f79774c2b6a shapingWorkspace)
		: base(shapingWorkspace)
	{
	}

	internal override void x550781f8db1cf5f2()
	{
		x13db88e817534a1c[] xf6f59bfdd8cbdaf = x2e1eb3b0e4890f28();
		x6e02fd5887c5587d(xf6f59bfdd8cbdaf);
	}

	private x13db88e817534a1c[] x2e1eb3b0e4890f28()
	{
		x13db88e817534a1c[] array = new x13db88e817534a1c[xb14db7591535b378.x1be93eed8950d961];
		x89c665a4797cda9f x89c665a4797cda9f = x89c665a4797cda9f.xaeebd880347ac418;
		x13db88e817534a1c x13db88e817534a1c = x13db88e817534a1c.x5920fbeb94de1c90;
		int num = 0;
		char c = xb14db7591535b378.get_xe6d4b1b411ed94b5(0);
		for (int i = 0; i < xb14db7591535b378.x1be93eed8950d961; i++)
		{
			char c2 = xb14db7591535b378.get_xe6d4b1b411ed94b5(i);
			x89c665a4797cda9f x89c665a4797cda9f2 = x6350aa5ac0b179b2.x9a083b5e298259c7(c2);
			if ((x89c665a4797cda9f2 == x89c665a4797cda9f.xc613adc4330033f3 || x89c665a4797cda9f2 == x89c665a4797cda9f.x5d593cee9d844848 || x89c665a4797cda9f2 == x89c665a4797cda9f.x857912840ffd015f) && (x89c665a4797cda9f == x89c665a4797cda9f.xed846b3bb18ccf39 || x89c665a4797cda9f == x89c665a4797cda9f.x5d593cee9d844848 || x89c665a4797cda9f == x89c665a4797cda9f.x857912840ffd015f) && c != '\u200c')
			{
				if (x13db88e817534a1c == x13db88e817534a1c.x5920fbeb94de1c90 && (x89c665a4797cda9f == x89c665a4797cda9f.x5d593cee9d844848 || x89c665a4797cda9f == x89c665a4797cda9f.xed846b3bb18ccf39))
				{
					array[num] = x13db88e817534a1c.x660adf533ba4edef;
				}
				else if (x13db88e817534a1c == x13db88e817534a1c.x6c4a61fe0135fb17 && x89c665a4797cda9f == x89c665a4797cda9f.x5d593cee9d844848)
				{
					array[num] = x13db88e817534a1c.x144e30a1467072ae;
				}
				array[i] = x13db88e817534a1c.x6c4a61fe0135fb17;
				x13db88e817534a1c = x13db88e817534a1c.x6c4a61fe0135fb17;
				x89c665a4797cda9f = x89c665a4797cda9f2;
				num = i;
			}
			else if (x89c665a4797cda9f2 != x89c665a4797cda9f.x14abc7eff15bf82b)
			{
				array[i] = x13db88e817534a1c.x5920fbeb94de1c90;
				x13db88e817534a1c = x13db88e817534a1c.x5920fbeb94de1c90;
				x89c665a4797cda9f = x89c665a4797cda9f2;
				num = i;
			}
			else
			{
				array[i] = x13db88e817534a1c.x5920fbeb94de1c90;
			}
			c = c2;
		}
		return array;
	}

	private void x6e02fd5887c5587d(x13db88e817534a1c[] xf6f59bfdd8cbdaf4)
	{
		char c = '\uffff';
		int num = 0;
		int x30cc7819189f11b = 0;
		for (int i = 0; i < xb14db7591535b378.x1be93eed8950d961; i++)
		{
			char c2 = xb14db7591535b378.get_xe6d4b1b411ed94b5(i);
			x89c665a4797cda9f x89c665a4797cda9f = x6350aa5ac0b179b2.x9a083b5e298259c7(c2);
			if ((c == 'ل' && c2 != 'ا' && c2 != 'آ' && c2 != 'أ' && c2 != 'إ' && x89c665a4797cda9f != x89c665a4797cda9f.x14abc7eff15bf82b) || c2 == '\u200c')
			{
				c = '\uffff';
			}
			if (c2 == 'ل')
			{
				c = c2;
				num = i;
				x30cc7819189f11b = xf18f3b887970dbc4.x1be93eed8950d961;
			}
			if (c == 'ل')
			{
				if (xf6f59bfdd8cbdaf4[num] == x13db88e817534a1c.x144e30a1467072ae)
				{
					switch (c2)
					{
					case 'ا':
						xb6b8f962814600b2(x30cc7819189f11b, 'ﻼ');
						continue;
					case 'آ':
						xb6b8f962814600b2(x30cc7819189f11b, 'ﻶ');
						continue;
					case 'أ':
						xb6b8f962814600b2(x30cc7819189f11b, 'ﻸ');
						continue;
					case 'إ':
						xb6b8f962814600b2(x30cc7819189f11b, 'ﻺ');
						continue;
					}
				}
				else if (xf6f59bfdd8cbdaf4[num] == x13db88e817534a1c.x660adf533ba4edef)
				{
					switch (c2)
					{
					case 'ا':
						xb6b8f962814600b2(x30cc7819189f11b, 'ﻻ');
						continue;
					case 'آ':
						xb6b8f962814600b2(x30cc7819189f11b, 'ﻵ');
						continue;
					case 'أ':
						xb6b8f962814600b2(x30cc7819189f11b, 'ﻷ');
						continue;
					case 'إ':
						xb6b8f962814600b2(x30cc7819189f11b, 'ﻹ');
						continue;
					}
				}
			}
			char xb867a42da3ae686d = x6350aa5ac0b179b2.xb6b2696908760820(c2, xf6f59bfdd8cbdaf4[i]);
			xf18f3b887970dbc4.x917b69030691beda(xb867a42da3ae686d, i);
		}
		xf18f3b887970dbc4.xcd5f7940e9d851bd();
	}
}
