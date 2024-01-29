using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
  public AudioSource src;
  public AudioClip jumpSound, dieSound, pointSound;

  public void playJumpSound()
  {
    src.clip = jumpSound;
    src.Play();
  }

  public void playDieSound()
  {
    src.clip = dieSound;
    src.Play();
  }

  public void playpointSound()
  {
    src.clip = pointSound;
    src.PlayDelayed(0.01f);
  }
}
