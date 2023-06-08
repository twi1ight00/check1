using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoMapper;

public interface IDelegateFactory
{
	LateBoundMethod CreateGet(MethodInfo method);

	LateBoundPropertyGet CreateGet(PropertyInfo property);

	LateBoundFieldGet CreateGet(FieldInfo field);

	LateBoundFieldSet CreateSet(FieldInfo field);

	LateBoundPropertySet CreateSet(PropertyInfo property);

	LateBoundCtor CreateCtor(Type type);

	LateBoundParamsCtor CreateCtor(ConstructorInfo constructorInfo, IEnumerable<ConstructorParameterMap> ctorParams);
}
