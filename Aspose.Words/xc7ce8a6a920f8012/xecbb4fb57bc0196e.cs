using System.Collections;
using x6c95d9cf46ff5f25;

namespace xc7ce8a6a920f8012;

internal class xecbb4fb57bc0196e
{
	private ArrayList xddc60c8d74d0f01b;

	private int xaabccab0c06d038b;

	private string xf7bbe199f47f234d;

	private string xa61af110d151dec0;

	private xecbb4fb57bc0196e xc454c03c23d4b4d9;

	public int x504f3d4040b356d7 => xaabccab0c06d038b;

	public string x238bf167ccfdd282 => xf7bbe199f47f234d;

	public string x943890051c1a578d => xa61af110d151dec0;

	public xecbb4fb57bc0196e x332a8eedb847940d
	{
		get
		{
			return xc454c03c23d4b4d9;
		}
		set
		{
			xc454c03c23d4b4d9 = value;
		}
	}

	public xecbb4fb57bc0196e(int level, string title, string navigationUrl)
	{
		xaabccab0c06d038b = level;
		xf7bbe199f47f234d = title;
		xa61af110d151dec0 = navigationUrl;
		xddc60c8d74d0f01b = new ArrayList();
	}

	public void x7b7a6766ca5eec6e(xecbb4fb57bc0196e xccb63ca5f63dc470)
	{
		xccb63ca5f63dc470.x332a8eedb847940d = this;
		xddc60c8d74d0f01b.Add(xccb63ca5f63dc470);
	}

	public void xc33bb25620d72575(x3c74b3c4f21844f9 xd07ce4b74c5774a7)
	{
		for (int i = 0; i < xddc60c8d74d0f01b.Count; i++)
		{
			xecbb4fb57bc0196e xecbb4fb57bc0196e2 = (xecbb4fb57bc0196e)xddc60c8d74d0f01b[i];
			xecbb4fb57bc0196e2.x7ad6fffd3bdb13f7(xd07ce4b74c5774a7);
		}
	}

	private void x7ad6fffd3bdb13f7(x3c74b3c4f21844f9 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("outline");
		xd07ce4b74c5774a7.xff520a0047c27122("title", xf7bbe199f47f234d);
		xd07ce4b74c5774a7.xff520a0047c27122("url", xa61af110d151dec0);
		xc33bb25620d72575(xd07ce4b74c5774a7);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}
}
