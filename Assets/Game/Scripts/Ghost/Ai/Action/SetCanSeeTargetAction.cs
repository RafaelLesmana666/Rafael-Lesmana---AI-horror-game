using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(
    name: "Set Can See Target",
    story: "Set [CanSeeTarget] from [Ai]",
    category: "Action",
    id: "10de707c19b9cbc54f268aceb0323d16"
)]
public partial class SetCanSeeTargetAction : Action
{
    [SerializeReference]
    public BlackboardVariable<bool> CanSeeTarget;

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

        CanSeeTarget.Value = Ai.Value.SightPerception.CanSeePlayer;
        Debug.Log(CanSeeTarget.Value);
        return Status.Success;
    }

    protected override void OnEnd() { }
}
