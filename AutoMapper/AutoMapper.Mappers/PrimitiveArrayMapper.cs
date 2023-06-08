using System;

namespace AutoMapper.Mappers;

public class PrimitiveArrayMapper : IObjectMapper
{
	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		if (context.IsSourceValueNull && mapper.ShouldMapSourceCollectionAsNull(context))
		{
			return null;
		}
		Type elementType = TypeHelper.GetElementType(context.SourceType);
		Type elementType2 = TypeHelper.GetElementType(context.DestinationType);
		Array array = ((Array)context.SourceValue) ?? ObjectCreator.CreateArray(elementType, 0);
		int length = array.Length;
		Array array2 = ObjectCreator.CreateArray(elementType2, length);
		Array.Copy(array, array2, length);
		return array2;
	}

	private bool IsPrimitiveArrayType(Type type)
	{
		if (type.IsArray)
		{
			Type elementType = TypeHelper.GetElementType(type);
			if (!elementType.IsPrimitive)
			{
				return elementType.Equals(typeof(string));
			}
			return true;
		}
		return false;
	}

	public bool IsMatch(ResolutionContext context)
	{
		if (IsPrimitiveArrayType(context.DestinationType) && IsPrimitiveArrayType(context.SourceType))
		{
			return TypeHelper.GetElementType(context.DestinationType).Equals(TypeHelper.GetElementType(context.SourceType));
		}
		return false;
	}
}
