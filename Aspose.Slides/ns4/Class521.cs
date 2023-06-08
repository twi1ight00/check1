using System.Drawing;

namespace ns4;

internal sealed class Class521
{
	private PointF pointF_0;

	private float float_0;

	private float float_1;

	private float float_2;

	public PointF Center => pointF_0;

	public float Angle => float_0;

	public float ScaleX => float_1;

	public float ScaleY => float_2;

	public Class521(float centerX, float centerY, float angle, float scaleX, float scaleY)
	{
		pointF_0 = new PointF(centerX, centerY);
		float_0 = angle;
		float_1 = scaleX;
		float_2 = scaleY;
	}
}
