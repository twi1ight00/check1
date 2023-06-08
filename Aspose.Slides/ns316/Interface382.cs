using System.Drawing;

namespace ns316;

internal interface Interface382
{
	bool IsConstant { get; }

	Color LightColor { set; }

	void imethod_0(float x, float y, float z, float[] result);

	float[][][] imethod_1(float x, float y, float dx, float dy, int width, int height, float[][][] elevation);

	float[][] imethod_2(float x, float y, float dx, int width, float[][] elevation, float[][] row);

	float[] imethod_3(bool linear);
}
