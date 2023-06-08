using System;
using System.Security.Cryptography;

namespace Enyim;

/// <summary>
/// Implements an FNV1 hash algorithm.
/// </summary>
public class FNV1 : HashAlgorithm, IUIntHashAlgorithm
{
	protected const uint Prime = 16777619u;

	protected const uint Init = 2166136261u;

	/// <summary>
	/// The current hash value.
	/// </summary>
	protected uint CurrentHashValue;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:FNV1a" /> class.
	/// </summary>
	public FNV1()
	{
		HashSizeValue = 32;
	}

	/// <summary>
	/// Initializes an instance of <see cref="T:FNV1a" />.
	/// </summary>
	public override void Initialize()
	{
		CurrentHashValue = 2166136261u;
	}

	/// <summary>Routes data written to the object into the <see cref="T:FNV1a" /> hash algorithm for computing the hash.</summary>
	/// <param name="array">The input data. </param>
	/// <param name="ibStart">The offset into the byte array from which to begin using data. </param>
	/// <param name="cbSize">The number of bytes in the array to use as data. </param>
	protected override void HashCore(byte[] array, int ibStart, int cbSize)
	{
		int end = ibStart + cbSize;
		for (int i = ibStart; i < end; i++)
		{
			CurrentHashValue *= 16777619u;
			CurrentHashValue ^= array[i];
		}
	}

	/// <summary>
	/// Returns the computed <see cref="T:FNV1a" /> hash value after all data has been written to the object.
	/// </summary>
	/// <returns>The computed hash code.</returns>
	protected override byte[] HashFinal()
	{
		return BitConverter.GetBytes(CurrentHashValue);
	}

	uint IUIntHashAlgorithm.ComputeHash(byte[] data)
	{
		Initialize();
		HashCore(data, 0, data.Length);
		return CurrentHashValue;
	}
}
