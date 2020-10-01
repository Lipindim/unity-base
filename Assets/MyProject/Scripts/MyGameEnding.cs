using UnityEngine;


public class MyGameEnding : MonoBehaviour
{
    [SerializeField] public float _fadeDuration = 5f;
    [SerializeField] public AudioSource _exitAudio;

    private bool _isGameEnd;
    private float _timer;
    private bool _hasAudioPlayed;

    public void EndGame()
    {
        _isGameEnd = true;
    }

    private void Update()
    {
        if (_isGameEnd)
        {
            EndLevel(_exitAudio);
        }
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
