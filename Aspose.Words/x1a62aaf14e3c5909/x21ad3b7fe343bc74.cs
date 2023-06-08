using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace x1a62aaf14e3c5909;

[DefaultMember("Item")]
internal class x21ad3b7fe343bc74 : xddf6304144fd3863
{
	private x622ccf73c1aa9e89 xddc60c8d74d0f01b = new x622ccf73c1aa9e89();

	internal x622ccf73c1aa9e89 xf2453c298c5de6f5 => xddc60c8d74d0f01b;

	internal int xd44988f225497f3a => xddc60c8d74d0f01b.Count;

	internal xddf6304144fd3863 xe6d4b1b411ed94b5
	{
		get
		{
			return xddc60c8d74d0f01b.get_xe6d4b1b411ed94b5(xc0c4c459c6ccbd00);
		}
		set
		{
			xddc60c8d74d0f01b.set_xe6d4b1b411ed94b5(xc0c4c459c6ccbd00, value);
		}
	}

	internal x21ad3b7fe343bc74()
	{
	}

	internal x21ad3b7fe343bc74(x773fe540042dad03 type)
	{
		base.x1ea60bde2b5d0d28.xffbe50541a5f9da3 = true;
		base.x1ea60bde2b5d0d28.x3146d638ec378671 = type;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0} Start\n", GetType().Name);
		stringBuilder.AppendFormat("Self: {0}\n", base.ToString());
		for (int i = 0; i < xddc60c8d74d0f01b.Count; i++)
		{
			stringBuilder.AppendFormat("{0}\n", xddc60c8d74d0f01b.get_xe6d4b1b411ed94b5(i).ToString());
		}
		stringBuilder.AppendFormat("{0} End\n", GetType().Name);
		return stringBuilder.ToString();
	}

	internal xddf6304144fd3863 x125f04e3b1dbfafd(x773fe540042dad03 xc1674de501b364d0)
	{
		for (int i = 0; i < xddc60c8d74d0f01b.Count; i++)
		{
			xddf6304144fd3863 xddf6304144fd3864 = xddc60c8d74d0f01b.get_xe6d4b1b411ed94b5(i);
			if (xddf6304144fd3864.x1ea60bde2b5d0d28.x3146d638ec378671 == xc1674de501b364d0)
			{
				return xddf6304144fd3864;
			}
		}
		return null;
	}

	internal x21ad3b7fe343bc74 x14a0892a8fc0bc92(xddf6304144fd3863 xa71d725cbde3e9e6)
	{
		for (int i = 0; i < xddc60c8d74d0f01b.Count; i++)
		{
			xddf6304144fd3863 xddf6304144fd3864 = xddc60c8d74d0f01b.get_xe6d4b1b411ed94b5(i);
			if (xddf6304144fd3864 == xa71d725cbde3e9e6)
			{
				return this;
			}
			if (xddf6304144fd3864 is x21ad3b7fe343bc74)
			{
				x21ad3b7fe343bc74 x21ad3b7fe343bc75 = (x21ad3b7fe343bc74)xddf6304144fd3864;
				x21ad3b7fe343bc74 x21ad3b7fe343bc76 = x21ad3b7fe343bc75.x14a0892a8fc0bc92(xa71d725cbde3e9e6);
				if (x21ad3b7fe343bc76 != null)
				{
					return x21ad3b7fe343bc76;
				}
			}
		}
		return null;
	}

	internal xddf6304144fd3863 xe382d6617070a76d(Type x43163d22e8cd5a71)
	{
		for (int i = 0; i < xddc60c8d74d0f01b.Count; i++)
		{
			xddf6304144fd3863 xddf6304144fd3864 = xddc60c8d74d0f01b.get_xe6d4b1b411ed94b5(i);
			if (xddf6304144fd3864.GetType() == x43163d22e8cd5a71)
			{
				return xddf6304144fd3864;
			}
		}
		return null;
	}

	protected override void DoRead(BinaryReader reader)
	{
		xddc60c8d74d0f01b.x06b0e25aa6ad68a9(reader, base.x1ea60bde2b5d0d28.x1be93eed8950d961, base.xf69ca7a9bb4a4a51);
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		xddc60c8d74d0f01b.x6210059f049f0d48(writer);
	}
}
