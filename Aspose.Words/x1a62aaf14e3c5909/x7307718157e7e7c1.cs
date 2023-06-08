using System.IO;
using System.Text;
using x6c95d9cf46ff5f25;

namespace x1a62aaf14e3c5909;

internal class x7307718157e7e7c1 : xddf6304144fd3863
{
	private readonly xa5a62ee5bc98c41e x66cd11f407255d70 = new xa5a62ee5bc98c41e();

	internal xa5a62ee5bc98c41e x4e35c79189b28e26 => x66cd11f407255d70;

	internal x7307718157e7e7c1()
		: this(isExtendedOptions: false)
	{
	}

	internal x7307718157e7e7c1(bool isExtendedOptions)
		: base(isExtendedOptions ? x773fe540042dad03.xb80a65a936e596c7 : x773fe540042dad03.x25010a8486e00671, 3)
	{
	}

	protected override void DoRead(BinaryReader reader)
	{
		x66cd11f407255d70.xa9d636b00ff486b7();
		x66cd11f407255d70.x06b0e25aa6ad68a9(reader, base.x1ea60bde2b5d0d28.x9834ddb0e0bd5996, base.xf69ca7a9bb4a4a51);
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		base.x1ea60bde2b5d0d28.x9834ddb0e0bd5996 = x66cd11f407255d70.xd44988f225497f3a;
		x66cd11f407255d70.x6210059f049f0d48(writer);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(base.ToString());
		stringBuilder.Append("\r\n");
		for (int i = 0; i < x66cd11f407255d70.xd44988f225497f3a; i++)
		{
			xef8fbb0f103c0bb1 xef8fbb0f103c0bb2 = (xef8fbb0f103c0bb1)((x09ce2c02826e31a6)x66cd11f407255d70).get_xe6d4b1b411ed94b5(x66cd11f407255d70.xf15263674eb297bb(i));
			stringBuilder.AppendFormat("  0x{0:x4}:0x{1:x}, {2}", xef8fbb0f103c0bb2.xea1e81378298fa81, xef8fbb0f103c0bb2.x9a1915e0a5a745b7, xef8fbb0f103c0bb2.x74a7f36e76358cb5 ? "complex" : "simple");
			switch (xef8fbb0f103c0bb2.xea1e81378298fa81)
			{
			case 831:
				stringBuilder.AppendFormat(" ({0})", (xc3631055b59bd42a)xef8fbb0f103c0bb2.x9a1915e0a5a745b7);
				break;
			case 959:
				stringBuilder.AppendFormat(" ({0})", (xc7100d9eaf633c2e)xef8fbb0f103c0bb2.x9a1915e0a5a745b7);
				break;
			case 511:
				stringBuilder.AppendFormat(" ({0})", (x667c1793394d266a)xef8fbb0f103c0bb2.x9a1915e0a5a745b7);
				break;
			}
			stringBuilder.Append("\r\n");
		}
		return stringBuilder.ToString();
	}
}
