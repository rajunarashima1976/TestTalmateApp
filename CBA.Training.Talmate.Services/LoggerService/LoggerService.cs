using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Training.Talmate.Services.LoggerService
{
    public class LoggerService : ILoggerService
    {
        public async Task<bool> WriteErrorToFile(string text)
        {
                string sPath = @"C:\Talmate\Error\Error" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".log";
                string sFolder = "C:\\Talmate\\Error\\";


                if (System.IO.Directory.Exists(sFolder) == false)
                {
                    System.IO.Directory.CreateDirectory(sFolder);
                }

                TextWriter tw = new StreamWriter(sPath, true);
                tw.WriteLine((DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm:ss") + " : ") + text);
                tw.Flush();
                tw.Close();
                return await Task.FromResult(true);
            
        }

        public async Task<bool> WriteActionExecutionToFile(string text)
        {
            string sPath = @"C:\Talmate\ActionExecution\ActionExecution" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".log";
            string sFolder = "C:\\Talmate\\ActionExecution\\";


            if (System.IO.Directory.Exists(sFolder) == false)
            {
                System.IO.Directory.CreateDirectory(sFolder);
            }

            TextWriter tw = new StreamWriter(sPath, true);
            tw.WriteLine((DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm:ss") + " : ") + text);
            tw.Flush();
            tw.Close();
            return await Task.FromResult(true);

        }
    }
}
