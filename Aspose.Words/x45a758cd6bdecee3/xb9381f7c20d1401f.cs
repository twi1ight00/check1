using System;
using System.IO;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace x45a758cd6bdecee3;

internal class xb9381f7c20d1401f
{
	private readonly xa8866d7566da0aa2 x7450cc1e48712286;

	private xf2e052cd3abef6d7 x1b927fb4449da3ff;

	private xd345c73dd1b16b74 xedd0ebd9c11915f4;

	public xa8866d7566da0aa2 x7468be44f5498f9f => x7450cc1e48712286;

	public Stream x9e418ad9a56d1cf5 => x7450cc1e48712286.x9e418ad9a56d1cf5;

	public xf2e052cd3abef6d7 xc3be943b246eeabb => x1b927fb4449da3ff;

	public xd345c73dd1b16b74 x5eab864c00224c02 => xedd0ebd9c11915f4;

	public xb9381f7c20d1401f(xa8866d7566da0aa2 reader)
	{
		x7450cc1e48712286 = reader;
	}

	public xb9381f7c20d1401f(Stream stream)
	{
		x7450cc1e48712286 = new xa8866d7566da0aa2(stream);
	}

	public void x43325fdd19b94194()
	{
		if (!x4c69b151997c4a03())
		{
			throw new InvalidOperationException("The sfnt file is not valid.");
		}
	}

	public bool x4c69b151997c4a03()
	{
		x1b927fb4449da3ff = xf2e052cd3abef6d7.x06b0e25aa6ad68a9(x7450cc1e48712286);
		if (!xc3be943b246eeabb.x22ab5dfa6f12e902)
		{
			return false;
		}
		xedd0ebd9c11915f4 = new xd345c73dd1b16b74();
		for (int i = 0; i < xc3be943b246eeabb.x444aa5ad583fb445; i++)
		{
			x1d5a785c8d5b14ee x1d5a785c8d5b14ee2 = x1d5a785c8d5b14ee.x06b0e25aa6ad68a9(x7450cc1e48712286);
			x5eab864c00224c02.Add(x1d5a785c8d5b14ee2.xd229d86af0f16fb0, x1d5a785c8d5b14ee2);
		}
		return true;
	}

	public void x98741c31b7c91763(string x6cefb4997d5d0dba)
	{
		x1d5a785c8d5b14ee x1d5a785c8d5b14ee2 = (x1d5a785c8d5b14ee)xedd0ebd9c11915f4[x6cefb4997d5d0dba];
		if (x1d5a785c8d5b14ee2 == null)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mfkfhhbgbiigohpgmhghohnhhceikglikgcjmgjjpfakibhkjgokdfflbfmlifdmoekmgabnkainlfpnnagohfnoopdpepkpkdcamdjalopamdhbncobhcfcpnlcccddickdecbehcieanoedbgfdbnfdbegjalgpmbh", 1060526617)), x6cefb4997d5d0dba));
		}
		x7450cc1e48712286.x9e418ad9a56d1cf5.Position = x1d5a785c8d5b14ee2.xf1d9b91c9700c401;
	}

	public byte[] xed7d554f6c638fb0(string x6cefb4997d5d0dba)
	{
		x98741c31b7c91763(x6cefb4997d5d0dba);
		x1d5a785c8d5b14ee x1d5a785c8d5b14ee2 = (x1d5a785c8d5b14ee)xedd0ebd9c11915f4[x6cefb4997d5d0dba];
		return x7450cc1e48712286.x0f6807cca84a8e5b((int)x1d5a785c8d5b14ee2.x1be93eed8950d961);
	}
}
