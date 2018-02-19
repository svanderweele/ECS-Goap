using AI.Goap.Handler;

namespace ECS.AI.Goap
{
    public class EntityGoapAction : BaseGoapAction
    {
        
        protected EntityGoapAgent m_agent
        {
            get { return (EntityGoapAgent) base.m_agent; }
        }
    }
}