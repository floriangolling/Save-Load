using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Button[] myButtons;

    private void Awake()
    {
        resetMenuData();
    }

    public void resetMenuData()
    {
        SavableData data = SaveLoadManager.loadData();
        if (data == null)
        {
            makeButtonClickable(1);
        } else
        {
            makeButtonClickable(data.level);
        }
    }

    public void makeButtonClickable(int _level)
    {
        for (int i = 0; i < _level && i < myButtons.Length; i++)
        {
            myButtons[i].interactable = true;
        }
    }

    public void loadScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }
}
