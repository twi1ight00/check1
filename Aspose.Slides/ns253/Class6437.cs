namespace ns253;

internal class Class6437 : Interface298
{
	private Class6434 class6434_0;

	private Class6445 class6445_0;

	public Class6434 Paragraph => class6434_0;

	public Class6445 RunProperties
	{
		get
		{
			if (class6445_0 == null)
			{
				class6445_0 = new Class6445();
			}
			return class6445_0;
		}
	}

	public virtual void imethod_0(Class6434 paragraph)
	{
		class6434_0 = paragraph;
		RunProperties.method_0(paragraph.Properties.DefaultRunProperties);
	}
}
