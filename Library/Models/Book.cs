using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;
using Microsoft.AspNetCore.Mvc;
using LibraryApp;
using LibraryApp.Models;

namespace LibraryApp.Models
{
  public class Book
  {
    private int _bookId;
    private string _bookTitle;
    private int _copies;

    public Book(string bookTitle, int copies, int bookId = 0)
    {
      _bookTitle = bookTitle;
      _copies = copies;
      _bookId = bookId;
    }

    public override bool Equals(System.Object otherBook)
    {
      if (!(otherBook is Book))
      {
        return false;
      }
      else
      {
        Book newBook = (Book) otherBook;
        bool idEquality = (this.GetBookId() == newBook.GetBookId());
        bool clientEquality = (this.GetBookTitle() == newBook.GetBookTitle());
        return (idEquality && clientEquality);
      }
    }

//When called on, this method will allow users to save a book to the books database.
    public void SaveBook()
       {
         MySqlConnection conn = DB.Connection();
         conn.Open();

         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"Insert INTO books (book_id, copies, title) VALUES (@book_id, @copies, @title);";

         MySqlParameter bookId = new MySqlParameter();
         bookId.ParameterName = "@book_id";
         bookId.Value = this._bookId;
         cmd.Parameters.Add(bookId);

         MySqlParameter copies = new MySqlParameter();
         copies.ParameterName = "@copies";
         copies.Value = this._copies;
         cmd.Parameters.Add(copies);

         MySqlParameter bookTitle = new MySqlParameter();
         bookTitle.ParameterName = "@title";
         bookTitle.Value = this._bookTitle;
         cmd.Parameters.Add(bookTitle);

         cmd.ExecuteNonQuery();
         _bookId = (int) cmd.LastInsertedId;

         conn.Close();
         if (conn != null)
           {
             conn.Dispose();
           }
       }


    public int GetBookId()
    {
      return _bookId;
    }
    public string GetBookTitle()
    {
      return _bookTitle;
    }
  }
}
