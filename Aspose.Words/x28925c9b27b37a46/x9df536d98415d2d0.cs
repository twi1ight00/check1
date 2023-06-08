using System.Collections;
using Aspose.Words;
using x5794c252ba25e723;

namespace x28925c9b27b37a46;

internal class x9df536d98415d2d0
{
	private const float x2eb7cbe8420b3468 = 0.238f;

	private readonly Stack xbc872aead225e83f = new Stack();

	private static readonly x26d9ecb4bdf0456d xbb8499a0e8262dc1 = x26d9ecb4bdf0456d.x8f02f53f1587477d;

	internal x9df536d98415d2d0()
	{
		xbc872aead225e83f.Push(null);
	}

	internal void x00149f2495b0f026(Shading x12b7f8e5698b30a6)
	{
		xbc872aead225e83f.Push(xa853df7acdb217c8(x12b7f8e5698b30a6) ? x12b7f8e5698b30a6 : xbc872aead225e83f.Peek());
	}

	internal void xbcd358ebb8d4e95e()
	{
		xbc872aead225e83f.Pop();
	}

	internal x26d9ecb4bdf0456d xa6dfa2703204e9f0(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		if (!x6c50a99faab7d741.x7149c962c02931b3)
		{
			return x6c50a99faab7d741;
		}
		Shading shading = (Shading)xbc872aead225e83f.Peek();
		if (shading != null)
		{
			return x70e0b9728c246fd0(shading);
		}
		return x26d9ecb4bdf0456d.x89fffa2751fdecbe;
	}

	internal static x26d9ecb4bdf0456d x893d2de060ba9359(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		if (!x6c50a99faab7d741.x7149c962c02931b3)
		{
			return x6c50a99faab7d741;
		}
		return xbb8499a0e8262dc1;
	}

	internal static x26d9ecb4bdf0456d x20fbec1cd9812891(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		if (!x6c50a99faab7d741.x7149c962c02931b3)
		{
			return x6c50a99faab7d741;
		}
		return x26d9ecb4bdf0456d.x89fffa2751fdecbe;
	}

	private static x26d9ecb4bdf0456d x70e0b9728c246fd0(Shading x12b7f8e5698b30a6)
	{
		TextureIndex texture = x12b7f8e5698b30a6.Texture;
		if (texture == TextureIndex.TextureNone || texture == TextureIndex.TextureNil)
		{
			if (x12b7f8e5698b30a6.x0e18178ac4b2272f.x7149c962c02931b3)
			{
				return x26d9ecb4bdf0456d.x89fffa2751fdecbe;
			}
			float num = x618bf1990c65e830(x12b7f8e5698b30a6.x0e18178ac4b2272f);
			if (!(num > 0.238f))
			{
				return x26d9ecb4bdf0456d.x8f02f53f1587477d;
			}
			return x26d9ecb4bdf0456d.x89fffa2751fdecbe;
		}
		if (xb7dbd7bb3ed97d5b.x36694757e8d7e52b(texture))
		{
			return x26d9ecb4bdf0456d.x89fffa2751fdecbe;
		}
		float num2 = (float)xb7dbd7bb3ed97d5b.x73ef7a6dac3d681b(texture);
		x26d9ecb4bdf0456d x6c50a99faab7d = x20fbec1cd9812891(x12b7f8e5698b30a6.xc290f60df004e384);
		float num3 = x618bf1990c65e830(x6c50a99faab7d) * num2;
		float num4 = 1f - num2;
		x26d9ecb4bdf0456d x6c50a99faab7d2 = x893d2de060ba9359(x12b7f8e5698b30a6.x0e18178ac4b2272f);
		float num5 = x618bf1990c65e830(x6c50a99faab7d2) * num4;
		float num6 = num3 + num5;
		if (!(num6 > 0.238f))
		{
			return x26d9ecb4bdf0456d.x8f02f53f1587477d;
		}
		return x26d9ecb4bdf0456d.x89fffa2751fdecbe;
	}

	private static bool xa853df7acdb217c8(Shading x12b7f8e5698b30a6)
	{
		return x12b7f8e5698b30a6?.xa853df7acdb217c8 ?? false;
	}

	private static float x618bf1990c65e830(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		float num = 0.3f * (float)x6c50a99faab7d741.xc613adc4330033f3 / 255f;
		float num2 = 0.59f * (float)x6c50a99faab7d741.x26463655896fd90a / 255f;
		float num3 = 0.11f * (float)x6c50a99faab7d741.x8e8f6cc6a0756b05 / 255f;
		return num + num2 + num3;
	}
}
