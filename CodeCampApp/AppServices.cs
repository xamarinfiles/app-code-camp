using CodeCampApp.Navigation;
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

            NavService = new NavigationService(Assembly);
        }

        #endregion

        #region Public Properties

        #endregion

        #region Internal Services

        internal static INavigationService NavService { get; private set; }

        #endregion

        #region Private

        #endregion
    }
}
