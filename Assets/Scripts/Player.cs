using UnityEngine;

public class Player : MonoBehaviour
{
  private CharacterController character;
  private Vector3 direction;
  private SoundEffectsPlayer sound;
  public Crouch crouch;
  public AnimateSprites erect;

  public float gravity = 9.81f * 2f;
  public float jumpforce = 8f;

  private void Awake()
  {
    character = GetComponent<CharacterController>();
    sound = GetComponent<SoundEffectsPlayer>();
    erect = GetComponent<AnimateSprites>();
    crouch = GetComponent<Crouch>();
  }

  private void OnEnable()
  {
    direction = Vector3.zero;
    erect.enabled = true;
    crouch.enabled = false;
  }

  private void Update()
  {
    direction += Vector3.down * gravity * Time.deltaTime;

    if (character.isGrounded)
    {
      direction = Vector3.down;

      if (Input.GetKeyDown(KeyCode.UpArrow))
      {
        erect.enabled = true;
        crouch.enabled = false;
        direction = Vector3.up * jumpforce;
        sound.playJumpSound();
      }

      else if (Input.GetKeyDown(KeyCode.DownArrow))
      {
        erect.enabled = false;
        crouch.enabled = true;
      }

    }

    character.Move(direction * Time.deltaTime);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Obstacle"))
      GameManager.Instance.GameOver();
  }

}
