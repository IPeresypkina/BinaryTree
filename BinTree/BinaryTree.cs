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
            if(val.CompareTo(tree.val) < 0)
                return _search(tree.left, val);
            else if (val.CompareTo(tree.val) > 0)
                return _search(tree.right, val);
            else return tree;
        }
    
        public BinaryTree<T> search(T val)
        {
            return _search(this, val);
        } 
        
        
        public bool remove(T val)
        {
            //Проверяем, существует ли данный узел
            BinaryTree<T> tree = search(val);
            if(tree == null) return false;
            
            BinaryTree<T> curTree;
  
            //Если удаляем корень
            if(tree == this)
            { 
                if(tree.right!=null) {
                    curTree = tree.right;
                }
                else curTree = tree.left;
                T temp = curTree.val;
                this.remove(temp);
                tree.val = temp;
                return true;
            }
      
            //Удаление листьев
            if(tree.left==null && tree.right==null && tree.parent != null){ 
                if(tree == tree.parent.left)
                    tree.parent.left = null;
                else {
                    tree.parent.right = null;
                }
                return true;
            }
      
            //Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
            if(tree.left != null && tree.right == null){
                //Меняем родителя
                tree.left.parent = tree.parent;
                if(tree == tree.parent.left){
                    tree.parent.left = tree.left;
                }else if(tree == tree.parent.right){
                    tree.parent.right = tree.left;
                }
                return true;
            }
      
            //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
            if(tree.left == null && tree.right != null){
                //Меняем родителя
                tree.right.parent = tree.parent;
                if(tree == tree.parent.left){
                    tree.parent.left = tree.right;
                }
                else if(tree == tree.parent.right){
                    tree.parent.right = tree.right;
                }
                return true;
            }
      
              //Удаляем узел, имеющий поддеревья с обеих сторон
            if(tree.right!=null && tree.left!=null) {
                curTree = tree.right;
      
                while (curTree.left != null) {
                    curTree = curTree.left;
                }
      
                //Если самый левый элемент является первым потомком
                if(curTree.parent == tree) {
                    curTree.left = tree.left;
                    tree.left.parent = curTree;
                    curTree.parent = tree.parent;
                    tree.parent.left = curTree;
                }
                //Если самый левый элемент НЕ является первым потомком
                else {
                    if (curTree.right != null) {
                        curTree.right.parent = curTree.parent;
                    }
                    curTree.parent.left = curTree.right;
                    curTree.right = tree.right;
                    curTree.left = tree.left;
                    tree.left.parent = curTree;
                    tree.right.parent = curTree;
                    curTree.parent = tree.parent;
                    tree.parent.right = curTree;
                }
                return true;
            }
            return false;
        }
    }
}