using Xamarin.Forms;

namespace CodeCampApp.Styles
{
    public class Dimensions
    {
        public static double PageWidth => Device.Info.ScaledScreenSize.Width;

        #region Common page row heights

        private static readonly int HeaderFooterHeight = 60;

        public static GridLength PageHeaderRowHeight =
            new GridLength(HeaderFooterHeight);

        public static GridLength FooterMenuRowHeight =
            new GridLength(HeaderFooterHeight);

        #endregion

        #region Nav Menu Button

        public static readonly double NavButtonImageSize = 28;

        // Make nav buttons the same width
        public static readonly double NavButtonWidth = PageWidth / 5;

        //public static GridLength NavButtonRowHeight =
        //    new GridLength(NavButtonComponentHeight);

        #endregion
    }
}
