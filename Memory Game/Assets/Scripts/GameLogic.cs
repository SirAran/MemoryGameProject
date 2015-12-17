using UnityEngine;
using System.Collections;
using System;

public class GameLogic : MonoBehaviour
{

    int NunberOfElements = 3;
    int ElementCounter = 0;
    //int MaxNumberOfElements = 60;
    int[] MemoryStorage = new int[60];
    bool Start = true;
    bool PlayTime = false;
    bool Victory = false;

    //ArrayList MemoryList = new ArrayList();    
    int RandomNumber;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public AudioSource audioFail;
    public AudioSource audioSuccess;

    // Update is called once per frame
    void Update()
    {

        if (Start == true)
        {
            MemoryGameStart();
        }
    }

    void BeginGameAgain()
    {
        Start = false;
        PlayTime = true;
    }


    public void MemoryGameStart()
    {
        for (int i = 0; i < NunberOfElements; i++)
        {
            RandomNumber = (int)UnityEngine.Random.Range(1.0F, 3.4F);
            MemoryStorage[i] = RandomNumber;
            StartCoroutine(PlayInstructions());

        }
        BeginGameAgain();
    }

    IEnumerator PlayInstructions()
    {
              
        yield return new WaitForSeconds(2);
      

        for (int j = 0; j < NunberOfElements; j++)
        {
            int PlayableNumber = MemoryStorage[j];

            switch (PlayableNumber)
            {
                case 1:
                    Debug.logger.Log(1);
                    Button1.GetComponent<MemoryButton>().FlashIt();
                    AudioSource audio1 = Button1.GetComponent<AudioSource>();
                    if (audio1 != null)
                    {
                        audio1.Play();
                        yield return new WaitForSeconds(1);
                    }
                    break;

                case 2:
                    Debug.logger.Log(2);
                    Button2.GetComponent<MemoryButton>().FlashIt();
                    AudioSource audio2 = Button2.GetComponent<AudioSource>();
                    if (audio2 != null)
                    {
                        audio2.Play();
                        yield return new WaitForSeconds(1);
                    }

                    break;

                case 3:
                    Debug.logger.Log(3);
                    Button3.GetComponent<MemoryButton>().FlashIt();
                    AudioSource audio3 = Button3.GetComponent<AudioSource>();
                    if (audio3 != null)
                    {
                        audio3.Play();
                        yield return new WaitForSeconds(1);
                    }
                    break;
                default:
                    Debug.logger.Log("insufficientError");
                    break;
            }
        }
    }

    // Check if the Value Equals the memory
    public void checkValue(int value)
    {
        int valueToRemember = MemoryStorage[ElementCounter];
        if (valueToRemember == value)
        {
            ElementCounter = ElementCounter + 1;
            if (VictoryCondition())
            {
                if (audioSuccess != null)
                {
                    Victory = true;
                    audioSuccess.Play();
                    NunberOfElements++;
                    ElementCounter = 0;
                    MemoryGameStart();
                }
            }
        }
        else
        {
            PlayTime = false;
            if (audioFail != null)
            {
                audioFail.Play();
                ElementCounter = 0;
                StartCoroutine(PlayInstructions());
                BeginGameAgain();
            }
        }
    }

    // Check if the Player has won the game.
    public bool VictoryCondition()
    {

        if ((ElementCounter) == NunberOfElements)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    
    // Getters and Setters
    public bool getPlayTime()
    {
        return this.PlayTime;
    }
}