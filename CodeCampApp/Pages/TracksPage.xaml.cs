using CodeCampApp.PageModels;
using System;
using static CodeCampApp.Data.Messaging.MessageHandler;

namespace CodeCampApp.Pages
{
    public partial class TracksPage : BasePage<TracksPageModel>
    {
        #region Constructors

        public TracksPage()
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

        #region Interface

        #endregion

        #region Protected Overrides

        #endregion

        #region Bindable Properties

        #endregion

        #region Events

        #endregion

        #region Private

        #endregion
    }
}
