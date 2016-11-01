using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaserInlamningsuppgift1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            using (var db = new ContactList())
            {

                foreach (var contact in db.Contact)
                {
                    lboContacts.Items.Add(contact);
                }
            }
        }

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            using (var db = new ContactList())
            {
                db.Contact.Add(new Contact
                {
                    Name = txtName.Text,
                    Address = txtStreetAddress.Text,
                    ZipCode = txtZipCode.Text,
                    City = txtCity.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    Birthday = dtpDateOfBirth.Value
                });
                db.SaveChanges();

                lboContacts.Items.Clear();
                foreach (var contact in db.Contact)
                {
                    lboContacts.Items.Add(contact);
                }
            }
        }

        private void lboContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new ContactList())
            {
                if (lboContacts.SelectedItem != null)
                {
                    var c = ((Contact)lboContacts.SelectedItem);
                    txtName.Text = c.Name;
                    txtStreetAddress.Text = c.Address;
                    txtZipCode.Text = c.ZipCode;
                    txtCity.Text = c.City;
                    txtPhone.Text = c.Phone;
                    txtEmail.Text = c.Email;
                    dtpDateOfBirth.Value = c.Birthday;
                    //MessageBox.Show(c.Name + "\n" + c.Address + "\n" + c.ZipCode + "\n" + c.City + "\n" + c.Phone + "\n" +  c.Email + "\n" + c.Birthday);
                }    
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {

            using (var db = new ContactList())
            {
                if (lboContacts.SelectedItem != null)
                {
                    var c = ((Contact)lboContacts.SelectedItem);
                    db.Contact.Attach(c);
                    db.Contact.Remove(c);
                    db.SaveChanges();

                    lboContacts.Items.Clear();

                    foreach (var contact in db.Contact)
                    {
                        lboContacts.Items.Add(contact);
                    }
                }
            }        
        }

        public void DeleteContact(Contact s)
        {
            using (var db = new ContactList())
            {
                db.Contact.Remove(s);
                db.SaveChanges();
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtStreetAddress.Text = "";
            txtZipCode.Text = "";
            txtCity.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            dtpDateOfBirth.Value = DateTime.Now;
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            using (var db = new ContactList())
            {
                if (lboContacts.SelectedItem != null)
                {
                    var c = ((Contact)lboContacts.SelectedItem);
                    var f = db.Contact.First(i => i.ContactId == c.ContactId);
                    f.Name = txtName.Text;
                    f.Address = txtStreetAddress.Text;
                    f.ZipCode = txtZipCode.Text;
                    f.City = txtCity.Text;
                    f.Phone = txtPhone.Text;
                    f.Email = txtEmail.Text;
                    f.Birthday = dtpDateOfBirth.Value;

                    db.SaveChanges();

                    lboContacts.Items.Clear();

                    foreach (var contact in db.Contact)
                    {
                        lboContacts.Items.Add(contact);
                    }
                }
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            using (var db = new ContactList())
            {

                string search = txtSearch.Text;
                var o = from cont in db.Contact
                        where (cont.Name.Contains(search) || cont.Address.Contains(search) || cont.Phone.Contains(search) || 
                               cont.ZipCode.Contains(search) || cont.Email.Contains(search) || cont.City.Contains(search))
                        select cont;

                lboContacts.Items.Clear();

                foreach (var contact in o)
                {
                    lboContacts.Items.Add(contact);
                }
            }
        }

        private void cmdShowAll_Click(object sender, EventArgs e)
        {
            lboContacts.Items.Clear();
            using (var db = new ContactList())
            {
                foreach (var contact in db.Contact)
                {
                    lboContacts.Items.Add(contact);
                }
            }
        }
    }
}

