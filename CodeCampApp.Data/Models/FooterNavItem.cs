using Xamarin.Forms;
using static CodeCampApp.Data.Models.NavigationState;

namespace CodeCampApp.Data.Models
{
    public class FooterNavItem
    {
        #region Enums

        #endregion

        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Public

        public AppSection AppSection { get; set; }

        public bool IsSelected { get; set; }

        public Color ButtonBackground { get; set; }

        public string LabelText { get; set; }

        public Style LabelStyle { get; set; }

        public string Image { get; set; }

        public Command<AppSection> NavigationCommand { get; set; }

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
