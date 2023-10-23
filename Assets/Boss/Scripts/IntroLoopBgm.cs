using UnityEngine;
public class IntroLoopBgm : MonoBehaviour
{
  // オーディオ
    public AudioSource m_audioIntro;
    public AudioSource m_audioLoop;

    // BGMデータ
    public AudioClip m_intro;
    public AudioClip m_loop;


    public void Play()
    {
        m_audioIntro.clip = m_intro;
        m_audioLoop.clip  = m_loop;
        m_audioIntro.Play();
        m_audioLoop.PlayDelayed(29);
    }
}