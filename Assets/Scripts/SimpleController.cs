using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField, Range(0, 20)] float speed = 10;
    [SerializeField, Range(0, 20)] float jumpSpeed = 10;

    private bool isGrounded;

    SimplePlayerInventory Inventory;

    [SerializeField] UnityEvent OnTwiceJump = new UnityEvent();

    Action deactivate;

    [SerializeField] GameObject smokeEffect;

    [Header("Editor only")]
    [SerializeField] int InputForTwiceJump;
    [EButton]
    void SetTwiceJump()
    {
        GameManager.Instance.PlayerInventory.TwiceJumpAmount = InputForTwiceJump;
    }
    private void Awake()
    {
        smokeEffect.transform.parent = null;
        GameManager.Instance.AddOnPlayerDie(() => { smokeEffect.transform.position = transform.position;
            smokeEffect.SetActive(true);
        });
        deactivate = () => { gameObject.SetActive(false); };
        GameManager.Instance.AddOnPlayerLoose(deactivate);

    }
    // Start is called before the first frame update
    void Start()
    {
        Inventory = GameManager.Instance.PlayerInventory;
        //ignore trigger colliders for "isGrounded"s detection
        Physics2D.queriesHitTriggers = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        Vector2 v = rigidbody.velocity;
        v.x = x * speed;

        rigidbody.velocity = v;

    }

    private void Update()
    {
        Vector2 v = rigidbody.velocity;
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2);

        isGrounded = Physics2D.Raycast(origin, Vector2.down, 0.001f);

        bool jump = Input.GetButtonDown("Jump");
        //jump:
        bool IsThereTwiceJump = Inventory.TwiceJumpAmount > 0;

        if (jump && (isGrounded || IsThereTwiceJump))
        {
            v.y = jumpSpeed;

            //is this twice jump? yes, if player is on air
            if (!isGrounded)
            {
                Inventory.TwiceJumpAmount--;
                OnTwiceJump.Invoke();
            }

            rigidbody.velocity = v;
        }
    }
}
