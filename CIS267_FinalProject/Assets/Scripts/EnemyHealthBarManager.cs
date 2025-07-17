using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarManager : MonoBehaviour
{
    public Image healthBar;
    public int maxHealth = 100;
    private int curHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateHealthBar()
    {
        float health = (float)curHealth / maxHealth;
        healthBar.fillAmount = health;

    }

    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
        curHealth -= damage;
        //ensures everything stays in valid range
        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
        UpdateHealthBar();
    }
}
