using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KR_2
{
   public class Book
    {
        private string title;
        private string author;
        private string publishing;
        private int? year;
        private Genres genre;
        public string Title {
            get
            {
                return title;
            }
            set
            {
                if (value == "")
                {
                    title = "Default";
                }
                else
                {
                    title = value;
                }
            }
        }
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (value == "")
                {
                    author = "Default";
                }
                else
                {
                    author = value;
                }
            }
        }
        public string Publishing
        {
            get
            {
                return publishing;
            }
            set
            {
                if (value == "")
                {
                    publishing = "Default";
                }
                else
                {
                    publishing = value;
                }
            }
        }
        public int? Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }
        public Genres Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
            }
        }
        public Book(string Title, string Author, string Publishing, int? Year, string Genre)
        {
            this.Title = Title;
            this.Author = Author;
            this.Publishing = Publishing;
            this.Year = Year;
            switch (Genre)
            {
                case "Fantstic":
                    this.Genre = Genres.Fantastic;
                    break;
                case "Detective":
                    this.Genre = Genres.Detective;
                    break;
                case "Dramma":
                    this.Genre = Genres.Dramma;
                    break;
                case "Prose":
                    this.Genre = Genres.Prose;
                    break;
                case "":
                    this.Genre = Genres.Default;
                    break;
                default:
                    break;
            }

        }
        public enum Genres
        {
            Fantastic,
            Detective,
            Dramma,
            Prose,
            Default
        }

        public void GetInfo()
        {
            MessageBox.Show($"Ttitle - {Title}, Publishing - {Publishing}, Year - {Year}, Genre - {Genre}");
        }
    }
}
