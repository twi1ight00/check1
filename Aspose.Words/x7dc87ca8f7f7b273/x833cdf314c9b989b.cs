using System.Collections;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x7dc87ca8f7f7b273;

internal class x833cdf314c9b989b : xc7a77b17ac8b122b
{
	private const float xdd51c295b91d330c = 10f;

	private const string xca4a36f5f327e766 = "http://www.w3.org/2000/svg";

	private const string xeb9fca7655e529ad = "http://www.w3.org/1999/xlink";

	private int x25d95185974bdef4;

	private int x2bb7654456fb7122;

	private xe30ab0f541251753 x2d6df7514a3346cc;

	private ArrayList x4f6190ffbf116eda = new ArrayList();

	public xe30ab0f541251753 x5c96e27b059805fe => x2d6df7514a3346cc;

	public x833cdf314c9b989b(xd878af0d0717b77a context)
		: base(context)
	{
	}

	public void x9b9ed0109b743e3b()
	{
		base.x5aa326f374b3d0ef.x9b9ed0109b743e3b("svg");
		base.x5aa326f374b3d0ef.xff520a0047c27122("xmlns", "http://www.w3.org/2000/svg");
		base.x5aa326f374b3d0ef.xff520a0047c27122("xmlns:xlink", "http://www.w3.org/1999/xlink");
	}

	public void xa0dfc102c691b11f()
	{
		x2bb7654456fb7122 += (x4f6190ffbf116eda.Count - 1) * x4574ea26106f0edb.xdbd829479885762d(10.0);
		base.x5aa326f374b3d0ef.xff520a0047c27122("width", x25d95185974bdef4.ToString());
		base.x5aa326f374b3d0ef.xff520a0047c27122("height", x2bb7654456fb7122.ToString());
		if (x0d299f323d241756.x5959bccb67bbf051(base.x28fcdc775a1d069c.x73979cef1002ed01.xc605b5c8a6696acf))
		{
			base.x5aa326f374b3d0ef.x5222f4285e37d66b.WriteComment($"Generated by {base.x28fcdc775a1d069c.x73979cef1002ed01.xc605b5c8a6696acf}");
		}
		base.x28fcdc775a1d069c.x304b6d4b7f054ae1();
		base.x5aa326f374b3d0ef.x2307058321cdb62f("g");
		base.x5aa326f374b3d0ef.xff520a0047c27122("transform", "scale(1.33333)");
		float num = 0f;
		foreach (xe30ab0f541251753 x4f6190ffbf116edum in x4f6190ffbf116eda)
		{
			float num2 = ((float)x4574ea26106f0edb.xad2dd08366e0faf5(x25d95185974bdef4) - x4f6190ffbf116edum.x840f0682785efa25.Width) / 2f;
			base.x5aa326f374b3d0ef.x2307058321cdb62f("g");
			if (num2 > 0f || num > 0f)
			{
				base.x5aa326f374b3d0ef.xff520a0047c27122("transform", $"translate({xca004f56614e2431.x37804260a70f74eb(num2)},{xca004f56614e2431.x37804260a70f74eb(num)})");
			}
			x4f6190ffbf116edum.xa1cc26fee27f9d36();
			base.x5aa326f374b3d0ef.x2dfde153f4ef96d0();
			num += x4f6190ffbf116edum.x840f0682785efa25.Height + 10f;
		}
		base.x5aa326f374b3d0ef.x2dfde153f4ef96d0();
		base.x5aa326f374b3d0ef.xa0dfc102c691b11f();
	}

	public void x804b2039ae4e9b33(xc67adcdbca121a26 xbbe2f7d7c86e0379)
	{
		if (x25d95185974bdef4 < xbbe2f7d7c86e0379.x87406eebf687e0d7)
		{
			x25d95185974bdef4 = xbbe2f7d7c86e0379.x87406eebf687e0d7;
		}
		x2bb7654456fb7122 += xbbe2f7d7c86e0379.x0969cb0cdb4d079f;
		x2d6df7514a3346cc = new xe30ab0f541251753(base.x28fcdc775a1d069c);
		x2d6df7514a3346cc.x804b2039ae4e9b33(xbbe2f7d7c86e0379);
	}

	public void xa0cf4a18229be519()
	{
		x2d6df7514a3346cc.xa0cf4a18229be519();
		x4f6190ffbf116eda.Add(x2d6df7514a3346cc);
		x2d6df7514a3346cc = null;
	}
}
