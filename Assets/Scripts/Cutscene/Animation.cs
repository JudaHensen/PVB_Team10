using UnityEngine;

namespace Cutscene
{
    [CreateAssetMenu(fileName = "Transition", menuName = "Cutscene/Animation", order = 2)]
    public class Animation : ScriptableObject
    {
        [Header("Animation name for debugging.")]
        public string animationName;

        [Header("Animator which contains the needed animation.")]
        public Animator animator;

        [Header("Animation trigger to activate wanted animation.")]
        public string triggerName;
    }
}

