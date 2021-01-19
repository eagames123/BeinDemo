using System.IO;
using DiziFilm.Core;
using Microsoft.AspNetCore.Hosting;

namespace DiziFilm.Core.Utilities
{
    public class LogBeinHelper
    {
        private IHostingEnvironment _hostingEnvironment;

        public LogBeinHelper(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public void Insert(string logText, Layer layer)
        {
            string logType = "";
            switch (layer)
            {
                case Layer.Admin:
                    logType = "Admin - ";
                    break;
                case Layer.Api:
                    logType = "Api - ";
                    break;
                case Layer.UI:
                    logType = "UI - ";
                    break;
                default:
                    logType = "";
                    break;
            }

            string rootPath = _hostingEnvironment.ContentRootPath;

            rootPath = rootPath.Split("DiziFilm\\")[0] + "DiziFilm\\";

            string logFile = Path.Combine(rootPath + "DiziFilm.Project.Web.UI\\wwwroot", "files/log.txt");

            using (StreamWriter sw = new StreamWriter(logFile, true))
            {
                sw.WriteLine(logType + logText);

                sw.Close();

                sw.Dispose();

            }
        }

    }
}