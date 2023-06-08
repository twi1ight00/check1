using System;

namespace Aspose.Words.Properties;

public class CustomDocumentProperties : DocumentPropertyCollection
{
	internal CustomDocumentProperties()
	{
	}

	public DocumentProperty Add(string name, string value)
	{
		return xd6b6ed77479ef68c(name, value);
	}

	public DocumentProperty Add(string name, int value)
	{
		return xd6b6ed77479ef68c(name, value);
	}

	public DocumentProperty Add(string name, DateTime value)
	{
		return xd6b6ed77479ef68c(name, value);
	}

	public DocumentProperty Add(string name, bool value)
	{
		return xd6b6ed77479ef68c(name, value);
	}

	public DocumentProperty Add(string name, double value)
	{
		return xd6b6ed77479ef68c(name, value);
	}

	internal override DocumentPropertyCollection xebcf83b00134300b()
	{
		return new CustomDocumentProperties();
	}
}
