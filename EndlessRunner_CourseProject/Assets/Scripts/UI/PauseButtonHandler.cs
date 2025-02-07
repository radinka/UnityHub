﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonHandler : MonoBehaviour {
    [SerializeField] Sprite pauseIcon = null;
    [SerializeField] Sprite playIcon = null;
    private Button pauseButton = null;
    private Image pauseImage = null;
    public static event Action<bool> OnPauseStateChanged;

    void Start() {
        pauseButton = GetComponent<Button>();
        pauseImage = GetComponent<Image>();
        pauseButton.onClick.AddListener(TogglePause);
    }

    void TogglePause() {
        AudioManager.PlayClickButtonSound();
        if (Time.timeScale == 1) {
            Time.timeScale = 0;
            pauseImage.sprite = playIcon;
            OnPauseStateChanged?.Invoke(true);
        } else {
            Time.timeScale = 1;
            pauseImage.sprite = pauseIcon;
            OnPauseStateChanged?.Invoke(false);
        }
    }
}
