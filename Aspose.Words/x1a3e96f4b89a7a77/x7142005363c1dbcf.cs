using Aspose.Words;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace x1a3e96f4b89a7a77;

internal class x7142005363c1dbcf
{
	private x7142005363c1dbcf()
	{
	}

	internal static void x6210059f049f0d48(xf8cef531dae89ea3 x51dd02ffcbaa972d, xfe11bbc13ba649c3 x0f7b23d1c393aed9)
	{
		if (x51dd02ffcbaa972d == null || x51dd02ffcbaa972d.xd44988f225497f3a == 0)
		{
			return;
		}
		x873451caae5ad4ae xe1410f585439c7d = x0f7b23d1c393aed9.xe1410f585439c7d4;
		xe1410f585439c7d.x2307058321cdb62f("w:tcPr");
		if (x51dd02ffcbaa972d.x5fb16e270c21db2e != null)
		{
			x7f77ea92be0d9042 x7f77ea92be0d = (x7f77ea92be0d9042)x51dd02ffcbaa972d.x8b61531c8ea35b85();
			x7f77ea92be0d.xcb395027497bc067();
			x60e7c3c569225ff5(x7f77ea92be0d, x0f7b23d1c393aed9);
			xe1410f585439c7d.xd0c5f01ab55153ce(x51dd02ffcbaa972d.x5fb16e270c21db2e, "w:tcPrChange", x0f7b23d1c393aed9.x28ee4b8b8f777b55());
			if (x0f7b23d1c393aed9.x325f1926b78ae5cd)
			{
				xe1410f585439c7d.x2307058321cdb62f("w:tcPr");
			}
			x60e7c3c569225ff5(x51dd02ffcbaa972d, x0f7b23d1c393aed9);
			if (x0f7b23d1c393aed9.x325f1926b78ae5cd)
			{
				xe1410f585439c7d.x2dfde153f4ef96d0();
			}
			xe1410f585439c7d.x44d8d13f25d44840();
		}
		else
		{
			x60e7c3c569225ff5(x51dd02ffcbaa972d, x0f7b23d1c393aed9);
		}
		xe1410f585439c7d.x2dfde153f4ef96d0();
	}

