namespace ns271;

internal class Class6659
{
	private readonly int int_0;

	private readonly int int_1;

	private readonly int int_2;

	private readonly int int_3;

	private readonly bool bool_0;

	private readonly bool bool_1;

	private bool bool_2;

	public int dX => int_2;

	public int dY => int_3;

	public int X => int_0;

	public int Y => int_1;

	public bool IsOnCurve => bool_0;

	public bool IsEndOfContour => bool_1;

	public bool IsRefPoint
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	internal Class6659(int dx, int dy, int absoluteX, int absoluteY, bool isOnCurve, bool isEndOfContour)
	{
		int_2 = dx;
		int_3 = dy;
		int_0 = absoluteX;
		int_1 = absoluteY;
		bool_0 = isOnCurve;
		bool_1 = isEndOfContour;
	}
}
