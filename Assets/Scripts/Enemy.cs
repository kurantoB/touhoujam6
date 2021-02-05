using UnityEngine;

public class Enemy : MonoBehaviour
{
    // location on map
    public int EnemyX
    {
        get; private set;
    }

    public int EnemyY
    {
        get; private set;
    }

    public float moveDurationSecs;
    public World world;

    private Direction currentMovement;
    private bool isMoving = false;
    private float elapsedMoveTime;
    private float oldEnemyX;
    private float oldEnemyY;

    public void SpawnAt(World w, int x, int y)
    {
        world = w;
        EnemyX = x;
        EnemyY = y;
        transform.position = new Vector3(
            0.5f - (Utils.GRID_WIDTH / 2) + EnemyX,
            0.5f + (Utils.GRID_HEIGHT / 2) - EnemyY,
            transform.position.z);
        world.map[x, y].Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // move the unit
            bool isDoneMoving = Utils.MoveHelper(elapsedMoveTime, moveDurationSecs, gameObject, EnemyX, EnemyY, currentMovement, oldEnemyX, oldEnemyY);
            if (isDoneMoving)
            {
                isMoving = false;
            }
            else
            {
                elapsedMoveTime += Time.deltaTime;
            }
        }
    }

    public void MoveIntent(Direction direction)
    {
        world.map[EnemyX, EnemyY].Remove(gameObject);

        // receive the move signal
        switch (direction)
        {
            case Direction.UP:
                if (EnemyY > 0)
                {
                    EnemyY--;
                }
                break;
            case Direction.DOWN:
                if (EnemyY < Utils.GRID_HEIGHT - 1)
                {
                    EnemyY++;
                }
                break;
            case Direction.LEFT:
                if (EnemyY > 0)
                {
                    EnemyX--;
                }
                break;
            case Direction.RIGHT:
                if (EnemyX < Utils.GRID_WIDTH - 1)
                {
                    EnemyX++;
                }
                break;
        }
        Debug.Log($"Enemy is now at {EnemyX}, {EnemyY} on the grid");
        world.map[EnemyX, EnemyY].Add(gameObject);
        if (direction != Direction.NONE)
        {
            currentMovement = direction;
            isMoving = true;
            elapsedMoveTime = 0f;
            oldEnemyX = transform.position.x;
            oldEnemyY = transform.position.y;
        }
    }
}
