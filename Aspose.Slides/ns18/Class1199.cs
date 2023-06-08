using System;
using System.Drawing;
using System.Xml;
using Aspose.Slides;
using ns16;
using ns24;
using ns53;
using ns56;

namespace ns18;

internal class Class1199 : Class1188
{
	internal void method_5(Slide slide)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType != XmlNodeType.Element || !(base.XmlPartReader.LocalName == "cmLst"))
			{
				continue;
			}
			Class2141 @class = new Class2141(base.XmlPartReader);
			Class2226[] cmList = @class.CmList;
			foreach (Class2226 class2 in cmList)
			{
				base.DeserializationContext.CommentAuthorXmlIdToCommentAuthor.TryGetValue(class2.AuthorId, out var value);
				if (value != null)
				{
					IComment comment = slide.AddComment(value, class2.Text, new PointF((float)class2.Pos.X, (float)class2.Pos.Y));
					comment.CreatedTime = class2.Dt;
					method_6(comment, class2);
					continue;
				}
				throw new Exception("Comment by nonexistent author. AuthorId = " + class2.AuthorId + ".");
			}
		}
		method_2();
	}

	private void method_6(IComment comment, Class2226 cm)
	{
		Class332 pPTXUnsupportedProps = ((Comment)comment).PPTXUnsupportedProps;
		pPTXUnsupportedProps.Idx = cm.Idx;
		pPTXUnsupportedProps.ExtensionList = cm.ExtLst;
	}

	internal void method_7(IComment[] slideComments)
	{
		method_3();
		Class2141 @class = new Class2141();
		foreach (IComment comment in slideComments)
		{
			Class2226 class2 = @class.delegate2414_0();
			class2.Pos.X = comment.Position.X;
			class2.Pos.Y = comment.Position.Y;
			class2.Text = comment.Text;
			class2.AuthorId = ((CommentAuthor)comment.Author).PPTXUnsupportedProps.Id;
			class2.Dt = comment.CreatedTime;
			method_8(comment, class2);
		}
		@class.vmethod_4(null, base.XmlPartWriter, "cmLst");
		method_4();
	}

	private void method_8(IComment comment, Class2226 cm)
	{
		Class332 pPTXUnsupportedProps = ((Comment)comment).PPTXUnsupportedProps;
		cm.Idx = pPTXUnsupportedProps.Idx;
		cm.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}

	public Class1199(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1199(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
