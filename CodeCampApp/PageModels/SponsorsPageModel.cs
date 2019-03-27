using CodeCampApp.Data.Models;
using CodeCampApp.Pages;
using OrlandoCodeCampApi.Models.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using static CodeCampApp.Data.Messaging.MessageHandler;

namespace CodeCampApp.PageModels
{
    public class SponsorsPageModel : BasePageModel
    {
        #region Enums

        #endregion

        #region Fields

        #endregion

        #region Constructors

        public SponsorsPageModel(NavigationState navState) : base(navState)
        {
            GetSponsorsCommand.Execute(null);
        }

        #endregion

        #region Service Mappings

        #endregion

        #region Data Properties

        public IList<Sponsor> Sponsors {get; private set; }

        public IList<SponsorLevel> SponsorLevels { get; private set; }

        #endregion

        #region Navigation Properties

        #endregion

        #region State Properties

        public override PageType PageType => PageType.Sponsors;

        #endregion

        #region Data Commands

        #region GetSponsorsCommand

        private Command GetSponsorsCommand =>
            new Command(async () =>
            {
                try
                {
                    var sponsorsTask = CodeCampService.GetSponsorsList();
                    var sponsorLevelsTask  = CodeCampService.GetSponsorLevels();

                    await Task.WhenAll(sponsorsTask, sponsorLevelsTask);

                    Sponsors = await sponsorsTask;
                    SponsorLevels = await sponsorLevelsTask;
                }
                catch (Exception exception)
                {
                    SendErrorMessage(exception);
                }

            });

        #endregion

        #endregion

        #region Navigation Commands

        #endregion

        #region State Commands

        #endregion

        #region Internal Methods

        #endregion

        #region Protected Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
