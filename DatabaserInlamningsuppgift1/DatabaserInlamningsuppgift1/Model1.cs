namespace DatabaserInlamningsuppgift1
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;


    //Först skapar du ett Github-projekt som all källkod ska ligga i.
    //Därefter bygger du en Windows Forms-applikation som hanterar kontakter.
    //Du ska använda Entity Framework Code First och låta C#-koden driva fram databasstrukturen.
    //Kontaktdatabasen ska lagra namn, gatudress, postnummer, postort, telefon, e-post och 
    //födelsedag för varje kontakt. Dessutom ska varje post ha en nyckel.
    //Man ska kunna lägga till nya, ändra befintliga och ta bort poster ur kontaktdatabasen.
    //Det skall gå att söka på namn och sökresultatet ska visas i en lista. Från listan skall det gå att klicka på
    //kontakten och därefter se alla detaljer om kontakten.

    public class ContactList : DbContext
    {
        public DbSet<Contact> Contact { get; set; }
    }

    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

}