using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;

namespace Enyim.Caching.Configuration;

public interface IVBucketConfiguration
{
	IList<IPEndPoint> Servers { get; }

	IList<VBucket> Buckets { get; }

	HashAlgorithm CreateHashAlgorithm();
}
