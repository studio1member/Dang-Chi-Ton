using System.Collections.Generic;
using UnityEngine;

public class ChangeAttackAnimation : MonoBehaviour
{
    public Animator animator;
    public AnimationClip newAttackClip; // Gán clip mới ở đây

    void Awake()
    {
        Debug.Log("1");
        AnimatorOverrideController overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);

        var overrides = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        overrideController.GetOverrides(overrides);

        for (int i = 0; i < overrides.Count; i++)
        {
            if (overrides[i].Key.name == "attack") // phải đúng với tên clip gốc
            {
                overrides[i] = new KeyValuePair<AnimationClip, AnimationClip>(overrides[i].Key, newAttackClip);
                Debug.Log("1");
                break;
            }
        }

        overrideController.ApplyOverrides(overrides);
        animator.runtimeAnimatorController = overrideController;
        Debug.Log("1");
    }
}
