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
                entryName.Text = contact.Name;
                entryEmail.Text = contact.Email;    
                entryPhone.Text = contact.Phone;
                entryAddress.Text = contact.Address;
            }
            //lblName.Text = contact.Name;
        } 
    }

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {
        contact.Name = entryName.Text;
        contact.Email = entryEmail.Text;
        contact.Phone = entryPhone.Text;
        contact.Address = entryAddress.Text;

        ContactRepository.UpdateContact(contact.ContactId, contact);
        await Shell.Current.GoToAsync("..");
    }
}