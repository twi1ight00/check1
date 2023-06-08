using System;
using System.Security.Cryptography;

namespace Enyim;

/// <summary>
/// Implements a 64 bit long FNV1 hash.
/// </summary>
/// <remarks>
/// Calculation found at http://lists.danga.com/pipermail/memcached/2007-April/003846.html, but 
/// it is pretty much available everywhere
/// </remarks>
public class FNV64 : HashAlgorithm, IUIntHashAlgorithm
{
	protected const ulong Init = 14695981039346656037uL;

	protected const ulong Prime = 1099511628211uL;

	protected ulong CurrentHashValue;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:FNV64" /> class.
	/// </summary>
	public FNV64()
	{
		HashSizeValue = 64;
	}

	/// <summary>
	/// Initializes an instance of <see cref="T:FNV64" />.
	/// </summary>
	public override void Initialize()
	{
		CurrentHashValue = 14695981039346656037uL;
	}

	/// <summary>Routes data written to the object into the <see cref="T:FNV64" /> hash algorithm for computing the hash.</summary>
	/// <param name="array">The input data. </param>
	/// <param name="ibStart">The offset into the byte array from which to begin using data. </param>
	/// <param name="cbSize">The number of bytes in the array to use as data. </param>
	protected override void HashCore(byte[] array, int ibStart, int cbSize)
	{
		int end = ibStart + cbSize;
		for (int i = ibStart; i < end; i++)
		{
			CurrentHashValue *= 1099511628211uL;
			CurrentHashValue ^= array[i];
		}
	}

	/// <summary>
	/// Returns the computed <see cref="T:FNV64" /> hash value after all data has been written to the object.
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
		return (uint)CurrentHashValue;
	}
}
