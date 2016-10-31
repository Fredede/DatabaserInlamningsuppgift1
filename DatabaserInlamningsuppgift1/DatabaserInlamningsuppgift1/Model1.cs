namespace DatabaserInlamningsuppgift1
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;


    //F�rst skapar du ett Github-projekt som all k�llkod ska ligga i.
    //D�refter bygger du en Windows Forms-applikation som hanterar kontakter.
    //Du ska anv�nda Entity Framework Code First och l�ta C#-koden driva fram databasstrukturen.
    //Kontaktdatabasen ska lagra namn, gatudress, postnummer, postort, telefon, e-post och 
    //f�delsedag f�r varje kontakt. Dessutom ska varje post ha en nyckel.
    //Man ska kunna l�gga till nya, �ndra befintliga och ta bort poster ur kontaktdatabasen.
    //Det skall g� att s�ka p� namn och s�kresultatet ska visas i en lista. Fr�n listan skall det g� att klicka p�
    //kontakten och d�refter se alla detaljer om kontakten.

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