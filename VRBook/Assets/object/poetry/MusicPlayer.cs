using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public Button nextButton;
    public Button prevButton;
    public Button playButton;
    public Button stopButton;
    public TextMeshProUGUI songTitleText; // TextMeshProUGUI�� ����

    public Song[] songs;
    private int currentSongIndex = 0;

    void Start()
    {
        // ��ư�� Ŭ�� �̺�Ʈ �ڵ鷯�� ���� ����
        nextButton.onClick.AddListener(PlayNextSong);
        prevButton.onClick.AddListener(PlayPreviousSong);
        playButton.onClick.AddListener(TogglePlayPause);
        stopButton.onClick.AddListener(StopMusic);

        // �ʱ� �뷡 ���� ǥ��
        UpdateSongTitle();
    }

    void TogglePlayPause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }

    void PlayNextSong()
    {
        currentSongIndex = (currentSongIndex + 1) % songs.Length;
        PlayCurrentSong();
    }

    void PlayPreviousSong()
    {
        currentSongIndex = (currentSongIndex - 1 + songs.Length) % songs.Length;
        PlayCurrentSong();
    }

    void StopMusic()
    {
        audioSource.Stop();
    }

    void PlayCurrentSong()
    {
        audioSource.clip = songs[currentSongIndex].audioClip;
        audioSource.Play();

        // �뷡 ���� ������Ʈ
        UpdateSongTitle();
    }

    void UpdateSongTitle()
    {
        // ���� �뷡�� ������ TextMeshProUGUI�� ǥ��
        songTitleText.text = songs[currentSongIndex].title;
    }
}




