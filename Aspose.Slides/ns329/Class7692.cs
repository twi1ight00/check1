using System;
using Aspose.JavaScript;
using ns328;

namespace ns329;

internal class Class7692 : Class7691
{
	public override string vmethod_0(Enum @enum)
	{
		return (BinaryExpressionType)(object)@enum switch
		{
			BinaryExpressionType.And => "And", 
			BinaryExpressionType.Or => "Or", 
			BinaryExpressionType.NotEqual => "NotEqual", 
			BinaryExpressionType.LesserOrEqual => "LesserOrEqual", 
			BinaryExpressionType.GreaterOrEqual => "GreaterOrEqual", 
			BinaryExpressionType.Lesser => "Lesser", 
			BinaryExpressionType.Greater => "Greater", 
			BinaryExpressionType.Equal => "Equal", 
			BinaryExpressionType.Minus => "Minus", 
			BinaryExpressionType.Plus => "Plus", 
			BinaryExpressionType.Modulo => "Modulo", 
			BinaryExpressionType.Div => "Div", 
			BinaryExpressionType.Times => "Times", 
			BinaryExpressionType.Pow => "Pow", 
			BinaryExpressionType.BitwiseAnd => "BitwiseAnd", 
			BinaryExpressionType.BitwiseOr => "BitwiseOr", 
			BinaryExpressionType.BitwiseXOr => "BitwiseXOr", 
			BinaryExpressionType.Same => "Same", 
			BinaryExpressionType.NotSame => "NotSame", 
			BinaryExpressionType.LeftShift => "LeftShift", 
			BinaryExpressionType.RightShift => "RightShift", 
			BinaryExpressionType.UnsignedRightShift => "UnsignedRightShift", 
			BinaryExpressionType.InstanceOf => "InstanceOf", 
			BinaryExpressionType.In => "In", 
			BinaryExpressionType.Unknown => "Unknown", 
			_ => throw new ArgumentException(), 
		};
	}
}
