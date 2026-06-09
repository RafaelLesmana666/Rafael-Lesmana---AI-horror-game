using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(
    name: "Set Last Seen Position",
    story: "Set [LastSeenPosition] From [Ai]",
    category: "Action",
    id: "17e962b910f1a22e66d3edacf7771f69"
)]
public partial class SetLastSeenPositionAction : Action
{
    [SerializeReference]
    public BlackboardVariable<Vector3> LastSeenPosition;

    [SerializeReference]
    public BlackboardVariable<GhostAiController> Ai;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Ai.Value == null && Ai.Value.SightPerception == null)
        {
            return Status.Failure;
        }

        LastSeenPosition.Value = Ai.Value.SightPerception.LastSeenPosition;
        return Status.Success;
    }

    protected override void OnEnd() { }
}
