using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuInput : MonoBehaviour
{

    private TextMeshProUGUI option1;
    private TextMeshProUGUI option2;
    private TextMeshProUGUI option3;
    private TextMeshProUGUI option4;

    [SerializeField]
    private GameObject button1;
    [SerializeField]
    private GameObject button2;
    [SerializeField]
    private GameObject button3;
    [SerializeField]
    private GameObject button4;

    private int numberOfOptions = 4;

    private int selectedOption;

    private Animator animator1;
    private Animator animator2;
    private Animator animator3;
    private Animator animator4;


    // Use this for initialization
    void Start()
    {
        option1 = button1.GetComponentInChildren<TextMeshProUGUI>();
        option2 = button2.GetComponentInChildren<TextMeshProUGUI>();
        option3 = button3.GetComponentInChildren<TextMeshProUGUI>();
        option4 = button4.GetComponentInChildren<TextMeshProUGUI>();
        animator1 = button1.GetComponent<Animator>();
        animator2 = button2.GetComponent<Animator>();
        animator3 = button3.GetComponent<Animator>();
        animator4 = button4.GetComponent<Animator>();
        Debug.Log(!animator1.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"));

        selectedOption = 1;

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > numberOfOptions) //If at end of list go back to top
            {
                selectedOption = 1;
            }

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    if (!animator1.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                    {
                        animator1.Play("MenuButtonAnimation");
                        //FindObjectOfType<AudioManager>().Play("Click");
                    }
                    break;
                case 2:
                    if (!animator2.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                    {
                        animator2.Play("MenuButtonAnimation");
                        //FindObjectOfType<AudioManager>().Play("Click");
                    }
                    break;
                case 3:
                    if (!animator3.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                    {
                        animator3.Play("MenuButtonAnimation");
                        //FindObjectOfType<AudioManager>().Play("Click");
                    }
                    break;
                case 4:
                    if (!animator4.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                    {
                        animator4.Play("MenuButtonAnimation");
                        //FindObjectOfType<AudioManager>().Play("Click");
                    }
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 1) //If at end of list go back to top
            {
                selectedOption = numberOfOptions;
            }

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    if (!animator1.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                    {
                        animator1.Play("MenuButtonAnimation");
                        //FindObjectOfType<AudioManager>().Play("Click");
                    }
                    break;
                case 2:
                    if (!animator2.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                    {
                        animator2.Play("MenuButtonAnimation");
                        //FindObjectOfType<AudioManager>().Play("Click");
                    }
                    break;
                case 3:
                    if (!animator3.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                    {
                        animator3.Play("MenuButtonAnimation");
                        //FindObjectOfType<AudioManager>().Play("Click");
                    }
                    break;
                case 4:
                    if (!animator4.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                    {
                        animator4.Play("MenuButtonAnimation");
                        //FindObjectOfType<AudioManager>().Play("Click");
                    }
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("Picked: " + selectedOption); //For testing as the switch statment does nothing right now.

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    /*Do option one*/
                    break;
                case 2:
                    /*Do option two*/
                    break;
                case 3:
                    /*Do option two*/
                    break;
            }
        }
    }

}
