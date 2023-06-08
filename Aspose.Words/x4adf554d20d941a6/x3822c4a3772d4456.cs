using System.Collections;
using System.Drawing;

namespace x4adf554d20d941a6;

internal class x3822c4a3772d4456
{
	private readonly Rectangle[] x4642a7afcf443698;

	private readonly int x8918dc7c534575e5;

	private readonly int x1b8a4fc8efbd343f;

	internal Rectangle[] xd6abb2ab950b4d22 => x4642a7afcf443698;

	internal int xb0f146032f47c24e => x8918dc7c534575e5;

	internal int x77873e6fb945e6f8 => x1b8a4fc8efbd343f;

	internal x3822c4a3772d4456(Rectangle band, int height)
	{
		x4642a7afcf443698 = new Rectangle[1] { band };
		x8918dc7c534575e5 = height;
		x1b8a4fc8efbd343f = 1073741823;
	}

	internal x3822c4a3772d4456(ArrayList band, int height, int minIntersectingFloaterBottom)
		: this((Rectangle[])band.ToArray(typeof(Rectangle)), height, minIntersectingFloaterBottom)
	{
	}

	private x3822c4a3772d4456(Rectangle[] band, int height, int minIntersectingFloaterBottom)
	{
		x4642a7afcf443698 = band;
		x8918dc7c534575e5 = height;
		x1b8a4fc8efbd343f = minIntersectingFloaterBottom;
	}

	internal x3822c4a3772d4456 x9e19f5bd0a6dd5b7(Point xf7845a6fecd5afc3)
	{
		Rectangle[] array = new Rectangle[x4642a7afcf443698.Length];
		for (int i = 0; i < x4642a7afcf443698.Length; i++)
		{
			Rectangle rectangle = x4642a7afcf443698[i];
			ref Rectangle reference = ref array[i];
			reference = new Rectangle(rectangle.X - xf7845a6fecd5afc3.X, rectangle.Y - xf7845a6fecd5afc3.Y, rectangle.Width, rectangle.Height);
		}
		int minIntersectingFloaterBottom = ((x1b8a4fc8efbd343f != 1073741823) ? (x1b8a4fc8efbd343f - xf7845a6fecd5afc3.Y) : x1b8a4fc8efbd343f);
		return new x3822c4a3772d4456(array, xb0f146032f47c24e, minIntersectingFloaterBottom);
	}
}
