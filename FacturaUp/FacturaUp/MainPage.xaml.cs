using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturaUp.Models;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace FacturaUp
{
	public partial class MainPage : TabbedPage
    {
	    private ObservableCollection<Accountant> _accountants;
	    private Accountant _accountantService;

        public MainPage()
		{
			InitializeComponent();
		    _accountantService = new Accountant();

		    listviewAccounters.ItemsSource = _accountantService.GetAccountants("");

		}

        private async void BtnTakePicture_OnClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    DisplayAlert("No Camara", ":( No camara disponible.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

                //await DisplayAlert("File Location", file.Path, "OK");

                imageInvoice.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
            else
            {
                DisplayAlert("No Camara", "Debe darle permiso a la camara", "OK");
                return;
            }
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ListviewAccounters_OnRefreshing(object sender, EventArgs e)
        {
            listviewAccounters.ItemsSource = _accountantService.GetAccountants("");
            listviewAccounters.EndRefresh();
        }

	    private void MenuItem_OnClicked(object sender, EventArgs e)
	    {
	        //throw new NotImplementedException();
	    }
	}
}
