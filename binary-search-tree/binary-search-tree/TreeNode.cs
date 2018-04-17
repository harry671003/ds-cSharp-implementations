using System;
/// <summary>
/// A node in the tree.
/// </summary>
public class TreeNode<TKey, TValue> where TKey: IComparable
{
    public TreeNode(TKey key) 
    {
        this.Key = key;
    }

    /// <summary>
    /// Gets or sets the parent.
    /// </summary>
    public TreeNode<TKey, TValue> Parent { get; set; }
    
    /// <summary>
    /// Gets or sets the left child.
    /// </summary>
    public TreeNode<TKey, TValue> LeftChild { get; set; }
    
    /// <summary>
    /// Gets or sets the right child.
    /// </summary>
    public TreeNode<TKey, TValue> RightChild { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public TValue Value { get; set; }

    /// <summary>
    /// Gets the key.
    /// </summary>
    /// <returns></returns>
    public TKey Key { get; private set; }
}