using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MushroomController _mushroomController;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _winScreen;

    private void OnEnable()
    {
        _mushroomController.OnKilled += OnKilledMushroom;
    }

    private void OnDisable()
    {
        _mushroomController.OnKilled -= OnKilledMushroom;
    }

    private void OnKilledMushroom()
    {
        _endScreen.SetActive(true);
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void LvlComplite()
    {
        _winScreen.SetActive(true);
        _mushroomController.enabled = false;
    }
}