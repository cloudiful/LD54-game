using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private Animator _animator;

    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        var inputHorizontal = Input.GetAxis("Horizontal");
        var inputVertical = Input.GetAxis("Vertical");
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            var movement = new Vector2(inputHorizontal, inputVertical);
            transform.Translate(movement * Time.deltaTime);
            // set main characters walking animation state to true
            _animator.SetBool("walking", true);
            if (inputHorizontal > 0)
                // when walk right
                _renderer.flipX = false;
            else
                // when walk left, flip the sprite
                _renderer.flipX = true;
        }
        else
        {
            // set main characters walking animation state to false
            _animator.SetBool("walking", false);
        }
    }
}