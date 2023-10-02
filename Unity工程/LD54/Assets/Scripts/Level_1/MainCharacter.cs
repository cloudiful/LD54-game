using System;
using TMPro;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private Animator _animator;

    private SpriteRenderer _renderer;

    private Rigidbody2D _rigidbody;

    private Transform _transform;

    private GameManager _gameManager;

    public GameObject floorTile;
    public GameObject emptyTile;
    
    public TextMeshProUGUI textMeshProUGUI;


    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        
        GameManager.UpdateBoardCountDisplay(textMeshProUGUI);
        
    }

    // Update is called once per frame
    private void Update()
    {
        movement();

        clickAction();
    }

    /// <summary>
    ///     React to input and move the character
    /// </summary>
    private void movement()
    {
        var inputHorizontal = Input.GetAxisRaw("Horizontal");
        var inputVertical = Input.GetAxisRaw("Vertical");
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            var velocity = new Vector2(inputHorizontal, inputVertical).normalized * 2;

            // set main characters walking animation state to true
            _animator.SetBool("Walk", true);

            // set animation blend params
            _animator.SetFloat("XInput", inputHorizontal);
            _animator.SetFloat("YInput", inputVertical);

            // make character move
            _rigidbody.velocity = velocity;

            // when walk right use normal sprite
            // when walk left use flipped sprite
            _renderer.flipX = inputHorizontal < 0;
        }
        else
        {
            // reset velocity
            _rigidbody.velocity = Vector2.zero;

            // set main characters walking animation state to false
            _animator.SetBool("Walk", false);
        }
    }

    private void clickAction()
    {
        // if no mouse input then return
        if (!Input.GetMouseButtonDown(0)) return;
        
        var onObj = GameManager.MouseOn();
        
        // if mouse click nothing then return
        if (onObj is null) return;

        var obj = GameObject.Find(GameManager.MouseOn());
        // get selected position
        var ObjPos = obj.GetComponent<Transform>().position;

        // if has no board left
        if (GameManager.instance.boardCount <= 0)
        {
            return;
        }

        // get player position
        var playerPos = _transform.position;
        // distance between player with where to put the board
        var distance = Vector3.Distance(ObjPos, playerPos);
        
        // if it is too far then do not allow
        if (distance >= 1.3)
        {
            return;
        }
        
        // if where mouse clicdk is empty then add board
        if (obj.name.StartsWith("Empty"))
        {
            // add the floor on where player clicks
            Instantiate(floorTile, ObjPos, Quaternion.identity);
            Destroy(obj);
            GameManager.instance.boardCount--;
            GameManager.UpdateBoardCountDisplay(textMeshProUGUI);
        }
    }
    
}