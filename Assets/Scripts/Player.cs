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

    private void Start()
    {
        PlayerX = 10;
        PlayerY = 10;
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.UP:
                if (PlayerY > 0)
                {
                    PlayerY--;
                }
                break;
            case Direction.DOWN:
                if (PlayerY < Constants.GRID_HEIGHT - 1)
                {
                    PlayerY++;
                }
                break;
            case Direction.LEFT:
                if (PlayerX > 0)
                {
                    PlayerX--;
                }
                break;
            case Direction.RIGHT:
                if (PlayerX < Constants.GRID_WIDTH - 1)
                {
                    PlayerX++;
                }
                break;
        }
    }
}
