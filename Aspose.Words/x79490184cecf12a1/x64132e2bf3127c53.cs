using System;
using System.Collections;
using Aspose.Words;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;
using xfc5388ad7dff404f;

namespace x79490184cecf12a1;

internal class x64132e2bf3127c53
{
	private xa52ef41af20225f0 xe1d718cca131846e;

	private x9ea8b270a83f04a0 xc3723d392789e04d;

	private readonly ArrayList x0cdb247813e6224d = new ArrayList();

	private readonly Hashtable x7387d0e00389fe8e = new Hashtable();

	private readonly Hashtable x8eff8d254a3d2da6 = new Hashtable();

	internal static void x06b0e25aa6ad68a9(xa52ef41af20225f0 x994e3cc0f99dd2dc)
	{
		x64132e2bf3127c53 x64132e2bf3127c54 = new x64132e2bf3127c53();
		x64132e2bf3127c54.x197a76fd29b1245d(x994e3cc0f99dd2dc);
	}

	private void x197a76fd29b1245d(xa52ef41af20225f0 xe134235b3526fa75)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xe134235b3526fa75.x4bfdbcbc6a51d705(xe134235b3526fa75.x2a0bb2f6650f6a43, "http://schemas.microsoft.com/office/2006/relationships/keyMapCustomizations");
		if (xa2f1c3dcbd86f20a == null)
		{
			return;
		}
		xe1d718cca131846e = xe134235b3526fa75;
		xc3723d392789e04d = new x9ea8b270a83f04a0(xa2f1c3dcbd86f20a);
		while (xc3723d392789e04d.x152cbadbfa8061b1("tcg"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "keymaps":
			case "keymapsBad":
				xdaed184686b56056();
				break;
			case "toolbars":
				xa7157bc802e03111();
				break;
			case "acds":
				xe8aa73aa1e849e61();
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
		x7e1657a9be4b3520();
		x7a5e086fba161501();
	}

	private void xdaed184686b56056()
	{
		if (xe1d718cca131846e.x2c8c6741422a1298.xd971f86352b6d53c == null)
		{
			xe1d718cca131846e.x2c8c6741422a1298.xd971f86352b6d53c = new ArrayList();
		}
		string xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f;
		while (xc3723d392789e04d.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			string xa66385d80d4d296f2;
			if ((xa66385d80d4d296f2 = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f2 == "keymap")
			{
				x0e1826cdfff7c53a();
			}
			else
			{
				xc3723d392789e04d.IgnoreElement();
			}
		}
	}

	private void x0e1826cdfff7c53a()
	{
		x8ee6b62105cb1a44 x8ee6b62105cb1a = new x8ee6b62105cb1a44();
		xe1d718cca131846e.x2c8c6741422a1298.xd971f86352b6d53c.Add(x8ee6b62105cb1a);
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "chmPrimary":
				x8ee6b62105cb1a.xf50fbcf496bb26c8 = xc1b08afa36bf580c.x5c612ff105e66e13(xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			case "chmSecondary":
				x8ee6b62105cb1a.xd87d0c6750ba0381 = xc1b08afa36bf580c.x5c612ff105e66e13(xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			case "kcmPrimary":
				x8ee6b62105cb1a.x57a5e17c3ececd6e = xc1b08afa36bf580c.x5c612ff105e66e13(xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			case "kcmSecondary":
				x8ee6b62105cb1a.xc6f6af1a95493305 = xc1b08afa36bf580c.x5c612ff105e66e13(xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			case "mask":
				if (xc3723d392789e04d.xc3be6b142c6aca84)
				{
					x8ee6b62105cb1a.x3146d638ec378671 = xf396a2b7859eb922.x2c8724332a4788a6;
				}
				break;
			}
		}
		while (xc3723d392789e04d.x152cbadbfa8061b1("keymap"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "acd":
				x8ee6b62105cb1a.x3146d638ec378671 = xf396a2b7859eb922.xf5e19a19d8e0a0e6;
				x8eff8d254a3d2da6[xc3723d392789e04d.xd68abcd61e368af9("acdName", "")] = x8ee6b62105cb1a;
				break;
			case "fci":
				x7aa21a004480904d(x8ee6b62105cb1a);
				break;
			case "macro":
				x8ee6b62105cb1a.x3146d638ec378671 = xf396a2b7859eb922.x9ad02857f9b5feb6;
				x8ee6b62105cb1a.x71dd8c34587f8fc0 = xc3723d392789e04d.xd68abcd61e368af9("macroName", "");
				break;
			case "wch":
				x8ee6b62105cb1a.x3146d638ec378671 = xf396a2b7859eb922.xef7830d5b1716fcd;
				x8ee6b62105cb1a.x32dcc9d3ca30726c = xc1b08afa36bf580c.x5c612ff105e66e13(xc3723d392789e04d.xbbfc54380705e01e());
				break;
			case "wll":
				x8ee6b62105cb1a.x3146d638ec378671 = xf396a2b7859eb922.x86183739a8825637;
				x8ee6b62105cb1a.x71dd8c34587f8fc0 = xc3723d392789e04d.xd68abcd61e368af9("macroName", "");
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void x7aa21a004480904d(x8ee6b62105cb1a44 x81bec917e1a3c2a4)
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "fciIndex":
				x81bec917e1a3c2a4.x3146d638ec378671 = xf396a2b7859eb922.x76ad36638702d9bf;
				x81bec917e1a3c2a4.x74c5a2d6929342db = (x74c5a2d6929342db)xc1b08afa36bf580c.x5c612ff105e66e13(xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			case "fciName":
				x81bec917e1a3c2a4.x3146d638ec378671 = xf396a2b7859eb922.x76ad36638702d9bf;
				x81bec917e1a3c2a4.x74c5a2d6929342db = xab27133b6f3c4288.x62c26ea349f5eafb(xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			case "swArg":
				x81bec917e1a3c2a4.x8399367fe4b42e85 = xc1b08afa36bf580c.x5c612ff105e66e13(xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			}
		}
	}

	private void xa7157bc802e03111()
	{
		while (xc3723d392789e04d.x152cbadbfa8061b1("toolbars"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "acdManifest":
				x926d4eddcd29d8c3();
				break;
			case "toolbarData":
				x9e21c0c1b45e2f8a();
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void x926d4eddcd29d8c3()
	{
		while (xc3723d392789e04d.x152cbadbfa8061b1("acdManifest"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f == "acdEntry")
			{
				xdf175a7109c11b6b();
			}
			else
			{
				xc3723d392789e04d.IgnoreElement();
			}
		}
	}

	private void xdf175a7109c11b6b()
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f == "acdName")
			{
				x0cdb247813e6224d.Add(xc3723d392789e04d.xd2f68ee6f47e9dfb);
			}
		}
	}

	private void x9e21c0c1b45e2f8a()
	{
		string xc06e652f250a = xc3723d392789e04d.xf3ea3ee1c9ee5265();
		string xc15bd84e = xc3723d392789e04d.x398b3bd0acd94b61.x052a6c2e603b1662(xc06e652f250a);
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xe1d718cca131846e.xd4e2719ccf56f4d7(xc15bd84e);
		xe1d718cca131846e.x2c8c6741422a1298.x1bb9c356aa4ee24d = x0d299f323d241756.xa0aed4cd3b3d5d92(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
	}

	private void xe8aa73aa1e849e61()
	{
		while (xc3723d392789e04d.x152cbadbfa8061b1("acds"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f == "acd")
			{
				x651360aafedeeeb7();
			}
			else
			{
				xc3723d392789e04d.IgnoreElement();
			}
		}
	}

	private void x651360aafedeeeb7()
	{
		string text = null;
		xf5e19a19d8e0a0e6 xf5e19a19d8e0a0e = new xf5e19a19d8e0a0e6();
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "acdName":
				text = xc3723d392789e04d.xd2f68ee6f47e9dfb;
				break;
			case "argValue":
				xf5e19a19d8e0a0e.x09b3682d5c365bf7 = Convert.FromBase64String(xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			case "fciBasedOn":
				xf5e19a19d8e0a0e.x7bc28568bfa1ae1c = xab27133b6f3c4288.x62c26ea349f5eafb(xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			case "fciIndexBasedOn":
				xf5e19a19d8e0a0e.x7bc28568bfa1ae1c = (x74c5a2d6929342db)xc1b08afa36bf580c.x5c612ff105e66e13(xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x7387d0e00389fe8e[text] = xf5e19a19d8e0a0e;
		}
	}

	private void x7e1657a9be4b3520()
	{
		if (x0cdb247813e6224d.Count == 0 || x7387d0e00389fe8e.Count == 0)
		{
			return;
		}
		Document x2c8c6741422a = xe1d718cca131846e.x2c8c6741422a1298;
		x2c8c6741422a.x92fa7c4d9fc66489 = new ArrayList();
		foreach (string item in x0cdb247813e6224d)
		{
			xf5e19a19d8e0a0e6 xf5e19a19d8e0a0e = (xf5e19a19d8e0a0e6)x7387d0e00389fe8e[item];
			if (xf5e19a19d8e0a0e == null)
			{
				xf5e19a19d8e0a0e = new xf5e19a19d8e0a0e6();
			}
			x2c8c6741422a.x92fa7c4d9fc66489.Add(xf5e19a19d8e0a0e);
		}
	}

	private void x7a5e086fba161501()
	{
		foreach (DictionaryEntry item in x8eff8d254a3d2da6)
		{
			string x52a83ee906aece = (string)item.Key;
			x8ee6b62105cb1a44 x8ee6b62105cb1a = (x8ee6b62105cb1a44)item.Value;
			x8ee6b62105cb1a.x2d2721048f49b2bd = x70d7d1c2dc90b779(x52a83ee906aece);
		}
	}

	private int x70d7d1c2dc90b779(string x52a83ee906aece14)
	{
		for (int i = 0; i < x0cdb247813e6224d.Count; i++)
		{
			if ((string)x0cdb247813e6224d[i] == x52a83ee906aece14)
			{
				return i;
			}
		}
		return -1;
	}
}
