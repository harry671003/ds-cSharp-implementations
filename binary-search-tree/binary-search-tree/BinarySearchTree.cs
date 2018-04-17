using System;

namespace binary_search_tree
{
    public class BinarySearchTree<TKey, TValue> where TKey : IComparable
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public BinarySearchTree() 
        {
            this.Root = null;
            this.Count = 0;
        }

        public TreeNode<TKey, TValue> Root { get; private set; }

        public void Insert(TKey key, TValue value) 
        {
            var findResult = this.Find(key, this.Root);

            var newNode = new TreeNode<TKey, TValue>(key);
            newNode.Value = value;

            if(findResult == null) 
            {
                // The tree is empty.
                // Insert the node at the root.
                this.Root = newNode;
            }
            else {
                var comparisonResult = key.CompareTo(findResult.Key);
            
                if(comparisonResult == 0)
                {
                    // key == findResult.Key
                    // The key already exists in the tree.
                    throw new InvalidOperationException($"{key} already exists in tree.");
                }
                else if(comparisonResult < 0) {
                    // key < findResult.Key
                    // The new node must be added as the left child.
                    findResult.LeftChild = newNode;
                }
                else {
                    // key > findResult.Key
                    // The new node must be added as the right child.
                    findResult.RightChild = newNode;
                }

                newNode.Parent = findResult;
            }

            this.Count++;
        }

        /// <summary>
        /// Searches recursively for a node with given key.
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <param name="node">The node from which search begins.</param>
        /// <returns>
        /// Returns node -> if node is found.
        /// else returns the position where the node should be inserted.
        /// </returns>
        public TreeNode<TKey, TValue> Find(TKey key, TreeNode<TKey, TValue> node) 
        {
            if(this.Root == null) 
            {
                return null;
            }

            // comparisonResult < 0 if key < node.key
            // comparisonResult = 0 0 if key = node.key
            // comparisonResult > 0 if key > node.key
            var comparisonResult = key.CompareTo(node.Key);

            if(comparisonResult == 0) 
            {
                // Found the node.
                return node;
            }
            else if(comparisonResult > 0) 
            {
                // Should be in the right sub tree.
                if(node.RightChild == null) 
                {
                    return node;
                }

                return Find(key, node.RightChild);
            }
            else
            {
                // Should be in the left sub tree.
                if(node.LeftChild == null) 
                {
                    return node;
                }

                return Find(key, node.LeftChild);
            }
        }

        /// <summary>
        /// Get the count of nodes in the tree.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Returns the next larget node wrt to a current node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>Next largest node.</returns>
        public TreeNode<TKey, TValue> GetNext(TreeNode<TKey, TValue> node) 
        {
            if(node == null)
            {
                return null;
            }

            if(node.RightChild != null) {
                return GetLeftDescendent(node.RightChild);
            }

            return GetRightAncestor(node);
        }

        /// <summary>
        /// Returns the left most descendent for a node (recursive).
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode<TKey, TValue> GetLeftDescendent(TreeNode<TKey, TValue> node)
        {
            if(node.LeftChild == null) 
            {
                return node;
            }

            return GetLeftDescendent(node.LeftChild);
        }

        private TreeNode<TKey, TValue> GetRightAncestor(TreeNode<TKey, TValue> node)
        {
            if(node.Parent == null) 
            {
                return null;
            }
            
            if(node.Parent.Key.CompareTo(node.Key) > 0)
            {
                return node.Parent;
            }

            return GetRightAncestor(node.Parent);
        }
    }
}
