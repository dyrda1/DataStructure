using System;
namespace DataStructure
{
    class PrefixTree
    {
        TreeNode Root = new TreeNode();

        public void Add(string key, string value)
        {
            TreeNode current = Root;

            foreach (char c in key)
            {
                current.Childs[c - 'a'] = current.Childs[c - 'a'] ?? new TreeNode();
                current = current.Childs[c - 'a'];
            }

            current.Value = value;
        }

        public string Get(string key)
        {
            TreeNode current = Root;

            foreach (var c in key)
            {
                if (current.Childs[c - 'a'] == null)
                {
                    throw new ArgumentException();
                }

                current = current.Childs[c - 'a'];
            }

            if (current.HasValue)
            {
                return current.Value;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
