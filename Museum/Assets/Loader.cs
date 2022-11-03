using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
//Идеальное расстояние между комнатами 10.488f
public class Loader : MonoBehaviour
{
    public Text logText;
    // Load a .jpg or .png file by adding .bytes extensions to the file
    // and dragging it on the imageAsset variable.
    //public TextAsset imageAsset;
    //public string p = "C:\\Games\\pic.png";
    public string dirPath = "images";
    public GameObject framePrefab;
    public GameObject roomPrefab;

    List<GameObject> frames = new List<GameObject>();
    public void Start()
    {
        // Create a texture. Texture size does not matter, since
        // LoadImage will replace with the size of the incoming image.
        Texture2D tex = new Texture2D(2, 2);
        

        //tex.LoadImage(imageAsset.bytes);
        string[] png_path_array = System.IO.Directory.GetFiles(dirPath);
        logText.text = "";
        int howMuchPics= png_path_array.Length;
        float AroundGall = howMuchPics / 4.0f;
        int galNum = Mathf.CeilToInt(AroundGall);
        CreateGallery(galNum);

        for (int i = 0; i < howMuchPics; i++)
        {
            //GameObject new_frame = Instantiate(framePrefab);
            //new_frame.transform.position = new Vector3(i * 5, 0, 0);

            RenderPicture(frames[i],png_path_array[i]);
            //frames.Add(new_frame);
        }
        //CreateGallery(15);
        foreach (var item in png_path_array)
        {
            logText.text += item.ToString()+"\n";
        }
        //tex.LoadImage(System.IO.File.ReadAllBytes(p));
        //GetComponent<Renderer>().material.mainTexture = tex;
    }

    void CreateGallery(int Galleries)
    {
        for (int i = 0; i < Galleries; i++)
        {
            Room room=CreateRoom(new Vector3(i* 10.488f, 0, 0)).GetComponent<Room>();
            for (int j = 0; j < 4; j++)
            {
                frames.Add(room.frames[j]);
            }
            if (i != 0)
            {
                room.BackDoor.SetActive(false);
            }
            if (i != Galleries-1)
            {
                
                room.FrontDoor.SetActive(false);
            }
        }
    }

    GameObject CreateRoom(Vector3 where)
    {
        GameObject room= Instantiate(roomPrefab);
        room.transform.position = where;
        return room;
    }
    void RenderPicture(GameObject frame,string path)
    {
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(System.IO.File.ReadAllBytes(path));

        int h = tex.height;
        int w = tex.width;

        float max = h;
        if(w>max)max = w;

        logText.text += (h).ToString() + "x" + (w).ToString() + "->"+(h/ max).ToString() + "x"+ (w / max).ToString() + "\n";

        float ratio = h / w;//сколько ширин в высоте   (//ширина, 1, высота)
        frame.transform.localScale= new Vector3(w/max, 1, h/max)* 0.19f;

        frame.GetComponent<Renderer>().material.mainTexture = tex;

    }
}