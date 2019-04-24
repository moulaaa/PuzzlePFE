using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour
{
    //[HideInInspector]
    public bool clicked = false;
    //[HideInInspector]
    public bool replace = false;
    //[HideInInspector]
    public bool go_left;
    //[HideInInspector]
    public bool go_right;
    //[HideInInspector]
    public bool go_Down;
    //[HideInInspector]
    public bool go_up;
    //[HideInInspector]
    public Vector3 winPosition;
    //[HideInInspector]
    public float scale_x = 0.09f ;
    //[HideInInspector]
    public float scale_y = 0.09f;
    //[HideInInspector]
    public Vector3 Scale_backup;

    public Vector2 move_amount;
    public Vector2 startPos;
    public bool moved = false;

    public LayerMask puzzleMask;

    private Vector2 startPosition = new Vector2(-3.55f, 1.77f);
    private Vector2 offset = new Vector2(2.03f, 1.52f);

    Ray ray_up, ray_down, ray_left, ray_right;

    RaycastHit2D hit;

    void Start()
    {
        Scale_backup = transform.localScale;
        winPosition = transform.position; 
          move_amount = offset;

    }

    // Update is called once per frame
    void Update()
    {
        MovePuzzle();
    }
    private void OnMouseUp()
    {
        
            if (GameManager.game_Status.Status == GameStatus.GameStat.play)
            { clicked = false; }
        
        
            if (GameManager.game_Status.Status == GameStatus.GameStat.replace_puzzle)
            { replace = false;
            if (GameManager.replace_element== GameManager.RemplaceElement.first)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                GameManager.pos2 = transform.position;
                GameManager.element2_name = gameObject.name;
                GameManager.replace_element = GameManager.RemplaceElement.second;
            }
            if (GameManager.replace_element == GameManager.RemplaceElement.second)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                GameManager.pos1 = transform.position;
                GameManager.element1_name = gameObject.name;
                GameManager.replace_element = GameManager.RemplaceElement.finished;
            }
        }
        
    }
    private void OnMouseDown()
    {

        clicked = true;
        moved = false;
        CheckMoveAbility();
    }

    void CheckMoveAbility()
    {
        RaycastHit[] rays ;
        ray_right = new Ray(transform.position, Vector3.right);
        ray_up = new Ray(transform.position, Vector3.up);
        ray_down = new Ray(transform.position, Vector3.down);
        ray_left = new Ray(transform.position, Vector3.left);

        rays = Physics.RaycastAll(ray_right, 3);
        if ((rays.Length == 0) && (moved == false) && transform.position.x < (startPosition.x + 3 * offset.x))
        {
            Debug.Log("Move Right Allowed");
            go_right = true;
        }

        
        rays = Physics.RaycastAll(ray_down, 2);

        if (rays.Length == 0 && (moved == false) && (transform.position.y > -2.5f))
        {
            Debug.Log("Move Down Allowed");
            go_Down = true;
        }

        
        rays = Physics.RaycastAll(ray_left, 3);

        if (rays.Length == 0 && (moved == false) && (transform.position.x > startPosition.x))
        {
            Debug.Log("Move Left Allowed");
            go_left = true;
        }
        
        rays = Physics.RaycastAll(ray_up, 2);
        
        if (rays.Length == 0 && (moved == false) && (transform.position.y < startPosition.y))
        {
            Debug.Log("Move Right  Allowed");
            go_up = true;
        }
        MovePuzzle();
    } 

    void  MovePuzzle()
    { 
        if (go_left)
        { transform.position = new Vector3(transform.position.x - move_amount.x, transform.position.y, transform.position.z);
            go_left = false;
            moved = true;
        }
      if (go_right)
        {
            transform.position = new Vector3(transform.position.x + move_amount.x, transform.position.y, transform.position.z);
            go_right = false;
            moved = true;
        }
      if (go_up)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + move_amount.y, transform.position.z);
            go_up = false;
            moved = true;
        }
        if (go_Down)
        {
            
            transform.position = new Vector3(transform.position.x, transform.position.y - move_amount.y, transform.position.z);
            go_Down = false;
            moved = true;
        }
    }

}
