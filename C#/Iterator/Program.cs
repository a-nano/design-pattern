using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            BookShelf bookShelf = new BookShelf();
            bookShelf.appendBook(new Book("Around the world in 80 days"));
            bookShelf.appendBook(new Book("Bigle"));
            bookShelf.appendBook(new Book("Cinderella"));
            bookShelf.appendBook(new Book("Daddy-Long-legs"));
            IIterator it = bookShelf.Iterator();
            while(it.HasNext())
            {
                Book book = (Book)it.Next();
                Console.WriteLine(book.Name);
            }

            // 入力待ち
            Console.ReadLine();
        }
    }

    // 集合体を表すインターフェース
    public interface IAggregate
    {
        IIterator Iterator();
    }

    // 数え上げ、スキャンを表すインターフェース
    public interface IIterator
    {
        bool HasNext();
        object Next();
    }

    // 本を表すクラス
    public class Book
    {
        public string Name { get; set; }
        public Book(string name)
        {
            this.Name = name;
        }
    }

    // 本棚を表すクラス
    public class BookShelf : IAggregate
    {
        List<Book> books = new List<Book>();
        int Last { get; set; } = 0;
        public Book GetBookAt(int index)
        {
            return books[index];
        }
        public void appendBook(Book book)
        {
            this.books.Add(book);
            Last++;
        }
        public int Getlength()
        {
            return this.Last;
        }
        public IIterator Iterator()
        {
            return new BookShelfIterator(this);
        }
    }

    // 本棚をスキャンするクラス
    public class BookShelfIterator : IIterator
    {
        BookShelf BookShelf { get; set; }
        int Index { get; set; }
        public BookShelfIterator(BookShelf bookShelf)
        {
            this.BookShelf = bookShelf;
            this.Index = 0;
        }
        public bool HasNext()
        {
            if (Index < BookShelf.Getlength())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public object Next()
        {
            Book book = BookShelf.GetBookAt(Index);
            this.Index++;
            return book;
        }
    }

}
