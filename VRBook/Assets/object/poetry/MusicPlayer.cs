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
    public TextMeshProUGUI songTitleText; // TextMeshProUGUI로 변경

    public Song[] songs;
    private int currentSongIndex = 0;

    void Start()
    {
        // 버튼에 클릭 이벤트 핸들러를 직접 설정
        nextButton.onClick.AddListener(PlayNextSong);
        prevButton.onClick.AddListener(PlayPreviousSong);
        playButton.onClick.AddListener(TogglePlayPause);
        stopButton.onClick.AddListener(StopMusic);

        // 초기 노래 제목 표시
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

        // 노래 제목 업데이트
        UpdateSongTitle();
    }

    void UpdateSongTitle()
    {
        // 현재 노래의 제목을 TextMeshProUGUI에 표시
        songTitleText.text = songs[currentSongIndex].title;
    }
}




