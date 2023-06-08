using System.Collections;
using x9e34b6f7e9185197;
using xa6cc8e39f9a280d7;

namespace xc76255e87e5986c6;

internal class x4f15c2ab6fab0941
{
	private Hashtable x6a49f4f8f87a0802 = new Hashtable();

	private string xc61ff88f1f98652d;

	public string x759aa16c2016a289
	{
		get
		{
			if (xc61ff88f1f98652d == null)
			{
				xc61ff88f1f98652d = string.Empty;
			}
			return xc61ff88f1f98652d;
		}
		set
		{
			xc61ff88f1f98652d = value;
		}
	}

	public void xd48bda2de519c530(xd7e8497b32a408b8 x6c50a99faab7d741, x19119439284aead2 x7b603f7215a89cdd)
	{
		x6a49f4f8f87a0802[x7b603f7215a89cdd] = x6c50a99faab7d741;
	}

	public xd7e8497b32a408b8 xef50a938c8b9c7fd(x19119439284aead2 x7b603f7215a89cdd)
	{
		x7b603f7215a89cdd = xa67209fbf0f418e8(x7b603f7215a89cdd);
		return (xd7e8497b32a408b8)x6a49f4f8f87a0802[x7b603f7215a89cdd];
	}

	private x19119439284aead2 xa67209fbf0f418e8(x19119439284aead2 x6c50a99faab7d741)
	{
		return x6c50a99faab7d741 switch
		{
			x19119439284aead2.x8746bc414a8b9cc0 => x19119439284aead2.x34614caf8d0b54eb, 
			x19119439284aead2.x64b7a46621ad97d7 => x19119439284aead2.x457bb4d1a786686c, 
			x19119439284aead2.xdf3651e9ee6f58b9 => x19119439284aead2.xbc991998f16b5de4, 
			x19119439284aead2.xe779b81e8f63bfd5 => x19119439284aead2.x24036af9e33bd304, 
			_ => x6c50a99faab7d741, 
		};
	}
}
