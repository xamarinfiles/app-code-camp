﻿using CodeCampApp.Data.Models;
using CodeCampApp.Pages;
using OrlandoCodeCampApi.Models.Responses;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static CodeCampApp.Data.Messaging.MessageHandler;

namespace CodeCampApp.PageModels
{
    public class HomePageModel : BasePageModel
    {
        #region Enums

        #endregion

        #region Fields

        #endregion

        #region Constructors

        public HomePageModel(NavigationState navState) : base(navState)
        {
            GetAnnouncementsCommand.Execute(null);
        }

        #endregion

        #region Service Mappings

        #endregion

        #region Data Properties
        public IList<Announcement> Announcements { get; private set; }

        #endregion

        #region Navigation Properties

        #endregion

        #region State Properties

        public override PageType PageType => PageType.Home;

        #endregion

        #region Data Commands

        #region GetAccouncementsCommand

        public Command GetAnnouncementsCommand =>
            new Command(async () =>
            {
                try
                {
                    Announcements = await CodeCampService.GetAnnouncementsList();
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
