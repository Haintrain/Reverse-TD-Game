using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnimate : MonoBehaviour
{

    // An array with the sprites used for animation
    public Sprite[] animSprites;

    // How fast to change frame in the animation
    public int framesPerSec = 20;

    // Reference to the renderer of the sprite
    // game object
    private Image sr;

    // Index of the next frame to show in the animation
    private int nextFrameIndex = 0;

    // Variable for keeping track of time since
    // last frame change
    private float timeSinceLastFrame = 0.0f;


    // Use this for initialization
    void Start()
    {
        //GameyManager.gameState = GameyManager.GameState.Menu;
        // Get a reference to game object renderer and
        // cast it to Sprite Render
        sr = GetComponent<Image>();
        Time.timeScale = 1;
    }

    void Update()
    {
        // Add time since last game frame to time since last
        // animation frame change
        timeSinceLastFrame += Time.deltaTime;
        //Debug.Log(timeSinceLastFrame);
        //Debug.Log(Time.timeScale);

        //Check if it's time for animation frame change
        if (timeSinceLastFrame > 1f / (float)framesPerSec)
        {

            //Change the sprite
            sr.sprite = animSprites[nextFrameIndex];
            //Increment frame index and 
            //reset to 0 if it's larger than the number
            //of frames in animSprites
            nextFrameIndex++;
            nextFrameIndex %= animSprites.Length;

            //Reset time since last animation frame
            timeSinceLastFrame -= 1f / (float)framesPerSec;
        }
    }

    void OnDisable()
    {
        Time.timeScale = PlayPauseFastforward.currentMax;
    }
}