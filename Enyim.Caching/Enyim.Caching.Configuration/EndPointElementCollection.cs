using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net;

namespace Enyim.Caching.Configuration;

/// <summary>
/// Represents a collection of <see cref="T:EndPointElement" /> instances. This class cannot be inherited.
/// </summary>
public sealed class EndPointElementCollection : ConfigurationElementCollection
{
	/// <summary>
	/// Creates a new <see cref="T:ConfigurationElement" />.
	/// </summary>
	/// <returns>A new <see cref="T:ConfigurationElement" />.</returns>
	protected override ConfigurationElement CreateNewElement()
	{
		return new EndPointElement();
	}

	/// <summary>
	/// Gets the element key for a specified configuration element when overridden in a derived class.
	/// </summary>
	/// <param name="element">The <see cref="T:ConfigurationElement" /> to return the key for. </param>
	/// <returns>An <see cref="T:Object" /> that acts as the key for the specified <see cref="T:ConfigurationElement" />.</returns>
	protected override object GetElementKey(ConfigurationElement element)
	{
		EndPointElement ep = (EndPointElement)element;
		return ep.Address + ":" + ep.Port.ToString(CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Helper method; converts the collection into an <see cref="T:IPEndPoint" /> collection for the interface implementation.
	/// </summary>
	/// <returns></returns>
	public IList<IPEndPoint> ToIPEndPointCollection()
	{
		List<IPEndPoint> retval = new List<IPEndPoint>(base.Count);
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				EndPointElement e = (EndPointElement)enumerator.Current;
				retval.Add(e.EndPoint);
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
		return retval.AsReadOnly();
	}
}
