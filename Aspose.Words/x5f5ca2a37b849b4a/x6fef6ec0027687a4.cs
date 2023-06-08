using x24ed092a62874e86;
using x9e34b6f7e9185197;

namespace x5f5ca2a37b849b4a;

internal class x6fef6ec0027687a4
{
	private int x765fcfde94dce361;

	private x19119439284aead2[] x416daa5f27da7c5c;

	private xda4dde4038ab80db[] x268ed50457065dac;

	internal int x3be6f9894635446f => x765fcfde94dce361;

	internal x19119439284aead2[] x2c0320b7c80c1e61 => x416daa5f27da7c5c;

	internal xda4dde4038ab80db[] x30f0af038def5996 => x268ed50457065dac;

	internal x6fef6ec0027687a4(int themedFill, x19119439284aead2 color, xda4dde4038ab80db colorModifier)
		: this(themedFill, new x19119439284aead2[1] { color }, new xda4dde4038ab80db[1] { colorModifier })
	{
	}

	internal x6fef6ec0027687a4(int themedFill, x19119439284aead2[] colors, xda4dde4038ab80db colorModifier)
		: this(themedFill, colors, new xda4dde4038ab80db[1] { colorModifier })
	{
	}

	internal x6fef6ec0027687a4(int themedFill, x19119439284aead2[] colors, xda4dde4038ab80db[] colorModifiers)
	{
		x765fcfde94dce361 = themedFill;
		x416daa5f27da7c5c = colors;
		x268ed50457065dac = colorModifiers;
	}
}
