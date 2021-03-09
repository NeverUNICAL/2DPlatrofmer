
using UnityEngine;

public class EnemyPatrolMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Transform[] _moveSpots;

    private int _currentMoveSpot;

    private void Awake()
    {
        _currentMoveSpot = 0;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            _moveSpots[_currentMoveSpot].position,
            _movementSpeed * Time.deltaTime
            );
        
        if (transform.position ==_moveSpots[_currentMoveSpot].position)
        {
            if (_moveSpots[_currentMoveSpot] == _moveSpots[0] )
                _currentMoveSpot = 1;
            else 
                _currentMoveSpot = 0;
        }
    }
}
