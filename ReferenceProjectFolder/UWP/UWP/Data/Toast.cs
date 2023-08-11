using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Data
{
    internal class Toast
    {
        internal ToastContent MakeToast()
        {
            ToastContent tc = new ToastContent();
            tc.Launch = "action=MyLaunchAction&myItemId=123";

            ToastVisual tv = new ToastVisual();
            
            return tc;

        }
    }
}
