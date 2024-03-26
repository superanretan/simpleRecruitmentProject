using UnityEngine;

namespace Recruitment.UI.ScriptableObjects.SceneObject
{
    [CreateAssetMenu(menuName = "SceneObject")]
    public class SceneObjectSo : ScriptableObject
    {
        [SerializeField] private Sprite objectSprite;
        [SerializeField] private string objectName;
        [TextArea(2,10)]
        [SerializeField] private string objectDescription;

        public Sprite ObjectSprite => objectSprite;
        public string ObjectName => objectName; 
        public string ObjectDescription => objectDescription;
    }
}


