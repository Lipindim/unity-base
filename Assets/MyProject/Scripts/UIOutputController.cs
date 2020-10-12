using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIOutputController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthTextMesh;
    [SerializeField] private TextMeshProUGUI _killEnemyCountTextMesh;
    [SerializeField] private TextMeshProUGUI _inventoryTextMesh;
    [SerializeField] private KillsCounter _killCounter;


    private void Start()
    {
        HealthController healthController = GetComponent<HealthController>();
        DisplayHealth(healthController.HealthValue);
        healthController.OnChangeHealth += DisplayHealth;

        DisplayKillEnemyCount(_killCounter.CurrentKillCount);
        _killCounter.OnChangeKillCount += DisplayKillEnemyCount;
    }

    private void DisplayHealth(float health)
    {
        _healthTextMesh.text = $"Жизней: {health}";
    }

    private void DisplayKillEnemyCount(int killEnemyCount)
    {
        _killEnemyCountTextMesh.text = $"Убито: {killEnemyCount}";
    }

    public void DisplayInventory(IEnumerable<Item> items)
    {
        string itemsString = string.Join("\n", items.Select(x => x.ItemName));
        _inventoryTextMesh.text = $"Инвентарь:\n{itemsString}";
    }
}
