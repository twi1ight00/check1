using System.IO;
using System.Text;
using x13f1efc79617a47b;

namespace x1a62aaf14e3c5909;

internal class x3ed37e433e884f79 : xddf6304144fd3863
{
	private int x1935165c0a17c079;

	private int x03d7d3b1408cc893;

	internal int x65ea8654a7f70de3
	{
		get
		{
			return base.x1ea60bde2b5d0d28.x9834ddb0e0bd5996;
		}
		set
		{
			base.x1ea60bde2b5d0d28.x9834ddb0e0bd5996 = value;
		}
	}

	internal int x45856a8054f10613
	{
		get
		{
			return x1935165c0a17c079;
		}
		set
		{
			x1935165c0a17c079 = value;
		}
	}

	internal int x80a0fbcf860ec6e0
	{
		get
		{
			return x03d7d3b1408cc893;
		}
		set
		{
			x03d7d3b1408cc893 = value;
		}
	}

	internal x3ed37e433e884f79()
		: base(x773fe540042dad03.x91ac32ef4a85c752, 0)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0}\n", base.ToString());
		stringBuilder.AppendFormat(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hkffjlmfpkdgllkgnkbhiiihblphelgikkninkejahljokckagjkkkalgfhlheolhhfmbjmmhidnphknegboghiofipodigpgenpeieahdlandcbifjbkhaceahc", 695489876)), x1935165c0a17c079, x03d7d3b1408cc893);
		return stringBuilder.ToString();
	}

	protected override void DoRead(BinaryReader reader)
	{
		x1935165c0a17c079 = reader.ReadInt32();
		x03d7d3b1408cc893 = reader.ReadInt32();
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		writer.Write(x1935165c0a17c079);
		writer.Write(x03d7d3b1408cc893);
	}
}
