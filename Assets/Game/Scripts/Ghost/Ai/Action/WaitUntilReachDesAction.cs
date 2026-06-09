using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(
    name: "Wait Until Reach Des",
    story: "[Ai] wait until reach destination",
    category: "Action",
    id: "2d2777e498fa4054168d4ae4e881dfc0"
)]
public partial class WaitUntilReachDesAction : Action
{
    [SerializeReference]
    public BlackboardVariable<GhostAiController> Ai;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Ai.Value == null)
        {
            return Status.Failure;
        }

        if (Ai.Value.NavMeshAgent == null)
        {
            return Status.Failure;
        }

        if (Ai.Value.NavMeshAgent.pathPending == true)
        {
            return Status.Running;
        }

        if (Ai.Value.NavMeshAgent.remainingDistance > Ai.Value.NavMeshAgent.stoppingDistance + 0.5)
        {
            return Status.Running;
        }

        return Status.Success;
    }

    protected override void OnEnd() { }
}
