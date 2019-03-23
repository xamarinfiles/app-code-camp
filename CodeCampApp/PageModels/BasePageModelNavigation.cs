using CodeCampApp.Data.Models;
using CodeCampApp.Navigation;
using CodeCampApp.Pages;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using static CodeCampApp.Data.Logging.OutputWindow;
using static CodeCampApp.Data.Messaging.MessageHandler;
using static CodeCampApp.Data.Models.NavigationState;

namespace CodeCampApp.PageModels
{
    public abstract partial class BasePageModel
    {
        #region Enums

        #endregion

        #region Fields

        #endregion

        #region Service Mappings

        // TODO Make private
        internal static INavigationService NavService => App.NavService;

        #endregion

        #region Data Properties

        #endregion

        #region Navigation Properties

        public NavigationState NavState { get; set; }

        #endregion

        #region State Properties

        #endregion

        #region Data Commands

        #endregion

        #region Navigation Commands

        #region GoBackPageCommand

        public Command GoBackPageCommand =>
            new Command(async () =>
                await NavService.PopAsync()
            );

        #endregion

        #region Top-level pages (bottom nav bar)

        #region GoToHomePageCommand (left nav button)

        public Command GoToHomePageCommand =>
            new Command(async () =>
            {
                await ExecuteGoToPageCommand(PageType.Home, AppSection.Home);
            });

        #endregion

        #region GoToAgendaPageCommand (center-left nav button)

        public Command GoToAgendaPageCommand =>
            new Command(async () =>
            {
                await ExecuteGoToPageCommand(PageType.Agenda, AppSection.Agenda);
            });

        #endregion

        #region GoToTimeslotsPageCommand (center nav button)

        public Command GoToTimeslotsPageCommand =>
            new Command(async () =>
            {
                await ExecuteGoToPageCommand(PageType.Timeslots, AppSection.Timeslots);
            });

        #endregion

        #region GoToTracksPageCommand (center-right nav button)

        public Command GoToTracksPageCommand =>
            new Command(async () =>
            {
                await ExecuteGoToPageCommand(PageType.Tracks, AppSection.Tracks);
            });

        #endregion

        #region GoToMenuPageCommand (right nav button)

        public Command GoToMenuPageCommand =>
            new Command(async () =>
            {
                await ExecuteGoToPageCommand(PageType.Menu, AppSection.Menu);
            });

        #endregion

        #endregion

        #endregion

        #region State Commands

        #endregion

        #region Internal Methods

        #endregion

        #region Protected Methods

        #endregion

        #region Private Methods

        private async Task ExecuteGoToPageCommand(PageType nextPage,
            NavigationState.AppSection appSection)
        {
            await ExecuteGoToPageCommand(nextPage, new NavigationState(appSection));
        }

        private async Task ExecuteGoToPageCommand(PageType nextPage,
            NavigationState navState)
        {
            var currentPage = PageType;

            // Already on the page => ignore the request
            if (currentPage == nextPage)
                return;

            DebugWriteSubheader("Navigation initiated");
            DebugWriteValue("Current Page", currentPage);
            DebugWriteValue("Next Page", nextPage);

            try
            {
                switch (nextPage)
                {
                    //case PageType.Splash:
                    //    break;

                    // Top-level pages form parallel root pages

                    case PageType.Home:
                        await NavService.ReplaceRootAsync(
                            typeof(HomePageModel), navState);
                        break;
                    case PageType.Agenda:
                        await NavService.ReplaceRootAsync(
                            typeof(AgendaPageModel), navState);
                        break;
                    case PageType.Timeslots:
                        await NavService.ReplaceRootAsync(
                            typeof(TimeslotsPageModel), navState);
                        break;
                    case PageType.Tracks:
                        await NavService.ReplaceRootAsync(
                            typeof(TracksPageModel), navState);
                        break;
                    case PageType.Menu:
                        await NavService.ReplaceRootAsync(
                            typeof(MenuPageModel), navState);
                        break;

                    // Secondary pages off Menu

                    case PageType.Sponsors:
                        break;
                    case PageType.Speakers:
                        break;
                    case PageType.Event:
                        break;
                    case PageType.Settings:
                        break;
                    case PageType.About:
                        break;
                    case PageType.Developer:
                        break;
                }
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);
            }
        }

        #endregion
    }
}
