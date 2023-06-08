namespace Enyim;

/// <summary>
/// Implements a 64 bit long FVNV1a hash.
/// </summary>
public sealed class FNV64a : FNV64
{
	/// <summary>Routes data written to the object into the <see cref="T:FNV64" /> hash algorithm for computing the hash.</summary>
	/// <param name="array">The input data. </param>
	/// <param name="ibStart">The offset into the byte array from which to begin using data. </param>
	/// <param name="cbSize">The number of bytes in the array to use as data. </param>
	protected override void HashCore(byte[] array, int ibStart, int cbSize)
	{
		int end = ibStart + cbSize;
		for (int i = ibStart; i < end; i++)
		{
			CurrentHashValue ^= array[i];
			CurrentHashValue *= 1099511628211uL;
		}
	}
}
