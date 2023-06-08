using System;
using System.Collections;
using System.Drawing;
using System.IO;
using Aspose.Cells;
using ns16;
using ns18;

namespace ns17;

internal class Class1092
{
	protected ArrayList arrayList_0;

	protected Class454 class454_0;

	protected Class1623 class1623_0;

	protected SizeF sizeF_0 = default(SizeF);

	protected RectangleF rectangleF_0 = default(RectangleF);

	public double[] double_0 = new double[2] { 1.0, 1.0 };

	public TextAlignmentType textAlignmentType_0;

	public TextAlignmentType textAlignmentType_1;

	private Workbook workbook_0;

	public Class1092(Class454 class454_1, Class1623 class1623_1, PageSetup pageSetup_0, TextAlignmentType textAlignmentType_2, TextAlignmentType textAlignmentType_3, Workbook workbook_1)
	{
		arrayList_0 = new ArrayList();
		method_0();
		class454_0 = class454_1;
		class1623_0 = class1623_1;
		textAlignmentType_0 = textAlignmentType_2;
		textAlignmentType_1 = textAlignmentType_3;
		workbook_0 = workbook_1;
		float num = ((!pageSetup_0.IsHFAlignMargins) ? 54f : ((float)pageSetup_0.LeftMarginInch * 72f));
		float num2 = Math.Max((float)pageSetup_0.HeaderMarginInch * 72f, 1f);
		float num3 = Math.Max((float)pageSetup_0.FooterMarginInch * 72f, 1f);
		float num4 = ((!pageSetup_0.IsHFAlignMargins) ? 54f : ((float)pageSetup_0.RightMarginInch * 72f));
		PointF location = new PointF(num, num2);
		double num5 = 0.0;
		double num6 = 0.0;
		num5 = 0.0;
		num6 = 0.0;
		Class1625.smethod_10(pageSetup_0, out num5, out num6);
		SizeF size = new SizeF((float)(num5 * 72.0 - (double)num - (double)num4), (float)(num6 * 72.0 - (double)num2 - (double)num3));
		rectangleF_0 = new RectangleF(location, size);
		if (pageSetup_0.IsHFScaleWithDoc)
		{
			double_0 = class1623_0.double_0;
		}
	}

	public void method_0()
	{
		arrayList_0.Add(new Class1091());
	}

	private SizeF method_1()
	{
		SizeF empty = SizeF.Empty;
		foreach (Class1091 item in arrayList_0)
		{
			if (empty.Width < item.float_1)
			{
				empty.Width = item.float_1;
			}
			empty.Height += item.float_0;
		}
		return empty;
	}

	public void method_2(Class1544 class1544_0)
	{
		Class1091 @class = (Class1091)arrayList_0[arrayList_0.Count - 1];
		if (Class1078.smethod_1(class1544_0.string_0))
		{
			Class534 class2 = new Class534();
			ArrayList arrayList = class2.method_0(class1544_0);
			foreach (Class1544 item in arrayList)
			{
				item.font_0.Name = "Times New Roman";
				@class.method_0(new Class1090(item));
			}
			sizeF_0 = method_1();
		}
		else
		{
			@class.method_0(new Class1090(class1544_0));
			sizeF_0 = method_1();
		}
	}

	public void method_3(MemoryStream memoryStream_0, SizeF sizeF_1)
	{
		Class1091 @class = (Class1091)arrayList_0[arrayList_0.Count - 1];
		@class.method_0(new Class1089(memoryStream_0, sizeF_1));
		sizeF_0 = method_1();
	}

	public void method_4()
	{
		float x = 0f;
		float num = 0f;
		switch (textAlignmentType_1)
		{
		case TextAlignmentType.Top:
			num = rectangleF_0.Top + 1f;
			break;
		case TextAlignmentType.Bottom:
			num = rectangleF_0.Bottom - sizeF_0.Height;
			break;
		}
		foreach (Class1091 item in arrayList_0)
		{
			switch (textAlignmentType_0)
			{
			case TextAlignmentType.Left:
				x = rectangleF_0.Left + 2f;
				break;
			case TextAlignmentType.Right:
				x = rectangleF_0.Right - item.float_1 - 2f;
				break;
			case TextAlignmentType.Center:
				x = rectangleF_0.Left + (rectangleF_0.Width / 2f - item.float_1 / 2f);
				break;
			}
			item.method_1(ref class454_0, new PointF(x, num));
			num += item.float_0;
		}
	}
}
