namespace Enyim;

/// <summary>
/// Implements a modified FNV hash. Provides better distribution than FNV1 but it's only 32 bit long.
/// </summary>
/// <remarks>Algorithm found at http://bretm.home.comcast.net/hash/6.html</remarks>
public class ModifiedFNV : FNV1a
{
	/// <summary>
	/// Returns the computed <see cref="T:ModifiedFNV" /> hash value after all data has been written to the object.
	/// </summary>
	/// <returns>The computed hash code.</returns>
	protected override byte[] HashFinal()
	{
		CurrentHashValue += CurrentHashValue << 13;
		CurrentHashValue ^= CurrentHashValue >> 7;
		CurrentHashValue += CurrentHashValue << 3;
		CurrentHashValue ^= CurrentHashValue >> 17;
		CurrentHashValue += CurrentHashValue << 5;
		return base.HashFinal();
	}
}
