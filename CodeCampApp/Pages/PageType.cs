namespace CodeCampApp.Pages
{
    public enum PageType
    {
        // Divide pages into intro, primary, and secondary allows for quick calculations
        // Examples:
        // PageType >= Home && <= Menu => top-level page on nav bar
        // PageType > Menu => secondary page off one of pages on nav bar

        #region Loading pages (before Home) < 10^2

        Splash = 10,

        // TODO Reserve low numbers for loading, instructions, settings selection, etc

        #endregion

        #region Top-level pages (off bottom menu) and their children >= 10^2 < 10^3

        #region Home page (left button - root of top-level pages)

        Home = 100,

        #endregion

        #region Agenda (center-left button)

        Agenda = 200,

        #endregion

        #region Timeslots (center button)

        Timeslots = 300,

        #endregion

        #region Tracks (center-right button)

        Tracks = 400,

        #endregion

        #region Menu (right button - root of secondary pages)

        Menu = 500,

        #endregion

        #endregion

        #region Secondary pages (off menu page) and their children >= 10^3

        Sponsors = 1000,

        Speakers = 1100,

        Event = 1200,

        Settings = 1300,

        About = 1400,

        Developer = 1500

        #endregion
    }
}