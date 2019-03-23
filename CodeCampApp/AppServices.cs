using Xamarin.Forms;

namespace CodeCampApp
{
    public partial class App : Application
    {
        #region Enums

        #endregion

        #region Fields

        #endregion

        #region Public

        public static void SetupServices()
        {
            Data.Messaging.MessageHandler.SubscribeToMessages();

            //MessageHandler.SendErrorMessage(
            //    new Exception("TEST EXCEPTION"), true);
            //MessageHandler.SendWarningMessage("TEST WARNING");
        }

        #endregion

        #region Interface

        #endregion

        #region Protected

        #endregion

        #region Internal

        #endregion

        #region Private

        #endregion

        #region Nested Types

        #endregion
    }
}
