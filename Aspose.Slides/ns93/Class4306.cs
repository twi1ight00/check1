using ns84;

namespace ns93;

internal class Class4306 : Class4305
{
	private readonly float float_0;

	private readonly float float_1;

	private readonly float float_2;

	private readonly float float_3;

	private readonly float float_4;

	private readonly float float_5;

	private readonly float float_6;

	private readonly float float_7;

	private readonly float float_8;

	private readonly float float_9;

	private readonly float float_10;

	private readonly float float_11;

	private readonly float float_12;

	private readonly float float_13;

	private readonly float float_14;

	private readonly float float_15;

	public float M11 => float_0;

	public float M12 => float_1;

	public float M13 => float_2;

	public float M14 => float_3;

	public float M21 => float_4;

	public float M22 => float_5;

	public float M23 => float_6;

	public float M24 => float_7;

	public float M31 => float_8;

	public float M32 => float_9;

	public float M33 => float_10;

	public float M34 => float_11;

	public float M41 => float_12;

	public float M42 => float_13;

	public float M43 => float_14;

	public float M44 => float_15;

	public Class4306(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
		: base(Enum511.const_20)
	{
		float_0 = m11;
		float_1 = m12;
		float_2 = m13;
		float_3 = m14;
		float_4 = m21;
		float_5 = m22;
		float_6 = m23;
		float_7 = m24;
		float_8 = m31;
		float_9 = m32;
		float_10 = m33;
		float_11 = m34;
		float_12 = m41;
		float_13 = m42;
		float_14 = m43;
		float_15 = m44;
	}

	public override string ToString()
	{
		return string.Format(Class4337.cultureInfo_0, "matrix3d({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15})", M11, M12, float_2, float_3, float_4, float_5, float_6, float_7, float_8, float_9, float_10, float_11, float_12, float_13, float_14, float_15);
	}
}
