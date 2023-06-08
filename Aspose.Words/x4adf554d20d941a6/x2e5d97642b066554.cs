namespace x4adf554d20d941a6;

internal class x2e5d97642b066554
{
	internal static void xbc843e6d2f8d6fe7(x1073233de8252b3e x50a18ad2656e7181, x1073233de8252b3e x9e4d7279252bee4a)
	{
		xfbaf55d356868e77 x8faff3564372193a = x50a18ad2656e7181.x8faff3564372193a;
		x50a18ad2656e7181.x8faff3564372193a = x9e4d7279252bee4a.x8faff3564372193a;
		x50a18ad2656e7181.x8faff3564372193a.xc255c495fd9232ca = x50a18ad2656e7181;
		x9e4d7279252bee4a.x8faff3564372193a = x8faff3564372193a;
		x9e4d7279252bee4a.x8faff3564372193a.xc255c495fd9232ca = x9e4d7279252bee4a;
	}

	internal static bool x597e08db0a64a976(x852fe8bb5ac31098 xa447fc54e41dfe06, x852fe8bb5ac31098 xfc2074a859a5db8c)
	{
		if (!x40eee7eb012f1c68(xa447fc54e41dfe06, xfc2074a859a5db8c))
		{
			return x41123775242f8d75(xa447fc54e41dfe06, xfc2074a859a5db8c);
		}
		return true;
	}

	private static bool x40eee7eb012f1c68(x852fe8bb5ac31098 xa447fc54e41dfe06, x852fe8bb5ac31098 xfc2074a859a5db8c)
	{
		if (!xfc2074a859a5db8c.x7149c962c02931b3)
		{
			return false;
		}
		if (xfc2074a859a5db8c.x057ec8a18573254e)
		{
			return false;
		}
		if (xa447fc54e41dfe06.xe202d610ff4b6eca != xfc2074a859a5db8c)
		{
			return false;
		}
		if (xa447fc54e41dfe06.xca2d66057ac8daf2)
		{
			return false;
		}
		if (!xa447fc54e41dfe06.x35dcdaa8bc9d8066)
		{
			return false;
		}
		return true;
	}

	private static bool x41123775242f8d75(x852fe8bb5ac31098 xa447fc54e41dfe06, x852fe8bb5ac31098 xfc2074a859a5db8c)
	{
		if (!xfc2074a859a5db8c.x057ec8a18573254e)
		{
			return false;
		}
		if (!xfc2074a859a5db8c.x0ac0d07d9ef85b2b())
		{
			return false;
		}
		if (!xfc2074a859a5db8c.x35dcdaa8bc9d8066)
		{
			return false;
		}
		bool result = false;
		for (x852fe8bb5ac31098 xe202d610ff4b6eca = xa447fc54e41dfe06.xe202d610ff4b6eca; xe202d610ff4b6eca != null; xe202d610ff4b6eca = xe202d610ff4b6eca.xe202d610ff4b6eca)
		{
			if (!xe202d610ff4b6eca.x7149c962c02931b3)
			{
				return false;
			}
			if (xe202d610ff4b6eca == xfc2074a859a5db8c)
			{
				result = true;
			}
		}
		return result;
	}
}
