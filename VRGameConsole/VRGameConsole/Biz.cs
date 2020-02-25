using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using VRGameConsole.Models;
using System.Text;
using System.Runtime.InteropServices;

namespace VRGameConsole
{
    public class Biz
    {
        public Biz(ViewModel model)
        {
            this.Model = model;
        }

        public ViewModel Model { get; set; }

        public bool Save(AppModel app)
        {
            if (!this.Validate(app))
            {
                return false;
            }

            var oldApp = this.Model.AppList.SingleOrDefault(m => String.Compare(m.Path, app.Path, true) == 0);
            if (oldApp == null)
            {
                // add
                this.Model.AppList.Add(app);
                return true;
            }
            else if (!(this.Model.AppList.Any(m => string.Compare(m.Path, app.Path) != 0 && string.Compare(m.Name, app.Name, true) == 0)))
            {

                oldApp.Name = app.Name;
                //oldApp.Path = app.Path;
                oldApp.ProcessName = app.ProcessName;
                return true;
            }

            return false;
        }

        public bool Validate(AppModel app)
        {
            if (string.IsNullOrEmpty(app.Name))
            {
                return false;
            }

            if (string.IsNullOrEmpty(app.Path))
            {
                return false;
            }

            if (string.IsNullOrEmpty(app.ProcessName))
            {
                return false;
            }

            return true;
        }

        public bool Remove(string appName)
        {
            var oldApp = this.Model.AppList.SingleOrDefault(m => String.Compare(m.Name, appName, true) == 0);
            if (oldApp != null)
            {
                this.Model.AppList.Remove(oldApp);
                return true;
            }

            return false;
        }

        private const string SETTINGS_FILE_NAME = "settings.json";

        public bool SaveSettings()
        {
            try
            {
                var m = this.Model.GetSettings();
                var str = JsonConvert.SerializeObject(m);
                File.WriteAllText(SETTINGS_FILE_NAME, str);
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#else
                return false;
#endif
            }
        }

        public SettingsModel LoadSettings()
        {
            try
            {
                if (!File.Exists(SETTINGS_FILE_NAME))
                {
                    return null;
                }

                var str = File.ReadAllText(SETTINGS_FILE_NAME);
                if (string.IsNullOrWhiteSpace(str))
                {
                    return null;
                }

                var settings = JsonConvert.DeserializeObject<SettingsModel>(str.Trim());
                return settings;
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#else
                return null;
#endif
            }
        }

        public void Sleep(double seconds)
        {
            Thread.Sleep(Convert.ToInt32(seconds * 1000));
        }

        public bool CompareProcess(List<OperationRecordModel> processList)
        {
            bool changed = false;
            if (processList.Count > 0)
            {
                // 在console启动的，关联进程
                foreach (var m in processList)
                {
                    foreach (var n in this.Model.RunningApps)
                    {
                        if (string.Compare(m.App.ProcessName, n.App.ProcessName, true) == 0 && !n.ProcessID.HasValue)
                        {
                            n.Set(m);
                            changed = true;
                        }
                    }
                }
                // 不在console启动的，新加的
                var addList = processList.Where(m => !this.Model.RunningApps.Any(n => String.Compare(n.App.ProcessName, m.App.ProcessName, true) == 0)).ToList();
                foreach (var m in addList)
                {
                    this.Model.RunningApps.Add(m);
                    changed = true;
                }
            }

            //过期的
            for (var i = this.Model.RunningApps.Count - 1; i >= 0; i--)
            {
                var m = this.Model.RunningApps[i];
                if (m.Expired.GetValueOrDefault())
                {
                    this.KillProcess($"{m.App.ProcessName}{Path.GetExtension(m.App.Path)}");
                    m.DateFinished = DateTime.Now;
                    this.Model.RunApps.Add(m);
                    this.Model.RunningApps.Remove(m);
                    changed = true;
                    this.Model.Worker.ReportProgress(0, new UserStateModel());
                }
                else if (m.CountDown.HasValue)
                {
                    this.Model.Worker.ReportProgress(0, new UserStateModel() { CountDown = m.CountDown });
                }
            }

            // 不在console启动的 删除的
            var removeList = this.Model.RunningApps.Where(m => !processList.Any(n => string.Compare(n.App.ProcessName, m.App.ProcessName, true) == 0)).ToList();
            foreach (var m in removeList)
            {
                m.DateFinished = DateTime.Now;
                this.Model.RunningApps.Remove(m);
                this.Model.RunApps.Add(m);
                changed = true;
            }

            return changed;
        }

        public void StopAllRunning()
        {
            for (var i = this.Model.RunningApps.Count - 1; i >= 0; i--)
            {
                var m = this.Model.RunningApps[i];
                this.KillProcess($"{m.App.ProcessName}{Path.GetExtension(m.App.Path)}");
                m.DateFinished = DateTime.Now;
                this.Model.RunApps.Add(m);
                this.Model.RunningApps.Remove(m);
            }
        }

        public bool KillProcess(string processName)
        {
            var retry = 3;
            while (true)
            {
                try
                {
                    var output = this.Execute($"TASKKILL /F /IM \"{processName}\" /T", 10);
                    if (!output.Contains("成功") && !output.Contains("SUCCESS"))
                    {
                        return true;
                    }
                }
                catch
                {
                    retry--;
                    if (retry <= 0)
                    {
                        break;
                    }

                    this.Sleep(1);
                }
            }

            LockWorkStation();
            return false;
        }

