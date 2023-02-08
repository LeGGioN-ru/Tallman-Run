using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSaver : GameSaver
{
    [SerializeField] private PlayerDeformation _playerDeformation;
    [SerializeField] private HeightUpgrade _heightUpgrade;
    [SerializeField] private WidthUpgrade _widthUpgrade;
    [SerializeField] private SpeedUpgrade _speedUpgrade;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private bool _isStartSave;

    private void Start()
    {
        if (_isStartSave)
            Execute();
        else
            SaveCurrentScene();
    }

    private void SaveCurrentScene()
    {
        Save save = GetCurrentSave();
        save.CurrentScene = SceneManager.GetActiveScene().name;
        Execute(save);
    }

    private void OnEnable()
    {
        _widthUpgrade.Clicked += Execute;
        _speedUpgrade.Clicked += Execute;
        _heightUpgrade.Clicked += Execute;
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    private void OnDisable()
    {
        _widthUpgrade.Clicked -= Execute;
        _speedUpgrade.Clicked -= Execute;
        _heightUpgrade.Clicked -= Execute;
        SceneManager.activeSceneChanged -= OnActiveSceneChanged;
    }

    public override Save GetSave()
    {
        return new Save(SceneManager.GetActiveScene().name, _playerMoney.AllMoney, _playerDeformation.StartHeight, _playerDeformation.StartWidth, _heightUpgrade.Level, _widthUpgrade.Level, _speedUpgrade.Level);
    }

    private void OnActiveSceneChanged(Scene scene, Scene scondScene)
    {
        //Execute(GetCurrentSave());
    }
}
