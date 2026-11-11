using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class playerMana : MonoBehaviour
{
    public int mana = 100;
    public TMP_Text manaText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manaText.text = "Mana: " + mana;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();

        manaText.text = "Mana: " + mana;
    }

    // Mana go up/down

    void Attack()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame && mana > 0)
        {
            mana -= 10;
        }
 
    }
}
