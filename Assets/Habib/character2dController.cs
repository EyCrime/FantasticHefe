using UnityEngine;

public class character2dController : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    private Rigidbody2D _rigidbody;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) *Time.deltaTime *MovementSpeed;

        if(Input.GetButtonDown("Jump")&&Mathf.Abs(_rigidbody.velocity.y)<0.001f)
        {
            _rigidbody.AddForce(new Vector2(0,JumpForce), ForceMode2D.Impulse);
        }
    }
}
