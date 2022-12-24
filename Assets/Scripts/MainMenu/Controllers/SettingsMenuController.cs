using Controllers;
using Profile;
using Tool;
using UnityEngine;
using UnityEngine.UI;

internal class SettingsMenuController : BaseController
{
    private Transform _placeForUi;
    private ProfilePlayers _profilePlayer;
    private UiMainMenuData _uiMainMenuData;

    private SettingsMenuView _mainMenuView;

    private Button _backButton;

    public SettingsMenuController(Transform placeForUi, ProfilePlayers profilePlayer, UiMainMenuData uiMainMenuData)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _uiMainMenuData = uiMainMenuData;

        _mainMenuView = LoadView(placeForUi);

        AddButton();
        SubscribeButton();
    }

    private SettingsMenuView LoadView(Transform placeForUi)
    {
        GameObject prefab = ResourcesLoader.LoadPrefab(new ResourcePath(_uiMainMenuData.SettingsMenuView));
        GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
        AddGameObject(objectView);

        return objectView.GetComponent<SettingsMenuView>();

    }

    private void AddButton()
    {
        _backButton = _mainMenuView.BackButton;
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