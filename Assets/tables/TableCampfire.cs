using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TableCampfire{

    static public int POP_MAXIUM_ORI = 5;//初始5人口上限
    static public int POP_MAXIUM_MOD = 2;//每一级篝火+2人口
    static public int POP_ORI = 1;//初始1人数
    static public int CF_MAXIUM_ORI = 100;//初始篝火强度上限
    static public int CF_MAXIUM_MOD = 20;//每一级篝火+20强度
    static public float CF_WEAKEN = 0.01f;//每秒篝火强度削弱比例
    static public int POP_BORN_ORI = 45;//100强度时，初始45秒生一个村民
    static public int POP_BORN_MOD = 15;//每个村民+15秒
    static public int CIV_BURN = 30;//每个被烧的村民+30篝火强度
}
