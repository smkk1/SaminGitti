using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private float aika;

    

    private GameObject MainMenuMenu;
    private GameObject optionsMenu;

    private int numberOfOptions = 4;

    private int selectedOption;

    private GameObject button1;
    private GameObject button2;
    private GameObject button3;
    private GameObject button4;
    private Animator animator1;
    private Animator animator2;
    private Animator animator3;
    private Animator animator4;
    private InputManager im;

    public static MenuManager instance;

    private Animator optionsAnimator1;
    private Animator optionsAnimator2;
    private Animator optionsAnimator3;
    private Animator optionsAnimator4;

    private GameObject optionsButton1;
    private GameObject optionsButton2;
    private GameObject optionsButton3;
    private GameObject optionsButton4;


    private HiScoreInput hiInput;

    // Start is called before the first frame update
    void Start()
    {
        
        im = FindObjectOfType<InputManager>();
        button1 = GameObject.Find("PlayButton");
        button2 = GameObject.Find("HighScoreButton");
        button3 = GameObject.Find("OptionsButton");
        button4 = GameObject.Find("QuitButton");
        MainMenuMenu = GameObject.Find("MainMenu");
        optionsMenu = GameObject.Find("OptionsMenu");

        

        selectedOption = 1;

        animator1 = button1.GetComponent<Animator>();
        animator2 = button2.GetComponent<Animator>();
        animator3 = button3.GetComponent<Animator>();
        animator4 = button4.GetComponent<Animator>();

        optionsButton1 = GameObject.Find("CameraPos1");
        optionsButton2 = GameObject.Find("CameraPos2");
        optionsButton3 = GameObject.Find("CameraPos3");

        optionsAnimator1 = optionsButton1.GetComponent<Animator>();
        optionsAnimator2 = optionsButton2.GetComponent<Animator>();
        optionsAnimator3 = optionsButton3.GetComponent<Animator>();



        optionsMenu.SetActive(false);

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    void FixedUpdate()
    {
        aika += Time.deltaTime;
    }

    void Update()
    {
        if(MainMenuMenu == null)
        {
            button1 = GameObject.Find("PlayButton");
            button2 = GameObject.Find("HighScoreButton");
            button3 = GameObject.Find("OptionsButton");
            button4 = GameObject.Find("QuitButton");
            MainMenuMenu = GameObject.Find("MainMenu");
            optionsMenu = GameObject.Find("OptionsMenu");

            animator1 = button1.GetComponent<Animator>();
            animator2 = button2.GetComponent<Animator>();
            animator3 = button3.GetComponent<Animator>();
            animator4 = button4.GetComponent<Animator>();

            optionsButton1 = GameObject.Find("CameraPos1");
            optionsButton2 = GameObject.Find("CameraPos2");
            optionsButton3 = GameObject.Find("CameraPos3");

            optionsAnimator1 = optionsButton1.GetComponent<Animator>();
            optionsAnimator2 = optionsButton2.GetComponent<Animator>();
            optionsAnimator3 = optionsButton3.GetComponent<Animator>();

            optionsMenu.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Menu" && MainMenuMenu.activeSelf == true)
        {
            if (im.vasen == 0 && im.oikea == 1)
            {
                if (aika > 0.5f)
                {
                    selectedOption -= 1;
                    if (selectedOption < 1)
                    {
                        selectedOption = numberOfOptions;
                    }
                    Debug.Log(selectedOption);

                    switch (selectedOption)
                    {
                        case 1:
                            aika = 0f;
                            if (!animator1.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                animator1.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                        case 2:
                            aika = 0f;
                            if (!animator2.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                animator2.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                        case 3:
                            aika = 0f;
                            if (!animator3.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                animator3.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                        case 4:
                            aika = 0f;
                            if (!animator4.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                animator4.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                    }
                }

            }

            else if (im.vasen == 1 && im.oikea == 0)
            {
                if (aika > 0.5f)
                {
                    selectedOption += 1;
                    if (selectedOption > numberOfOptions)
                    {
                        selectedOption = 1;
                    }
                    Debug.Log(selectedOption);

                    switch (selectedOption)
                    {
                        case 1:
                            aika = 0f;
                            if (!animator1.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                animator1.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                        case 2:
                            aika = 0f;
                            if (!animator2.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                animator2.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                        case 3:
                            aika = 0f;
                            if (!animator3.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                animator3.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                        case 4:
                            aika = 0f;
                            if (!animator4.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                animator4.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                    }
                }
            }
            else if (im.vasen == 1 && im.oikea == 1)
            {
                Debug.Log("Picked: " + selectedOption);

                switch (selectedOption)
                {
                    case 1:
                        MainMenu.PlayGame();
                        break;
                    case 2:
                        MainMenu.OpenHighScore();
                        break;
                    case 3:
                        optionsMenu.SetActive(true);
                        MainMenuMenu.SetActive(false);


                        break;
                    case 4:
                        MainMenu.QuitGame();
                        break;
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "HighScore")
        {
            hiInput = FindObjectOfType<HiScoreInput>();
            if (im.vasen == 0 && im.oikea == 1)
            {
                if (aika > 0.5f)
                {
                    hiInput.NextAlphaBet();
                    aika = 0f;
                }

            }

            else if (im.vasen == 1 && im.oikea == 0)
            {
                if (aika > 0.5f)
                {
                    hiInput.PrevAlphaBet();
                    aika = 0f;
                }
            }
            else if (im.vasen == 1 && im.oikea == 1)
            {
                if (aika > 0.5f)
                {
                    hiInput.NextLetter();
                    aika = 0f;
                    if (hiInput.end == true)
                    {
                        SceneManager.LoadScene(0);
                        aika = 0f;
                    }
                }
            }
        
        }
        if (SceneManager.GetActiveScene().name == "Menu" && MainMenuMenu.activeSelf == false)
        {
            Debug.Log("123");
            if (im.vasen == 0 && im.oikea == 1)
            {
                if (aika > 0.5f)
                {
                    selectedOption -= 1;
                    if (selectedOption < 1)
                    {
                        selectedOption = numberOfOptions;
                    }
                    Debug.Log(selectedOption);

                    switch (selectedOption)
                    {
                        case 1:
                            aika = 0f;
                            if (!optionsAnimator1.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                optionsAnimator1.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                        case 2:
                            aika = 0f;
                            if (!optionsAnimator2.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                optionsAnimator2.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                        case 3:
                            aika = 0f;
                            if (!optionsAnimator3.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                optionsAnimator3.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                        case 4:
                            aika = 0f;
                            if (!optionsAnimator4.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                optionsAnimator4.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                    }
                }

            }

            else if (im.vasen == 1 && im.oikea == 0)
            {
                if (aika > 0.5f)
                {
                    selectedOption += 1;
                    if (selectedOption > numberOfOptions)
                    {
                        selectedOption = 1;
                    }
                    Debug.Log(selectedOption);

                    switch (selectedOption)
                    {
                        case 1:
                            aika = 0f;
                            if (!optionsAnimator1.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                optionsAnimator1.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                        case 2:
                            aika = 0f;
                            if (!optionsAnimator2.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                optionsAnimator2.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                        case 3:
                            aika = 0f;
                            if (!optionsAnimator3.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                optionsAnimator3.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                        case 4:
                            aika = 0f;
                            if (!optionsAnimator4.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
                            {
                                optionsAnimator4.Play("MenuButtonAnimation");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            break;
                    }
                }
            }
            else if (im.vasen == 1 && im.oikea == 1)
            {
                Debug.Log("Picked: " + selectedOption);

                switch (selectedOption)
                {
                    case 1:
                        CameraOffset.UpdateCameraOffset(0);
                        break;
                    case 2:
                        CameraOffset.UpdateCameraOffset(1);
                        break;
                    case 3:
                        CameraOffset.UpdateCameraOffset(2);

                        break;
                    case 4:
                        MainMenuMenu.SetActive(true);
                        optionsMenu.SetActive(false);
                        break;
                }
            }
        }
    }
}
