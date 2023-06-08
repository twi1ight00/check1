using System.IO;

namespace xa604c4d210ae0581;

internal class x759e32a03439237a
{
	internal static bool x492f529cee830a40;

	internal static void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, int xa5750de2465a751c, int x4e5f86b4fda78093, xa38071b52e850907 x7d1bf994956f1081, string x1fc1ac6d1662f30c)
	{
		if (xa5750de2465a751c != 0)
		{
			int x7ba25e2bf03f41de = (xa5750de2465a751c - 4) / (4 + x4e5f86b4fda78093);
			_ = x492f529cee830a40;
			x06b0e25aa6ad68a9(xe134235b3526fa75, x7ba25e2bf03f41de, x7d1bf994956f1081);
		}
	}

	internal static void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, int x7ba25e2bf03f41de, xa38071b52e850907 x7d1bf994956f1081)
	{
		int num = x7ba25e2bf03f41de + 1;
		_ = x492f529cee830a40;
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = xe134235b3526fa75.ReadInt32();
			_ = x492f529cee830a40;
		}
		_ = x492f529cee830a40;
		for (int j = 0; j < x7ba25e2bf03f41de; j++)
		{
			x7d1bf994956f1081.xa6a789f0e88511c3(xe134235b3526fa75, array[j], array[j + 1]);
		}
	}
}
