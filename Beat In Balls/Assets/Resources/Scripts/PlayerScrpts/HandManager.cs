using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{
    [SerializeField] Gun currentGun;
    [SerializeField] GameObject currentBullet;

    [SerializeField] Gun[] listOfGuns;
    [SerializeField] Bullets[] listOfBullets;

    [SerializeField] TextMeshProUGUI ammoIndicator;
    [SerializeField] GameObject rechargingIndicator;

    private void Start()
    { 
        currentGun = GetComponentInChildren<Gun>();
    }

    private void Update()
    {
        if (GameManagerScpt.IsPaused)
            return;

        if(currentGun == null)
        {
            EquipGun(0);
        }

        if (currentGun.CheckCoolDown())
        {
            if (Input.GetMouseButtonDown(0))
                currentGun.MouseClicked(currentBullet);

            else if (Input.GetMouseButton(0))
                currentGun.MousePressed(currentBullet);

            if (Input.GetKeyDown(KeyCode.R) && !currentGun.IsRecharding)
                currentGun.StartRecharging();

            ammoIndicator.text = "Munição: " + currentGun.CurrentAmmo;
            rechargingIndicator.SetActive(currentGun.IsRecharding);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            EquipGun(0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            EquipGun(1);
        }
    }


    public void EquipGun(int value)
    {
        if (currentGun != null)
            Destroy(currentGun);

        currentGun = Instantiate(listOfGuns[value], this.transform);
    }
}
