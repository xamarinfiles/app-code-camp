using System;
using static CodeCampApp.Data.Messaging.MessageHandler;

namespace CodeCampApp.Data.Models
{
    public class NavigationState
    {
        #region Enums

        public enum AppSection
        {
            Splash,
            Home,
            Agenda,
            Timeslots,
            Tracks,
            Menu,
            Modal
        }

        #endregion

        #region Fields

        #endregion

        #region Constructors

        public NavigationState(AppSection appSection)
        {
            try
            {
                AppSectionSelected = appSection;
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);
            }

        }

        #endregion

        #region Public

        // Primary navigation (nav bar)
        public AppSection AppSectionSelected { get; }

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
