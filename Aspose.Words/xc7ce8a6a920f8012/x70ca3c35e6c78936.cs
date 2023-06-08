using x6c95d9cf46ff5f25;

namespace xc7ce8a6a920f8012;

internal class x70ca3c35e6c78936
{
	private xecbb4fb57bc0196e xc627a977c47d5ef4;

	private xecbb4fb57bc0196e x0c727542aa4e0b35;

	private int x6efe68e6aabe9b31;

	public x70ca3c35e6c78936(int expandedOutlineLevels)
	{
		xc627a977c47d5ef4 = new xecbb4fb57bc0196e(-1, "root", "");
		x0c727542aa4e0b35 = xc627a977c47d5ef4;
		x6efe68e6aabe9b31 = expandedOutlineLevels;
	}

	public void xdac50776b1d359d8(int x66bbd7ed8c65740d, string x37a96021dbbe3532, string x2cde75ecfbc26b0b)
	{
		if (x66bbd7ed8c65740d < 0 || !x0d299f323d241756.x5959bccb67bbf051(x37a96021dbbe3532) || !x0d299f323d241756.x5959bccb67bbf051(x2cde75ecfbc26b0b))
		{
			return;
		}
		xecbb4fb57bc0196e xecbb4fb57bc0196e2 = new xecbb4fb57bc0196e(x66bbd7ed8c65740d, x37a96021dbbe3532, x2cde75ecfbc26b0b);
		if (xecbb4fb57bc0196e2.x504f3d4040b356d7 > x0c727542aa4e0b35.x504f3d4040b356d7)
		{
			x0c727542aa4e0b35.x7b7a6766ca5eec6e(xecbb4fb57bc0196e2);
		}
		else if (xecbb4fb57bc0196e2.x504f3d4040b356d7 < x0c727542aa4e0b35.x504f3d4040b356d7)
		{
			while (x0c727542aa4e0b35.x504f3d4040b356d7 >= xecbb4fb57bc0196e2.x504f3d4040b356d7)
			{
				x0c727542aa4e0b35 = x0c727542aa4e0b35.x332a8eedb847940d;
			}
			x0c727542aa4e0b35.x7b7a6766ca5eec6e(xecbb4fb57bc0196e2);
		}
		else
		{
			x0c727542aa4e0b35.x332a8eedb847940d.x7b7a6766ca5eec6e(xecbb4fb57bc0196e2);
		}
		x0c727542aa4e0b35 = xecbb4fb57bc0196e2;
	}

	public void xa2d0834a5d3e1a19(x3c74b3c4f21844f9 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("outlines");
		xd07ce4b74c5774a7.xff520a0047c27122("expandedOutlineLevels", x6efe68e6aabe9b31.ToString());
		xc627a977c47d5ef4.xc33bb25620d72575(xd07ce4b74c5774a7);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}
}
