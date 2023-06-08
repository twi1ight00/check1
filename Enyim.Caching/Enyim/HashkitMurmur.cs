using System;
using System.Security.Cryptography;

namespace Enyim;

/// <summary>
/// Murmur hash. Uses the same seed values as libhashkit.
/// </summary>
/// <remarks>Does not support block based hashing.</remarks>
internal class HashkitMurmur : HashAlgorithm, IUIntHashAlgorithm
{
	public override bool CanTransformMultipleBlocks => false;

	public uint CurrentHash { get; private set; }

	public HashkitMurmur()
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
		CurrentHash = UnsafeHashCore(array, ibStart, cbSize);
	}

	protected override byte[] HashFinal()
	{
		return BitConverter.GetBytes(CurrentHash);
	}

	private unsafe static uint UnsafeHashCore(byte[] data, int offset, int length)
	{
		uint seed = (uint)(3735928559u * length);
		uint hash = (uint)(seed ^ length);
		int count = length >> 2;
		fixed (byte* start = &data[offset])
		{
			uint* ptrUInt = (uint*)start;
			while (count > 0)
			{
				uint current = *ptrUInt;
				current *= 1540483477;
				current ^= current >> 24;
				current *= 1540483477;
				hash *= 1540483477;
				hash ^= current;
				count--;
				ptrUInt++;
			}
			switch (length & 3)
			{
			case 3:
				hash ^= *(ushort*)ptrUInt;
				hash ^= (uint)(((byte*)ptrUInt)[2] << 16);
				hash *= 1540483477;
				break;
			case 2:
				hash ^= *(ushort*)ptrUInt;
				hash *= 1540483477;
				break;
			case 1:
				hash ^= *(byte*)ptrUInt;
				hash *= 1540483477;
				break;
			}
		}
		hash ^= hash >> 13;
		hash *= 1540483477;
		return hash ^ (hash >> 15);
	}

	uint IUIntHashAlgorithm.ComputeHash(byte[] data)
	{
		Initialize();
		HashCore(data, 0, data.Length);
		return CurrentHash;
	}
}
