using System.Drawing;

namespace ns316;

internal class Class7159
{
	private int int_0;

	private int[,] int_1;

	private int int_2;

	private Enum975 enum975_0;

	private int[] int_3;

	public Enum975 BlurType
	{
		get
		{
			return enum975_0;
		}
		set
		{
			enum975_0 = value;
		}
	}

	public int Radius
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
			method_0();
		}
	}

	public Class7159(int radius, Enum975 blurType)
	{
		int_2 = radius;
		enum975_0 = blurType;
		method_0();
	}

	public Class7159(int areaRadius)
		: this(areaRadius, Enum975.const_0)
	{
	}

	public Class7159()
		: this(1, Enum975.const_0)
	{
	}

	private void method_0()
	{
		int num = int_2 * 2 + 1;
		int_3 = new int[num];
		int_1 = new int[num, 256];
		for (int i = 1; i <= int_2; i++)
		{
			int num2 = int_2 - i;
			int num3 = int_2 + i;
			int_3[num3] = (int_3[num2] = (num2 + 1) * (num2 + 1));
			int_0 += int_3[num3] + int_3[num2];
			for (int j = 0; j < 256; j++)
			{
				int_1[num3, j] = (int_1[num2, j] = int_3[num3] * j);
			}
		}
		int_3[int_2] = (int_2 + 1) * (int_2 + 1);
		int_0 += int_3[int_2];
		for (int k = 0; k < 256; k++)
		{
			int_1[int_2, k] = int_3[int_2] * k;
		}
	}

	public Bitmap method_1(Image image)
	{
		using Class7161 @class = new Class7161(new Bitmap(image));
		using Class7161 class2 = new Class7161(new Bitmap(image.Width, image.Height));
		int num = @class.ImageWidth * @class.ImageHeight;
		int[] array = new int[num];
		int[] array2 = new int[num];
		int[] array3 = new int[num];
		int[] array4 = new int[num];
		int[] array5 = new int[num];
		int[] array6 = new int[num];
		int[] array7 = new int[num];
		int[] array8 = new int[num];
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			array[i] = @class.ArgbValues[num2];
			array3[i] = @class.ArgbValues[++num2];
			array5[i] = @class.ArgbValues[++num2];
			array7[i] = @class.ArgbValues[++num2];
			num2++;
		}
		int num3 = 0;
		int num4 = 0;
		if (enum975_0 != Enum975.const_2)
		{
			for (int j = 0; j < num; j++)
			{
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				int num9 = j - int_2;
				for (int k = 0; k < int_3.Length; k++)
				{
					num2 = ((num9 >= num3) ? ((num9 <= num3 + @class.ImageWidth - 1) ? num9 : (num3 + @class.ImageWidth - 1)) : num3);
					num8 += int_1[k, array[num2]];
					num7 += int_1[k, array3[num2]];
					num6 += int_1[k, array5[num2]];
					num5 += int_1[k, array7[num2]];
					num9++;
				}
				array2[j] = num8 / int_0;
				array4[j] = num7 / int_0;
				array6[j] = num6 / int_0;
				array8[j] = num5 / int_0;
				if (enum975_0 == Enum975.const_1)
				{
					class2.ArgbValues[num4] = (byte)(num8 / int_0);
					class2.ArgbValues[++num4] = (byte)(num7 / int_0);
					class2.ArgbValues[++num4] = (byte)(num6 / int_0);
					class2.ArgbValues[++num4] = (byte)(num5 / int_0);
					num4++;
				}
				if (j > 0 && j % @class.ImageWidth == 0)
				{
					num3 += @class.ImageWidth;
				}
			}
		}
		if (enum975_0 == Enum975.const_1)
		{
			return class2.Bitmap;
		}
		num4 = 0;
		for (int l = 0; l < @class.ImageHeight; l++)
		{
			int num10 = l - int_2;
			num3 = num10 * @class.ImageWidth;
			for (int m = 0; m < @class.ImageWidth; m++)
			{
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				int num9 = num3 + m;
				int num11 = num10;
				for (int n = 0; n < int_3.Length; n++)
				{
					if (enum975_0 == Enum975.const_2)
					{
						num2 = ((num11 < 0) ? m : ((num11 <= @class.ImageHeight - 1) ? num9 : (num - (@class.ImageWidth - m))));
						num8 += int_1[n, array[num2]];
						num7 += int_1[n, array3[num2]];
						num6 += int_1[n, array5[num2]];
						num5 += int_1[n, array7[num2]];
					}
					else
					{
						num2 = ((num11 < 0) ? m : ((num11 <= @class.ImageHeight - 1) ? num9 : (num - (@class.ImageWidth - m))));
						num8 += int_1[n, array2[num2]];
						num7 += int_1[n, array4[num2]];
						num6 += int_1[n, array6[num2]];
						num5 += int_1[n, array8[num2]];
					}
					num9 += @class.ImageWidth;
					num11++;
				}
				class2.ArgbValues[num4] = (byte)(num8 / int_0);
				class2.ArgbValues[++num4] = (byte)(num7 / int_0);
				class2.ArgbValues[++num4] = (byte)(num6 / int_0);
				class2.ArgbValues[++num4] = (byte)(num5 / int_0);
				num4++;
			}
		}
		return class2.Bitmap;
	}
}
