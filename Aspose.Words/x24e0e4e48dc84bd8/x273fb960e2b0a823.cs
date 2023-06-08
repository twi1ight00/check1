using Aspose;
using x1c8faa688b1f0b0c;

namespace x24e0e4e48dc84bd8;

internal abstract class x273fb960e2b0a823
{
	private x4fdf549af9de6b97 x2c0c54ac5228656f;

	private readonly byte[] xd4251e57da4db8b6;

	public byte[] x90427ee74997bf7a => xd4251e57da4db8b6;

	protected x273fb960e2b0a823(byte[] bytes)
	{
		xd4251e57da4db8b6 = bytes;
	}

	public x4fdf549af9de6b97 xca1273758a917434()
	{
		if (x2c0c54ac5228656f == null)
		{
			x2c0c54ac5228656f = ConverToAps();
		}
		return x2c0c54ac5228656f;
	}

	[JavaThrows(true)]
	protected abstract x4fdf549af9de6b97 ConverToAps();
}
