using System.Collections;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class x89129abe6fed968f
{
	private const int x94453eec7c700d51 = 1;

	private const int x64cb65cc37bf5cbc = 2;

	private const int xc210311c0e6cafc4 = 4;

	private readonly Hashtable x4faa3ce8f40213bc;

	public Hashtable xc955b0b111c9581c => x4faa3ce8f40213bc;

	public x89129abe6fed968f(Hashtable kerningValues)
	{
		x4faa3ce8f40213bc = kerningValues;
	}

	public x89129abe6fed968f()
		: this(new Hashtable())
	{
	}

	public static x89129abe6fed968f x06b0e25aa6ad68a9(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		xe134235b3526fa75.xdb264d863790ee7b();
		int num = xe134235b3526fa75.xdb264d863790ee7b();
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < num; i++)
		{
			long position = xe134235b3526fa75.x9e418ad9a56d1cf5.Position;
			xe134235b3526fa75.xdb264d863790ee7b();
			int num2 = xe134235b3526fa75.xdb264d863790ee7b();
			int num3 = xe134235b3526fa75.xdb264d863790ee7b();
			bool flag = x26000ce44ebda9ea.xf73042981b08c3f7(num3, 1);
			bool flag2 = x26000ce44ebda9ea.xf73042981b08c3f7(num3, 2);
			bool flag3 = x26000ce44ebda9ea.xf73042981b08c3f7(num3, 4);
			if ((num3 & 0xFF00) >> 8 == 0 && flag && !flag2 && !flag3)
			{
				xa1ac9375f68d238f(xe134235b3526fa75, hashtable);
			}
			xe134235b3526fa75.x9e418ad9a56d1cf5.Position = position + num2;
		}
		return new x89129abe6fed968f(hashtable);
	}

	private static void xa1ac9375f68d238f(xa8866d7566da0aa2 xe134235b3526fa75, Hashtable x378f87a3c235021d)
	{
		int num = xe134235b3526fa75.xdb264d863790ee7b();
		xe134235b3526fa75.xdb264d863790ee7b();
		xe134235b3526fa75.xdb264d863790ee7b();
		xe134235b3526fa75.xdb264d863790ee7b();
		for (int i = 0; i < num; i++)
		{
			int left = xe134235b3526fa75.xdb264d863790ee7b();
			int right = xe134235b3526fa75.xdb264d863790ee7b();
			int num2 = xe134235b3526fa75.x2e6b89ad8001e18f();
			x378f87a3c235021d[new x40ece001856d7b50(left, right)] = num2;
		}
	}
}
