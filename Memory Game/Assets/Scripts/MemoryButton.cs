using UnityEngine;
using System.Collections;

public class MemoryButton : MonoBehaviour {

    public new AudioSource audio;
    public GameObject Gamelogic;
    public int value;
    bool Flash = false;
       
    // Use this for initialization
    void Start(){

    }

    // Event on mouse click
    void OnMouseDown(){        
        if (Gamelogic.GetComponent<GameLogic>().getPlayTime() == true){ 
            this.Play();           
            Gamelogic.GetComponent<GameLogic>().checkValue(value);
            Flash = true;            
        }
    }

    // Update is called once per frame
    void Update(){

        if (Flash == true)
        {           
            StartCoroutine(FlashingIt());            
            Flash = false;
        }
    }

    void Play(){
        if (audio != null)
        {
            audio.Play();
        }
    }

    public void FlashIt()
    {
        StartCoroutine(FlashingIt());
    }

    IEnumerator FlashingIt()
    {
        Color OldColor = gameObject.GetComponent<Renderer>().material.color;
        Color FlashColor = gameObject.GetComponent<Renderer>().material.color * (1.5F * Color.white);
        gameObject.GetComponent<Renderer>().material.color = FlashColor;
        yield return new WaitForSeconds(0.5F);
        gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color * (0.667F * Color.white); ;

    }   
}
