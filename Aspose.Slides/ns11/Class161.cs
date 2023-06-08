using System.Drawing.Drawing2D;
using ns224;

namespace ns11;

internal abstract class Class161 : Class159
{
	private float float_0;

	private float float_1;

	private int int_0;

	private int int_1;

	protected Class6002 class6002_1;

	protected Class6002 class6002_2;

	public override float DpiX => float_0;

	public override float DpiY => float_1;

	public override int Width => int_0;

	public override int Height => int_1;

	protected override Class6002 TransformImpl
	{
		get
		{
			return class6002_1;
		}
		set
		{
			class6002_1 = value.Clone();
			class6002_2 = value.Clone();
			class6002_2.method_5(DpiX / 576f, DpiY / 576f, MatrixOrder.Append);
			vmethod_4();
		}
	}

	protected Class161(int canvasWidth, int canvasHeight, float dpiX, float dpiY)
		: base(null)
	{
		float_0 = dpiX;
		float_1 = dpiY;
		int_0 = canvasWidth;
		int_1 = canvasHeight;
		TransformImpl = new Class6002();
	}
}
