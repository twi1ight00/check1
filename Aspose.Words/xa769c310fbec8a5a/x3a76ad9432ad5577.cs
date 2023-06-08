using System.Collections;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;

namespace xa769c310fbec8a5a;

internal class x3a76ad9432ad5577 : xa127f6c5c99ca9d4
{
	private ArrayList x81740c4a091698a1;

	public ArrayList x4552ecfd28b9edc4
	{
		get
		{
			if (x81740c4a091698a1 == null)
			{
				x81740c4a091698a1 = new ArrayList();
			}
			return x81740c4a091698a1;
		}
		set
		{
			x81740c4a091698a1 = value;
		}
	}

	public override void AdjustPen(x31c19fcb724dfaf5 pen)
	{
		float[] array = new float[x4552ecfd28b9edc4.Count * 2];
		for (int i = 0; i < x4552ecfd28b9edc4.Count; i++)
		{
			x4030b55fa9fd15b4 x4030b55fa9fd15b5 = (x4030b55fa9fd15b4)x4552ecfd28b9edc4[i];
			array[i * 2] = (float)x4030b55fa9fd15b5.xd99fe9821a70dc62.x71c5078172d72420;
			array[i * 2 + 1] = (float)x4030b55fa9fd15b5.xf8bdeedf86eea03b.x71c5078172d72420;
		}
		pen.xca08e8eb525b8a1a = DashStyle.Custom;
		pen.x358988d12e56bf69 = array;
	}

	public override xa127f6c5c99ca9d4 Clone()
	{
		x3a76ad9432ad5577 x3a76ad9432ad5578 = new x3a76ad9432ad5577();
		x3a76ad9432ad5578.x4552ecfd28b9edc4 = new ArrayList(x4552ecfd28b9edc4.Count);
		for (int i = 0; i < x4552ecfd28b9edc4.Count; i++)
		{
			x3a76ad9432ad5578.x4552ecfd28b9edc4[i] = ((x4030b55fa9fd15b4)x4552ecfd28b9edc4[i]).x8b61531c8ea35b85();
		}
		return x3a76ad9432ad5578;
	}
}
