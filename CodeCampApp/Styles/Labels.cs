using Xamarin.Forms;
using static Xamarin.Forms.NamedSize;

namespace CodeCampApp.Styles
{
    public static class Labels
    {
        #region Font Sizes

        public static readonly double FontSizeMicro = GetNamedFontSize(Micro);
        public static readonly double FontSizeSmall = GetNamedFontSize(Small);
        public static readonly double FontSizeMedium = GetNamedFontSize(Medium);
        public static readonly double FontSizeLarge = GetNamedFontSize(Large);

        #endregion

        #region Styles

        public static Style PageHeaderTitle => new Style(typeof(Label))
        {
            Setters =
            {
                new Setter
                {
                    Property = View.VerticalOptionsProperty,
                    Value = LayoutOptions.FillAndExpand
                },
                new Setter
                {
                    Property = Label.HorizontalTextAlignmentProperty,
                    Value = TextAlignment.Center
                },
                new Setter
                {
                    Property = Label.VerticalTextAlignmentProperty,
                    Value = TextAlignment.Center
                },
                new Setter
                {
                    Property = Label.FontSizeProperty,
                    Value = FontSizeLarge,
                },
                new Setter
                {
                    Property = Label.FontAttributesProperty,
                    Value = FontAttributes.Bold,
                },
                new Setter
                {
                    Property = Label.LineBreakModeProperty,
                    Value = LineBreakMode.TailTruncation
                },
                new Setter
                {
                    Property = Label.TextColorProperty,
                    Value = Colors.PageHeaderTitle
                },
            }
        };

        #endregion

        #region private

        private static double GetNamedFontSize(NamedSize namedSize)
        {
            var fontSize = Device.GetNamedSize(namedSize, typeof(Label));

            return fontSize;
        }

        #endregion
    }
}
