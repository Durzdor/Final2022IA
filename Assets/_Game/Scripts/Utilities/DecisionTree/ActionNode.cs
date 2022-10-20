namespace _Game.Scripts.Utilities.DecisionTree
{
    public class ActionNode : INode
    {
        public delegate void myDelegate();
        private myDelegate _action;

        public ActionNode(myDelegate action)
        {
            _action = action;
        }
        public void SubAction(myDelegate newAction)
        {
            _action += newAction;
        }
        public void Execute()
        {
            _action();
        }
    }
}
