using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [SerializeField] private int _coins;
    [SerializeField] private Text _coinText;
    

    void Awake()
    {
        Instance = this;
    }
    public void AddCoins()
    {
        _coins += 1;
        _coinText.text = _coins.ToString(); 
    }
}
