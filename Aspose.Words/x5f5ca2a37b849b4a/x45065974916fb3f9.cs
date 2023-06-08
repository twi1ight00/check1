using System;
using System.Collections;
using System.Reflection;

namespace x5f5ca2a37b849b4a;

[DefaultMember("Item")]
internal class x45065974916fb3f9
{
	private Hashtable x92846a201c23924a = new Hashtable();

	internal x8579bcedac010519 xe6d4b1b411ed94b5
	{
		get
		{
			if (x44ecfea61c937b8e < 1 || x44ecfea61c937b8e > 48)
			{
				throw new ArgumentException("Style must be in range between 1 and 48 inclusive.");
			}
			object obj = x92846a201c23924a[x44ecfea61c937b8e];
			if (obj == null)
			{
				for (int i = 1; i <= x44ecfea61c937b8e; i++)
				{
					if (x92846a201c23924a[i] != null)
					{
						obj = x92846a201c23924a[i];
					}
				}
			}
			return (x8579bcedac010519)obj;
		}
		set
		{
			if (x44ecfea61c937b8e < 1 || x44ecfea61c937b8e > 48)
			{
				throw new ArgumentException("Style must be in range between 1 and 48 inclusive.");
			}
			x92846a201c23924a[x44ecfea61c937b8e] = value;
		}
	}
}
