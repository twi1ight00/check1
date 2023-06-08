using System.Drawing;

namespace Aspose.Words.Rendering;

public class ThumbnailGeneratingOptions
{
	private bool x83242e32422dd2b2 = true;

	private Size x9b63401c0443ff84 = x0d463bea0ea19697;

	private static readonly Size x0d463bea0ea19697 = new Size(600, 900);

	public bool GenerateFromFirstPage
	{
		get
		{
			return x83242e32422dd2b2;
		}
		set
		{
			x83242e32422dd2b2 = value;
		}
	}

	public Size ThumbnailSize
	{
		get
		{
			return x9b63401c0443ff84;
		}
		set
		{
			x9b63401c0443ff84 = value;
		}
	}
}
