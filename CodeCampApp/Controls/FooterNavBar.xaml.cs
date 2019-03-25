using System;
using Xamarin.Forms;
using static CodeCampApp.Data.Messaging.MessageHandler;

namespace CodeCampApp.Controls
{
    public partial class FooterNavBar : ContentView
    {
        #region Enums

        #endregion

        #region Constructors

        public FooterNavBar()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);
            }
        }

        #endregion

        #region Protected Overrides

        #endregion

        #region Bindable Properties

        #endregion

        #region Properties

        #endregion

        #region Events

        #endregion

        #region Delegates

        #endregion

        #region Private

        #endregion
    }
}
