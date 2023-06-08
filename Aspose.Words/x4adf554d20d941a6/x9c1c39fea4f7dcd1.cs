using System;
using System.Collections;

namespace x4adf554d20d941a6;

internal class x9c1c39fea4f7dcd1
{
	private readonly Queue x63aaf3ff4d51622e = new Queue();

	internal bool x7149c962c02931b3 => x63aaf3ff4d51622e.Count <= 0;

	private int xd44988f225497f3a => x63aaf3ff4d51622e.Count;

	internal void xca34506722145a85(object xe0292b9ed559da7d, x9352d7e557b05f9e xfbf34718e704c6bc)
	{
		x63aaf3ff4d51622e.Enqueue(new object[2] { xe0292b9ed559da7d, xfbf34718e704c6bc });
	}

	internal void x1536749f629911ac(object[] xfbf34718e704c6bc)
	{
		Array.Copy((object[])x63aaf3ff4d51622e.Dequeue(), xfbf34718e704c6bc, xfbf34718e704c6bc.Length);
	}

	internal void xbb7550bbb62a218c(bool xfad304b5f8f3bb5b)
	{
		object[] array = new object[2];
		int num = xd44988f225497f3a;
		for (int i = 0; (xfad304b5f8f3bb5b && !x7149c962c02931b3) || i < num; i++)
		{
			x1536749f629911ac(array);
			object xe0292b9ed559da7d = array[0];
			x9352d7e557b05f9e x9352d7e557b05f9e2 = (x9352d7e557b05f9e)array[1];
			x9352d7e557b05f9e2.xae145c0710a57c3f.xae7aaadc88b9a9f5(xe0292b9ed559da7d, x9352d7e557b05f9e2);
		}
	}
}
