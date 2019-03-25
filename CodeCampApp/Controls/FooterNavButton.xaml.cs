using System;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;
using static CodeCampApp.Data.Messaging.MessageHandler;
using static CodeCampApp.Data.Models.NavigationState;

namespace CodeCampApp.Controls
{
    public partial class FooterNavButton : ContentView
    {
        #region Enums

        #endregion

        #region Constructors

        public FooterNavButton()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception exception)
            {
                SendErrorMessage(exception);
            }
        }

        #endregion

        #region Protected Overrides

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var context = BindingContext;
        }

        #endregion

        #region Bindable Properties

        #region CurrentAppSection

        public AppSection CurrentAppSection
        {
            get => (AppSection)GetValue(CurrentAppSectionProperty);
            set => SetValue(CurrentAppSectionProperty, value);
        }

        [SuppressMessage("ReSharper", "RedundantArgumentName")]
        private static readonly BindableProperty CurrentAppSectionProperty =
            BindableProperty.Create(
                propertyName: nameof(CurrentAppSection),
                returnType: typeof(AppSection),
                declaringType: typeof(FooterNavButton),
                defaultValue: default(AppSection));

        #endregion

        #region IsSelected

        public bool IsSelected
        {
            get => (bool) GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        [SuppressMessage("ReSharper", "RedundantArgumentName")]
        private static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(
                propertyName: nameof(IsSelected),
                returnType: typeof(bool),
                declaringType: typeof(FooterNavButton),
                defaultValue: true);

        #endregion

        #endregion

        #region Properties

        #endregion

        #region Events

        #endregion

        #region Delegates

        #endregion

        #region Private

        #endregion
    }
}
