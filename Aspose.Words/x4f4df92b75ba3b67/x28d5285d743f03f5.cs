using System;
using x38a89dee67fc7a16;
using x5794c252ba25e723;

namespace x4f4df92b75ba3b67;

internal abstract class x28d5285d743f03f5
{
	private static readonly x28d5285d743f03f5 xee26f6747fb01697 = new x228b0a98bcdf7c31();

	private static readonly x28d5285d743f03f5 x3fce54f0c69ab579 = new x1f4a9aa01e0bf94e();

	private static readonly x28d5285d743f03f5 x65404e12b81a30ff = new x1bf9defa2688c74c();

	private static readonly x28d5285d743f03f5 x9ee3cd7e705a1cbd = new x36c085281652b431();

	internal abstract string x0155217fb8bbda6a { get; }

	internal abstract int xdb1ba24fae9ef815 { get; }

	internal abstract string xeff0fe726f3da2ea { get; }

	internal abstract string x8f878f72e5a5dc35 { get; }

	internal static x28d5285d743f03f5 x3e8193d537ae8eac => xee26f6747fb01697;

	internal static x28d5285d743f03f5 x529d0bc70de5de1f => x3fce54f0c69ab579;

	internal static x28d5285d743f03f5 x7bc2cd43944d90a3 => x65404e12b81a30ff;

	internal static x28d5285d743f03f5 xd265a220a45d3124 => x9ee3cd7e705a1cbd;

	internal abstract string xfafbf12cd38285b5(x26d9ecb4bdf0456d x6c50a99faab7d741);

	internal static x28d5285d743f03f5 xd62557bb0eb80475(x342b86618ed63a10 xe306c5db8faba54d)
	{
		return xe306c5db8faba54d switch
		{
			x342b86618ed63a10.x2c689d7a8a2c3c93 => x529d0bc70de5de1f, 
			x342b86618ed63a10.x7bc2cd43944d90a3 => x7bc2cd43944d90a3, 
			x342b86618ed63a10.x4ad4518443afe7c9 => x3e8193d537ae8eac, 
			_ => throw new InvalidOperationException("Unknown bitmap color space."), 
		};
	}

	internal static x28d5285d743f03f5 x17b1961e76a1bb2b(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		if (!x6c50a99faab7d741.x2bdbc700da15ebe5)
		{
			return x529d0bc70de5de1f;
		}
		return x3e8193d537ae8eac;
	}
}
