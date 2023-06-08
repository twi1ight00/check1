namespace ns243;

internal struct Struct220
{
	public float float_0;

	public float float_1;

	public float float_2;

	public float float_3;

	public static Struct220 Zero => new Struct220(0f, 0f, 0f, 0f);

	public Struct220(float top, float left, float right, float bottom)
	{
		float_0 = top;
		float_1 = left;
		float_2 = right;
		float_3 = bottom;
	}
}
