namespace x4f4df92b75ba3b67;

internal class xf86e577c4526d9a1
{
	private readonly x4882ae789be6e2ef x8cedcaa9a62c6e39;

	private readonly xa9557e6051f29a2a xb98a60faee9bf68f;

	private xa9557e6051f29a2a x0c727542aa4e0b35;

	internal bool x7149c962c02931b3 => xb98a60faee9bf68f.x38ced5a01a389303 == null;

	internal string x899a2110a8a35fda => xb98a60faee9bf68f.x899a2110a8a35fda;

	internal xf86e577c4526d9a1(x4882ae789be6e2ef context)
	{
		x8cedcaa9a62c6e39 = context;
		xb98a60faee9bf68f = new xa9557e6051f29a2a(x8cedcaa9a62c6e39, "Root", -1, null);
		x0c727542aa4e0b35 = xb98a60faee9bf68f;
	}

	internal void xdac50776b1d359d8(string x37a96021dbbe3532, int x66bbd7ed8c65740d, x3b40d431d373c41d x6b8e154b42d5c1e3)
	{
		xa9557e6051f29a2a xa9557e6051f29a2a2 = new xa9557e6051f29a2a(x8cedcaa9a62c6e39, x37a96021dbbe3532, x66bbd7ed8c65740d, x6b8e154b42d5c1e3);
		if (xa9557e6051f29a2a2.x504f3d4040b356d7 > x0c727542aa4e0b35.x504f3d4040b356d7)
		{
			x0c727542aa4e0b35.x7b7a6766ca5eec6e(xa9557e6051f29a2a2);
		}
		else if (xa9557e6051f29a2a2.x504f3d4040b356d7 < x0c727542aa4e0b35.x504f3d4040b356d7)
		{
			while (x0c727542aa4e0b35.x504f3d4040b356d7 >= xa9557e6051f29a2a2.x504f3d4040b356d7)
			{
				x0c727542aa4e0b35 = x0c727542aa4e0b35.x332a8eedb847940d;
			}
			x0c727542aa4e0b35.x7b7a6766ca5eec6e(xa9557e6051f29a2a2);
		}
		else
		{
			x0c727542aa4e0b35.x332a8eedb847940d.x7b7a6766ca5eec6e(xa9557e6051f29a2a2);
		}
		x0c727542aa4e0b35 = xa9557e6051f29a2a2;
	}

	internal void x10f3680c04d77f08(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x7a67b9beb30292d6(xb98a60faee9bf68f);
		xbdfb620b7167944b.xafb7e6f79ed43681();
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Type", "/Outlines");
		if (xb98a60faee9bf68f.x38ced5a01a389303 != null)
		{
			xbdfb620b7167944b.xa4dc0ad8886e23a2("/First", xb98a60faee9bf68f.x38ced5a01a389303.x899a2110a8a35fda);
		}
		if (xb98a60faee9bf68f.xed3e432f7c9bf846 != null)
		{
			xbdfb620b7167944b.xa4dc0ad8886e23a2("/Last", xb98a60faee9bf68f.xed3e432f7c9bf846.x899a2110a8a35fda);
		}
		xbdfb620b7167944b.x693a8d6d020474f2();
		xbdfb620b7167944b.x5155d7b9dab28280();
		for (xa9557e6051f29a2a xa9557e6051f29a2a2 = xb98a60faee9bf68f.x38ced5a01a389303; xa9557e6051f29a2a2 != null; xa9557e6051f29a2a2 = xa9557e6051f29a2a2.xbc13914359462815)
		{
			xa9557e6051f29a2a2.WriteToPdf(xbdfb620b7167944b);
		}
	}
}
