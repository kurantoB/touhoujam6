using UnityEngine;

public class InputHandling : MonoBehaviour
{
    public float inputCooldown;
    public Player player;

    private float inputCooldownTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (inputCooldownTimer == 0f)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                player.Move(Direction.LEFT);
                inputCooldownTimer = inputCooldown;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                player.Move(Direction.RIGHT);
                inputCooldownTimer = inputCooldown;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                player.Move(Direction.DOWN);
                inputCooldownTimer = inputCooldown;
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                player.Move(Direction.UP);
                inputCooldownTimer = inputCooldown;
            }
        } else
        {
            inputCooldownTimer = Mathf.Max(inputCooldownTimer - Time.deltaTime, 0f);
        }
    }
}
