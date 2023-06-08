using Quartz.Util;

namespace Quartz;

/// <summary>
/// Matchers can be used in various <see cref="T:Quartz.IScheduler" /> API methods to 
/// select the entities that should be operated upon.
/// </summary>
/// <author>James House</author>
/// <typeparam name="T"></typeparam>
public interface IMatcher<T> where T : Key<T>
{
	bool IsMatch(T key);

	new int GetHashCode();

	new bool Equals(object obj);
}
