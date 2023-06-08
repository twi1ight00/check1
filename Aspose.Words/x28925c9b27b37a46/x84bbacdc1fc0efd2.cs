using Aspose.Words;

namespace x28925c9b27b37a46;

internal class x84bbacdc1fc0efd2 : x11e014059489ae95
{
	private int x4574aea041dd835f;

	private LineSpacingRule xc44be4886a493c98;

	public bool xc8ea2954a6825f32 => false;

	internal int xd2f68ee6f47e9dfb
	{
		get
		{
			return x4574aea041dd835f;
		}
		set
		{
			x4574aea041dd835f = value;
		}
	}

	internal LineSpacingRule xea9485ec61071863
	{
		get
		{
			return xc44be4886a493c98;
		}
		set
		{
			xc44be4886a493c98 = value;
		}
	}

	internal x84bbacdc1fc0efd2(int value, LineSpacingRule rule)
	{
		x4574aea041dd835f = value;
		xc44be4886a493c98 = rule;
	}

	public static x84bbacdc1fc0efd2 x3c58c039066df51e()
	{
		x84bbacdc1fc0efd2 x84bbacdc1fc0efd3 = (x84bbacdc1fc0efd2)x1a78664fa10a3755.x0095b789d636f3ae(1650);
		return x84bbacdc1fc0efd3.x8b61531c8ea35b85();
	}

	public x84bbacdc1fc0efd2 x8b61531c8ea35b85()
	{
		return (x84bbacdc1fc0efd2)MemberwiseClone();
	}

	public x11e014059489ae95 xcc4933610939ad04()
	{
		return (x84bbacdc1fc0efd2)MemberwiseClone();
	}

	internal bool Equals(x84bbacdc1fc0efd2 rhs)
	{
		if (x4574aea041dd835f == rhs.x4574aea041dd835f)
		{
			return xc44be4886a493c98 == rhs.xc44be4886a493c98;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj.GetType() != typeof(x84bbacdc1fc0efd2))
		{
			return false;
		}
		return Equals((x84bbacdc1fc0efd2)obj);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
