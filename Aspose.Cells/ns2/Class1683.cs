using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class1683 : CollectionBase
{
	private WorksheetCollection worksheetCollection_0;

	public Style this[int int_0]
	{
		get
		{
			return (Style)base.InnerList[int_0];
		}
		set
		{
			base.InnerList[int_0] = value;
		}
	}

	internal Style this[string string_0]
	{
		get
		{
			int num = 0;
			Style style;
			while (true)
			{
				if (num < base.Count)
				{
					style = (Style)base.InnerList[num];
					if (style.Name == string_0)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return style;
		}
	}

	internal Class1683(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
	}

	internal int method_0(Style style_0)
	{
		base.InnerList.Add(style_0);
		return base.Count - 1;
	}

	internal int method_1(Style style_0, int int_0)
	{
		bool bool_ = style_0.method_10();
		style_0.method_11(bool_0: true);
		int num = int_0 + 1;
		while (true)
		{
			if (num < base.Count)
			{
				Style style = (Style)base.InnerList[num];
				if (style_0 == style || (int_0 == style.method_12() && style_0.method_31(style)))
				{
					break;
				}
				num++;
				continue;
			}
			Style style2 = new Style(worksheetCollection_0);
			style2.Copy(style_0);
			style2.method_13(int_0);
			base.InnerList.Add(style2);
			style_0.method_11(bool_);
			return base.Count - 1;
		}
		return num;
	}

	internal int method_2(Style style_0)
	{
		int num = base.InnerList.Count - 1;
		while (true)
		{
			if (num >= 16)
			{
				if (style_0.method_31((Style)base.InnerList[num]))
				{
					break;
				}
				num--;
				continue;
			}
			return -1;
		}
		return num;
	}

	public int method_3(Style style_0)
	{
		if (style_0.method_12() > 0 && style_0.method_12() != 4095)
		{
			if (style_0.method_5() != worksheetCollection_0)
			{
				Style style = style_0.method_5().method_58()[style_0.method_12()];
				bool flag = false;
				int num = 0;
				for (num = 0; num < base.InnerList.Count; num++)
				{
					Style style2 = (Style)base.InnerList[num];
					if (style2 != null && style2.Name == style.Name)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Style style3 = new Style(worksheetCollection_0);
					style3.Copy(style);
					style3.method_3(style.Name);
					style3.method_11(bool_0: false);
					base.InnerList.Add(style3);
					Style style4 = new Style(worksheetCollection_0);
					style4.Copy(style_0);
					style4.method_11(bool_0: true);
					style4.method_13(base.InnerList.Count - 1);
					base.InnerList.Add(style4);
					return base.InnerList.Count - 1;
				}
				int num2 = num;
				num++;
				while (true)
				{
					if (num < base.InnerList.Count)
					{
						Style style5 = (Style)base.InnerList[num];
						if (style_0 == style5 || (num2 == style5.method_12() && style_0.method_31(style5)))
						{
							break;
						}
						num++;
						continue;
					}
					Style style6 = new Style(worksheetCollection_0);
					style6.Copy(style_0);
					style6.method_13(num2);
					base.InnerList.Add(style6);
					return base.InnerList.Count - 1;
				}
				return num;
			}
			int num3 = style_0.method_12() + 1;
			while (true)
			{
				if (num3 < base.InnerList.Count)
				{
					Style style7 = (Style)base.InnerList[num3];
					if (style_0 == style7 || (style_0.method_12() == style7.method_12() && style_0.method_31(style7)))
					{
						break;
					}
					num3++;
					continue;
				}
				Style style8 = new Style(worksheetCollection_0);
				style8.Copy(style_0);
				base.InnerList.Add(style8);
				return base.InnerList.Count - 1;
			}
			return num3;
		}
		if (style_0.Name != null && !(style_0.Name == ""))
		{
			bool flag2 = false;
			int num4 = 0;
			for (num4 = 0; num4 < base.InnerList.Count; num4++)
			{
				Style style9 = (Style)base.InnerList[num4];
				if (style9 != null && (style9 == style_0 || style9.Name == style_0.Name))
				{
					if (style9 != style_0)
					{
						base.InnerList[num4] = style_0;
					}
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				style_0.method_11(bool_0: false);
				base.InnerList.Add(style_0);
				Style style10 = new Style(worksheetCollection_0);
				style10.Copy(style_0);
				style10.method_11(bool_0: true);
				style10.method_16(0);
				style10.method_13(base.InnerList.Count - 1);
				base.InnerList.Add(style10);
				return base.InnerList.Count - 1;
			}
			int num5 = num4;
			style_0.method_11(bool_0: true);
			byte byte_ = style_0.method_15();
			num4++;
			while (true)
			{
				if (num4 < base.InnerList.Count)
				{
					Style style11 = (Style)base.InnerList[num4];
					if (style11 != null && style11.method_12() == num5 && style11.method_32(style_0, byte_))
					{
						break;
					}
					num4++;
					continue;
				}
				Style style12 = new Style(worksheetCollection_0);
				style12.Copy(style_0);
				style12.method_11(bool_0: true);
				style12.method_16(0);
				style12.method_13(num5);
				base.InnerList.Add(style12);
				style_0.method_11(bool_0: false);
				style_0.method_16(byte_);
				return base.InnerList.Count - 1;
			}
			style_0.method_11(bool_0: false);
			return num4;
		}
		if (style_0.method_31((Style)base.InnerList[15]))
		{
			return 15;
		}
		int num6 = base.InnerList.Count - 1;
		while (true)
		{
			if (num6 >= 16)
			{
				Style style13 = (Style)base.InnerList[num6];
				if (style13.method_12() == 0 && style_0.method_31(style13))
				{
					break;
				}
				num6--;
				continue;
			}
			Style style14 = new Style(worksheetCollection_0);
			style14.Copy(style_0);
			base.InnerList.Add(style14);
			return base.InnerList.Count - 1;
		}
		return num6;
	}

	internal int method_4(Style style_0)
	{
		style_0.method_11(bool_0: false);
		base.InnerList.Add(style_0);
		return base.Count - 1;
	}

	internal int method_5(Style style_0)
	{
		style_0.method_11(bool_0: false);
		int num = 0;
		num = 0;
		Style style;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				style = (Style)base.InnerList[num];
				if (style != null && (style == style_0 || style.Name == style_0.Name))
				{
					break;
				}
				num++;
				continue;
			}
			base.InnerList.Add(style_0);
			return base.Count - 1;
		}
		if (style != style_0)
		{
			base.InnerList[num] = style_0;
		}
		return num;
	}

	internal int method_6(Style style_0)
	{
		style_0.method_11(bool_0: false);
		int num = 0;
		num = 0;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				Style style = (Style)base.InnerList[num];
				if (style != null && (style == style_0 || style.Name == style_0.Name))
				{
					break;
				}
				num++;
				continue;
			}
			base.InnerList.Add(style_0);
			return base.Count - 1;
		}
		return num;
	}

	internal int method_7(Style style_0)
	{
		style_0.method_11(bool_0: false);
		int num = 0;
		num = 0;
		Style style;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				style = (Style)base.InnerList[num];
				if (style != null && (style == style_0 || style.Name == style_0.Name))
				{
					break;
				}
				num++;
				continue;
			}
			base.InnerList.Add(style_0);
			return base.Count - 1;
		}
		if (style != style_0)
		{
			base.InnerList[num] = style_0;
		}
		return num;
	}

	internal void Copy(Class1683 class1683_0)
	{
		for (int i = 0; i < class1683_0.Count; i++)
		{
			Style style = new Style(worksheetCollection_0);
			Style style2 = (Style)class1683_0.InnerList[i];
			style.Copy(style2);
			style.method_3(style2.Name);
			base.InnerList.Add(style);
		}
	}

	internal void method_8()
	{
		for (int i = 0; i < 5; i++)
		{
			Font font = new Font(worksheetCollection_0, null, bool_0: false);
			font.method_22(i);
			if (i == 4)
			{
				i = 5;
			}
			worksheetCollection_0.method_52().Add(font);
		}
	}

	internal void method_9()
	{
		for (int i = 0; i < 5; i++)
		{
			Font font = new Font(worksheetCollection_0, null, bool_0: false);
			font.method_22(i);
			if (i == 4)
			{
				i = 5;
			}
			worksheetCollection_0.method_52().Add(font);
		}
		Style style = new Style(worksheetCollection_0);
		style.method_11(bool_0: false);
		style.method_3("Normal");
		style.Font.method_22(0);
		style.Number = 0;
		style.method_16(252);
		base.InnerList.Add(style);
		for (int j = 0; j < 2; j++)
		{
			style = new Style(worksheetCollection_0);
			style.method_11(bool_0: false);
			style.Font.method_22(1);
			style.Number = 0;
			style.method_16(8);
			base.InnerList.Add(style);
		}
		for (int k = 0; k < 2; k++)
		{
			style = new Style(worksheetCollection_0);
			style.method_11(bool_0: false);
			style.Font.method_22(2);
			style.Number = 0;
			style.method_16(8);
			base.InnerList.Add(style);
		}
		for (int l = 0; l < 16; l++)
		{
			style = new Style(worksheetCollection_0);
			style.Font.method_22(0);
			if (l == 10)
			{
				style.method_11(bool_0: true);
			}
			else
			{
				style.method_11(bool_0: false);
			}
			switch (l)
			{
			default:
				style.method_16(8);
				break;
			case 10:
				style.method_16(0);
				break;
			case 11:
				style.Number = 9;
				style.method_3("Percent");
				style.method_16(4);
				break;
			case 12:
				style.Number = 44;
				style.method_3("Currency");
				style.method_16(4);
				break;
			case 13:
				style.Number = 42;
				style.method_3("Currency [0]");
				style.method_16(4);
				break;
			case 14:
				style.Number = 43;
				style.method_3("Comma");
				style.method_16(4);
				break;
			case 15:
				style.Number = 41;
				style.method_3("Comma [0]");
				style.method_16(4);
				break;
			}
			base.InnerList.Add(style);
		}
		for (int m = 0; m < base.InnerList.Count; m++)
		{
			style = (Style)base.InnerList[m];
			if (style.method_2() != null && style.method_2() != "")
			{
				worksheetCollection_0.Styles.Add(style);
			}
		}
	}
}
