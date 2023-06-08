using System;
using System.IO;
using x6c95d9cf46ff5f25;

namespace x084786fe6fb0a4e7;

internal class xba5f2e8a212f838a
{
	private const int x47d12178bb897ec7 = 4096;

	private const int x005c992b28781b6a = 76;

	private const int x954be420ee45f14b = 57;

	private const int x45d4aaa030fe55f5 = 4152;

	private const int x20d61b0ce9ce73d6 = 78;

	private readonly StreamWriter x06aeac6c18880fd3;

	private readonly byte[] x6e20f3a0d2544e01;

	private readonly char[] x88f179ffc97330fe;

	private int x098db166a4d0ad50;

	internal xba5f2e8a212f838a(StreamWriter streamWriter)
	{
		x06aeac6c18880fd3 = streamWriter;
		x6e20f3a0d2544e01 = new byte[4152];
		x88f179ffc97330fe = new char[78];
	}

	internal void xd068481bae111913(Stream x337e217cb3ba0627)
	{
		int num = x337e217cb3ba0627.Read(x6e20f3a0d2544e01, 0, 4096);
		if (num == 0)
		{
			return;
		}
		x098db166a4d0ad50 = 0;
		bool flag = true;
		int num2 = 1;
		byte b = x6e20f3a0d2544e01[0];
		while (true)
		{
			for (int i = num2; i < num; i++)
			{
				byte b2 = x6e20f3a0d2544e01[i];
				int num3 = 76 - x098db166a4d0ad50;
				if (b > 32 && b != 61 && b < 127)
				{
					if (num3 <= 1 && b2 != 13)
					{
						x1e5255c34ab3f3a5();
					}
					xf4b743b70a0ab9e0(b);
				}
				else
				{
					switch (b)
					{
					case 13:
						xf4b743b70a0ab9e0(b);
						break;
					case 10:
						xf4b743b70a0ab9e0(b);
						xbb7550bbb62a218c();
						break;
					case 9:
					case 32:
						if (b2 == 13)
						{
							if (num3 < 3)
							{
								x1e5255c34ab3f3a5();
							}
							xe89f1d60eee24906(b);
							break;
						}
						switch (num3)
						{
						case 1:
							x1e5255c34ab3f3a5();
							xf4b743b70a0ab9e0(b);
							break;
						case 2:
							xf4b743b70a0ab9e0(b);
							x1e5255c34ab3f3a5();
							break;
						default:
							xf4b743b70a0ab9e0(b);
							break;
						}
						break;
					default:
						if (num3 < 3 || (num3 == 3 && b2 != 13))
						{
							x1e5255c34ab3f3a5();
						}
						xe89f1d60eee24906(b);
						break;
					}
				}
				b = b2;
			}
			if (!flag)
			{
				break;
			}
			num2 = 0;
			num = x337e217cb3ba0627.Read(x6e20f3a0d2544e01, 0, 4096);
			if (num == 0)
			{
				flag = false;
				num = 1;
				x6e20f3a0d2544e01[0] = 13;
			}
		}
		if (x098db166a4d0ad50 != 0)
		{
			x56b7860ae7d81417();
		}
	}

	private void xf4b743b70a0ab9e0(byte xe7ebe10fa44d8d49)
	{
		x88f179ffc97330fe[x098db166a4d0ad50++] = (char)xe7ebe10fa44d8d49;
	}

	private void xe89f1d60eee24906(byte xe7ebe10fa44d8d49)
	{
		x88f179ffc97330fe[x098db166a4d0ad50++] = '=';
		char[] array = x0d299f323d241756.xd7eddd4ee94f26bb(xe7ebe10fa44d8d49);
		x88f179ffc97330fe[x098db166a4d0ad50++] = array[0];
		x88f179ffc97330fe[x098db166a4d0ad50++] = array[1];
	}

	private void xbb7550bbb62a218c()
	{
		x06aeac6c18880fd3.Write(x88f179ffc97330fe, 0, x098db166a4d0ad50);
		x098db166a4d0ad50 = 0;
	}

	private void x56b7860ae7d81417()
	{
		x06aeac6c18880fd3.WriteLine(x88f179ffc97330fe, 0, x098db166a4d0ad50);
		x098db166a4d0ad50 = 0;
	}

	private void x1e5255c34ab3f3a5()
	{
		x88f179ffc97330fe[x098db166a4d0ad50++] = '=';
		x56b7860ae7d81417();
	}

	internal void xe24c4103102bcb90(Stream x337e217cb3ba0627)
	{
		int num = 0;
		int num2;
		while ((num2 = x337e217cb3ba0627.Read(x6e20f3a0d2544e01, num, 4096)) != 0)
		{
			int num3 = num + num2;
			int num4 = num3 / 57;
			if (num4 != 0)
			{
				int num5 = 0;
				int num6 = num4;
				while (--num6 >= 0)
				{
					string value = Convert.ToBase64String(x6e20f3a0d2544e01, num5, 57);
					x06aeac6c18880fd3.WriteLine(value);
					num5 += 57;
				}
				num = num3 - num5;
				Array.Copy(x6e20f3a0d2544e01, num5, x6e20f3a0d2544e01, 0, num);
			}
			else
			{
				num = num3;
			}
		}
		if (num > 0)
		{
			string value2 = Convert.ToBase64String(x6e20f3a0d2544e01, 0, num);
			x06aeac6c18880fd3.WriteLine(value2);
		}
	}
}
