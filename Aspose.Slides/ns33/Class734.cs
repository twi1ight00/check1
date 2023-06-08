namespace ns33;

internal class Class734
{
	private class Class735
	{
		private int int_0;

		private int int_1;

		private string[] string_0;

		public int Start => int_0;

		public int End => int_1;

		public string[] FontFamilies => string_0;

		public Class735(int start, int end, string[] fontFamilies)
		{
			int_0 = start;
			int_1 = end;
			string_0 = fontFamilies;
		}
	}

	private static Class735[] class735_0 = new Class735[29]
	{
		new Class735(1920, 1983, new string[3] { "MV Boli", "Thaana Unicode Akeh", "ClearlyU" }),
		new Class735(1984, 2047, new string[3] { "Ebrima", "DejaVu Sans", "Conakry" }),
		new Class735(2048, 2111, new string[1] { "Hebrew Samaritan" }),
		new Class735(3456, 3583, new string[5] { "Iskoola Pota", "Free Sans", "Dinamina", "KaputaUnicode", "Potha" }),
		new Class735(4608, 5023, new string[2] { "Nyala", "ClearlyU" }),
		new Class735(5024, 5119, new string[1] { "Plantagenet Cherokee" }),
		new Class735(5120, 5759, new string[3] { "Euphemia", "Euphemia UCAS", "ClearlyU" }),
		new Class735(6016, 6143, new string[4] { "DaunPenh", "Khmer UI", "Meiryo", "MoolBoran" }),
		new Class735(6144, 6319, new string[1] { "Mongolian Baiti" }),
		new Class735(6480, 6527, new string[1] { "Microsoft Tai Le" }),
		new Class735(6528, 6623, new string[2] { "Microsoft New Tai Lue", "Dai Banna SIL" }),
		new Class735(6624, 6655, new string[4] { "DaunPenh", "Khmer UI", "Meiryo", "MoolBoran" }),
		new Class735(11264, 11359, new string[1] { "Segoe UI Symbol" }),
		new Class735(11568, 11647, new string[1] { "Ebrima" }),
		new Class735(11648, 11743, new string[1] { "Nyala" }),
		new Class735(11904, 12031, new string[2] { "Meiryo", "Meiryo UI" }),
		new Class735(12032, 12255, new string[2] { "Meiryo", "Meiryo UI" }),
		new Class735(12272, 12287, new string[5] { "SimSun", "SimHei", "NSimSun", "KaiTi", "FangSong" }),
		new Class735(12704, 12735, new string[2] { "Microsoft JhengHei", "Microsoft YaHei" }),
		new Class735(12736, 12783, new string[3] { "MingLiU", "MingLiU_HKSCS", "PMingLiU" }),
		new Class735(12784, 12799, new string[3] { "Meiryo", "Microsoft JhengHei", "Microsoft YaHei" }),
		new Class735(13312, 19903, new string[5] { "MingLiU", "Microsoft JhengHei", "Microsoft YaHei", "KaiTi", "FangSong" }),
		new Class735(19904, 19967, new string[2] { "Segoe UI Symbol", "DejaVu Sans" }),
		new Class735(40960, 42191, new string[1] { "Microsoft Yi Baiti" }),
		new Class735(44032, 55215, new string[4] { "Batang", "Dotum", "Gulim", "Gungsuh" }),
		new Class735(42240, 42559, new string[1] { "Ebrima" }),
		new Class735(43072, 43135, new string[1] { "Microsoft PhagsPa" }),
		new Class735(66688, 66735, new string[1] { "Ebrima" }),
		new Class735(119808, 120831, new string[1] { "Cambria Math" })
	};

	public static string[] smethod_0(char symbol)
	{
		if (symbol < class735_0[0].Start)
		{
			return null;
		}
		Class735[] array = class735_0;
		int num = 0;
		Class735 @class;
		while (true)
		{
			if (num < array.Length)
			{
				@class = array[num];
				if (symbol >= @class.Start && symbol <= @class.End)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class.FontFamilies;
	}

	private Class734()
	{
	}
}
