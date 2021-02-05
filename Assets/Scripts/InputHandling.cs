using UnityEngine;

public class InputHandling : MonoBehaviour
{
    public float inputCooldown;
    public Player player;
    public World world;

    private float inputCooldownTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        // as opposed to player attack input
        // enemies will move according to player's new location, which is updated through player.Move()
        bool playerMoveInput = false;
        if (inputCooldownTimer == 0f)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                player.Move(Direction.LEFT);
                inputCooldownTimer = inputCooldown;
                playerMoveInput = true;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                player.Move(Direction.RIGHT);
                inputCooldownTimer = inputCooldown;
                playerMoveInput = true;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                player.Move(Direction.DOWN);
                inputCooldownTimer = inputCooldown;
                playerMoveInput = true;
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                player.Move(Direction.UP);
                inputCooldownTimer = inputCooldown;
                playerMoveInput = true;
            }
        } else
        {
            inputCooldownTimer = Mathf.Max(inputCooldownTimer - Time.deltaTime, 0f);
        }

        if (playerMoveInput)
        {
            foreach (Enemy enemy in world.GetEnemies())
            {
                int xDelta = enemy.EnemyX - player.PlayerX;
                int yDelta = enemy.EnemyY - player.PlayerY;
                // TODO: Also check for obstacles?
                if (Mathf.Abs(xDelta) >= Mathf.Abs(yDelta))
                {
                    if (xDelta > 0)
                    {
                        enemy.MoveIntent(Direction.LEFT);
                    } else
                    {
                        enemy.MoveIntent(Direction.RIGHT);
                    }
                } else
                {
                    if (yDelta > 0)
                    {
                        enemy.MoveIntent(Direction.UP);
                    } else
                    {
                        enemy.MoveIntent(Direction.DOWN);
                    }
                }
            }
        }
    }
}
