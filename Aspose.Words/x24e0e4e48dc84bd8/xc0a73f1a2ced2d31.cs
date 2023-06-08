using System;
using System.Drawing;
using x6c95d9cf46ff5f25;
using xa7850104c8d8c135;

namespace x24e0e4e48dc84bd8;

internal class xc0a73f1a2ced2d31
{
	private double xcd2575f409f2fa1c = 96.0;

	private double x8e1b6c5f655e675f = 96.0;

	public double xfcad41fa51b4114e
	{
		get
		{
			return xcd2575f409f2fa1c;
		}
		set
		{
			xcd2575f409f2fa1c = value;
		}
	}

	public double xacc339743dffe4c0
	{
		get
		{
			return x8e1b6c5f655e675f;
		}
		set
		{
			x8e1b6c5f655e675f = value;
		}
	}

	public double x3ae2efb7fb57cc6a(double xbcea506a33cf9111, x60f0a0028c81b61c xec1dc110291a6af9)
	{
		return xec1dc110291a6af9 switch
		{
			x60f0a0028c81b61c.x7e8cf1e7b595157e => xbcea506a33cf9111, 
			x60f0a0028c81b61c.x09545e10fff1add9 => xbcea506a33cf9111, 
			x60f0a0028c81b61c.xf81cffce159a6359 => x4574ea26106f0edb.xad2dd08366e0faf5(xbcea506a33cf9111, xcd2575f409f2fa1c), 
			x60f0a0028c81b61c.xa68772d91d1d18a4 => xbcea506a33cf9111, 
			x60f0a0028c81b61c.x8ce7726231b95d6f => x4574ea26106f0edb.x9adffc4de2e5ac97(xbcea506a33cf9111), 
			x60f0a0028c81b61c.x5b30d761342b46b2 => xbcea506a33cf9111 / 300.0, 
			x60f0a0028c81b61c.x3dbbb018ed21db35 => x4574ea26106f0edb.x5612f4c9f83f95d3(xbcea506a33cf9111), 
			_ => throw new ArgumentOutOfRangeException("unitType"), 
		};
	}

	public double x645cd44df6f04941(double xbcea506a33cf9111, x60f0a0028c81b61c xec1dc110291a6af9)
	{
		return xec1dc110291a6af9 switch
		{
			x60f0a0028c81b61c.x7e8cf1e7b595157e => xbcea506a33cf9111, 
			x60f0a0028c81b61c.x09545e10fff1add9 => xbcea506a33cf9111, 
			x60f0a0028c81b61c.xf81cffce159a6359 => xbcea506a33cf9111, 
			x60f0a0028c81b61c.xa68772d91d1d18a4 => x4574ea26106f0edb.x1f1488a9109eace7(xbcea506a33cf9111, xcd2575f409f2fa1c), 
			x60f0a0028c81b61c.x8ce7726231b95d6f => x4574ea26106f0edb.xb0e438d6d798d50b(xbcea506a33cf9111, xcd2575f409f2fa1c), 
			x60f0a0028c81b61c.x5b30d761342b46b2 => x4574ea26106f0edb.x1f1488a9109eace7(xbcea506a33cf9111 / 300.0, xcd2575f409f2fa1c), 
			x60f0a0028c81b61c.x3dbbb018ed21db35 => x4574ea26106f0edb.x2dec7440ed5bb457(xbcea506a33cf9111, xcd2575f409f2fa1c), 
			_ => throw new ArgumentOutOfRangeException("unitType"), 
		};
	}

	public RectangleF x645cd44df6f04941(RectangleF x26545669838eb36e, x60f0a0028c81b61c xe373d1943de92e35)
	{
		return RectangleF.FromLTRB((float)x645cd44df6f04941(x26545669838eb36e.Left, xe373d1943de92e35), (float)x645cd44df6f04941(x26545669838eb36e.Top, xe373d1943de92e35), (float)x645cd44df6f04941(x26545669838eb36e.Right, xe373d1943de92e35), (float)x645cd44df6f04941(x26545669838eb36e.Bottom, xe373d1943de92e35));
	}
}
