using CodeCampApp.Data.Models;
using CodeCampApp.Navigation;
using CodeCampApp.Pages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using static CodeCampApp.Data.Logging.OutputWindow;
using static CodeCampApp.Data.Messaging.MessageHandler;
using static CodeCampApp.Data.Models.NavigationState;
using static CodeCampApp.Styles.Colors;
using static CodeCampApp.Styles.Labels;

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

        #region Navigation Properties

        public IList<FooterNavItem> FooterNavItems { get; }

        public NavigationState NavState { get; }

        #endregion

        #region Navigation Commands

        #region GoBackPageCommand

        public Command GoBackPageCommand =>
            new Command(async () =>
                await NavService.PopAsync()
            );

        #endregion

        #region GoToNavBarPageCommand

        public Command<AppSection> GoToNavBarPageCommand =>
            new Command<AppSection>(appSection =>
            {
                switch (appSection)
                {
                    case AppSection.Home:
                        GoToHomePageCommand.Execute(null);
                        break;
                    case AppSection.Agenda:
                        GoToAgendaPageCommand.Execute(null);
                        break;
                    case AppSection.Timeslots:
                        GoToTimeslotsPageCommand.Execute(null);
                        break;
                    case AppSection.Tracks:
                        GoToTracksPageCommand.Execute(null);
                        break;
                    case AppSection.More:
                        GoToMorePageCommand.Execute(null);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(appSection), appSection, null);
                }
            });

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

        #region GoToMorePageCommand (right nav button)

        public Command GoToMorePageCommand =>
            new Command(async () =>
            {
                await ExecuteGoToPageCommand(PageType.More, AppSection.More);
            });

        #endregion

        #endregion

        #endregion

        #region Internal Methods

        #endregion

        #region Protected Methods

        #endregion

        #region Private Methods

        private IList<FooterNavItem> BuildNavigationMenu()
        {
            var footerNavItems = new List<FooterNavItem>();

            AddFooterNavItem(AppSection.Home, HomeButtonBackground);
            AddFooterNavItem(AppSection.Agenda, AgendaButtonBackground);
            AddFooterNavItem(AppSection.Timeslots, TimeslotsButtonBackground);
            AddFooterNavItem(AppSection.Tracks, TracksButtonBackground);
            AddFooterNavItem(AppSection.More, MoreButtonBackground);

            return footerNavItems;

            void AddFooterNavItem(AppSection appSection, Color selectedBackground)
            {
                var isSelected = appSection == NavState.AppSectionSelected;
                var labelStyle = isSelected
                    ? NavButtonSelectedTitle
                    : NavButtonUnselectedTitle;
                var navItem = new FooterNavItem
                {
                    AppSection = appSection,
                    IsSelected = isSelected,
                    LabelText = appSection.ToString(),
                    LabelStyle = labelStyle,
                    // TODO image
                    ButtonBackground = isSelected ? selectedBackground : Color.Transparent,
                    NavigationCommand = GoToNavBarPageCommand
                };

                footerNavItems.Add(navItem);
            }
        }

        private async Task ExecuteGoToPageCommand(PageType nextPage,
            AppSection appSection)
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
                    case PageType.More:
                        await NavService.ReplaceRootAsync(
                            typeof(MorePageModel), navState);
                        break;

                    // Secondary pages off More

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
