using Libraries.btcp.Goap.src.Handler;

namespace Libraries.btcp.src.Extensions
{
    public class EntityGoapAction : BaseGoapAction
    {
        
        protected EntityGoapAgent m_agent
        {
            get { return (EntityGoapAgent) base.m_agent; }
        }
    }
}