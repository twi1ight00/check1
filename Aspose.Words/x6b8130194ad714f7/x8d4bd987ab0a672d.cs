using System.Collections;

namespace x6b8130194ad714f7;

internal class x8d4bd987ab0a672d : xc0c3660c7b899d0d
{
	private ArrayList x9a3b89d2367b5e4b = new ArrayList();

	public void x51061004a8e6f93e(x9fdddbe5699ad8e5 x0b5700835c9e1235)
	{
		if (x0b5700835c9e1235 != null && !x9a3b89d2367b5e4b.Contains(x0b5700835c9e1235))
		{
			x9a3b89d2367b5e4b.Add(x0b5700835c9e1235);
		}
	}

	public void x093faa888421d73b(x9fdddbe5699ad8e5 x0b5700835c9e1235)
	{
		if (x0b5700835c9e1235 != null)
		{
			x9a3b89d2367b5e4b.Remove(x0b5700835c9e1235);
		}
	}

	public void xf9b7fca29875330b(object x337e217cb3ba0627, string xc3513c7f2bbafa84)
	{
		foreach (x9fdddbe5699ad8e5 item in x9a3b89d2367b5e4b)
		{
			try
			{
				item.x255a9125fad2d9bb(x337e217cb3ba0627, xc3513c7f2bbafa84);
			}
			catch
			{
			}
		}
	}
}
