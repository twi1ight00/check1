using System.Drawing;
using ns252;

namespace ns249;

internal class Class6364
{
	private Class6329 class6329_0 = new Class6329();

	private Class6329 class6329_1 = new Class6329();

	private Class6329 class6329_2 = new Class6329();

	private Class6329 class6329_3 = new Class6329();

	public Class6329 BottomOffset
	{
		get
		{
			return class6329_0;
		}
		set
		{
			class6329_0 = value;
		}
	}

	public Class6329 TopOffset
	{
		get
		{
			return class6329_3;
		}
		set
		{
			class6329_3 = value;
		}
	}

	public Class6329 LeftOffset
	{
		get
		{
			return class6329_1;
		}
		set
		{
			class6329_1 = value;
		}
	}

	public Class6329 RightOffset
	{
		get
		{
			return class6329_2;
		}
		set
		{
			class6329_2 = value;
		}
	}

	public Class6364()
	{
	}

	public Class6364(double leftOffsetFraction, double topOffsetFraction, double rightOffsetFraction, double bottomOffsetFraction)
	{
		class6329_0 = Class6329.smethod_0(bottomOffsetFraction);
		class6329_1 = Class6329.smethod_0(leftOffsetFraction);
		class6329_2 = Class6329.smethod_0(rightOffsetFraction);
		class6329_3 = Class6329.smethod_0(topOffsetFraction);
	}

	public Class6364(Class6329 leftOffset, Class6329 topOffset, Class6329 rightOffset, Class6329 bottomOffset)
	{
		class6329_0 = bottomOffset;
		class6329_1 = leftOffset;
		class6329_2 = rightOffset;
		class6329_3 = topOffset;
	}

	public bool Equals(Class6364 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (object.Equals(other.class6329_0, class6329_0) && object.Equals(other.class6329_1, class6329_1) && object.Equals(other.class6329_2, class6329_2))
		{
			return object.Equals(other.class6329_3, class6329_3);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(Class6364))
		{
			return false;
		}
		return Equals((Class6364)obj);
	}

	public override int GetHashCode()
	{
		int num = ((class6329_0 != null) ? class6329_0.GetHashCode() : 0);
		num = (num * 397) ^ ((class6329_1 != null) ? class6329_1.GetHashCode() : 0);
		num = (num * 397) ^ ((class6329_2 != null) ? class6329_2.GetHashCode() : 0);
		return (num * 397) ^ ((class6329_3 != null) ? class6329_3.GetHashCode() : 0);
	}

	public Class6364 Clone()
	{
		Class6364 @class = new Class6364();
		@class.TopOffset = TopOffset;
		@class.BottomOffset = BottomOffset;
		@class.LeftOffset = LeftOffset;
		@class.RightOffset = RightOffset;
		return @class;
	}

	public RectangleF method_0(RectangleF rect)
	{
		float width = rect.Width;
		float height = rect.Height;
		float left = (float)((double)rect.Left + (double)width * LeftOffset.Fraction);
		float right = (float)((double)rect.Right - (double)width * RightOffset.Fraction);
		float top = (float)((double)rect.Top + (double)height * TopOffset.Fraction);
		float bottom = (float)((double)rect.Bottom - (double)height * BottomOffset.Fraction);
		return RectangleF.FromLTRB(left, top, right, bottom);
	}
}
