using CodeCampApp.Data.Messaging.Args;
using System;
using Xamarin.Forms;
using static CodeCampApp.Data.Logging.OutputWindow;
using static CodeCampApp.Data.Messaging.MessageType;

namespace CodeCampApp.Data.Messaging
{
    // TODO Convert to static service instead of importing static members everywhere
    public static class MessageHandler
    {
        #region Enums

        #endregion

        #region Constructors

        #endregion

        #region Public

        public static void SubscribeToMessages()
        {
            DebugWriteSubheader($"Subscribing to MessagingCenter messages ...");

            SubscribeToMessages<CrashArgs>(Crash);
            SubscribeToMessages<ErrorArgs>(Error);
            SubscribeToMessages<AnalyticsArgs>(Analytics);
            SubscribeToMessages<InformationArgs>(Information);
            SubscribeToMessages<WarningArgs>(Warning);

            //SendErrorMessage(new Exception("TEST EXCEPTION"), true);
            //SendWarningMessage("TEST WARNING");
        }

        #region Send Methods

        public static void SendErrorMessage(Exception exception,
            bool showStackTrace = false)
        {
            try
            {
                var errorArgs = new ErrorArgs
                {
                    Exception = exception,
                    ShowStackTrace = showStackTrace
                };

                if (ErrorMessagingAvailable)
                    MessagingCenter.Send(Application.Current, Error.ToString(),
                        errorArgs);
                else
                    DebugWriteException(exception);
            }
            catch (Exception sendException)
            {
                DebugWriteException(sendException);
            }
        }

        public static void SendWarningMessage(string warning)
        {
            try
            {
                var warningArgs = new WarningArgs
                {
                    Message = warning
                };

                MessagingCenter.Send(Application.Current, Warning.ToString(), warningArgs);
            }
            catch (Exception exception)
            {
                DebugWriteException(exception);
            }
        }

        #endregion

        #endregion

        #region Interface

        #endregion

        #region Protected

        #endregion

        #region Internal

        #endregion

        #region Private

        private static bool AnalyticsMessagingAvailable { get; set; }
        private static bool CrashMessagingAvailable { get; set; }
        private static bool ErrorMessagingAvailable { get; set; }
        private static bool InformationMessagingAvailable { get; set; }
        private static bool WarningMessagingAvailable { get; set; }

        private static void SubscribeToMessages<TBaseArgs>(
            MessageType messageType) where TBaseArgs : BaseArgs
        {
            Action<Application, TBaseArgs> callback = null;

            switch (messageType)
            {
                case Analytics:
                    callback =
                        (app, args) => ProcessAnalyticsMessage(args as AnalyticsArgs);
                    break;
                case Crash:
                    callback = (app, args) => ProcessCrashMessage(args as CrashArgs);
                    break;
                case Error:
                    callback = (app, args) => ProcessErrorMessage(args as ErrorArgs);
                    break;
                case Information:
                    callback =
                        (app, args) => ProcessInformationMessage(args as InformationArgs);
                    break;
                case Warning:
                    callback = (app, args) => ProcessWarningMessage(args as WarningArgs);
                    break;
            }

            if (callback == null) return;

            MessagingCenter.Subscribe(Application.Current,
                messageType.ToString(),
                callback);

            DebugWriteValue($"{messageType.ToString()} messages", "Subscribed");

            switch (messageType)
            {
                case Analytics:
                    AnalyticsMessagingAvailable = true;
                    break;
                case Crash:
                    CrashMessagingAvailable = true;
                    break;
                case Error:
                    ErrorMessagingAvailable = true;
                    break;
                case Information:
                    InformationMessagingAvailable = true;
                    break;
                case Warning:
                    WarningMessagingAvailable = true;
                    break;
            }
        }

        private static void ProcessAnalyticsMessage(AnalyticsArgs analyticsArgs)
        {
            DebugWriteSubheader("ANALYTICS MESSAGE");

            // TODO
        }

        private static void ProcessCrashMessage(CrashArgs args)
        {
            DebugWriteSubheader("CRASH MESSAGE");

            // TODO
        }

        private static void ProcessErrorMessage(ErrorArgs errorArgs)
        {
            DebugWriteException(errorArgs.Exception, errorArgs.ShowStackTrace);

            // TODO Send error to App Center
        }

        private static void ProcessInformationMessage(InformationArgs args)
        {
            DebugWriteInformation(args.Message);

            // TODO
        }

        private static void ProcessWarningMessage(WarningArgs args)
        {
            DebugWriteWarning(args.Message);

            // TODO
        }

        #endregion

        #region Nested Types

        #endregion
    }
}
