using System.Collections;

namespace x2a6f63b6650e76c4;

internal class x8c3521e0d68eee94
{
	private readonly Stack xbf41aa070b906168 = new Stack();

	internal int xd44988f225497f3a => xbf41aa070b906168.Count;

	internal void x1914eddf1fde1228(x65f1c5fa03df41d5 x9c9eac3a36336680)
	{
		xbf41aa070b906168.Push(x9c9eac3a36336680);
	}

	internal x65f1c5fa03df41d5 x47c79a4d207183de()
	{
		return (x65f1c5fa03df41d5)xbf41aa070b906168.Pop();
	}

	internal x65f1c5fa03df41d5 x607a4a398b7b3888()
	{
		return (x65f1c5fa03df41d5)xbf41aa070b906168.Peek();
	}
}
