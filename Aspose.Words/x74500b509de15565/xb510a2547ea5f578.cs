using System;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xa7850104c8d8c135;
using xf9a9481c3f63a419;

namespace x74500b509de15565;

internal class xb510a2547ea5f578 : x4cb7537b071ca71a
{
	public xb510a2547ea5f578(x3fa09e8d7b952fbc metafileInfo, xb0d8039f74776744 apsBuilderContext)
		: base(metafileInfo, apsBuilderContext)
	{
	}

	protected override xb8e7e788f6d59708 DoPlay()
	{
		try
		{
			SizeF x1de68a531466236f = new SizeF(base.x4aca0559c9e6ddc0.xf2b3620f7bfc9ed5, base.x4aca0559c9e6ddc0.x5c6fc5693c6898cd);
			if (x1de68a531466236f.Height == 0f && x1de68a531466236f.Width != 0f)
			{
				x1de68a531466236f = new SizeF(x1de68a531466236f.Width, x1de68a531466236f.Width);
			}
			else if (x1de68a531466236f.Height != 0f && x1de68a531466236f.Width == 0f)
			{
				x1de68a531466236f = new SizeF(x1de68a531466236f.Height, x1de68a531466236f.Height);
			}
			else if (x1de68a531466236f.Height == 0f && x1de68a531466236f.Width == 0f)
			{
				x1de68a531466236f = new SizeF(96f, 96f);
			}
			base.x4aca0559c9e6ddc0.xb8a774e0111d0fbe.Position = 0L;
			byte[] array = xaf1d5886bde15736.x9ae3c76542ff5bd7(base.x4aca0559c9e6ddc0.xb8a774e0111d0fbe, x1de68a531466236f);
			SizeF xc6da7d30336037ec = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(array).xc6da7d30336037ec;
			x72c34b8dbaec3734 xda5bf54deb817e = new x72c34b8dbaec3734(default(PointF), xc6da7d30336037ec, array);
			xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
			xb8e7e788f6d.xd6b6ed77479ef68c(xda5bf54deb817e);
			xb8e7e788f6d.x52dde376accdec7d = x54366fa5f75a02f7.x6698fc0971e66ffb(new RectangleF(default(PointF), xc6da7d30336037ec), new RectangleF(default(PointF), base.x437e3b626c0fdd43));
			return xb8e7e788f6d;
		}
		catch (Exception ex)
		{
			base.xa6f30a6360be2a75.x4d2cf6c77ee521cd().xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, x3959df40367ac8a3.x5459fadea977d08d, "GDI+ failed to process the metafile: {0}", ex.Message);
			base.xa6f30a6360be2a75.xec8728ceac69f279 = true;
			return null;
		}
	}
}
