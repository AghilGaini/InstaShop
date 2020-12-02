using System;
using System.Collections;
using System.Collections.Generic;
//using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities;

namespace Logger
{
    public enum LogLevel
    {
        Error = 1,
        Warning = 2,
        Info = 3,
        Debug = 4,
        Fatal = 5
    };
    public enum LogType
    {
        File = 1,
        DataBase = 2
    };

    public class LogBusiness
    {
        #region LocalVariables
        private class LogLayout
        {
            public bool Message { get; set; }
            public bool Time { get; set; }
            public string TimeFormat { get; set; }
            public bool ClassName { get; set; }
            public bool LineNumber { get; set; }
            public bool ColumnNumber { get; set; }
        }
        private class QueueObjects
        {
            public string Message { get; set; }
            public string Path { get; set; }
        }
        private static class LogFiles
        {
            public static string Error { get; set; }
            public static string Warning { get; set; }
            public static string Info { get; set; }
            public static string Debug { get; set; }
            public static string Fatal { get; set; }

        }

        private readonly object lockObj = new object();
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
        public static Queue MyErrorQueue = new Queue();
        public static Queue TempErrorQueue = new Queue();
        public static int AllError = 0;

        private bool _isActiveLog = true;
        private List<string> _TextlogPattern;
        private LogLayout _TextlogLayout;
        private string Pattern = "";
        private string ClassName = "";
        private string LineNumber = "";
        private string ColumnNumber = "";

        #endregion

        public LogBusiness()
        {

        }
        public void Log(string message, LogLevel logLevel, LogType logType, Exception ex)
        {
            if (logType == LogType.File)
            {
                TextLog(message, logLevel, logType, ex);
            }
            else
            {

            }
        }
        public void Log(string message, LogLevel logLevel, LogType logType)
        {
            if (logType == LogType.File)
            {
                TextLog(message, logLevel, logType);
            }
            else
            {

            }
        }

