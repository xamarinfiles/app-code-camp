using Xamarin.Forms;

namespace CodeCampApp.Styles
{
    class BoxViews
    {
        public static Style PageSeparator { get; } =
            new Style(typeof(BoxView))
            {
                Setters =
                {
                    new Setter
                    {
                        Property = BoxView.ColorProperty,
                        Value = Colors.PageSeparator
                    },
                    new Setter
                    {
                        Property = VisualElement.HeightRequestProperty,
                        Value = 1
                    }
                }
            };

        public static Style PageHeaderSeparator { get; } =
            new Style(typeof(BoxView))
        {
            BasedOn = PageSeparator,
            Setters =
            {
                new Setter
                {
                    Property = View.VerticalOptionsProperty,
                    Value = LayoutOptions.End
                }
            }
        };

        public static Style PageFooterSeparator { get; } =
            new Style(typeof(BoxView))
            {
                BasedOn = PageSeparator,
                Setters =
                {
                    new Setter
                    {
                        Property = View.VerticalOptionsProperty,
                        Value = LayoutOptions.Start
                    }
                }
            };
    }
}