        [DllImport("User32.DLL")]
        public static extern void LockWorkStation();

        /// <summary>
        /// 执行DOS命令，返回DOS命令的输出
        /// </summary>
        /// <param name="dosCommand">dos命令</param>
        /// <param name="milliseconds">等待命令执行的时间（单位：毫秒），
        /// 如果设定为0，则无限等待</param>
        /// <returns>返回DOS命令的输出</returns>
        public string Execute(string command, int seconds)
        {
            string output = ""; //输出字符串
            if (command != null && !command.Equals(""))
            {
                Process process = new Process();//创建进程对象
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";//设定需要执行的命令
                startInfo.Arguments = "/C " + command;//“/C”表示执行完命令后马上退出
                startInfo.UseShellExecute = false;//不使用系统外壳程序启动
                startInfo.RedirectStandardInput = false;//不重定向输入
                startInfo.RedirectStandardOutput = true; //重定向输出
                startInfo.CreateNoWindow = true;//不创建窗口
                process.StartInfo = startInfo;
                try
                {
                    if (process.Start())//开始进程
                    {
                        if (seconds == 0)
                        {
                            process.WaitForExit();//这里无限等待进程结束
                        }
                        else
                        {
                            process.WaitForExit(seconds); //等待进程结束，等待时间为指定的毫秒
                        }
                        output = process.StandardOutput.ReadToEnd();//读取进程的输出
                    }
                }
                catch
                {
                }
                finally
                {
                    if (process != null)
                        process.Close();
                }
            }
            return output;

        }

        public bool ExportExcel()
        {
            var retry = 3;
            while (true)
            {
                try
                {
                    var list = this.Model.RunApps.Where(m => !m.Saved).ToList();
                    if (list.Count == 0)
                    {
                        return false;
                    }

                    list = this.Model.RunApps.OrderBy(m => m.DateStarted.GetValueOrDefault()).ToList();
                    IWorkbook wb = new XSSFWorkbook();
                    ISheet sht = wb.CreateSheet("运行记录");
                    var rowIndex = 0;
                    IRow rh = sht.CreateRow(rowIndex++);
                    var col = 0;
                    ICell cell = rh.CreateCell(col++);
                    cell.SetCellValue("开始时间");

                    cell = rh.CreateCell(col++);
                    cell.SetCellValue("结束时间");

                    cell = rh.CreateCell(col++);
                    cell.SetCellValue("程序名称");

                    cell = rh.CreateCell(col++);
                    cell.SetCellValue("时限");

                    cell = rh.CreateCell(col++);
                    cell.SetCellValue("已完成");

                    var i = 1;
                    foreach (var t in list)
                    {
                        col = 0;
                        IRow row = sht.CreateRow(rowIndex++);

                        row.CreateCell(col++).SetCellValue(t.DateStarted.HasValue ? t.DateStarted.Value.ToString("yyyy-MM-dd HH:mm:ss") : "N/A");
                        row.CreateCell(col++).SetCellValue(t.DateFinished.HasValue ? t.DateFinished.Value.ToString("yyyy-MM-dd HH:mm:ss") : "N/A");
                        row.CreateCell(col++).SetCellValue(Path.GetFileName(t.App.Path));
                        row.CreateCell(col++).SetCellValue(t.LimitMinutes.HasValue ? t.LimitMinutes.Value.ToString() : "N/A");
                        row.CreateCell(col++).SetCellValue(t.Expired.GetValueOrDefault() ? "" : "否");
                        i++;
                    }

                    //var folder = $"{this.Model.StartTime.ToString("yyyy-MM-dd HH_mm_ss")}";
                    //if (!Directory.Exists(folder))
                    //{
                    //    Directory.CreateDirectory(folder);
                    //}

                    var fileName = $"Records_{DateTime.Now.ToString("yyyyMMdd")}_{this.Model.StartTime.Ticks / 10000000L}{(string.IsNullOrEmpty(this.Model.Desc) ? string.Empty : $"_{this.Model.Desc}")}.xlsx";
                    using (var ms = new MemoryStream())
                    {
                        wb.Write(ms);
                        var buf = ms.ToArray();

                        //保存为Excel文件  
                        using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(buf, 0, buf.Length);
                            fs.Flush();
                        }
                    }

                    foreach (var t in list)
                    {
                        t.Saved = true;
                    }

                    return true;
                }
                catch (Exception ex)
                {
#if DEBUG
                    retry--;
                    if (retry <= 0)
                    {
                        throw ex;
                    }
#else
                    return false;
#endif
                }

                this.Sleep(1);
            }
        }

        public string[] GetDefaultLimitDataSource()
        {
            var str = ConfigurationManager.AppSettings["DefaultLimits"];
            if (string.IsNullOrEmpty(str))
            {
                return new string[0];
            }

            var array = str.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(m => int.TryParse(m.Trim(), out int tmp))
                .OrderByDescending(m => Convert.ToInt32(m))
                .ToArray();
            return array;
        }

        public bool IsValid()
        {
            return true;
        }

        
    }
}
