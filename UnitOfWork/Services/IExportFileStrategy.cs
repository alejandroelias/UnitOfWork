using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitOfWork.Services
{
    public interface IExportFileStrategy
    {
        void ExportFile();
    }

    public class ExportFileExcelStrategy : IExportFileStrategy
    {
        public void ExportFile()
        {
            //Logica para exportacion a excel
            Console.WriteLine("Exportar a formato excel");
        }
    }

    public class ExportFilePDFStrategy : IExportFileStrategy
    {
        public void ExportFile()
        {
            //Logica para exportacion a PDF
            Console.WriteLine("Exportar a formato PDF");
        }
    }

    //Context
    public class ExportFileAnyFormat
    {
        private IExportFileStrategy _exportFileStrategy;
        public IExportFileStrategy ExportFileStrategy { set => _exportFileStrategy = value; }
        public ExportFileAnyFormat(IExportFileStrategy exportFileStrategy) => _exportFileStrategy = exportFileStrategy;

        public void ExportFile() => _exportFileStrategy.ExportFile();

    }


}