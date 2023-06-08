using System;
using Aspose.Words;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;

namespace x639ad3f66698fe1b;

internal class xb1e88b85b354fc81
{
	private x21f0d20d41203be1 x8cedcaa9a62c6e39;

	internal void x6210059f049f0d48(x21f0d20d41203be1 x0f7b23d1c393aed9)
	{
		x8cedcaa9a62c6e39 = x0f7b23d1c393aed9;
		x8cedcaa9a62c6e39.xe1410f585439c7d4.x25d0efbd7848eeb3();
		x8cedcaa9a62c6e39.xe1410f585439c7d4.xee60bff2900a72f2("\\stylesheet");
		StyleCollection styles = x0f7b23d1c393aed9.x2c8c6741422a1298.Styles;
		for (int i = 0; i < styles.Count; i++)
		{
			Style style = styles[i];
			if (style.Type != StyleType.List && style.x8301ab10c226b0c2 != 12 && style.x8301ab10c226b0c2 != 11)
			{
				x8cedcaa9a62c6e39.xe1410f585439c7d4.x25d0efbd7848eeb3();
				x8cedcaa9a62c6e39.xe1410f585439c7d4.xa07aa514e9082b3a();
				x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913(x7f2e57314061ca55(style.Type), style.x8301ab10c226b0c2);
				if (style.Type == StyleType.Character)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\additive");
				}
				if (style.xe709b224f455b863 != 4095 && style.xe709b224f455b863 != 12 && style.xe709b224f455b863 != 11)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\sbasedon", style.xe709b224f455b863);
				}
				if (style.Type == StyleType.Paragraph && style.xfb77c9ea054ac31c != 4095)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\snext", style.xfb77c9ea054ac31c);
				}
				if (style.x913ff5916b187824)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\sautoupd");
				}
				if (style.x96e55b5d052d1279)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\shidden");
				}
				if (style.x4cf1854ef833220f != 4095)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\slink", style.x4cf1854ef833220f);
				}
				if (style.x2d8aaa05bddcf40c)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\slocked");
				}
				if (style.xdf3672ec434b4524)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\spersonal");
				}
				if (style.xde61abbe9514a1ee)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\scompose");
				}
				if (style.x3bbb21ee843f081c)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\sreply");
				}
				if (style.xe12a6bc6d222e782 != 0)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\styrsid", style.xe12a6bc6d222e782);
				}
				if (style.x45101ac87546632f)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\ssemihidden");
				}
				if (style.xebe0f6c7e6f4ae3a)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\sqformat");
				}
				if (style.x9eb07da9aa5bbf9e != 99)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\spriority", style.x9eb07da9aa5bbf9e);
				}
				if (style.x5356a3af7e7ecdfa)
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x4d14ee33f46b5913("\\sunhideused");
				}
				switch (style.Type)
				{
				case StyleType.Character:
					x1ac74001755071a5(style);
					break;
				case StyleType.Paragraph:
					x23c8b7ad9bfc5719(style);
					break;
				case StyleType.Table:
					x746ca66f5c31e314(style);
					break;
				default:
					throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("coclipjlmoammphmbpomdofnonmnmodoknkognbppiippnppnngapnnapmebfmlbnhccomjcanademhdglodmhfe", 309572237)));
				}
				x8cedcaa9a62c6e39.xe1410f585439c7d4.x50f5dc167b3269a7(x72a0c846678ecaf9.x27d6a5b617edc9db(style.StyleIdentifier, style.Name));
				string text = style.Styles.x4c0f9b9b517a1ec4(style, xe9f84f829511a789: false);
				if (x0d299f323d241756.x5959bccb67bbf051(text))
				{
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x50f5dc167b3269a7(",");
					x8cedcaa9a62c6e39.xe1410f585439c7d4.x50f5dc167b3269a7(text);
				}
				x8cedcaa9a62c6e39.xe1410f585439c7d4.x80fb22e7844d1324();
				x8cedcaa9a62c6e39.xe1410f585439c7d4.x4ecc66ceff7a75c0();
			}
		}
		x8cedcaa9a62c6e39.xe1410f585439c7d4.xc8a13a52db0580ae();
		x8cedcaa9a62c6e39.xe1410f585439c7d4.x25d0efbd7848eeb3();
	}

	private void x1ac74001755071a5(Style x44ecfea61c937b8e)
	{
		x8cedcaa9a62c6e39.x6fca94e50472ae68.x6210059f049f0d48(x44ecfea61c937b8e.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226), x00ce61b8358bb4cc: false);
	}

	private void x23c8b7ad9bfc5719(Style x44ecfea61c937b8e)
	{
		x8cedcaa9a62c6e39.x1e8de05c1565effc.x6210059f049f0d48(x44ecfea61c937b8e.x2e12c5f9278ae233(xd9bc7f7e70d71e14.x3968babb3b57e478), x00ce61b8358bb4cc: false, x02cadcecef04989f: false);
		x8cedcaa9a62c6e39.x6fca94e50472ae68.x6210059f049f0d48(x44ecfea61c937b8e.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226), x00ce61b8358bb4cc: false);
	}

	private void x746ca66f5c31e314(Style x44ecfea61c937b8e)
	{
	}

	private static string x7f2e57314061ca55(StyleType x43163d22e8cd5a71)
	{
		return x43163d22e8cd5a71 switch
		{
			StyleType.Character => "\\*\\cs", 
			StyleType.Paragraph => "\\s", 
			StyleType.Table => "\\*\\ts", 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("icmmoddncdkncebohdiojcpoecgpcdnpaceamblafnbbfcjbdcacfchcfboclafddmldebdegbkekabfmphfcmof", 806669267))), 
		};
	}
}
