namespace Contacts.MAUI.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("..");
    }
}