namespace AutoMapper;

public interface IMemberAccessor : IMemberGetter, IMemberResolver, IValueResolver
{
	void SetValue(object destination, object value);
}
