using System;
using Aspose;
using x13f1efc79617a47b;

namespace x4f4df92b75ba3b67;

internal abstract class x264ba3b7aca691be
{
	protected x4882ae789be6e2ef x8cedcaa9a62c6e39;

	protected string x46b079bd0553f90a;

	private readonly int x60adf410a9cceab0;

	internal x4882ae789be6e2ef x28fcdc775a1d069c => x8cedcaa9a62c6e39;

	internal int xea1e81378298fa81 => x60adf410a9cceab0;

	internal string x899a2110a8a35fda => $"{x60adf410a9cceab0} 0 R";

	internal bool x53d700f231bd7063 => x41c71fb0a8629935 != x3499f937de5622bc.x4d0b9d4447ba7566;

	internal string xd160355ae2167ae9 => x46b079bd0553f90a;

	internal virtual x3499f937de5622bc x41c71fb0a8629935 => x3499f937de5622bc.x4d0b9d4447ba7566;

	protected x264ba3b7aca691be(x4882ae789be6e2ef context)
	{
		x8cedcaa9a62c6e39 = context;
		x60adf410a9cceab0 = context.x6bdb5f9a7aff5750();
		if (x53d700f231bd7063)
		{
			x46b079bd0553f90a = GenerateResourceName();
		}
	}

	[JavaThrows(true)]
	public abstract void WriteToPdf(x4f40d990d5bf81a6 writer);

	protected virtual string GenerateResourceName()
	{
		if (!x53d700f231bd7063)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jhoeejffiimfbidgnhkggdbhhiihphphncgibhnimgejchljggckahjkmfalmghlkfolcbfmafmmmadnlfknlebogfiopepocfgpmenpkdeajdlabpbbmdjbmcacfdhckcoccoedncmdlcdenckegnaffbiffbpfgbggibngoaehemkhcacioliinaajnpgjiaojbafkeamkopclmojlloamblhm", 1798065701)));
		}
		if (x46b079bd0553f90a != null)
		{
			return x46b079bd0553f90a;
		}
		return $"{xe21bbe9dfab6c4dd.x096d740b861b7ce8(x41c71fb0a8629935)}{x8cedcaa9a62c6e39.x2107de3fc2a21893.x7029e474053b751e(x41c71fb0a8629935) + 1}";
	}

	protected x5babd393421dd91d xbfbb1719d4106af2()
	{
		if (!x8cedcaa9a62c6e39.x73979cef1002ed01.xa4167addc9c6947c)
		{
			return null;
		}
		return x8cedcaa9a62c6e39.xf3b73fb11ed05856.xbfbb1719d4106af2(xea1e81378298fa81, 0);
	}
}
