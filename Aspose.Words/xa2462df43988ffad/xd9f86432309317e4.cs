using Aspose.Words;
using xbe73d5820f7f4ae3;

namespace xa2462df43988ffad;

internal class xd9f86432309317e4
{
	internal string x51d60f077c5fc6e0;

	internal string xcdd9c381820c3274;

	internal string x3dcd010ed1e386de;

	internal string x6545d1f2c1b77773;

	internal double xfe8b2581f8989da7 = double.NaN;

	internal double xdce98c019bd9517d = double.NaN;

	internal Border x03cb705fbd5700a4;

	internal bool x7e7782b21b2e73d0;

	internal void x6210059f049f0d48(x9c77c7e782b62883 xd07ce4b74c5774a7, string x4f217665270fa928)
	{
		xd07ce4b74c5774a7.x943f6be3acf634db($"fo:padding-{x4f217665270fa928}", x3dcd010ed1e386de);
		xd07ce4b74c5774a7.x943f6be3acf634db($"fo:border-{x4f217665270fa928}", x51d60f077c5fc6e0);
		xd07ce4b74c5774a7.x943f6be3acf634db($"fo:margin-{x4f217665270fa928}", x6545d1f2c1b77773);
		xd07ce4b74c5774a7.x943f6be3acf634db($"style:border-line-width-{x4f217665270fa928}", xcdd9c381820c3274);
	}

	internal bool xd586e0c16bdae7fc(bool x2b818897b65c872e, bool xa6651a0a6d059494)
	{
		double num = (xa6651a0a6d059494 ? 0.0 : double.NaN);
		double num3;
		if (x03cb705fbd5700a4 != null)
		{
			double num2 = xbb857c9fc36f5054.x6a2cd7b6d4dbe0bb(x03cb705fbd5700a4.x1f2d5df87a5c4f81);
			if (xa6651a0a6d059494)
			{
				num = num2;
				num3 = ((!double.IsNaN(xdce98c019bd9517d)) ? (xdce98c019bd9517d - num2 - xbb857c9fc36f5054.x6a2cd7b6d4dbe0bb(x03cb705fbd5700a4.LineWidth)) : (num2 - xbb857c9fc36f5054.x6a2cd7b6d4dbe0bb(x03cb705fbd5700a4.LineWidth)));
				if (x7e7782b21b2e73d0)
				{
					double num4 = num3;
					num3 = num;
					num = num4;
				}
			}
			else
			{
				num = ((!double.IsNaN(xdce98c019bd9517d)) ? ((xdce98c019bd9517d - num2 == 0.0) ? double.NaN : (xdce98c019bd9517d - num2)) : ((num2 == 0.0) ? double.NaN : num2));
				num3 = xdce98c019bd9517d;
			}
			if (x0eb9a864413f34de.x6e755b88613727d8(x03cb705fbd5700a4.LineStyle) == "double")
			{
				string text = xbb857c9fc36f5054.x96d7e563211411f6(xbb857c9fc36f5054.x74060b9a671b9ca3(x03cb705fbd5700a4.LineStyle, x03cb705fbd5700a4.xab266ea415f07c09) / 3.0);
				xcdd9c381820c3274 = $"{text} {text} {text}";
			}
			x51d60f077c5fc6e0 = xbb857c9fc36f5054.x7006e2fd50829e4a(x03cb705fbd5700a4, x2b818897b65c872e);
		}
		else
		{
			num3 = xdce98c019bd9517d;
		}
		if (!double.IsNaN(num3) && num3 >= 0.0)
		{
			x6545d1f2c1b77773 = xbb857c9fc36f5054.x34bdf37bc4f6368b(num3);
		}
		if (!double.IsNaN(num) && num >= 0.0)
		{
			x3dcd010ed1e386de = xbb857c9fc36f5054.x34bdf37bc4f6368b(num);
		}
		if (x3dcd010ed1e386de == null && x51d60f077c5fc6e0 == null)
		{
			return x6545d1f2c1b77773 != null;
		}
		return true;
	}
}
