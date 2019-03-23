using Xamarin.Forms;

namespace CodeCampApp.Styles
{
    public class Dimensions
    {
        #region Common page row heights

        private static readonly int HeaderFooterHeight = 60;

        public static GridLength PageHeaderRowHeight = new GridLength(HeaderFooterHeight);

        public static GridLength FooterMenuRowHeight = new GridLength(HeaderFooterHeight);

        #endregion
    }
}
