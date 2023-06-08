using Aspose.Words;
using Aspose.Words.Fields;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal class x82c8201fae256a59 : Field
{
	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		FormField formField = (FormField)base.Start.x03a9a1b8afdf52f9(NodeType.FormField);
		switch (formField.TextInputType)
		{
		case TextFormFieldType.CurrentDate:
		case TextFormFieldType.CurrentTime:
			base.Result = x93041bc169c6692b();
			break;
		case TextFormFieldType.Calculated:
		{
			string text = x93041bc169c6692b();
			double num = xca004f56614e2431.xf5ece46c5d72e3b9(text);
			if (!double.IsNaN(num))
			{
				base.Result = xca004f56614e2431.x3fefcbaee4514358(num, formField.TextInputFormat, x5c4c72022ea54b2c: true);
			}
			else
			{
				base.Result = text;
			}
			break;
		}
		}
		return null;
	}

	private string x93041bc169c6692b()
	{
		FieldStart fieldStart = (FieldStart)base.Start.x03a9a1b8afdf52f9(NodeType.FieldStart);
		FieldSeparator fieldSeparator = (FieldSeparator)fieldStart.x03a9a1b8afdf52f9(NodeType.FieldSeparator);
		FieldEnd xca09b6c2b5b = (FieldEnd)fieldSeparator.x03a9a1b8afdf52f9(NodeType.FieldEnd);
		Field field = x3759c06a3a4cf5d1.x43fef3435fba7a66(fieldStart, fieldSeparator, xca09b6c2b5b);
		field.Update();
		return field.Result;
	}
}
