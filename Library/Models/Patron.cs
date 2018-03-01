using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;
using Microsoft.AspNetCore.Mvc;
using LibraryApp;
using LibraryApp.Models;

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
    public string GetPatronName()
    {
      return _patronName;
    }

    public void SavePatron()
       {
         MySqlConnection conn = DB.Connection();
         conn.Open();

         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"Insert INTO patrons (patron_id, patron_name, book_id) VALUES (@patron_id, @patron_name, @book_id);";

         MySqlParameter patronId = new MySqlParameter();
         patronId.ParameterName = "@patron_id";
         patronId.Value = this._patronId;
         cmd.Parameters.Add(patronId);

         MySqlParameter patronName = new MySqlParameter();
         patronName.ParameterName = "@patron_name";
         patronName.Value = this._patronName;
         cmd.Parameters.Add(patronName);

         MySqlParameter bookId = new MySqlParameter();
         bookId.ParameterName = "@book_id";
         bookId.Value = this._bookId;
         cmd.Parameters.Add(bookId);

         cmd.ExecuteNonQuery();
         _patronId = (int) cmd.LastInsertedId;

         conn.Close();
         if (conn != null)
           {
             conn.Dispose();
           }
       }



  }
}
