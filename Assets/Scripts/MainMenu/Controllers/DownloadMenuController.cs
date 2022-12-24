using Controllers;
using Profile;
using Tool;
using UnityEngine;
using UnityEngine.UI;

internal class DownloadMenuController : BaseController
{
    private Transform _placeForUi;
    private ProfilePlayers _profilePlayer;
    private UiMainMenuData _uiMainMenuData;

    private DownloadMenuView _downloadMenuView;

    private Button _backButton;

    public DownloadMenuController(Transform placeForUi, ProfilePlayers profilePlayer, UiMainMenuData uiMainMenuData)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _uiMainMenuData = uiMainMenuData;

        _downloadMenuView = LoadView(placeForUi);

        AddButton();
        SubscribeButton();
    }

    private DownloadMenuView LoadView(Transform placeForUi)
    {
        GameObject prefab = ResourcesLoader.LoadPrefab(new ResourcePath(_uiMainMenuData.DownloadMenuView));
        GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
        AddGameObject(objectView);

        return objectView.GetComponent<DownloadMenuView>();

    }

    private void AddButton()
    {
        _backButton = _downloadMenuView.BackButton;
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