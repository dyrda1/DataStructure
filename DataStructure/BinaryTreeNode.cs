namespace DataStructure
{
    public enum Side : byte
    {
        Left,
        Right
    }

    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> ParentNode { get; set; }
        public BinaryTreeNode<T> RightNode { get; set; }
        public BinaryTreeNode<T> LeftNode { get; set; }
        public Side? NodeSide
        {
            get 
            {
                if (ParentNode == null) return null;
                else if(ParentNode.LeftNode == this) return Side.Left;
                else return Side.Right;
            }
        }
                
        public BinaryTreeNode(T data)
        {
            Data = data;
        }
    }
}
