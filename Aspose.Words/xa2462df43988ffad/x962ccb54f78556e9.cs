using Aspose.Words;
using x28925c9b27b37a46;
using xbe73d5820f7f4ae3;

namespace xa2462df43988ffad;

internal class x962ccb54f78556e9
{
	private xfb6a9597c6d089e0 x075dd9b3a8840fca;

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	internal x962ccb54f78556e9(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
	}

	internal void x6210059f049f0d48(Section xb32f8dd719a105db)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		x8f04d6bdc85b09f3(xb32f8dd719a105db, xb32f8dd719a105db.xfc72d4c9b765cad7);
		if (x075dd9b3a8840fca.x5fb16e270c21db2e != null)
		{
			x8f04d6bdc85b09f3(xb32f8dd719a105db, x075dd9b3a8840fca.x5fb16e270c21db2e.xdf4bcc85da8f85b2);
		}
		if (x075dd9b3a8840fca.xd44988f225497f3a > 0)
		{
			xe1410f585439c7d.x2307058321cdb62f("style:section-properties");
			xe1410f585439c7d.x943f6be3acf634db("text:dont-balance-text-columns", x075dd9b3a8840fca.xa8dd04300e24fdb0);
			xee68c4a2afc4e5c1();
			xe1410f585439c7d.x2dfde153f4ef96d0("style:section-properties");
		}
	}

	internal void xee68c4a2afc4e5c1()
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x2307058321cdb62f("style:columns");
		xe1410f585439c7d.x943f6be3acf634db("fo:column-count", x075dd9b3a8840fca.x5840ec53f70adb17.ToString());
		if (x075dd9b3a8840fca.xbd7bb54d8760ed0a == null || x075dd9b3a8840fca.xbd7bb54d8760ed0a.xd44988f225497f3a == 0 || x075dd9b3a8840fca.x49ddd5238a18b5b1)
		{
			xe1410f585439c7d.x943f6be3acf634db("fo:column-gap", x075dd9b3a8840fca.x042eb39cc7d00f5c);
		}
		if (x075dd9b3a8840fca.x422ab82803b368bc)
		{
			xe1410f585439c7d.xf68f9c3818e1f4b1("style:column-sep");
		}
		if (x075dd9b3a8840fca.xbd7bb54d8760ed0a != null)
		{
			for (int i = 0; i < x075dd9b3a8840fca.xbd7bb54d8760ed0a.xd44988f225497f3a; i++)
			{
				xf4b20132c25a92db(x075dd9b3a8840fca.xbd7bb54d8760ed0a.get_xe6d4b1b411ed94b5(i), i);
			}
		}
		xe1410f585439c7d.x2dfde153f4ef96d0("style:columns");
	}

	internal void xf4b20132c25a92db(TextColumn xe3e287548b3d01f5, int xbeb0e74fd1e3aefb)
	{
		int num = 0;
		int num2 = 0;
		if (xbeb0e74fd1e3aefb > 0)
		{
			num = x075dd9b3a8840fca.xbd7bb54d8760ed0a.get_xe6d4b1b411ed94b5(xbeb0e74fd1e3aefb - 1).xbe8b68828bd16a4b / 2;
		}
		if (xbeb0e74fd1e3aefb < x075dd9b3a8840fca.xbd7bb54d8760ed0a.xd44988f225497f3a - 1)
		{
			num2 = xe3e287548b3d01f5.xbe8b68828bd16a4b / 2;
		}
		x9b287b671d592594.xe1410f585439c7d4.xc049ea80ee267201("style:column", "style:rel-width", $"{xe3e287548b3d01f5.x7219de950d4b708a + num + num2}*", "fo:start-indent", (num != 0) ? xbb857c9fc36f5054.xf7c347cb12d2a63f(num) : null, "fo:end-indent", (num2 != 0) ? xbb857c9fc36f5054.xf7c347cb12d2a63f(num2) : null);
	}

	internal xfb6a9597c6d089e0 x8f04d6bdc85b09f3(Section xb32f8dd719a105db, x7f77ea92be0d9042 x873e775b892867cf)
	{
		x075dd9b3a8840fca = new xfb6a9597c6d089e0();
		x075dd9b3a8840fca.x49ddd5238a18b5b1 = false;
		for (int i = 0; i < x873e775b892867cf.xd44988f225497f3a; i++)
		{
			int num = x873e775b892867cf.xf15263674eb297bb(i);
			object obj = x873e775b892867cf.x6d3720b962bd3112(i);
			if (obj != null)
			{
				x075dd9b3a8840fca.xd44988f225497f3a++;
				switch (num)
				{
				case 2350:
					x075dd9b3a8840fca.x5840ec53f70adb17 = (int)obj;
					break;
				case 2380:
					x075dd9b3a8840fca.xbd7bb54d8760ed0a = (x28980d9c5ec3f471)obj;
					break;
				case 2370:
					x075dd9b3a8840fca.x042eb39cc7d00f5c = xbb857c9fc36f5054.xf7c347cb12d2a63f(obj);
					break;
				case 2360:
					x075dd9b3a8840fca.x49ddd5238a18b5b1 = (bool)obj;
					break;
				case 2060:
					x075dd9b3a8840fca.x422ab82803b368bc = (bool)obj;
					break;
				case 10010:
					x075dd9b3a8840fca.x5fb16e270c21db2e = (x5fb16e270c21db2e)obj;
					break;
				default:
					x075dd9b3a8840fca.xd44988f225497f3a--;
					break;
				}
			}
		}
		if (x075dd9b3a8840fca.x042eb39cc7d00f5c == null)
		{
			x075dd9b3a8840fca.x042eb39cc7d00f5c = xbb857c9fc36f5054.xf7c347cb12d2a63f(xfc72d4c9b765cad7.x0095b789d636f3ae(2370));
			x075dd9b3a8840fca.xd44988f225497f3a++;
		}
		x075dd9b3a8840fca.xa8dd04300e24fdb0 = (x9b287b671d592594.x2c8c6741422a1298.CompatibilityOptions.NoColumnBalance ? "true" : "false");
		x075dd9b3a8840fca.xd44988f225497f3a++;
		return x075dd9b3a8840fca;
	}
}
