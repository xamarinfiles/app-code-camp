using CodeCampApp.PageModels;
using System;
using static CodeCampApp.Data.Messaging.MessageHandler;

namespace CodeCampApp.Pages
{
    public partial class HomePage : BasePage<HomePageModel>
    {
        #region Constructors

        public HomePage()
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // DEL After add nav bar
            PageModel.GoToAgendaPageCommand.Execute(null);
        }

        #endregion

        #region Bindable Properties

        #endregion

        #region Events

        #endregion

        #region Private

        #endregion
    }
}
