using xa7850104c8d8c135;
using xe9865c3fb834da49;

namespace Aspose.Words.Saving;

public class MetafileRenderingOptions
{
	private EmfPlusDualRenderingMode xc82cbbb066f86a34;

	private MetafileRenderingMode xfbf964c0da574e10;

	private bool xcacc93965216fd11 = true;

	public MetafileRenderingMode RenderingMode
	{
		get
		{
			return xfbf964c0da574e10;
		}
		set
		{
			xfbf964c0da574e10 = value;
		}
	}

	public EmfPlusDualRenderingMode EmfPlusDualRenderingMode
	{
		get
		{
			return xc82cbbb066f86a34;
		}
		set
		{
			xc82cbbb066f86a34 = value;
		}
	}

	public bool UseEmfEmbeddedToWmf
	{
		get
		{
			return xcacc93965216fd11;
		}
		set
		{
			xcacc93965216fd11 = value;
		}
	}

	internal x6edb191c4eaef585 x5eff1f3a09faac7e()
	{
		x6edb191c4eaef585 x6edb191c4eaef = new x6edb191c4eaef585();
		x6edb191c4eaef.xd41c83b6f451eaa6 = x254b8e0d5c68f194.x13bb04a23dd090b6(RenderingMode);
		x6edb191c4eaef.xea5fd6cabb198568 = x254b8e0d5c68f194.x449c51d78e7b8858(EmfPlusDualRenderingMode);
		x6edb191c4eaef.xff53682edbd8fefe = UseEmfEmbeddedToWmf;
		return x6edb191c4eaef;
	}
}
