using UnityEngine;
using System.Collections;

   

public class FacialExpressions : MonoBehaviour
{

    //Script containing levels of emotions
    ImageResultsParser userEmotions; 

    //player Transform used to obtain reference to UserEmotions script
    Transform player;

    //Used to change the face from smiling to frowning
    public Renderer faceRenderer;

    private Material faceMaterial;
    private Vector2 uvOffset;
    public bool joy;
    public bool sad;
    public bool surprise; 
    private float y; 

    // Initialization and Setting references
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Sailor").transform;
        userEmotions = player.GetComponent<ImageResultsParser>();
        uvOffset = Vector2.zero;
        faceMaterial = faceRenderer.materials[1];
    }

    // Setting the user's dominant emotion every frame
    void FixedUpdate()
    {
        if (userEmotions.joyLevel >= 40)
        {
            setJoyful();
            joy = true;
            sad = false;
            surprise = false; 

           
            if (transform.position.y >= 10.0)
            {
                y = 0.0f;
            }
            else
            {
                transform.Translate(0.0f, 0.1f, 0.0f, Space.World);
            }

        }
        else if(userEmotions.sadnessLevel>=1)
        {
            setSad();
            sad = true;
            joy = false;
            surprise = false;
        }
        else if (userEmotions.surpriseLevel >= 10 && userEmotions.sadnessLevel < 10)
        {
            setSurprise();
            sad = false;
            joy = false;
            surprise = true;
        }

        else
        {
            setIdle();
            sad = false;
            joy = false;
            surprise = false; 
        }

        faceMaterial.SetTextureOffset("_MainTex", uvOffset);
    }





    //sets the Character's emotion to Idle (Emotionless)
    void setIdle()
    {
        uvOffset = new Vector2(0, 0);
    }

    //sets the Character's emotion to Joyful (Smiling)
    void setJoyful()
    {
        uvOffset = new Vector2(0.25f, 0);
    }

    //sets the Character's emotion to Sad (Frowning)
    void setSad()
    {
        uvOffset = new Vector2(0, -0.25f);
    }

    void setSurprise()
    {
        uvOffset = new Vector2(0.25f,-.25f);
    }


}
