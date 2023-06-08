namespace x5f3520a4b31ea90f;

internal class x0c2c2ec0e5dfca9c
{
	internal xfbab8f66e7836ec4 x5c8780fe7aa5ad5c;

	internal xfbab8f66e7836ec4 xe7d06cb218ed4487;

	public xfbab8f66e7836ec4 x02f2e920b8f411d0 => x5c8780fe7aa5ad5c;

	public xfbab8f66e7836ec4 x24bbf5a4ec5b021d => xe7d06cb218ed4487;

	public x0c2c2ec0e5dfca9c(byte[] modulusBytes, byte[] exponentBytes)
	{
		x5c8780fe7aa5ad5c = new xfbab8f66e7836ec4(modulusBytes);
		xe7d06cb218ed4487 = new xfbab8f66e7836ec4(exponentBytes);
	}

	public byte[] x246b032720dd4c0d(byte[] x87c35a902ad7d8a4)
	{
		if (x87c35a902ad7d8a4 == null || x87c35a902ad7d8a4.Length < 1)
		{
			return new byte[0];
		}
		xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(x87c35a902ad7d8a4);
		xfbab8f66e7836ec4 xfbab8f66e7836ec6 = xfbab8f66e7836ec5.xe66bb648cc583eb8(xe7d06cb218ed4487, x5c8780fe7aa5ad5c);
		byte[] result = xfbab8f66e7836ec6.xd7256284d8a56f03();
		xfbab8f66e7836ec5.xa9d636b00ff486b7();
		xfbab8f66e7836ec6.xa9d636b00ff486b7();
		return result;
	}
}
