
using Recruitment.UI.ScriptableObjects.SceneObject;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Recruitment.UI.GridObject
{
    public class GridObject : MonoBehaviour
    {
        [SerializeField] private Image objectImage;
        [SerializeField] private TextMeshProUGUI objectDescriptionText;
        [SerializeField] private GameObject selectedImage;
        private Button _gridObjectButton;
        public Button GridObjectButton =>_gridObjectButton;


        public void SetObjectSelected(bool isActive)
        {
            selectedImage.SetActive(isActive);
        }

        public void SetupGridObject(SceneObjectSo sceneObjectSo)
        {
            _gridObjectButton = GetComponent<Button>();
            objectImage.sprite = sceneObjectSo.ObjectSprite;
            objectDescriptionText.text = sceneObjectSo.ObjectDescription;
        }
    }
}
