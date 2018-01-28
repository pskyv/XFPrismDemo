using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using XFPrismDemo.Models;

namespace XFPrismDemo.Utils
{
    public static class HelperFunctions
    {
        public static void ShowToastMessage(ToastMessageType type, string message)
        {
            var icon = string.Empty;
            System.Drawing.Color color = System.Drawing.Color.ForestGreen;

            switch (type)
            {
                case ToastMessageType.Success:
                    icon = "ic_done.png";
                    break;
                case ToastMessageType.Error:
                    icon = "ic_error.png";
                    color = System.Drawing.Color.Red;
                    break;
            }

            var toastConfig = new ToastConfig(message);
            toastConfig.SetDuration(2000);
            toastConfig.SetBackgroundColor(color);
            toastConfig.SetIcon(icon);
            UserDialogs.Instance.Toast(toastConfig);
        }
    }
}
