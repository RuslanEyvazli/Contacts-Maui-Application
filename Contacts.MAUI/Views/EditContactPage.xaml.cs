using Contacts.MAUI.Models;
using Contact = Contacts.MAUI.Models.Contact;
namespace Contacts.MAUI.Views;


[QueryProperty(nameof(ContactId),"id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;
	public EditContactPage()
	{
		InitializeComponent();
	}
    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
    public string ContactId { 
        set {
            contact = ContactRepository.GetContactById(int.Parse(value));
            if (contact != null)
            {
                contactCtrl.Name = contact.Name;
                contactCtrl.Email = contact.Email;    
                contactCtrl.Phone = contact.Phone;
                contactCtrl.Address = contact.Address;
            }
            //lblName.Text = contact.Name;
        } 
    }

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {

        contact.Name = contactCtrl.Name;
        contact.Email = contactCtrl.Email;
        contact.Phone = contactCtrl.Phone;
        contact.Address = contactCtrl.Address;

        ContactRepository.UpdateContact(contact.ContactId, contact);
        await Shell.Current.GoToAsync("..");
    }


    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}