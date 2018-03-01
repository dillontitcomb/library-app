using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;
using Microsoft.AspNetCore.Mvc;
using LibraryApp;
using LibraryApp.Models;

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
    public int GetAuthorId()
    {
      return _authorId;
    }
    public string GetAuthorName()
    {
      return _authorName;
    }

    public void SaveAuthor()
    {
         MySqlConnection conn = DB.Connection();
         conn.Open();

         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"Insert INTO authors (author_id, author_name, book_id) VALUES (@author_id, @author_name, @book_id);";

         MySqlParameter authorId = new MySqlParameter();
         authorId.ParameterName = "@author_id";
         authorId.Value = this._authorId;
         cmd.Parameters.Add(authorId);

         MySqlParameter authorName = new MySqlParameter();
         authorName.ParameterName = "@author_name";
         authorName.Value = this._authorName;
         cmd.Parameters.Add(authorName);

         MySqlParameter bookId = new MySqlParameter();
         bookId.ParameterName = "@book_id";
         bookId.Value = this._bookId;
         cmd.Parameters.Add(bookId);

         cmd.ExecuteNonQuery();
         _authorId = (int) cmd.LastInsertedId;

         conn.Close();
         if (conn != null)
           {
             conn.Dispose();
           }
         }
       }
     }
