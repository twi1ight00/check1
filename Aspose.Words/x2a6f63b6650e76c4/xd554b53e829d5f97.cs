using System;
using System.Collections;

namespace x2a6f63b6650e76c4;

internal class xd554b53e829d5f97 : x209f3e4a2f735d1e, IEnumerable
{
	private readonly xe02d79c539b6382d x9c2966082f84c86a;

	private readonly xb8f8d187f6793877 xda41fb38d19d0ee2;

	bool x209f3e4a2f735d1e.x3b634e1fe06f2a1c => false;

	bool x209f3e4a2f735d1e.x2e39ff7109112d84 => false;

	xe02d79c539b6382d x209f3e4a2f735d1e.x9f8c133ccef2c16c => null;

	xe02d79c539b6382d x209f3e4a2f735d1e.x92116d159a362cf8 => null;

	internal xe02d79c539b6382d x89f700c5ff3d93e4 => x9c2966082f84c86a;

	internal xb8f8d187f6793877 xdbfa333b4cd503e0 => xda41fb38d19d0ee2;

	internal xd554b53e829d5f97(xe02d79c539b6382d referencePosition, xb8f8d187f6793877 direction)
	{
		x9c2966082f84c86a = referencePosition;
		xda41fb38d19d0ee2 = direction;
	}

	internal static x82e26649b09596bd x19890931227f0f56(x12e7545fad3ccc9b x0f7b23d1c393aed9, string xc15bd84e01929885, out x209f3e4a2f735d1e x9b10ace6509508c0)
	{
		x9b10ace6509508c0 = null;
		xb8f8d187f6793877 xb8f8d187f6793878;
		switch (xc15bd84e01929885.ToUpper())
		{
		case "ABOVE":
			xb8f8d187f6793878 = xb8f8d187f6793877.x2e8310e038e73798;
			break;
		case "BELOW":
			xb8f8d187f6793878 = xb8f8d187f6793877.x7af9190cf6099399;
			break;
		case "LEFT":
			xb8f8d187f6793878 = xb8f8d187f6793877.x72d92bd1aff02e37;
			break;
		case "RIGHT":
			xb8f8d187f6793878 = xb8f8d187f6793877.x419ba17a5322627b;
			break;
		default:
			return null;
		}
		if (x0f7b23d1c393aed9.xc5464084edc8e226 == null)
		{
			return new xf7d966ea5d1701b6("!The Formula Not In Table");
		}
		xe02d79c539b6382d xe02d79c539b6382d2 = new xe02d79c539b6382d(x0f7b23d1c393aed9.xc5464084edc8e226);
		switch (xb8f8d187f6793878)
		{
		case xb8f8d187f6793877.x2e8310e038e73798:
			if (xe02d79c539b6382d2.xc95e2772f13b118e)
			{
				return new xf7d966ea5d1701b6("!Table Index Cannot be Zero");
			}
			break;
		case xb8f8d187f6793877.x7af9190cf6099399:
			if (xe02d79c539b6382d2.x68c5cc3196e669be)
			{
				return new x918e475ee39e3253(0.0);
			}
			break;
		case xb8f8d187f6793877.x72d92bd1aff02e37:
			if (xe02d79c539b6382d2.xe27d24f5402f718b)
			{
				return new xf7d966ea5d1701b6("!Table Index Cannot be Zero");
			}
			break;
		case xb8f8d187f6793877.x419ba17a5322627b:
			if (xe02d79c539b6382d2.xe827bb03048c257c)
			{
				return new x918e475ee39e3253(0.0);
			}
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		x9b10ace6509508c0 = new xd554b53e829d5f97(xe02d79c539b6382d2, xb8f8d187f6793878);
		return null;
	}

	private IEnumerator x05b0b83b5e6c5de6()
	{
		return x4e68fc46f3a05e16.x8506c44a27b96f94(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x05b0b83b5e6c5de6
		return this.x05b0b83b5e6c5de6();
	}
}
