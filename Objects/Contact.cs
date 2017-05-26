using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private int      _id;
    private string   _name;
    private string   _phone;
    private string   _address;
    private static List<Contact> _instances = new List<Contact>{};

    public Contact (string name, string phone, string address)
    {
      _id       = _instances.Count;
      _name     = name;
      _phone    = phone;
      _address  = address;
      _instances.Add(this);
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }
    public string GetPhone()
    {
      return _phone;
    }
    public void SetPhone(string newPhone)
    {
      _phone = newPhone;
    }
    public string GetAddress()
    {
      return _address;
    }
    public void SetAddress(string newAddress)
    {
      _address = newAddress;
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public static void DeleteAll()
    {
      _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId];
    }
  }
}
