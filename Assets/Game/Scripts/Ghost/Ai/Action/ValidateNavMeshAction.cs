using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(
    name: "Validate Nav Mesh",
    story: "Validat NavMesh From [Ai]",
    category: "Action",
    id: "4ac0b3fbca5fb3b9b33127523e9a0d93"
)]
public partial class ValidateNavMeshAction : Action
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

        if (Ai.Value.NavMeshAgent.isActiveAndEnabled == false)
        {
            return Status.Failure;
        }

        if (Ai.Value.NavMeshAgent.isOnNavMesh == false)
        {
            return Status.Failure;
        }

        return Status.Success;
    }

    protected override void OnEnd() { }
}
