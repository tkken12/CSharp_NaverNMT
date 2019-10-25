using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp1 {
    public class RestAPI{
        internal String API(string tessQuery, string tessSoruce, string tessTarget) {
            string url = "https://openapi.naver.com/v1/language/translate";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "enPKzotuFU0i_ZSLFoiT");
            request.Headers.Add("X-Naver-Client-Secret", "qSOpKL68ax");
            request.Method = "POST";
            //string query = tessQuery;
            byte[] byteDataParams = Encoding.UTF8.GetBytes("source="+tessSoruce+"&target="+tessTarget+"&text=" + tessQuery);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteDataParams.Length;
            Stream st = request.GetRequestStream();
            st.Write(byteDataParams, 0, byteDataParams.Length);
            st.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string text = reader.ReadToEnd();
            stream.Close();
            response.Close();
            reader.Close();
            return text;
            
        }
    }

}
