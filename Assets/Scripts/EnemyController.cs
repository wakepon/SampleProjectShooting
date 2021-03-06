using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float deathY = -11.0f;
    [SerializeField] private GameObject destroyParticle;
    private Rigidbody2D _rigidbody2D;
    private const string PlayerBulletTag = "PlayerBullet";
    public UnityEvent OnHit { get; private set; }

    void Awake()
    {
        OnHit = new UnityEvent();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Init()
    {
        _rigidbody2D.velocity = Vector3.zero;
    }

    void Update()
    {
        if (transform.position.y < deathY)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }

    void BirthDestroyParticle()
    {
        var obj = Instantiate(destroyParticle);
        obj.transform.position = transform.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(PlayerBulletTag))
        {
            BirthDestroyParticle();
            Die();
            OnHit.Invoke();
        }
    }
}