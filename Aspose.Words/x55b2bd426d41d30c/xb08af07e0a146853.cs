using System.IO;
using System.Text;
using xf9a9481c3f63a419;

namespace x55b2bd426d41d30c;

internal class xb08af07e0a146853
{
	private readonly x98b82bd568a929c4 x4642a7afcf443698 = new x98b82bd568a929c4();

	public x98b82bd568a929c4 xd6abb2ab950b4d22 => x4642a7afcf443698;

	public xb08af07e0a146853()
	{
	}

	public xb08af07e0a146853(string filename)
	{
		using Stream xcf18e5243f8d5fd = new FileStream(filename, FileMode.Open, FileAccess.Read);
		x5d4db34d48fb3129(xcf18e5243f8d5fd);
	}

	public xb08af07e0a146853(Stream stream)
	{
		x5d4db34d48fb3129(stream);
	}

	private void x5d4db34d48fb3129(Stream xcf18e5243f8d5fd3)
	{
		xc5d5cabda4535c40 xc5d5cabda4535c = new xc5d5cabda4535c40(xcf18e5243f8d5fd3);
		while (xc5d5cabda4535c.xa10f9c7d6062e4a9())
		{
			x0ca5e8b532953a51 x0ca5e8b532953a52 = new x0ca5e8b532953a51(x034857d431c3b7cf(xc5d5cabda4535c.x2b9ddc3bb222d878));
			x4642a7afcf443698.xd6b6ed77479ef68c(x0ca5e8b532953a52);
			xc5d5cabda4535c.x5b90d11fb5da5910(x0ca5e8b532953a52.xb8a774e0111d0fbe);
			x0ca5e8b532953a52.xb8a774e0111d0fbe.Position = 0L;
		}
	}

	public x0ca5e8b532953a51 x5621ebad67e4df79(string xc15bd84e01929885)
	{
		return x4642a7afcf443698.get_xe6d4b1b411ed94b5(xc15bd84e01929885);
	}

	public void x0acd3c2012ea2ee8(Stream xcf18e5243f8d5fd3, string xe1d3286d17e44a37)
	{
		x16c15bc14c6d8897 x16c15bc14c6d = new x16c15bc14c6d8897(xcf18e5243f8d5fd3);
		x16c15bc14c6d.x2c7bb6cb9492babe("mimetype", Encoding.ASCII.GetBytes(xe1d3286d17e44a37));
		foreach (x0ca5e8b532953a51 item in x4642a7afcf443698)
		{
			item.xb8a774e0111d0fbe.Position = 0L;
			x16c15bc14c6d.xd7d75c376e5ae843(xb6dcac13cde77caf(item.x759aa16c2016a289), item.xb8a774e0111d0fbe);
		}
		x16c15bc14c6d.x7ffaace5132efedd();
	}

	private static string xb6dcac13cde77caf(string x69cb5ff2e6c23f47)
	{
		return x69cb5ff2e6c23f47.TrimStart('/');
	}

	internal static string x034857d431c3b7cf(string xacf645aa6fc873a3)
	{
		return "/" + xacf645aa6fc873a3;
	}
}
