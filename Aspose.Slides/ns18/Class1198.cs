using System.Xml;
using Aspose.Slides;
using ns16;
using ns24;
using ns53;
using ns56;

namespace ns18;

internal class Class1198 : Class1188
{
	internal void method_5(IPresentation presentation)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "cmAuthorLst")
			{
				Class2140 @class = new Class2140(base.XmlPartReader);
				Class2225[] cmAuthorList = @class.CmAuthorList;
				for (int i = 0; i < cmAuthorList.Length; i++)
				{
					ICommentAuthor author = presentation.CommentAuthors.AddAuthor(cmAuthorList[i].Name, cmAuthorList[i].Initials);
					method_6(author, cmAuthorList[i]);
				}
			}
		}
		method_2();
	}

	private void method_6(ICommentAuthor author, Class2225 authorElementData)
	{
		Class331 pPTXUnsupportedProps = ((CommentAuthor)author).PPTXUnsupportedProps;
		pPTXUnsupportedProps.Id = authorElementData.Id;
		base.DeserializationContext.CommentAuthorXmlIdToCommentAuthor.Add(authorElementData.Id, author);
		pPTXUnsupportedProps.ColorIndex = (int)authorElementData.ClrIdx;
		pPTXUnsupportedProps.ExtensionList = authorElementData.ExtLst;
	}

	internal void method_7(IPresentation presentation)
	{
		method_3();
		Class2140 @class = new Class2140();
		int maxClrIndex = 0;
		foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
		{
			Class2225 class2 = @class.delegate2411_0();
			class2.Name = commentAuthor.Name;
			class2.Initials = commentAuthor.Initials;
			method_8(commentAuthor, class2, ref maxClrIndex);
		}
		@class.vmethod_4(null, base.XmlPartWriter, "cmAuthorLst");
		method_4();
	}

	private void method_8(ICommentAuthor author, Class2225 cmAuthorElementData, ref int maxClrIndex)
	{
		Class331 pPTXUnsupportedProps = ((CommentAuthor)author).PPTXUnsupportedProps;
		cmAuthorElementData.Id = pPTXUnsupportedProps.Id;
		int num = pPTXUnsupportedProps.ColorIndex;
		if (num < 0)
		{
			num = maxClrIndex + 1;
		}
		if (num > maxClrIndex)
		{
			maxClrIndex = num;
		}
		cmAuthorElementData.ClrIdx = (uint)num;
		cmAuthorElementData.LastIdx = pPTXUnsupportedProps.LastIndex;
		cmAuthorElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}

	public Class1198(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1198(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
