using System.Text;

namespace ns4;

internal class Class70 : Interface1
{
	public static readonly Class70 class70_0 = new Class70();

	private static readonly char[] char_0 = new char[10] { '०', '१', '२', '३', '४', '५', '६', '७', '८', '९' };

	public string imethod_0(string format, int value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		while (value > 0)
		{
			stringBuilder.Append(char_0[value % 10]);
			value /= 10;
		}
		if (stringBuilder.Length > 0)
		{
			int num = stringBuilder.Length / 2;
			for (int i = 0; i < num; i++)
			{
				char value2 = stringBuilder[i];
				stringBuilder[i] = stringBuilder[stringBuilder.Length - 1 - i];
				stringBuilder[stringBuilder.Length - 1 - i] = value2;
			}
		}
		int num2 = 1;
		if (format != null)
		{
			int j;
			for (j = 0; j < format.Length && format[j] >= '0' && format[j] <= '9'; j++)
			{
			}
			if (j > 0)
			{
				num2 = int.Parse((j == format.Length) ? format : format.Substring(0, j));
			}
		}
		if (num2 > stringBuilder.Length)
		{
			stringBuilder.Insert(0, new string(char_0[0], num2 - stringBuilder.Length));
		}
		return stringBuilder.ToString();
	}
}
