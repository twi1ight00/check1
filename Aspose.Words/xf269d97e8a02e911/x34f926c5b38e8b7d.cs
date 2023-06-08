namespace xf269d97e8a02e911;

internal class x34f926c5b38e8b7d
{
	private int x4574aea041dd835f;

	public int xc613adc4330033f3 => x4574aea041dd835f & 0xFF;

	public int x26463655896fd90a => (x4574aea041dd835f >> 8) & 0xFF;

	public int x8e8f6cc6a0756b05 => (x4574aea041dd835f >> 16) & 0xFF;

	internal x5322239d809e8f13 x586b7652ac7cefe0 => (x5322239d809e8f13)((x4574aea041dd835f >> 24) & 0xFF);

	internal x34f926c5b38e8b7d(int value)
	{
		x4574aea041dd835f = value;
	}
}
