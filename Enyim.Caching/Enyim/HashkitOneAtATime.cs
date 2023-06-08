using System;
using System.Security.Cryptography;

namespace Enyim;

/// <summary>
/// This is Jenkin's "One at A time Hash".
/// http://en.wikipedia.org/wiki/Jenkins_hash_function
///
/// Coming from libhashkit.
/// </summary>
/// <remarks>Does not support block based hashing.</remarks>
internal class HashkitOneAtATime : HashAlgorithm, IUIntHashAlgorithm
{
	public override bool CanTransformMultipleBlocks => false;

	public uint CurrentHash { get; private set; }

	public HashkitOneAtATime()
	{
		HashSizeValue = 32;
	}

	public override void Initialize()
	{
	}

	protected override void HashCore(byte[] array, int ibStart, int cbSize)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (ibStart < 0 || ibStart > array.Length)
		{
			throw new ArgumentOutOfRangeException("ibStart");
		}
		if (ibStart + cbSize > array.Length)
		{
			throw new ArgumentOutOfRangeException("cbSize");
		}
		UnsafeHashCore(array, ibStart, cbSize);
	}

	protected override byte[] HashFinal()
	{
		return BitConverter.GetBytes(CurrentHash);
	}

	private unsafe static uint UnsafeHashCore(byte[] data, int offset, int count)
	{
		uint hash = 0u;
		fixed (byte* start = &data[offset])
		{
			byte* ptr = start;
			while (count > 0)
			{
				hash += *ptr;
				hash += hash << 10;
				hash ^= hash >> 6;
				count--;
				ptr++;
			}
		}
		hash += hash << 3;
		hash ^= hash >> 11;
		return hash + (hash << 15);
	}

	uint IUIntHashAlgorithm.ComputeHash(byte[] data)
	{
		Initialize();
		HashCore(data, 0, data.Length);
		return CurrentHash;
	}
}
