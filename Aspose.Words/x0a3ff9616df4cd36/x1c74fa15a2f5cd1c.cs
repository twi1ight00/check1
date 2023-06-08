using System.Collections;

namespace x0a3ff9616df4cd36;

internal class x1c74fa15a2f5cd1c
{
	internal static ICollection xb1451f746ac6e5cb(ArrayList x45bd840e09b7c920)
	{
		if (x45bd840e09b7c920 == null || x45bd840e09b7c920.Count == 0)
		{
			return new ArrayList(0);
		}
		SortedList sortedList = new SortedList();
		foreach (x506b258dd39c6252 item in x45bd840e09b7c920)
		{
			if (item.x4af6b6f55aeb44a7 == xd9934398f56f27df.x7b8788264ab563ac)
			{
				continue;
			}
			if (sortedList.ContainsKey(item.x4af6b6f55aeb44a7))
			{
				if (xed007403c5a25742(item))
				{
					continue;
				}
				sortedList.Remove(item.x4af6b6f55aeb44a7);
			}
			sortedList.Add(item.x4af6b6f55aeb44a7, item);
		}
		return sortedList.Values;
	}

	private static bool xed007403c5a25742(x506b258dd39c6252 x55e65a18bfeb8986)
	{
		bool flag = x55e65a18bfeb8986 is x2c421831b88cb0f0;
		return !flag;
	}
}
