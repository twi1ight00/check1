using System;
using System.Collections;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using x996431aaaaf00543;

namespace x8b1f7613579e78d0;

internal class x241ec192a9b04589
{
	private x6b0a622599ef58fb xe5e7c5dcefb14298;

	private string x2d86ec1da68584cd = string.Empty;

	private string xb1e46151ebeb4978 = string.Empty;

	private ArrayList x661ff97aad146326;

	private byte[] x0df624923feda1e7;

	public x6b0a622599ef58fb x39a5a0699f625f92
	{
		get
		{
			return xe5e7c5dcefb14298;
		}
		set
		{
			xe5e7c5dcefb14298 = value;
		}
	}

	public string x04360fd10c29777d
	{
		get
		{
			if (x2d86ec1da68584cd == null)
			{
				x2d86ec1da68584cd = string.Empty;
			}
			return x2d86ec1da68584cd;
		}
		set
		{
			x2d86ec1da68584cd = value;
			x0df624923feda1e7 = null;
		}
	}

	public string xc1ac8b0c3628adf0
	{
		get
		{
			if (xb1e46151ebeb4978 == null)
			{
				xb1e46151ebeb4978 = string.Empty;
			}
			return xb1e46151ebeb4978;
		}
		set
		{
			xb1e46151ebeb4978 = value;
			x0df624923feda1e7 = null;
		}
	}

	public ArrayList x819589f292a61f6b
	{
		get
		{
			if (x661ff97aad146326 == null)
			{
				x661ff97aad146326 = new ArrayList();
			}
			return x661ff97aad146326;
		}
		set
		{
			x661ff97aad146326 = value;
		}
	}

	public x241ec192a9b04589 x8b61531c8ea35b85()
	{
		x241ec192a9b04589 x241ec192a9b4590 = new x241ec192a9b04589();
		x241ec192a9b4590.x39a5a0699f625f92 = x39a5a0699f625f92;
		x241ec192a9b4590.x04360fd10c29777d = x04360fd10c29777d;
		x241ec192a9b4590.xc1ac8b0c3628adf0 = xc1ac8b0c3628adf0;
		return x241ec192a9b4590;
	}

	public xfe2ff3c162b47c70 x22bfb60fc9ca9282(x1709225c4bd1ed83 x49432508d78271dd)
	{
		return xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(x601e9a2243ca6720(x49432508d78271dd));
	}

	public byte[] x601e9a2243ca6720(x1709225c4bd1ed83 x49432508d78271dd)
	{
		try
		{
			if (x0df624923feda1e7 != null)
			{
				return x0df624923feda1e7;
			}
			if (x0d299f323d241756.x5959bccb67bbf051(x04360fd10c29777d))
			{
				x0df624923feda1e7 = x49432508d78271dd.x3e0c39f372c8f2f9(x04360fd10c29777d);
			}
			else if (x0d299f323d241756.x5959bccb67bbf051(xc1ac8b0c3628adf0))
			{
				x0df624923feda1e7 = x49432508d78271dd.xe7ea3b1eeee820e4(xc1ac8b0c3628adf0);
			}
			return x0df624923feda1e7;
		}
		catch (Exception)
		{
			return null;
		}
	}
}
