using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
  [SerializeField] protected int level;

  public UnityEvent enemyKilledEvent;

  private void Start()
  {
    enemyKilledEvent ??= new UnityEvent();
  }

  public void SetLevel(int level)
  {
    this.level = level;
  }

  public int GetLevel()
  {
    return level;
  }

  private void OnDestroy()
  {
    enemyKilledEvent.Invoke();
  }
}
