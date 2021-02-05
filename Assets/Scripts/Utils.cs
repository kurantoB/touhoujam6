using UnityEngine;

public class Utils
{
    public static int GRID_WIDTH = 20;
    public static int GRID_HEIGHT = 20;

    // returns whether unit is done moving
    public static bool MoveHelper(float elapsedMoveTime, float moveDurationSecs, GameObject unit, int unitX, int unitY, Direction currentMovement, float oldUnitX, float oldUnitY)
    {
        if (elapsedMoveTime > moveDurationSecs)
        {
            // movement over - snap player to grid
            // (0.5, 0.5) is the location of the center of the grid
            unit.transform.position = new Vector3(
                0.5f - (Utils.GRID_WIDTH / 2) + unitX,
                0.5f + (Utils.GRID_HEIGHT / 2) - unitY,
                unit.transform.position.z);
            return true;
        }
        else
        {
            float displacement = elapsedMoveTime / moveDurationSecs;
            switch (currentMovement)
            {
                case Direction.UP:
                    unit.transform.position = new Vector3(
                        unit.transform.position.x,
                        oldUnitY + displacement,
                        unit.transform.position.z);
                    break;
                case Direction.DOWN:
                    unit.transform.position = new Vector3(
                        unit.transform.position.x,
                        oldUnitY - displacement,
                        unit.transform.position.z);
                    break;
                case Direction.LEFT:
                    unit.transform.position = new Vector3(
                        oldUnitX - displacement,
                        unit.transform.position.y,
                        unit.transform.position.z);
                    break;
                case Direction.RIGHT:
                    unit.transform.position = new Vector3(
                        oldUnitX + displacement,
                        unit.transform.position.y,
                        unit.transform.position.z);
                    break;
            }
            return false;
        }
    }
}
