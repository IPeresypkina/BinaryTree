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
        
        public void add(T val)
        {
            if(val.CompareTo(this.val) < 0){
                if(this.left==null){
                    this.left = new BinaryTree<T>(val, this);
                }
                else if(this.left != null)
                    this.left.add(val);
            }
            else{
                if(this.right==null){
                    this.right = new BinaryTree<T>(val, this);
                }
                else if(this.right != null)
                    this.right.add(val);
            }
        }
        
        private BinaryTree<T> _search(BinaryTree<T> tree, T val)
        {
            if(tree == null) return null;
            switch (val.CompareTo(tree.val)){
                case 1: return _search(tree.right, val);
                case -1: return _search(tree.left, val);
                case 0: return tree;
                default: return null;
            }
        }
    
        public BinaryTree<T> search(T val)
        {
            return _search(this, val);
        }
        
    }
}