using System.Collections;
using System.IO;
using System.Text;
using Aspose;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;

namespace x9e260ffa1ac41ffa;

internal abstract class x25732282434cea28
{
	private const int x8de900e319821f2f = 512;

	private Hashtable xe14b235350c05dea;

	private xc9072e4c3fa520ad xe83fbae1e983d207;

	private MemoryStream xcf18e5243f8d5fd3;

	private BinaryWriter xbdfb620b7167944b;

	private int x0a5d5ed14b1fd88b;

	internal int x42e6c5d8cfec25f7 => x0a5d5ed14b1fd88b - xe83fbae1e983d207.x437e3b626c0fdd43;

	[JavaThrows(false)]
	internal x25732282434cea28(int plcfStructureSize)
	{
		xe14b235350c05dea = new Hashtable();
		xe83fbae1e983d207 = new xc9072e4c3fa520ad(plcfStructureSize);
		xcf18e5243f8d5fd3 = new MemoryStream(512);
		xbdfb620b7167944b = new BinaryWriter(xcf18e5243f8d5fd3, Encoding.Unicode);
		x0a5d5ed14b1fd88b = 510;
	}

	internal bool xd6b6ed77479ef68c(int xb55016094f0bf0bc, int x4919a826cd6fa1bd, x71d23a26ce0a5b23 x6eb3757a94e174fc)
	{
		int num = 0;
		int hashCode = x6eb3757a94e174fc.GetHashCode();
		if (xe14b235350c05dea.Contains(hashCode))
		{
			if (!x19b0863121f8af0f(0))
			{
				return false;
			}
			num = (int)xe14b235350c05dea[hashCode];
		}
		else
		{
			int num2 = x6eb3757a94e174fc.x1deebb03a3d03a50(x0381b6dfdcc2d7b9: true);
			if (x0d299f323d241756.x7e32f71c3f39b6bc(num2))
			{
				num2++;
			}
			if (!x19b0863121f8af0f(num2))
			{
				return false;
			}
			if (num2 > 0)
			{
				x0a5d5ed14b1fd88b -= num2;
				xcf18e5243f8d5fd3.Seek(x0a5d5ed14b1fd88b, SeekOrigin.Begin);
				x6eb3757a94e174fc.x6210059f049f0d48(xbdfb620b7167944b, x0381b6dfdcc2d7b9: true);
				num = x0a5d5ed14b1fd88b / 2;
				xe14b235350c05dea[hashCode] = num;
			}
		}
		xe83fbae1e983d207.xd6b6ed77479ef68c(xb55016094f0bf0bc, x4919a826cd6fa1bd, NewStructure(num));
		return true;
	}

	internal x65018335ce75ca44 x3351d447ab90c1ad()
	{
		xcf18e5243f8d5fd3.Seek(0L, SeekOrigin.Begin);
		xe83fbae1e983d207.x6210059f049f0d48(xbdfb620b7167944b);
		xcf18e5243f8d5fd3.Seek(511L, SeekOrigin.Begin);
		xbdfb620b7167944b.Write((byte)xe83fbae1e983d207.x23719734cf1f138c);
		return new x65018335ce75ca44(xe83fbae1e983d207.x0bcabe1c3230f8a6, xe83fbae1e983d207.xe7417f6a11716af5, xcf18e5243f8d5fd3.ToArray());
	}

	private bool x19b0863121f8af0f(int x8eefd06b250b0310)
	{
		return x42e6c5d8cfec25f7 >= xe83fbae1e983d207.x6ba3a6a074ca1119 + x8eefd06b250b0310;
	}

	protected abstract object NewStructure(int lastPXWordOffset);
}
