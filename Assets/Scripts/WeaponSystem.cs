
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool(AnimatorHash.IsShooting,false);
        if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0))
        {
            _animator.SetBool(AnimatorHash.IsShooting,true);
            Debug.Log("shooting");
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePodition2D = new Vector2(mousePosition.x,mousePosition.y);
            Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
            Vector2 shootDirection = mousePodition2D - firePointPosition;
            Debug.DrawLine(firePointPosition,shootDirection*100,Color.red);

        }
    }
}
