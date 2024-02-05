using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string Id { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public int Balance { get; set; }
    public int Cash { get; set; }

    public User(string _id, string _password, string _name, int _balance, int cash)
    {
        Id = _id;
        Password = _password;
        Name = _name;
        Balance = _balance;
        Cash = cash;
    }
}
