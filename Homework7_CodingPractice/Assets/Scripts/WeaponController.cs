﻿using System;
using UnityEngine;
using static UnityEngine.Mathf;

public class WeaponController : MonoBehaviour
{
    public static readonly int maxAmmo = 9;

    [SerializeField]
    private int heroAmmo = maxAmmo;
    private Animator animator;
    private bool isFiring;
    private void Awake() {
        heroAmmo = maxAmmo;
    }

    public event Action<int> OnAmmoCountChange;
    public int getAmmo() {
        return heroAmmo;
    }
    public bool TakeAmmo() {
        if (heroAmmo >= 1f) {
            heroAmmo -= 1;
            OnAmmoCountChange?.Invoke(heroAmmo);
            return true;
        }
        else return false;
    }
    // Start is called before the first frame update
    void Start() {
        animator = WeaponController.FindObjectOfType<Animator>(); // GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(1)) {
            TryShoot();
        }
        isFiring = false;
        animator.SetBool("isFiring", isFiring);
    }

    void TryShoot() {
        if (TakeAmmo()) {
            // Debug.Log("TryToShoot");
            isFiring = true;
            animator.SetBool("isFiring", isFiring);
            Debug.LogError("TryShoot - isFiring " + isFiring);
        }
        else isFiring = false;
    }


}
