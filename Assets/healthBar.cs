using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthBar : MonoBehaviour
{
    [SerializeField] private Slider cSlider;
    [SerializeField] private Slider pSlider;
    [SerializeField] private Slider eSlider;
    public void SetMaxHealth(int health)
    {
        pSlider.maxValue = health;
        pSlider.value = health;
        eSlider.maxValue = health;
        eSlider.value = health;
    }
    public void SetPlayerHealth(int health)
    {
        pSlider.value = health;
    }
    public void SetEnemyHealth(int health)
    {
        eSlider.value = health;
    }
    public void SetCoolDown(float health)
    {
        cSlider.value = health;
    }
    public void onExit()
    {
        SceneManager.LoadScene(0);
    }
}
