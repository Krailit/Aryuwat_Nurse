using System;
using System.Collections.Generic;
using System.Text;

namespace AryuwatSystem.DerClass
{
    /// <summary>
    /// interface for MainMenu
    /// </summary>
   public interface IForm
    {
       void IsSave();
       void IsDelete();
       void IsRefresh();
       void IsEdit();
       void IsPrint();
       void IsNew();
       void IsExit();
    }

    /// <summary>
    /// interface for Splash Screen
    /// </summary>
    public interface ISplashForm
    {
        void SetStatusInfo(string NewStatusInfo);
    }
}
