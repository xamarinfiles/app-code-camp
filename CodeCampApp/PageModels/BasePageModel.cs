using System.Diagnostics.CodeAnalysis;
using CodeCampApp.Data.Models;
using CodeCampApp.Pages;
using static CodeCampApp.Data.Logging.OutputWindow;

namespace CodeCampApp.PageModels
{
    public abstract class BasePageModel
    {
        #region Enums

        #endregion

        #region Fields

        #endregion

        #region Constructors

        protected BasePageModel()
        {
            DebugWriteHeader(PageTitle);
        }

        #endregion

        #region Service Mappings

        #endregion

        #region Data Properties

        #endregion

        #region Navigation Properties

        public NavigationState NavState { get; set; }

        #endregion

        #region State Properties

        public bool PageIsWaiting { get; set; }

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public string PageName => PageType.ToString();

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public string PageTitle => PageType.PageTitle(NavState);

        public abstract PageType PageType { get; }

        #endregion

        #region Data Commands

        #endregion

        #region Navigation Commands

        #endregion

        #region State Commands

        #endregion

        #region Internal Methods

        #endregion

        #region Protected Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
