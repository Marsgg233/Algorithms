using System.Collections.Generic;

namespace KT_3
{
    public class BinarySearchTree
    {
        private TreeNode? root;

        public void Insert(int value)
        {
            root = InsertRecursive(root, value);
        }

        private TreeNode InsertRecursive(TreeNode? current, int value)
        {
            if (current == null)
            {
                return new TreeNode(value);
            }

            if (value < current.Value)
            {
                current.Left = InsertRecursive(current.Left, value);
            }
            else if (value > current.Value)
            {
                current.Right = InsertRecursive(current.Right, value);
            }

            return current;
        }

        public bool Contains(int value)
        {
            return ContainsRecursive(root, value);
        }

        private bool ContainsRecursive(TreeNode? current, int value)
        {
            if (current == null)
            {
                return false;
            }

            if (current.Value == value)
            {
                return true;
            }

            if (value < current.Value)
            {
                return ContainsRecursive(current.Left, value);
            }

            return ContainsRecursive(current.Right, value);
        }

        public void Remove(int value)
        {
            root = RemoveRecursive(root, value);
        }

        private TreeNode? RemoveRecursive(TreeNode? current, int value)
        {
            if (current == null)
            {
                return null;
            }

            if (value < current.Value)
            {
                current.Left = RemoveRecursive(current.Left, value);
            }
            else if (value > current.Value)
            {
                current.Right = RemoveRecursive(current.Right, value);
            }
            else
            {
                if (current.Left == null)
                {
                    return current.Right;
                }
                if (current.Right == null)
                {
                    return current.Left;
                }

                TreeNode successor = FindMin(current.Right);
                current.Value = successor.Value;
                current.Right = RemoveRecursive(current.Right, successor.Value);
            }

            return current;
        }

        private TreeNode FindMin(TreeNode node)
        {
            TreeNode current = node;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current;
        }

        public List<int> InOrderTraversal()
        {
            List<int> result = new List<int>();
            InOrderRecursive(root, result);
            return result;
        }

        private void InOrderRecursive(TreeNode? current, List<int> result)
        {
            if (current != null)
            {
                InOrderRecursive(current.Left, result);
                result.Add(current.Value);
                InOrderRecursive(current.Right, result);
            }
        }

        public List<int> PreOrderTraversal()
        {
            List<int> result = new List<int>();
            PreOrderRecursive(root, result);
            return result;
        }

        private void PreOrderRecursive(TreeNode? current, List<int> result)
        {
            if (current != null)
            {
                result.Add(current.Value);
                PreOrderRecursive(current.Left, result);
                PreOrderRecursive(current.Right, result);
            }
        }

        public List<int> PostOrderTraversal()
        {
            List<int> result = new List<int>();
            PostOrderRecursive(root, result);
            return result;
        }

        private void PostOrderRecursive(TreeNode? current, List<int> result)
        {
            if (current != null)
            {
                PostOrderRecursive(current.Left, result);
                PostOrderRecursive(current.Right, result);
                result.Add(current.Value);
            }
        }
    }
}
