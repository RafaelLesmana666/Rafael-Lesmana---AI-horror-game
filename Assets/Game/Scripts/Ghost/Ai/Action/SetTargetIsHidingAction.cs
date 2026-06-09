using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(
    name: "Set Target Is Hiding",
    story: "Set [TargetIsHiding] From [Ai]",
    category: "Action",
    id: "feb5d7bf0b1b861ea1bc6e1c4484badc"
)]
public partial class SetTargetIsHidingAction : Action
{
    [SerializeReference]
    public BlackboardVariable<bool> TargetIsHiding;

    [SerializeReference]
    public BlackboardVariable<GhostAiController> Ai;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Ai.Value == null && Ai.Value.Target == null)
        {
            return Status.Failure;
        }

        TargetIsHiding.Value = Ai.Value.Target.IsHiding;
        return Status.Success;
    }

    protected override void OnEnd() { }
}
