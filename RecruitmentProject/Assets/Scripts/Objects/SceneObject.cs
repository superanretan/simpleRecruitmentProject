using Recruitment.Events.SceneEvents;
using Recruitment.Interfaces;
using Recruitment.UI.ScriptableObjects.SceneObject;
using UnityEngine;

namespace Recruitment.Objects.SceneObject
{
    public class SceneObject : MonoBehaviour , ISceneObject
    {
        [SerializeField] private SceneObjectSo sceneObjectSo;
        public SceneObjectSo SceneObjectSo => sceneObjectSo;

        private void Start()
        {
            this.transform.tag = "SceneObject";
        }

        public void OnObjectClicked()
        {
            SceneEvents.OnSceneObjectClicked?.Invoke(sceneObjectSo);
        }
    }
}

