using System.Collections;

namespace x2a6f63b6650e76c4;

internal class xa7ef704c7557cbae
{
	private readonly Stack xbf41aa070b906168 = new Stack();

	internal void x1914eddf1fde1228(x82e26649b09596bd xb4480c8b340110b9)
	{
		xbf41aa070b906168.Push(xb4480c8b340110b9);
	}

	internal x82e26649b09596bd x47c79a4d207183de()
	{
		if (xbf41aa070b906168.Count == 0)
		{
			return new xf7d966ea5d1701b6("!Syntax Error");
		}
		return (x82e26649b09596bd)xbf41aa070b906168.Pop();
	}
}
