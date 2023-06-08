namespace x28925c9b27b37a46;

internal class xce798d32ec270dda : xb56968f92e308c8a
{
	internal xce798d32ec270dda(x7e263f21a73a027a range)
		: base(range)
	{
	}

	protected void x267efc5f6ada2866()
	{
		bool x0d900d42b3598fde = true;
		while (x1ef2c3be187f37a2(x0d900d42b3598fde))
		{
			if (base.x3387295f12854dfd.IsComposite)
			{
				if (!x2b1ee3a87b36a988.x1d96b06babfe1068(base.x7d2e50686d249839.x9fd888e65466818c.x40212106aad8a8b0, base.x3387295f12854dfd))
				{
					OnMiddleParentNode();
					x0d900d42b3598fde = false;
				}
				else
				{
					OnLastParentNode();
					x0d900d42b3598fde = true;
				}
			}
			else
			{
				OnChildNode();
				x0d900d42b3598fde = false;
			}
		}
	}

	protected virtual void OnMiddleParentNode()
	{
	}

	protected virtual void OnLastParentNode()
	{
	}

	protected virtual void OnChildNode()
	{
	}
}
