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
    [SerializeField] GameObject[] listOfBullets;

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
    }


    public void EquipGun(int value)
    {
        if (currentGun != null)
            Destroy(currentGun.gameObject);

        currentGun = Instantiate(listOfGuns[value], this.transform);
    }

    public void EquipAmmo(int value)
    {
        currentBullet = listOfBullets[value];
    }
}
