using UnityEngine;
using UnityEditor.Animations;

namespace Cutscene
{
    [CreateAssetMenu(fileName = "Transition", menuName = "Cutscene/Animation", order = 2)]
    public class Animation : ScriptableObject
    {
        [Header("Animation name for debugging.")]
        public string animationName;

        [Header("Animator which contains the needed animation.")]
        public AnimatorController controller;

        [Header("Animation trigger to activate wanted animation.")]
        public string triggerName;

        [Header("Animation trigger delay in miliseconds since transition execution.")]
        public uint triggerDelay;
    }
}

