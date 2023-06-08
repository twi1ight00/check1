using Aspose.Words;
using Aspose.Words.Tables;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;
using xf9a9481c3f63a419;

namespace xdbe3cd173bd00464;

internal class xc946ba15e395060e
{
	private xc946ba15e395060e()
	{
	}

	internal static void x96072a935905c3fb(x873451caae5ad4ae xd07ce4b74c5774a7, Font x26094932cf7a9139, x9df536d98415d2d0 x8b1a40fd1ddfa567, bool xb36a059a5e87b854)
	{
		xd07ce4b74c5774a7.x943f6be3acf634db("FontFamily", x26094932cf7a9139.Name);
		xd07ce4b74c5774a7.x943f6be3acf634db("FontSize", $"{xca004f56614e2431.xdbca7a004e2d3753(x26094932cf7a9139.Size)}pt");
		if (x26094932cf7a9139.Italic)
		{
			xd07ce4b74c5774a7.x943f6be3acf634db("FontStyle", "Italic");
		}
		if (x26094932cf7a9139.Bold)
		{
			xd07ce4b74c5774a7.x943f6be3acf634db("FontWeight", "Bold");
		}
		if (x26094932cf7a9139.Underline != 0)
		{
			xd07ce4b74c5774a7.x943f6be3acf634db("TextDecorations", "Underline");
		}
		if (!xb36a059a5e87b854)
		{
			if (!x26094932cf7a9139.xff8cd6f1d57322e6.x7149c962c02931b3)
			{
				xd07ce4b74c5774a7.x943f6be3acf634db("Background", xb2b537767a3ea62c.xfafbf12cd38285b5(x26094932cf7a9139.xff8cd6f1d57322e6));
			}
			xd07ce4b74c5774a7.x943f6be3acf634db("Foreground", xb2b537767a3ea62c.xfafbf12cd38285b5(x8b1a40fd1ddfa567.xa6dfa2703204e9f0(x26094932cf7a9139.x63b1a7c31a962459)));
			x864ca8045769f8cd(xd07ce4b74c5774a7, x26094932cf7a9139.Bidi);
		}
	}

	internal static void x9ed6d11bbfc54525(x873451caae5ad4ae xd07ce4b74c5774a7, ParagraphFormat x82a4dd3377ffb686)
	{
		xd07ce4b74c5774a7.x0ea3ef8dd3ae2f3f("KeepTogether", x82a4dd3377ffb686.KeepTogether);
		xd07ce4b74c5774a7.x0ea3ef8dd3ae2f3f("KeepWithNext", x82a4dd3377ffb686.KeepWithNext);
		xd07ce4b74c5774a7.x25e28424582ee3ac("TextAlignment", xb2b537767a3ea62c.x7f90501c33a75aa6(x82a4dd3377ffb686.Alignment), "Left");
		if (x82a4dd3377ffb686.FirstLineIndent > 0.0)
		{
			xd07ce4b74c5774a7.x943f6be3acf634db("TextIndent", xb2b537767a3ea62c.x541e8c2724a511cc(x82a4dd3377ffb686.FirstLineIndent, "pt"));
		}
		xa37fc1555c01fc86(xd07ce4b74c5774a7, "Margin", x82a4dd3377ffb686.LeftIndent, x82a4dd3377ffb686.SpaceBefore, x82a4dd3377ffb686.RightIndent, x82a4dd3377ffb686.SpaceAfter);
		xb93ca4dae426dc65(xd07ce4b74c5774a7, x82a4dd3377ffb686.Shading);
		xa653462abd146df5(xd07ce4b74c5774a7, x82a4dd3377ffb686.Borders.Left, x82a4dd3377ffb686.Borders.Top, x82a4dd3377ffb686.Borders.Right, x82a4dd3377ffb686.Borders.Bottom);
		x864ca8045769f8cd(xd07ce4b74c5774a7, x82a4dd3377ffb686.Bidi);
	}

	internal static void xf36e6c2240ea983f(x873451caae5ad4ae xd07ce4b74c5774a7, Table x1ec770899c98a268)
	{
		xa37fc1555c01fc86(xd07ce4b74c5774a7, "Padding", x1ec770899c98a268.LeftPadding, x1ec770899c98a268.TopPadding, x1ec770899c98a268.RightPadding, x1ec770899c98a268.BottomPadding);
		xa37fc1555c01fc86(xd07ce4b74c5774a7, "Margin", x1ec770899c98a268.LeftIndent, 0.0, 0.0, 0.0);
		xd07ce4b74c5774a7.x943f6be3acf634db("CellSpacing", $"{xca004f56614e2431.xdbca7a004e2d3753(x1ec770899c98a268.CellSpacing)}pt");
		x864ca8045769f8cd(xd07ce4b74c5774a7, x1ec770899c98a268.Bidi);
	}

	internal static void xf9cf13cc959f2cbb(x873451caae5ad4ae xd07ce4b74c5774a7, xf8cef531dae89ea3 x51dd02ffcbaa972d)
	{
		xa653462abd146df5(xd07ce4b74c5774a7, x51dd02ffcbaa972d.xaea087ab32102492, x51dd02ffcbaa972d.xa8c2637cc4888928, x51dd02ffcbaa972d.xd7a21e27974f626c, x51dd02ffcbaa972d.x79d902473861f242);
		xb93ca4dae426dc65(xd07ce4b74c5774a7, x51dd02ffcbaa972d.x554aca059bdf6d48);
	}

