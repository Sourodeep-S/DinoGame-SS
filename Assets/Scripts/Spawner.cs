using UnityEngine;

public class Spawner : MonoBehaviour
{
  [System.Serializable]
  public struct SpawnableObject
  {
    public GameObject prefab;
    [Range(0f, 1f)]
    public float spwanChance;
  };

  public SpawnableObject[] objects;

  public float minSpawnRate = 1f;
  public float maxSpawnRate = 2f;


  private void OnEnable()
  {
    Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
  }

  private void OnDisable()
  {
    CancelInvoke();
  }

  private void Spawn()
  {
    float spawnchance = Random.value;

    foreach (var obj in objects)
    {
      if (spawnchance < obj.spwanChance)
      {
        GameObject obstacle = Instantiate(obj.prefab);
        obstacle.transform.position += transform.position;
        break;
      }

      spawnchance -= obj.spwanChance;
    }

    Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
  }

}
