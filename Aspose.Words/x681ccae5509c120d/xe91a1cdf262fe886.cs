using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using Aspose.Words;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;

namespace x681ccae5509c120d;

internal class xe91a1cdf262fe886
{
	private readonly Hashtable x1f08039b1b7da5a7;

	private readonly Hashtable x1ca1902f30d576bc;

	private readonly xeaa001c8a56a5789 x71f8ed3cdd081d7b = new xeaa001c8a56a5789();

	private readonly x3368fdcc844084ff x6a7ade73ceba95b5 = new x3368fdcc844084ff();

	private readonly StringCollection xcd7a948cd6d6f316 = new StringCollection();

	private readonly xe8da7f5fa0796e15 xda0fdd6f2fc34038 = new xe8da7f5fa0796e15();

	private readonly xc9072e4c3fa520ad x800bbc9a12733e59 = new xc9072e4c3fa520ad(0);

	private readonly x38fe1b2a1bc6e0a4 xf194262df1c8e5b7 = new x38fe1b2a1bc6e0a4();

	internal xeaa001c8a56a5789 xeaa001c8a56a5789 => x71f8ed3cdd081d7b;

	internal x3368fdcc844084ff x3368fdcc844084ff => x6a7ade73ceba95b5;

	internal xe8da7f5fa0796e15 x1213e861660862e7 => xda0fdd6f2fc34038;

	internal xc9072e4c3fa520ad x8a4e50b3272d2d52 => x800bbc9a12733e59;

	internal xe91a1cdf262fe886()
	{
		x1ca1902f30d576bc = new Hashtable();
	}

	internal xe91a1cdf262fe886(x8aeace2bf92692ab fib, BinaryReader tableStreamReader)
	{
		x1f08039b1b7da5a7 = new Hashtable();
		tableStreamReader.BaseStream.Position = fib.x955a03f821588c52.x019087940edc5b16.xe53f0e68147463d1;
		int num = fib.x955a03f821588c52.x019087940edc5b16.xe53f0e68147463d1 + fib.x955a03f821588c52.x019087940edc5b16.x04c290dc4d04369c;
		while (tableStreamReader.BaseStream.Position < num)
		{
			xcd7a948cd6d6f316.Add(x93b05c1ad709a695.x602d3c3fbfa56f51(tableStreamReader, x5be1cad1d00af914: true, xac1baf51b3e43d13: false));
		}
		x71f8ed3cdd081d7b.x06b0e25aa6ad68a9(tableStreamReader, fib.x955a03f821588c52.xbf634e8b648e59e9);
		x71f8ed3cdd081d7b.x5f571ea8c74d391b(tableStreamReader, fib.x4605e55a1901024b.xf47a1df27ae60301.xe53f0e68147463d1, fib.x4605e55a1901024b.xf47a1df27ae60301.x04c290dc4d04369c);
		x6a7ade73ceba95b5.x06b0e25aa6ad68a9(tableStreamReader, fib.x955a03f821588c52.xe90a0c88d34c1da8);
		xda0fdd6f2fc34038.x06b0e25aa6ad68a9(tableStreamReader, fib.x955a03f821588c52.x024d2f39765ee510);
		x800bbc9a12733e59.x06b0e25aa6ad68a9(tableStreamReader, fib.x955a03f821588c52.xd2c137c21ca682a3);
		xf194262df1c8e5b7.x06b0e25aa6ad68a9(tableStreamReader, fib.x955a03f821588c52.x38fe1b2a1bc6e0a4.xe53f0e68147463d1, fib.x955a03f821588c52.x38fe1b2a1bc6e0a4.x04c290dc4d04369c);
		x3a063252ba665245(xda0fdd6f2fc34038);
		x3a063252ba665245(x800bbc9a12733e59);
		x671b78dd61605a75();
	}

	private static void x3a063252ba665245(x6fa6e31d93cf837a xe83fbae1e983d207)
	{
		if (xe83fbae1e983d207.x82b0eb36012eef83 > 0)
		{
			xe83fbae1e983d207.xe7417f6a11716af5 = int.MaxValue;
		}
	}

	private void x671b78dd61605a75()
	{
		for (int i = 0; i < xda0fdd6f2fc34038.x23719734cf1f138c; i++)
		{
			xe97005d9cb85f5b7 xe97005d9cb85f5b8 = (xe97005d9cb85f5b7)xda0fdd6f2fc34038.xe84e6ff66aac2a0e(i);
			x1f08039b1b7da5a7[xe97005d9cb85f5b8.xff616fa638fdd6e3] = i;
		}
	}

