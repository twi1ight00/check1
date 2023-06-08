using System;
using System.Drawing;
using Aspose;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;
using xa7850104c8d8c135;

namespace x74500b509de15565;

internal abstract class x4cb7537b071ca71a
{
	private readonly xb0d8039f74776744 xd563a235b0ace4c8;

	private readonly x3fa09e8d7b952fbc x44bb21011b34eca8;

	private SizeF x3b77a41bd57164d6;

	private bool x46bf013b689e7bb5;

	public SizeF x437e3b626c0fdd43 => x3b77a41bd57164d6;

	public bool x6cd834400ec1b81e => x46bf013b689e7bb5;

	public xb0d8039f74776744 xa6f30a6360be2a75 => xd563a235b0ace4c8;

	internal x3fa09e8d7b952fbc x4aca0559c9e6ddc0 => x44bb21011b34eca8;

	protected x54b98d0096d7251a xf69ca7a9bb4a4a51 => xa6f30a6360be2a75.x4d2cf6c77ee521cd();

	protected x4cb7537b071ca71a(x3fa09e8d7b952fbc metafileInfo, xb0d8039f74776744 apsBuilderContext)
	{
		xd563a235b0ace4c8 = apsBuilderContext;
		x44bb21011b34eca8 = metafileInfo;
	}

	internal xb8e7e788f6d59708 x0613827d1b6c81c9(SizeF x0ceec69a97f73617, bool x48c97d04abed82b6)
	{
		try
		{
			x3b77a41bd57164d6 = x0ceec69a97f73617;
			x46bf013b689e7bb5 = x48c97d04abed82b6;
			return DoPlay();
		}
		catch (Exception ex)
		{
			xf69ca7a9bb4a4a51.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, x3959df40367ac8a3.x5459fadea977d08d, "Metafile cannot be processed: {0}", ex.Message);
			xa6f30a6360be2a75.xec8728ceac69f279 = true;
			return null;
		}
	}

	[JavaThrows(true)]
	protected abstract xb8e7e788f6d59708 DoPlay();
}