        #region TextLog
        public void TextLog(string message, LogLevel logLevel, LogType logType, Exception ex)
        {
            _isActiveLog = ConfigurationManager.AppSettings["IsActiveLog"].ToBoolean();
            if (!_isActiveLog)
                return;

            //For Reset All TextLog Variables
            ResetVariables();

            //Get Pattern From WebConfig
            _TextlogPattern.Add("message");
            if (ConfigurationManager.AppSettings["LogPattern"] != null)
                _TextlogPattern.AddRange(ConfigurationManager.AppSettings["LogPattern"].ToString().Split(',').ToList());

            //Initialize all Directories and pathes For text log
            InitializeTextLogPath();

            SetTextLogPattern(_TextlogPattern, ref _TextlogLayout);

            string path = "";

            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
            this.ClassName = trace.GetFrame(0).GetMethod().ReflectedType.FullName + "." + trace.GetFrame(0).GetMethod().Name;
            this.LineNumber = trace.GetFrame(0).GetFileLineNumber().ToString();
            this.ColumnNumber = trace.GetFrame(0).GetFileColumnNumber().ToString();

            Pattern = GetTextLogPattern();


            if (logLevel == LogLevel.Error)
            {
                TextLogError(ref message, ref path);
            }
            else if (logLevel == LogLevel.Warning)
            {
                TextLogWarning(ref message, ref path);
            }
            else if (logLevel == LogLevel.Info)
            {
                TextLogInfo(ref message, ref path);
            }
            else if (logLevel == LogLevel.Debug)
            {
                TextLogDebug(ref message, ref path);
            }

            InsertTextLog(message, path);
        }
        public void TextLog(string message, LogLevel logLevel, LogType logType)
        {
            _isActiveLog = ConfigurationManager.AppSettings["IsActiveLog"].ToBoolean();
            if (!_isActiveLog)
                return;

            //For Reset All TextLog Variables
            ResetVariables();

            //Get Pattern From WebConfig
            _TextlogPattern.Add("message");
            if (ConfigurationManager.AppSettings["LogPattern"] != null)
                _TextlogPattern.AddRange(ConfigurationManager.AppSettings["LogPattern"].ToString().Split(',').ToList());

            //Initialize all Directories and pathes For text log
            InitializeTextLogPath();

            SetTextLogPattern(_TextlogPattern, ref _TextlogLayout, false);

            string path = "";

            Pattern = GetTextLogPattern();


            if (logLevel == LogLevel.Error)
            {
                TextLogError(ref message, ref path);
            }
            else if (logLevel == LogLevel.Warning)
            {
                TextLogWarning(ref message, ref path);
            }
            else if (logLevel == LogLevel.Info)
            {
                TextLogInfo(ref message, ref path);
            }
            else if (logLevel == LogLevel.Debug)
            {
                TextLogDebug(ref message, ref path);
            }
            else if (logLevel == LogLevel.Fatal)
            {
                TextLogFatal(ref message, ref path);
            }

            InsertTextLog(message, path);
        }
        private void ResetVariables()
        {
            this._TextlogLayout = new LogLayout();
            this._TextlogPattern = new List<string>();
            this.ClassName = "";
            this.LineNumber = "";
            this.ColumnNumber = "";
        }
        private void InitializeTextLogPath()
        {

            var Folders = new List<string>();
            Type type = typeof(Constants.LogInfo.LogPath.Directories);
            foreach (var item in type.GetProperties())
            {
                if (!Directory.Exists(item.GetValue(null).ToString()))
                    Directory.CreateDirectory(item.GetValue(null).ToString());
                Folders.Add(item.GetValue(null).ToString());
            }

            foreach (var item in Folders)
            {
                var path = string.Format(@"{0}\{1}.txt", item, DateTime.Now.ToString("MM-dd-yyyy"));
                if (!File.Exists(path))
                {
                    var MyFile = File.Create(path);
                    MyFile.Close();
                }
                if (item.Contains("Error"))
                    LogFiles.Error = path;
                else if (item.Contains("Warning"))
                    LogFiles.Warning = path;
                else if (item.Contains("Info"))
                    LogFiles.Info = path;
                else if (item.Contains("Debug"))
                    LogFiles.Debug = path;
                else if (item.Contains("Fatal"))
                    LogFiles.Fatal = path;

            }
        }
        private void SetTextLogPattern(List<string> _TextlogPattern, ref LogLayout _TextlogLayout, bool IsEception = true)
        {
            foreach (var item in _TextlogPattern)
            {
                if (item == "message")
                {
                    _TextlogLayout.Message = true;
                    continue;
                }
                if (item == "time")
                {
                    _TextlogLayout.Time = true;
                    continue;
                }
                if (item.Contains("timeformat"))
                {
                    _TextlogLayout.TimeFormat = item.Split('{').ToList()[1].Trim('}');
                }
                if (IsEception)
                {
                    if (item == "classname")
                    {
                        _TextlogLayout.ClassName = true;
                        continue;
                    }
                    if (item == "line")
                    {
                        _TextlogLayout.LineNumber = true;
                    }
                    if (item == "column")
                    {
                        _TextlogLayout.ColumnNumber = true;
                    }
                }
            }
        }
        private string GetTextLogPattern()
        {
            string Res = "";

            if (_TextlogLayout.Time)
            {
                if (_TextlogLayout.TimeFormat != "")
                {
                    Res += string.Format("[Time:{0}]--------", DateTime.Now.ToString(_TextlogLayout.TimeFormat));
                }
                else
                    Res += string.Format("[Time:{0}]--------", DateTime.Now.ToString());
            }
            if (_TextlogLayout.ClassName)
            {
                Res += string.Format("[ClassName:{0}]--------", this.ClassName);
            }
            if (_TextlogLayout.LineNumber)
            {
                Res += string.Format("[Line:{0}]--------", this.LineNumber);
            }
            if (_TextlogLayout.ColumnNumber)
            {
                Res += string.Format("[Column:{0}]--------", this.ColumnNumber);
            }

            return Res;
        }
        private void TextLogError(ref string message, ref string path)
        {
            path = LogFiles.Error;
            message = string.Format("[ERROR] {0}[Payload:{1}]", Pattern, message);
        }
        private void TextLogWarning(ref string message, ref string path)
        {
            path = LogFiles.Warning;
            message = string.Format("[Warning] {0}[Payload:{1}]", Pattern, message);
        }
        private void TextLogInfo(ref string message, ref string path)
        {
            path = LogFiles.Info;
            message = string.Format("[INFO] {0}[Payload:{1}]", Pattern, message);
        }
        private void TextLogDebug(ref string message, ref string path)
        {
            path = LogFiles.Debug;
            message = string.Format("[DEBUG] {0}[Payload:{1}]", Pattern, message);
        }
        private void TextLogFatal(ref string message, ref string path)
        {
            path = LogFiles.Fatal;
            message = string.Format("[Fatal] {0}[Payload:{1}]", Pattern, message);
        }
        private async void InsertTextLog(string message, string path)
        {
            try
            {
                if (_isActiveLog)
                {
                    message = string.Format("{0}{1}", message, Environment.NewLine);

                    await semaphoreSlim.WaitAsync();

                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        await sw.WriteAsync(message);
                        sw.Close();
                    }

                }
            }
            catch
            {
                MyErrorQueue.Enqueue(new QueueObjects() { Message = "***-" + message, Path = path });
                AllError += 1;
            }
            finally
            {
                if (semaphoreSlim.CurrentCount < 1)
                    semaphoreSlim.Release();
                ReadFromErrorQueue();
            }

        }
        private async void InsertTextLog(Queue ErrorQueue)
        {
            try
            {
                if (_isActiveLog)
                {
                    var message = "";
                    var path = "";
                    try
                    {
                        foreach (QueueObjects item in ErrorQueue)
                        {
                            message = string.Format("{0}{1}", item.Message, Environment.NewLine);
                            path = item.Path;

                            await semaphoreSlim.WaitAsync();

                            using (StreamWriter sw = new StreamWriter(path, true))
                            {
                                await sw.WriteAsync(message);
                                sw.Close();
                            }
                        }
                    }
                    catch
                    {
                        MyErrorQueue.Enqueue(new QueueObjects() { Message = message, Path = path });
                        AllError += 1;

                    }
                    finally
                    {
                        if (semaphoreSlim.CurrentCount < 1)
                            semaphoreSlim.Release();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ReadFromErrorQueue()
        {
            if (MyErrorQueue.Count > 100)
            {

                TempErrorQueue.Clear();
                for (int i = 0; i < 100; i++)
                {
                    TempErrorQueue.Enqueue(MyErrorQueue.Dequeue());
                }
                InsertTextLog(TempErrorQueue);
            }

        }

        #endregion
    }
}
