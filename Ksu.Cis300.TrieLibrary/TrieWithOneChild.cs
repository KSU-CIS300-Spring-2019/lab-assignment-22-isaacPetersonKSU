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
        /// whether the trie contains the empty string
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// the only child
        /// </summary>
        private ITrie _child;

        /// <summary>
        /// the child's label
        /// </summary>
        private char _label;

        public TrieWithOneChild(string s, bool hasEmpty)
        {
            if (s == "" || !char.IsLower(s[0]))
            {
                throw new ArgumentException();
            }
            _hasEmptyString = hasEmpty;
            _label = s[0];
            _child = new TrieWithNoChildren();
            _child= _child.Add(s.Substring(1));
        }

        /// <summary>
        /// adds a string to the trie
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if(s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else if(s[0] == _label)
            {
                _child = _child.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _hasEmptyString, _label, _child);
            }
        }

        /// <summary>
        /// searches the trie for a string
        /// </summary>
        /// <param name="s">the string</param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else if (s[0] == _label)
            {
                return _child.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
