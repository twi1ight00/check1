using System.Drawing;
using System.Globalization;
using Aspose.Cells;

namespace ns17;

internal class Class1082 : Class1080
{
	public Class1082(Class1087 class1087_1)
	{
		class1087_0 = class1087_1;
	}

	public override Enum170 vmethod_0(ref string string_0)
	{
		int i = 1;
		switch (string_0[1])
		{
		case 'B':
			class1087_0.font_0.IsBold = true;
			break;
		case '"':
		{
			i++;
			int num = i;
			for (; i < string_0.Length && string_0[i] != '"'; i++)
			{
			}
			if (i - num >= 0)
			{
				string string_ = string_0.Substring(num, i - num);
				class1087_0.method_0(string_);
			}
			break;
		}
		case 'S':
			class1087_0.font_0.IsStrikeout = true;
			break;
		case 'U':
			class1087_0.font_0.Underline = FontUnderlineType.Single;
			break;
		case 'X':
			class1087_0.font_0.IsSuperscript = true;
			break;
		case 'Y':
			class1087_0.font_0.IsSubscript = true;
			break;
		case 'I':
			class1087_0.font_0.IsItalic = true;
			break;
		default:
		{
			int num = i;
			for (i++; i < string_0.Length && char.IsDigit(string_0[i]); i++)
			{
			}
			class1087_0.font_0.Size = int.Parse(string_0.Substring(num, i - num));
			i--;
			break;
		}
		case 'K':
			if (i + 6 >= string_0.Length)
			{
				throw new CellsException(ExceptionType.InvalidData, "Invalid font color of the page header/footer");
			}
			try
			{
				int red = int.Parse(string_0.Substring(i + 1, 2), NumberStyles.HexNumber);
				int green = int.Parse(string_0.Substring(i + 3, 2), NumberStyles.HexNumber);
				int blue = int.Parse(string_0.Substring(i + 5, 2), NumberStyles.HexNumber);
				class1087_0.font_0.Color = Color.FromArgb(red, green, blue);
			}
			catch
			{
				class1087_0.font_0.Color = Color.FromArgb(0, 0, 0);
			}
			i += 6;
			break;
		case 'E':
			class1087_0.font_0.Underline = FontUnderlineType.Double;
			break;
		}
		string_0 = string_0.Substring(i + 1);
		class1087_0.class1080_6 = class1087_0.class1080_0;
		return Enum170.const_0;
	}
}
