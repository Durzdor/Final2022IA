namespace _Game.Scripts.Utilities.DecisionTree
{
    public class QuestionNode : INode
    {
        public delegate bool myDelegate();
        private myDelegate _question;
        private INode _trueNode;
        private INode _falseNode;
        public QuestionNode(myDelegate question, INode trueNode, INode falseNode)
        {
            _question = question;
            _trueNode = trueNode;
            _falseNode = falseNode;
        }
        public void Execute()
        {
            if (_question())
            {
                _trueNode.Execute();
            }
            else
            {
                _falseNode.Execute();
            }
        }
    }
}
