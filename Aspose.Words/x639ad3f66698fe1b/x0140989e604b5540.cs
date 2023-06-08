using Aspose.Words;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using x9db5f2e5af3d596e;

namespace x639ad3f66698fe1b;

internal class x0140989e604b5540
{
	private x21f0d20d41203be1 x8cedcaa9a62c6e39;

	internal static bool x492f529cee830a40;

	private xbfd162a6d47f59a4 xe1410f585439c7d4 => x8cedcaa9a62c6e39.xe1410f585439c7d4;

	internal x0140989e604b5540(x21f0d20d41203be1 context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal void x6210059f049f0d48(Cell xe6de5e5fa2d44af5)
	{
		xf8cef531dae89ea3 xf8cef531dae89ea = xe6de5e5fa2d44af5.xf8cef531dae89ea3;
		Border x14cf9593b86ecbaa = null;
		Border x14cf9593b86ecbaa2 = null;
		Border x14cf9593b86ecbaa3 = null;
		Border x14cf9593b86ecbaa4 = null;
		Border x14cf9593b86ecbaa5 = null;
		Border x14cf9593b86ecbaa6 = null;
		Shading x12b7f8e5698b30a = null;
		for (int i = 0; i < xf8cef531dae89ea.xd44988f225497f3a; i++)
		{
			int num = xf8cef531dae89ea.xf15263674eb297bb(i);
			object obj = xf8cef531dae89ea.x6d3720b962bd3112(i);
			switch (num)
			{
			case 3040:
				xf22d0bb79eccb80b((CellMerge)obj);
				break;
			case 3030:
				x64eecc0825b51c81((CellMerge)obj);
				break;
			case 3190:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\clFitText", (bool)obj);
				break;
			case 3180:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\clNoWrap", !(bool)obj);
				break;
			case 3220:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\clhidemark", (bool)obj);
				break;
			case 3090:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\clpadt", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\clpadft3");
				break;
			case 3100:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\clpadr", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\clpadfr3");
				break;
			case 3070:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\clpadl", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\clpadfl3");
				break;
			case 3080:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\clpadb", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\clpadfb3");
				break;
			case 3020:
				xe1410f585439c7d4.xcdbc678d36159c69("\\clwWidth", "\\clftsWidth", (PreferredWidth)obj);
				break;
			case 3060:
				xe1410f585439c7d4.x4d14ee33f46b5913(x6e170ce4c1e43b64.x0b72d88f38f024c0((CellVerticalAlignment)obj));
				break;
			case 3050:
				xe1410f585439c7d4.x4d14ee33f46b5913(x6e170ce4c1e43b64.x524cce487cb301ab((TextOrientation)obj));
				break;
			case 3120:
				x14cf9593b86ecbaa = (Border)obj;
				break;
			case 3140:
				x14cf9593b86ecbaa2 = (Border)obj;
				break;
			case 3110:
				x14cf9593b86ecbaa3 = (Border)obj;
				break;
			case 3130:
				x14cf9593b86ecbaa4 = (Border)obj;
				break;
			case 3160:
				x14cf9593b86ecbaa5 = (Border)obj;
				break;
			case 3150:
				x14cf9593b86ecbaa6 = (Border)obj;
				break;
			case 3170:
				x12b7f8e5698b30a = (Shading)obj;
				break;
			default:
				_ = x492f529cee830a40;
				break;
			case 3010:
			case 10010:
				break;
			}
		}
		x7bb3fbb369864bd2(x14cf9593b86ecbaa, xe6de5e5fa2d44af5, 3120, "\\clbrdrl");
		x7bb3fbb369864bd2(x14cf9593b86ecbaa2, xe6de5e5fa2d44af5, 3140, "\\clbrdrr");
		x7bb3fbb369864bd2(x14cf9593b86ecbaa3, xe6de5e5fa2d44af5, 3110, "\\clbrdrt");
		x7bb3fbb369864bd2(x14cf9593b86ecbaa4, xe6de5e5fa2d44af5, 3130, "\\clbrdrb");
		x7bb3fbb369864bd2(x14cf9593b86ecbaa5, xe6de5e5fa2d44af5, 3160, "\\cldgll");
		x7bb3fbb369864bd2(x14cf9593b86ecbaa6, xe6de5e5fa2d44af5, 3150, "\\cldglu");
		xb93ca4dae426dc65(x12b7f8e5698b30a, xe6de5e5fa2d44af5);
	}

	private void xf22d0bb79eccb80b(CellMerge xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case CellMerge.First:
			xe1410f585439c7d4.x4d14ee33f46b5913("\\clmgf");
			break;
		case CellMerge.Previous:
			xe1410f585439c7d4.x4d14ee33f46b5913("\\clmrg");
			break;
		case CellMerge.None:
			break;
		}
	}

	private void x64eecc0825b51c81(CellMerge xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case CellMerge.First:
			xe1410f585439c7d4.x4d14ee33f46b5913("\\clvmgf");
			break;
		case CellMerge.Previous:
			xe1410f585439c7d4.x4d14ee33f46b5913("\\clvmrg");
			break;
		case CellMerge.None:
			break;
		}
	}

	private void x7bb3fbb369864bd2(Border x14cf9593b86ecbaa, xf516b6b0dd7e0d14 x1a84eefd5d3e114a, int xba08ce632055a1d9, string x6be0110c7154b456)
	{
		if (x14cf9593b86ecbaa == null || x14cf9593b86ecbaa.xa157de8185757b11)
		{
			x14cf9593b86ecbaa = (Border)x1a84eefd5d3e114a.x4c5c531cd5714601(xba08ce632055a1d9);
		}
		if (x14cf9593b86ecbaa.IsVisible || !x8cedcaa9a62c6e39.xf57de0fd37d5e97d.ExportCompactSize)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913(x6be0110c7154b456);
			if (x14cf9593b86ecbaa.IsVisible)
			{
				x4bf0725a1c29dbf0.xf3de23fd492ab916(x8cedcaa9a62c6e39, x14cf9593b86ecbaa);
			}
			else
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\brdrnone");
			}
		}
	}

	private void xb93ca4dae426dc65(Shading x12b7f8e5698b30a6, xf516b6b0dd7e0d14 x1a84eefd5d3e114a)
	{
		if (x12b7f8e5698b30a6 == null || x12b7f8e5698b30a6.xa157de8185757b11)
		{
			x12b7f8e5698b30a6 = (Shading)x1a84eefd5d3e114a.x4c5c531cd5714601(3170);
		}
		if (x12b7f8e5698b30a6.xa853df7acdb217c8)
		{
			xf2c041437cd4ab14.x6210059f049f0d48(x8cedcaa9a62c6e39, x12b7f8e5698b30a6, "\\clshdng", "\\clcbpat", "\\clcfpat", x6e170ce4c1e43b64.xac5a7a97f8b14aea(x12b7f8e5698b30a6.Texture));
		}
	}
}
