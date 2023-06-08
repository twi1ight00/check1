using System.Threading;
using Aspose;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal abstract class x7ddd810cb8bb8f44
{
	private Thread x6425f95d3cf7ed99;

	public bool x20862f902304f373 => x6425f95d3cf7ed99.IsAlive;

	public void x12cb12b5d2cad53d()
	{
		x6425f95d3cf7ed99 = new Thread(DoWork);
		x6425f95d3cf7ed99.Start();
	}

	protected abstract void DoWork();
}
