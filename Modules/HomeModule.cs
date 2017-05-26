using Nancy;
using AddressBook.Objects;
using System.Collections.Generic;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml", Contact.GetAll()];
      };
      Get["/contacts/new"] = _ => {
        return View["contact_form.cshtml"];
      };
      Post["/"] = _ => {
        Contact newContact = new Contact(Request.Form["new-name"],
                                   Request.Form["new-phone"],
                                   Request.Form["new-address"]);

        return View["contact_added.cshtml", Contact.GetAll()];
      };
      Post["/contacts/delete"] = _ => {
        Contact.DeleteAll();

        return View["delete.cshtml"];
      };
      Get["/contacts/{id}"] = parameters => {
        Contact targetContact = Contact.Find(parameters.id);

        return View["contact_details.cshtml", targetContact];
      };
    }
  }
}
