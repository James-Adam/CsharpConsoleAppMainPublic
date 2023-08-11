using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.WebSockets;
using Owin;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace AuthenticatedSchoolSystem.Back_End.DataStorage
{
    public class DataStorage
    {
        public void ApplicationState()
        {
            HttpContext.Current.Application.Lock();
            HttpContext.Current.Application["myApplicationObject"] = new List<string> { "a", "b", "c" };

            foreach (string s in (List<string>)HttpContext.Current.Application["mySessionObject"])
            {
                HttpContext.Current.Response.Write(s);
            }

            HttpContext.Current.Application.UnLock();
        }

        public void SessionState()
        {
            HttpContext.Current.Session["mySessionObject"] = new List<string> { "a", "b", "c" };

            foreach (string s in (List<string>)HttpContext.Current.Session["mySessionObject"])
            {
                HttpContext.Current.Response.Write(s);
            }

            string sessionId = HttpContext.Current.Session.SessionID;
        }

        public void ProfileProperties()
        {
            _ = HttpContext.Current.Profile.UserName;

            HttpContext.Current.Profile["myProfileProperty1"] = "myProfileValue1";
            HttpContext.Current.Profile["myProfileProperty2"] = new List<string> { "a", "b", "c" };
            _ = (string)HttpContext.Current.Profile["myProfileProperty1"];
        }

        public void WebSocketReadWrite()
        {
            //using (WebSocket ws = new WebSocket("wss://echo.websocket.org"))
            //{
            //    ws.OnMessage += (sender, e) =>
            //    {
            //        HttpContext.Current.Response.Write(e.Data);
            //    };

            // ws.Connect(); ws.SendAsync("my string data", SendResult);

            //}
        }

        public async Task ReadWriteStreamAsync(Stream s, Stream d)
        {
            byte[] buf = new byte[65536];
            while (true)
            {
                int r = await s.ReadAsync(buf, 0, 65536);
                if (r <= 0)
                {
                    break;
                }

                await d.WriteAsync(buf, 0, r);
            }
        }
    }

    public class SignalR : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            _ = app.MapSignalR();
        }
    }

    public class ConnectionLossStrategy : WebSocketHandler
    {
        public ConnectionLossStrategy(int? max) : base(max)
        {
        }

        public override void OnClose()
        {
            //myApp.Remove(this);
            //myApp.Broadcast(user + " left");
        }

        public override void OnError()
        {
            //myApp.Remove(this);
            //myApp.Broadcast(user + " errored");
        }
    }

    internal class WebSocketCollection
    {
        // do some work
    }
}