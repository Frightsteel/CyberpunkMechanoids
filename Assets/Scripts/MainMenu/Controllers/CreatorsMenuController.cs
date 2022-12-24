using Controllers;
using Profile;
using Tool;
using UnityEngine;
using UnityEngine.UI;

internal class CreatorsMenuController : BaseController
{
    private Transform _placeForUi;
    private ProfilePlayers _profilePlayer;
    private UiMainMenuData _uiMainMenuData;

    private CreatorsMenuView _creatorsMenuView;

    private Button _backButton;

    public CreatorsMenuController(Transform placeForUi, ProfilePlayers profilePlayer, UiMainMenuData uiMainMenuData)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _uiMainMenuData = uiMainMenuData;

        _creatorsMenuView = LoadView(placeForUi);

        AddButton();
        SubscribeButton();
    }

    private CreatorsMenuView LoadView(Transform placeForUi)
    {
        GameObject prefab = ResourcesLoader.LoadPrefab(new ResourcePath(_uiMainMenuData.CreatorsMenuView));
        GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
        AddGameObject(objectView);

        return objectView.GetComponent<CreatorsMenuView>();

    }

    private void AddButton()
    {
        _backButton = _creatorsMenuView.BackButton;
    }
    private void SubscribeButton()
    {
        _backButton.onClick.AddListener(OnBackButtonClick);
    }

    private void OnBackButtonClick()
    {
        _profilePlayer.CurrentState.Value = GameState.MainMenu;
    }

    private void UnsubscribeButton()
    {
        _backButton.onClick.RemoveAllListeners();
    }

    protected override void OnDispose()
    {
        UnsubscribeButton();
    }
}