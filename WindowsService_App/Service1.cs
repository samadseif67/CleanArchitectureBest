using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsService_App
{
    public partial class Service1 : ServiceBase
    {
        string path = "";
        public Service1()
        {
            InitializeComponent();
           // this.ServiceName = "AppSamad";
            path = AppDomain.CurrentDomain.BaseDirectory;
        }

        protected override  void OnStart(string[] args)
        {
            while (true)
            {
                Thread.Sleep(5000);
                string currentDirectory = (path + "AA.txt");
                    using (StreamWriter sw = new StreamWriter(currentDirectory, true))
                    {
                        sw.WriteLine("start ... "+DateTime.Now.ToString());
                    }                
            }
        }

        protected override void OnStop()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("end ... " + DateTime.Now.ToString());
            }
        }
    }
}
