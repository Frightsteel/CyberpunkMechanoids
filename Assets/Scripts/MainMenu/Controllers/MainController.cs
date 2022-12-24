using Controllers;
using Profile;
using UnityEngine;

internal class MainController : BaseController
{
    private Transform _placeForUi;
    private ProfilePlayers _profilePlayer;
    private UiMainMenuData _uiMainMenuData;

    private MainMenuController _mainMenuController;
    private ExitMenuController _exitMenuController;
    private SettingsMenuController _settingsMenuController;
    private DownloadMenuController _downloadMenuController;
    private CreatorsMenuController _creatorsMenuController;

    public MainController(Transform placeForUi, ProfilePlayers profilePlayer, UiMainMenuData uiMainMenuData)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _uiMainMenuData = uiMainMenuData;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    private void OnChangeGameState(GameState state)
    {
        DisposeControllers();
        switch (state)
        {
            case GameState.Game:
                break;
            case GameState.MainMenu:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer, _uiMainMenuData);
                break;
            case GameState.SettingsMenu:
                _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer, _uiMainMenuData);
                break;
            case GameState.Download:
                _downloadMenuController = new DownloadMenuController(_placeForUi, _profilePlayer, _uiMainMenuData);
                break;
            case GameState.Creators:
                _creatorsMenuController = new CreatorsMenuController(_placeForUi, _profilePlayer, _uiMainMenuData);
                break;
            case GameState.ExitMenu:
                _exitMenuController = new ExitMenuController(_placeForUi, _profilePlayer, _uiMainMenuData);
                break;
        }
    }

    private void DisposeControllers()
    {
        _exitMenuController?.Dispose();
        _mainMenuController?.Dispose();
        _settingsMenuController?.Dispose();
        _downloadMenuController?.Dispose();
        _creatorsMenuController?.Dispose();
    }
}