using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public float jumpForce = 10;
    public LogicScript logicScript;
    public bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // ya no se usa el velocity sino el linearVelocity

        if(Input.GetKeyDown(KeyCode.Space)   && !isDead)
        {
            myrigidbody.linearVelocity = Vector2.up * jumpForce;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScreenCollider")
        {
            logicScript.GameOver();
            isDead = true;
        } 
    }
}
