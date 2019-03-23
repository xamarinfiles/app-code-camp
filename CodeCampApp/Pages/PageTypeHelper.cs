using CodeCampApp.Data.Models;
using System;
using static CodeCampApp.Data.Messaging.MessageHandler;

namespace CodeCampApp.Pages
{
    public static class PageTypeHelper
    {
        #region Enums

        #endregion

        #region Fields

        #endregion

        #region Constructors

        public static string PageTitle(this PageType pageType, NavigationState navState)
        {
            var pageTitle = "";

            try
            {
                // Override page title from PageType to make more user-friendly
                switch (pageType)
                {
                    default:
                        // Use PageType for default page title and navigation testing
                        pageTitle = pageType.ToString();
                        break;
                }
            }
            catch (Exception exception)
            {
                // exception.Data.Add(,);

                SendErrorMessage(exception);
            }

            return pageTitle;
        }

        #endregion

        #region Public

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
