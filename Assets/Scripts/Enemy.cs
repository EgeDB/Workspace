using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemyHealth;
    [SerializeField] private float maxenemyHealth;
    [SerializeField] private Image healthBar;
    private void Start()
    {
        maxenemyHealth = enemyHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(enemyHealth / maxenemyHealth, 0, 1);
    }
}
