using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [Header("Cấu hình di chuyển")]
    public Transform playerTarget; // Khai báo mục tiêu (Player)
    public float moveSpeed = 3.0f; // Tốc độ di chuyển của Zombie

    [Header("Cấu hình tấn công")]
    public int damage = 10; // Sát thương gây ra cho Player
    public float attackCooldown = 1.5f; // Thời gian giãn cách giữa các lần tấn công
    private float nextAttackTime = 0f;

    void Start()
    {
        // Nếu chưa kéo Player vào Inspector, tự động tìm đối tượng có Tag là "Player"
        if (playerTarget == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                playerTarget = playerObj.transform;
            }
        }
    }

    void Update()
    {
        if (playerTarget != null)
        {
            MoveTowardsPlayer();
        }
    }

    // Hàm điều khiển di chuyển hướng về phía Player
    void MoveTowardsPlayer()
    {
        // Tính toán hướng di chuyển (bỏ qua trục Y để zombie không bị nghiêng/bay lên)
        Vector3 direction = (playerTarget.position - transform.position);
        direction.y = 0;
        direction.Normalize();

        // Quay mặt về phía Player
        if (direction != Vector3.zero)
        {
            transform.forward = direction;
        }

        // Di chuyển Zombie
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    // Xử lý va chạm vật lý (Yêu cầu cả 2 đối tượng đều có Collider, và ít nhất 1 bên có Rigidbody)
    private void OnCollisionStay(Collision collision)
    {
        // Kiểm tra xem đối tượng va chạm có phải là Player không
        if (collision.gameObject.CompareTag("Player"))
        {
            // Kiểm tra thời gian hồi chiêu để tránh gây sát thương liên tục mỗi khung hình
            if (Time.time >= nextAttackTime)
            {
                Attack(collision.gameObject);
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    void Attack(GameObject target)
    {
        Debug.Log("Zombie tấn công Player, gây " + damage + " sát thương!");

        // Gọi hàm mất máu của Player (nếu bạn đã cài đặt script nhận sát thương cho Player)
        /*
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
        */
    }
}