namespace Enyim;

/// <summary>
/// Implements an FNV1a hash algorithm.
/// </summary>
public class FNV1a : FNV1
{
	/// <summary>Routes data written to the object into the <see cref="T:FNV1a" /> hash algorithm for computing the hash.</summary>
	/// <param name="array">The input data. </param>
	/// <param name="ibStart">The offset into the byte array from which to begin using data. </param>
	/// <param name="cbSize">The number of bytes in the array to use as data. </param>
	protected override void HashCore(byte[] array, int ibStart, int cbSize)
	{
		int end = ibStart + cbSize;
		for (int i = ibStart; i < end; i++)
		{
			CurrentHashValue ^= array[i];
			CurrentHashValue *= 16777619u;
		}
	}
}
