using System.Reflection;

namespace x59d6a4fc5007b7a4;

[DefaultMember("Item")]
internal class xa1a7cce7c5e4a4dc
{
	private readonly string[] xedc9b5bc46353c3d;

	private int xbf03dd83dc9d3892;

	private int x8e59c92eae4b951c;

	internal int x1be93eed8950d961 => x8e59c92eae4b951c;

	internal int xcace819d50a03332 => xedc9b5bc46353c3d.Length;

	internal string[] xb2917ec9757c4b01
	{
		get
		{
			string[] array = new string[xedc9b5bc46353c3d.Length];
			for (int i = 0; i < xedc9b5bc46353c3d.Length; i++)
			{
				array[i] = ((xedc9b5bc46353c3d[i] == "\0") ? "" : xedc9b5bc46353c3d[i]);
			}
			return array;
		}
	}

	internal char xe6d4b1b411ed94b5 => xb23fcae9b34ef48c(xc0c4c459c6ccbd00);

	internal xa1a7cce7c5e4a4dc(string[] runs)
	{
		xedc9b5bc46353c3d = new string[runs.Length];
		for (int i = 0; i < runs.Length; i++)
		{
			xedc9b5bc46353c3d[i] = ((runs[i] == "") ? "\0" : runs[i]);
		}
		xf0d7885e12a62f8b();
	}

	internal int x7c9168d2804254a7(int x6c428075bb2fdc3b)
	{
		xb23fcae9b34ef48c(x6c428075bb2fdc3b);
		return xbf03dd83dc9d3892;
	}

	internal void xcd5f7940e9d851bd(string xd9942531f416cda8, int[] xc4313d7c5696eaac)
	{
		int num = 0;
		int i;
		string text;
		for (i = 0; i < xedc9b5bc46353c3d.Length - 1; i++)
		{
			if (xc4313d7c5696eaac[i] == 0)
			{
				if (xedc9b5bc46353c3d.Length == 2)
				{
					xedc9b5bc46353c3d[1] = "\0";
					break;
				}
				xedc9b5bc46353c3d[i] = "\0";
			}
			else
			{
				int length = xc4313d7c5696eaac[i] - num;
				text = xd9942531f416cda8.Substring(num, length);
				xedc9b5bc46353c3d[i] = text;
				num = xc4313d7c5696eaac[i];
			}
		}
		text = xd9942531f416cda8.Substring(num);
		xedc9b5bc46353c3d[i] = text;
		xf0d7885e12a62f8b();
	}

	private char xb23fcae9b34ef48c(int xc0c4c459c6ccbd00)
	{
		int num = 0;
		int num2 = 0;
		int index = 0;
		string text = xedc9b5bc46353c3d[0];
		xbf03dd83dc9d3892 = 0;
		for (int i = 0; i < xedc9b5bc46353c3d.Length; i++)
		{
			num += xedc9b5bc46353c3d[i].Length;
			if (num > xc0c4c459c6ccbd00)
			{
				text = xedc9b5bc46353c3d[i];
				index = xc0c4c459c6ccbd00 - num2;
				break;
			}
			num2 = num;
			xbf03dd83dc9d3892++;
		}
		return text[index];
	}

	private void xf0d7885e12a62f8b()
	{
		x8e59c92eae4b951c = 0;
		for (int i = 0; i < xcace819d50a03332; i++)
		{
			x8e59c92eae4b951c += xedc9b5bc46353c3d[i].Length;
		}
	}
}
