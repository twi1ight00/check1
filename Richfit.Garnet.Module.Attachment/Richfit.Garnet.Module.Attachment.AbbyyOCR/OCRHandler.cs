using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using FREngine;
using Richfit.Garnet.Common.Logging;

namespace Richfit.Garnet.Module.Attachment.AbbyyOCR;

public class OCRHandler : BaseHandler
{
	public delegate void TraceHandler(object message);

	private string TextLanguage = "ChinesePRC+English";

	private string OCRDir = ConfigurationManager.AppSettings["OCRFilePath"];

	private ILogger log = LoggerManager.GetLogger();

	private EnginesPool enginesPool;

	private object isCancelledLock;

	private bool isCancelled;

	private TraceHandler traceHandler;

	private Guid threadId = Guid.NewGuid();

	public OCRHandler(TraceHandler handler)
	{
		isCancelledLock = new object();
		isCancelled = false;
		if (handler != null)
		{
			traceHandler = handler;
		}
		else
		{
			traceHandler = log.Info;
		}
		try
		{
			enginesPool = EnginPoolManager.Instance.Pool;
		}
		catch (Exception exp)
		{
			progress.OperationText = "识别引擎异常：" + exp.Message;
			progress.Percentage = 0;
			traceHandler(exp);
		}
	}

	public void Cancel()
	{
		lock (isCancelledLock)
		{
			isCancelled = true;
		}
	}

	public bool IsCancelled()
	{
		lock (isCancelledLock)
		{
			return isCancelled;
		}
	}

	public string doWork(IList<string> imageSource, string resultFilePath, int pageCount)
	{
		traceHandler("Thread " + threadId.ToString() + " started");
		if (enginesPool == null)
		{
			progress.Percentage = 100;
			progress.OperationText = "识别引擎异常，请联系运维项目组！";
			return "识别引擎异常，请联系运维项目组";
		}
		try
		{
			return processImageFile(imageSource, resultFilePath, pageCount);
		}
		catch (Exception exception)
		{
			progress.Percentage = 100;
			progress.OperationText = "识别过程异常！" + exception.Message;
			traceHandler("Thread " + threadId.ToString() + " ERROR: \"" + exception.Message + "\" during processing image file ");
			return "识别过程异常！" + exception.Message;
		}
	}

	public IList<int> getAmountAndRemains()
	{
		bool isRecycleRequired = false;
		IList<int> keyList = new List<int>();
		IEngine engine = enginesPool.GetEngine();
		try
		{
			if (engine == null)
			{
				throw new Exception("识别引擎获取失败，请重试！");
			}
			int amount = engine.CurrentLicense.get_Volume(LicenseCounterTypeEnum.LCT_Pages);
			int remains = engine.CurrentLicense.get_VolumeRemaining(LicenseCounterTypeEnum.LCT_Pages);
			keyList.Add(amount);
			keyList.Add(remains);
			return keyList;
		}
		finally
		{
			enginesPool.ReleaseEngine(engine, isRecycleRequired);
		}
	}

