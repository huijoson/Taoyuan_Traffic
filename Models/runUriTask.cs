using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;

namespace Taoyuan_Traffic
{
    public class runUriTask
    {
        private bool _stopping = false;

        public runUriTask()
        {

        }

        public void run()
        {
            var aThread = new Thread(TaskLoop);
            aThread.IsBackground = true;
            aThread.Priority = ThreadPriority.BelowNormal;
            //aThread.Start();
        }

        public void Stop()
        {
            _stopping = true;
        }

        private void Log(string msg)
        {
            System.IO.File.AppendAllText(@"D:\Temp\log.txt", msg + Environment.NewLine);
        }

        private void TaskLoop()
        {
            const int LoopIntervalInMinutes = 1000 * 10800 * 1;

            Log("TaskLoop on thread ID: " + Thread.CurrentThread.ManagedThreadId.ToString());
            while (!_stopping)
            {
                try
                {
                    DoRunURI();
                }
                catch (Exception ex)
                {
                    // 發生意外時只記在 log 裡，不拋出 exception，以確保迴圈持續執行.
                    Log(ex.ToString());
                }
                finally
                {
                    // 每一輪工作完成後的延遲.
                    System.Threading.Thread.Sleep(LoopIntervalInMinutes);
                }
            }
        }

        private void DoRunURI()
        {
            //更新路由資訊API
            string targetUrl = ConfigurationManager.AppSettings["TaskAllRouteURL"].ToString();
            WebRequest request = WebRequest.Create(targetUrl) as HttpWebRequest;
            request.Method = WebRequestMethods.Http.Post;
            string param = "=sayhello";//注意有個「=」
            byte[] bs = Encoding.Default.GetBytes(param);
            request.ContentLength = bs.Length;

            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Flush();
            }
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //Server回傳的資料。
                        System.IO.Stream data = response.GetResponseStream();
                        StreamReader sr = new StreamReader(data);
                        string retMsg = sr.ReadToEnd();
                        sr.Close();
                        data.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }

            string msg = String.Format("DoRunURI() at {0:yyyy/MM/dd HH:mm:ss}", DateTime.Now);
            Log(msg);
        }
    }
}