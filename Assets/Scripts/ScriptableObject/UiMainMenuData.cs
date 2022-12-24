using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/UiMainMenuData", fileName = "UiMainMenuData", order = 51)  ]
public class UiMainMenuData : ScriptableObject
{
    public string MainMenuView = "MainMenu/MainMenu";
    public string SettingsMenuView = "MainMenu/SettingsMenu";
    public string DownloadMenuView = "MainMenu/DownloadMenu";
    public string CreatorsMenuView = "MainMenu/CreatorsMenu";
    public string ExitMenuView = "MainMenu/ExitMenu";

}
