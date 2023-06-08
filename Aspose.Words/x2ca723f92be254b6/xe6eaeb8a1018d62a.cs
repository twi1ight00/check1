using System;
using System.IO;
using x09d959ca29199776;
using x49d934946ca8bab8;
using x6c95d9cf46ff5f25;

namespace x2ca723f92be254b6;

internal class xe6eaeb8a1018d62a
{
	public static byte[] xf76803be5e9ee2aa(byte[] x4a3f0a05c02f235f)
	{
		using MemoryStream memoryStream = new MemoryStream(x4a3f0a05c02f235f);
		xa8866d7566da0aa2 xa8866d7566da0aa = new xa8866d7566da0aa2(memoryStream);
		short num = xa8866d7566da0aa.x672ed37ee25c078c();
		if (num != 3)
		{
			throw new InvalidOperationException("Unsupported MTX version.");
		}
		xa8866d7566da0aa.x5b77aaf600f3aee7();
		int num2 = xa8866d7566da0aa.x5b77aaf600f3aee7();
		int num3 = xa8866d7566da0aa.x5b77aaf600f3aee7();
		if (num2 > num3 || num3 >= x4a3f0a05c02f235f.Length)
		{
			throw new InvalidOperationException("The MTX data is not valid.");
		}
		byte[] x1fcfa035bd2b2edc = xfb5add3858def3a0.x239fffc1037a80f3(xa8866d7566da0aa.x0f6807cca84a8e5b(num2 - (int)memoryStream.Position));
		byte[] xe65822bb53be = xfb5add3858def3a0.x239fffc1037a80f3(xa8866d7566da0aa.x0f6807cca84a8e5b(num3 - (int)memoryStream.Position));
		byte[] xad086f0b0726868e = xfb5add3858def3a0.x239fffc1037a80f3(xa8866d7566da0aa.x0f6807cca84a8e5b(x4a3f0a05c02f235f.Length - (int)memoryStream.Position));
		return x9bb9c5cf3f0a03f5.xf76803be5e9ee2aa(x1fcfa035bd2b2edc, xe65822bb53be, xad086f0b0726868e);
	}
}
