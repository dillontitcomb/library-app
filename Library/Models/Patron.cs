using System.Collections.Generic;
using MySql.Data.MySqlAuthor;
using System;
using Microsoft.AspNetCore.Mvc;
using LibraryApp;

namespace LibraryApp.Models
{
  public class Patron
  {
    private int _patronId;
    private string _patronName;
    private int _bookId;

    public Patron(string patronName, int bookId, int patronId = 0)
    {
      _patronName = patronName;
      _bookId = bookId;
      _patronId = patronId;
    }

    public override bool Equals(System.Object otherPatron)
    {
      if (!(otherPatron is Patron))
      {
        return false;
      }
      else
      {
        Patron newPatron = (Patron) otherPatron;
        bool idEquality = (this.GetPatronId() == newPatron.GetPatronId());
        bool clientEquality = (this.GetPatronName() == newPatron.GetPatronName());
        return (idEquality && clientEquality);
      }
    }
    public int GetPatronId()
    {
      return _patronId;
    }
    public int GetPatronName()
    {
      return _patronName;
    }
  }
}
