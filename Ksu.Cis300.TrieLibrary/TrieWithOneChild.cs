using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// whether trie contains empty string.
        /// </summary>
        private bool _contains;

        /// <summary>
        /// field for the child's label
        /// </summary>
        private char _label;

        /// <summary>
        /// field for the only child
        /// </summary>
        private ITrie _onlyChild;

        /// <summary>
        /// constructor
        /// </summary>
        public TrieWithOneChild(string s, bool b)
        {
            if (s == "" || s[0] < 'a' || 'z' < s[0]) throw new ArgumentException();
            _contains = b;
            _label = s[0];
            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1));
        }
        /// <summary>
        /// Class to Add an ITrie
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _contains = true;
            }
            else if(s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else if (_label == s[0])
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
                
            }
            else
            {
                return new TrieWithManyChildren(s, _contains, _label, _onlyChild);
            }
            return this;
        }

        /// <summary>
        /// class to return a bool if it contains the string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _contains;
            }
            else if(s[0] == _label)
            {
                return _onlyChild.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
