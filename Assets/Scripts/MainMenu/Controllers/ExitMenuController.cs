using Controllers;
using Profile;
using Tool;
using UnityEngine;
using UnityEngine.UI;

internal class ExitMenuController : BaseController
{
    private Transform _placeForUi;
    private ProfilePlayers _profilePlayer;
    private UiMainMenuData _uiMainMenuData;

    private ExitMenuView _exitMenuView;

    private Button _exitButton;
    private Button _backButton;

    public ExitMenuController(Transform placeForUi, ProfilePlayers profilePlayer, UiMainMenuData uiMainMenuData)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _uiMainMenuData = uiMainMenuData;

        _exitMenuView = LoadView(placeForUi);

        AddButton();
        SubscribeButton();
    }

    private void SubscribeButton()
    {
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _backButton.onClick.AddListener(OnBackButtonClick);
    }

    private void OnExitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void OnBackButtonClick()
    {
        _profilePlayer.CurrentState.Value = GameState.MainMenu;
    }

    private void AddButton()
    {
        _exitButton = _exitMenuView.ExitButton;
        _backButton = _exitMenuView.BackButton;
    }  

    private ExitMenuView LoadView(Transform placeForUi)
    {
        GameObject prefab = ResourcesLoader.LoadPrefab(new ResourcePath(_uiMainMenuData.ExitMenuView));
        GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
        AddGameObject(objectView);

        return objectView.GetComponent<ExitMenuView>();
        
    }

    private void UnsubscribeButton()
    {
        _exitButton.onClick.RemoveAllListeners();
        _backButton.onClick.RemoveAllListeners();
    }

    protected override void OnDispose()
    {
        UnsubscribeButton();
    }
}