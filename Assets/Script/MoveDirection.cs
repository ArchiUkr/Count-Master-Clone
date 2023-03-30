using UnityEngine;

public abstract class MoveDirection : MonoBehaviour
{
    private Vector3 direction;
    private Movement movement;
    private void Awake()
    {
        movement = GetComponent<Movement>();
    }
    private void Update()
    {
        direction = CalculateDirection();
    }
    void FixedUpdate()
    {
        movement.Move(direction);
    }
    public void StartMoveDirection()
    {
        enabled = true;

    }
    public void StopMoveDirection()
    {
        enabled = false;
    }
    public abstract Vector3 CalculateDirection();
}
