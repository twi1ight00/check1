using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Practices.ServiceLocation.Properties;

namespace Microsoft.Practices.ServiceLocation;

/// <summary>
/// This class is a helper that provides a default implementation
/// for most of the methods of <see cref="T:Microsoft.Practices.ServiceLocation.IServiceLocator" />.
/// </summary>
public abstract class ServiceLocatorImplBase : IServiceLocator, IServiceProvider
{
	[CompilerGenerated]
	private sealed class _003CGetAllInstances_003Ed__0<TService> : IEnumerable<TService>, IEnumerable, IEnumerator<TService>, IEnumerator, IDisposable
	{
		private TService _003C_003E2__current;

		private int _003C_003E1__state;

		public ServiceLocatorImplBase _003C_003E4__this;

		public object _003Citem_003E5__1;

		public IEnumerator<object> _003C_003E7__wrap2;

		TService IEnumerator<TService>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		IEnumerator<TService> IEnumerable<TService>.GetEnumerator()
		{
			return (Interlocked.CompareExchange(ref _003C_003E1__state, 0, -2) != -2) ? new _003CGetAllInstances_003Ed__0<TService>(0)
			{
				_003C_003E4__this = _003C_003E4__this
			} : this;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<TService>)this).GetEnumerator();
		}

		private bool MoveNext()
		{
			try
			{
				switch (_003C_003E1__state)
				{
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap2 = _003C_003E4__this.GetAllInstances(typeof(TService)).GetEnumerator();
					_003C_003E1__state = 1;
					goto IL_0082;
				case 2:
					{
						_003C_003E1__state = 1;
						goto IL_0082;
					}
					IL_0082:
					if (_003C_003E7__wrap2.MoveNext())
					{
						_003Citem_003E5__1 = _003C_003E7__wrap2.Current;
						_003C_003E2__current = (TService)_003Citem_003E5__1;
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003E1__state = -1;
					if (_003C_003E7__wrap2 != null)
					{
						_003C_003E7__wrap2.Dispose();
					}
					break;
				}
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		void IDisposable.Dispose()
		{
			switch (_003C_003E1__state)
			{
			case 1:
			case 2:
				try
				{
					break;
				}
				finally
				{
					_003C_003E1__state = -1;
					if (_003C_003E7__wrap2 != null)
					{
						_003C_003E7__wrap2.Dispose();
					}
				}
			}
		}

		[DebuggerHidden]
		public _003CGetAllInstances_003Ed__0(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}
	}

	/// <summary>
	/// Implementation of <see cref="M:System.IServiceProvider.GetService(System.Type)" />.
	/// </summary>
	/// <param name="serviceType">The requested service.</param>
	/// <exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is an error in resolving the service instance.</exception>
	/// <returns>The requested object.</returns>
	public virtual object GetService(Type serviceType)
	{
		return GetInstance(serviceType, null);
	}

	/// <summary>
	/// Get an instance of the given <paramref name="serviceType" />.
	/// </summary>
	/// <param name="serviceType">Type of object requested.</param>
	/// <exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is an error resolving
	/// the service instance.</exception>
	/// <returns>The requested service instance.</returns>
	public virtual object GetInstance(Type serviceType)
	{
		return GetInstance(serviceType, null);
	}

	/// <summary>
	/// Get an instance of the given named <paramref name="serviceType" />.
	/// </summary>
	/// <param name="serviceType">Type of object requested.</param>
	/// <param name="key">Name the object was registered with.</param>
	/// <exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is an error resolving
	/// the service instance.</exception>
	/// <returns>The requested service instance.</returns>
	public virtual object GetInstance(Type serviceType, string key)
	{
		try
		{
			return DoGetInstance(serviceType, key);
		}
		catch (Exception ex)
		{
			throw new ActivationException(FormatActivationExceptionMessage(ex, serviceType, key), ex);
		}
	}

	/// <summary>
	/// Get all instances of the given <paramref name="serviceType" /> currently
	/// registered in the container.
	/// </summary>
	/// <param name="serviceType">Type of object requested.</param>
	/// <exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is are errors resolving
	/// the service instance.</exception>
	/// <returns>A sequence of instances of the requested <paramref name="serviceType" />.</returns>
	public virtual IEnumerable<object> GetAllInstances(Type serviceType)
	{
		try
		{
			return DoGetAllInstances(serviceType);
		}
		catch (Exception ex)
		{
			throw new ActivationException(FormatActivateAllExceptionMessage(ex, serviceType), ex);
		}
	}

	/// <summary>
	/// Get an instance of the given <typeparamref name="TService" />.
	/// </summary>
	/// <typeparam name="TService">Type of object requested.</typeparam>
	/// <exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is are errors resolving
	/// the service instance.</exception>
	/// <returns>The requested service instance.</returns>
	public virtual TService GetInstance<TService>()
	{
		return (TService)GetInstance(typeof(TService), null);
	}

	/// <summary>
	/// Get an instance of the given named <typeparamref name="TService" />.
	/// </summary>
	/// <typeparam name="TService">Type of object requested.</typeparam>
	/// <param name="key">Name the object was registered with.</param>
	/// <exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is are errors resolving
	/// the service instance.</exception>
	/// <returns>The requested service instance.</returns>
	public virtual TService GetInstance<TService>(string key)
	{
		return (TService)GetInstance(typeof(TService), key);
	}

	/// <summary>
	/// Get all instances of the given <typeparamref name="TService" /> currently
	/// registered in the container.
	/// </summary>
	/// <typeparam name="TService">Type of object requested.</typeparam>
	/// <exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is are errors resolving
	/// the service instance.</exception>
	/// <returns>A sequence of instances of the requested <typeparamref name="TService" />.</returns>
	public virtual IEnumerable<TService> GetAllInstances<TService>()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		_003CGetAllInstances_003Ed__0<TService> _003CGetAllInstances_003Ed__ = new _003CGetAllInstances_003Ed__0<TService>(-2);
		_003CGetAllInstances_003Ed__._003C_003E4__this = this;
		return _003CGetAllInstances_003Ed__;
	}

	/// <summary>
	/// When implemented by inheriting classes, this method will do the actual work of resolving
	/// the requested service instance.
	/// </summary>
	/// <param name="serviceType">Type of instance requested.</param>
	/// <param name="key">Name of registered service you want. May be null.</param>
	/// <returns>The requested service instance.</returns>
	protected abstract object DoGetInstance(Type serviceType, string key);

	/// <summary>
	/// When implemented by inheriting classes, this method will do the actual work of
	/// resolving all the requested service instances.
	/// </summary>
	/// <param name="serviceType">Type of service requested.</param>
	/// <returns>Sequence of service instance objects.</returns>
	protected abstract IEnumerable<object> DoGetAllInstances(Type serviceType);

	/// <summary>
	/// Format the exception message for use in an <see cref="T:Microsoft.Practices.ServiceLocation.ActivationException" />
	/// that occurs while resolving a single service.
	/// </summary>
	/// <param name="actualException">The actual exception thrown by the implementation.</param>
	/// <param name="serviceType">Type of service requested.</param>
	/// <param name="key">Name requested.</param>
	/// <returns>The formatted exception message string.</returns>
	protected virtual string FormatActivationExceptionMessage(Exception actualException, Type serviceType, string key)
	{
		return string.Format(CultureInfo.CurrentUICulture, Resources.ActivationExceptionMessage, serviceType.Name, key);
	}

	/// <summary>
	/// Format the exception message for use in an <see cref="T:Microsoft.Practices.ServiceLocation.ActivationException" />
	/// that occurs while resolving multiple service instances.
	/// </summary>
	/// <param name="actualException">The actual exception thrown by the implementation.</param>
	/// <param name="serviceType">Type of service requested.</param>
	/// <returns>The formatted exception message string.</returns>
	protected virtual string FormatActivateAllExceptionMessage(Exception actualException, Type serviceType)
	{
		return string.Format(CultureInfo.CurrentUICulture, Resources.ActivateAllExceptionMessage, serviceType.Name);
	}
}
