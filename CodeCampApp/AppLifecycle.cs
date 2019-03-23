using CodeCampApp.Data.Models;
using CodeCampApp.PageModels;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CodeCampApp.Data.Messaging.MessageHandler;
using static CodeCampApp.Data.Models.NavigationState;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CodeCampApp
{
    public partial class App : Application
    {
        #region Fields

        private static readonly Assembly Assembly = typeof(App).Assembly;

        #endregion

        #region Constructor

        public App()
        {
            try
            {
                SetupServices();

                MainPage = new NavigationPage();
                // TODO Move initiation into NavService method
                NavService.PushAsync(typeof(HomePageModel),
                    new NavigationState(AppSection.Home));
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);
            }
        }

        #endregion

        #region Protected Overrides

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #endregion
    }
}
