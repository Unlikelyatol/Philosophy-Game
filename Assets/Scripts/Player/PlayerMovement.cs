using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    private Animator animator;
    [SerializeField] LayerMask SolidObject;
    [SerializeField] float Movementfactor = 1f;
    [SerializeField] Transform MovePoint;
    [SerializeField] float OffsetX, OffsetY;
    int DirectionNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MovePoint.parent = null;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); 
        vertical = Input.GetAxisRaw("Vertical");
        MovePoint.position = new Vector3(MovePoint.position.x + OffsetX, MovePoint.position.y+ OffsetY, 0);
        transform.position = Vector3.MoveTowards(transform.position, MovePoint.position, Movementfactor * Time.deltaTime);
        animator.SetBool("IsMoving", vertical != 0 || horizontal != 0);
        if (Vector3.Distance(transform.position, MovePoint.position) <= .05f) 
        {
            if (Mathf.Abs(horizontal) == 1)
            {
                if (!Physics2D.OverlapCircle(MovePoint.position+ new Vector3(horizontal, 0f, 0f), 0.2f, SolidObject))
                {
                    MovePoint.position += new Vector3(horizontal, 0f, 0f);
                    DirectionNumber = Mathf.RoundToInt(horizontal);
                    animator.SetInteger("Direction", DirectionNumber*2);
                }
            }
            else if (Mathf.Abs(vertical) == 1)
            {
                if (!Physics2D.OverlapCircle(MovePoint.position + new Vector3(0f, vertical, 0f), 0.2f, SolidObject))
                {
                    MovePoint.position += new Vector3(0f, vertical, 0f);
                    DirectionNumber = Mathf.RoundToInt(vertical);
                    animator.SetInteger("Direction", DirectionNumber);
                }
            }
           
        }
        
    }
}
