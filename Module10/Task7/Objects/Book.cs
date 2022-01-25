using System;

namespace Module10.Task7.Objects
{
    public class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public Book(string title = "", string author = "", int year = 0, decimal price = 0)
        {
            Title = title;
            Author = author;
            Year = year;
            Price = price;
        }

        public override string ToString()
        {
            return $"Title: {Title}; Author: {Author}; Year: {Year}; Price {Price}";
        }

        public int CompareTo(Book other)
        {
            return Price.CompareTo(other.Price);
        }
        public override bool Equals(object obj)
        {
            if (obj is Book book)
            {
                return CompareTo(book) == 0;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(Book left, Book right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Book left, Book right)
        {
            return !(left == right);
        }

        public static bool operator <(Book left, Book right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Book left, Book right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Book left, Book right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Book left, Book right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
