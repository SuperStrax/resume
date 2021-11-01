using System.Collections;
using UnityEngine;

public class ZombieAudio : MonoBehaviour
{
    public AudioClip[] zombieAudio;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(spawnAudio());
    }

    IEnumerator spawnAudio()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            AudioClip nowAudio = zombieAudio[Random.Range(0, zombieAudio.Length)];
            audioSource.clip = nowAudio;
            audioSource.Play();
            yield return new WaitForSeconds(3f);
        }
    }
}
