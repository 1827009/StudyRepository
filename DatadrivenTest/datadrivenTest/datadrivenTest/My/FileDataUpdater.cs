using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace My
{
    public class FileDataUpdater : System.ComponentModel.ISynchronizeInvoke
    {
        public static FileDataUpdater Instance = new FileDataUpdater();

        private FileSystemWatcher watcher = null;

        /// <summary>
        /// Keyとしてファイルネーム、Valueとして更新時呼び出しメソッド
        /// </summary>
        private Dictionary<string, Action> updateAction = new Dictionary<string, Action>();
        public Dictionary<string, Action> UpdateAction
        {
            get { return updateAction; }
        }
        public void AddUpdateAction(string fileName, Action action)
        {
            if (!My.FileDataUpdater.Instance.UpdateAction.ContainsKey(fileName))
                My.FileDataUpdater.Instance.UpdateAction.Add(fileName, action);
            else
                My.FileDataUpdater.Instance.UpdateAction[fileName] += action;
        }

        public void OnUpdate(string pash)
        {
            if (watcher != null) return;

            watcher = new FileSystemWatcher();
            //監視するディレクトリを指定
            watcher.Path = pash;
            //最終アクセス日時、最終更新日時、ファイル、フォルダ名の変更を監視する
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            //すべてのファイルを監視
            watcher.Filter = "";

            watcher.SynchronizingObject = (System.ComponentModel.ISynchronizeInvoke)this;

            //イベントハンドラの追加
            watcher.Changed += new FileSystemEventHandler(watcher_Changed);

            //監視を開始する
            watcher.EnableRaisingEvents = true;
        }

        private void watcher_Changed(System.Object source,
            FileSystemEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Name + " が自動更新されました。");
            updateAction[e.Name]?.Invoke();
        }


        public bool InvokeRequired => throw new NotImplementedException();

        public IAsyncResult BeginInvoke(Delegate method, object[] args)
        {
            throw new NotImplementedException();
        }

        public object EndInvoke(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public object Invoke(Delegate method, object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
