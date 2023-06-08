namespace x28925c9b27b37a46;

internal class x34b8d86b79df411d
{
	private x7e263f21a73a027a x4517c2b411ea1d52;

	private x98739d759efb5fe7 xc83d0e6d4611cafd;

	protected bool x2cfe892a9c18ef55 => x4517c2b411ea1d52.x12cb12b5d2cad53d.x807fa4fe13e2b839(xc83d0e6d4611cafd);

	protected bool x4cfb8da53d040316 => x4517c2b411ea1d52.x9fd888e65466818c.x807fa4fe13e2b839(xc83d0e6d4611cafd);

	internal x98739d759efb5fe7 x180f9c8380162d4e => xc83d0e6d4611cafd;

	internal x34b8d86b79df411d(x7e263f21a73a027a range)
	{
		x4517c2b411ea1d52 = range;
	}

	internal bool x47f176deff0d42e2(bool x4283b4e6c57a1853)
	{
		if (x4517c2b411ea1d52.x30d6662e83251ab4 || x4517c2b411ea1d52.x7149c962c02931b3)
		{
			return false;
		}
		if (xc83d0e6d4611cafd == null)
		{
			xc83d0e6d4611cafd = x4517c2b411ea1d52.x12cb12b5d2cad53d.x8b61531c8ea35b85();
			if (x4517c2b411ea1d52.xf89ce0154d15311b)
			{
				return true;
			}
		}
		if (x0e410626c9576523(x4283b4e6c57a1853))
		{
			return false;
		}
		if (!xc83d0e6d4611cafd.x47f176deff0d42e2(x4283b4e6c57a1853))
		{
			return false;
		}
		if (!x4517c2b411ea1d52.x09a741c07fe6233f)
		{
			return !x0e410626c9576523(x4283b4e6c57a1853);
		}
		return true;
	}

	internal bool x47f176deff0d42e2()
	{
		return x47f176deff0d42e2(x4283b4e6c57a1853: true);
	}

	internal void x74f5a1ef3906e23c()
	{
		xc83d0e6d4611cafd = null;
	}

	private bool x0e410626c9576523(bool x4283b4e6c57a1853)
	{
		if (!x4cfb8da53d040316)
		{
			return false;
		}
		if (!x2cfe892a9c18ef55)
		{
			return true;
		}
		if (x4517c2b411ea1d52.x9fd888e65466818c.xb84fd3bd45bf0c24(xc83d0e6d4611cafd))
		{
			return true;
		}
		if (!xc83d0e6d4611cafd.x40212106aad8a8b0.IsComposite && x4283b4e6c57a1853)
		{
			return true;
		}
		return false;
	}
}
