public  class HttpTool
    {
        private  readonly HttpClient httpClient;

        public HttpTool(string baseUrl)
        {
            httpClient = new HttpClient() { BaseAddress = new Uri(baseUrl) };
            httpClient.Timeout = TimeSpan.FromMilliseconds(2000);
           // httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.MaxResponseContentBufferSize = 256000;

            //httpClient.SendAsync(new HttpRequestMessage
            //{
            //    Method = new HttpMethod("HEAD"),
            //    RequestUri = new Uri(baseUrl + "/")
            //}).Result.EnsureSuccessStatusCode();
        }
        public string getUrl(string url, List<KeyValuePair<string, string>> paramArray)
        {
            string result = "";
            url = url + "?" + buildParam(paramArray);
            HttpResponseMessage message = null;
            var task = httpClient.GetAsync(url);
            message = task.Result;
            if (message != null && message.StatusCode == System.Net.HttpStatusCode.OK)
            {
                using (message)
                {
                    result = message.Content.ReadAsStringAsync().Result;
                }
            }
            result = decodeStr(result);
            return result;
        }
        public string postForm(string url, List<KeyValuePair<string, string>> paramArray)
        {
            string result = "";
            var postData = buildParam(paramArray);
            var data = Encoding.ASCII.GetBytes(postData);
            HttpResponseMessage message = null;
            using (Stream dataStream = new MemoryStream(data ?? new byte[0]))
            {
                using (HttpContent content = new StreamContent(dataStream))
                {
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    var task = httpClient.PostAsync(url, content);
                    message = task.Result;
                }
            }
            if (message != null && message.StatusCode == System.Net.HttpStatusCode.OK)
            {
                using (message)
                {
                    result = message.Content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }
        private async Task<string> getCharSetAsync(HttpContent httpContent)
        {
            var charset = httpContent.Headers.ContentType.CharSet;
            if (!string.IsNullOrEmpty(charset))
                return charset;
            var content = await httpContent.ReadAsStringAsync();
            var match = Regex.Match(content, @"charset=(?<charset>.+?)""", RegexOptions.IgnoreCase);
            if (!match.Success)
                return charset;
            return match.Groups["charset"].Value;
        }

        private static async void GetData()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
            HttpResponseMessage response = null;
            response = await httpClient.GetAsync("http://services.odata.org/Northwind/Northwind.svc/Regions");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Response Status Code and Reason Phrase: " + response.StatusCode + " " + response.ReasonPhrase);
                string responseBodyAsText = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Received payload of " + responseBodyAsText.Length + " characters");
                //Console.WriteLine(responseBodyAsText);
            }
        }

       

        private  string buildParam(List<KeyValuePair<string, string>> paramArray, Encoding encode = null)
        {
            string url = "";

            if (encode == null) encode = Encoding.UTF8;

            if (paramArray != null && paramArray.Count > 0)
            {
                var parms = "";
                foreach (var item in paramArray)
                {
                    parms += string.Format("{0}={1}&", encodeStr(item.Key, encode), encodeStr(item.Value, encode));
                }
                if (parms != "")
                {
                    parms = parms.TrimEnd('&');
                }
                url += parms;

            }
            return url;
        }
        private  string encodeStr(string content, Encoding encode = null)
        {
       

            return System.Web.HttpUtility.UrlEncode(content, Encoding.UTF8);

        }
        private string decodeStr(string content, Encoding encode = null)
        {
       
           return System.Web.HttpUtility.UrlDecode(content, Encoding.UTF8);
        }
        
        private string UnicodeToString(string srcText)
        {
            string dst = "";
            string src = srcText;
            int len = srcText.Length / 6;
            for (int i = 0; i <= len - 1; i++)
            {
                string str = "";
                str = src.Substring(0, 6).Substring(2);
                src = src.Substring(6);
                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                dst += Encoding.Unicode.GetString(bytes);
            }
            return dst;
        }
    }