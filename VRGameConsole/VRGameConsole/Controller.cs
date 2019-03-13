using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRGameConsole.Models;

namespace VRGameConsole
{
    public class Controller
    {
        public Controller(ViewModel model)
        {
            this.Model = model;
            this.Biz = new Biz(this.Model);
        }

        private ViewModel Model { get; set; }

        private Biz Biz { get; set; }

        public bool Save(AppModel app)
        {
            var r = this.Biz.Save(app);
            if (r)
            {
                this.SaveSettings();
            }

            return r;
        }



        public bool Remove(string appName)
        {
            var r = this.Biz.Remove(appName);
            this.SaveSettings();
            return r;
        }

        public bool SaveSettings()
        {
            var r = this.Biz.SaveSettings();
            this.LoadSettings();
            return r;
        }

        public void LoadSettings()
        {
            var settings = this.Biz.LoadSettings();
            this.Model.Set(settings);
        }

        public void Sleep(double seconds)
        {
            this.Biz.Sleep(seconds);
        }

        public bool CompareProcess(List<OperationRecordModel> processList)
        {
            var changed = this.Biz.CompareProcess(processList);
            if (!changed)
            {
                this.ExportExcel();
            }

            return changed;
        }

        public bool ExportExcel()
        {
            var r = this.Biz.ExportExcel();
            return r;
        }

        public string[] GetDefaultLimitDataSource()
        {
            var list = this.Biz.GetDefaultLimitDataSource();
            return list;
        }

        public void StopAllRunning()
        {
            this.Biz.StopAllRunning();
        }
    }
}
