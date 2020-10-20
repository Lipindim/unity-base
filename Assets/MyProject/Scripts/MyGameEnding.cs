using UnityEngine;


public class MyGameEnding : MonoBehaviour
{

    #region Fields

    [SerializeField] private AudioSource _exitAudio;
    [SerializeField] private HealthController _bossHealthController;
    [SerializeField] private HealthController _playerHealthController;
    [SerializeField] private UIOutputController _uiOutputController;

    [SerializeField] private float _fadeDuration = 5.0f;

    private bool _isGameEnd;
    private float _timer;
    private bool _hasAudioPlayed;

    #endregion


    #region UnityMethods

    private void Start()
    {
        if (_bossHealthController != null)
            _bossHealthController.OnDie += EndGame;

        _playerHealthController.OnDie += OnPlayerDie;
    }

    private void OnPlayerDie()
    {
        _uiOutputController.DisplayCheckPointMessage("Вы проиграли!!!", _fadeDuration);
        _uiOutputController.ShowRestartRound();
        Time.timeScale = 0;
        
    }

    private void Update()
    {
        if (_isGameEnd)
        {
            EndLevel(_exitAudio);
        }
    }

    #endregion


    #region Methods

    public void EndGame()
    {
        _isGameEnd = true;
    }

    private void EndLevel(AudioSource audioSource)
    {
        if (!_hasAudioPlayed)
        {
            audioSource.Play();
            _uiOutputController.DisplayCheckPointMessage("Вы победили!!!", _fadeDuration);
            _uiOutputController.DisplayVictoryImage();
            _hasAudioPlayed = true;
        }

        _timer += Time.deltaTime;

        if (_timer > _fadeDuration)
            Application.Quit();
    }

    #endregion

}
