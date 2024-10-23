using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //[SerializeField]
    //float speed = 1000;
    //Vector2 mouse = new Vector2 (0, 0);
    void Update()
    {
        //mouse.x += Input.GetAxis("Mouse X"); //gán cho các giá trị biến động từ -1 đến 1 của axis
        //mouse.y += Input.GetAxis("Mouse Y"); //cộng dồn để không bị giới hạn góc quay mỗi frame (là 1 góc duy nhất có giá trị get ra trong khoảng giá trị của axis)
        //transform.rotation = Quaternion.Euler(- mouse.y, mouse.x, 0); //quỹ đạo chuột di chuyển lên xuống sẽ quy định hành vi xoay trục x để obj hướng lên hoặc chốc xuống, quỹ đạo chuột di chuyển trái phải cần xoay trục y để obj xoay trái phải, trục z sẽ xoay vật thể theo phương ngang


        //float mouse = Input.GetAxis("Mouse X");
        //transform.rotation *= Quaternion.AngleAxis(mouse * Time.deltaTime * speed, Vector3.up);

        // Phương pháp sử dụng hai cam, một dùng để theo dõi xe, một (main cam) dùng để chiếu vị trí trỏ chuột vào không gian 3D
        //giúp trục z của trỏ chuột trong không gian 3D được trùng phương với trục z của xe
        //đồng thời xoay main cam theo trục z của xe để hướng của trục z trỏ chuột cũng thay đổi tương ứng giúp xoay được góc đáng kể mà không cần cộng dồn và tránh hiện tượng giá trị x, y di chuyển ra quá xa dẫn đến ngừng xoay
        Vector3 mouse = Input.mousePosition;
        mouse.z = 30;
        mouse = Camera.main.ScreenToWorldPoint(mouse); // phải gán z trước khi chuyển đổi vì việc gán z ngay sau khi chuyển đổi chỉ di dời một điểm tương ứng trên không gian thế giới đi, không phản ánh vị trí tương quan giữa input và cam
        Vector3 dir = mouse - transform.position;
        dir.y = 0; // phải khóa trục y thì phương thức LookRotation xoay cả x và y để hướng z theo dir
        transform.rotation = Quaternion.LookRotation(dir);
        // Yếu: phương pháp chuyển đổi tọa độ này đã khuếch đại mức độ ảnh hưởng của việc di chuyển của chuột khiến xe xoay như điên khi khoảng cách rê chuột lớn mà không có cách nào giải quyết
    }
}
