using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7600 : Class7456
{
	private static readonly Type type_0 = typeof(Class7087);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_11("lineNumber", Enum983.flag_0);
		method_11("columnNumber", Enum983.flag_0);
		method_11("byteOffset", Enum983.flag_0);
		method_11("utf16Offset", Enum983.flag_0);
		method_11("relatedNode", Enum983.flag_0);
		method_11("uri", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7087 @class = (Class7087)instance.Value;
		switch (function)
		{
		case "get_lineNumber":
			return method_5(@class.LineNumber);
		case "get_columnNumber":
			return method_5(@class.ColumnNumber);
		case "get_byteOffset":
			return method_5(@class.ByteOffset);
		case "get_utf16Offset":
			return method_5(@class.Utf16Offset);
		case "get_relatedNode":
		{
			Class6976 relatedNode = @class.RelatedNode;
			if (relatedNode == null)
			{
				return base.Undefined;
			}
			return method_2(relatedNode, relatedNode.GetType());
		}
		default:
			throw new Exception89("unknown function");
		case "get_uri":
			return method_3(@class.Uri);
		}
	}
}