	private static void x60e7c3c569225ff5(x4c1e058c67948d6a xe9707cb1ec88db49, xfe11bbc13ba649c3 x0f7b23d1c393aed9)
	{
		bool x325f1926b78ae5cd = x0f7b23d1c393aed9.x325f1926b78ae5cd;
		x873451caae5ad4ae xe1410f585439c7d = x0f7b23d1c393aed9.xe1410f585439c7d4;
		PreferredWidth x961016a387451f = null;
		string text = null;
		string text2 = null;
		Border border = null;
		Border border2 = null;
		Border border3 = null;
		Border border4 = null;
		Border border5 = null;
		Border border6 = null;
		Border border7 = null;
		Border border8 = null;
		Shading x12b7f8e5698b30a = null;
		object xbcea506a33cf = null;
		string x60e3d97b97bb8c4b = null;
		string xc790aa4ad151a9a = null;
		string xbec4ce2ebab = null;
		string x9d14ae04d = null;
		string xbcea506a33cf2 = null;
		object xbcea506a33cf3 = null;
		string xbcea506a33cf4 = null;
		object xbcea506a33cf5 = null;
		object obj = null;
		for (int i = 0; i < xe9707cb1ec88db49.xd44988f225497f3a; i++)
		{
			int num = xe9707cb1ec88db49.xf15263674eb297bb(i);
			object obj2 = xe9707cb1ec88db49.x6d3720b962bd3112(i);
			switch (num)
			{
			case 3020:
				x961016a387451f = (PreferredWidth)obj2;
				break;
			case 3040:
				text = xd106566a5d9f6f46.x658fb4df5e4d113a((CellMerge)obj2);
				break;
			case 3030:
				text2 = xd106566a5d9f6f46.x658fb4df5e4d113a((CellMerge)obj2);
				break;
			case 3110:
				border = (Border)obj2;
				break;
			case 3120:
				border2 = (Border)obj2;
				break;
			case 3130:
				border3 = (Border)obj2;
				break;
			case 3140:
				border4 = (Border)obj2;
				break;
			case 3150:
				border5 = (Border)obj2;
				break;
			case 3160:
				border6 = (Border)obj2;
				break;
			case 3200:
				border7 = (Border)obj2;
				break;
			case 3210:
				border8 = (Border)obj2;
				break;
			case 3170:
				x12b7f8e5698b30a = (Shading)obj2;
				break;
			case 3070:
				x60e3d97b97bb8c4b = xca004f56614e2431.x754c3a5f03a2ce84((int)obj2);
				break;
			case 3090:
				xc790aa4ad151a9a = xca004f56614e2431.x754c3a5f03a2ce84((int)obj2);
				break;
			case 3080:
				xbec4ce2ebab = xca004f56614e2431.x754c3a5f03a2ce84((int)obj2);
				break;
			case 3100:
				x9d14ae04d = xca004f56614e2431.x754c3a5f03a2ce84((int)obj2);
				break;
			case 3180:
				if (!(bool)obj2)
				{
					xbcea506a33cf = true;
				}
				break;
			case 3220:
				if ((bool)obj2)
				{
					xbcea506a33cf5 = true;
				}
				break;
			case 3190:
				if ((bool)obj2)
				{
					xbcea506a33cf3 = true;
				}
				break;
			case 3050:
				if ((TextOrientation)obj2 != 0)
				{
					xbcea506a33cf2 = x72a0c846678ecaf9.x5d29ab24a0be9aab((TextOrientation)obj2, x325f1926b78ae5cd);
				}
				break;
			case 3060:
				if ((CellVerticalAlignment)obj2 != 0)
				{
					xbcea506a33cf4 = xd106566a5d9f6f46.x66809280b09b6f05((CellVerticalAlignment)obj2);
				}
				break;
			case 10010:
				_ = (x5fb16e270c21db2e)obj2;
				break;
			case 3900:
				obj = (int)obj2;
				break;
			}
		}
		xe1410f585439c7d.xcdbc678d36159c69("w:tcW", x961016a387451f);
		if (text != "restart" && obj != null && (int)obj > 1)
		{
			xe1410f585439c7d.x547195bcc386fe66("w:gridSpan", obj);
		}
		string x121383aa = (x325f1926b78ae5cd ? "w:hMerge" : "w:hmerge");
		if (text == "continue")
		{
			xe1410f585439c7d.xf68f9c3818e1f4b1(x121383aa);
		}
		else
		{
			xe1410f585439c7d.x547195bcc386fe66(x121383aa, text);
		}
		string x121383aa2 = (x325f1926b78ae5cd ? "w:vMerge" : "w:vmerge");
		if (text2 == "continue")
		{
			xe1410f585439c7d.xf68f9c3818e1f4b1(x121383aa2);
		}
		else
		{
			xe1410f585439c7d.x547195bcc386fe66(x121383aa2, text2);
		}
		xe1410f585439c7d.xa653462abd146df5("w:tcBorders", "w:top", border, "w:left", border2, "w:bottom", border3, "w:right", border4, "w:insideH", border7, "w:insideV", border8, "w:tl2br", border5, "w:tr2bl", border6);
		xe1410f585439c7d.xbcea76c28b5e9461(x12b7f8e5698b30a);
		xe1410f585439c7d.x547195bcc386fe66("w:noWrap", xbcea506a33cf);
		xe1410f585439c7d.x99a8871fc05f6874("w:tcMar", x60e3d97b97bb8c4b, xc790aa4ad151a9a, xbec4ce2ebab, x9d14ae04d);
		xe1410f585439c7d.x547195bcc386fe66(x325f1926b78ae5cd ? "w:textDirection" : "w:textFlow", xbcea506a33cf2);
		xe1410f585439c7d.x547195bcc386fe66("w:tcFitText", xbcea506a33cf3);
		xe1410f585439c7d.x547195bcc386fe66("w:vAlign", xbcea506a33cf4);
		xe1410f585439c7d.x547195bcc386fe66("w:hideMark", xbcea506a33cf5);
	}
}
