using System.Drawing.Drawing2D;
using x0097836593a6a96a;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using xa7850104c8d8c135;

namespace x24e0e4e48dc84bd8;

internal class x11d3005e3db787c9 : x273fb960e2b0a823
{
	private readonly x15e3f5f8a0a3fb3b x065f09505b5cc65a;

	private readonly x4e88096751fad171 xd995695f8e3419d6;

	public x11d3005e3db787c9(byte[] bytes, x15e3f5f8a0a3fb3b type, x4e88096751fad171 serviceLocator)
		: base(bytes)
	{
		xd995695f8e3419d6 = serviceLocator;
		x065f09505b5cc65a = type;
	}

	protected override x4fdf549af9de6b97 ConverToAps()
	{
		x6edb191c4eaef585 x6edb191c4eaef = new x6edb191c4eaef585();
		x6edb191c4eaef.xd41c83b6f451eaa6 = x81630573c48a5fdb.x377b65d6f94f815a;
		x6edb191c4eaef.xea5fd6cabb198568 = xfd36ea142a49c494.x047ce0e397babf66;
		xb0d8039f74776744 xb0d8039f = new xb0d8039f74776744();
		x776d392443cca64d x776d392443cca64d = x776d392443cca64d.xebcf83b00134300b(base.x90427ee74997bf7a, xb0d8039f);
		xb8e7e788f6d59708 xb8e7e788f6d = x776d392443cca64d.Play(x776d392443cca64d.xb444c09fa044bbca.x2ae4e44a2787f337, x6edb191c4eaef);
		if (xb0d8039f.xec8728ceac69f279)
		{
			xd995695f8e3419d6.x5e3cfff57135d485("Embedded metafile contains not supported records.");
		}
		if (xb8e7e788f6d.x52dde376accdec7d == null)
		{
			xb8e7e788f6d.x52dde376accdec7d = new x54366fa5f75a02f7();
		}
		xb8e7e788f6d.x52dde376accdec7d.xce92de628aa023cf(x776d392443cca64d.xb444c09fa044bbca.xee6354c7044d841a.X, x776d392443cca64d.xb444c09fa044bbca.xee6354c7044d841a.Y, MatrixOrder.Append);
		return xb8e7e788f6d;
	}
}
