using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Book: IComparable<Book>
    {
        private String bookId;
        private String bname;
        private String author;
        private int quantity;
        private float price;
       
       


        public string BookId { get => bookId; set => bookId = value; }
        public string Bname { get => bname; set => bname = value; }
        public string Author { get => author; set => author = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public float Price { get => price; set => price = value; }

        public Book(string bookId, string bname, string author, int quantity, float price)
        {
            this.bookId = bookId;
            this.bname = bname;
            this.author = author;
            this.quantity = quantity;
            this.price = price;
        }

       

        public override string ToString()
        {
            return bname + " , Author : " + author + " , Qunatity : " + quantity + " , Price : "+ price;
        }

        public override bool Equals(object obj)
        {
            if (obj is Book)
            {
                Book b = obj as Book;
                if (b.bookId == bookId)
                    return true;
            }
            return false;
        }

        public int CompareTo(Book other)
        {
            return other.quantity - quantity; //Desecnding
        }
    }
}
