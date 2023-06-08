using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal class x5dec0ee4f92a55e8 : Field, x6ed66b5cf8da2955
{
	internal int x32dcc9d3ca30726c
	{
		get
		{
			string text = base.xb452e2ee706d7a67.x642e37025c67edab(0);
			int num = xca004f56614e2431.x912616ee70b2d94d(text);
			if (num != int.MinValue)
			{
				return num;
			}
			if (text.StartsWith("0x") || text.StartsWith("0X"))
			{
				return xca004f56614e2431.xadcf75bfc0bf31e3(text.Substring(2));
			}
			return 0;
		}
	}

	private bool x4fec18a85168c2f8 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\f");

	internal string x707c2bded9e130c2 => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\f");

	private bool xd8bf23c9c99b8caf => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\s");

	internal double x70c328f6f2e77d76
	{
		get
		{
			double num = xca004f56614e2431.xf5ece46c5d72e3b9(base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\s"));
			if (!double.IsNaN(num))
			{
				return num;
			}
			return x4574ea26106f0edb.x4610495f80b4c267(base.x2c8c6741422a1298.Styles.x27096df7ca0cfe2e.x437e3b626c0fdd43);
		}
	}

	internal bool x1b8c4020bd5474d5 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\a");

	internal bool x75b732ba9b2cd574 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\u");

	internal bool xfb3d030cd7377a97 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\j");

	internal bool xa41a9b4948a041a6 => !base.xb452e2ee706d7a67.xcc2d426b867d703d("\\h");

	internal override x7e263f21a73a027a x1c428e55430b2acc()
	{
		Run run = new Run(base.x2c8c6741422a1298, x243e311c3569636d());
		if (x4fec18a85168c2f8 && x0d299f323d241756.x5959bccb67bbf051(x707c2bded9e130c2))
		{
			run.Font.Name = x707c2bded9e130c2;
		}
		if (xd8bf23c9c99b8caf)
		{
			run.Font.Size = x70c328f6f2e77d76;
		}
		return new x7e263f21a73a027a(run, run);
	}

	private string x243e311c3569636d()
	{
		if (x1b8c4020bd5474d5 && x32dcc9d3ca30726c > 255)
		{
			return "###";
		}
		return ((char)x32dcc9d3ca30726c).ToString();
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\a":
		case "\\j":
		case "\\h":
		case "\\u":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		case "\\f":
		case "\\s":
			return x9f6b815e19fa8f62.x47e3e032f7bd5d28;
		default:
			return x9f6b815e19fa8f62.xf6c17f648b65c793;
		}
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}
}
