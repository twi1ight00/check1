namespace Aspose.Words.Loading;

public class ResourceLoadingArgs
{
	private readonly ResourceType x34c2cccee28ab1a5;

	private byte[] x73f065a6b420cfe1;

	private string x85672ef2a158d360;

	private readonly string x70750298485be82e;

	public ResourceType ResourceType => x34c2cccee28ab1a5;

	public string Uri
	{
		get
		{
			return x85672ef2a158d360;
		}
		set
		{
			x85672ef2a158d360 = value;
		}
	}

	public string OriginalUri => x70750298485be82e;

	internal ResourceLoadingArgs(string absoluteUri, string originalUri, ResourceType resourceType)
	{
		x70750298485be82e = originalUri;
		x34c2cccee28ab1a5 = resourceType;
		x85672ef2a158d360 = absoluteUri;
	}

	public void SetData(byte[] data)
	{
		x73f065a6b420cfe1 = data;
	}

	internal byte[] xd378208b5267f7e2()
	{
		return x73f065a6b420cfe1;
	}
}
