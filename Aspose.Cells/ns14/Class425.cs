using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns22;

namespace ns14;

internal class Class425 : Class424
{
	private Cell cell_0;

	private double double_2 = -1.0;

	public override double Width
	{
		get
		{
			if (double_2 < 0.0)
			{
				Range mergedRange = cell_0.GetMergedRange();
				if (mergedRange == null)
				{
					double_2 = cell_0.method_4().GetColumnWidth(cell_0.Column);
				}
				else
				{
					int i = mergedRange.FirstColumn;
					int num = i + mergedRange.ColumnCount;
					Cells cells = cell_0.method_4();
					double_2 = 0.0;
					for (; i < num; i++)
					{
						double_2 += cells.GetColumnWidth(i);
					}
				}
			}
			return double_2;
		}
	}

	internal Class425(Cell cell_1)
		: base(bool_1: false)
	{
		cell_0 = cell_1;
	}

	public virtual int vmethod_6(string string_0, char char_0)
	{
		if (cell_0.method_32().ShrinkToFit)
		{
			return 0;
		}
		return base.vmethod_5(string_0, char_0);
	}

	protected override int vmethod_0(string string_0)
	{
		if (cell_0.method_32().ShrinkToFit)
		{
			return 11;
		}
		return base.vmethod_0(string_0);
	}

	[SpecialName]
	protected override bool vmethod_4()
	{
		if (class484_0 == null)
		{
			int num = cell_0.method_35();
			if (num != 15 && num >= 0 && num < cell_0.method_4().method_19().method_58()
				.Count)
			{
				Style defaultStyle = cell_0.method_4().method_19().Workbook.DefaultStyle;
				Font font = defaultStyle.Font;
				Style style = cell_0.method_4().method_19().method_58()[num];
				Font font2 = style.method_40();
				if (font2 == null)
				{
					style = style.ParentStyle;
					if (style == null || style == defaultStyle)
					{
						return true;
					}
					font2 = style.method_40();
					if (font2 == null)
					{
						return true;
					}
				}
				if (font2.method_30() == font.method_30() && font2.Name == font.Name)
				{
					if (font2.Size == font.Size)
					{
						return true;
					}
					class484_0 = new Class484(font.Name, font.Size, font.method_30(), Class1181.smethod_7(font.Name, font.method_30()));
					method_0();
					class484_1 = new Class484(font2.Name, font2.Size, font2.method_30(), class484_0.method_5());
					method_1();
					return false;
				}
				class484_0 = new Class484(font.Name, font.Size, font.method_30(), bool_1: true, null);
				method_0();
				class484_1 = new Class484(font2.Name, font2.Size, font2.method_30(), bool_1: true, null);
				method_1();
				return false;
			}
			return true;
		}
		return class484_0.method_0(class484_1);
	}

	protected override void vmethod_3()
	{
		Font font = cell_0.method_4().method_19().Workbook.DefaultStyle.Font;
		if (class484_1 != null && class484_1.method_4() == font.method_30() && class484_1.FontName == font.Name)
		{
			if (class484_1.FontSize == font.Size)
			{
				class484_0 = class484_1;
				method_0();
				return;
			}
			if (class484_1.method_5() != null)
			{
				class484_0 = new Class484(font.Name, font.Size, font.method_30(), class484_1.method_5());
				method_0();
				return;
			}
		}
		class484_0 = new Class484(font.Name, font.Size, font.method_30(), bool_1: true, null);
		method_0();
	}

	protected override void vmethod_2()
	{
		int num = cell_0.method_35();
		if (num != 15 && num >= 0 && num < cell_0.method_4().method_19().method_58()
			.Count)
		{
			Style defaultStyle = cell_0.method_4().method_19().Workbook.DefaultStyle;
			Font font = defaultStyle.Font;
			Style style = cell_0.method_4().method_19().method_58()[num];
			Font font2 = style.method_40();
			if (font2 == null)
			{
				style = style.ParentStyle;
				if (style == null || style == defaultStyle || style.method_40() == null)
				{
					if (class484_0 == null)
					{
						vmethod_3();
					}
					class484_1 = class484_0;
					method_1();
					return;
				}
				font2 = style.method_40();
			}
			if (font2.method_30() == font.method_30() && font2.Name == font.Name)
			{
				if (font2.Size == font.Size)
				{
					if (class484_0 == null)
					{
						vmethod_3();
					}
					class484_1 = class484_0;
					method_1();
				}
				else
				{
					class484_0 = new Class484(font.Name, font.Size, font.method_30(), Class1181.smethod_7(font.Name, font.method_30()));
					method_0();
					class484_1 = new Class484(font2.Name, font2.Size, font2.method_30(), class484_0.method_5());
					method_1();
				}
			}
			else
			{
				if (class484_0 == null)
				{
					class484_0 = new Class484(font.Name, font.Size, font.method_30(), bool_1: true, null);
					method_0();
				}
				class484_1 = new Class484(font2.Name, font2.Size, font2.method_30(), bool_1: true, null);
				method_1();
			}
		}
		else
		{
			if (class484_0 == null)
			{
				vmethod_3();
			}
			class484_1 = class484_0;
			method_1();
		}
	}
}
