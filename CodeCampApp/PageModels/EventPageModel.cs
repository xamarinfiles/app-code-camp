using CodeCampApp.Data.Models;
using CodeCampApp.Pages;
using OrlandoCodeCampApi.Models.Responses;
using System;
using Xamarin.Forms;
using static CodeCampApp.Data.Messaging.MessageHandler;

namespace CodeCampApp.PageModels
{
    public class EventPageModel : BasePageModel
    {
        #region Enums

        #endregion

        #region Fields

        #endregion

        #region Constructors

        public EventPageModel(NavigationState navState) : base(navState)
        {
        }

        #endregion

        #region Service Mappings

        #endregion

        #region Data Properties

        public Event Event { get; private set; }

        #endregion

        #region Navigation Properties

        #endregion

        #region State Properties

        public override PageType PageType => PageType.Event;

        #endregion

        #region Data Commands

        #region GetEventCommand

        public Command GetEventCommand =>
            new Command(async () =>
            {
                try
                {
                    Event = await CodeCampService.GetActiveEvent();
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
