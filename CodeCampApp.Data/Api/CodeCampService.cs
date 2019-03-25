using OrlandoCodeCampApi;
using OrlandoCodeCampApi.Models.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xamarin.Forms;
using static CodeCampApp.Data.Logging.OutputWindow;
using static CodeCampApp.Data.Messaging.MessageHandler;

namespace CodeCampApp.Data.Api
{
    // TODO Use EventId for other years
    [SuppressMessage("ReSharper", "ConvertIfStatementToNullCoalescingExpression")]
    public class CodeCampService
    {
        #region Fields

        private readonly CodeCampApi _codeCampService;

        // HACK before caching
        private IList<Announcement> _announcements;
        private Event _event;
        private IList<Session> _sessions;
        private IList<Speaker> _speakers;
        private IList<Sponsor> _sponsors;
        private IList<SponsorLevel> _sponsorLevels;
        private IList<Timeslot> _timeslots;
        private IList<Track> _tracks;

        #endregion

        #region Constructors

        public CodeCampService(string baseUrl)
        {
            _codeCampService = new CodeCampApi(baseUrl);

            DebugWriteHeader("Code Camp Service");
            DebugWriteValue("Base URL", baseUrl);

            PrefetchCommand.Execute(null);
        }

        #endregion

        #region Public

        #region Announcements

        public async Task<IList<Announcement>> GetAnnouncementsList()
        {
            try
            {
                if (_announcements == null)
                    _announcements = await _codeCampService.GetAnnouncementsList();

                return _announcements;
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);

                return null;
            }
        }

        #endregion

        #region Events

        public async Task<Event> GetActiveEvent()
        {
            try
            {
                if (_event == null)
                    _event = await _codeCampService.GetActiveEvent();

                return _event;
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);

                return null;
            }
        }

        #endregion

        #region Sessions

        // TODO Filter parameters
        public async Task<IList<Session>> GetSessionsList()
        {
            try
            {
                if (_sessions == null)
                    _sessions = await _codeCampService.GetSessionsList();

                return _sessions;
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);

                return null;
            }
        }

        public async Task<Session> GetSession(int sessionId,
            bool? includeDescription = null)
        {
            try
            {
                var session = await _codeCampService.GetSession(sessionId, includeDescription);

                return session;
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);

                return null;
            }
        }

        #endregion

        #region Speakers

        public async Task<IList<Speaker>> GetSpeakersList(bool? includeDetails = null)
        {
            try
            {
                if (_speakers == null)
                    _speakers =
                        await _codeCampService.GetSpeakersList(includeDetails: includeDetails);

                return _speakers;
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);

                return null;
            }
        }

        public async Task<Speaker> GetSpeaker(int speakerId, bool? includeDetails = null)
        {
            try
            {
                var speaker =
                    await _codeCampService.GetSpeaker(speakerId, includeDetails);

                return speaker;
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);

                return null;
            }
        }

        public Uri GetSpeakerImageUri(int speakerId)
        {
            try
            {
                var speakerImage = _codeCampService.GetSpeakerImageUrl(speakerId);

                return speakerImage;
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);

                return null;
            }
        }

        #endregion

        #region Sponsors

        public async Task<IList<Sponsor>> GetSponsorsList()
        {
            try
            {
                if (_sponsors == null)
                    _sponsors = await _codeCampService.GetSponsorsList();

                return _sponsors;
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);

                return null;
            }
        }

        public async Task<IList<SponsorLevel>> GetSponsorLevels()
        {
            try
            {
                if (_sponsorLevels == null)
                    _sponsorLevels = await _codeCampService.GetSponsorLevels();

                return _sponsorLevels;
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);

                return null;
            }
        }

        public Uri GetSponsorImageUrl(int sponsorId)
        {
            try
            {
                var sponsorImage = _codeCampService.GetSponsorImageUrl(sponsorId);

                return sponsorImage;
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);

                return null;
            }
        }

        #endregion

        #region Timeslots

        public async Task<IList<Timeslot>> GetTimeslotsList()
        {
            try
            {
                if (_timeslots == null)
                    _timeslots = await _codeCampService.GetTimeslotsList();

                return _timeslots;
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);

                return null;
            }
        }

        #endregion

        #region Tracks

        public async Task<IList<Track>> GetTracksList()
        {
            try
            {
                if (_tracks == null)
                    _tracks = await _codeCampService.GetTracksList();

                return _tracks;
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);

                return null;
            }
        }

        #endregion

        #endregion

        #region Private

        #region PrefectchCommand

        public Command PrefetchCommand =>
            new Command(async () =>
            {
                // TODO Ensure cache is initialized

                var announcementsTask = GetAnnouncementsList();
                var timeslotsTask = GetTimeslotsList();
                var tracksTask = GetTracksList();

                var sessionsTask = GetSessionsList();
                var speakersTask = GetSpeakersList();

                var sponsorsTask = GetSponsorsList();
                var sponsorLevelsTask = GetSponsorLevels();

                var eventTask = GetActiveEvent();

                await Task.WhenAll(announcementsTask, timeslotsTask, tracksTask);

                await Task.WhenAll(sessionsTask, speakersTask);

                await Task.WhenAll(sponsorsTask, sponsorLevelsTask);

                await Task.WhenAll(eventTask);

            });

        #endregion


        #endregion
    }
}
