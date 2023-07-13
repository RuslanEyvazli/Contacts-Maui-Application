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
        LoadContacts();

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

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
		var menuItem = sender as MenuItem;
		var contact = menuItem.CommandParameter as Contact;
		ContactRepository.DeleteContact(contact.ContactId);
		LoadContacts();
    }
	private void LoadContacts()
	{
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());

        listContacts.ItemsSource = contacts;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
		var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;

    }
}