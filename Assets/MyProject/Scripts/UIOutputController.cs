using TMPro;
using UnityEngine;

public class UIOutputController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthTextMesh;
    [SerializeField] private TextMeshProUGUI _killEnemyCountTextMesh;
    [SerializeField] private KillsCounter _killCounter;

    private void Start()
    {
        HealthController healthController = GetComponent<HealthController>();
        OutputHealth(healthController.HealthValue);
        healthController.OnChangeHealth += OutputHealth;

        OutputKillEnemyCount(_killCounter.CurrentKillCount);
        _killCounter.OnChangeKillCount += OutputKillEnemyCount;
    }

    private void OutputHealth(float health)
    {
        _healthTextMesh.text = $"Жизней: {health}";
    }

    private void OutputKillEnemyCount(int killEnemyCount)
    {
        _killEnemyCountTextMesh.text = $"Убито: {killEnemyCount}";
    }
}
