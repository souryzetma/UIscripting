using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RemoveItem : MonoBehaviour
{
    // Start is called before the first frame update
    SpawnItemRandomly here;
    void Start()
    {
        here = GetComponent<SpawnItemRandomly>();
    }

    // Update is called once per frame
    void Update()
    {
        if (here.itemClones.Count > 0)
        {
            if (here.itemClones[0].transform.position.y < -30)
            {
                Destroy(here.itemClones[0].gameObject);//phương thức Destroy không tự động làm rỗng biến
                                                       //mà chỉ hủy bỏ đối tượng và
                                                       //khiến biến tham chiếu đến một đối tượng không còn tồn tại
                here.itemClones.RemoveAt(0);//hồi sinh
            }
        }
    }
}
