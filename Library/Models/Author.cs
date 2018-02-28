using System.Collections.Generic;
using MySql.Data.MySqlAuthor;
using System;
using Microsoft.AspNetCore.Mvc;
using LibraryApp;

namespace LibraryApp.Models
{
  public class Author
  {
    private int _authorId;
    private string _authorName;
    private int _bookId;

    public Author(string authorName, int bookId, int authorId = 0)
    {
      _authorName = authorName;
      _bookId = bookId;
      _authorId = authorId;
    }

    public override bool Equals(System.Object otherAuthor)
    {
      if (!(otherAuthor is Author))
      {
        return false;
      }
      else
      {
        Author newAuthor = (Author) otherAuthor;
        bool idEquality = (this.GetAuthorId() == newAuthor.GetAuthorId());
        bool clientEquality = (this.GetAuthorName() == newAuthor.GetAuthorName());
        return (idEquality && clientEquality);
      }
    }
    public int GetId()
    {
      return _authorId;
    }
    public int GetAuthorName()
    {
      return _authorName;
    }
  }
}
