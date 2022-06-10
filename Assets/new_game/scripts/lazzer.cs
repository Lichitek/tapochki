using UnityEngine;

public class lazzer : MonoBehaviour
{
    [SerializeField] private float def = 100;
    public Transform firePoint;
    public LineRenderer m_linerender;
    Transform m_transform;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }
    private void Update()
    {
        ShootLazer();
    }
    void ShootLazer()
    {
        
        if (Physics2D.Raycast(m_transform.position, transform.up))
        {
            RaycastHit2D hit = Physics2D.Raycast(m_transform.position, transform.up);
            Draw2DRay(firePoint.position, hit.point);
        }
        else
        {
            Draw2DRay(firePoint.position, firePoint.transform.up * def);
        }
    }

    void Draw2DRay(Vector2 strt, Vector2 end)
    {
        m_linerender.SetPosition(0, strt);
        m_linerender.SetPosition(0, end);

    }
}
