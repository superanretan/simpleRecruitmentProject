using System;
using Recruitment.UI.ScriptableObjects.SceneObject;
using UnityEngine;

namespace Recruitment.Events.SceneEvents
{
    [CreateAssetMenu(menuName = "SceneEvents")]
    public class SceneEvents : ScriptableObject
    {
        public static Action<SceneObjectSo> OnSceneObjectClicked;
    }

}
