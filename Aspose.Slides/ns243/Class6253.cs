using System.Collections.Generic;
using ns224;

namespace ns243;

internal class Class6253 : Class6252
{
	public override Class6235[] vmethod_1(string text, float width, Class5998 foreColor, Class5999 font)
	{
		List<Class6235> list = new List<Class6235>();
		int i = 0;
		int num;
		for (string[] array = text.Split(' '); i < array.Length; i += num)
		{
			string text2 = string.Empty;
			num = 0;
			while (i + num < array.Length && !(method_1(text2 + array[i + num], font).Width >= width))
			{
				text2 = text2 + array[i + num++] + " ";
			}
			list.Add(new Class6235(foreColor, font, text2.Trim(), this));
		}
		return list.ToArray();
	}

	public override string vmethod_2(Class6235 row, float width)
	{
		float num = row.Size.Width / (float)row.Text.Length;
		float num2 = width - num / 2f;
		string text = row.Text;
		int num3 = 0;
		while (method_1(text, row.Font).Width < num2)
		{
			int num4 = text.IndexOf(' ', num3);
			if (num4 == -1 || num4 >= text.Length)
			{
				break;
			}
			text = text.Insert(num4, " ");
			num3 = num4 + 2;
			if (num3 >= text.Length)
			{
				break;
			}
		}
		return text;
	}
}
