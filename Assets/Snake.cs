using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnakeMovement : MonoBehaviour
{
    private Vector2 direction = Vector2.right;

    public float moveDelay = 0.08f;           // Başlangıç hızı
    private float currentMoveDelay;           // Dinamik hız
    private List<Transform> segments;
    public Transform segmentPrefab;

    void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);

        currentMoveDelay = moveDelay;
        InvokeRepeating(nameof(Move), currentMoveDelay, currentMoveDelay);
    }

    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame && direction != Vector2.down)
            direction = Vector2.up;
        else if (Keyboard.current.sKey.wasPressedThisFrame && direction != Vector2.up)
            direction = Vector2.down;
        else if (Keyboard.current.aKey.wasPressedThisFrame && direction != Vector2.right)
            direction = Vector2.left;
        else if (Keyboard.current.dKey.wasPressedThisFrame && direction != Vector2.left)
            direction = Vector2.right;
    }

    void Move()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Round(newPosition.x + direction.x);
        newPosition.y = Mathf.Round(newPosition.y + direction.y);
        transform.position = newPosition;
    }

    void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = new Vector3(1000, 1000, 0); // Çarpışmayı önle

        segments.Add(segment);

        // 🔥 HIZLANDIRMA
        currentMoveDelay = Mathf.Max(0.03f, currentMoveDelay - 0.008f); // Her yem sonrası hızlan
        CancelInvoke(nameof(Move));
        InvokeRepeating(nameof(Move), currentMoveDelay, currentMoveDelay);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Grow();
            GameManager.Instance.AddScore(1);
            FindObjectOfType<SnakeEffects>().OnEat();
            other.GetComponent<Food>().SendMessage("RandomizePosition");
        }
    }

    void ResetState()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);

        this.transform.position = Vector3.zero;
        direction = Vector2.right;

        // Reset hızı da başlatır
        currentMoveDelay = moveDelay;
        CancelInvoke(nameof(Move));
        InvokeRepeating(nameof(Move), currentMoveDelay, currentMoveDelay);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            FindObjectOfType<SnakeEffects>().OnCrash();
            GameManager.Instance.GameOver();
        }
    }
}
