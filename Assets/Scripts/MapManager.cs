using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager> {

    public int width = 40, height = 40;
    public bool[][] mapPass;
    public List<Building> listBuilding;


    public float blockWidth, blockHeight, StartX, StartY; //地图每格宽高，（0,0）坐标
    private Vector3 originPosition;
    private Vector3 xDiff, yDiff;


    // Use this for initialization
    void Start () {
        originPosition = new Vector3(StartX, StartY, 0);
        xDiff = new Vector3(blockWidth * 0.5f, blockHeight * 0.5f, 0);
        yDiff = new Vector3(blockWidth * 0.5f, -blockHeight * 0.5f, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //斜45度坐标，对象sprite的size，对象占几格，对象的底面中心在sprite上的坐标
    //按最左格计算斜45度坐标
    public Vector3 calcPosition(int x, int y, Vector2 size, Vector2 leftCenter) {
        Vector3 leftPos = calcStandardPosition(x, y); //sprite的45坐标的最左格世界坐标
        return leftPos + size / 2 - leftCenter; //sprite中心世界坐标


    }

    public Vector3 calcStandardPosition(int x, int y) {
        return originPosition + x * xDiff + y * yDiff;
    }
}
