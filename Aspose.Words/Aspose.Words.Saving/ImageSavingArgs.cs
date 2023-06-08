using System;
using System.IO;
using Aspose.Words.Drawing;
using x6c95d9cf46ff5f25;
using xe9865c3fb834da49;

namespace Aspose.Words.Saving;

public class ImageSavingArgs
{
	private Stream x7492bd16e718c2a0;

	private readonly ShapeBase x317be79405176667;

	private readonly bool x2ecef0e333378fd6;

	private string x7c0b2c3ae14d9668;

	private bool x83e1ab2bb89895c5;

	public Document Document => x317be79405176667.x357c90b33d6bb8e6();

	public ShapeBase CurrentShape => x317be79405176667;

	public bool IsImageAvailable => x2ecef0e333378fd6;

	public string ImageFileName
	{
		get
		{
			return x7c0b2c3ae14d9668;
		}
		set
		{
			x0d299f323d241756.x48501aec8e48c869(value, "ImageFileName");
			if (Path.GetFileName(value) != value)
			{
				throw new ArgumentException("ImageFileName must be a file name without path.");
			}
			x7c0b2c3ae14d9668 = value;
		}
	}

	public bool KeepImageStreamOpen
	{
		get
		{
			return x83e1ab2bb89895c5;
		}
		set
		{
			x83e1ab2bb89895c5 = value;
		}
	}

	public Stream ImageStream
	{
		get
		{
			return x7492bd16e718c2a0;
		}
		set
		{
			x7492bd16e718c2a0 = value;
		}
	}

	internal bool x3477a684b2bbe7b0 => x7492bd16e718c2a0 != null;

	internal ImageSavingArgs(ShapeBase shape, bool isImageAvailable, string dstFileName)
	{
		x317be79405176667 = shape;
		x2ecef0e333378fd6 = isImageAvailable;
		x7c0b2c3ae14d9668 = dstFileName;
	}

	internal x3d213ffad4d30370 xd9984d5750dc6ac8()
	{
		return new x3d213ffad4d30370(x7492bd16e718c2a0, x83e1ab2bb89895c5);
	}
}
