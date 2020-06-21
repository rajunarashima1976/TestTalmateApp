using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Training.Talmate.Services.LoggerService
{
    public interface ILoggerService
    {
        Task<bool> WriteErrorToFile(string text);
        Task<bool> WriteActionExecutionToFile(string text);
    }
}
