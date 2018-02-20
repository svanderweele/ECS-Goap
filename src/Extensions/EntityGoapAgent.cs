using System.Collections.Generic;
using Entitas;

using Libraries.btcp.ECS.src.AI.Sensors.Targeting;
using Libraries.btcp.Goap.src.Handler;
using UnityEngine.Assertions;

namespace Libraries.btcp.src.Extensions
{
    public class EntityGoapAgent : BaseGoapAgent
    {
        //TODO : Make sure entity is removed when destroyed
        private readonly GameEntity m_entity;
        private readonly Contexts m_contexts;

        public GameEntity Entity
        {
            get { return m_entity; }
        }

        public Contexts Contexts
        {
            get { return m_contexts; }
        }


        public EntityGoapAgent(Contexts contexts, GameEntity entity)
        {
            m_contexts = contexts;
            m_entity = entity;
        }

        
        public void IterateActions()
        {
            RunNextAction();
        }

        
        //Targeting

        public void SetTarget(GameEntity target)
        {
            TargetingHelpers.SetTarget(m_entity, target);
        }

        public void SetTarget(int targetID)
        {
            Assert.IsFalse(targetID == -1, "Invalid Entity Target ID Passed");
            var target = m_contexts.game.GetEntityWithId(targetID);
            SetTarget(target);
        }

        public GameEntity GetTarget()
        {
            return TargetingHelpers.GetTarget(m_contexts, m_entity);
        }

        public bool HasTarget()
        {
            return Entity.hasTarget;
        }
        
        public List<int> GetMatchingTargetsInSight(IMatcher<GameEntity> matcher)
        {
            return TargetingHelpers.GetMatchingTargetsInSight(m_contexts, m_entity, matcher);
        }

        public bool HasMatchingTargetInSight(IMatcher<GameEntity> matcher)
        {
            return GetMatchingTargetsInSight(matcher).Count > 0;
        }

        public bool DoesCurrentTargetMatch(IMatcher<GameEntity> matcher)
        {
            return TargetingHelpers.DoesCurrentTargetMatch(m_contexts, m_entity, matcher);
        }
        
        //---------
    }
}