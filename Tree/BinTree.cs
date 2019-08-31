using System;
using System.Reflection.Emit;
namespace Tree
{
    public class BinarySearchTree<T> where T:IComparable<T>
    {
        public Node<T> root { get; set; }
       
        public BinarySearchTree()
        { 
            root = null; 
        }
        
        private Node<T> ReturnRoot()
        {
            return root;
        }
        public int Height(Node<T> N)
        {
            if (N == null)
                return 0;
            return Math.Max(Height(N.Left), Height(N.Right)) + 1;
        }
        public virtual void Add(T data, Node<T> node)
        { 

            if (data.CompareTo(node.Item) > 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(data);
                    return;
                }
                Add(data, node.Right);
                System.Console.WriteLine("right");
            }

            else if (data.CompareTo(node.Item) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(data);
                    return;
                }
                Add(data, node.Left);
                System.Console.WriteLine("left");
            }
        }
        
        public virtual void Insert(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (root == null)
                root = newNode;
            Node<T> current = root;
            while (current != null)
            {
                if (data.CompareTo(current.Item) > 0)
                {
                    if (current.Right != null)
                    {
                        current = current.Right; 
                        continue;
                    }
                    current.Right = new Node<T>(data); 
                } 

                else if (data.CompareTo(current.Item) < 0)
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                        continue;
                    }
                    current.Left = new Node<T>(data); 
                }

                else
                {
                    return;
                }
            }
        }
        public void Preorder(Node<T> Root)
        {
            if (Root != null)
            {
                Console.Write(Root.Item + " ");
                Preorder(Root.Left);
                Preorder(Root.Right);
            }
        }
        public void Inorder(Node<T> Root)
        {
            if (Root != null)
            {
                Inorder(Root.Left);
                Console.Write(Root.Item + " ");
                Inorder(Root.Right);
            }
        }
        public void Postorder(Node<T> Root)
        {
            if (Root != null)
            {
                Postorder(Root.Left);
                Postorder(Root.Right);
                Console.Write(Root.Item + " ");
            }
        }
        
        public void InsertFromArray(T[] array)
        {
            foreach(T t in array)
            {
                this.Insert(t); 
            }
        }
        public static bool Contains(Node<T> node, T value)
        {
            if (value.Equals(node.Item))
            {
                return true;
            }
            else if (value.CompareTo(node.Item)>0)
            {
                if (node.Right == null)
                {
                    Contains(node.Left, value);
                }
                Contains(node.Right, value);
            }
            else 
            {
                if (node.Left == null)
                {
                    Contains(node.Right, value);
                }

                Contains(node.Left, value);
            }

            return false;
        }
        T minValue(Node<T> root)  
        {  
            T minv = root.Item;  
            while (root.Left != null)  
            {  
                minv = root.Left.Item;  
                root = root.Left;  
            }  
            return minv;  
        }  
        public virtual Node<T> Delate(Node<T> root, T key)  
        {  
            
            if (root == null) return root;  
  
            if (key.CompareTo(root.Item) <0) 
                root.Left = Delate(root.Left, key);  
            else if (key.CompareTo(root.Item)>0)
                root.Right = Delate(root.Right, key);  
  
            else
            {  
                if (root.Left == null)  
                    return root.Right;  
                else if (root.Right == null)  
                    return root.Left;  
  
                root.Item = minValue(root.Right);  
  
                root.Right = Delate(root.Right, root.Item);  
            }  
            return root;  
        }  
    }
}