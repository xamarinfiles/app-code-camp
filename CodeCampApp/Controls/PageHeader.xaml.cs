using System;
using Xamarin.Forms;
using static CodeCampApp.Data.Messaging.MessageHandler;

namespace CodeCampApp.Controls
{
    // NOTE Put this control in strict height container in parent to enforce consistency
    public partial class PageHeader : ContentView
    {
        #region Enums

        #endregion

        #region Constructors

        public PageHeader()
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
