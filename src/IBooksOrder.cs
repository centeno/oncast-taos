using oncast_taos.src.model;
using System.Collections.Generic;

namespace oncast_taos.src
{
    public interface IBooksOrder
    {
        IList<Book> Order(IList<Book> books);
    }
}
