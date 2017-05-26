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
        return View["Contact_form.cshtml"];
      };
      Post["/"] = _ => {
        Contact newContact = new Contact(Request.Form["new-name"],
                                   Request.Form["new-phone"],
                                   Request.Form["new-address"]);
        return View["index.cshtml", Contact.GetAll()];
      };
      Post["/contacts/clear"] = _ => {
        Contact.ClearAll();
        return View["clear.cshtml"];
      };
      Get["/contacts/{id}"] = parameters => {
        Contact targetContact = Contact.Find(parameters.id);
        return View["Contact_details.cshtml", targetContact];
      };
    }
  }
}
