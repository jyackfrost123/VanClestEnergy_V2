using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement; 

public class energyController : MonoBehaviour
{

    [SerializeField]private int _energyNum = 0;
    public int EnergyNum{
        get{return _energyNum;}
        set{
            _energyNum = value;

            foreach(Image img in uiSprite){
                img.color = new Color(255, 255, 255);
            }
            for(int i = 0; i < _energyNum; i++){
                uiSprite[i].color = new Color(51,255, 0);
                //EditorUtility.SetDirty(uiSprite[i]);
            }
            
        }
    }

    [SerializeField]private Image[] uiSprite;

    [SerializeField] private GameObject se;
    [SerializeField] private GameObject drawSE;
    [SerializeField] private GameObject restartSE;

    private bool isChange = false;

    private const int MAX = 10;
    private const int MIN = 0;
    private const int EnergyBlastDraw = 7;

    // Start is called before the first frame update
    void Start()
    {
        EnergyNum = 0;
    }

    public void AddEnergy(){
        if(EnergyNum < MAX){
            EnergyNum++;
            changeImage();
            Instantiate(se, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void AddThreeEnergy(){
        if(EnergyNum < MAX){
            if(EnergyNum+3 > MAX) EnergyNum = MAX;
            else EnergyNum+=3;

            changeImage();
            Instantiate(se, new Vector3(0, 0, 0), Quaternion.identity);
            
        }
    }

    public void SubstractEnergy(){
        if(MIN < EnergyNum){
            EnergyNum--;
            changeImage();
            Instantiate(se, new Vector3(0, 0, 0), Quaternion.identity);
        }
        
    }

    public void BootEnergy(){
        if(EnergyBlastDraw <= EnergyNum){
            EnergyNum = EnergyNum - 7;
            changeImage();
           Instantiate(drawSE, new Vector3(0, 0, 0), Quaternion.identity);
        }

    }

    public void ResetEnergy(){
        if(EnergyNum != 0){
            EnergyNum = 0;
            changeImage();
            Instantiate(restartSE, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void ChangeScene(){
        SceneManager.LoadScene("twoPlayerMode");
    }

    public void changeImage(){
        foreach(Image img in uiSprite){
            img.color = new Color(255.0f, 255.0f, 255.0f);
        }
        for(int i = 0; i < _energyNum; i++){
            uiSprite[i].color = new Color(51.0f/ 255.0f ,255.0f/ 255.0f , 0);
            //EditorUtility.SetDirty(uiSprite[i]);
        }
    }
}
