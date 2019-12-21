using System;
using System.Collections.Generic;

namespace BinTree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public BinaryTree<T> parent, left, right;
        public T val;

        public BinaryTree(T val, BinaryTree<T> parent)
        {
            this.val = val;
            this.parent = parent;
        }
    }
}