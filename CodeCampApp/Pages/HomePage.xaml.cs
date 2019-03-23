using CodeCampApp.Data.Models;
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

            // DEL After PageModel navigation
            BasePageModel.NavService.PushAsync(typeof(AgendaPageModel),
                new NavigationState(NavigationState.AppSection.Agenda));
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
