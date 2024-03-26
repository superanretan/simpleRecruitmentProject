using System.Collections.Generic;
using DG.Tweening;
using Recruitment.Events.SceneEvents;
using Recruitment.UI.GridObject;
using Recruitment.UI.ScriptableObjects.SceneObject;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Recruitment.Managers
{
    [System.Serializable]
    public class GridObjectsPairing
    {
        private SceneObjectSo _sceneObjectSo;
        private Objects.SceneObject.SceneObject _sceneObject;
        private GridObject _gridObject;

        public SceneObjectSo SceneObjectSo => _sceneObjectSo;
        public Objects.SceneObject.SceneObject SceneObject => _sceneObject;
        public GridObject GridObject => _gridObject;

        public void SetGridObjectsPairing(SceneObjectSo sceneObjectSo, Objects.SceneObject.SceneObject sceneObject,
            GridObject gridObject)
        {
            this._sceneObjectSo = sceneObjectSo;
            this._sceneObject = sceneObject;
            this._gridObject = gridObject;
        }
    }

    public class MenuSceneObjectsManager : MonoBehaviour
    {
        [SerializeField] private GridObject gridObjectPrefab;
        [SerializeField] private Transform gridParent;
        [SerializeField] private TextMeshProUGUI objectNameText;
        [SerializeField] private SceneEvents sceneEvents;

        [Header("Menu UI")] [SerializeField] private Button closeMenuButton;
        [SerializeField] private Transform menuPanel;
        [SerializeField] private Transform menuOpenPosition;
        [SerializeField] private Transform menuClosePosition;
        [Header("----")] [SerializeField] private Transform sceneParent;
        private List<Objects.SceneObject.SceneObject> _sceneObjectsList = new List<Objects.SceneObject.SceneObject>();
        private List<GridObjectsPairing> _gridObjectsPairingList = new List<GridObjectsPairing>();

        void Start()
        {
            SetupSceneObjectsGrid();
            closeMenuButton.onClick.AddListener(() => { ShowMenu(false); });
        }

        private void OnEnable()
        {
            SceneEvents.OnSceneObjectClicked += OnSceneObjectClicked;
        }

        private void OnDisable()
        {
            SceneEvents.OnSceneObjectClicked -= OnSceneObjectClicked;
        }

        private void OnSceneObjectClicked(SceneObjectSo sceneObjectSo)
        {
            SwitchActiveGridObject(sceneObjectSo);
            ShowMenu(true);
        }

        private void ShowMenu(bool show)
        {
            menuPanel.transform.DOMove(show ? menuOpenPosition.position : menuClosePosition.position, 0.3f);
        }

        private void SwitchActiveGridObject(SceneObjectSo sceneObjectSo)
        {
            foreach (var gridObjectsPairing in _gridObjectsPairingList)
            {
                if (gridObjectsPairing.SceneObjectSo == sceneObjectSo)
                {
                    gridObjectsPairing.GridObject.SetObjectSelected(true);
                    SwitchObjectName(sceneObjectSo.ObjectName);
                }
                else
                    gridObjectsPairing.GridObject.SetObjectSelected(false);
            }
        }

        private void SwitchObjectName(string objectName)
        {
            objectNameText.text = objectName;
        }

        private void SetupSceneObjectsGrid()
        {
            if (sceneParent.GetComponentsInChildren<Objects.SceneObject.SceneObject>() != null)
                _sceneObjectsList.AddRange(sceneParent.GetComponentsInChildren<Objects.SceneObject.SceneObject>());
            else
            {
                Debug.LogError("Scene don't have SceneObject objects!");
                return;
            }

            foreach (var sceneObject in _sceneObjectsList)
            {
                var gridObject = Instantiate(gridObjectPrefab, parent: gridParent);
                gridObject.SetObjectSelected(false);
                gridObject.SetupGridObject(sceneObject.SceneObjectSo);
                gridObject.GridObjectButton.onClick.AddListener(() =>
                {
                    SwitchActiveGridObject(sceneObject.SceneObjectSo);
                });

                var gridObjectsPairing = new GridObjectsPairing();
                gridObjectsPairing.SetGridObjectsPairing(sceneObject.SceneObjectSo, sceneObject, gridObject);
                _gridObjectsPairingList.Add(gridObjectsPairing);
            }
        }
    }
}