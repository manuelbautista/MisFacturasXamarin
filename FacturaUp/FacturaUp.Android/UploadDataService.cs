using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace FacturaUp.Droid
{
    [Service]
    public class UploadDataService: Service
    {
       
        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        private Timer _Check_timer_Data;

        public void DebugMyBGService()
        {
            _Check_timer_Data = new Timer((o) =>
            {
                Log.Debug("SS", "Helloword start service");
            },null,0,2000);
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Log.Debug("SS", "MY BG SERVICE HAS STARTED SUCESSFULL");
            DebugMyBGService();

            return StartCommandResult.NotSticky;
        }

        public override bool StopService(Intent name)
        {
            return base.StopService(name);
        }
    }
}