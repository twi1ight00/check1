using System.Drawing;
using ns218;

namespace ns235;

internal class Class6270
{
	private readonly RectangleF rectangleF_0 = RectangleF.Empty;

	private readonly bool bool_0;

	private readonly string string_0;

	private readonly Enum802 enum802_0;

	private readonly Enum803 enum803_0;

	private readonly int int_0;

	public RectangleF ActiveRect => rectangleF_0;

	public bool IsLocal => bool_0;

	public string Target => string_0;

	public Enum802 HyperlinkType => enum802_0;

	public Enum803 JumpType => enum803_0;

	public int Page => int_0;

	protected bool Equals(Class6270 other)
	{
		RectangleF rectangleF = rectangleF_0;
		if (rectangleF.Equals(other.rectangleF_0) && bool_0.Equals(other.bool_0) && string.Equals(string_0, other.string_0) && enum802_0 == other.enum802_0 && enum803_0 == other.enum803_0)
		{
			return int_0 == other.int_0;
		}
		return false;
	}

	public static bool Equals(Class6270 x, Class6270 y)
	{
		if (object.ReferenceEquals(x, y))
		{
			return true;
		}
		if (object.ReferenceEquals(x, null) && object.ReferenceEquals(y, null))
		{
			return true;
		}
		if (object.ReferenceEquals(x, null))
		{
			return false;
		}
		return x.Equals(y);
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
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((Class6270)obj);
	}

	public override int GetHashCode()
	{
		RectangleF rectangleF = rectangleF_0;
		int hashCode = rectangleF.GetHashCode();
		hashCode = (hashCode * 397) ^ bool_0.GetHashCode();
		hashCode = (hashCode * 397) ^ ((string_0 != null) ? string_0.GetHashCode() : 0);
		hashCode = (hashCode * 397) ^ (int)enum802_0;
		hashCode = (hashCode * 397) ^ (int)enum803_0;
		return (hashCode * 397) ^ int_0;
	}

	public Class6270(RectangleF activeRect, string targetUri)
	{
		rectangleF_0 = activeRect;
		if (Class5973.smethod_15(targetUri))
		{
			bool_0 = true;
			string_0 = targetUri.Substring(1);
		}
		else
		{
			bool_0 = false;
			string_0 = targetUri;
		}
		enum802_0 = Enum802.const_0;
		enum803_0 = Enum803.const_0;
		int_0 = -1;
	}

	public Class6270(RectangleF activeRect, Enum803 jumpType)
	{
		enum802_0 = Enum802.const_1;
		enum803_0 = jumpType;
		rectangleF_0 = activeRect;
		bool_0 = true;
		int_0 = -1;
	}

	public Class6270(RectangleF activeRect, int page)
	{
		enum802_0 = Enum802.const_1;
		enum803_0 = Enum803.const_7;
		rectangleF_0 = activeRect;
		bool_0 = true;
		int_0 = page;
	}
}
