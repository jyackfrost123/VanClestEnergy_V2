using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement; 

public class energyEnemyController : MonoBehaviour
{
 
    [SerializeField]private int _enemyenergyNum = 0;
    public int EnemyEnergyNum{
        get{return _enemyenergyNum;}
        set{
            _enemyenergyNum = value;            
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
        EnemyEnergyNum = 0;
    }

    public void AddEnemyEnergy(){
        if(EnemyEnergyNum < MAX){
            EnemyEnergyNum++;
            changeImage();
            Instantiate(se, new Vector3(0, 0, 0), Quaternion.identity);
        }

    }
    
    public void AddThreeEnemyEnergy(){
        if(EnemyEnergyNum < MAX){
            EnemyEnergyNum+=3;
            if(EnemyEnergyNum > MAX) EnemyEnergyNum = MAX;
            changeImage();
            Instantiate(se, new Vector3(0, 0, 0), Quaternion.identity);
        }

    }

    public void SubstractEnemyEnergy(){
        if(MIN < EnemyEnergyNum){
            EnemyEnergyNum--;
            changeImage();
            Instantiate(se, new Vector3(0, 0, 0), Quaternion.identity);
        }
        
    }

    public void BootEnemyEnergy(){
        if(EnergyBlastDraw <= EnemyEnergyNum){
            EnemyEnergyNum = EnemyEnergyNum - 7;
            changeImage();
            Instantiate(drawSE, new Vector3(0, 0, 0), Quaternion.identity);
        }

    }

    public void ResetEnemyEnergy(){
        if(EnemyEnergyNum != 0){
            EnemyEnergyNum = 0;
            changeImage();
            Instantiate(restartSE, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void ChangeEnemyScene(){
        SceneManager.LoadScene("SampleScene");
        //Instantiate(se, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void changeImage(){
        foreach(Image img in uiSprite){
            img.color = new Color(255.0f, 255.0f, 255.0f);
        }
        for(int i = 0; i < _enemyenergyNum; i++){
            uiSprite[i].color = new Color(51.0f/ 255.0f ,255.0f/ 255.0f , 0);
            //EditorUtility.SetDirty(uiSprite[i]);
        }
    }
}