	internal void x6210059f049f0d48(x8aeace2bf92692ab xf0c8411938a86cbf, BinaryWriter xfd86a6b02a8cb849)
	{
		xf0c8411938a86cbf.x955a03f821588c52.x019087940edc5b16.xe53f0e68147463d1 = (int)xfd86a6b02a8cb849.BaseStream.Position;
		StringEnumerator enumerator = xcd7a948cd6d6f316.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				x93b05c1ad709a695.x4a3c44ae9b1cf5ab(current, 55, xfd86a6b02a8cb849, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		xf0c8411938a86cbf.x955a03f821588c52.x019087940edc5b16.x04c290dc4d04369c = (int)xfd86a6b02a8cb849.BaseStream.Position - xf0c8411938a86cbf.x955a03f821588c52.x019087940edc5b16.xe53f0e68147463d1;
		xf0c8411938a86cbf.x955a03f821588c52.xbf634e8b648e59e9.xe53f0e68147463d1 = (int)xfd86a6b02a8cb849.BaseStream.Position;
		xf0c8411938a86cbf.x955a03f821588c52.xbf634e8b648e59e9.x04c290dc4d04369c = x71f8ed3cdd081d7b.x6210059f049f0d48(xfd86a6b02a8cb849);
		xf0c8411938a86cbf.x4605e55a1901024b.xf47a1df27ae60301.xe53f0e68147463d1 = (int)xfd86a6b02a8cb849.BaseStream.Position;
		xf0c8411938a86cbf.x4605e55a1901024b.xf47a1df27ae60301.x04c290dc4d04369c = x71f8ed3cdd081d7b.xbab4a8354252fa3b(xfd86a6b02a8cb849);
		xf0c8411938a86cbf.x955a03f821588c52.xe90a0c88d34c1da8.xe53f0e68147463d1 = (int)xfd86a6b02a8cb849.BaseStream.Position;
		xf0c8411938a86cbf.x955a03f821588c52.xe90a0c88d34c1da8.x04c290dc4d04369c = x6a7ade73ceba95b5.x6210059f049f0d48(xfd86a6b02a8cb849);
		x952ed1807f2c1ffe();
		xf0c8411938a86cbf.x955a03f821588c52.x024d2f39765ee510.xe53f0e68147463d1 = (int)xfd86a6b02a8cb849.BaseStream.Position;
		xf0c8411938a86cbf.x955a03f821588c52.x024d2f39765ee510.x04c290dc4d04369c = xda0fdd6f2fc34038.x6210059f049f0d48(xfd86a6b02a8cb849);
		xf0c8411938a86cbf.x955a03f821588c52.xd2c137c21ca682a3.xe53f0e68147463d1 = (int)xfd86a6b02a8cb849.BaseStream.Position;
		xf0c8411938a86cbf.x955a03f821588c52.xd2c137c21ca682a3.x04c290dc4d04369c = x800bbc9a12733e59.x6210059f049f0d48(xfd86a6b02a8cb849);
		xf0c8411938a86cbf.x955a03f821588c52.x38fe1b2a1bc6e0a4.xe53f0e68147463d1 = (int)xfd86a6b02a8cb849.BaseStream.Position;
		xf0c8411938a86cbf.x955a03f821588c52.x38fe1b2a1bc6e0a4.x04c290dc4d04369c = xf194262df1c8e5b7.x6210059f049f0d48(xfd86a6b02a8cb849);
	}

	private void x952ed1807f2c1ffe()
	{
		for (int i = 0; i < xda0fdd6f2fc34038.x23719734cf1f138c; i++)
		{
			xe97005d9cb85f5b7 xe97005d9cb85f5b8 = (xe97005d9cb85f5b7)xda0fdd6f2fc34038.xe84e6ff66aac2a0e(i);
			xe97005d9cb85f5b8.xff616fa638fdd6e3 = (int)x1ca1902f30d576bc[x87d755c77d5e879a(i)];
		}
	}

	internal string x1f819cfa8567ddba(int xc0c4c459c6ccbd00)
	{
		if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 >= xcd7a948cd6d6f316.Count)
		{
			return "";
		}
		return xcd7a948cd6d6f316[xc0c4c459c6ccbd00];
	}

	internal void xc33ad5bca70a78bb(int x18d1054d82981887, Comment x77c5a31ec0891f38)
	{
		xca838b0f1d157cd8 xca838b0f1d157cd9 = new xca838b0f1d157cd8();
		xca838b0f1d157cd9.x660adf533ba4edef = x77c5a31ec0891f38.Initial;
		xca838b0f1d157cd9.x242851e6278ed355 = x77c5a31ec0891f38.DateTime;
		xca838b0f1d157cd9.x57653a46aad8df6a = xcd7a948cd6d6f316.IndexOf(x77c5a31ec0891f38.Author);
		if (xca838b0f1d157cd9.x57653a46aad8df6a < 0)
		{
			xca838b0f1d157cd9.x57653a46aad8df6a = xcd7a948cd6d6f316.Count;
			xcd7a948cd6d6f316.Add(x77c5a31ec0891f38.Author);
		}
		xca838b0f1d157cd9.x745c3a5e8101c8d9 = (x77c5a31ec0891f38.xad2b66edfff52038 ? x77c5a31ec0891f38.Id : (-1));
		x71f8ed3cdd081d7b.xd6b6ed77479ef68c(x18d1054d82981887, xca838b0f1d157cd9);
	}

	internal void x997a4489160115e0(int x18d1054d82981887)
	{
		x6a7ade73ceba95b5.xd6b6ed77479ef68c(x18d1054d82981887, null);
	}

	internal void x32c21433b443e338(int x18d1054d82981887)
	{
		x6a7ade73ceba95b5.xd6b6ed77479ef68c(x18d1054d82981887);
	}

	internal void x97cec16df8d915d2(int x18d1054d82981887, int xeaf1b27180c0557b)
	{
		xda0fdd6f2fc34038.xd6b6ed77479ef68c(x18d1054d82981887, new xe97005d9cb85f5b7());
		xf194262df1c8e5b7.xd6b6ed77479ef68c(xeaf1b27180c0557b);
	}

	internal void x3db79c2fd9382b7b(int x18d1054d82981887, int xeaf1b27180c0557b)
	{
		int num = x800bbc9a12733e59.xd6b6ed77479ef68c(x18d1054d82981887, null);
		x1ca1902f30d576bc[xeaf1b27180c0557b] = num;
	}

	internal int x87d755c77d5e879a(int xd4f974c06ffa392b)
	{
		return xf194262df1c8e5b7.get_xe6d4b1b411ed94b5(xd4f974c06ffa392b);
	}

	internal int xc0817640be82e250(int x4fc5a88ee8968c44)
	{
		return x87d755c77d5e879a((int)x1f08039b1b7da5a7[x4fc5a88ee8968c44]);
	}
}
