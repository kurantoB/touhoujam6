using UnityEngine;

public class Player : MonoBehaviour
{
    // location on map
    public int PlayerX
    {
        get; private set;
    }

    public int PlayerY
    {
        get; private set;
    }

    public float moveDurationSecs;
    public GameObject camera;
    public World world;

    private Direction currentMovement;
    private bool isMoving = false;
    private float elapsedMoveTime;
    private float oldPlayerX;
    private float oldPlayerY;

    private void Start()
    {
        PlayerX = 10;
        PlayerY = 10;
    }

    private void Update()
    {
        if (isMoving)
        {
            // move the unit
            bool isDoneMoving = Utils.MoveHelper(elapsedMoveTime, moveDurationSecs, gameObject, PlayerX, PlayerY, currentMovement, oldPlayerX, oldPlayerY);
            if (isDoneMoving)
            {
                isMoving = false;
            }
            else
            {
                elapsedMoveTime += Time.deltaTime;
            }
        }
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
    }

    public void Move(Direction direction)
    {
        bool isValidSignal = false;

        world.map[PlayerX, PlayerY].Remove(gameObject);
        // receive the move signal
        switch (direction)
        {
            case Direction.UP:
                if (PlayerY > 0)
                {
                    PlayerY--;
                    isValidSignal = true;
                }
                break;
            case Direction.DOWN:
                if (PlayerY < Utils.GRID_HEIGHT - 1)
                {
                    PlayerY++;
                    isValidSignal = true;
                }
                break;
            case Direction.LEFT:
                if (PlayerX > 0)
                {
                    PlayerX--;
                    isValidSignal = true;
                }
                break;
            case Direction.RIGHT:
                if (PlayerX < Utils.GRID_WIDTH - 1)
                {
                    PlayerX++;
                    isValidSignal = true;
                }
                break;
        }
        //Debug.Log($"Player is now at {PlayerX}, {PlayerY} on the grid");
        world.map[PlayerX, PlayerY].Add(gameObject);
        if (isValidSignal)
        {
            currentMovement = direction;
            isMoving = true;
            elapsedMoveTime = 0f;
            oldPlayerX = transform.position.x;
            oldPlayerY = transform.position.y;
        }
    }
}
