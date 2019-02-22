using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Affdex; 


//Parsed image data will be sent to the ImageResultsListener methods
public class ImageResultsParser : ImageResultsListener
{

    //emotion levels
    public float joyLevel;
    public float sadnessLevel;
    public float surpriseLevel;

    public override void onFaceFound(float timestamp, int faceId)
    {

    }

    //called when the Affectiva SDK loses a facial detection
    public override void onFaceLost(float timestamp, int faceId)

    {
        //set emotion levels to 0 (will cause character to be Idle)
        joyLevel = 0;
        sadnessLevel = 0;
        surpriseLevel = 0;
    }

    //called every second whether there is a face detected or not
    public override void onImageResults(Dictionary<int, Face> faces)
    {
        if (faces.Count > 0)
        {
            //set emotion levels
            faces[0].Emotions.TryGetValue(Emotions.Joy, out joyLevel);
            faces[0].Emotions.TryGetValue(Emotions.Sadness, out sadnessLevel);
            faces[0].Emotions.TryGetValue(Emotions.Surprise, out surpriseLevel);
        }
    }
}

