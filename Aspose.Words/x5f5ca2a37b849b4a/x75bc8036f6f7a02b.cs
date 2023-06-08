using x24ed092a62874e86;
using x9e34b6f7e9185197;

namespace x5f5ca2a37b849b4a;

internal class x75bc8036f6f7a02b : x6fef6ec0027687a4
{
	private double x1aefc8a2390552c2;

	internal double xffa1fc725bf36690 => x1aefc8a2390552c2;

	internal x75bc8036f6f7a02b(int themedLine, x19119439284aead2 color, xda4dde4038ab80db colorModifier)
		: this(themedLine, new x19119439284aead2[1] { color }, new xda4dde4038ab80db[1] { colorModifier }, 0.0)
	{
	}

	internal x75bc8036f6f7a02b(int themedLine, x19119439284aead2[] colors, xda4dde4038ab80db[] colorModifiers)
		: this(themedLine, colors, colorModifiers, 0.0)
	{
	}

	internal x75bc8036f6f7a02b(int themedLine, x19119439284aead2[] colors, xda4dde4038ab80db colorModifier)
		: this(themedLine, colors, new xda4dde4038ab80db[1] { colorModifier }, 0.0)
	{
	}

	internal x75bc8036f6f7a02b(int themedLine, x19119439284aead2 color, xda4dde4038ab80db colorModifier, double lineWidth)
		: this(themedLine, new x19119439284aead2[1] { color }, new xda4dde4038ab80db[1] { colorModifier }, lineWidth)
	{
	}

	internal x75bc8036f6f7a02b(int themedLine, x19119439284aead2[] colors, xda4dde4038ab80db colorModifier, double lineWidth)
		: this(themedLine, colors, new xda4dde4038ab80db[1] { colorModifier }, lineWidth)
	{
	}

	internal x75bc8036f6f7a02b(int themedLine, x19119439284aead2[] colors, xda4dde4038ab80db[] colorModifiers, double lineWidth)
		: base(themedLine, colors, colorModifiers)
	{
		x1aefc8a2390552c2 = lineWidth;
	}
}
