namespace x4f4df92b75ba3b67;

internal class xa9557e6051f29a2a : x264ba3b7aca691be
{
	internal string x238bf167ccfdd282;

	internal int x504f3d4040b356d7;

	internal x3b40d431d373c41d xca4d557d535fa375;

	internal xa9557e6051f29a2a x332a8eedb847940d;

	internal xa9557e6051f29a2a xd3669c4cce512327;

	internal xa9557e6051f29a2a xbc13914359462815;

	internal xa9557e6051f29a2a x38ced5a01a389303;

	internal xa9557e6051f29a2a xed3e432f7c9bf846;

	internal xa9557e6051f29a2a(x4882ae789be6e2ef context, string title, int level, x3b40d431d373c41d destination)
		: base(context)
	{
		x238bf167ccfdd282 = title;
		x504f3d4040b356d7 = level;
		xca4d557d535fa375 = destination;
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x1c638d277561c422(xbfbb1719d4106af2());
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		writer.x94aba205302527e1("/Title", x238bf167ccfdd282);
		writer.xa4dc0ad8886e23a2("/Parent", x332a8eedb847940d.x899a2110a8a35fda);
		if (xd3669c4cce512327 != null)
		{
			writer.xa4dc0ad8886e23a2("/Prev", xd3669c4cce512327.x899a2110a8a35fda);
		}
		if (xbc13914359462815 != null)
		{
			writer.xa4dc0ad8886e23a2("/Next", xbc13914359462815.x899a2110a8a35fda);
		}
		if (x38ced5a01a389303 != null)
		{
			writer.xa4dc0ad8886e23a2("/First", x38ced5a01a389303.x899a2110a8a35fda);
		}
		if (xed3e432f7c9bf846 != null)
		{
			writer.xa4dc0ad8886e23a2("/Last", xed3e432f7c9bf846.x899a2110a8a35fda);
		}
		if (x38ced5a01a389303 != null)
		{
			int num = xd81c6696ad9e3f31();
			if (x504f3d4040b356d7 >= x8cedcaa9a62c6e39.x73979cef1002ed01.x6b12d92d6782ee94)
			{
				num = -num;
			}
			writer.xa4dc0ad8886e23a2("/Count", num);
		}
		writer.x6210059f049f0d48("/Dest");
		xca4d557d535fa375.x10f3680c04d77f08(writer);
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
		for (xa9557e6051f29a2a xa9557e6051f29a2a2 = x38ced5a01a389303; xa9557e6051f29a2a2 != null; xa9557e6051f29a2a2 = xa9557e6051f29a2a2.xbc13914359462815)
		{
			xa9557e6051f29a2a2.WriteToPdf(writer);
		}
	}

	internal void x7b7a6766ca5eec6e(xa9557e6051f29a2a xde860fba55c41d76)
	{
		if (x38ced5a01a389303 == null)
		{
			x38ced5a01a389303 = xde860fba55c41d76;
		}
		else
		{
			xed3e432f7c9bf846.xbc13914359462815 = xde860fba55c41d76;
			xde860fba55c41d76.xd3669c4cce512327 = xed3e432f7c9bf846;
		}
		xed3e432f7c9bf846 = xde860fba55c41d76;
		xde860fba55c41d76.x332a8eedb847940d = this;
	}

	private int xd81c6696ad9e3f31()
	{
		int num = 0;
		for (xa9557e6051f29a2a xa9557e6051f29a2a2 = x38ced5a01a389303; xa9557e6051f29a2a2 != null; xa9557e6051f29a2a2 = xa9557e6051f29a2a2.xbc13914359462815)
		{
			num++;
		}
		return num;
	}
}
