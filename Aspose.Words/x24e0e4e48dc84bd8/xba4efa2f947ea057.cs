using System.Collections;

namespace x24e0e4e48dc84bd8;

internal class xba4efa2f947ea057
{
	private Stack xbf41aa070b906168 = new Stack();

	public void xd6b6ed77479ef68c(x1dd7d14b42118378 x01b557925841ae51)
	{
		xbf41aa070b906168.Push(x01b557925841ae51);
	}

	public x1dd7d14b42118378 x52b190e626f65140(int x0c131de6e4b13692)
	{
		while (xbf41aa070b906168.Count > 0)
		{
			x1dd7d14b42118378 x1dd7d14b42118379 = (x1dd7d14b42118378)xbf41aa070b906168.Pop();
			if (x1dd7d14b42118379.x121fecb7d5bede1d == x0c131de6e4b13692)
			{
				return x1dd7d14b42118379;
			}
		}
		return null;
	}
}
