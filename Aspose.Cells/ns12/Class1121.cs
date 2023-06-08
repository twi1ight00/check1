using System.Text;
using Aspose.Cells;

namespace ns12;

internal class Class1121
{
	internal static object Calculate(object object_0)
	{
		if (object_0 == null)
		{
			return "";
		}
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		string text = object_0.ToString();
		if (text.Length == 0)
		{
			return text;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < text.Length; i++)
		{
			int num = text[i];
			if (num >= 32)
			{
				switch (num)
				{
				case 127:
				case 129:
				case 141:
				case 143:
				case 144:
				case 157:
					continue;
				}
				stringBuilder.Append(text[i]);
			}
		}
		return stringBuilder.ToString();
	}
}
