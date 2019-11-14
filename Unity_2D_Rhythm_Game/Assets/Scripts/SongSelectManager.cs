using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SongSelectManager : MonoBehaviour
{
    public Image musicImageUI;
    public Text musicTitleUI;
    public Text bpmUI;

    private int musicIndex;
    private int musicCount = 3;

    private void UpdateSong(int musicIndex)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        // 리소스에서 비트 텍스트 파일을 불러온다
        TextAsset textAsset = Resources.Load<TextAsset>("Beats/" + musicIndex.ToString());
        StringReader stringReader = new StringReader(textAsset.text);
        // 첫 번째 줄에 적힌 곡 이름을 읽어서 UI를 업데이트
        musicTitleUI.text = stringReader.ReadLine();
        // 두 번째 줄은 읽기만 하고 아무 처리도 하지 않는다
        stringReader.ReadLine();
        // 세번째 줄에 적힌 BPM을 읽어서 UI를 업데이트
        bpmUI.text = " BPM: " + stringReader.ReadLine().Split(' ')[0];
        // 리소스에서 음악파일을 불러와 재생
        AudioClip audioClip = Resources.Load<AudioClip>("Beats/" + musicIndex.ToString());
        audioSource.clip = audioClip;
        audioSource.Play();
        // 리소스에서 비트 이미지 파일을 불러온다
        musicImageUI.sprite = Resources.Load<Sprite>("Beats/" + musicIndex.ToString());
    }

    public void Right()
    {
        musicIndex = musicIndex + 1;
        if (musicIndex > musicCount)
            musicIndex = 1;
        UpdateSong(musicIndex);
    }
    public void Left()
    {
        musicIndex = musicIndex - 1;
        if (musicIndex < 1)
            musicIndex = musicCount;
        UpdateSong(musicIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        musicIndex = 1;
        UpdateSong(musicIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        PlayerInformation.selectedMusic = musicIndex.ToString();
        SceneManager.LoadScene("GameScene");
    }
}
