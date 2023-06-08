using Aspose.Words;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;

namespace x1495530f35d79681;

internal class x2a19dee8776aaa44
{
	private x2a19dee8776aaa44()
	{
	}

	internal static void x5d14aa99881b11fb(string xc15bd84e01929885, StyleCollection x3fa6ecdd18b2ff6e, bool x5409eeb7bc334110, Style x44ecfea61c937b8e)
	{
		x0d299f323d241756.x48501aec8e48c869(xc15bd84e01929885, "name");
		x0d299f323d241756.x0aaaea7864a53f26(x3fa6ecdd18b2ff6e, "styles");
		x0d299f323d241756.x0aaaea7864a53f26(x44ecfea61c937b8e, "style");
		StyleIdentifier styleIdentifier = (x5409eeb7bc334110 ? StyleIdentifier.User : x72a0c846678ecaf9.x3b3cea4656a2e16d(xc15bd84e01929885));
		if (styleIdentifier != StyleIdentifier.User)
		{
			xc15bd84e01929885 = x72a0c846678ecaf9.xebaf9df1cc1ad15a(xc15bd84e01929885);
		}
		if (x3fa6ecdd18b2ff6e.x263d579af1d0d43f(styleIdentifier))
		{
			styleIdentifier = StyleIdentifier.User;
		}
		int num = xd9263e6f13384bf1.x778a4fac7992bc43(styleIdentifier);
		if (num == 4095)
		{
			num = x3fa6ecdd18b2ff6e.xdc32dcfe6668100d();
		}
		x44ecfea61c937b8e.x7ac71dcbd33d6241(styleIdentifier);
		x44ecfea61c937b8e.x2b8399f052630a13(xc15bd84e01929885);
		x44ecfea61c937b8e.xd01720d5ff2238cc(num);
		x44ecfea61c937b8e.xfb77c9ea054ac31c = num;
	}
}
