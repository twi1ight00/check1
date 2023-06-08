using System;
using System.IO;
using x6c95d9cf46ff5f25;
using xe9865c3fb834da49;

namespace Aspose.Words.Saving;

public class DocumentPartSavingArgs
{
	private Stream x63a5946b8064edf1;

	private readonly Document xd1424e1a0bb4a72b;

	private string x4943313674ae08ca;

	private bool x3bff659c3978b9a4;

	public Document Document => xd1424e1a0bb4a72b;

	public string DocumentPartFileName
	{
		get
		{
			return x4943313674ae08ca;
		}
		set
		{
			x0d299f323d241756.x48501aec8e48c869(value, "DocumentPartFileName");
			if (Path.GetFileName(value) != value)
			{
				throw new ArgumentException("DocumentPartFileName must be a file name without path.");
			}
			x4943313674ae08ca = value;
		}
	}

	public bool KeepDocumentPartStreamOpen
	{
		get
		{
			return x3bff659c3978b9a4;
		}
		set
		{
			x3bff659c3978b9a4 = value;
		}
	}

	public Stream DocumentPartStream
	{
		get
		{
			return x63a5946b8064edf1;
		}
		set
		{
			x63a5946b8064edf1 = value;
		}
	}

	internal bool x3477a684b2bbe7b0 => x63a5946b8064edf1 != null;

	internal DocumentPartSavingArgs(Document document, string fileName)
	{
		xd1424e1a0bb4a72b = document;
		x4943313674ae08ca = fileName;
	}

	internal x3d213ffad4d30370 xd9984d5750dc6ac8()
	{
		return new x3d213ffad4d30370(x63a5946b8064edf1, x3bff659c3978b9a4);
	}
}
