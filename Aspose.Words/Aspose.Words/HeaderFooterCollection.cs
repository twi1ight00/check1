using System;
using System.Collections;

namespace Aspose.Words;

[JavaGenericArguments("NodeCollection<HeaderFooter>")]
public class HeaderFooterCollection : NodeCollection
{
	public new HeaderFooter this[int index] => (HeaderFooter)base[index];

	public HeaderFooter this[HeaderFooterType headerFooterType]
	{
		get
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					HeaderFooter headerFooter = (HeaderFooter)enumerator.Current;
					if (headerFooter.HeaderFooterType == headerFooterType)
					{
						return headerFooter;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return null;
		}
	}

	internal HeaderFooterCollection(CompositeNode parent)
		: base(parent, NodeType.HeaderFooter, isDeep: false)
	{
	}

	public void LinkToPrevious(bool isLinkToPrevious)
	{
		LinkToPrevious(HeaderFooterType.HeaderPrimary, isLinkToPrevious);
		LinkToPrevious(HeaderFooterType.HeaderFirst, isLinkToPrevious);
		LinkToPrevious(HeaderFooterType.HeaderEven, isLinkToPrevious);
		LinkToPrevious(HeaderFooterType.FooterPrimary, isLinkToPrevious);
		LinkToPrevious(HeaderFooterType.FooterFirst, isLinkToPrevious);
		LinkToPrevious(HeaderFooterType.FooterEven, isLinkToPrevious);
	}

	public void LinkToPrevious(HeaderFooterType headerFooterType, bool isLinkToPrevious)
	{
		HeaderFooter headerFooter = this[headerFooterType];
		if (headerFooter == null)
		{
			headerFooter = new HeaderFooter(base.xc255c495fd9232ca.Document, headerFooterType);
			Add(headerFooter);
		}
		headerFooter.IsLinkedToPrevious = isLinkToPrevious;
	}

	public new HeaderFooter[] ToArray()
	{
		return (HeaderFooter[])x8a2b4876a80a0afd().ToArray(typeof(HeaderFooter));
	}
}
