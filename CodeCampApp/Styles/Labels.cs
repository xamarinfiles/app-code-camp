using Xamarin.Forms;

namespace CodeCampApp.Styles
{
    public static class Labels
    {
        #region Font Sizes

        // Use iOS font sizes
        public static readonly double FontSizeMicro = 12;   // Android is 10
        public static readonly double FontSizeSmall = 14;
        public static readonly double FontSizeMedium = 17;  // Android is 18
        public static readonly double FontSizeLarge = 22;

        #endregion

        #region Styles

        public static Style PageHeaderTitle { get; } = new Style(typeof(Label))
        {
            Setters =
            {
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
                }
            }
        };

        #region Nav Buttons

        private static Style NavButtonTitle { get; } = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter
                {
                    Property = View.HorizontalOptionsProperty,
                    Value = LayoutOptions.Center
                },
                new Setter
                {
                    Property = View.VerticalOptionsProperty,
                    Value = LayoutOptions.Start
                },
                new Setter
                {
                    Property = Label.FontSizeProperty,
                    Value = FontSizeMedium,
                },
                new Setter
                {
                    Property = Label.HorizontalTextAlignmentProperty,
                    Value = TextAlignment.Center,
                },
                new Setter
                {
                    Property = Label.TextColorProperty,
                    Value = Colors.NavButtonTitleUnselected
                }
            }
        };

        public static Style NavButtonSelectedTitle { get; } =
            new Style(typeof(Label))
        {
            BasedOn = NavButtonTitle,
            Setters =
            {
                new Setter
                {
                    Property = Label.TextColorProperty,
                    Value = Colors.NavButtonTitleSelected
                },
                new Setter
                {
                    Property = Label.FontAttributesProperty,
                    Value = FontAttributes.Bold
                }
            }
        };

        public static Style NavButtonUnselectedTitle { get; } =
            new Style(typeof(Label))
        {
            BasedOn = NavButtonTitle,
            Setters =
            {
                new Setter
                {
                    Property = Label.TextColorProperty,
                    Value = Colors.NavButtonTitleUnselected
                },
                new Setter
                {
                    Property = Label.FontAttributesProperty,
                    Value = FontAttributes.None
                }
            }
        };

        #endregion

        #endregion
    }
}
