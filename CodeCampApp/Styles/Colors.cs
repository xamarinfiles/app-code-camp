using Xamarin.Forms;

namespace CodeCampApp.Styles
{
    public static class Colors
    {
        #region Individual Colors

        #endregion

        #region Base Colors

        private static readonly Color DefaultBackground = Color.White;

        private static readonly Color DefaultSeparator = Color.DimGray;

        private static readonly Color DefaultText = Color.Black;

        #endregion

        #region Mapped Colors

        #region BoxViews

        public static readonly Color PageHeaderSeparator = DefaultSeparator;

        #endregion

        #region Labels

        public static readonly Color PageHeaderTitle = DefaultText;

        #endregion

        #region Pages

        public static readonly Color PageBackground = Color.White;

        #endregion

        #endregion
    }
}
