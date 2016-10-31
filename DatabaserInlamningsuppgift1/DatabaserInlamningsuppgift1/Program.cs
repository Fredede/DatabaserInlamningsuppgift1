using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaserInlamningsuppgift1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //using (var db = new ContactList())
            //{
                //db.Contact.Add(new Contact { Name = "First Name1" });
                //db.SaveChanges();

                //foreach (var contact in db.Contact)
                //{
                //    (contact.Name);
                //}
            //}

        }
    }
}
