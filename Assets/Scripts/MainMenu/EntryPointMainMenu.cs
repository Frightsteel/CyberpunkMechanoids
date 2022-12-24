using Profile;
using UnityEngine;

public class EntryPointMainMenu : MonoBehaviour
{
    [SerializeField] private UiMainMenuData _uiMainMenuData;
    [SerializeField] private Transform _placeForUi;

    private ProfilePlayers _profilePlayer;
    private MainController _mainMenuController;

    private void Awake()
    {
        _profilePlayer = new ProfilePlayers(GameState.MainMenu);
        _mainMenuController = new MainController(_placeForUi, _profilePlayer, _uiMainMenuData);
    }

}
