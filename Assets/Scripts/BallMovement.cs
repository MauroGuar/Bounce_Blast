using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallMovement2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidBody2D;
    private Camera _mainCamera;
    [SerializeField] private RectTransform rectTransformPauseButton;
    [SerializeField] private Text debugText;
    private bool _canMove;
    private bool _isTouching;
    private bool _touchingPress;
    private bool _newTouch = true;
    private float _xButton;
    private float _yButton;

    private void Start()
    {
        _mainCamera = Camera.main;

        var buttonPos = rectTransformPauseButton.position;
        _xButton = buttonPos.x;
        _yButton = buttonPos.y;
    }

    private void Update()
    {
        CheckInputState();
        if (transform.position.y >= 5.5 || transform.position.y <= -5.5)
        {
            Die();
        }

        // Debug.Log(isTouching + " " + canMove);
    }

    private void FixedUpdate()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    private void ChangeGravity(float gravity)
    {
        _newTouch = false;
        myRigidBody2D.gravityScale = gravity;
        BallScript.changeRotation();
    }

    private bool CanTouchMove()
    {
        return _newTouch && _isTouching && _canMove;
    }

    private void CheckInputState()
    {

        if (Input.touchCount == 1)
        {
            var touchRealPos = _mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (touchRealPos.x <= _xButton || touchRealPos.y <= _yButton)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    _isTouching = true;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    _isTouching = false;
                    _newTouch = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isTouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _newTouch = true;
            _isTouching = false;
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (!col.gameObject.tag.Equals("Support") && !col.gameObject.tag.Equals("Middle")) return;
        _canMove = true;
        if (CanTouchMove()) ChangeGravity(myRigidBody2D.gravityScale * -1);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        _canMove = false;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (!col.gameObject.tag.Equals("Middle")) return;
        _canMove = true;

        var pressSprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
        var spriteName = pressSprite.name;

        if (CanTouchMove())
        {
            switch (spriteName)
            {
                case "PressJumpInvert":
                    _touchingPress = true;
                    ChangeGravity(myRigidBody2D.gravityScale * -1);
                    var force = new Vector2(0, -1300 * Mathf.Pow(myRigidBody2D.gravityScale, 0) * Time.deltaTime);
                    myRigidBody2D.AddForce(force, ForceMode2D.Impulse);
                    break;
                case "PressJump":
                    _touchingPress = true;
                    _newTouch = false;
                    var force2 = new Vector2(0, -1600 * Mathf.Pow(myRigidBody2D.gravityScale, 0) * Time.deltaTime);
                    myRigidBody2D.AddForce(force2, ForceMode2D.Impulse);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        _touchingPress = false;
    }

    private void ChechDieStatus()
    {
        // TODO complete function that checks whether the player should die
    }

    public static void Die()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        BallScript.resetRotation();
    }

    /*public void AvoidMovement()
    {
        isTouching = false;
        newTouch = false;
        if (canMove == true && !touchingPress)
        {
            ChangeGravity(myRigidBody2D.gravityScale * -1);
        }
    }*/
}