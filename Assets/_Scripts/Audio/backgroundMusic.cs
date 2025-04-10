using UnityEngine;

public class backgroundMusic : MonoBehaviour
{
    [SerializeField]
    private AudioClip backgroundMusicClip;
    public SoundManager soundManager;

    private void Start()
    {
        if (backgroundMusicClip != null)
        {
            soundManager.PlayLoop(backgroundMusicClip);
        }
        else
        {
            Debug.LogWarning("Background music clip is not assigned.");
        }
    }
}
