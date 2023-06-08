using System;
using Aspose.Words;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using xf9a9481c3f63a419;
using xfc5388ad7dff404f;

namespace xa8550ea6ae4a81a5;

internal class x2191414f532035e4
{
	internal static void x6210059f049f0d48(x07e190e23dab42a9 xbdfb620b7167944b)
	{
		if (xbdfb620b7167944b.x2c8c6741422a1298.x55676d6d0c3d48c0)
		{
			x8f3af96aa56f1e32 x8f3af96aa56f1e33 = xbdfb620b7167944b.xa24813b526772a3b("customizations.xml", "application/vnd.ms-word.keyMapCustomizations+xml", "http://schemas.microsoft.com/office/2006/relationships/keyMapCustomizations");
			x8f3af96aa56f1e33.x9b9ed0109b743e3b("wne:tcg");
			x8f3af96aa56f1e33.xff520a0047c27122("xmlns:r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			x8f3af96aa56f1e33.xff520a0047c27122("xmlns:wne", "http://schemas.microsoft.com/office/word/2006/wordml");
			xccb16536683d1953(xbdfb620b7167944b, x8f3af96aa56f1e33);
			x341afb81620b6db8(xbdfb620b7167944b, x8f3af96aa56f1e33);
			x9ddab32af77472ac(xbdfb620b7167944b, x8f3af96aa56f1e33);
			x8f3af96aa56f1e33.xa0dfc102c691b11f();
		}
	}

	private static void xccb16536683d1953(x07e190e23dab42a9 xbdfb620b7167944b, x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		Document x2c8c6741422a = xbdfb620b7167944b.x2c8c6741422a1298;
		if (!x2c8c6741422a.x6241a8bc689c088a)
		{
			return;
		}
		xd07ce4b74c5774a7.x2307058321cdb62f("wne:keymaps");
		foreach (x8ee6b62105cb1a44 item in x2c8c6741422a.xd971f86352b6d53c)
		{
			if (item.x3146d638ec378671 != 0)
			{
				xd07ce4b74c5774a7.x2307058321cdb62f("wne:keymap");
				if (item.x3146d638ec378671 == xf396a2b7859eb922.x2c8724332a4788a6)
				{
					xd07ce4b74c5774a7.x943f6be3acf634db("wne:mask", 1);
				}
				x071ee96aa5c0b55b(xd07ce4b74c5774a7, "wne:chmPrimary", item.xf50fbcf496bb26c8);
				x071ee96aa5c0b55b(xd07ce4b74c5774a7, "wne:chmSecondary", item.xd87d0c6750ba0381);
				x071ee96aa5c0b55b(xd07ce4b74c5774a7, "wne:kcmPrimary", item.x57a5e17c3ececd6e);
				x071ee96aa5c0b55b(xd07ce4b74c5774a7, "wne:kcmSecondary", item.xc6f6af1a95493305);
				switch (item.x3146d638ec378671)
				{
				case xf396a2b7859eb922.xf5e19a19d8e0a0e6:
					xd07ce4b74c5774a7.x2307058321cdb62f("wne:acd");
					xd07ce4b74c5774a7.x943f6be3acf634db("wne:acdName", xb887c4a1b70568de(item.x2d2721048f49b2bd));
					xd07ce4b74c5774a7.x2dfde153f4ef96d0();
					break;
				case xf396a2b7859eb922.x76ad36638702d9bf:
				{
					xd07ce4b74c5774a7.x2307058321cdb62f("wne:fci");
					int x74c5a2d6929342db = (int)item.x74c5a2d6929342db;
					xd07ce4b74c5774a7.x943f6be3acf634db("wne:fciIndex", xca004f56614e2431.x7c1a0f9da8274fe8(x74c5a2d6929342db));
					xd07ce4b74c5774a7.x943f6be3acf634db("wne:swArg", xca004f56614e2431.x7c1a0f9da8274fe8(item.x8399367fe4b42e85));
					xd07ce4b74c5774a7.x2dfde153f4ef96d0();
					break;
				}
				case xf396a2b7859eb922.x9ad02857f9b5feb6:
					xd07ce4b74c5774a7.x2307058321cdb62f("wne:macro");
					xd07ce4b74c5774a7.x943f6be3acf634db("wne:macroName", item.x71dd8c34587f8fc0);
					xd07ce4b74c5774a7.x2dfde153f4ef96d0();
					break;
				case xf396a2b7859eb922.xef7830d5b1716fcd:
					xd07ce4b74c5774a7.x2307058321cdb62f("wne:wch");
					xd07ce4b74c5774a7.x943f6be3acf634db("wne:val", xca004f56614e2431.xaa4e6020773f88bc(item.x32dcc9d3ca30726c));
					xd07ce4b74c5774a7.x2dfde153f4ef96d0();
					break;
				case xf396a2b7859eb922.x86183739a8825637:
					xd07ce4b74c5774a7.x2307058321cdb62f("wne:wll");
					xd07ce4b74c5774a7.x943f6be3acf634db("wne:macroName", item.x71dd8c34587f8fc0);
					xd07ce4b74c5774a7.x2dfde153f4ef96d0();
					break;
				default:
					throw new InvalidOperationException("Unknown keymap type.");
				case xf396a2b7859eb922.x4d0b9d4447ba7566:
				case xf396a2b7859eb922.x2c8724332a4788a6:
					break;
				}
				xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			}
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x071ee96aa5c0b55b(x873451caae5ad4ae xf468ade57d60a816, string xc15bd84e01929885, int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != 0)
		{
			xf468ade57d60a816.x943f6be3acf634db(xc15bd84e01929885, xca004f56614e2431.x7c1a0f9da8274fe8(xbcea506a33cf9111));
		}
	}

	private static string xb887c4a1b70568de(int x670bbd39df926946)
	{
		return $"acd{x670bbd39df926946}";
	}

	private static void x341afb81620b6db8(x07e190e23dab42a9 xbdfb620b7167944b, x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		Document x2c8c6741422a = xbdfb620b7167944b.x2c8c6741422a1298;
		if (!x2c8c6741422a.xd4f5fcbd0eb0353a && !x2c8c6741422a.xf6b81fe1e8a261f5)
		{
			return;
		}
		xd07ce4b74c5774a7.x2307058321cdb62f("wne:toolbars");
		if (x2c8c6741422a.xd4f5fcbd0eb0353a)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("wne:acdManifest");
			for (int i = 0; i < x2c8c6741422a.x92fa7c4d9fc66489.Count; i++)
			{
				xd07ce4b74c5774a7.x2307058321cdb62f("wne:acdEntry");
				xd07ce4b74c5774a7.x943f6be3acf634db("wne:acdName", xb887c4a1b70568de(i));
				xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			}
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
		if (x2c8c6741422a.xf6b81fe1e8a261f5)
		{
			string xc06e652f250a;
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xbdfb620b7167944b.x39c7aeeec1af9dd0.x42c5f80e2ed823ff(xd07ce4b74c5774a7.x398b3bd0acd94b61, "attachedToolbars.bin", "application/vnd.ms-word.attachedToolbars", "http://schemas.microsoft.com/office/2006/relationships/attachedToolbars", out xc06e652f250a);
			xa2f1c3dcbd86f20a.xb8a774e0111d0fbe.Write(x2c8c6741422a.x1bb9c356aa4ee24d, 0, x2c8c6741422a.x1bb9c356aa4ee24d.Length);
			xd07ce4b74c5774a7.x942df950ff3fdafd("wne:toolbarData", xc06e652f250a);
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x9ddab32af77472ac(x07e190e23dab42a9 xbdfb620b7167944b, x873451caae5ad4ae xd07ce4b74c5774a7)
	{
		Document x2c8c6741422a = xbdfb620b7167944b.x2c8c6741422a1298;
		if (!x2c8c6741422a.xd4f5fcbd0eb0353a)
		{
			return;
		}
		xd07ce4b74c5774a7.x2307058321cdb62f("wne:acds");
		for (int i = 0; i < x2c8c6741422a.x92fa7c4d9fc66489.Count; i++)
		{
			xf5e19a19d8e0a0e6 xf5e19a19d8e0a0e = (xf5e19a19d8e0a0e6)x2c8c6741422a.x92fa7c4d9fc66489[i];
			if (xf5e19a19d8e0a0e.x7bc28568bfa1ae1c != 0)
			{
				xd07ce4b74c5774a7.x2307058321cdb62f("wne:acd");
				xd07ce4b74c5774a7.x943f6be3acf634db("wne:argValue", xf5e19a19d8e0a0e.x09b3682d5c365bf7);
				xd07ce4b74c5774a7.x943f6be3acf634db("wne:acdName", xb887c4a1b70568de(i));
				int x7bc28568bfa1ae1c = (int)xf5e19a19d8e0a0e.x7bc28568bfa1ae1c;
				xd07ce4b74c5774a7.x943f6be3acf634db("wne:fciIndexBasedOn", xca004f56614e2431.x7c1a0f9da8274fe8(x7bc28568bfa1ae1c));
				xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			}
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}
}
