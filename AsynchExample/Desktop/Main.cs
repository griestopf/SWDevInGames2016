using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Base.Imp.Desktop;
using Fusee.Engine.Core;
using Fusee.Serialization;
using Path = Fusee.Base.Common.Path;

namespace Fusee.Tutorial.Desktop
{
    public class Simple
    {
        public static void Main()
        {
            // Inject Fusee.Engine.Base InjectMe dependencies
            IO.IOImp = new Fusee.Base.Imp.Desktop.IOImp();

            var fap = new Fusee.Base.Imp.Desktop.FileAssetProvider("Assets");
            fap.RegisterTypeHandler(
                new AssetHandler
                {
                    ReturnedType = typeof(Font),
                    Decoder = delegate (string id, object storage)
                    {
                        if (!Path.GetExtension(id).ToLower().Contains("ttf")) return null;
                        return new Font{ _fontImp = new FontImp((Stream)storage) };
                    },
                    Checker = id => Path.GetExtension(id).ToLower().Contains("ttf")
                });
            fap.RegisterTypeHandler(
                new AssetHandler
                {
                    ReturnedType = typeof(SceneContainer),
                    Decoder = delegate (string id, object storage)
                    {
                        if (!Path.GetExtension(id).ToLower().Contains("fus")) return null;
                        var ser = new Serializer();
                        return ser.Deserialize((Stream)storage, null, typeof(SceneContainer)) as SceneContainer;
                    },
                    Checker = id => Path.GetExtension(id).ToLower().Contains("fus")
                });

            AssetStorage.RegisterProvider(fap);

            var app = new Core.AsyncExample();

            // Inject Fusee.Engine InjectMe dependencies (hard coded)
            app.CanvasImplementor = new Fusee.Engine.Imp.Graphics.Desktop.RenderCanvasImp();
            app.ContextImplementor = new Fusee.Engine.Imp.Graphics.Desktop.RenderContextImp(app.CanvasImplementor);
            Input.AddDriverImp(new Fusee.Engine.Imp.Graphics.Desktop.RenderCanvasInputDriverImp(app.CanvasImplementor));
            Input.AddDriverImp(new Fusee.Engine.Imp.Graphics.Desktop.WindowsTouchInputDriverImp(app.CanvasImplementor));
            // app.InputImplementor = new Fusee.Engine.Imp.Graphics.Desktop.InputImp(app.CanvasImplementor);
            // app.AudioImplementor = new Fusee.Engine.Imp.Sound.Desktop.AudioImp();
            // app.NetworkImplementor = new Fusee.Engine.Imp.Network.Desktop.NetworkImp();
            // app.InputDriverImplementor = new Fusee.Engine.Imp.Input.Desktop.InputDriverImp();
            // app.VideoManagerImplementor = ImpFactory.CreateIVideoManagerImp();


            /*
            // VERSION 1 - SYNCHRONER DOWNLOAD
            app.ButtonDown += delegate (object sender, EventArgs args)
            {
                WebClient client = new WebClient();

                string fileContents = client.DownloadString(new Uri("http://www.fusee3d.org/Examples/Async/SomeText.txt"));
                app.Ticker.CompleteText = fileContents;
            };
            /*  */


            // VERSION 2 - Asynchronous Programming Model (APM) - wird von WebClient nicht unterstützt, daher kein Beispiel

            // VERSION 3 - Event Based Asynchronous Pattern (EAP)
            app.ButtonDown += delegate (object sender, EventArgs args)
            {
                WebClient client = new WebClient();

                client.DownloadStringCompleted += delegate(object o, DownloadStringCompletedEventArgs eventArgs)
                {
                    app.Ticker.CompleteText = eventArgs.Result;
                };
                client.DownloadStringAsync(new Uri("http://www.fusee3d.org/Examples/Async/SomeText.txt"));
            };
            /*  */

            /*
            // VERSION 4 - Task-based Asynchronous Pattern (TAP)
            app.ButtonDown += async delegate (object sender, EventArgs args)
            {
                WebClient client = new WebClient();

                String fileContents = await client.DownloadStringTaskAsync(new Uri("http://www.fusee3d.org/Examples/Async/SomeText.txt"));
                // Nach dem await - Code der hier steht, wird erst nach dem ENDE des Task aufgerufen
                app.Ticker.CompleteText = fileContents;

            };
            /*  */


            /*
            // VERSION 5 - Task-based Asynchronous Pattern (TAP) mit getrenntem await
            app.ButtonDown += async delegate(object sender, EventArgs args)
            {
                WebClient client = new WebClient();

                Task<string> task = client.DownloadStringTaskAsync(new Uri("http://www.fusee3d.org/Examples/Async/SomeText.txt"));
                // Dinge, die direkt nach dem Starten des Task passieren sollen 

                app.Ticker.CompleteText = "- - - D O W N L O A D I N G - - - T H E   C O M P L E T E   W O R K S   O F   W I L L I A M   S H A K E S P E A R E ";


                // Vor dem await - hier passiert alles direkt nach dem Starten des Task
                String fileContents = await task;
                // Nach dem await - Code der hier steht, wird erst nach dem ENDE des Task aufgerufen
                app.Ticker.CompleteText = fileContents;

            };
            /*  */

            // Start the app
            app.Run();
        }
    }
}
