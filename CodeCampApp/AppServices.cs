using CodeCampApp.Data.Api;
using CodeCampApp.Navigation;
using CodeCampApp.Resources;
using System;
using Xamarin.Forms;
using static CodeCampApp.Data.Messaging.MessageHandler;


namespace CodeCampApp
{
    public partial class App : Application
    {
        #region Fields

        #endregion

        #region Public

        private static void SetupServices()
        {
            SubscribeToMessages();

            SetupCodeCampService();

            NavService = new NavigationService(Assembly);
        }

        #endregion

        #region Public Properties

        #endregion

        #region Internal Services

        internal static CodeCampService CodeCampService { get; private set; }

        internal static INavigationService NavService { get; private set; }

        #endregion

        #region Private

        // TODO Support multiple environments
        // TODO HTTP logger option
        private static void SetupCodeCampService()
        {
            try
            {
                var baseUrl = Urls.CodeCampUrl;

                CodeCampService = new CodeCampService(baseUrl);
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);
            }
        }

        #endregion
    }
}