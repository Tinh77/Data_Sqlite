using FormContact.Entity;
using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FormContact
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class List : Page
    {
        private List<Contact> listContact;
        public List()
        {
            this.InitializeComponent();
            List_Contact();
        }

        internal List<Contact> ListContact { get => listContact; set => listContact = value; }

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
