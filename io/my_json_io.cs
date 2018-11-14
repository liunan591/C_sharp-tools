using LitJson;
using System.IO;
using System.Text;

namespace nc_with_sin
{
    class my_json_io
    {
        public static void write_Json_to_file(JsonData jsonData, string path)
        {
            string json = jsonData.ToJson();    //将以上数据转为Json格式的文本
            StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);   //利用写入流创建文件
            sw.Write(json);     //写入数据
            sw.Close();     //关闭流
            sw.Dispose();       //销毁流
        }

        public static string[] read_config(string cf_file = "cf-inf.json")
        {
            JsonData jsonData = JsonMapper.ToObject(File.ReadAllText(cf_file));
            string[] cf_info = { jsonData["python_location"].ToString(),
                jsonData["pip_location"].ToString(), jsonData["first_use"].ToString() };
            jsonData["first_use"] = "false";
            write_Json_to_file(jsonData, cf_file);
            return cf_info;

        }

        public static object read_obj(string cf_file = "cf-inf.json")
        {
            JsonData jsonData = JsonMapper.ToObject(File.ReadAllText("config.json"));
            foreach (JsonData temp in jsonData)    //temp在这里代表一个对象
            {
                JsonData idValue = temp["id"];
                JsonData nameValue = temp["Name"];
                object.ID = Int32.Parse(idValue.ToString());
                object.Name = nameValue.ToString();
            }
            //使用泛型解析json
            //Json里面对象的键必须跟类里面的字段或者属性保持一致
            //List<Skill> skillList = JsonMapper.ToObject<List<Skill>>(File.ReadAllText(cf_file));


            //解析单独一个对象
            //Player p = JsonMapper.ToObject<Player>(File.ReadAllText("主角信息.txt"));

            //Player p = new Player();
            //string json = JsonMapper.ToJson(p);
            //Console.Write(p);
        }

    }
}
