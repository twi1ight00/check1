using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using ns166;
using ns224;
using ns233;
using ns235;

namespace ns161;

internal class Class4858
{
	private class Class6180 : Class6176
	{
		private Class5999 class5999_0;

		private Class5998 class5998_0 = Class5998.class5998_140;

		private RectangleF rectangleF_0 = RectangleF.Empty;

		private StringBuilder stringBuilder_0 = new StringBuilder();

		private RectangleF rectangleF_1 = RectangleF.Empty;

		private bool bool_0;

		private bool bool_1;

		private Class6270 class6270_0;

		private Class4858 class4858_0;

		public Class6180(Class4858 owner)
		{
			class4858_0 = owner;
		}

		public override void vmethod_11(Class6220 image)
		{
			method_0();
			Class4777 @class = new Class4777(image.Size, new MemoryStream(image.ImageBytes));
			int i = 0;
			bool flag = false;
			for (; i < class4858_0.arrayList_0.Count; i++)
			{
				Class4777 class2 = (Class4777)class4858_0.arrayList_0[i];
				if (class2.Equals(@class))
				{
					flag = true;
					break;
				}
			}
			string arg = "png";
			if (image.ImageType == Enum788.const_4)
			{
				arg = "jpg";
			}
			if (!flag)
			{
				class4858_0.arrayList_0.Add(@class);
			}
			string name = $"pic{++i}.{arg}";
			class4858_0.interface146_0.imethod_7(image, name);
		}

		public override void vmethod_0(Class6216 page)
		{
			class4858_0.interface146_0.imethod_0(page.Width, page.Height);
		}

		public override void vmethod_1(Class6216 page)
		{
			if (bool_1)
			{
				method_0();
			}
			if (bool_0)
			{
				class4858_0.interface146_0.imethod_3();
			}
			class4858_0.interface146_0.imethod_1();
		}

		public override void vmethod_4(Class6219 glyphs)
		{
			bool flag = false;
			if (!class4858_0.hashtable_0.Contains(glyphs.Font.FamilyName))
			{
				class4858_0.hashtable_0.Add(glyphs.Font.FamilyName, glyphs.Font);
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			string text = glyphs.Text;
			foreach (char c in text)
			{
				if (c != ' ' && c != '\r' && c != '\n')
				{
					num++;
				}
				stringBuilder.Append(c);
			}
			if (num == 0)
			{
				return;
			}
			float num2 = glyphs.Font.method_1(' ');
			if (num2 == 0f)
			{
				num2 = glyphs.Font.method_1('A') * 0.5f;
			}
			if (class5999_0 == null || class5999_0.FamilyName != glyphs.Font.FamilyName || class5999_0.SizePoints != glyphs.Font.SizePoints || class5999_0.Style != glyphs.Font.Style)
			{
				flag = true;
				class5999_0 = glyphs.Font;
			}
			bool flag2 = false;
			RectangleF rectangleF = new RectangleF(glyphs.Origin, glyphs.Size);
			RectangleF rectangleF2 = RectangleF.Intersect(rectangleF, rectangleF_0);
			if (!rectangleF2.IsEmpty && rectangleF2.Width * rectangleF2.Height > 0.5f * rectangleF.Width * rectangleF.Height)
			{
				string text2 = stringBuilder.ToString();
				string text3 = stringBuilder_0.ToString();
				int num3 = 0;
				int num4 = 0;
				while (num3 < text2.Length && num4 < stringBuilder_0.Length)
				{
					if (text2[num3] == ' ')
					{
						num3++;
						continue;
					}
					if (text3[num4] == ' ')
					{
						num4++;
						continue;
					}
					if (text2[num3] != text3[num4])
					{
						break;
					}
					num3++;
					num4++;
				}
				flag2 = num3 == text2.Length && num4 == text3.Length;
			}
			double num5 = rectangleF.Left - rectangleF_0.Right;
			bool flag3 = false;
			if (Class4778.smethod_12(rectangleF_0, rectangleF) > 0.5f && num5 > (double)(0f - num2) && num5 < 0.75 * (double)num2 && !flag)
			{
				flag3 = true;
			}
			flag3 &= glyphs.Hyperlink == null && class6270_0 == null;
			flag2 &= glyphs.Hyperlink == null && class6270_0 == null;
			if (flag3)
			{
				rectangleF = RectangleF.Union(rectangleF_0, rectangleF);
			}
			if (!flag3)
			{
				if (flag2)
				{
					bool_1 = false;
				}
				else if (bool_1)
				{
					method_0();
				}
			}
			class5998_0 = glyphs.Color;
			if (flag)
			{
				if (bool_0)
				{
					class4858_0.interface146_0.imethod_3();
				}
				Class4776 @class = new Class4776(class5999_0.TrueTypeFont.Data.vmethod_0(), class5999_0.FamilyName);
				string empty = string.Empty;
				bool flag4 = false;
				int j;
				for (j = 0; j < class4858_0.arrayList_1.Count; j++)
				{
					Class4776 class2 = (Class4776)class4858_0.arrayList_1[j];
					if (class2.Equals(@class))
					{
						flag4 = true;
						break;
					}
				}
				empty = $"font{++j}.ttf";
				if (!flag4)
				{
					class4858_0.arrayList_1.Add(@class);
				}
				class4858_0.interface146_0.imethod_2(class5999_0.TrueTypeFont, class5999_0.SizePoints, class5999_0.Style, empty);
				bool_0 = true;
			}
			if (!bool_1)
			{
				stringBuilder_0.Remove(0, stringBuilder_0.Length);
				rectangleF_1 = RectangleF.Empty;
			}
			stringBuilder_0.Append(stringBuilder);
			bool_1 = true;
			rectangleF_1 = (rectangleF_0 = rectangleF);
			class6270_0 = glyphs.Hyperlink;
		}

		private void method_0()
		{
			class4858_0.interface146_0.imethod_6(rectangleF_1, class5998_0, stringBuilder_0.ToString());
			bool_1 = false;
			if (class6270_0 != null)
			{
				class4858_0.interface146_0.imethod_4(class6270_0.Target);
				class4858_0.interface146_0.imethod_6(rectangleF_1, class5998_0, stringBuilder_0.ToString());
				class4858_0.interface146_0.imethod_5();
				class6270_0 = null;
			}
		}
	}

	private Hashtable hashtable_0 = new Hashtable();

	private ArrayList arrayList_0 = new ArrayList();

	private ArrayList arrayList_1 = new ArrayList();

	private Interface146 interface146_0;

	public Class4858(Interface146 fixedBuilder)
	{
		interface146_0 = fixedBuilder;
	}

	public void method_0(ArrayList apsPages)
	{
		Class4859 @class = new Class4859();
		@class.Normalize = true;
		@class.UseEmbeddedTrueTypeFonts = true;
		int num = 0;
		foreach (Class6216 apsPage in apsPages)
		{
			Class6180 visitor = new Class6180(this);
			if (@class.Normalize)
			{
				Class6216 class3 = Class4753.smethod_0(apsPage, ++num, @class, 2, transformImages: true);
				class3.vmethod_0(visitor);
			}
			else
			{
				apsPage.vmethod_0(visitor);
			}
		}
	}
}
