using System;
namespace Tree
{
    public class Node<T> where T: IComparable<T>
    {
        public  T Item { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public  Node(T item)
        {
            this.Item = item;
        }
        
        public void display()
            {
                Console.Write("[");
                Console.Write(Item);
                Console.Write("]");
            }
        
    }
}