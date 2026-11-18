using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    // Different facing positions
    public Sprite wizardup;
    public Sprite wizarddown;
    public Sprite wizardleft;
    public Sprite wizardright;

    // Weapon
    public Transform Weapon;
    public SpriteRenderer weaponRenderer;
    public Transform firepoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {

        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -moveSpeed;
            spriteRenderer.sprite = wizardleft;

            Weapon.localScale = new Vector3(-1f, 1f, 1f);
            firepoint.localRotation = Quaternion.Euler(0, 0, -90);
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = moveSpeed;
            spriteRenderer.sprite = wizardright;

            Weapon.localScale = new Vector3(1f, 1f, 1f);
            firepoint.localRotation = Quaternion.Euler(0, 0, -90);
        }
        else
        {
            speedX = 0;
        }

        // Vertical Movement
        if (Keyboard.current.wKey.isPressed)
        {
            speedY = moveSpeed;
            spriteRenderer.sprite = wizardup;

            Weapon.localScale = new Vector3(1f, 1f, 1f);
            firepoint.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            speedY = -moveSpeed;
            spriteRenderer.sprite = wizarddown;

            Weapon.localScale = new Vector3(1f, 1f, 1f);
            firepoint.localRotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            speedY = 0;
        }

        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}
