using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    private Text _text;

    public void Initialize()
    {
        _text = GetComponentInChildren<Text>();
    }

    public void ChangePoint(int point)
    {
        _text.text = point.ToString();
    }
}
