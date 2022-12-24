using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _downloadButton;
    [SerializeField] private Button _creatorsButton;
    [SerializeField] private Button _exitButton;

    public Button NewGameButton => _newGameButton;
    public Button SettingsButton => _settingsButton;
    public Button DownloadButton => _downloadButton;
    public Button CreatorsButton => _creatorsButton;
    public Button ExitButton => _exitButton;


}
