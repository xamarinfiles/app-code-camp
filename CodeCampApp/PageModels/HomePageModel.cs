using CodeCampApp.Data.Models;
using CodeCampApp.Pages;

namespace CodeCampApp.PageModels
{
    public class HomePageModel : BasePageModel
    {
        #region Enums

        #endregion

        #region Fields

        #endregion

        #region Constructors

        public HomePageModel(NavigationState navState) : base(navState)
        {
        }

        #endregion

        #region Service Mappings

        #endregion

        #region Data Properties

        #endregion

        #region Navigation Properties

        #endregion

        #region State Properties

        public override PageType PageType => PageType.Home;

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
