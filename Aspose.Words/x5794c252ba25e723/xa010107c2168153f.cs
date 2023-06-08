namespace x5794c252ba25e723;

internal class xa010107c2168153f : xcb322cb732dde676
{
	private float x7cf290e345b9b3cf;

	private float x7b7c4bf07166b4da;

	private float x66a07f4e5b3cbf17;

	public float x8df91a2f90079e88
	{
		get
		{
			return x7cf290e345b9b3cf;
		}
		set
		{
			x7cf290e345b9b3cf = value;
		}
	}

	public float xc821290d7ecc08bf
	{
		get
		{
			return x7b7c4bf07166b4da;
		}
		set
		{
			x7b7c4bf07166b4da = value;
		}
	}

	public float xe7189024fdf97d87
	{
		get
		{
			return x66a07f4e5b3cbf17;
		}
		set
		{
			x66a07f4e5b3cbf17 = value;
		}
	}

	public override void Accept(x2f90c0cfb1f8b01a visitor)
	{
		visitor.VisitPoint(this);
	}

	public xa010107c2168153f()
	{
		x7cf290e345b9b3cf = 0f;
		x7b7c4bf07166b4da = 0f;
		x66a07f4e5b3cbf17 = 0f;
	}

	public xa010107c2168153f(float x, float y, float z)
	{
		x7cf290e345b9b3cf = x;
		x7b7c4bf07166b4da = y;
		x66a07f4e5b3cbf17 = z;
	}
}
