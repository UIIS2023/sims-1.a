﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using InitialProject.Model;
using InitialProject.WPF.Views;
using SixLabors.ImageSharp.Metadata.Profiles.Xmp;
using System.Windows.Navigation;
using InitialProject.WPF.Views.OwnerViews;

namespace InitialProject.WPF.ViewModels.OwnerViewModels
{
    public class MenuViewModel
    {
        private Owner owner;
        public RelayCommand HomePageCommand { get; set; }
        public RelayCommand MyAccommodationCommand { get; set; }
        public RelayCommand MyProfileCommand { get; set; }
        public RelayCommand SignOutCommand { get; set; }
        public RelayCommand MyRequestsCommand { get; set; }
        public RelayCommand GuestReviewsCommand { get; set; }
        public RelayCommand MyRenovationsCommand { get; set; }
        public RelayCommand MyForumsCommand { get; set; }
        public RelayCommand SuggestionCommand { get; set; }
        public MenuViewModel(Owner owner)
        {
            this.owner = owner;
            MakeCommands();
        }

        private void MakeCommands()
        {
            HomePageCommand = new RelayCommand(HomePage_Executed, CanExecute);
            MyAccommodationCommand = new RelayCommand(MyAccommodation_Executed, CanExecute);
            MyProfileCommand = new RelayCommand(MyProfile_Executed, CanExecute);
            SignOutCommand = new RelayCommand(SignOut_Executed, CanExecute);
            MyRequestsCommand = new RelayCommand(MyRequests_Executed, CanExecute);
            GuestReviewsCommand = new RelayCommand(GuestReviews_Executed, CanExecute);
            MyRenovationsCommand = new RelayCommand(MyRenovations_Executed, CanExecute);
            MyForumsCommand = new RelayCommand(MyForums_Executed, CanExecute);
            SuggestionCommand = new RelayCommand(Suggestion_Executed, CanExecute);
        }
        private bool CanExecute(object sender)
        {
            return true;
        }

        private void HomePage_Executed(object sender)
        {

            OwnerOverviewView ownerOverviewView = new OwnerOverviewView(owner);
            Application.Current.Windows.OfType<OwnerMainWindowView>().FirstOrDefault().FrameForPages.Content = ownerOverviewView;
        }
        private void MyAccommodation_Executed(object sender)
        {
            AccommodationView accommodationView = new AccommodationView(owner);
            Application.Current.Windows.OfType<OwnerMainWindowView>().FirstOrDefault().FrameForPages.Content = accommodationView;
        }

        private void MyProfile_Executed(object sender)
        {
            MyProfileView myProfile = new MyProfileView(owner);
            Application.Current.Windows.OfType<OwnerMainWindowView>().FirstOrDefault().FrameForPages.Content = myProfile;
        }

        private void SignOut_Executed(object sender)
        {
            SignInForm signInForm = new SignInForm();
            signInForm.Show();
            Application.Current.Windows.OfType<OwnerMainWindowView>().FirstOrDefault().Close();
        }

        private void MyRequests_Executed(object sender)
        {
            ReservationReschedulingView reschedulingView = new ReservationReschedulingView(owner);
            Application.Current.Windows.OfType<OwnerMainWindowView>().FirstOrDefault().FrameForPages.Content = reschedulingView;
        }

        private void GuestReviews_Executed(object sender)
        {
            GuestReviewView guestReviewView = new GuestReviewView(owner);
            Application.Current.Windows.OfType<OwnerMainWindowView>().FirstOrDefault().FrameForPages.Content = guestReviewView;
        }

        private void MyRenovations_Executed(object sender)
        {
            MyRenovationsView myRenovationsView = new MyRenovationsView(owner);
            Application.Current.Windows.OfType<OwnerMainWindowView>().FirstOrDefault().FrameForPages.Content = myRenovationsView;
        }
        private void MyForums_Executed(object sender)
        {
            ForumsView forumsView = new ForumsView(owner);
            Application.Current.Windows.OfType<OwnerMainWindowView>().FirstOrDefault().FrameForPages.Content = forumsView;
        }

        private void Suggestion_Executed(object sender)
        {
            LocationSuggestionsView suggestionsView = new LocationSuggestionsView(owner);
            Application.Current.Windows.OfType<OwnerMainWindowView>().FirstOrDefault().FrameForPages.Content = suggestionsView;
        }
    }
}
