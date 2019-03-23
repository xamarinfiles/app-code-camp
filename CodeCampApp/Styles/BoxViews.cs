using Xamarin.Forms;

namespace CodeCampApp.Styles
{
    class BoxViews
    {
        public static Style PageHeaderSeparator => new Style(typeof(BoxView))
        {
            Setters =
            {
                new Setter
                {
                    Property = View.VerticalOptionsProperty,
                    Value = LayoutOptions.End
                },
                new Setter
                {
                    Property = BoxView.ColorProperty,
                    Value = Colors.PageHeaderSeparator
                },
                new Setter
                {
                    Property = VisualElement.HeightRequestProperty,
                    Value = 1
                }
            }
        };
    }
}
