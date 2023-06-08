using Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

namespace Richfit.Garnet.Module.ImportingAndExporting.Application.Services.Export;

public interface IExport
{
	string Export(ExportDTO parameter);
}
