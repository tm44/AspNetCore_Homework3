var context = new Homework3.Db.ContactsContext();

const string CONTACT_NAME = "Mike";

var existingContact = context.Contacts.FirstOrDefault(c => c.ContactName == CONTACT_NAME);

if (existingContact == null)
{
    existingContact = new Homework3.Db.Contact()
    {
        ContactAge = 40,
        ContactCreatedDate = DateTime.Now,
        ContactName = "Mike",
        ContactEmail = "mike@uw.edu",
        ContactNotes = "This is a test note",
        ContactPhoneNumber = "206-999-8888",
        ContactPhoneType = "mobile"
    };
    context.Contacts.Add(existingContact);
    context.SaveChanges();
    Console.WriteLine("Added the contact.");
}
else
{
    Console.WriteLine($"The contact record for {CONTACT_NAME} already exists.");
}

Console.WriteLine($"Info for {existingContact.ContactName}:");
Console.WriteLine($"Age: {existingContact.ContactAge}");
Console.WriteLine($"Email: {existingContact.ContactEmail}");
Console.WriteLine($"Phone: {existingContact.ContactPhoneNumber} ({existingContact.ContactPhoneType})");
Console.WriteLine($"Notes: {existingContact.ContactNotes}");
Console.WriteLine($"Created: {existingContact.ContactCreatedDate.ToShortDateString()}");

context.Contacts.Remove(existingContact);
context.SaveChanges();
Console.WriteLine("Removed the contact.");

Console.WriteLine("Number of contact records: " + context.Contacts.Count());