using System;
using System.IO;
using Quartz.Spi;

namespace Quartz.Simpl;

/// <summary> 
/// A <see cref="T:Quartz.Spi.ITypeLoadHelper" /> that simply calls <see cref="M:System.Type.GetType(System.String)" />.
/// </summary>
/// <seealso cref="T:Quartz.Spi.ITypeLoadHelper" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class SimpleTypeLoadHelper : ITypeLoadHelper
{
	/// <summary> 
	/// Called to give the ClassLoadHelper a chance to Initialize itself,
	/// including the oportunity to "steal" the class loader off of the calling
	/// thread, which is the thread that is initializing Quartz.
	/// </summary>
	public virtual void Initialize()
	{
	}

	/// <summary> Return the class with the given name.</summary>
	public virtual Type LoadType(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		return Type.GetType(name, throwOnError: true);
	}

	/// <summary>
	/// Finds a resource with a given name. This method returns null if no
	/// resource with this name is found.
	/// </summary>
	/// <param name="name">name of the desired resource
	/// </param>
	/// <returns> a Uri object</returns>
	public virtual Uri GetResource(string name)
	{
		return null;
	}

	/// <summary>
	/// Finds a resource with a given name. This method returns null if no
	/// resource with this name is found.
	/// </summary>
	/// <param name="name">name of the desired resource
	/// </param>
	/// <returns> a Stream object
	/// </returns>
	public virtual Stream GetResourceAsStream(string name)
	{
		return null;
	}
}
