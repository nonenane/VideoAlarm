using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VideoAlarmDemon
{
    // делегат для создания события - извещения
    public delegate void delShow(string Message);

    // делегат для запуска проверки словаря в фоновом режиме
    public delegate void delCheckDict();

    class Watcher : IDisposable
    {
        // словарь для хранения имени файла и времени изменения
        Dictionary<string, DateTime> dic = new Dictionary<string, DateTime>();
        // событие-извещение об изменении файла
        public event delShow CurEvents;
        // объект - мониторинг изменения в файле
        private FileSystemWatcher watcher = new FileSystemWatcher();
        // для создания объекта от делегата для запуска в фоновом режиме проверки словаря
        private delCheckDict ChDict;

        private string Path;

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public Watcher(string Path)
        {
            this.Path = Path;
            //Task.Run(() => Run());
            watcher.Path = this.Path;
            watcher.Filter = @"*.txt";
            watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            //NotifyFilters.LastAccess
            //| NotifyFilters.LastWrite
            //| NotifyFilters.FileName
            //| NotifyFilters.DirectoryName;

            // запускаем проверку словаря в фоновом режиме
            ChDict = new delCheckDict(CheckDict);
            IAsyncResult ir = ChDict.BeginInvoke(null, null);

            watcher.EnableRaisingEvents = true;
        }

        private async void Run()
        {
            watcher.Path = this.Path;
            watcher.Filter = @"*.txt";
            watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            watcher.NotifyFilter = NotifyFilters.LastWrite;

            // запускаем проверку словаря в фоновом режиме
            ChDict = new delCheckDict(CheckDict);
            IAsyncResult ir = ChDict.BeginInvoke(null, null);

            watcher.EnableRaisingEvents = true;
        }

        private void watcher_Changed(Object sender, FileSystemEventArgs e)
        {
            bool IsEvent = false;
            lock (this)
            {
                if (dic.ContainsKey(e.FullPath))
                {
                    dic.Remove(e.FullPath);
                    IsEvent = true;
                }
                else
                    dic.Add(e.FullPath, DateTime.Now);

            }
            if (IsEvent) MakeEvents(e.FullPath);
        }

        private void MakeEvents(string FileName)
        {
            try
            {
                FileInfo fi = new FileInfo(FileName);
                CurEvents(string.Format("Файл:{0} Длина:{1}", fi.FullName, fi.Length));
            }
            catch
            {
                CurEvents("Нет файла!");
            }

        }

        private void CheckDict()
        {
            List<string> EntryKeysToRemove;

            // проходим по словарю каждые 3 сек и смотрим,
            // если файл "сидит" более 3 секунд - вызываем событие с ним
            while (true)
            {
                EntryKeysToRemove = new List<string>();
                foreach (KeyValuePair<string, DateTime> entry in dic)
                {
                    if ((DateTime.Now - entry.Value).TotalSeconds > 3)
                    {
                        MakeEvents(entry.Key);
                        EntryKeysToRemove.Add(entry.Key);
                    }
                }

                foreach (string entryKey in EntryKeysToRemove)
                {
                    lock (this)
                    {
                        dic.Remove(entryKey);
                    }
                }
                Thread.Sleep(3000);
            }
        }

        public void WatcherStartStop(bool Start)
        {
            watcher.EnableRaisingEvents = Start;
        }

        public bool getStatus()
        { return watcher.EnableRaisingEvents; }

        public void Dispose()
        {
            Console.Beep();
            Console.WriteLine("Disposed");
        }

        ~Watcher()
        {
            Dispose();
        }
    }
}
