using UnityEngine;

namespace Cutscene
{
    [CreateAssetMenu(fileName = "Transition", menuName = "Cutscene/Animation", order = 2)]
    public class Animation : MonoBehaviour
    {
        [Header("Animation name for debugging.")]
        public string animationName;

        [Header("Animator which contains the needed animation.")]
        public Animator controller;

        [Header("Animation trigger to activate wanted animation.")]
        public string triggerName;

        [Header("Animation trigger delay in miliseconds since transition execution.")]
        public uint triggerDelay;
    }
}

