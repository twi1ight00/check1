using System.Drawing;
using ns218;

namespace ns235;

internal class Class6216 : Class6212
{
	private const int int_0 = 0;

	private SizeF sizeF_0 = SizeF.Empty;

	private readonly int int_1;

	private bool bool_0;

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

	public float Width => sizeF_0.Width;

	public float Height => sizeF_0.Height;

	public int WidthPixels => Class5955.smethod_2(Width);

	public int HeightPixels => Class5955.smethod_2(Height);

	public int PaperTray => int_1;

	public Class6216(float width, float height)
		: this(new SizeF(width, height), 0)
	{
	}

	public Class6216(SizeF size, int tray)
	{
		sizeF_0 = size;
		int_1 = tray;
	}

	public bool method_1()
	{
		return bool_0;
	}

	public void method_2(bool endPage)
	{
		bool_0 = endPage;
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_0(this);
		try
		{
			base.vmethod_0(visitor);
		}
		catch (Exception58)
		{
			visitor.vmethod_1(this);
			throw;
		}
		visitor.vmethod_1(this);
	}
}
