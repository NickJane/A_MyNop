using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace MyNopWindowsService
{
    public class FileLoger
    {
        static readonly object Lock = new object();
        /// <summary>
        /// 记录日志,文件名为yyyyMMdd.log
        /// </summary>
        /// <param name="format">日志内容</param>
        /// <param name="args">参数</param>
        public static void WriteLog(string format, params object[] args)
        {
            WriteLogEx(DateTime.Now.ToString("yyyyMMdd"), format, args);
        }

        /// <summary>
        /// 写日志,以天为单位建立文件夹,后跟文件名
        /// </summary>
        /// <param name="filename">日志文件名</param>
        /// <param name="format">日志内容</param>
        /// <param name="args">参数</param>
        public static void WriteLogEx(string filename, string format, params object[] args)
        {
            if (String.IsNullOrWhiteSpace(filename))
            {
                return;
            }
            lock (Lock)
            {
                try
                {
                    var body = args.Length > 0 ? string.Format(format, args) : format;
                    body = string.Format("{0:HH:mm:ss fff}\t{1}", DateTime.Now, body);
                    var logPath = GetLogPath();
                    if (string.IsNullOrEmpty(logPath))
                        return;
                    logPath = Path.Combine(logPath, DateTime.Now.ToString("yyyyMMdd"));

                    if (!System.IO.Directory.Exists(logPath))
                    {
                        System.IO.Directory.CreateDirectory(logPath);
                    }
                    logPath = Path.Combine(logPath, filename + ".log");
                    using (var sw = File.AppendText(logPath))
                    {
                        sw.WriteLine(body);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private static string _logPath;
        public static string GetLogPath()
        {
            if (_logPath == null)
            {
                _logPath = ConfigurationManager.AppSettings["logpath"];
                // 尝试读取web启动路径
                if (string.IsNullOrEmpty(_logPath))
                {
                    _logPath = HostingEnvironment.MapPath("~/Logs/");
                }
                // 尝试读取windows启动路径
                if (string.IsNullOrEmpty(_logPath))
                {
                    _logPath = Path.Combine(Environment.CurrentDirectory, "Logs");
                }
                if (string.IsNullOrEmpty(_logPath))
                    _logPath = string.Empty;
            }
            return _logPath;
        }

        public static void SetLogPath(string logPath)
        {
            _logPath = logPath;
        }
    }
}
