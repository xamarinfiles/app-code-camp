using CodeCampApp.Data.Api;
using OrlandoCodeCampApi.Models.Responses;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static CodeCampApp.Data.Messaging.MessageHandler;

namespace CodeCampApp.PageModels
{
    public abstract partial class BasePageModel
    {
        #region Enums

        #endregion

        #region Fields

        #endregion

        #region Service Mappings

        protected static CodeCampService CodeCampService => App.CodeCampService;

        #endregion

        #region Data Properties

        public IList<Session> Sessions {get; private set; }

        public IList<Speaker> Speakers { get; private set; }

        public IList<Timeslot> Timeslots { get; private set; }

        public IList<Track> Tracks { get; private set; }

        #endregion

        #region Data Commands

        #region GetSessionsCommand

        public Command GetSessionsCommand =>
            new Command(async () =>
            {
                try
                {
                    Sessions = await CodeCampService.GetSessionsList();
                }
                catch (Exception exception)
                {
                    SendErrorMessage(exception);
                }
            });

        #endregion

        #region GetSpeakersCommand

        public Command GetSpeakersCommand =>
            new Command(async () =>
            {
                try
                {
                    Speakers = await CodeCampService.GetSpeakersList();
                }
                catch (Exception exception)
                {
                    SendErrorMessage(exception);
                }
            });

        #endregion

        #region GetTimeslotsCommand

        public Command GetTimeslotsCommand =>
            new Command(async () =>
            {
                try
                {
                    Timeslots = await CodeCampService.GetTimeslotsList();
                }
                catch (Exception exception)
                {
                    SendErrorMessage(exception);
                }
            });

        #endregion

        #region GetTracksCommand

        public Command GetTracksCommand =>
            new Command(async () =>
            {
                try
                {
                    Tracks = await CodeCampService.GetTracksList();
                }
                catch (Exception exception)
                {
                    SendErrorMessage(exception);
                }
            });

        #endregion

        #endregion

        #region Internal Methods

        #endregion

        #region Protected Methods

        #endregion

        #region Private Methods

        private void LoadCommonData()
        {
            GetTimeslotsCommand.Execute(null);
            GetTracksCommand.Execute(null);
            GetSessionsCommand.Execute(null);
            GetSpeakersCommand.Execute(null);
        }

        #endregion
    }
}