	private string processImageFile(IList<string> imageSource, string resultFilePath, int pageCount)
	{
		bool isRecycleRequired = false;
		progress.OperationText = "正在装载识别驱动";
		progress.Percentage = 0;
		IEngine engine = enginesPool.GetEngine();
		try
		{
			if (engine == null)
			{
				throw new Exception("识别引擎获取失败，请重试！");
			}
			int remains = engine.CurrentLicense.get_VolumeRemaining(LicenseCounterTypeEnum.LCT_Pages);
			if (remains < pageCount)
			{
				progress.Percentage = 100;
				progress.OperationText = "剩余识别额度不足,请联系运维人员!";
				return "剩余识别额度不足,请联系运维人员!";
			}
			FRDocument frDocument = engine.CreateFRDocument();
			try
			{
				DIFRDocumentEvents_OnProgressEventHandler loadImageOnProgressHandler = frDocument_LoadImageOnProgress;
				DIFRDocumentEvents_OnProgressEventHandler recognizeOnPreProgressHandler = frDocument_OnPreProgress;
				DIFRDocumentEvents_OnProgressEventHandler recognizeOnProgressHandler = frDocument_OnProgress;
				new ComAwareEventInfo(typeof(DIFRDocumentEvents_Event), "OnProgress").AddEventHandler(frDocument, loadImageOnProgressHandler);
				foreach (string img in imageSource)
				{
					if (File.Exists(img))
					{
						frDocument.AddImageFile(img);
						continue;
					}
					traceHandler("Thread " + threadId.ToString() + " ERROR: " + img + "不存在！");
				}
				new ComAwareEventInfo(typeof(DIFRDocumentEvents_Event), "OnProgress").RemoveEventHandler(frDocument, loadImageOnProgressHandler);
				engine.LoadPredefinedProfile("DocumentConversion_Accuracy");
				new ComAwareEventInfo(typeof(DIFRDocumentEvents_Event), "OnProgress").AddEventHandler(frDocument, recognizeOnPreProgressHandler);
				PagePreprocessingParams ppp = engine.CreatePagePreprocessingParams();
				ppp.CorrectInvertedImage = true;
				ppp.CorrectOrientation = true;
				ppp.OrientationDetectionParams = engine.CreateOrientationDetectionParams();
				ppp.OrientationDetectionParams.OrientationDetectionMode = OrientationDetectionModeEnum.ODM_Normal;
				RecognizerParams rp = engine.CreateRecognizerParams();
				rp.SetPredefinedTextLanguage(TextLanguage);
				frDocument.Preprocess(ppp, null, rp);
				new ComAwareEventInfo(typeof(DIFRDocumentEvents_Event), "OnProgress").RemoveEventHandler(frDocument, recognizeOnPreProgressHandler);
				new ComAwareEventInfo(typeof(DIFRDocumentEvents_Event), "OnProgress").AddEventHandler(frDocument, recognizeOnProgressHandler);
				DocumentProcessingParams dpp = engine.CreateDocumentProcessingParams();
				dpp.PageProcessingParams.RecognizerParams.SetPredefinedTextLanguage(TextLanguage);
				frDocument.Process(dpp);
				new ComAwareEventInfo(typeof(DIFRDocumentEvents_Event), "OnProgress").RemoveEventHandler(frDocument, recognizeOnProgressHandler);
				DIFRDocumentEvents_OnProgressEventHandler exportOnProgressHandler = frDocument_ExportOnProgress;
				new ComAwareEventInfo(typeof(DIFRDocumentEvents_Event), "OnProgress").AddEventHandler(frDocument, exportOnProgressHandler);
				RTFExportParams ep = engine.CreateRTFExportParams();
				ep.PageSynthesisMode = RTFPageSynthesisModeEnum.PSM_RTFFormatParagraphs;
				string result = "";
				for (int iPage = 0; iPage < frDocument.Pages.Count; iPage++)
				{
					IFRPage page = frDocument.Pages[iPage];
					ILayout layout = page.Layout;
					int blocksCount = layout.Blocks.Count;
					for (int iBlock = 0; iBlock < blocksCount; iBlock++)
					{
						IBlock block = layout.Blocks[iBlock];
						ITextBlock textBlock = block.GetAsTextBlock();
						int paragraphsCount = textBlock.Text.Paragraphs.Count;
						for (int iPar = 0; iPar < paragraphsCount; iPar++)
						{
							IParagraph par = textBlock.Text.Paragraphs[iPar];
							result += par.Text;
						}
					}
				}
				new ComAwareEventInfo(typeof(DIFRDocumentEvents_Event), "OnProgress").RemoveEventHandler(frDocument, exportOnProgressHandler);
				return result;
			}
			finally
			{
				frDocument.Close();
			}
		}
		catch (Exception exception)
		{
			throw exception;
		}
		finally
		{
			enginesPool.ReleaseEngine(engine, isRecycleRequired);
		}
	}

	private void frDocument_LoadImageOnProgress(FRDocument Sender, int Percentage, ref bool cancel)
	{
		int displayPercentage = ((Percentage == 100) ? (Percentage - 1) : Percentage);
		progress.OperationText = "正在加载文档中的图片，已完成" + displayPercentage + "%";
		progress.Percentage = displayPercentage;
		cancel = IsCancelled();
	}

	private void frDocument_OnPreProgress(FRDocument Sender, int Percentage, ref bool cancel)
	{
		int displayPercentage = ((Percentage == 100) ? (Percentage - 1) : Percentage);
		progress.OperationText = "正在预处理，已完成" + displayPercentage + "%";
		progress.Percentage = displayPercentage;
		cancel = IsCancelled();
	}

	private void frDocument_OnProgress(FRDocument Sender, int Percentage, ref bool cancel)
	{
		int displayPercentage = ((Percentage == 100) ? (Percentage - 1) : Percentage);
		progress.OperationText = "识别已完成" + displayPercentage + "%，请耐心等待";
		progress.Percentage = displayPercentage;
		cancel = IsCancelled();
	}

	private void frDocument_ExportOnProgress(FRDocument sender, int Percentage, ref bool cancel)
	{
		progress.OperationText = "正在导出，进度：" + Percentage + "%";
		progress.Percentage = Percentage;
		cancel = IsCancelled();
	}

	private static bool shouldRestartEngine(Exception exception)
	{
		if (exception is COMException comException)
		{
			switch ((uint)comException.ErrorCode)
			{
			case 2147944122u:
				return true;
			case 2147549445u:
				return true;
			}
		}
		if (exception is OutOfMemoryException)
		{
			return true;
		}
		return false;
	}
}
