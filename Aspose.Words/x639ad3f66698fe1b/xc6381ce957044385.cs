using System.Collections;
using System.Drawing;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x884584cc69c5c378;
using xfbd1009a0cbb9842;

namespace x639ad3f66698fe1b;

internal class xc6381ce957044385
{
	private readonly x21f0d20d41203be1 x8cedcaa9a62c6e39;

	private readonly x5fbed40a77205d71 xfb426646e9a7f451;

	private int xb92b8edd4b869c7d;

	internal xc6381ce957044385(x21f0d20d41203be1 context)
	{
		x8cedcaa9a62c6e39 = context;
		xfb426646e9a7f451 = new x5fbed40a77205d71(context);
		xb92b8edd4b869c7d = 0;
	}

	internal void x9b9ed0109b743e3b(x21f0d20d41203be1 x0f7b23d1c393aed9)
	{
		x09ce2c02826e31a6 x09ce2c02826e31a = new x09ce2c02826e31a6();
		Hashtable xe42bd130f1e = x0f7b23d1c393aed9.x8556eed81191af11.xe42bd130f1e95570;
		foreach (int key in xe42bd130f1e.Keys)
		{
			x09ce2c02826e31a.xd6b6ed77479ef68c(key, xe42bd130f1e[key]);
		}
		for (int i = 0; i < x09ce2c02826e31a.xd44988f225497f3a; i++)
		{
			ShapeBase x5770cdefd8931aa = (ShapeBase)x09ce2c02826e31a.x6d3720b962bd3112(i);
			if (xd69cbb14962f3cdb(x5770cdefd8931aa))
			{
				xf39b0e49df97d58b(x5770cdefd8931aa);
			}
		}
	}

	internal void x92e9ca271095fc22(ShapeBase x5770cdefd8931aa9)
	{
		SizeF x0ceec69a97f = x5770cdefd8931aa9.x437e3b626c0fdd43;
		if (x5770cdefd8931aa9.IsTopLevel)
		{
			x0ceec69a97f = x409512556c3f2a9a.x71b0f13c06d08cd9(x0ceec69a97f, x5770cdefd8931aa9.Rotation);
		}
		x5770cdefd8931aa9.x404ab2fc377ad1ed(x0ceec69a97f.Height);
		x5770cdefd8931aa9.xf524ccc95fe8e714(x0ceec69a97f.Width);
		if (x5770cdefd8931aa9.IsInline)
		{
			xa2da347149ea5053(x5770cdefd8931aa9);
		}
		else
		{
			x69310f6cbc6d8f29(x5770cdefd8931aa9);
		}
	}

