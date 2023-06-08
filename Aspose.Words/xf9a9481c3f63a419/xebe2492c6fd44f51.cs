using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose;
using x38a89dee67fc7a16;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class xebe2492c6fd44f51 : IDisposable
{
	private static readonly Hashtable x2cf34d7a31023ea4;

	private x858159a2ee718ca5 x4a66f2abeb17a818;

	private Image x3dd43be9f615600b;

	private EncoderParameters xc85d3e32c68e3387;

	private bool x9dc3ec86e1de192e;

	public void Dispose()
	{
		if (x9dc3ec86e1de192e && x3dd43be9f615600b != null)
		{
			x3dd43be9f615600b.Dispose();
			x3dd43be9f615600b = null;
		}
		GC.SuppressFinalize(this);
	}

	public void x2c68b59bdffce478(Bitmap xe205f0cd81228282, Stream xcf18e5243f8d5fd3, x858159a2ee718ca5 x66c2bb8e70f50527, bool x5229aac0e655112a)
	{
		x4a66f2abeb17a818 = x66c2bb8e70f50527;
		x3dd43be9f615600b = x26a784485d3096c8(xe205f0cd81228282, x66c2bb8e70f50527);
		ImageCodecInfo encoder = x6a10b0e15f4796fb.xe9a31ec80cc211ff(ImageFormat.Tiff);
		xc85d3e32c68e3387 = xeac474b0aa9c6215(x66c2bb8e70f50527, x5229aac0e655112a);
		x3dd43be9f615600b.Save(xcf18e5243f8d5fd3, encoder, xc85d3e32c68e3387);
		x9dc3ec86e1de192e = x3dd43be9f615600b != xe205f0cd81228282;
	}

	public void xf111a06c3ff6a33d(x3cd5d648729cd9b6 xe205f0cd81228282)
	{
		Bitmap image = x26a784485d3096c8(xe205f0cd81228282.x45634637f3d108db(), x4a66f2abeb17a818);
		xc85d3e32c68e3387.Param[0] = new EncoderParameter(xc85d3e32c68e3387.Param[0].Encoder, 23L);
		x3dd43be9f615600b.SaveAdd(image, xc85d3e32c68e3387);
	}

	public void x95ce6f08245274c1()
	{
		xc85d3e32c68e3387.Param[0] = new EncoderParameter(xc85d3e32c68e3387.Param[0].Encoder, 20L);
		x3dd43be9f615600b.SaveAdd(xc85d3e32c68e3387);
	}

	private static Bitmap x26a784485d3096c8(Bitmap xe205f0cd81228282, x858159a2ee718ca5 x66c2bb8e70f50527)
	{
		switch (x66c2bb8e70f50527)
		{
		case x858159a2ee718ca5.xf6875da725c82a98:
		case x858159a2ee718ca5.xd9c34d7c9f00a2f9:
			if (!xed747ca236d86aa0.xdf550180001d5cd4() && xe205f0cd81228282.PixelFormat != PixelFormat.Format1bppIndexed)
			{
				xe205f0cd81228282 = new x67f5e4db5e884ab4().x5772bbb43a8ca973(xe205f0cd81228282);
			}
			break;
		}
		return xe205f0cd81228282;
	}

	private static EncoderParameters xeac474b0aa9c6215(x858159a2ee718ca5 x66c2bb8e70f50527, bool x5229aac0e655112a)
	{
		EncoderParameter encoderParameter = new EncoderParameter(Encoder.Compression, (long)xfbb09942d73a6ce5(x66c2bb8e70f50527));
		if (x5229aac0e655112a)
		{
			EncoderParameters encoderParameters = new EncoderParameters(2);
			encoderParameters.Param[0] = new EncoderParameter(Encoder.SaveFlag, 18L);
			encoderParameters.Param[1] = encoderParameter;
			return encoderParameters;
		}
		EncoderParameters encoderParameters2 = new EncoderParameters();
		encoderParameters2.Param[0] = encoderParameter;
		return encoderParameters2;
	}

	private static EncoderValue xfbb09942d73a6ce5(x858159a2ee718ca5 x66c2bb8e70f50527)
	{
		return (EncoderValue)x2cf34d7a31023ea4[x66c2bb8e70f50527];
	}

	static xebe2492c6fd44f51()
	{
		x2cf34d7a31023ea4 = new Hashtable();
		x2cf34d7a31023ea4.Add(x858159a2ee718ca5.x4d0b9d4447ba7566, EncoderValue.CompressionNone);
		x2cf34d7a31023ea4.Add(x858159a2ee718ca5.x67749da60288d66c, EncoderValue.CompressionRle);
		x2cf34d7a31023ea4.Add(x858159a2ee718ca5.x79eafe89940e5b0e, EncoderValue.CompressionLZW);
		x2cf34d7a31023ea4.Add(x858159a2ee718ca5.xf6875da725c82a98, EncoderValue.CompressionCCITT3);
		x2cf34d7a31023ea4.Add(x858159a2ee718ca5.xd9c34d7c9f00a2f9, EncoderValue.CompressionCCITT4);
	}
}
