using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIOutputController : MonoBehaviour
{

    #region Fields

    [SerializeField] private TextMeshProUGUI _inventoryTextMesh;
    [SerializeField] private TextMeshProUGUI _checkPointTextMesh;
    [SerializeField] private Image _healthBar;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject _vicotryImage;

    private float _maxHealth;

    #endregion


    #region UnityMethods

    private void Start()
    {
        HealthController healthController = GetComponent<HealthController>();
        DisplayHealth(healthController.HealthValue);
        healthController.OnChangeHealth += DisplayHealth;
        _maxHealth = healthController.HealthValue;
    }

    #endregion


    #region Methods

    private void DisplayHealth(float health)
    {
        _healthBar.fillAmount = health / _maxHealth;
    }

    public void DisplayInventory(IEnumerable<Item> items)
    {
        string itemsString = string.Join("\n", items.Select(x => x.ItemName));
        _inventoryTextMesh.text = $"Инвентарь:\n{itemsString}";
    }

    public void DisplayCheckPointMessage(string message, float displayTime)
    {
        _checkPointTextMesh.text = message;
        Invoke(nameof(ClearCheckPointMessage), displayTime);
    }

    private void ClearCheckPointMessage()
    {
        _checkPointTextMesh.SetText(string.Empty);
    }

    public void ShowRestartRound()
    {
        _restartButton.SetActive(true);
        _exitButton.SetActive(true);
    }

    public void DisplayVictoryImage()
    {
        _vicotryImage.SetActive(true);
    }

    #endregion

}
