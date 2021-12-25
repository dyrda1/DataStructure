namespace DataStructure
{
    internal class TreeNode
    {
        public TreeNode[] Childs { get; set; }
        public string Value { get; set; }

        public bool HasValue
        {
            get { return Value != null; }
        }

        public TreeNode()
        {
            Childs = new TreeNode[26];
        }
    }
}
