using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour {
    
    public ParticleSystem light_;
    public Transform original;
    public float revs;
    public float rate;
    GameObject gameObject_;
    bool move;
    int color;
	// Use this for initialization
	void Start () {
        move = false;
        color = 1;
	}
    private void OnMouseDown()
    {
        /*鼠标选中gameobject */
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                gameObject_ = hit.collider.gameObject; //获得点击的物体
                light_ = gameObject.GetComponent<ParticleSystem>();
       
        

                if(move){
                    move = false;
                    GameObject empty;
                    empty = gameObject_.transform.parent.gameObject;
                    empty.transform.position = new Vector3(0, 0, 0);
                }
                else{
                    move = true;
                    GameObject empty;
                    empty = gameObject_.transform.parent.gameObject;
                    empty.transform.position = new Vector3(-2, 0, 0);
                }
            }
        }
    }
	// Update is called once per frame
	void Update () {
        if(move){
            if(((color-color % 100)/100)%2 == 0)
                {
                Debug.Log("click2");
                var mainModule = light_.main;
                mainModule.startColor = Color.red;
                mainModule = original.GetComponent<ParticleSystem>().main;
                mainModule.startColor = Color.red;
                color++;
                if (color > 500) color = 0;
            }else{
                Debug.Log("click1");
                var mainModule = light_.main;
                mainModule.startColor = Color.yellow;
                mainModule = original.GetComponent<ParticleSystem>().main;
                mainModule.startColor = Color.yellow;
                color++;
                if (color > 500) color = 0;
            }
            gameObject_.transform.parent.transform.RotateAround(new Vector3(0,0,0),new Vector3(0,0,1), 50 * Time.deltaTime);
        }
	}
}
