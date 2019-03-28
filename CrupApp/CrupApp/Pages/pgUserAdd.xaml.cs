using CrupApp.Services;
using CrupApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrupApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class pgUserAdd : ContentPage
	{
        UserService _service = new UserService();
        public UserViewModel reciveModel { get; set; }

        public pgUserAdd (UserViewModel model)
		{
            if (model!=null)
            {
                reciveModel = model;
            }
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (reciveModel !=null)
            {
                txtName.Text = reciveModel.Name;
                txtPersonId.Text = reciveModel.Id.ToString();
            }
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            try
            {
                var user = new UserViewModel();
                user.Name = txtName.Text;
                user.IsActive = true;
                user.Id = Convert.ToInt32(txtPersonId.Text);

                var result = await _service.InsertAndUpdateUserAsync(user);
                if (result)
                {
                    await DisplayAlert("Success", "Insert Successfully", "OK");
                    //await Navigation.PushAsync(new MainPage());
                    await Navigation.PopAsync(); //previous page
                }
                else await DisplayAlert("Filed", "Try Again", "OK");
                
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            try
            {
                var user = new UserViewModel();
                user.Name = txtName.Text;
                user.IsActive = true;
                user.Id = Convert.ToInt32(txtPersonId.Text);

                var result = await _service.InsertAndUpdateUserAsync(user);
                if (result)
                {
                    await DisplayAlert("Success", "Update Successfully", "OK");
                    //await Navigation.PushAsync(new MainPage());
                    await Navigation.PopAsync(); //previous page
                }
                else await DisplayAlert("Filed", "Try Again", "OK");


            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            try
            {
                var warning = await DisplayAlert("Warning", "Are you sure?", "Yes", "No");
                if (warning)
                {
                    var result = await _service.DeleteUserById(Convert.ToInt32(txtPersonId.Text));
                    if (result)
                    {
                        await DisplayAlert("Success", "Delete Successfully", "OK");
                        //await Navigation.PushAsync(new MainPage());
                        await Navigation.PopAsync(); //previous page
                    }
                    else await DisplayAlert("Filed", "Try Again", "OK");
                }




            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", ex.Message, "OK");
            }
        }


    }
}