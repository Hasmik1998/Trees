using System;

namespace Tree
{
    public class AVLTree<T>:BinarySearchTree<T> where T: IComparable<T>
    {
        public new Node<T> Root;
        
        public Node<T> RightRotate(Node<T> y)  
        {  
            Node<T> x = y.Left;  
            Node<T> z = x.Right;
            x.Right = y;  
            y.Left = z;  
            return x;  
        }   
        public Node<T> LeftRotate(Node<T> x)  
        {  
            Node<T> y = x.Right;  
            Node<T> z = y.Left;
            y.Left = x;  
            x.Right = z;  
            return y;  
        } 
        public int getBalance(Node<T> N) 
        {  
            if (N == null)  
                return 0;  
  
            return Height(N.Left) - Height(N.Right);  
        }

        public override void  Add(T data, Node<T> node)
        {
            base.Add(data, node);
            int balance = getBalance(node);  
  
            if (balance > 1 && data.CompareTo(node.Left.Item)<0)  
                 RightRotate(node);  
  
            if (balance < -1 && data.CompareTo(node.Right.Item)>0)
                LeftRotate(node);  
  
            // Left Right Case  
            if (balance > 1 && data.CompareTo( node.Left.Item)>0)  
            {  
                node.Left = LeftRotate(node.Left);  
                RightRotate(node);  
            }  
  
            // Right Left Case  
            if (balance < -1 && data.CompareTo(node.Right.Item)<0) 
            {  
                node.Right = RightRotate(node.Right);  
                LeftRotate(node);  
            }  
  
        }
    }
}