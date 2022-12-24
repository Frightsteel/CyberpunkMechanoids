using Controllers;
using Profile;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

internal class MainMenuController : BaseController
{
    private Transform _placeForUi;
    private ProfilePlayers _profilePlayer;
    private UiMainMenuData _uiMainMenuData;

    private MainMenuView _mainMenuView;

    private Button _newGameButton;
    private Button _settingsButton;
    private Button _downloadButton;
    private Button _creatorsButton;
    private Button _exitButton;

    public MainMenuController(Transform placeForUi, ProfilePlayers profilePlayer, UiMainMenuData uiMainMenuData)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _uiMainMenuData = uiMainMenuData;

        _mainMenuView = LoadView(placeForUi);

        AddButton();
        SubscribeButton();
    }

    private MainMenuView LoadView(Transform placeForUi)
    {
        GameObject prefab = ResourcesLoader.LoadPrefab(new ResourcePath(_uiMainMenuData.MainMenuView));
        GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
        AddGameObject(objectView);

        return objectView.GetComponent<MainMenuView>();
    }

    private void AddButton()
    {
        _newGameButton = _mainMenuView.NewGameButton;
        _settingsButton = _mainMenuView.SettingsButton;
        _downloadButton = _mainMenuView.DownloadButton;
        _creatorsButton = _mainMenuView.CreatorsButton;
        _exitButton = _mainMenuView.ExitButton;
    }

    private void SubscribeButton()
    {
        _newGameButton.onClick.AddListener(OnNewGameButtonClick);
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        _downloadButton.onClick.AddListener(OnDownloadButtonClick);
        _creatorsButton.onClick.AddListener(OnCreatorsButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnExitButtonClick()
    {
        _profilePlayer.CurrentState.Value = GameState.ExitMenu;
    }

    private void OnCreatorsButtonClick()
    {
        _profilePlayer.CurrentState.Value = GameState.Creators;
    }

    private void OnDownloadButtonClick()
    {
        _profilePlayer.CurrentState.Value = GameState.Download;
    }

    private void OnSettingsButtonClick()
    {
        _profilePlayer.CurrentState.Value = GameState.SettingsMenu;
    }

    private void OnNewGameButtonClick()
    {
        SceneManager.LoadScene("FirstFloor");
    }

    private void UnsubscribeButton()
    {
        _newGameButton.onClick.RemoveAllListeners();
        _settingsButton.onClick.RemoveAllListeners();
        _downloadButton.onClick.RemoveAllListeners();
        _creatorsButton.onClick.RemoveAllListeners();
        _exitButton.onClick.RemoveAllListeners();
    }

    protected override void OnDispose()
    {
        UnsubscribeButton();
    }
}