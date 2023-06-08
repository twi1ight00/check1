using System.IO;

namespace ns238;

internal class Class6584 : Class6568
{
	private long long_0;

	public Class6584(Class6567 context)
		: base(context)
	{
	}

	public void method_0()
	{
		long_0 = base.Writer.BaseWriter.BaseStream.Position;
		base.Writer.method_0(new byte[6]);
	}

	public void method_1(Enum878 tagType)
	{
		int tagLength = (int)(base.Writer.BaseWriter.BaseStream.Position - long_0 - 6L);
		base.Writer.BaseWriter.Seek((int)long_0, SeekOrigin.Begin);
		base.Writer.method_16(tagType, tagLength);
		base.Writer.BaseWriter.Seek(0, SeekOrigin.End);
	}
}
