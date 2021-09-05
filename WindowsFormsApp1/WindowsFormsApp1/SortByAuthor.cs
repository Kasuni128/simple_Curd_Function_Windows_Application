using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SortByAuthor : IComparer<Book>
    {


        

        public int Compare(Book x, Book y)
        {

        
            return (int)(y.Author.Count() - x.Author.Count());
        }

       
    }
}
