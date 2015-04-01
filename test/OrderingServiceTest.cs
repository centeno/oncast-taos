using Microsoft.VisualStudio.TestTools.UnitTesting;
using oncast_taos.src;
using oncast_taos.src.model;
using System.Collections.Generic;

namespace oncast_taos
{
    [TestClass]
    public class OrderingServiceTest
    {
        IList<Book> books;
        Book book1, book2, book3, book4;
        Configuration config;
        OrderingService os;

        [TestInitialize()]
        public void Initialize()
        {
            books = new List<Book>();
            book1 = new Book() { Title = "Java How to Program", AuthorName = "Deitel & Deitel", EditionYear = 2007 };
            book2 = new Book() { Title = "Patterns of Enterprise Application Architecture", AuthorName = "Martin Fowler", EditionYear = 2002 };
            book3 = new Book() { Title = "Head First Design Patterns", AuthorName = "Elisabeth Freeman", EditionYear = 2004 };
            book4 = new Book() { Title = "Internet & World Wide Web: How to Program", AuthorName = "Deitel & Deitel", EditionYear = 2007 };
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            config = Configuration.Instance;
            os = new OrderingService();
        }

        [TestMethod]
        public void Should_Return_Empty_When_EmptyList()
        {
            IList<Book> ret = os.Order(new List<Book>());

            Assert.AreEqual(0, ret.Count);
        }

        [TestMethod]
        public void Should_Return_Books3412_When_SortedBy_TitleASC()
        {
            string order = @"[{ 'Property': 'Title', 'Direction': 'Ascendent' }]";
            config.loadConfiguration(order);
            IList<Book> ret = os.Order(books);

            Assert.AreSame(book3, ret[0]);
            Assert.AreSame(book4, ret[1]);
            Assert.AreSame(book1, ret[2]);
            Assert.AreSame(book2, ret[3]);
        }

        [TestMethod]
        public void Should_Return_Books1432_When_SortedBy_AuthorASC_TitleDESC()
        {
            string order = @"[{ 'Property': 'AuthorName', 'Direction': 'Ascendent' },
                              { 'Property': 'Title', 'Direction': 'Descendent' }]";
            config.loadConfiguration(order);
            IList<Book> ret = os.Order(books);

            Assert.AreSame(book1, ret[0]);
            Assert.AreSame(book4, ret[1]);
            Assert.AreSame(book3, ret[2]);
            Assert.AreSame(book2, ret[3]);
        }

        [TestMethod]
        public void Should_Return_Books4132_When_SortedBy_EditionDESC_AuthorDESC_TitleASC()
        {
            string order = @"[{ 'Property': 'EditionYear', 'Direction': 'Descendent' },
                              { 'Property': 'AuthorName', 'Direction': 'Descendent' },
                              { 'Property': 'Title', 'Direction': 'Ascendent' }]";
            config.loadConfiguration(order);
            IList<Book> ret = os.Order(books);

            Assert.AreSame(book4, ret[0]);
            Assert.AreSame(book1, ret[1]);
            Assert.AreSame(book3, ret[2]);
            Assert.AreSame(book2, ret[3]);
        }
    }
}
