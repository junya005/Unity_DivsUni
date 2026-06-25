using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameSettings : MonoBehaviour
{
    private Vector3 CHECK_POSITION_DOG { get { return new Vector3(0, 423, 0); } }
    private Vector3 CHECK_POSITION_HUMSTER { get { return new Vector3(0, -141, 0); } }
    private Vector3 CHECK_POSITION_PENGUIN { get { return new Vector3(0, -705, 0); } }

    public static int setting_characterID = 0;
    public static bool setting_tutorial;
    [SerializeField] private GameObject _setDogButton;
    [SerializeField] private GameObject _setHumsterButton;
    [SerializeField] private GameObject _setPenguinButton;
    [SerializeField] private GameObject _checkMark;

    private void Start()
    {
        setting_tutorial = true;
    }

    public void Setting_characterID(int _characterID)
    {
        setting_characterID = _characterID;
        DisplayCheckMark(setting_characterID);
    }

    public void ChangeSetTutorial()
    {
        if (setting_tutorial)
        {
            setting_tutorial = false;
        }
        else
        {
            setting_tutorial = true;
        }
    }

    private void DisplayCheckMark(int _characterID)
    {
        switch (_characterID)
        {
            case 0:
                _setDogButton.SetActive(false);
                _setHumsterButton.SetActive(true);
                _setPenguinButton.SetActive(true);
                _checkMark.GetComponent<RectTransform>().localPosition = CHECK_POSITION_DOG;
                break;
            case 1:
                _setDogButton.SetActive(true);
                _setHumsterButton.SetActive(false);
                _setPenguinButton.SetActive(true);
                _checkMark.GetComponent<RectTransform>().localPosition = CHECK_POSITION_HUMSTER;
                break;
            case 2:
                _setDogButton.SetActive(true);
                _setHumsterButton.SetActive(true);
                _setPenguinButton.SetActive(false);
                _checkMark.GetComponent<RectTransform>().localPosition = CHECK_POSITION_PENGUIN;
                break;
            default:
                _setDogButton.SetActive(false);
                _setHumsterButton.SetActive(true);
                _setPenguinButton.SetActive(true);
                _checkMark.GetComponent<RectTransform>().localPosition = CHECK_POSITION_DOG;
                break;
        }
    }
}
