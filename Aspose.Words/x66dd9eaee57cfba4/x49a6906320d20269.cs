using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class x49a6906320d20269
{
	internal x00ef2e50265c0d3e[] x178cb9516bd7c522;

	internal short[] x7999fb265edd4bd2;

	internal x49a6906320d20269(xa8866d7566da0aa2 reader, int hMetricCount, int glyphCount)
	{
		x178cb9516bd7c522 = new x00ef2e50265c0d3e[hMetricCount];
		for (int i = 0; i < x178cb9516bd7c522.Length; i++)
		{
			ref x00ef2e50265c0d3e reference = ref x178cb9516bd7c522[i];
			reference = new x00ef2e50265c0d3e(reader);
		}
		int num = glyphCount - hMetricCount;
		x7999fb265edd4bd2 = new short[num];
		for (int j = 0; j < x7999fb265edd4bd2.Length; j++)
		{
			x7999fb265edd4bd2[j] = reader.x2e6b89ad8001e18f();
		}
	}

	internal x00ef2e50265c0d3e xc9b9fba2361cb131(int x7a6027e2e9a31663)
	{
		if (x7a6027e2e9a31663 < x178cb9516bd7c522.Length)
		{
			return x178cb9516bd7c522[x7a6027e2e9a31663];
		}
		x00ef2e50265c0d3e x00ef2e50265c0d3e2 = x178cb9516bd7c522[x178cb9516bd7c522.Length - 1];
		short leftSideBearing = x7999fb265edd4bd2[x7a6027e2e9a31663 - x178cb9516bd7c522.Length];
		return new x00ef2e50265c0d3e(x00ef2e50265c0d3e2.xf58adb71a3d2dade, leftSideBearing);
	}
}
