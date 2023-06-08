using xbe73d5820f7f4ae3;

namespace xa2462df43988ffad;

internal class xbfe28dc6957d92f0
{
	internal bool xf398ffaf32ffe055;

	private float x7f1db2ff3584843d;

	internal readonly xd9f86432309317e4 xa8c2637cc4888928;

	internal readonly xd9f86432309317e4 x79d902473861f242;

	internal readonly xd9f86432309317e4 xaea087ab32102492;

	internal readonly xd9f86432309317e4 xd7a21e27974f626c;

	internal bool x7e7782b21b2e73d0;

	internal xbfe28dc6957d92f0()
	{
		xa8c2637cc4888928 = new xd9f86432309317e4();
		x79d902473861f242 = new xd9f86432309317e4();
		xaea087ab32102492 = new xd9f86432309317e4();
		xd7a21e27974f626c = new xd9f86432309317e4();
	}

	internal void x6210059f049f0d48(x9c77c7e782b62883 xd07ce4b74c5774a7)
	{
		xa8c2637cc4888928.x6210059f049f0d48(xd07ce4b74c5774a7, "top");
		x79d902473861f242.x6210059f049f0d48(xd07ce4b74c5774a7, "bottom");
		xaea087ab32102492.x6210059f049f0d48(xd07ce4b74c5774a7, "left");
		xd7a21e27974f626c.x6210059f049f0d48(xd07ce4b74c5774a7, "right");
		if (xf398ffaf32ffe055)
		{
			xd07ce4b74c5774a7.x943f6be3acf634db("style:shadow", $"#000000 {xbb857c9fc36f5054.x96d7e563211411f6(x7f1db2ff3584843d)} {xbb857c9fc36f5054.x96d7e563211411f6(x7f1db2ff3584843d)}");
		}
	}

	internal bool x5f92400e1485c05c(bool x2b818897b65c872e, bool xa6651a0a6d059494)
	{
		bool result = false;
		if (x9a0b6e3c347f8d15(xa8c2637cc4888928, x2b818897b65c872e, xa6651a0a6d059494))
		{
			result = true;
		}
		if (x9a0b6e3c347f8d15(x79d902473861f242, x2b818897b65c872e, xa6651a0a6d059494))
		{
			result = true;
		}
		if (x9a0b6e3c347f8d15(xaea087ab32102492, x2b818897b65c872e, xa6651a0a6d059494))
		{
			result = true;
		}
		if (x9a0b6e3c347f8d15(xd7a21e27974f626c, x2b818897b65c872e, xa6651a0a6d059494))
		{
			result = true;
		}
		return result;
	}

	private bool x9a0b6e3c347f8d15(xd9f86432309317e4 x895c40fd497ba465, bool x2b818897b65c872e, bool xa6651a0a6d059494)
	{
		if (x895c40fd497ba465.x03cb705fbd5700a4 != null && x895c40fd497ba465.x03cb705fbd5700a4.Shadow)
		{
			xf398ffaf32ffe055 = true;
			if (x895c40fd497ba465.x03cb705fbd5700a4.xeae235558dc44397 > x7f1db2ff3584843d)
			{
				x7f1db2ff3584843d = x895c40fd497ba465.x03cb705fbd5700a4.xeae235558dc44397;
			}
		}
		x895c40fd497ba465.x7e7782b21b2e73d0 = x7e7782b21b2e73d0;
		if (!x895c40fd497ba465.xd586e0c16bdae7fc(x2b818897b65c872e, xa6651a0a6d059494))
		{
			return xf398ffaf32ffe055;
		}
		return true;
	}
}
