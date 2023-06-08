using System.Collections;
using System.IO;
using System.Text;
using xa604c4d210ae0581;

namespace x650fee20d618512c;

internal class xcb573e59d7de41b0
{
	private BinaryReader x7450cc1e48712286;

	private readonly ArrayList x7836ae0475e423a0 = new ArrayList();

	internal byte[] x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75)
	{
		x7450cc1e48712286 = xe134235b3526fa75;
		int num = (int)x7450cc1e48712286.BaseStream.Position;
		xa2f7ab34efed664f();
		int count = (int)x7450cc1e48712286.BaseStream.Position - num;
		x7450cc1e48712286.BaseStream.Position = num;
		byte[] array = x7450cc1e48712286.ReadBytes(count);
		x2df0ba9983f47cd6(array, num, 0);
		return array;
	}

	internal byte[] x9b103d78bb2b3bb6(byte[] x4a3f0a05c02f235f, int x4f2c773c5f53ec5d)
	{
		if (x4a3f0a05c02f235f == null || x4a3f0a05c02f235f.Length == 0)
		{
			return null;
		}
		x7450cc1e48712286 = new BinaryReader(new MemoryStream(x4a3f0a05c02f235f));
		xa2f7ab34efed664f();
		byte[] array = new byte[x4a3f0a05c02f235f.Length];
		for (int i = 0; i < x4a3f0a05c02f235f.Length; i++)
		{
			array[i] = x4a3f0a05c02f235f[i];
		}
		x2df0ba9983f47cd6(array, 0, x4f2c773c5f53ec5d);
		return array;
	}

	private void x2df0ba9983f47cd6(byte[] x4a3f0a05c02f235f, int xe4d2cb8d5fcc4f79, int x4f2c773c5f53ec5d)
	{
		if (x7836ae0475e423a0.Count == 0)
		{
			return;
		}
		MemoryStream memoryStream = new MemoryStream(x4a3f0a05c02f235f);
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		foreach (int item in x7836ae0475e423a0)
		{
			int num2 = item - xe4d2cb8d5fcc4f79;
			binaryReader.BaseStream.Position = num2;
			int num3 = binaryReader.ReadInt32();
			int value = num3 - xe4d2cb8d5fcc4f79 + x4f2c773c5f53ec5d;
			binaryReader.BaseStream.Position = num2;
			binaryWriter.Write(value);
		}
	}

	private void xa2f7ab34efed664f()
	{
		x7450cc1e48712286.ReadByte();
		x7450cc1e48712286.ReadInt16();
		x7450cc1e48712286.ReadByte();
		x7450cc1e48712286.ReadInt16();
		x7450cc1e48712286.ReadInt16();
		x7450cc1e48712286.ReadInt16();
		int num = x7450cc1e48712286.ReadInt16();
		int count = x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadBytes(count);
		for (int i = 0; i < num; i++)
		{
			x45310c0802f409eb();
		}
	}

	private void x45310c0802f409eb()
	{
		int num = x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadInt16();
		int num2 = x7450cc1e48712286.ReadInt16();
		if (num == 0)
		{
			x765cef35d67766a1();
			return;
		}
		for (int i = 0; i < num2; i++)
		{
			x141625dc4fbd8678();
		}
	}

	private void x141625dc4fbd8678()
	{
		x7450cc1e48712286.ReadByte();
		x7450cc1e48712286.ReadByte();
		x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadInt32();
		int num = (int)x7450cc1e48712286.BaseStream.Position;
		x7450cc1e48712286.ReadInt32();
		int num2 = x7450cc1e48712286.ReadUInt16();
		x7450cc1e48712286.ReadUInt16();
		if (((uint)num2 & (true ? 1u : 0u)) != 0)
		{
			x7836ae0475e423a0.Add(num);
		}
	}

	private void x765cef35d67766a1()
	{
		x93b05c1ad709a695.x602d3c3fbfa56f51(x7450cc1e48712286, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
		int num = x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadBytes(num - 4);
		int num2 = x7450cc1e48712286.ReadInt32();
		for (int i = 0; i < num2; i++)
		{
			x99aa947b98b1504d();
		}
	}

	private void x99aa947b98b1504d()
	{
		xbe381c99c49e5bb0 xbe381c99c49e5bb = new xbe381c99c49e5bb0(x7450cc1e48712286);
		if (xbe381c99c49e5bb.xe46e0b6a73ca799b != 1 && xbe381c99c49e5bb.xe46e0b6a73ca799b != 4177)
		{
			x7450cc1e48712286.ReadInt32();
		}
		if (xbe381c99c49e5bb.x915ce04b6995076f == xe9b252f3b5f4e1ed.x8c91e9f318e3fe7c)
		{
			return;
		}
		xbe28e0a31c4d0eeb();
		switch (xbe381c99c49e5bb.x915ce04b6995076f)
		{
		case xe9b252f3b5f4e1ed.xd7fe23e9aa2591f6:
		case xe9b252f3b5f4e1ed.x24a034ed29eed855:
			xc80eda5f1e0028bf();
			break;
		case xe9b252f3b5f4e1ed.x4402a69f607144e3:
		case xe9b252f3b5f4e1ed.x5c4d7da392c50927:
		case xe9b252f3b5f4e1ed.xc20a575c11fb4c8b:
		case xe9b252f3b5f4e1ed.x4d2faa0dba529007:
			xc69e2410967b921f();
			break;
		case xe9b252f3b5f4e1ed.x5410a63599038a04:
		case xe9b252f3b5f4e1ed.xca07ebdb4698a889:
		case xe9b252f3b5f4e1ed.xb48012e2ee7ac646:
		case xe9b252f3b5f4e1ed.xdeda5230714eff80:
		case xe9b252f3b5f4e1ed.x42c03b9bdd28e3a9:
		case xe9b252f3b5f4e1ed.xd66e1bb337537aeb:
			if (xbe381c99c49e5bb.xe46e0b6a73ca799b == 1)
			{
				x3de3d032554ad72b();
			}
			break;
		case (xe9b252f3b5f4e1ed)5:
		case xe9b252f3b5f4e1ed.x66818b60c14d3b42:
		case (xe9b252f3b5f4e1ed)8:
		case (xe9b252f3b5f4e1ed)11:
		case xe9b252f3b5f4e1ed.xe9605a4bea014f21:
		case (xe9b252f3b5f4e1ed)17:
		case xe9b252f3b5f4e1ed.x03bb6a33fcd217b4:
		case xe9b252f3b5f4e1ed.xfb1f92890f8bd67b:
			break;
		}
	}

	private void xbe28e0a31c4d0eeb()
	{
		x630e06a8aad6b324 x630e06a8aad6b325 = (x630e06a8aad6b324)x7450cc1e48712286.ReadByte();
		if ((x630e06a8aad6b325 & x630e06a8aad6b324.xeafbb9aa193d2714) != 0)
		{
			x03fc9cf00067adf7();
		}
		if ((x630e06a8aad6b325 & x630e06a8aad6b324.xe13b82ff4d1ba3e1) != 0)
		{
			x03fc9cf00067adf7();
			x03fc9cf00067adf7();
		}
		if ((x630e06a8aad6b325 & x630e06a8aad6b324.x63016ee101821851) != 0)
		{
			xb0ae06c6ff588322();
		}
	}

	private void xb0ae06c6ff588322()
	{
		x03fc9cf00067adf7();
		x7450cc1e48712286.ReadInt32();
		x03fc9cf00067adf7();
		x03fc9cf00067adf7();
		x03fc9cf00067adf7();
		x7450cc1e48712286.ReadByte();
		x7450cc1e48712286.ReadByte();
	}

	private void xc80eda5f1e0028bf()
	{
		x09b8396ffe8165cf x09b8396ffe8165cf2 = (x09b8396ffe8165cf)x7450cc1e48712286.ReadByte();
		if ((x09b8396ffe8165cf2 & x09b8396ffe8165cf.xce5ef0b1439cd073) != 0)
		{
			xff91f2699fb66249();
			xff91f2699fb66249();
		}
		if ((x09b8396ffe8165cf2 & x09b8396ffe8165cf.x5c992346037540d3) != 0)
		{
			x7450cc1e48712286.ReadUInt16();
		}
		if ((x09b8396ffe8165cf2 & x09b8396ffe8165cf.x21df15027d247ecf) != 0)
		{
			x03fc9cf00067adf7();
		}
	}

	private void xff91f2699fb66249()
	{
		int num = x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadBytes(num - 10);
	}

	private void xc69e2410967b921f()
	{
		int num = x7450cc1e48712286.ReadInt32();
		if (num == 1)
		{
			x03fc9cf00067adf7();
		}
	}

	private void x3de3d032554ad72b()
	{
		int num = x7450cc1e48712286.ReadInt16();
		for (int i = 0; i < num; i++)
		{
			x03fc9cf00067adf7();
		}
		x7450cc1e48712286.ReadInt16();
		x7450cc1e48712286.ReadInt16();
		x7450cc1e48712286.ReadInt16();
		x7450cc1e48712286.ReadInt16();
		x03fc9cf00067adf7();
	}

	private string x03fc9cf00067adf7()
	{
		int num = x7450cc1e48712286.ReadByte();
		byte[] bytes = x7450cc1e48712286.ReadBytes(num * 2);
		return Encoding.Unicode.GetString(bytes);
	}
}
