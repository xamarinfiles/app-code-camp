using CodeCampApp.Navigation;
using CodeCampApp.PageModels;
using CodeCampApp.Styles;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using static CodeCampApp.Data.Logging.OutputWindow;
using NavigationPage = Xamarin.Forms.NavigationPage;

namespace CodeCampApp.Pages
{
    public class BasePage<TViewModel> : ContentPage, IPageFor<TViewModel>
        where TViewModel : BasePageModel
    {
        #region Enums

        #endregion

        #region Fields

        #endregion

        #region Constructors

        [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
        public BasePage()
        {
            // Use footer nav bar and menu page instead of default header nav bar
            NavigationPage.SetHasNavigationBar(this, false);

            // Default page background color
            BackgroundColor = Colors.PageBackground;

            // Move iOS layout under status bar
            if (Device.RuntimePlatform == Device.iOS)
                On<iOS>().SetUseSafeArea(true);
        }

        #endregion

        #region Public

        #endregion

        #region Interface

        object IPageFor.PageModel
        {
            get => PageModel;
            set => PageModel = (TViewModel) value;
        }

        public TViewModel PageModel { get; set; }

        #endregion

        #region Protected Overrides

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // TODO TrackEvent in App Center
        }

        protected override bool OnBackButtonPressed()
        {
            PageModel.GoBackPageCommand.Execute(null);

            // TODO Add warning when trying to pop root page
            return true;
        }

        #endregion

        #region Bindable Properties

        #endregion

        #region Events

        #endregion

        #region Protected

        [Conditional("DEBUG")]
        protected static void PrintPageDimensions(double width, double height)
        {
            DebugWriteLine($"Page dimensions (W x H): {(int) width} X {(int) height}");
        }

        #endregion

        #region Private

        #endregion
    }
}
