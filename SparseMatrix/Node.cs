﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacierzRzadka
{
    class Node
    {
        private int _index;
        public int value;
        public int index { get { return _index; } }
        public int setIndex { set { _index = value; } }
        public Node left, right;
        public int level;
        
        public Node(int i, int v)
        {
            _index = i;
            value = v;
            left = null; 
            right= null;
        }
        public Node() { }
        public Node GetRight()
        {
            if(right==null)
                right = new Node();
            
            return this.right;
        }
        public Node GetLeft()
        {
            if (left == null)
                left = new Node();

            return this.left;
        }
    }
    
}
