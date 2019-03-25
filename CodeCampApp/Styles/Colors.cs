using Xamarin.Forms;

namespace CodeCampApp.Styles
{
    // TODO Extract into theme or something else not specific to ONETUG
    // Color names from http://hex.negraru.com/<HexCodeWithoutHash>
    public static class Colors
    {
        #region Individual Colors

        #region ONETUG logo

        private static readonly Color SchoolBusYellow = Color.FromHex("#FFDD00");

        private static readonly Color AzureBlue = Color.FromHex("#386cb3");

        private static readonly Color SalemGreen = Color.FromHex("#0e8742");

        private static readonly Color FlamingoOrange = Color.FromHex("#F26122");

        #endregion

        #region CodeCamp website

        private static readonly Color MineshaftBlack = Color.FromHex("#222222");

        private static readonly Color SilverChalice = Color.FromHex("#9D9D9D");

        #endregion

        #endregion

        #region Default Colors

        private static readonly Color DefaultBackground = Color.White;

        private static readonly Color DefaultSeparator = Color.DimGray;

        private static readonly Color DefaultText = Color.Black;

        #endregion

        #region Mapped Colors

        #region BoxViews

        public static readonly Color PageSeparator = DefaultSeparator;

        #endregion

        #region Labels

        public static readonly Color NavButtonTitleSelected = Color.Black;

        public static readonly Color NavButtonTitleUnselected = SilverChalice;

        public static readonly Color PageHeaderTitle = DefaultText;

        #endregion

        #region Nav Bar Buttons

        public static readonly Color HomeButtonBackground = SchoolBusYellow;

        public static readonly Color AgendaButtonBackground = AzureBlue;

        public static readonly Color TimeslotsButtonBackground = SalemGreen;

        public static readonly Color TracksButtonBackground = FlamingoOrange;

        public static readonly Color MoreButtonBackground = Color.White;

        #endregion

        #region Pages

        public static readonly Color PageBackground = Color.White;

        #endregion

        #region Page Header

        public static readonly Color NavBarBackground = MineshaftBlack;

        #endregion

        #endregion
    }
}
