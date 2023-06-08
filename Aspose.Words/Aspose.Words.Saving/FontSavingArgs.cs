using System;
using System.IO;
using x6c95d9cf46ff5f25;
using xe9865c3fb834da49;

namespace Aspose.Words.Saving;

public class FontSavingArgs
{
	private Stream xe503a9bb34af68fb;

	private readonly Document xd1424e1a0bb4a72b;

	private readonly string xd777c653fc2f2c60;

	private readonly bool xacc99cd4e3772eb3;

	private readonly bool xdfebec19c51b4843;

	private readonly string xa1b6127f243e7e06;

	private readonly int xab59eebcd6597130;

	private bool xf41959cb591fe759;

	private bool xdbc46193e4c561d2;

	private string x7efddf7b730d7350;

	private bool x5798f1057e8667b8;

	public Document Document => xd1424e1a0bb4a72b;

	public string FontFamilyName => xd777c653fc2f2c60;

	public bool Bold => xacc99cd4e3772eb3;

	public bool Italic => xdfebec19c51b4843;

	public string OriginalFileName => xa1b6127f243e7e06;

	public int OriginalFileSize => xab59eebcd6597130;

	public bool IsExportNeeded
	{
		get
		{
			return xf41959cb591fe759;
		}
		set
		{
			xf41959cb591fe759 = value;
		}
	}

	public bool IsSubsettingNeeded
	{
		get
		{
			return xdbc46193e4c561d2;
		}
		set
		{
			xdbc46193e4c561d2 = value;
		}
	}

	public string FontFileName
	{
		get
		{
			return x7efddf7b730d7350;
		}
		set
		{
			x0d299f323d241756.x48501aec8e48c869(value, "FontFileName");
			if (Path.GetFileName(value) != value)
			{
				throw new ArgumentException("FontFileName must be a file name without path.");
			}
			x7efddf7b730d7350 = value;
		}
	}

	public bool KeepFontStreamOpen
	{
		get
		{
			return x5798f1057e8667b8;
		}
		set
		{
			x5798f1057e8667b8 = value;
		}
	}

	public Stream FontStream
	{
		get
		{
			return xe503a9bb34af68fb;
		}
		set
		{
			xe503a9bb34af68fb = value;
		}
	}

	internal bool x3477a684b2bbe7b0 => xe503a9bb34af68fb != null;

	internal FontSavingArgs(Document document, string fontName, bool isBold, bool isItalic, string origFileName, int origFileSize, bool isSubsettingNeeded, string dstFileName)
	{
		xd1424e1a0bb4a72b = document;
		xd777c653fc2f2c60 = fontName;
		xacc99cd4e3772eb3 = isBold;
		xdfebec19c51b4843 = isItalic;
		xa1b6127f243e7e06 = origFileName;
		xab59eebcd6597130 = origFileSize;
		xf41959cb591fe759 = true;
		xdbc46193e4c561d2 = isSubsettingNeeded;
		x7efddf7b730d7350 = dstFileName;
	}

	internal x3d213ffad4d30370 xd9984d5750dc6ac8()
	{
		return new x3d213ffad4d30370(xe503a9bb34af68fb, x5798f1057e8667b8);
	}
}
