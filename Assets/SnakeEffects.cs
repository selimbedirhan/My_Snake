// SnakeEffects.cs - Sadece ses efektleri, arka plan ve renk geçişi kaldırıldı
using UnityEngine;

public class SnakeEffects : MonoBehaviour
{
    public Camera mainCamera;
    public AudioSource audioSource;
    public AudioClip eatSound;
    public AudioClip crashSound;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    public void OnEat()
    {
        PlayEatSound();
    }

    public void OnCrash()
    {
        PlayCrashSound();
    }

    void PlayEatSound()
    {
        if (eatSound != null && audioSource != null)
            audioSource.PlayOneShot(eatSound);
    }

    void PlayCrashSound()
    {
        if (crashSound != null && audioSource != null)
            audioSource.PlayOneShot(crashSound);
    }
}