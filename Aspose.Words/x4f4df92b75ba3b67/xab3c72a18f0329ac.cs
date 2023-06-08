using x6c95d9cf46ff5f25;

namespace x4f4df92b75ba3b67;

internal class xab3c72a18f0329ac : x264ba3b7aca691be
{
	private float xe91beb1d06f0c155 = 1f;

	private float xcff1a3cc383a7674 = 1f;

	internal override x3499f937de5622bc x41c71fb0a8629935 => x3499f937de5622bc.xf70cb55d58c64a9c;

	internal float x0b15246bc2e0140e
	{
		get
		{
			return xe91beb1d06f0c155;
		}
		set
		{
			xe91beb1d06f0c155 = value;
		}
	}

	internal float x5f994f7d6671fc42
	{
		get
		{
			return xcff1a3cc383a7674;
		}
		set
		{
			xcff1a3cc383a7674 = value;
		}
	}

	internal xab3c72a18f0329ac(x4882ae789be6e2ef context)
		: base(context)
	{
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		writer.xa4dc0ad8886e23a2("/Type", "/ExtGState");
		if (x8cedcaa9a62c6e39.x5ba9693d4c3c102e)
		{
			writer.xa4dc0ad8886e23a2("/CA", "1.0");
			writer.xa4dc0ad8886e23a2("/ca", "1.0");
			if (xe91beb1d06f0c155 < 1f || xcff1a3cc383a7674 < 1f)
			{
				x8cedcaa9a62c6e39.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, "Transparency does not conform to PDF/A standard and has been removed.");
			}
		}
		else
		{
			writer.xa4dc0ad8886e23a2("/CA", xe91beb1d06f0c155);
			writer.xa4dc0ad8886e23a2("/ca", xcff1a3cc383a7674);
		}
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
	}

	internal bool Equals(xab3c72a18f0329ac rhs)
	{
		if (rhs != null && xe91beb1d06f0c155 == rhs.xe91beb1d06f0c155)
		{
			return xcff1a3cc383a7674 == rhs.xcff1a3cc383a7674;
		}
		return false;
	}
}