	private static void x864ca8045769f8cd(x873451caae5ad4ae xd07ce4b74c5774a7, bool x4d21032b3ed37672)
	{
		if (x4d21032b3ed37672)
		{
			xd07ce4b74c5774a7.x943f6be3acf634db("FlowDirection", "RightToLeft");
		}
	}

	private static void xa653462abd146df5(x873451caae5ad4ae xd07ce4b74c5774a7, Border xa447fc54e41dfe06, Border xc941868c59399d3e, Border xfc2074a859a5db8c, Border xaf9a0436a70689de)
	{
		Border border = x560972f561dbebd2(xa447fc54e41dfe06, xc941868c59399d3e, xfc2074a859a5db8c, xaf9a0436a70689de);
		if (border != null)
		{
			xa37fc1555c01fc86(xd07ce4b74c5774a7, "BorderThickness", xa256a24167988278(xa447fc54e41dfe06) ? xa447fc54e41dfe06.LineWidth : 0.0, xa256a24167988278(xc941868c59399d3e) ? xc941868c59399d3e.LineWidth : 0.0, xa256a24167988278(xfc2074a859a5db8c) ? xfc2074a859a5db8c.LineWidth : 0.0, xa256a24167988278(xaf9a0436a70689de) ? xaf9a0436a70689de.LineWidth : 0.0);
			xd07ce4b74c5774a7.x943f6be3acf634db("BorderBrush", xb2b537767a3ea62c.xfafbf12cd38285b5(border.x63b1a7c31a962459.x7149c962c02931b3 ? x26d9ecb4bdf0456d.x89fffa2751fdecbe : border.x63b1a7c31a962459));
		}
	}

	private static bool xa256a24167988278(Border x14cf9593b86ecbaa)
	{
		if (x14cf9593b86ecbaa != null)
		{
			return x14cf9593b86ecbaa.LineStyle != LineStyle.None;
		}
		return false;
	}

	private static Border x560972f561dbebd2(Border xa447fc54e41dfe06, Border xc941868c59399d3e, Border xfc2074a859a5db8c, Border xaf9a0436a70689de)
	{
		Border result = null;
		if (xa256a24167988278(xa447fc54e41dfe06))
		{
			result = xa447fc54e41dfe06;
		}
		else if (xa256a24167988278(xc941868c59399d3e))
		{
			result = xc941868c59399d3e;
		}
		else if (xa256a24167988278(xfc2074a859a5db8c))
		{
			result = xfc2074a859a5db8c;
		}
		else if (xa256a24167988278(xaf9a0436a70689de))
		{
			result = xaf9a0436a70689de;
		}
		return result;
	}

	private static void xb93ca4dae426dc65(x873451caae5ad4ae xd07ce4b74c5774a7, Shading x12b7f8e5698b30a6)
	{
		if (x12b7f8e5698b30a6 != null)
		{
			if (!x12b7f8e5698b30a6.x0e18178ac4b2272f.x7149c962c02931b3)
			{
				xd07ce4b74c5774a7.x943f6be3acf634db("Background", xb2b537767a3ea62c.xfafbf12cd38285b5(x12b7f8e5698b30a6.x0e18178ac4b2272f));
			}
			if (!x12b7f8e5698b30a6.xc290f60df004e384.x7149c962c02931b3)
			{
				xd07ce4b74c5774a7.x943f6be3acf634db("Foreground", xb2b537767a3ea62c.xfafbf12cd38285b5(x12b7f8e5698b30a6.xc290f60df004e384));
			}
		}
	}

	private static void xa37fc1555c01fc86(x873451caae5ad4ae xd07ce4b74c5774a7, string x9e89cc6e6284edf4, double xa447fc54e41dfe06, double xc941868c59399d3e, double xfc2074a859a5db8c, double xaf9a0436a70689de)
	{
		if (x15e971129fd80714.xd23801717be7f91e(xa447fc54e41dfe06, xc941868c59399d3e) && x15e971129fd80714.xd23801717be7f91e(xa447fc54e41dfe06, xfc2074a859a5db8c) && x15e971129fd80714.xd23801717be7f91e(xa447fc54e41dfe06, xaf9a0436a70689de))
		{
			xd07ce4b74c5774a7.x943f6be3acf634db(x9e89cc6e6284edf4, xb2b537767a3ea62c.x541e8c2724a511cc(xa447fc54e41dfe06, "pt"));
			return;
		}
		xd07ce4b74c5774a7.x943f6be3acf634db(x9e89cc6e6284edf4, string.Format("{0},{1},{2},{3}", xb2b537767a3ea62c.x541e8c2724a511cc(xa447fc54e41dfe06, "pt"), xb2b537767a3ea62c.x541e8c2724a511cc(xc941868c59399d3e, "pt"), xb2b537767a3ea62c.x541e8c2724a511cc(xfc2074a859a5db8c, "pt"), xb2b537767a3ea62c.x541e8c2724a511cc(xaf9a0436a70689de, "pt")));
	}
}
