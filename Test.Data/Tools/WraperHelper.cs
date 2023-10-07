using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entities.DTO;

namespace Test.Data.Tools
{
    public class WraperHelper
    {
        public static ResultOperation<response> WrapOperation<request, response>(Func<request, response> Weo, request param)
        {
            var result = new ResultOperation<response>();
            try
            {

                result.result = Weo(param);
                return result;
            }
            catch (Exception ex)
            {

                result.stateOperation = false;

                StringBuilder exceptionDetails = new StringBuilder();

                exceptionDetails.AppendLine($"Message: {ex.Message}");
                exceptionDetails.AppendLine($"StackTrace: {ex.StackTrace}");

                if (ex.InnerException != null)
                {
                    exceptionDetails.AppendLine($"InnerException Message: {ex.InnerException.Message}");
                    exceptionDetails.AppendLine($"InnerException StackTrace: {ex.InnerException.StackTrace}");
                }

                result.exception = exceptionDetails.ToString();

                string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "ExceptionLogs");
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                string logFilePath = Path.Combine(logDirectory, DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".txt");

                File.WriteAllText(logFilePath, result.exception);

                return result;

            }
        }

        public static async Task<ResultOperation<response>> WrapOperationAsync<request, response>(Func<request, Task<response>> Weo, request param)
        {
            var result = new ResultOperation<response>();
            try
            {
                result.result = await Task.Run(() =>  Weo(param));
                return result;
            }
            catch (Exception ex)
            {
                result.stateOperation = false;

                StringBuilder exceptionDetails = new StringBuilder();

                exceptionDetails.AppendLine($"Message: {ex.Message}");
                exceptionDetails.AppendLine($"StackTrace: {ex.StackTrace}");

                if (ex.InnerException != null)
                {
                    exceptionDetails.AppendLine($"InnerException Message: {ex.InnerException.Message}");
                    exceptionDetails.AppendLine($"InnerException StackTrace: {ex.InnerException.StackTrace}");
                }

                result.exception = exceptionDetails.ToString();

                string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "ExceptionLogs");
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                string logFilePath = Path.Combine(logDirectory, DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".txt");

                File.WriteAllText(logFilePath, result.exception);

                return result;

            }
        }
    }
}
