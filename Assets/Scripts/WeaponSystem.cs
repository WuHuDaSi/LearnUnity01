
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform shootTrail;
    [SerializeField] private Transform muzzleFlash;
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
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector2 mousePosition2D = new Vector2(mousePosition.x,mousePosition.y);
            Vector2 firePointPosition = firePoint.position;
            Vector2 shootDirection;
            if (Vector2.Distance(firePointPosition, mousePosition) > 0.5f)
            {
                shootDirection = mousePosition - firePointPosition;
            }
            else
            {

                shootDirection = transform.up; //firePoint.parent.up
            }
            Debug.Log(shootDirection);
            float trailAngle = Mathf.Atan2(shootDirection.y,shootDirection.x) * Mathf.Rad2Deg;
            Quaternion trailRotation = Quaternion.AngleAxis(trailAngle,Vector3.forward);
            Transform trail = Instantiate(shootTrail, firePointPosition, trailRotation);
            Destroy(trail.gameObject,0.05f);
            //Debug.DrawLine(firePointPosition,shootDirection*100,Color.red);
            MuzzleFlash();

        }
        Debug.Log(transform.up);
    }

    private void MuzzleFlash()
    {
        Transform flash = Instantiate(muzzleFlash,firePoint.position,firePoint.rotation);
        flash.SetParent(firePoint);
        float randomSize = Random.Range(0.6f,0.9f);
        flash.localScale = Vector3.one * randomSize;
        Destroy(flash.gameObject,0.05f);
    }
}
