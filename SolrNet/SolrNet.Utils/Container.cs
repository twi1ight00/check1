using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;

namespace SolrNet.Utils;

/// <summary>
/// Basic built-in dependency-injection container
/// </summary>
public class Container : ServiceLocatorImplBase, IContainer, IServiceLocator, IServiceProvider
{
	private readonly Dictionary<string, Converter<IContainer, object>> componentsByName = new Dictionary<string, Converter<IContainer, object>>();

	private readonly Dictionary<Type, List<Converter<IContainer, object>>> componentsByType = new Dictionary<Type, List<Converter<IContainer, object>>>();

	public Container()
	{
	}

	/// <summary>
	/// Creates a new container copying all components from another container
	/// </summary>
	/// <param name="c"></param>
	public Container(Container c)
	{
		componentsByName = new Dictionary<string, Converter<IContainer, object>>(c.componentsByName);
		foreach (KeyValuePair<Type, List<Converter<IContainer, object>>> t in c.componentsByType)
		{
			componentsByType[t.Key] = new List<Converter<IContainer, object>>(t.Value);
		}
	}

	protected override object DoGetInstance(Type serviceType, string key)
	{
		if (key == null)
		{
			return componentsByType[serviceType][0](this);
		}
		return componentsByName[key](this);
	}

	protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
	{
		if (!componentsByType.ContainsKey(serviceType))
		{
			yield break;
		}
		foreach (Converter<IContainer, object> c in componentsByType[serviceType])
		{
			yield return c(this);
		}
	}

	/// <summary>
	/// Adds a component implementing <typeparamref name="T" />
	/// Component key is <typeparamref name="T" />'s <see cref="P:System.Type.FullName" />
	/// </summary>
	/// <typeparam name="T">Service type</typeparam>
	/// <param name="factory">Component factory method</param>
	public void Register<T>(Converter<IContainer, T> factory)
	{
		Register(typeof(T).FullName, typeof(T), (IContainer c) => factory(c));
	}

	/// <summary>
	/// Adds a component implementing <typeparamref name="T" /> with the specified key
	/// </summary>
	/// <typeparam name="T">Service type</typeparam>
	/// <param name="factory">Component factory method</param>
	/// <param name="key">Component key</param>
	public void Register<T>(string key, Converter<IContainer, T> factory)
	{
		Register(key, typeof(T), (IContainer c) => factory(c));
	}

	/// <summary>
	/// Adds a component
	/// </summary>
	/// <param name="key">Component key</param>
	/// <param name="serviceType">Component service type</param>
	/// <param name="factory">Component factory method. Must return <paramref name="serviceType" /> or a descendant</param>
	public void Register(string key, Type serviceType, Converter<IContainer, object> factory)
	{
		if (componentsByName.ContainsKey(key))
		{
			throw new ApplicationException($"Key '{key}' already registered in container");
		}
		componentsByName[key] = factory;
		if (!componentsByType.ContainsKey(serviceType))
		{
			componentsByType[serviceType] = new List<Converter<IContainer, object>>();
		}
		componentsByType[serviceType].Add(factory);
	}

	/// <summary>
	/// Removes all components with service type <typeparamref name="T" />
	/// </summary>
	/// <typeparam name="T">Service type</typeparam>
	public void RemoveAll<T>()
	{
		if (!componentsByType.ContainsKey(typeof(T)))
		{
			return;
		}
		foreach (Converter<IContainer, object> c in componentsByType[typeof(T)])
		{
			List<string> removeList = new List<string>();
			foreach (KeyValuePair<string, Converter<IContainer, object>> cn in componentsByName)
			{
				if (cn.Value == c)
				{
					removeList.Add(cn.Key);
				}
			}
			removeList.ForEach(delegate(string k)
			{
				componentsByName.Remove(k);
			});
		}
		componentsByType[typeof(T)].Clear();
	}

	/// <summary>
	/// Removes the default component for service type <typeparamref name="T" />
	/// </summary>
	/// <typeparam name="T">Service type</typeparam>
	public void Remove<T>()
	{
		Remove(typeof(T).FullName, typeof(T));
	}

	/// <summary>
	/// Removes the component with key <paramref name="key" /> implementing service type <typeparamref name="T" />
	/// </summary>
	/// <typeparam name="T">Service type</typeparam>
	/// <param name="key">Component key</param>
	public void Remove<T>(string key)
	{
		Remove(key, typeof(T));
	}

	/// <summary>
	/// Removes the component with key <paramref name="key" /> implementing service type <paramref name="serviceType" />
	/// </summary>
	/// <param name="key">Component key</param>
	/// <param name="serviceType">Service type</param>
	public void Remove(string key, Type serviceType)
	{
		Converter<IContainer, object> factory = componentsByName[key];
		componentsByName.Remove(key);
		componentsByType[serviceType].Remove(factory);
	}

	/// <summary>
	/// Removes all component registrations from this container
	/// </summary>
	public void Clear()
	{
		componentsByType.Clear();
		componentsByName.Clear();
	}
}
