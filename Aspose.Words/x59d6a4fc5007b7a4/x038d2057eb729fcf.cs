using System.Drawing;
using Aspose.Words;
using Aspose.Words.Fields;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x4adf554d20d941a6;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class x038d2057eb729fcf : xb850ecb8335a2e09
{
	private x5b0ea7c4a9d65903 x8d8226994d810517;

	protected object x831916008bfc3ed7;

	private Aspose.Words.Font x83cd810ab70afec3;

	private xe39d06eee35dd23d xcfb178b83a29d588;

	private string xed4a7b1500064e12;

	private string xdf4364b11fab6d16;

	internal virtual string xf9ad6fb78355fe13
	{
		get
		{
			if (xed4a7b1500064e12 == null)
			{
				xed4a7b1500064e12 = xe4b49d17e98f45f8(x56410a8dd70087c5.xf9ad6fb78355fe13);
			}
			return xed4a7b1500064e12;
		}
		set
		{
			xed4a7b1500064e12 = xe4b49d17e98f45f8(value);
		}
	}

	internal string x33e0a63c396e274b
	{
		get
		{
			if (xdf4364b11fab6d16 == null)
			{
				if (x56410a8dd70087c5.x5566e2d2acbd1fbe == 25604)
				{
					xa67197c42bddc7dc xa67197c42bddc7dc = (xa67197c42bddc7dc)x56410a8dd70087c5;
					if (x0d299f323d241756.x5959bccb67bbf051(xa67197c42bddc7dc.xc9bcfb2d9630b0c7))
					{
						xdf4364b11fab6d16 = xa67197c42bddc7dc.xc9bcfb2d9630b0c7;
					}
				}
				if (xdf4364b11fab6d16 == null)
				{
					x5c28fdcd27dee7d9 x5c28fdcd27dee7d = x56410a8dd70087c5.x73ce1c9078892ff3(false, FieldType.FieldHyperlink, FieldType.FieldRef, FieldType.FieldNoteRef, FieldType.FieldPageRef);
					if (x5c28fdcd27dee7d != null)
					{
						xdf4364b11fab6d16 = x5c28fdcd27dee7d.xc9bcfb2d9630b0c7;
					}
				}
			}
			return xdf4364b11fab6d16;
		}
	}

	internal xe39d06eee35dd23d xd49212c2bf5d3d12
	{
		get
		{
			if (xcfb178b83a29d588 == null)
			{
				xcfb178b83a29d588 = x56410a8dd70087c5.x705ed5f9769744e5.xc2d4efc42998d87b;
			}
			return xcfb178b83a29d588;
		}
	}

	internal int x5566e2d2acbd1fbe => x56410a8dd70087c5.x5566e2d2acbd1fbe;

	internal float x887b872a95caaab5 => x4574ea26106f0edb.xc96d70553223ee04(x56410a8dd70087c5.x887b872a95caaab5);

	internal float xbcd477821fdbd81b => x4574ea26106f0edb.xc96d70553223ee04(x56410a8dd70087c5.xbcd477821fdbd81b);

	internal RectangleF x8d3e220b8546945e => x4574ea26106f0edb.xc96d70553223ee04(x56410a8dd70087c5.xc5ddd087b660ca35);

	internal RectangleF x007986b943c7e3cf => new RectangleF(x72d92bd1aff02e37, xce1f19b805aa290d, xdc1bf80853046136, xa2a9e5b20ef4d76a);

	private float xce1f19b805aa290d => x4574ea26106f0edb.xc96d70553223ee04(x56410a8dd70087c5.xc821290d7ecc08bf);

	private float xa2a9e5b20ef4d76a => x4574ea26106f0edb.xc96d70553223ee04(x56410a8dd70087c5.xb0f146032f47c24e);

	internal Aspose.Words.Font xc2d4efc42998d87b
	{
		get
		{
			if (x83cd810ab70afec3 == null)
			{
				x396b77a306f83da6 x705ed5f9769744e = x56410a8dd70087c5.x705ed5f9769744e5;
				x83cd810ab70afec3 = new Aspose.Words.Font();
				x83cd810ab70afec3.Name = x705ed5f9769744e.x759aa16c2016a289;
				x83cd810ab70afec3.Size = x4574ea26106f0edb.xc96d70553223ee04(x705ed5f9769744e.x437e3b626c0fdd43);
				x83cd810ab70afec3.x63b1a7c31a962459 = x705ed5f9769744e.x9b41425268471380;
				x83cd810ab70afec3.Bold = x705ed5f9769744e.xa143daf3bef8b339;
				x83cd810ab70afec3.Italic = x705ed5f9769744e.xb65ca9637cc40782;
				x83cd810ab70afec3.Hidden = x705ed5f9769744e.x24385217e0d88ab8;
				x83cd810ab70afec3.Underline = x705ed5f9769744e.x2588d8c20c42e232;
				x83cd810ab70afec3.x99907b37201c7b19 = x705ed5f9769744e.x36197c67d114da57;
				x83cd810ab70afec3.Position = x4574ea26106f0edb.xc96d70553223ee04(x705ed5f9769744e.xbe1e23e7d5b43370);
				x83cd810ab70afec3.AllCaps = x705ed5f9769744e.xa6417f0b87702333 == xa79d032ee44aba11.xa6417f0b87702333;
				x83cd810ab70afec3.SmallCaps = x705ed5f9769744e.xa6417f0b87702333 == xa79d032ee44aba11.x3225daf421fc5451;
				x83cd810ab70afec3.Superscript = x705ed5f9769744e.x838b2dfd1391264c == x7af53bbecc5ccdd5.xab66d68facbadf18;
				x83cd810ab70afec3.Subscript = x705ed5f9769744e.x838b2dfd1391264c == x7af53bbecc5ccdd5.x1b1f4712a1a0c38c;
				x83cd810ab70afec3.StrikeThrough = x705ed5f9769744e.xfedaa23df3912116 == x0ae5fe02c6cbfde7.x63374d6ffed4adeb;
				x83cd810ab70afec3.DoubleStrikeThrough = x705ed5f9769744e.xfedaa23df3912116 == x0ae5fe02c6cbfde7.x94c083f2813272f4;
				x83cd810ab70afec3.Emboss = x705ed5f9769744e.x2fb115b47db0d216 == xc92cdbffb9d00ef3.x8a8280480a77bc88;
				x83cd810ab70afec3.Engrave = x705ed5f9769744e.x2fb115b47db0d216 == xc92cdbffb9d00ef3.x3db6b9a9a976176a;
				x83cd810ab70afec3.Outline = x705ed5f9769744e.x2fb115b47db0d216 == xc92cdbffb9d00ef3.x93e68a44438355fd || x705ed5f9769744e.x2fb115b47db0d216 == xc92cdbffb9d00ef3.x80311f214b796fbe;
				x83cd810ab70afec3.Shadow = x705ed5f9769744e.x2fb115b47db0d216 == xc92cdbffb9d00ef3.xf398ffaf32ffe055 || x705ed5f9769744e.x2fb115b47db0d216 == xc92cdbffb9d00ef3.x80311f214b796fbe;
				x83cd810ab70afec3.xff8cd6f1d57322e6 = x705ed5f9769744e.xabb599f76795ecaf;
				x83cd810ab70afec3.Scaling = x705ed5f9769744e.x5152a5707921c783;
				x83cd810ab70afec3.xbcb6fa15d8981abb = x4574ea26106f0edb.x5df565b312141b2b(x705ed5f9769744e.x9ba60a33bc3988dc);
				if (!x56410a8dd70087c5.x2617ae682f706ca0)
				{
					x83cd810ab70afec3.Shading.xc290f60df004e384 = x705ed5f9769744e.x554aca059bdf6d48.x8fdbd80e8da6b0e6;
					x83cd810ab70afec3.Shading.x0e18178ac4b2272f = x705ed5f9769744e.x554aca059bdf6d48.x83729c7ebf48ae24;
					x83cd810ab70afec3.Shading.Texture = x705ed5f9769744e.x554aca059bdf6d48.x7b6a6d281546db99;
					x83cd810ab70afec3.Border.LineWidth = x705ed5f9769744e.x51d60f077c5fc6e0.xffa1fc725bf36690;
					x83cd810ab70afec3.Border.LineStyle = x705ed5f9769744e.x51d60f077c5fc6e0.x3d0571719b5893b4;
					x83cd810ab70afec3.Border.x63b1a7c31a962459 = x705ed5f9769744e.x51d60f077c5fc6e0.x9b41425268471380;
					x83cd810ab70afec3.Border.DistanceFromText = x705ed5f9769744e.x51d60f077c5fc6e0.x58316dde3396e982;
					x83cd810ab70afec3.Border.Shadow = x705ed5f9769744e.x51d60f077c5fc6e0.x0214605434693fc1;
					x83cd810ab70afec3.Border.x227665e444fb500a = x705ed5f9769744e.x51d60f077c5fc6e0.x75c2a4a522094a98;
				}
			}
			return x83cd810ab70afec3;
		}
	}

	internal bool xf456709e18aac75a => x56410a8dd70087c5.xf456709e18aac75a;

	internal bool xb987620b63e60ab6 => x56410a8dd70087c5.xb987620b63e60ab6;

	internal virtual bool xd4933b722e704dcd
	{
		get
		{
			if (x56410a8dd70087c5.x705ed5f9769744e5.x2588d8c20c42e232 == Underline.None)
			{
				return false;
			}
			if (x56410a8dd70087c5.x705ed5f9769744e5.x2588d8c20c42e232 == Underline.Words && (x56410a8dd70087c5.x5566e2d2acbd1fbe == 10754 || x56410a8dd70087c5.x5566e2d2acbd1fbe == 12803 || x56410a8dd70087c5.x5566e2d2acbd1fbe == 9747 || x56410a8dd70087c5.x5566e2d2acbd1fbe == 10770 || x56410a8dd70087c5.x5566e2d2acbd1fbe == 10782))
			{
				return false;
			}
			if (x56410a8dd70087c5.x2617ae682f706ca0 && !x56410a8dd70087c5.x2c8c6741422a1298.x80f061859cd048ae.xde015839cc88f18d.xe3317f2b441ead28)
			{
				return false;
			}
			return true;
		}
	}

	internal override PointF xc22eade24b085d91
	{
		get
		{
			if (x831916008bfc3ed7 == null)
			{
				x831916008bfc3ed7 = x4574ea26106f0edb.xc96d70553223ee04(new Point(x56410a8dd70087c5.x2ac47fc4f8b20847, x56410a8dd70087c5.x139412b8dea2f02b));
			}
			return (PointF)x831916008bfc3ed7;
		}
		set
		{
			x831916008bfc3ed7 = value;
		}
	}

	internal override float xdc1bf80853046136
	{
		get
		{
			if (x9fb0e9c0b1bdc4b3 != null)
			{
				return base.xdc1bf80853046136;
			}
			return 0f;
		}
	}

	internal override float xb0f146032f47c24e
	{
		get
		{
			if (x9fb0e9c0b1bdc4b3 != null)
			{
				return base.xb0f146032f47c24e;
			}
			return 0f;
		}
	}

	internal x5b0ea7c4a9d65903 x9ee8adcec1e2f351
	{
		get
		{
			return x8d8226994d810517;
		}
		set
		{
			x8d8226994d810517 = value;
		}
	}

	internal x56410a8dd70087c5 x56410a8dd70087c5 => x9fb0e9c0b1bdc4b3 as x56410a8dd70087c5;

	internal x038d2057eb729fcf(x398b3bd0acd94b61 part)
		: base(part)
	{
	}

	internal static string xe4b49d17e98f45f8(string xf6987a1745781d6f)
	{
		if (xf6987a1745781d6f == null)
		{
			return xf6987a1745781d6f;
		}
		return xf6987a1745781d6f.Replace('\u00a0', ' ');
	}
}
