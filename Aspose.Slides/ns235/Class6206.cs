using System.Drawing;

namespace ns235;

internal class Class6206 : Class6205
{
	private string string_3;

	private SizeF sizeF_0;

	public SizeF Size
	{
		get
		{
			return sizeF_0;
		}
		set
		{
			sizeF_0 = value;
		}
	}

	public string Caption
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public override RectangleF BoundingBox => new RectangleF(base.Origin, sizeF_0);

	public Class6206(PointF origin, string name, SizeF size)
		: base(origin, name)
	{
		sizeF_0 = size;
	}

	public Class6206()
	{
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_18(this);
	}
}
