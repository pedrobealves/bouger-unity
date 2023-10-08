using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartMenu : MonoBehaviour
{
    [SerializeField] private RectTransform selection;
    [SerializeField] private RectTransform[] buttons;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;

    public AudioSource soundSource { get; private set; }

    private int currentPosition;

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        ChangePosition(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Submit"))
            Interact();
    }

    public void ChangePosition(int _change)
    {
        currentPosition += _change;

        if (_change != 0)
            soundSource.PlayOneShot(changeSound);

        if (currentPosition < 0)
            currentPosition = buttons.Length - 1;
        else if (currentPosition > buttons.Length - 1)
            currentPosition = 0;

        AssignPosition();
    }
    private void AssignPosition()
    {
        selection.position = new Vector3(selection.position.x, buttons[currentPosition].position.y);
    }
    private void Interact()
    {

        soundSource.PlayOneShot(interactSound);


        if (currentPosition == 0)
        {
            //Start game
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (currentPosition == 1)
        {
            //Open Settings
        }
        else if (currentPosition == 3)
            Application.Quit();
    }
}
