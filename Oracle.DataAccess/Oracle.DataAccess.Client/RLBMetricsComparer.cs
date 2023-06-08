using System.Collections;

namespace Oracle.DataAccess.Client;

internal class RLBMetricsComparer : IComparer
{
	public int Compare(object x, object y)
	{
		RLBMetrics rLBMetrics = (RLBMetrics)x;
		RLBMetrics rLBMetrics2 = (RLBMetrics)y;
		if (rLBMetrics.MaxDistribFreq < rLBMetrics2.MaxDistribFreq)
		{
			return 1;
		}
		if (rLBMetrics.MaxDistribFreq == rLBMetrics2.MaxDistribFreq)
		{
			return 0;
		}
		return -1;
	}
}
