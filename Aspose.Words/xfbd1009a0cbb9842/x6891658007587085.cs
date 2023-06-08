using System;
using Aspose.Words;
using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal class x6891658007587085 : Field, x6ed66b5cf8da2955
{
	internal string x7ca2c1fcbcdb13cf => base.xb452e2ee706d7a67.x642e37025c67edab(0);

	internal bool xe9753893d2db4b38 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\l");

	internal bool x6d2c00ef98bef83f => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\n");

	internal bool x5bc3f473bf19ef90 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\p");

	internal bool x332a54a20ac3f40f => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\r");

	internal bool xd4939327bb0403a1 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\t");

	internal bool xde16e0db1a9670f5 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\w");

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		x52b190e626f65140(x7d5e2f34b6651bf4.xf8d31d196ccd74c4);
		base.x34a4695711b84f85.x874035a07982e6e7(new xb424217efe68741a(x357c90b33d6bb8e6()), xcf417e2db4fe9ed3.x5a360e1cee7f2c61);
		x72608c670658bf7a x72608c670658bf7a2 = xf8d1065b0c12d495.x177d82d2dbabfc03(base.Start.ParentParagraph, x7ca2c1fcbcdb13cf);
		if (x72608c670658bf7a2 == null)
		{
			return new xd5801a931e010963(this, "Error! No text of specified style in document.");
		}
		if (x6d2c00ef98bef83f)
		{
			string result = x730be1b1b0b78790.x42f7238db039e795(x72608c670658bf7a2.xfdc1a17f479acc42);
			return new xca592a476766b11a(this, result);
		}
		if (x332a54a20ac3f40f)
		{
			string result2 = x730be1b1b0b78790.x2d418f17c2a87afd(x72608c670658bf7a2.xfdc1a17f479acc42, base.Start.ParentParagraph);
			return new xca592a476766b11a(this, result2);
		}
		if (xde16e0db1a9670f5)
		{
			string result3 = x730be1b1b0b78790.xd57b1e0d28032d64(x72608c670658bf7a2.xfdc1a17f479acc42);
			return new xca592a476766b11a(this, result3);
		}
		if (x5bc3f473bf19ef90)
		{
			return x72608c670658bf7a2.xdbfa333b4cd503e0 switch
			{
				x0e0a2e0dd6ccd312.xe9634325258d088b => new xca592a476766b11a(this, "above"), 
				x0e0a2e0dd6ccd312.xd4a82970ba6be033 => new xca592a476766b11a(this, "below"), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		x8af883cebd6b8f09(x72608c670658bf7a2);
		return null;
	}

	private void x8af883cebd6b8f09(x72608c670658bf7a x95fd3a760433c561)
	{
		int num = 0;
		int num2 = Math.Min(x95fd3a760433c561.x761445bca289bae4, x95fd3a760433c561.xef557afa150f7cb2);
		int num3 = Math.Max(x95fd3a760433c561.x761445bca289bae4, x95fd3a760433c561.xef557afa150f7cb2);
		for (int i = num2; i <= num3; i++)
		{
			Run run = x95fd3a760433c561.xfdc1a17f479acc42.Runs[i];
			int num4 = num + run.Text.Length - 256;
			if (num4 <= 0)
			{
				Run run2 = (Run)run.Clone(isCloneChildren: false);
				run2.xeedad81aaed42a76.xe80983f2918b2568();
				base.End.ParentNode.InsertBefore(run2, base.End);
				num += run.Text.Length;
				continue;
			}
			Run run3 = run.x4ede2f7ca43a1460(0, run.Text.Length - num4, x1e2b473fecc8c6b6: true);
			run3.xeedad81aaed42a76.xe80983f2918b2568();
			if (run3.Text.Length > 0)
			{
				base.End.ParentNode.InsertBefore(run3, base.End);
			}
			break;
		}
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\l":
		case "\\n":
		case "\\m":
		case "\\p":
		case "\\r":
		case "\\t":
		case "\\w":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
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
