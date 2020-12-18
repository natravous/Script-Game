using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Scripting;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    private int maxStamina = 100;
    private int currentStamina;

    private PlayerState playerState;
    //private PlayerMovements player;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    private Coroutine regen;

    public static StaminaBar instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //currentStamina = playerState.maxEnergi;
        //staminaBar.maxValue = playerState.maxEnergi;
        //staminaBar.value = playerState.maxEnergi;

        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if(regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("TIDAK CUKUP STAMINA");
        }
    }

    public IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            //currentStamina += playerState.maxEnergi / 100;

            staminaBar.value = currentStamina;
            yield return regenTick;
            Debug.Log("Stamina bertambah menjadi: " + currentStamina);
        }
        regen = null;
    }

}
