using System.Drawing;

namespace ns14;

internal class Class485 : Interface2
{
	private Color[] color_0;

	internal Class485()
	{
		color_0 = new Color[56];
		for (int i = 0; i < color_0.Length; i++)
		{
			ref Color reference = ref color_0[i];
			reference = smethod_0(i + 1);
		}
	}

	public Color GetColor(int int_0)
	{
		if (int_0 >= 1 && int_0 <= 56)
		{
			return color_0[int_0 - 1];
		}
		return Color.Empty;
	}

	internal static Color smethod_0(int int_0)
	{
		if (int_0 >= 1 && int_0 <= 56)
		{
			return int_0 switch
			{
				-7 => smethod_1(0), 
				-6 => smethod_1(16777215), 
				-5 => smethod_1(255), 
				-4 => smethod_1(65280), 
				-3 => smethod_1(16711680), 
				-2 => smethod_1(65535), 
				-1 => smethod_1(16711935), 
				0 => smethod_1(16776960), 
				1 => smethod_1(0), 
				2 => smethod_1(16777215), 
				3 => smethod_1(255), 
				4 => smethod_1(65280), 
				5 => smethod_1(16711680), 
				6 => smethod_1(65535), 
				7 => smethod_1(16711935), 
				8 => smethod_1(16776960), 
				9 => smethod_1(128), 
				10 => smethod_1(32768), 
				11 => smethod_1(8388608), 
				12 => smethod_1(32896), 
				13 => smethod_1(8388736), 
				14 => smethod_1(8421376), 
				15 => smethod_1(12632256), 
				16 => smethod_1(8421504), 
				17 => smethod_1(16751001), 
				18 => smethod_1(6697881), 
				19 => smethod_1(13434879), 
				20 => smethod_1(16777164), 
				21 => smethod_1(6684774), 
				22 => smethod_1(8421631), 
				23 => smethod_1(13395456), 
				24 => smethod_1(16764108), 
				25 => smethod_1(8388608), 
				26 => smethod_1(16711935), 
				27 => smethod_1(65535), 
				28 => smethod_1(16776960), 
				29 => smethod_1(8388736), 
				30 => smethod_1(128), 
				31 => smethod_1(8421376), 
				32 => smethod_1(16711680), 
				33 => smethod_1(16763904), 
				34 => smethod_1(16777164), 
				35 => smethod_1(13434828), 
				36 => smethod_1(10092543), 
				37 => smethod_1(16764057), 
				38 => smethod_1(13408767), 
				39 => smethod_1(16751052), 
				40 => smethod_1(10079487), 
				41 => smethod_1(16737843), 
				42 => smethod_1(13421619), 
				43 => smethod_1(52377), 
				44 => smethod_1(52479), 
				45 => smethod_1(39423), 
				46 => smethod_1(26367), 
				47 => smethod_1(10053222), 
				48 => smethod_1(9868950), 
				49 => smethod_1(6697728), 
				50 => smethod_1(6723891), 
				51 => smethod_1(13056), 
				52 => smethod_1(13107), 
				53 => smethod_1(13209), 
				54 => smethod_1(6697881), 
				55 => smethod_1(10040115), 
				56 => smethod_1(3355443), 
				_ => Color.Empty, 
			};
		}
		return Color.Empty;
	}

	private static Color smethod_1(int int_0)
	{
		int red = int_0 & 0xFF;
		int green = (int_0 & 0xFF00) >> 8;
		int blue = (int_0 & 0xFF0000) >> 16;
		return Color.FromArgb(red, green, blue);
	}
}
