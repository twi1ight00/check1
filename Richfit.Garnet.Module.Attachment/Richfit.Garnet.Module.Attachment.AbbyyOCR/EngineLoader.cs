using System;
using System.IO;
using System.Runtime.InteropServices;
using FREngine;
using Richfit.Garnet.Common.Logging;

namespace Richfit.Garnet.Module.Attachment.AbbyyOCR;

public class EngineLoader : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode)]
	private delegate int GetEngineObject(string devSN, ref IEngine engine);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int DeinitializeEngine();

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int DllCanUnloadNow();

	private const uint LOAD_WITH_ALTERED_SEARCH_PATH = 8u;

	private ILogger log = LoggerManager.GetLogger();

	private IEngine engine = null;

	private IntPtr dllHandle = IntPtr.Zero;

	private GetEngineObject getEngineObject = null;

	private DeinitializeEngine deinitializeEngine = null;

	private DllCanUnloadNow dllCanUnloadNow = null;

	public IEngine Engine => engine;

	public EngineLoader(string developerSN)
	{
		string enginePath = Path.Combine(FreConfig.GetDllFolder(), "FREngine.dll");
		dllHandle = LoadLibraryEx(enginePath, IntPtr.Zero, 8u);
		IntPtr i = GetLastError();
		try
		{
			if (dllHandle == IntPtr.Zero)
			{
				throw new Exception("Can't load " + enginePath);
			}
			IntPtr getEngineObjectPtr = GetProcAddress(dllHandle, "GetEngineObject");
			if (getEngineObjectPtr == IntPtr.Zero)
			{
				throw new Exception("Can't find GetEngineObject function");
			}
			IntPtr deinitializeEnginePtr = GetProcAddress(dllHandle, "DeinitializeEngine");
			if (deinitializeEnginePtr == IntPtr.Zero)
			{
				throw new Exception("Can't find DeinitializeEngine function");
			}
			IntPtr dllCanUnloadNowPtr = GetProcAddress(dllHandle, "DllCanUnloadNow");
			if (dllCanUnloadNowPtr == IntPtr.Zero)
			{
				throw new Exception("Can't find DllCanUnloadNow function");
			}
			getEngineObject = (GetEngineObject)Marshal.GetDelegateForFunctionPointer(getEngineObjectPtr, typeof(GetEngineObject));
			deinitializeEngine = (DeinitializeEngine)Marshal.GetDelegateForFunctionPointer(deinitializeEnginePtr, typeof(DeinitializeEngine));
			dllCanUnloadNow = (DllCanUnloadNow)Marshal.GetDelegateForFunctionPointer(dllCanUnloadNowPtr, typeof(DllCanUnloadNow));
			int hresult = getEngineObject(developerSN, ref engine);
			Marshal.ThrowExceptionForHR(hresult);
		}
		catch (Exception exp)
		{
			engine = null;
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
			FreeLibrary(dllHandle);
			dllHandle = IntPtr.Zero;
			getEngineObject = null;
			deinitializeEngine = null;
			dllCanUnloadNow = null;
			log.Error(exp);
			throw;
		}
	}

	public void Dispose()
	{
		if (engine != null)
		{
			engine = null;
			int hresult = deinitializeEngine();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
			hresult = dllCanUnloadNow();
			if (hresult == 0)
			{
				FreeLibrary(dllHandle);
			}
			dllHandle = IntPtr.Zero;
			getEngineObject = null;
			deinitializeEngine = null;
			dllCanUnloadNow = null;
			Marshal.ThrowExceptionForHR(hresult);
		}
	}

	[DllImport("kernel32.dll")]
	private static extern IntPtr GetLastError();

	[DllImport("kernel32.dll")]
	private static extern IntPtr LoadLibraryEx(string dllToLoad, IntPtr reserved, uint flags);

	[DllImport("kernel32.dll")]
	private static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

	[DllImport("kernel32.dll")]
	private static extern bool FreeLibrary(IntPtr hModule);
}
