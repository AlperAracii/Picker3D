using Assets.Scripts.Game.LevelScripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LevelGeneratorService _levelGeneratorService;
    [SerializeField] PickerBaseScript _pickerBase;


    private void Start()
    {
        AssetManager.Instance.LoadPlatformPrefabs();
        _pickerBase.Initialize();
        _levelGeneratorService.GenerateLevel();
    }
}
