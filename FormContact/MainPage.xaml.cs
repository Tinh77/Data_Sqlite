using FormContact.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FormContact
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Contact> listContact;

        internal List<Contact> ListContact { get => listContact; set => listContact = value; }
        public MainPage()
        {
            this.InitializeComponent();
            List_Contact();
        }

        private void Create_Contact(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = Name.Text,
                Phone = Phone.Text,
                Email = Email.Text
            };
            ContactModel.AddData(contact);
            Debug.WriteLine("success");
        }

        private void List_Contact()
        {
            listContact = ContactModel.GetData();
            foreach (var item in listContact)
            {
                new Contact()
                {
                    Name = item.Name,
                    Phone = item.Phone,
                    Email = item.Email
                };
            }
        }

    }
}
