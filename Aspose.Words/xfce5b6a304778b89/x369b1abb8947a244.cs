using Aspose.Words.Settings;
using x55b2bd426d41d30c;

namespace xfce5b6a304778b89;

internal class x369b1abb8947a244
{
	private x369b1abb8947a244()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75)
	{
		xe134235b3526fa75.x2c8c6741422a1298.xdade2366eaa6f915.xe322902ca0e695f5.DoNotUseHTMLParagraphAutoSpacing = true;
		x0ca5e8b532953a51 x0ca5e8b532953a = xe134235b3526fa75.x39c7aeeec1af9dd0.x5621ebad67e4df79("/settings.xml");
		if (x0ca5e8b532953a == null)
		{
			return;
		}
		x536e1b48249b1390 x536e1b48249b1392 = (xe134235b3526fa75.xca994afbcb9073a2 = new x536e1b48249b1390(x0ca5e8b532953a.xb8a774e0111d0fbe));
		while (x536e1b48249b1392.x152cbadbfa8061b1("document-settings"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x536e1b48249b1392.xa66385d80d4d296f) != null && xa66385d80d4d296f == "settings")
			{
				x56109671a8f391d1(xe134235b3526fa75);
			}
			else
			{
				x536e1b48249b1392.IgnoreElement();
			}
		}
	}

	private static void x56109671a8f391d1(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("settings"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "config-item-set")
			{
				x4c8ece90bc188f07(xe134235b3526fa75);
			}
			else
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
	}

	private static void x4c8ece90bc188f07(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("config-item-set"))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "config-item":
				x859ccb96a0281370(xe134235b3526fa75);
				break;
			case "config-item-map-indexed":
				x1a4ae82100a98eb1(xe134235b3526fa75);
				break;
			default:
				xe134235b3526fa75.xca994afbcb9073a2.IgnoreElement();
				break;
			}
		}
	}

	private static void x57f384ca27faa6f3(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("config-item-map-entry"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "config-item")
			{
				x859ccb96a0281370(xe134235b3526fa75);
			}
			else
			{
				xe134235b3526fa75.xca994afbcb9073a2.IgnoreElement();
			}
		}
	}

	private static void x1a4ae82100a98eb1(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		if (!(xca994afbcb9073a.xd68abcd61e368af9("name", "") == "Views"))
		{
			return;
		}
		while (xca994afbcb9073a.x152cbadbfa8061b1("config-item-map-indexed"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "config-item-map-entry")
			{
				x57f384ca27faa6f3(xe134235b3526fa75);
			}
			else
			{
				xe134235b3526fa75.xca994afbcb9073a2.IgnoreElement();
			}
		}
	}

	private static void x859ccb96a0281370(xf871da68decec406 xe134235b3526fa75)
	{
		CompatibilityOptions xe322902ca0e695f = xe134235b3526fa75.x2c8c6741422a1298.xdade2366eaa6f915.xe322902ca0e695f5;
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "name")
			{
				switch (xca994afbcb9073a.xd2f68ee6f47e9dfb)
				{
				case "AddParaSpacingToTableCells":
					xe134235b3526fa75.xf3a0f9e4e429f8f2 = xca994afbcb9073a.x0291058ae9d2ec36();
					return;
				case "ShowRedlineChanges":
					xe134235b3526fa75.x2c8c6741422a1298.xdade2366eaa6f915.x14fd633e1477f9de = xca994afbcb9073a.x0291058ae9d2ec36();
					return;
				case "AddParaTableSpacing":
					xe322902ca0e695f.DoNotUseHTMLParagraphAutoSpacing = xca994afbcb9073a.x0291058ae9d2ec36();
					return;
				case "AddExternalLeading":
					xe322902ca0e695f.NoLeading = !xca994afbcb9073a.x0291058ae9d2ec36();
					return;
				case "ZoomType":
					xe134235b3526fa75.x2c8c6741422a1298.ViewOptions.ZoomType = (ZoomType)xca994afbcb9073a.xab461f3453328cf7();
					return;
				case "ZoomFactor":
					xe134235b3526fa75.x2c8c6741422a1298.ViewOptions.ZoomPercent = xca994afbcb9073a.xab461f3453328cf7();
					return;
				case "UseFormerLineSpacing":
					xe322902ca0e695f.ApplyBreakingRules = xca994afbcb9073a.x0291058ae9d2ec36();
					return;
				}
			}
		}
	}
}
