using System.Diagnostics;
using System.IO;
using System.Text;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace xb92b7270f78a4e8d;

internal class x4b3117edb6fb43b5 : x022e9ea87bd0a4c7
{
	private readonly Stream xa49cef274042e702;

	private readonly x1ea60bde2b5d0d28 xf49591a44359232f;

	internal x4b3117edb6fb43b5(Stream stream, x1ea60bde2b5d0d28 header)
	{
		xa49cef274042e702 = stream;
		xf49591a44359232f = header;
	}

	internal void x06b0e25aa6ad68a9()
	{
		x022e9ea87bd0a4c7 x022e9ea87bd0a4c8 = xf143ea72badff319.x06b0e25aa6ad68a9(xa49cef274042e702, xf49591a44359232f.xa8cfe0f15be4bf6f, xf49591a44359232f.xa488c50953a4b64c, xf49591a44359232f.xed20a3f26053569b);
		byte[] buffer = new byte[512];
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(buffer), Encoding.Unicode);
		for (uint num = 0u; num < xf49591a44359232f.xa8cfe0f15be4bf6f; num++)
		{
			xa49cef274042e702.Position = x4952846e23c21e88.x29cc5da3d9d1b58a(x022e9ea87bd0a4c8.get_xe6d4b1b411ed94b5(num), x0a996d99793b1739: true);
			xa49cef274042e702.Read(buffer, 0, 512);
			binaryReader.BaseStream.Position = 0L;
			for (int i = 0; i < 128; i++)
			{
				xd6b6ed77479ef68c(binaryReader.ReadUInt32());
			}
		}
	}

	[Conditional("DEBUG")]
	internal void xc857bd91ddeda162()
	{
		using StreamWriter streamWriter = new StreamWriter(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dkmagjdbflkbombcbiicmlpcmlgdblnd", 812321887)));
		for (uint num = 0u; num < base.xd44988f225497f3a; num++)
		{
			streamWriter.WriteLine($"{num} {base.get_xe6d4b1b411ed94b5(num)} 0x{base.get_xe6d4b1b411ed94b5(num):X8}");
		}
	}

	internal void x6210059f049f0d48()
	{
		MemoryStream memoryStream = x0fe354a7e0ea7cc1();
		BinaryWriter binaryWriter = new BinaryWriter(xa49cef274042e702, Encoding.Unicode);
		uint x6fef33b4fb431a = x4952846e23c21e88.x2ef840043f42e207(xa49cef274042e702.Position, x0a996d99793b1739: true);
		int num = base.xd44988f225497f3a;
		int num2 = x0d299f323d241756.xc82acf77a8e0e053(num, 128);
		num2 = x0d299f323d241756.xc82acf77a8e0e053(num + num2, 128);
		xa49cef274042e702.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
		for (int i = 0; i < num2; i++)
		{
			binaryWriter.Write(4294967293u);
		}
		int num3 = x0d299f323d241756.xc82acf77a8e0e053(num + num2, 128);
		if (num3 > 109)
		{
			int num4 = x0d299f323d241756.xc82acf77a8e0e053(num3 - 109, 127);
			for (int j = 0; j < num4; j++)
			{
				binaryWriter.Write(4294967293u);
			}
			for (int k = 0; k < num4; k++)
			{
				binaryWriter.Write(4294967292u);
			}
			num3 = x0d299f323d241756.xc82acf77a8e0e053(num + num2 + num4, 128);
		}
		xf49591a44359232f.xa8cfe0f15be4bf6f = num3;
		x4952846e23c21e88.xdd43f3d19173b660(binaryWriter);
		xf143ea72badff319.x6210059f049f0d48(xa49cef274042e702, x6fef33b4fb431a, num3, xf49591a44359232f);
	}
}
