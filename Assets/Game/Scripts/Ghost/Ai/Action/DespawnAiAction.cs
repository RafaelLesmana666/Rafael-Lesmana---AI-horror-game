using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(
    name: "Despawn Ai",
    story: "despawn [ai]",
    category: "Action",
    id: "6d80e924998141730f058b9afaa16662"
)]
public partial class DespawnAiAction : Action
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

        Ai.Value.Despawn();
        return Status.Success;
    }

    protected override void OnEnd() { }
}
