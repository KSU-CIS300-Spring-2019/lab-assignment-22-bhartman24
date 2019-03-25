using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// field to indicate if empty string is stored in the trie rooted at node
        /// </summary>
        private bool _stored = false;

        /// <summary>
        /// class to return an ITrie adding string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _stored = true;
                
            }
            else
            {
                return new TrieWithOneChild(s, _stored);
            }
            return this;
        }

        /// <summary>
        /// class to determine if the string is contained
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _stored;
            }

            else return false;
        }
    }
}
