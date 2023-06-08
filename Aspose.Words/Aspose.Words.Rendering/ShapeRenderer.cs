using System;
using System.Drawing;
using System.IO;
using Aspose.Words.Drawing;
using Aspose.Words.Saving;
using x077e797660ceec8d;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x3d94286fe72124a8;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x85732faf56f7825d;

namespace Aspose.Words.Rendering;

public class ShapeRenderer
{
	private xe973e6aa8aca7f14 xb4db99e167d74ee1;

	private WarningInfoCollection x6bdd4eb84ba9e673 = new WarningInfoCollection();

	private readonly xb8e7e788f6d59708 x9b1777152cf410e1;

	public SizeF SizeInPoints => xb4db99e167d74ee1.xfe502558fa04ffb1.Size;

	public ShapeRenderer(DrawingML shape)
	{
		if (shape == null)
		{
			throw new ArgumentNullException("shape");
		}
		x7c8328a75e9baa2d warningCallback = new x7c8328a75e9baa2d(x6bdd4eb84ba9e673);
		x73d966e39902908a x73d966e39902908a = new x73d966e39902908a(warningCallback);
		x7721ad963b03c6eb xa3d15e542708d37f = new x7721ad963b03c6eb(shape);
		x2fca56c11bd20653 x2fca56c11bd = x73d966e39902908a.xe406325e56f74b46(xa3d15e542708d37f);
		x9b1777152cf410e1 = x2fca56c11bd.xa1eafe7821eb4aab;
		x64a9193a95feb37a(x2fca56c11bd);
	}

	public ShapeRenderer(ShapeBase shape)
	{
		if (shape == null)
		{
			throw new ArgumentNullException("shape");
		}
		x7c8328a75e9baa2d x57fef5933b41d0c = new x7c8328a75e9baa2d(x6bdd4eb84ba9e673);
		x7721ad963b03c6eb x7721ad963b03c6eb = new x7721ad963b03c6eb(shape);
		x9b1777152cf410e1 = xc958d22004253850.xe0bb10192c142499(x7721ad963b03c6eb, x57fef5933b41d0c);
		x64a9193a95feb37a(x7721ad963b03c6eb);
	}

	public Size GetSizeInPixels(float scale, float dpi)
	{
		return x4574ea26106f0edb.x4bec21b1de9d1b5b(SizeInPoints, scale, dpi);
	}

	public SizeF RenderToScale(Graphics graphics, float x, float y, float scale)
	{
		x3a15c7024016ce52 x3a15c7024016ce = new x3a15c7024016ce52();
		return x3a15c7024016ce.x231ed5305a7bb3ea(x9b1777152cf410e1, SizeInPoints, graphics, x, y, scale);
	}

	public float RenderToSize(Graphics graphics, float x, float y, float width, float height)
	{
		x3a15c7024016ce52 x3a15c7024016ce = new x3a15c7024016ce52();
		return x3a15c7024016ce.xc8a427e6e672c1ed(x9b1777152cf410e1, SizeInPoints, graphics, x, y, width, height);
	}

	public void Save(string fileName, ImageSaveOptions saveOptions)
	{
		x0d299f323d241756.x48501aec8e48c869(fileName, "fileName");
		if (saveOptions == null)
		{
			saveOptions = (ImageSaveOptions)SaveOptions.CreateSaveOptions(fileName);
		}
		using Stream stream = File.Create(fileName);
		Save(stream, saveOptions);
	}

	[JavaInternal]
	public void Save(Stream stream, ImageSaveOptions saveOptions)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (saveOptions == null)
		{
			saveOptions = new ImageSaveOptions(SaveFormat.Png);
		}
		SizeF sizeF = SizeInPoints;
		if (sizeF == SizeF.Empty && x9b1777152cf410e1.xd44988f225497f3a == 0)
		{
			x72c34b8dbaec3734 x72c34b8dbaec = new x72c34b8dbaec3734(new PointF(0f, 0f), new SizeF(32f, 32f), x0d299f323d241756.xcd6c2a9742c9220a());
			x9b1777152cf410e1.xd6b6ed77479ef68c(x72c34b8dbaec);
			sizeF = x72c34b8dbaec.x437e3b626c0fdd43;
		}
		x0a376fc3a80043f7.x53c5cdce403a6243(x9b1777152cf410e1, sizeF, stream, saveOptions);
		xc3b7f591ac179b1c(saveOptions);
	}

	private void x64a9193a95feb37a(xe973e6aa8aca7f14 x7d95d971d8923f4c)
	{
		xb4db99e167d74ee1 = x7d95d971d8923f4c;
		x9b1777152cf410e1.x52dde376accdec7d = new x54366fa5f75a02f7(1f, 0f, 0f, 1f, 0f - xb4db99e167d74ee1.xfe502558fa04ffb1.Left, 0f - xb4db99e167d74ee1.xfe502558fa04ffb1.Top);
	}

	private void xc3b7f591ac179b1c(ImageSaveOptions xc27f01f21f67608c)
	{
		if (xc27f01f21f67608c.WarningCallback == null)
		{
			return;
		}
		foreach (WarningInfo item in x6bdd4eb84ba9e673)
		{
			xc27f01f21f67608c.WarningCallback.Warning(item);
		}
	}
}
