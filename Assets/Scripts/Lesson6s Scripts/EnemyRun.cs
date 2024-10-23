using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform[] checkPoints; // 8 điểm phải được đặt đúng theo thứ tự lần lượt mà xe sẽ đi qua đồng thời có trục Z hướng đến nhau
                             // khoảng cách giữa 2 điểm ở mỗi góc cũng phải đủ lớn và đồng đều
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ReachTarget())
        {
            SetNextIndex();
            GetStartQuaternion();
        }
        SlerpTo();
        Move();
    }
    float speed;
    int index = 0;
    float turnTime = 2;
    float runTime = 0;
    float t = 0;
    private void Move()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    bool ReachTarget()
    {
        return Vector3.Dot(checkPoints[index].position - transform.position, transform.forward) <= 0;
    }
    void SlerpTo()
    {
        if (Vector3.Dot((checkPoints[index].position - transform.position).normalized, transform.forward) > 0.9988f)
        {
            transform.rotation = Quaternion.LookRotation(checkPoints[index].position - transform.position);
            speed = 20;
            return;
        }
        if (runTime <= turnTime)
        {
            t = runTime / turnTime;
            runTime += Time.deltaTime;
        }
        if (t >= 1) t = 1;
        transform.rotation = Quaternion.Slerp(startQua, GetEndQuaternion(), t);
        //Debug.Log(t);
        speed = ((checkPoints[index].position - transform.position).magnitude + 10f) / turnTime; // warning the plus value to distance
    }
    Quaternion startQua;
    void GetStartQuaternion()
    {
        startQua = Quaternion.LookRotation(transform.forward);
    }
    void SetNextIndex()
    {
        if (index < checkPoints.Length - 1)
        {
            index++;
        }
        else index = 0;
        runTime = 0;
    }
    Quaternion GetEndQuaternion()
    {
        return Quaternion.LookRotation(checkPoints[index].transform.forward);
    }
}
