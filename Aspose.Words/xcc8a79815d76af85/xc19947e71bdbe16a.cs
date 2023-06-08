using System.Text;
using x4dc96876c552a593;
using x6c95d9cf46ff5f25;

namespace xcc8a79815d76af85;

internal class xc19947e71bdbe16a
{
	private x6b94cea616e07c30 x2cfa10ff58801ec4;

	private x66db231de95e4103 x9c4686d7818b89ec;

	private string x9913fbaf0b91e577;

	private x4e987a76388726b5 x236c9369a45d1ec9;

	public x6b94cea616e07c30 x81575bc7c9357176 => x2cfa10ff58801ec4;

	public x66db231de95e4103 x7f54fb2d3a2bf08f
	{
		get
		{
			return x9c4686d7818b89ec;
		}
		set
		{
			x9c4686d7818b89ec = value;
		}
	}

	public string x08c5d9f4b0653c8d
	{
		get
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(x9913fbaf0b91e577) && x9c4686d7818b89ec != null && x9c4686d7818b89ec.xb730a77005d16cc1.x320382c5f1993a78[0] != null)
			{
				x9913fbaf0b91e577 = ((x86270791cf6a92b9)x9c4686d7818b89ec.xb730a77005d16cc1.x320382c5f1993a78[0]).StringValue;
			}
			return x9913fbaf0b91e577;
		}
		set
		{
			x2cfa10ff58801ec4 = x6b94cea616e07c30.x5a25f59d572442aa;
			x9913fbaf0b91e577 = value;
		}
	}

	public x4e987a76388726b5 x71826a9cb7f893e0
	{
		get
		{
			return x236c9369a45d1ec9;
		}
		set
		{
			x2cfa10ff58801ec4 = x6b94cea616e07c30.xbc111572dd185bf5;
			x236c9369a45d1ec9 = value;
		}
	}

	internal string x633d57e35b6715a4()
	{
		if (x71826a9cb7f893e0 != null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (xf5c6aa532fe023d4 item in x71826a9cb7f893e0.xe944988856b6cea9)
			{
				foreach (x62d3f1339ed0fbcf item2 in item.x0c560ee4a7223d6d)
				{
					if (item2 is x91f0f9c35f99edd9)
					{
						stringBuilder.Append(((x91f0f9c35f99edd9)item2).xf9ad6fb78355fe13);
					}
				}
			}
			return stringBuilder.ToString();
		}
		return x08c5d9f4b0653c8d;
	}
}
