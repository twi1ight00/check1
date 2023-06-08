using System.Drawing;
using ns224;
using ns235;
using ns271;

namespace ns243;

internal class Class6235 : Class6225
{
	private readonly Class5999 class5999_0;

	private Class5998 class5998_0;

	private string string_0;

	private readonly Class6252 class6252_0;

	private SizeF sizeF_1 = SizeF.Empty;

	public Class5998 ForeColor
	{
		get
		{
			return class5998_0;
		}
		set
		{
			class5998_0 = value;
		}
	}

	public Class5999 Font => class5999_0;

	public string Text => string_0;

	public override SizeF Size
	{
		get
		{
			if (sizeF_1 == SizeF.Empty)
			{
				sizeF_1 = class6252_0.method_1(string_0, class5999_0);
			}
			return sizeF_1;
		}
	}

	public void method_4(float width)
	{
		string_0 = class6252_0.vmethod_2(this, width);
		sizeF_1 = SizeF.Empty;
	}

	public override Class6204[] vmethod_2()
	{
		return new Class6204[1] { vmethod_4() };
	}

	public Class6235(Class5998 foreColor, Class5999 font, string text, Class6252 composer)
	{
		class5998_0 = foreColor;
		class5999_0 = font;
		string_0 = text;
		class6252_0 = composer;
	}

	public virtual Class6219 vmethod_4()
	{
		return new Class6219(Class6652.Instance.method_1(class5999_0.FamilyName, class5999_0.SizePoints, class5999_0.Style), (class5998_0 == null) ? Class5998.class5998_7 : class5998_0, (class5998_0 == null) ? Class5998.class5998_7 : class5998_0, Location, string_0, Size, 0f);
	}
}
