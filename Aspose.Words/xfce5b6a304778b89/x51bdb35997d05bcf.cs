using Aspose.Words;

namespace xfce5b6a304778b89;

internal class x51bdb35997d05bcf
{
	private x51bdb35997d05bcf()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, x09bf2b07acaf11a4 xfb7c3d67fd08b1e3)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		int num = x430d72944b3d049c(xe134235b3526fa75);
		if (xe134235b3526fa75.xf13a626e550cef8f == -1)
		{
			if (num == 1)
			{
				xe134235b3526fa75.x49e385128b291987 = true;
			}
			if (num == 0)
			{
				xe134235b3526fa75.x49e385128b291987 = false;
			}
		}
		else
		{
			xe134235b3526fa75.x49e385128b291987 = true;
		}
		if (xfb7c3d67fd08b1e3 == null || (xe134235b3526fa75.xe5ffcf1e3f9bd387 != null && xe134235b3526fa75.xe5ffcf1e3f9bd387 != xfb7c3d67fd08b1e3.x759aa16c2016a289))
		{
			xfb7c3d67fd08b1e3 = xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, (string)null, xe134235b3526fa75.xb9e32c79bd755ad8) as x09bf2b07acaf11a4;
		}
		xe134235b3526fa75.xf13a626e550cef8f++;
		while (xca994afbcb9073a.x152cbadbfa8061b1("list"))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "list-header":
				x41a34ff33ad9ec64(xe134235b3526fa75, x8b2c3c076d5a7daf, "list-header", xfb7c3d67fd08b1e3);
				break;
			case "list-item":
				x895be302a6cc29f2(xe134235b3526fa75, x8b2c3c076d5a7daf, xfb7c3d67fd08b1e3);
				break;
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
			xe134235b3526fa75.x49e385128b291987 = true;
		}
		xe134235b3526fa75.xf13a626e550cef8f--;
		if (xe134235b3526fa75.xf13a626e550cef8f == -1)
		{
			xe134235b3526fa75.x49e385128b291987 = false;
		}
	}

	private static int x430d72944b3d049c(xf871da68decec406 xe134235b3526fa75)
	{
		xe134235b3526fa75.xe5ffcf1e3f9bd387 = null;
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		int result = -1;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (!xe134235b3526fa75.x81c468031b83f5fc(xca994afbcb9073a))
			{
				switch (xca994afbcb9073a.xa66385d80d4d296f)
				{
				case "continue-numbering":
					result = ((xca994afbcb9073a.xd2f68ee6f47e9dfb == "true") ? 1 : 0);
					break;
				case "continue-list":
					result = 1;
					break;
				}
			}
		}
		return result;
	}

	private static void x895be302a6cc29f2(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, x09bf2b07acaf11a4 xfb7c3d67fd08b1e3)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "start-value" && xfb7c3d67fd08b1e3 != null)
			{
				xfb7c3d67fd08b1e3.x06ca69422bbb7502.ListLevels[xe134235b3526fa75.xf13a626e550cef8f].StartAt = xca994afbcb9073a.xbba6773b8ce56a01;
			}
		}
		x41a34ff33ad9ec64(xe134235b3526fa75, x8b2c3c076d5a7daf, "list-item", xfb7c3d67fd08b1e3);
	}

	private static void x41a34ff33ad9ec64(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, string x121383aa64985888, x09bf2b07acaf11a4 xfb7c3d67fd08b1e3)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		bool x0ff7f9ed695bb89a = true;
		while (xca994afbcb9073a.x152cbadbfa8061b1(x121383aa64985888))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "p":
			case "h":
				xef3217fa00e6d2ba.x06b0e25aa6ad68a9(xe134235b3526fa75, xca994afbcb9073a.xa66385d80d4d296f, x8b2c3c076d5a7daf, xfb7c3d67fd08b1e3, x0ff7f9ed695bb89a);
				x0ff7f9ed695bb89a = false;
				break;
			case "list":
				x06b0e25aa6ad68a9(xe134235b3526fa75, x8b2c3c076d5a7daf, xfb7c3d67fd08b1e3);
				break;
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
	}
}
