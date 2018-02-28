using System.Collections.Generic;
using MySql.Data.MySqlAuthor;
using System;
using Microsoft.AspNetCore.Mvc;
using LibraryApp;

namespace LibraryApp.Models
{
  public class Book
  {
    private int _bookId;
    private string _bookName;
    private int _copies;

    public Book(string bookName, int copies, int bookId = 0)
    {
      _bookName = bookName;
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
        bool clientEquality = (this.GetBookName() == newBook.GetBookName());
        return (idEquality && clientEquality);
      }
    }
    public int GetId()
    {
      return _bookId;
    }
    public int GetBookName()
    {
      return _bookName;
    }
  }
}