	internal void xd952c86c26db9330(ShapeBase x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.IsInline)
		{
			x8fe1c70aee4ce224(x5770cdefd8931aa9);
		}
		else
		{
			xc52fe632d83b554e(x5770cdefd8931aa9);
		}
	}

	internal void x409f6d17d51b0ce0(ShapeBase x5770cdefd8931aa9)
	{
		xa9a6cebffd173ca3(x5770cdefd8931aa9, x31f7755ef1c3e8a3: true);
		x4f95f44435ab20ed(x5770cdefd8931aa9);
	}

	private void xa2da347149ea5053(ShapeBase x5770cdefd8931aa9)
	{
		switch (x5770cdefd8931aa9.ShapeType)
		{
		case ShapeType.OleObject:
		case ShapeType.Image:
			x3ddd53fd6407e2d3((Shape)x5770cdefd8931aa9);
			return;
		case ShapeType.OleControl:
			xb96548915defddcf.xde8e4a77c0ba56cc(x8cedcaa9a62c6e39, (Shape)x5770cdefd8931aa9);
			return;
		}
		if (x5770cdefd8931aa9.x3d318285d887cd3a)
		{
			x6c54ade3d1387d65(x5770cdefd8931aa9);
			return;
		}
		x4cefe4b20532460c x4cefe4b20532460c2 = new x4cefe4b20532460c(x8cedcaa9a62c6e39, x5770cdefd8931aa9);
		x4cefe4b20532460c2.x6210059f049f0d48(x0efda03510113407: true, x87e9ac2885e28700: false, x10884bb8036bcee0.x1a23317d325de634);
	}

	private void x8fe1c70aee4ce224(ShapeBase x5770cdefd8931aa9)
	{
		ShapeType shapeType = x5770cdefd8931aa9.ShapeType;
		if (shapeType != ShapeType.OleObject && shapeType != ShapeType.Image && shapeType != ShapeType.OleControl && x5770cdefd8931aa9.x3d318285d887cd3a)
		{
			xb0b7ba9b57236331(x5770cdefd8931aa9);
		}
	}

	private void x69310f6cbc6d8f29(ShapeBase x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.xa170cce2bc40bdf5)
		{
			x44615072c1f1bc9e((Shape)x5770cdefd8931aa9);
			return;
		}
		x5da365af81fafb38(x5770cdefd8931aa9);
		xa9a6cebffd173ca3(x5770cdefd8931aa9, x31f7755ef1c3e8a3: false);
	}

	private void xc52fe632d83b554e(ShapeBase x5770cdefd8931aa9)
	{
		if (!x5770cdefd8931aa9.xa170cce2bc40bdf5)
		{
			x4f95f44435ab20ed(x5770cdefd8931aa9);
			x824b646a7759e64d(x5770cdefd8931aa9);
		}
	}

	private void x3ddd53fd6407e2d3(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.xbfc952aeef7fd0d5)
		{
			xdfac57ec3a49a3fc xdfac57ec3a49a3fc = new xdfac57ec3a49a3fc(x5770cdefd8931aa9.x8edafc3cf6e5431a, x5770cdefd8931aa9.xffd5ab6c569c488d, x5770cdefd8931aa9.ScreenTip, x5770cdefd8931aa9.Target);
			x8cedcaa9a62c6e39.xf81237e03ccdf47f.x8605874f1b4c6798(xdfac57ec3a49a3fc.ToString(), x5770cdefd8931aa9.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226), x0c07ecaa89906059: false);
			x8cedcaa9a62c6e39.xf81237e03ccdf47f.x8d6cd60f05fc1fe9();
		}
		if (x5770cdefd8931aa9.ShapeType == ShapeType.Image)
		{
			if (x5770cdefd8931aa9.ImageData.IsLink)
			{
				x5907707870dfe8ca(x5770cdefd8931aa9);
			}
			else
			{
				x6ccd8a614a6b0053(x5770cdefd8931aa9);
			}
		}
		else
		{
			xb96548915defddcf.xde8e4a77c0ba56cc(x8cedcaa9a62c6e39, x5770cdefd8931aa9);
		}
		if (x5770cdefd8931aa9.xbfc952aeef7fd0d5)
		{
			x8cedcaa9a62c6e39.xf81237e03ccdf47f.x98ab27c28fa098eb(x4797cf69c5ec19ff: true);
		}
	}

	private void x5907707870dfe8ca(Shape x5770cdefd8931aa9)
	{
		if (!x8cedcaa9a62c6e39.x5124b2bcc12d5218)
		{
			string text = $" INCLUDEPICTURE {xb7dbd7bb3ed97d5b.x0b0647af7a5ab290(x5770cdefd8931aa9.ImageData.SourceFullName)} \\* MERGEFORMAT ";
			if (x5770cdefd8931aa9.ImageData.IsLinkOnly)
			{
				text += "\\d ";
			}
			x8cedcaa9a62c6e39.xf81237e03ccdf47f.x8605874f1b4c6798(text, x5770cdefd8931aa9.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226), x0c07ecaa89906059: false);
			x8cedcaa9a62c6e39.xf81237e03ccdf47f.x8d6cd60f05fc1fe9();
		}
		x5da365af81fafb38(x5770cdefd8931aa9);
		x68bc5741469ea60b(x5770cdefd8931aa9);
		x824b646a7759e64d(x5770cdefd8931aa9);
		if (!x8cedcaa9a62c6e39.x5124b2bcc12d5218)
		{
			x8cedcaa9a62c6e39.xf81237e03ccdf47f.x98ab27c28fa098eb(x4797cf69c5ec19ff: true);
		}
	}

	private void x6ccd8a614a6b0053(Shape x5770cdefd8931aa9)
	{
		x5da365af81fafb38(x5770cdefd8931aa9);
		x68bc5741469ea60b(x5770cdefd8931aa9);
		x824b646a7759e64d(x5770cdefd8931aa9);
	}

	internal void x68bc5741469ea60b(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.ImageData.IsLinkOnly)
		{
			return;
		}
		x4cefe4b20532460c x4cefe4b20532460c2 = new x4cefe4b20532460c(x8cedcaa9a62c6e39, x5770cdefd8931aa9);
		switch (x5770cdefd8931aa9.ImageData.ImageType)
		{
		case ImageType.Emf:
		case ImageType.Wmf:
		case ImageType.Bmp:
			x4cefe4b20532460c2.x6210059f049f0d48(x0efda03510113407: true, x87e9ac2885e28700: false, x10884bb8036bcee0.x1a23317d325de634);
			return;
		}
		xbfd162a6d47f59a4 xe1410f585439c7d = x8cedcaa9a62c6e39.xe1410f585439c7d4;
		xe1410f585439c7d.xee60bff2900a72f2("\\*\\shppict");
		x4cefe4b20532460c2.x6210059f049f0d48(x0efda03510113407: true, x87e9ac2885e28700: false, x10884bb8036bcee0.x1a23317d325de634);
		xe1410f585439c7d.xc8a13a52db0580ae();
		if (x8cedcaa9a62c6e39.xf57de0fd37d5e97d.ExportImagesForOldReaders)
		{
			xe1410f585439c7d.xee60bff2900a72f2("\\nonshppict");
			x4cefe4b20532460c2.x6210059f049f0d48(x0efda03510113407: false, x87e9ac2885e28700: true, x10884bb8036bcee0.x1a23317d325de634);
			xe1410f585439c7d.xc8a13a52db0580ae();
		}
	}

	private void x44615072c1f1bc9e(Shape x5770cdefd8931aa9)
	{
		x5da365af81fafb38(x5770cdefd8931aa9);
		xa9a6cebffd173ca3(x5770cdefd8931aa9, x31f7755ef1c3e8a3: false);
		xb96548915defddcf.xde8e4a77c0ba56cc(x8cedcaa9a62c6e39, x5770cdefd8931aa9);
		x4f95f44435ab20ed(x5770cdefd8931aa9);
		x824b646a7759e64d(x5770cdefd8931aa9);
	}

	private void x6c54ade3d1387d65(ShapeBase x5770cdefd8931aa9)
	{
		x8cedcaa9a62c6e39.xf81237e03ccdf47f.x8605874f1b4c6798(" SHAPE  \\* MERGEFORMAT ", x5770cdefd8931aa9.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226), x0c07ecaa89906059: true);
		x8cedcaa9a62c6e39.xf81237e03ccdf47f.x8d6cd60f05fc1fe9();
		x5da365af81fafb38(x5770cdefd8931aa9);
		xa9a6cebffd173ca3(x5770cdefd8931aa9, x31f7755ef1c3e8a3: false);
	}

	private void xb0b7ba9b57236331(ShapeBase x5770cdefd8931aa9)
	{
		x824b646a7759e64d(x5770cdefd8931aa9);
		x4f95f44435ab20ed(x5770cdefd8931aa9);
		x5da365af81fafb38(x5770cdefd8931aa9);
		x4cefe4b20532460c x4cefe4b20532460c2 = x4cefe4b20532460c.x07aec41b62646646(x8cedcaa9a62c6e39, x5770cdefd8931aa9);
		x4cefe4b20532460c2.x6210059f049f0d48(x0efda03510113407: true, x87e9ac2885e28700: false, x10884bb8036bcee0.x1a23317d325de634);
		x824b646a7759e64d(x5770cdefd8931aa9);
		x8cedcaa9a62c6e39.xf81237e03ccdf47f.x98ab27c28fa098eb(x4797cf69c5ec19ff: true);
	}

	private void xa9a6cebffd173ca3(ShapeBase x5770cdefd8931aa9, bool x31f7755ef1c3e8a3)
	{
		xbfd162a6d47f59a4 xe1410f585439c7d = x8cedcaa9a62c6e39.xe1410f585439c7d4;
		xe1410f585439c7d.xee60bff2900a72f2(x5770cdefd8931aa9.IsGroup ? "\\shpgrp" : "\\shp");
		xe1410f585439c7d.xee60bff2900a72f2("\\*\\shpinst");
		if (x31f7755ef1c3e8a3)
		{
			xfb426646e9a7f451.x409f6d17d51b0ce0(x5770cdefd8931aa9);
		}
		else
		{
			xfb426646e9a7f451.x6210059f049f0d48(x5770cdefd8931aa9, x8cedcaa9a62c6e39.xf41b717aaedc8265);
		}
		if (xd69cbb14962f3cdb(x5770cdefd8931aa9))
		{
			xe1410f585439c7d.xee60bff2900a72f2("\\shptxt");
		}
	}

	private void xf39b0e49df97d58b(ShapeBase x5770cdefd8931aa9)
	{
		int num = xed158952e6342987.x4961afe4ff4567c4(xb92b8edd4b869c7d);
		while (x5770cdefd8931aa9 != null)
		{
			x5770cdefd8931aa9.xc95ed8e8690eb564 = num++;
			int xdf3d5f8941ea27a = x5770cdefd8931aa9.xdf3d5f8941ea27a6;
			x5770cdefd8931aa9 = ((xdf3d5f8941ea27a != 0) ? ((Shape)x8cedcaa9a62c6e39.x8556eed81191af11.xe42bd130f1e95570[xdf3d5f8941ea27a]) : null);
		}
		xb92b8edd4b869c7d++;
	}

	private void x4f95f44435ab20ed(ShapeBase x5770cdefd8931aa9)
	{
		xbfd162a6d47f59a4 xe1410f585439c7d = x8cedcaa9a62c6e39.xe1410f585439c7d4;
		if (xd69cbb14962f3cdb(x5770cdefd8931aa9))
		{
			xe1410f585439c7d.xc8a13a52db0580ae();
		}
		xe1410f585439c7d.xc8a13a52db0580ae();
		if (x8cedcaa9a62c6e39.xf57de0fd37d5e97d.ExportImagesForOldReaders && x5770cdefd8931aa9.CanHaveImage)
		{
			xe1410f585439c7d.xee60bff2900a72f2("\\shprslt");
			xe1410f585439c7d.x4d14ee33f46b5913("\\par");
			xe1410f585439c7d.x4d14ee33f46b5913("\\pard");
			x4cefe4b20532460c x4cefe4b20532460c2 = new x4cefe4b20532460c(x8cedcaa9a62c6e39, x5770cdefd8931aa9);
			x4cefe4b20532460c2.x6210059f049f0d48(x0efda03510113407: false, x87e9ac2885e28700: true, x10884bb8036bcee0.x1a23317d325de634);
			xe1410f585439c7d.x4d14ee33f46b5913("\\par");
			xe1410f585439c7d.xc8a13a52db0580ae();
		}
		xe1410f585439c7d.xc8a13a52db0580ae();
	}

	private void x5da365af81fafb38(ShapeBase x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.IsTopLevel)
		{
			x8cedcaa9a62c6e39.xe1410f585439c7d4.xa07aa514e9082b3a();
			x8cedcaa9a62c6e39.x6fca94e50472ae68.x6210059f049f0d48(x5770cdefd8931aa9.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226), x00ce61b8358bb4cc: true);
		}
	}

	private void x824b646a7759e64d(ShapeBase x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.IsTopLevel)
		{
			x8cedcaa9a62c6e39.xe1410f585439c7d4.x4ecc66ceff7a75c0();
		}
	}

	private static bool xd69cbb14962f3cdb(ShapeBase x5770cdefd8931aa9)
	{
		if (!x5770cdefd8931aa9.IsGroup)
		{
			if (!x5770cdefd8931aa9.HasChildNodes)
			{
				return x5770cdefd8931aa9.xa170cce2bc40bdf5;
			}
			return true;
		}
		return false;
	}
}
