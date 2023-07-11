using Contacts.MAUI.Models;
using System.Diagnostics.Metrics;
using Contact = Contacts.MAUI.Models.Contact;
using System.Collections.ObjectModel;
namespace Contacts.MAUI.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
		List<Contact> contacts = ContactRepository.GetContacts();
		
		listContacts.ItemsSource = contacts;
	}
    protected override void OnAppearing()
	{
		base.OnAppearing();
		var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());

		listContacts.ItemsSource = contacts;
	}
	private void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if(listContacts.SelectedItem != null)
		{
			// Logic
			Shell.Current.GoToAsync($"{nameof(EditContactPage)}?id={((Contact)listContacts.SelectedItem).ContactId}");
		}
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		listContacts.SelectedItem = null;
    }
}