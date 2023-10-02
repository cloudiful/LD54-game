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
    
    public TextMeshProUGUI textBoardCount;


    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        
        // update board count info
        textBoardCount.text = String.Concat("Board remains: ", GameManager.instance.stores[0].ToString());
        
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

        if (GameManager.instance.stores[0] <= 0)
        {
            return;
        }
        
        if (obj.name.StartsWith("Empty"))
        {
            // add the floor on where player clicks
            Instantiate(floorTile, ObjPos, Quaternion.identity);
            Destroy(obj);
            GameManager.instance.stores[0]--;
            textBoardCount.text = String.Concat("Board remains: ", GameManager.instance.stores[0].ToString());
        }
    }
    
}