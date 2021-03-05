using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private int _count;
    
    private Coin[] _coinsRemaining;

    void Start()
    {
        Generate();
    }

    private void Update()
    {
        _coinsRemaining = FindObjectsOfType<Coin>();
        if(_coinsRemaining.Length < 1)
            Generate();
    }

    private void Generate()
    {
        for (int i = 0; i < _count; i++)
        {
            Instantiate(_template,new Vector3(10 - (i*5),-0.4F,0), Quaternion.identity);
        }
    }
}
