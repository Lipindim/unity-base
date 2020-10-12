using UnityEngine;


public class MyGameEnding : MonoBehaviour
{
    [SerializeField] private AudioSource _exitAudio;
    [SerializeField] private HealthController _bossHealthController;
    [SerializeField] private HealthController _playerHealthController;

    [SerializeField] private float _fadeDuration = 5.0f;

    private bool _isGameEnd;
    private float _timer;
    private bool _hasAudioPlayed;

    private void Start()
    {
        _bossHealthController.OnDie += EndGame;
    }

    private void Update()
    {
        if (_isGameEnd)
        {
            EndLevel(_exitAudio);
        }
    }
    public void EndGame()
    {
        _isGameEnd = true;
    }

    

    private void EndLevel(AudioSource audioSource)
    {
        if (!_hasAudioPlayed)
        {
            audioSource.Play();
            _hasAudioPlayed = true;
        }

        _timer += Time.deltaTime;

        if (_timer > _fadeDuration)
            Application.Quit();
    }
}
