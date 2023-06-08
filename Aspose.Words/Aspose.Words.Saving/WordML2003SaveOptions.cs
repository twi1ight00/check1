using System;

namespace Aspose.Words.Saving;

public class WordML2003SaveOptions : SaveOptions
{
	public override SaveFormat SaveFormat
	{
		get
		{
			return SaveFormat.WordML;
		}
		set
		{
			if (value != SaveFormat.WordML)
			{
				throw new ArgumentException("An invalid SaveFormat for this options type was chosen.");
			}
		}
	}
}
